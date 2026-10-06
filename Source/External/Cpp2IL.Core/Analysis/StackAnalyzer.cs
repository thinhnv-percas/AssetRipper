using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

public class StackAnalyzer
{
    [DebuggerDisplay("Size = {Size}, Dynamic = {Dynamic}")]
    private class StackState
    {
        public int Size;

        /// <summary>
        /// AssetRipper: iteration 066 - the stack pointer was set to a value the code computed (a variable-size
        /// allocation), so a stack-relative operand no longer names a slot of the fixed frame.
        /// </summary>
        public bool Dynamic;

        public StackState Copy() => new() { Size = this.Size, Dynamic = this.Dynamic };
    }

    /// <summary>The register that holds the stack pointer once a dynamic allocation has moved it.</summary>
    public const string DynamicStackPointer = "SPDYN";

    /// <summary>How many variable-size stack allocations were recovered as <see cref="OpCode.StackAlloc"/>.</summary>
    public static int DynamicAllocationsRecovered;

    /// <summary>How many times the stack pointer was set to a computed value that is not a recognised allocation.</summary>
    public static int DynamicStackPointerUnrecognised;

    /// <summary>How many stack operands were read relative to the dynamic stack pointer rather than a fixed slot.</summary>
    public static int DynamicStackOperands;

    private Dictionary<Block, StackState> _inComingState = [];
    private Dictionary<Block, StackState> _outGoingState = [];
    private Dictionary<Instruction, StackState> _instructionState = [];

    // AssetRipper: where ARM64's frame pointer was set up, relative to the entry stack pointer; null when unknown
    // or when two paths disagree.
    private int? _framePosition;
    private bool _framePositionConflict;

    /// <summary>How many `add sp, x29, #k` resets were resolved against the frame pointer's setup.</summary>
    public static int StackResetsFromFramePointer;

    /// <summary>
    /// Max allowed count of blocks to visit (-1 for no limit).
    /// </summary>
    public static int MaxBlockVisitCount = 500000; //High enough to not be legitimately hit, but still give up if something loops infinitely.

    public static void Analyze(MethodAnalysisContext method)
        => Analyze(method.ControlFlowGraph!, method.ParameterOperands, method.AddWarning);

    /// <summary>AssetRipper: the analysis over a graph alone, so it can be tested without metadata behind it.</summary>
    public static void Analyze(ISILControlFlowGraph graph, List<IOperand>? parameterOperands = null, System.Action<string>? warn = null)
    {
        var analyzer = new StackAnalyzer();

        graph.RemoveUnreachableBlocks(); // Without this indirect jumps (in try catch i think) cause some weird stuff

        analyzer._inComingState = new Dictionary<Block, StackState> { { graph.EntryBlock, new StackState() } };

        analyzer.TraverseGraph(graph.EntryBlock);

        // The exit block has no outgoing state if it was never reached (e.g. every path loops or
        // throws). That's fine - just skip the end-of-method stack balance check in that case.
        if (analyzer._outGoingState.TryGetValue(graph.ExitBlock, out var outDelta) && outDelta.Size != 0)
        {
            var outText = outDelta.Size < 0 ? "-" + (-outDelta.Size).ToString("X") : outDelta.Size.ToString("X");
            warn?.Invoke($"Method ends with non empty stack ({outText}), the output could be wrong!");
        }

        analyzer.ResolveDynamicStack(graph);
        analyzer.ResolveFrameAliases(graph);
        analyzer.ResolveFramePointer(graph);
        analyzer.CorrectOffsets(graph);
        analyzer.KeepStoresReadThroughABaseAddress(graph);
        ReplaceStackWithRegisters(graph, parameterOperands ?? []);

        graph.RemoveNops();
        graph.RemoveEmptyBlocks();
    }

    /// <summary>
    /// AssetRipper: iteration 066 - the stack pointer after a variable-size allocation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A fully shared generic body allocates every local of a type parameter with
    /// <c>alloca(il2cpp_codegen_sizeof(T))</c>, which A64 writes as <c>mov xA, sp; sub xB, xA, size; mov sp, xB</c>.
    /// The stack walk only knew constant shifts, so it took the stack pointer to be unchanged: <c>mov xA, sp</c>
    /// named the bottom of the fixed frame every time, every buffer became an offset below one fixed slot, and that
    /// slot was typed as whatever the buffers were used as - <c>(nint)enumerator - num</c> in the recovered source.
    /// </para>
    /// <para>
    /// The model: <c>SP_new = SP_old - size</c>, held in a register of its own (<see cref="DynamicStackPointer"/>)
    /// so SSA versions it. An allocation whose three instructions are all there - the read of the stack pointer, the
    /// subtraction from exactly that value, and the write back of exactly the result - is a
    /// <see cref="OpCode.StackAlloc"/>, which is what il2cpp's own source says it is. Anything else that sets the stack
    /// pointer still moves <see cref="DynamicStackPointer"/>, and every stack operand while it is in effect is read
    /// relative to it rather than named after a fixed slot. Operands through the frame pointer are untouched: the
    /// frame does not move. The epilogue's reset from the frame pointer ends the dynamic region.
    /// </para>
    /// </remarks>
    private void ResolveDynamicStack(ISILControlFlowGraph graph)
    {
        var dynamicSp = new Register(null, DynamicStackPointer);

        foreach (var block in graph.Blocks)
        {
            for (var index = 0; index < block.Instructions.Count; index++)
            {
                var instruction = block.Instructions[index];
                if (!_instructionState.TryGetValue(instruction, out var state))
                    continue;

                if (instruction is { OpCode: OpCode.ShiftStack, Operands: [Register newStackPointer] })
                {
                    if (TryRecogniseAllocation(block, index, newStackPointer, state))
                        Interlocked.Increment(ref DynamicAllocationsRecovered);
                    else
                        Interlocked.Increment(ref DynamicStackPointerUnrecognised);

                    instruction.OpCode = OpCode.Move;
                    instruction.SetOperands([dynamicSp, newStackPointer]);
                    _instructionState.Remove(instruction);
                    continue;
                }

                if (!state.Dynamic)
                    continue;

                for (var i = 0; i < instruction.Operands.Count; i++)
                {
                    switch (instruction.Operands[i])
                    {
                        case StackOffset slot:
                            instruction.SetOperand(i, new MemoryOperand(dynamicSp, addend: slot.Offset));
                            Interlocked.Increment(ref DynamicStackOperands);
                            break;
                        case AddressOf { Target: StackOffset addressed } when instruction is { OpCode: OpCode.Move, Operands.Count: 2 } && i == 1:
                            if (addressed.Offset == 0)
                                instruction.SetOperand(1, dynamicSp);
                            else
                            {
                                instruction.OpCode = OpCode.Add;
                                instruction.SetOperands([instruction.Operands[0], dynamicSp, new Immediate(addressed.Offset)]);
                            }

                            Interlocked.Increment(ref DynamicStackOperands);
                            break;
                        case AddressOf { Target: StackOffset addressed }:
                        {
                            // the address is an operand of something else: compute it into a register of its own first
                            var temporary = new Register(null, $"SPDYNADDR{index}");
                            block.Instructions.Insert(index, new Instruction(-1, OpCode.Add, temporary, dynamicSp, new Immediate(addressed.Offset)));
                            index++;
                            instruction.SetOperand(i, temporary);
                            Interlocked.Increment(ref DynamicStackOperands);
                            break;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// <c>mov xA, sp; sub xB, xA, size; mov sp, xB</c> in one block, nothing redefining xA or xB in between. The
    /// subtraction becomes the allocation; the read of the old stack pointer is left for dead code elimination.
    /// </summary>
    private bool TryRecogniseAllocation(Block block, int setIndex, Register result, StackState atSet)
    {
        var subtractIndex = LastWriteBefore(block, setIndex, result.Name);
        if (subtractIndex < 0 || block.Instructions[subtractIndex] is not { OpCode: OpCode.Subtract, Operands: [_, Register oldStackPointer, var size] } subtract
            || size is not (Register or Immediate) || size is Register { Name: var sizeName } && sizeName == oldStackPointer.Name)
            return false;

        var readIndex = LastWriteBefore(block, subtractIndex, oldStackPointer.Name);
        if (readIndex < 0 || !_instructionState.TryGetValue(block.Instructions[readIndex], out var atRead) || atRead.Dynamic != atSet.Dynamic)
            return false;

        var isStackPointerRead = block.Instructions[readIndex] switch
        {
            // the fixed frame: the slot at the stack pointer itself
            { OpCode: OpCode.Move, Operands: [_, AddressOf { Target: StackOffset { Offset: 0 } }] } => !atRead.Dynamic,
            _ => false,
        };

        // after an earlier allocation the read is of the dynamic stack pointer; ResolveDynamicStack rewrites it to
        // exactly that once it reaches the read, which comes before this write in the block
        if (!isStackPointerRead && atRead.Dynamic)
            isStackPointerRead = block.Instructions[readIndex] is { OpCode: OpCode.Move, Operands: [_, Register { Name: DynamicStackPointer }] };

        if (!isStackPointerRead)
            return false;

        subtract.OpCode = OpCode.StackAlloc;
        subtract.SetOperands([subtract.Operands[0], size]);
        return true;
    }

    private static int LastWriteBefore(Block block, int before, string register)
    {
        for (var i = before - 1; i >= 0; i--)
            if (block.Instructions[i].Destination is Register { Name: var name } && name == register)
                return i;
        return -1;
    }

    // consider mov [reg], [stack pointer]
    // now we need to handle [reg] as if it were a stack pointer, forever.
    private void ResolveFrameAliases(ISILControlFlowGraph graph)
    {
        var aliases = new Dictionary<string, int>();

        foreach (var instruction in graph.EntryBlock.Successors.SelectMany(b => b.Instructions))
        {
            if (instruction is { OpCode: OpCode.Move, Operands: [Register destination, Register { Name: "rsp" }] }
                && _instructionState.TryGetValue(instruction, out var atCopy))
                aliases[destination.Name] = atCopy.Size;
        }

        if (aliases.Count == 0)
            return;

        // Following a register that gets reassigned would need flow analysis, so stop trusting it entirely
        foreach (var instruction in graph.Instructions)
        {
            if (instruction is { OpCode: OpCode.Move, Operands: [Register, Register { Name: "rsp" }] })
                continue;

            if (instruction.Destination is Register written)
                aliases.Remove(written.Name);
        }

        foreach (var instruction in graph.Instructions)
        {
            if (!_instructionState.TryGetValue(instruction, out var state))
                continue;

            for (var i = 0; i < instruction.Operands.Count; i++)
            {
                if (instruction.Operands[i] is not MemoryOperand { Index: null, Scale: 0, Base: Register frameBase } memory)
                    continue;

                if (!aliases.TryGetValue(frameBase.Name, out var frameOffset))
                    continue;

                instruction.SetOperand(i, new StackOffset((int)(frameOffset + memory.Addend - state.Size)));
            }
        }
    }

    /// <summary>How many memory operands through ARM64's frame pointer were named as the stack slot they are.</summary>
    public static int FramePointerSlotsResolved;

    private readonly List<Instruction> _framePointerStores = [];

    /// <summary>How many frame pointer stores were kept because only a neighbouring slot's address can read them.</summary>
    public static int FramePointerStoresKept;

    private static readonly System.Runtime.CompilerServices.ConditionalWeakTable<Instruction, object> FramePointerStores = new();
    private static readonly object FramePointerStoreMarker = new();

    /// <summary>Whether this store was written through ARM64's frame pointer before the slot was named.</summary>
    public static bool IsFramePointerStore(Instruction instruction) => FramePointerStores.TryGetValue(instruction, out _);

    /// <summary>How many addresses computed from ARM64's frame pointer were named as the address of their stack slot.</summary>
    public static int FramePointerAddressesResolved;

    /// <summary>How many methods set up a frame pointer that is then read as a plain value, and so were left alone.</summary>
    public static int FramePointerEscapes;

    /// <summary>
    /// AssetRipper: iteration 065 - ARM64's frame pointer as an alias of the stack.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <c>add x29, sp, #k</c> makes X29 the address of a fixed stack position, and the compiler then spills to and
    /// reloads from <c>[x29 - n]</c> as freely as from <c>[sp + m]</c>. <see cref="ResolveFrameAliases"/> handles
    /// the x86 form (<c>mov reg, rsp</c>) and only when the register is never written again; on A64 the epilogue
    /// always restores X29, so that rule never fires and every frame spill stayed a memory operand nothing could
    /// type. The cost is not one load: a fully shared body spills its <c>MethodInfo*</c> to <c>[x29 - 0x20]</c>
    /// and reloads it before every RGCTX read, so the class an interface lookup is handed - and with it the
    /// interface method - was unknown on 124 of Merge-Room's dispatches.
    /// </para>
    /// <para>
    /// The alias holds from the one instruction that sets it up until anything writes X29, which is a must
    /// dataflow over the blocks (a merge is aliased only if every predecessor is). Each operand
    /// <c>[x29 + a]</c> inside that region is the stack position <c>frame + a</c>, exactly the slot an
    /// SP-relative access to the same byte is named after - so a value spilled through one base and reloaded
    /// through the other becomes one storage. A method that reads X29 as a plain value while it is the frame -
    /// copies it, does arithmetic on it, hands it to a call - can reach a slot through a pointer this rewrite
    /// would not see, so it is left alone entirely.
    /// </para>
    /// </remarks>
    private void ResolveFramePointer(ISILControlFlowGraph graph)
    {
        const string framePointer = "X29";

        Instruction? setup = null;
        var frame = 0;

        foreach (var instruction in graph.Blocks.SelectMany(block => block.Instructions))
        {
            if (instruction is not { OpCode: OpCode.Move, Operands: [Register { Name: framePointer }, AddressOf { Target: StackOffset slot }] })
                continue;

            if (setup is not null || !_instructionState.TryGetValue(instruction, out var atSetup))
                return; // more than one frame, or one the stack walk did not reach: not this shape

            setup = instruction;
            frame = atSetup.Size + slot.Offset;
        }

        if (setup is null)
            return;

        static bool Writes(Instruction instruction) => instruction.Destination is Register { Name: framePointer };

        // must-dataflow: OUT starts at true everywhere (the top) and only falls
        var aliasedOut = graph.Blocks.ToDictionary(block => block, _ => true);
        bool AliasedIn(Block block) => block != graph.EntryBlock && block.Predecessors.Count > 0 && block.Predecessors.All(p => aliasedOut[p]);

        for (var changed = true; changed;)
        {
            changed = false;
            foreach (var block in graph.Blocks)
            {
                var aliased = AliasedIn(block);
                foreach (var instruction in block.Instructions)
                {
                    if (ReferenceEquals(instruction, setup))
                        aliased = true;
                    else if (Writes(instruction))
                        aliased = false;
                }

                if (aliased != aliasedOut[block])
                {
                    aliasedOut[block] = aliased;
                    changed = true;
                }
            }
        }

        var rewrites = new List<(Instruction Instruction, int Index, StackOffset Slot)>();
        var addresses = new List<(Instruction Instruction, Register Destination, StackOffset Slot)>();

        foreach (var block in graph.Blocks)
        {
            var aliased = AliasedIn(block);
            foreach (var instruction in block.Instructions)
            {
                // The address of a frame slot computed from X29 is the address of that slot, which is what the
                // lifter already writes for `add xN, sp, #k`. Doing the same here keeps an address-taken slot
                // visible to the passes that handle address-taken slots, rather than an escape.
                if (aliased && _instructionState.TryGetValue(instruction, out var at)
                    && instruction is { Operands: [Register { Name: not framePointer } destination, Register { Name: framePointer }, ..] })
                {
                    long? displacement = instruction switch
                    {
                        { OpCode: OpCode.Move, Operands.Count: 2 } => 0,
                        { OpCode: OpCode.Add, Operands: [_, _, Immediate added] } => added.Value,
                        { OpCode: OpCode.Subtract, Operands: [_, _, Immediate subtracted] } => -subtracted.Value,
                        _ => null,
                    };

                    if (displacement is { } amount)
                    {
                        addresses.Add((instruction, destination, new StackOffset((int)(frame + amount - at.Size))));
                        continue;
                    }
                }

                // the stack pointer reset from the frame pointer is the alias's own bookkeeping, nopped below
                if (instruction.OpCode == OpCode.ShiftStack)
                    continue;

                if (aliased && !ReferenceEquals(instruction, setup))
                {
                    for (var i = 0; i < instruction.Operands.Count; i++)
                    {
                        switch (instruction.Operands[i])
                        {
                            case MemoryOperand { Base: Register { Name: framePointer }, Index: null, Scale: 0 } memory
                                when _instructionState.TryGetValue(instruction, out var state):
                                rewrites.Add((instruction, i, new StackOffset((int)(frame + memory.Addend - state.Size))));
                                break;
                            case MemoryOperand { Base: Register { Name: framePointer } } or MemoryOperand { Index: Register { Name: framePointer } }:
                            case Register { Name: framePointer } when !(i == 0 && Writes(instruction)):
                                // the frame address escapes as a value: a slot may be reached through a pointer
                                Interlocked.Increment(ref FramePointerEscapes);
                                return;
                        }
                    }
                }

                if (ReferenceEquals(instruction, setup))
                    aliased = true;
                else if (Writes(instruction))
                    aliased = false;
            }
        }

        foreach (var (instruction, index, slot) in rewrites)
        {
            instruction.SetOperand(index, slot);

            // A store through the frame pointer was a memory store before it was a slot, and a slot past one whose
            // address is taken can be read through that address by anything the address is handed to - an invoker's
            // argument array is exactly that. Nothing names those reads, so the store stays a root (see
            // DeadCodeEliminator), as it was while it was a memory operand.
            if (index == 0 && instruction.Destination is StackOffset)
                _framePointerStores.Add(instruction);
        }

        foreach (var (instruction, destination, slot) in addresses)
        {
            instruction.OpCode = OpCode.Move;
            instruction.SetOperands([destination, new AddressOf(slot)]);
        }

        Interlocked.Add(ref FramePointerSlotsResolved, rewrites.Count);
        Interlocked.Add(ref FramePointerAddressesResolved, addresses.Count);
    }

    /// <summary>
    /// AssetRipper: iteration 065 - the frame pointer stores that only an address can read.
    /// </summary>
    /// <remarks>
    /// An invoker's argument array is built as consecutive slots, and the call is handed the first one's address:
    /// <c>[x29-0x30] = &amp;i; [x29-0x28] = buffer; invoker(…, &amp;[x29-0x30], …)</c>. Once those are named slots,
    /// the second is stored and never read by name, so every pass that drops a dead copy dropped it, and the
    /// argument went with it. A slot is kept when it belongs to a contiguous run of stored slots, none read by name,
    /// that starts at a slot whose address is taken - the only way anything reads it is through that address. A
    /// spill that is read back by name ends the run, which is what keeps the rule from holding on to scaffolding.
    /// Offsets here are the corrected, absolute ones.
    /// </remarks>
    private void KeepStoresReadThroughABaseAddress(ISILControlFlowGraph graph)
    {
        if (_framePointerStores.Count == 0)
            return;

        var addressTaken = new HashSet<int>();
        var stored = new HashSet<int>();
        var read = new HashSet<int>();

        foreach (var instruction in graph.Blocks.SelectMany(block => block.Instructions))
        {
            for (var i = 0; i < instruction.Operands.Count; i++)
            {
                switch (instruction.Operands[i])
                {
                    case AddressOf { Target: StackOffset addressed }:
                        addressTaken.Add(addressed.Offset);
                        break;
                    case StackOffset slot when i == 0 && instruction.OpCode == OpCode.Move:
                        stored.Add(slot.Offset);
                        break;
                    case StackOffset slot:
                        read.Add(slot.Offset);
                        break;
                }
            }
        }

        var reachable = new HashSet<int>();
        foreach (var start in addressTaken)
            for (var offset = start + 8; stored.Contains(offset) && !read.Contains(offset) && !addressTaken.Contains(offset); offset += 8)
                reachable.Add(offset);

        foreach (var instruction in _framePointerStores)
        {
            if (instruction.Operands.Count > 0 && instruction.Operands[0] is StackOffset slot && reachable.Contains(slot.Offset))
            {
                FramePointerStores.AddOrUpdate(instruction, FramePointerStoreMarker);
                Interlocked.Increment(ref FramePointerStoresKept);
            }
        }
    }

    private void CorrectOffsets(ISILControlFlowGraph graph)
    {
        foreach (var block in graph.Blocks)
        {
            foreach (var instruction in block.Instructions)
            {
                if (instruction is { OpCode: OpCode.ShiftStack })
                {
                    // Nop the shift stack instruction
                    instruction.OpCode = OpCode.Nop;
                    instruction.SetOperands();
                    continue;
                }

                int? state = null;

                // Correct offset for stack operands.
                for (var i = 0; i < instruction.Operands.Count; i++)
                {
                    var op = instruction.Operands[i];

                    var slot = op switch
                    {
                        StackOffset direct => direct,
                        AddressOf { Target: StackOffset addressed } => addressed,
                        _ => (StackOffset?)null
                    };

                    if (slot is { } offset)
                    {
                        // This can only be done before modifying any of the instruction operands,
                        // as doing so will make the dictionary lookup impossible.
                        state ??= _instructionState[instruction].Size;

                        var actual = new StackOffset(state.Value + offset.Offset);
                        instruction.SetOperand(i, op is AddressOf ? new AddressOf(actual) : actual);
                    }
                }
            }
        }
    }

    // Traverse the graph and calculate the stack state for each block and instruction
    private void TraverseGraph(Block initialBlock, int initialVisitedBlockCount = 0)
    {
        var blockLevelState = new Stack<(Block, int)>();
        blockLevelState.Push((initialBlock, initialVisitedBlockCount));

        while (blockLevelState.Count > 0)
        {
            var (block, visitedBlockCount) = blockLevelState.Pop();

            // Copy current state
            var incomingState = _inComingState[block];
            var currentState = incomingState.Copy();

            // Process instructions
            foreach (var instruction in block.Instructions)
            {
                _instructionState[instruction] = currentState;

                if (instruction is { OpCode: OpCode.ShiftStack, Operands: [Immediate fromFrame, Register] })
                {
                    // AssetRipper: the stack pointer reset from the frame pointer. Where the frame was set up is a
                    // fact of the path that reached here; a reset with no known frame changes nothing, as before.
                    if (_framePosition is { } frame)
                    {
                        currentState = currentState.Copy();
                        currentState.Size = frame + (int)fromFrame.Value;
                        currentState.Dynamic = false; // iteration 066: the frame does not move, so this ends a dynamic region
                        Interlocked.Increment(ref StackResetsFromFramePointer);
                    }
                }
                else if (instruction is { OpCode: OpCode.ShiftStack, Operands: [Register] })
                {
                    // AssetRipper: iteration 066 - the stack pointer set to a computed value; see ResolveDynamicStack
                    currentState = currentState.Copy();
                    currentState.Dynamic = true;
                }
                else if (instruction.OpCode == OpCode.ShiftStack)
                {
                    var offset = (int)((Immediate)instruction.Operands[0]).Value;
                    currentState = currentState.Copy();
                    currentState.Size += offset;
                }
                else if (instruction is { OpCode: OpCode.Move, Operands: [Register { Name: "X29" }, AddressOf { Target: StackOffset frameSlot }] })
                {
                    var position = currentState.Size + frameSlot.Offset;
                    _framePosition = _framePositionConflict || (_framePosition is { } seen && seen != position) ? null : position;
                    _framePositionConflict |= _framePosition is null;
                }
                else if (block.Instructions[^1] == instruction && block.BlockType == BlockType.TailCall)
                {
                    // Tail calls clear stack
                    currentState = currentState.Copy();
                    currentState.Size = 0;
                }
            }

            // Tail calls clear stack
            if (block.BlockType == BlockType.TailCall)
                currentState.Size = 0;

            _outGoingState[block] = currentState;

            visitedBlockCount++;

            if (MaxBlockVisitCount != -1 && visitedBlockCount > MaxBlockVisitCount)
                throw new DecompilerException($"Stack state not settling! ({visitedBlockCount} blocks already visited)");

            // Visit successors
            foreach (var successor in block.Successors)
            {
                // Already visited
                if (_inComingState.TryGetValue(successor, out var existingState))
                {
                    if (existingState.Size != currentState.Size)
                    {
                        var replaced = currentState.Copy();
                        replaced.Dynamic |= existingState.Dynamic;
                        _inComingState[successor] = replaced;
                        blockLevelState.Push((successor, visitedBlockCount + 1));
                    }
                    else if (currentState.Dynamic && !existingState.Dynamic)
                    {
                        // AssetRipper: iteration 066 - a merge reached by a moved stack pointer on any path is not
                        // the fixed frame on every path, so its stack operands cannot be named as fixed slots
                        var replaced = existingState.Copy();
                        replaced.Dynamic = true;
                        _inComingState[successor] = replaced;
                        blockLevelState.Push((successor, visitedBlockCount + 1));
                    }
                }
                else
                {
                    // Set incoming delta and add to queue
                    _inComingState[successor] = currentState.Copy();
                    blockLevelState.Push((successor, visitedBlockCount + 1));
                }
            }
        }
    }

    private static void ReplaceStackWithRegisters(ISILControlFlowGraph graph, List<IOperand> parameterOperands)
    {
        var instructions = graph.Instructions;

        // Replace stack offset operands
        foreach (var instruction in instructions)
        {
            for (var i = 0; i < instruction.Operands.Count; i++)
            {
                var operand = instruction.Operands[i];

                if (operand is StackOffset offset)
                    instruction.SetOperand(i, new Register(null, NameForSlot(offset)));

                if (operand is AddressOf { Target: StackOffset addressed })
                    instruction.SetOperand(i, new AddressOf(new Register(null, NameForSlot(addressed))));
            }
        }

        // Replace params
        for (var i = 0; i < parameterOperands.Count; i++)
        {
            var parameter = parameterOperands[i];

            if (parameter is StackOffset offset)
                parameterOperands[i] = new Register(null, NameForSlot(offset));
        }
    }

    private static string NameForSlot(StackOffset offset) => offset.Offset < 0 ? $"stack_-{-offset.Offset:X}" : $"stack_{offset.Offset:X}";
}
