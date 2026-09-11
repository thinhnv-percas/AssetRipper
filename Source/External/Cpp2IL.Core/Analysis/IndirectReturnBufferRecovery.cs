using System.Collections.Generic;
using System.Threading;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: names a read through a call's hidden return buffer as a field of the value the call
/// returned.
/// </summary>
/// <remarks>
/// <para>
/// A struct too large to come back in registers is returned through memory: the caller passes the
/// address of a stack slot in the hidden return buffer register - X8 on AAPCS64 - and the callee
/// writes the value there. The reads that follow are <c>[buffer + k]</c>, and the buffer is a local
/// defined by an address-take, so nothing types it and every one of them is an unresolved load.
/// </para>
/// <para>
/// The answer is not slot arithmetic. The slot the address was taken of is never written by an
/// instruction - the callee writes it - so there are no versions to choose between and no typed
/// destination slots to land on. What the buffer holds is exactly the call's return value, which the
/// call already names as its result operand, so <c>[buffer + k]</c> is the field of that value at
/// offset k. <c>ObscuredDouble::op_Increment</c> is the whole shape in six instructions: take the
/// address of a slot into X8, call <c>Increment</c>, then read 0x0, 0x10 and 0x20 back out - which
/// are that struct's three fields, as the store side of those same instructions independently says.
/// </para>
/// <para>
/// Which register is the buffer comes from the callee's own calling convention rather than from a
/// name written down here, so an architecture that returns a large struct some other way - x86-64
/// hands the caller a pointer back in RAX - matches nothing and is left alone.
/// </para>
/// <para>
/// Runs before <see cref="LocalVariables.ResolveTypesAndFields"/> so the rewritten base is typed and
/// its field resolved by the fixpoint that is already there, and after
/// <see cref="MetadataResolver.ResolveAll"/> so the callee is known.
/// </para>
/// </remarks>
public static class IndirectReturnBufferRecovery
{
    /// <summary>Reads renamed as a field of a returned value.</summary>
    public static int ReadsRecovered;

    /// <summary>Buffers whose reads could not all be attributed to one call, and so were left alone.</summary>
    public static int BuffersAmbiguous;

    public static void Run(MethodAnalysisContext method)
    {
        if (method.ControlFlowGraph is { } graph && method.DominatorInfo is { } dominators)
            Apply(graph, dominators, FillsAHiddenReturnBuffer);
    }

    /// <summary>
    /// AssetRipper: whether this call returns its value through the buffer register the given local
    /// sits in. Separated from <see cref="Apply"/> so the control flow reasoning can be tested without
    /// a metadata context behind it.
    /// </summary>
    private static bool FillsAHiddenReturnBuffer(Instruction call, LocalVariable buffer)
        => call.Operands is [MethodAnalysisContext callee, LocalVariable, ..]
            && callee.AppContext.InstructionSet.CallingConventionResolver is { } conventions
            && conventions.ReturnsViaHiddenBuffer(callee)
            && conventions.HiddenReturnBufferRegister(callee) is { } bufferRegister
            && bufferRegister.Name == buffer.Register.Name;

    public static void Apply(ISILControlFlowGraph graph, DominatorInfo dominators,
        System.Func<Instruction, LocalVariable, bool> fillsBuffer)
    {
        foreach (var block in graph.Blocks)
        {
            for (var i = 0; i < block.Instructions.Count; i++)
            {
                var instruction = block.Instructions[i];

                if (instruction is not { OpCode: OpCode.Move, Operands: [LocalVariable buffer, AddressOf { Target: LocalVariable slot }] })
                    continue;

                if (FilledBy(graph, dominators, block, i, buffer, slot, fillsBuffer) is not ({ } call, { } callBlock, var callIndex))
                    continue;

                if (call.Operands[1] is not LocalVariable returned)
                    continue;

                RewriteReadsAfter(graph, dominators, buffer, returned, callBlock, callIndex);
            }
        }
    }

    /// <summary>
    /// AssetRipper: the call this buffer was filled by, when exactly one call can have filled it.
    /// </summary>
    /// <remarks>
    /// The requirements are all evidence rather than shape: the buffer has to be in the register the
    /// callee's convention names for a hidden return, the callee has to actually return that way, and
    /// the address-take has to reach the call with nothing in between that could have written the slot
    /// under its own name. A second candidate call means the buffer was reused and nothing here can
    /// say which value a later read wanted, so the whole buffer is abandoned rather than guessed at.
    /// </remarks>
    private static (Instruction? Call, Block? Block, int Index) FilledBy(ISILControlFlowGraph graph,
        DominatorInfo dominators, Block definitionBlock, int definitionIndex, LocalVariable buffer, LocalVariable slot,
        System.Func<Instruction, LocalVariable, bool> fillsBuffer)
    {
        (Instruction? Call, Block? Block, int Index) found = (null, null, 0);

        foreach (var block in graph.Blocks)
        {
            for (var i = 0; i < block.Instructions.Count; i++)
            {
                var instruction = block.Instructions[i];

                if (!After(dominators, definitionBlock, definitionIndex, block, i))
                    continue;

                if (instruction.OpCode != OpCode.Call || !fillsBuffer(instruction, buffer))
                    continue;

                if (found.Call is not null)
                    return Ambiguous(); //Reused for a second return, so a read could mean either

                found = (instruction, block, i);
            }
        }

        // A write to the slot under its own name *between* the address-take and the call means the two
        // names are both live over the window the callee is supposed to own, and which one a later
        // read wanted is no longer decidable. After the call is a different matter entirely: the
        // compiler routinely reuses the same stack location to hold what it just read back out, and
        // SSA versions that write perfectly well.
        if (found.Call is not null && found.Block is { } callBlock && WrittenDirectlyBetween(graph, dominators,
                definitionBlock, definitionIndex, callBlock, found.Index, slot))
            return Ambiguous();

        return found;

        (Instruction?, Block?, int) Ambiguous()
        {
            Interlocked.Increment(ref BuffersAmbiguous);
            return (null, null, 0);
        }
    }

    private static bool WrittenDirectlyBetween(ISILControlFlowGraph graph, DominatorInfo dominators, Block fromBlock,
        int fromIndex, Block toBlock, int toIndex, LocalVariable slot)
    {
        foreach (var block in graph.Blocks)
        {
            for (var i = 0; i < block.Instructions.Count; i++)
            {
                if (!After(dominators, fromBlock, fromIndex, block, i) || After(dominators, toBlock, toIndex, block, i))
                    continue;

                if (block.Instructions[i].Destination is LocalVariable written && written.Register.Name == slot.Register.Name)
                    return true;
            }
        }

        return false;
    }

    private static void RewriteReadsAfter(ISILControlFlowGraph graph, DominatorInfo dominators, LocalVariable buffer,
        LocalVariable returned, Block callBlock, int callIndex)
    {
        foreach (var block in graph.Blocks)
        {
            for (var i = 0; i < block.Instructions.Count; i++)
            {
                // A read before the call is reading whatever the slot held beforehand, which this says
                // nothing about.
                if (!After(dominators, callBlock, callIndex, block, i))
                    continue;

                var instruction = block.Instructions[i];

                for (var operand = 0; operand < instruction.Operands.Count; operand++)
                {
                    if (instruction.Operands[operand] is not MemoryOperand { Index: null } memory
                        || memory.Base is not LocalVariable read
                        || !ReferenceEquals(read, buffer))
                        continue;

                    // The destination of a store through the buffer is the callee's own business; only
                    // the reads say anything about the value that came back.
                    if (operand == 0 && instruction.OpCode is OpCode.Move)
                        continue;

                    memory.Base = returned;
                    instruction.SetOperand(operand, memory);
                    Interlocked.Increment(ref ReadsRecovered);
                }
            }
        }
    }

    /// <summary>
    /// AssetRipper: whether one point in the graph is reached only by way of another. Within a block
    /// that is the instruction order; across blocks it is dominance, so a read on a path that does not
    /// go through the call is not counted as after it.
    /// </summary>
    private static bool After(DominatorInfo dominators, Block earlierBlock, int earlierIndex, Block block, int index)
        => ReferenceEquals(block, earlierBlock) ? index > earlierIndex : dominators.Dominates(earlierBlock, block);
}
