using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// Removes the IL2CPP runtime-metadata initialization guards the compiler emits near the top of
/// (almost) every method, plus il2cpp_runtime_class_init blocks.
/// </summary>
public static class MetadataInitGuardRemover
{
    private const string InitializeRuntimeMetadata = "il2cpp_codegen_initialize_runtime_metadata";
    private const string InitializeMethod = "il2cpp_codegen_initialize_method";
    private const string ClassInitExport = "il2cpp_runtime_class_init_export";
    private const string ClassInitActual = "il2cpp_runtime_class_init_actual";
    private const string ClassInitCodegen = "il2cpp_codegen_runtime_class_init";

    // Byte holding Il2CppClass's bitfield, of which bit 0 is initialized_and_no_error.
    // TODO this is almost certainly not correct on every version... but which?
    private const long InitialisedFlagOffset64 = 0x135;
    private const long InitialisedFlagOffset32 = 0xBD;

    // Offset of MethodInfo::rgctx_data
    private const long MethodRgctxOffset64 = 0x38;
    private const long MethodRgctxOffset32 = 0x1C;

    public static void Run(MethodAnalysisContext method)
    {
        var is32Bit = method.AppContext.Binary.is32Bit;
        Run(method.ControlFlowGraph!, is32Bit ? InitialisedFlagOffset32 : InitialisedFlagOffset64,
            Il2CppClassUsefulOffsets.TryGetOffset("cctor_finished", is32Bit, out var cctorFinished) ? cctorFinished : null);
    }

    /// <summary>AssetRipper: iteration 066 - class-init guards on the whole <c>cctor_finished_or_no_cctor</c> word.</summary>
    public static int ClassInitWordGuards;

    /// <summary>AssetRipper: iteration 066 - guards whose init arm is the class initializer followed by a copy of the other arm.</summary>
    public static int DuplicatedTailGuardsFolded;

    /// <summary>AssetRipper: iteration 066 - guards excised through a block that only forwards to the merge.</summary>
    public static int GuardsExcisedThroughForwardingBlock;

    /// <summary>AssetRipper: what a guard test can be recognised by, collected once per method.</summary>
    private sealed class GuardEvidence
    {
        public required HashSet<LocalVariable> ClassPointers { get; init; }
        public required HashSet<LocalVariable> ClassByteLoads { get; init; }
        public required HashSet<LocalVariable> ClassInitWordLoads { get; init; }
        public required HashSet<LocalVariable> ConstantAddresses { get; init; }
        public long? CctorFinishedOffset { get; init; }
    }

    // Rewrite any metadata init calls we didn't remove into movs.
    public static void RewriteUnguardedInits(MethodAnalysisContext method)
    {
        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (instruction.OpCode != OpCode.Call || instruction.Operands is not [StringLiteral { Value: InitializeRuntimeMetadata or InitializeMethod }, var result, var handle, ..])
                continue;

            instruction.OpCode = OpCode.Move;
            instruction.SetOperands(result, handle);
        }
    }
    
    // Removes the lazy-init guards protecting a generic method's inlined RGCTX metadata lookups.
    public static void RunRgctx(MethodAnalysisContext method)
    {
        var cfg = method.ControlFlowGraph!;
        var rgctxOffset = method.AppContext.Binary.is32Bit ? MethodRgctxOffset32 : MethodRgctxOffset64;

        var removedAny = false;

        foreach (var guard in cfg.Blocks.ToList())
            removedAny |= TryRemoveRgctxGuard(cfg, guard, rgctxOffset);

        if (removedAny)
            DeadCodeEliminator.Run(cfg);
    }

    private static bool TryRemoveRgctxGuard(ISILControlFlowGraph cfg, Block guard, long rgctxOffset)
    {
        if (guard.BlockType != BlockType.TwoWay || guard.Successors.Count != 2
            || guard.Instructions.Count == 0 || guard.Instructions[^1].OpCode != OpCode.ConditionalJump)
            return false;

        var isRgctxGuard = guard.Instructions.Any(i =>
            i.OpCode is OpCode.CheckEqual or OpCode.CheckNotEqual
            && (IsRgctxLoad(i.Operands[1], rgctxOffset) && IsZero(i.Operands[2])
                || IsRgctxLoad(i.Operands[2], rgctxOffset) && IsZero(i.Operands[1])));

        if (!isRgctxGuard)
            return false;

        var first = guard.Successors[0];
        var second = guard.Successors[1];

        // treat region calls as init boilerplate, exactly as the class-init flag test does
        return TryExcise(cfg, guard, first, second, true)
            || TryExcise(cfg, guard, second, first, true);
    }

    private static bool IsRgctxLoad(IOperand operand, long rgctxOffset) =>
        operand is MemoryOperand { Index: null, Scale: 0, Base: LocalVariable { Type: RuntimeMethodInfoAnalysisContext } } memory
        && memory.Addend == rgctxOffset;

    private static bool IsZero(IOperand operand) => operand is Immediate { Value: 0 };

    public static void Run(ISILControlFlowGraph cfg, long initialisedFlagOffset, long? cctorFinishedOffset = null)
        => Run(cfg, initialisedFlagOffset, cctorFinishedOffset, []);

    /// <summary>AssetRipper: <paramref name="knownClassPointers"/> seeds the class pointers, so the rules can be tested without metadata.</summary>
    public static void Run(ISILControlFlowGraph cfg, long initialisedFlagOffset, long? cctorFinishedOffset, IEnumerable<LocalVariable> knownClassPointers)
    {
        var removedAny = false;

        // AssetRipper: locals holding a byte of an Il2CppClass, so a bit test on one can be recognised
        // as a class-init guard whatever byte of the struct it reads. See IsClassFlagTest.
        var classPointers = new HashSet<LocalVariable>(knownClassPointers);
        var classByteLoads = new HashSet<LocalVariable>();

        foreach (var instruction in cfg.Instructions)
        {
            if (instruction is { OpCode: OpCode.Move, Operands: [LocalVariable destination, TypeAnalysisContext and not (RuntimeMethodInfoAnalysisContext or RuntimeFieldInfoAnalysisContext)] })
                classPointers.Add(destination);
            else if (instruction.Operands is [LocalVariable typedDestination, ..] && typedDestination.Type is RuntimeClassTypeAnalysisContext)
                classPointers.Add(typedDestination);
        }

        // AssetRipper: a class pointer is copied and merged before it is tested - through a phi at a
        // branch join, then a plain copy - and the locals along the way carry no type of their own.
        // Following the copies is what lets the guard on the far end be recognised at all.
        bool grew;
        do
        {
            grew = false;

            foreach (var instruction in cfg.Instructions)
            {
                if (instruction.OpCode is not (OpCode.Move or OpCode.Phi)
                    || instruction.Operands is not [LocalVariable destination, ..]
                    || classPointers.Contains(destination))
                    continue;

                for (var i = 1; i < instruction.Operands.Count; i++)
                {
                    // A copy or a phi carries the pointer; so does one more dereference, because the
                    // address in the code can name the metadata usage slot rather than be it, and both
                    // resolve to the same usage - see the same allowance in PropagateStaticFieldStorage.
                    var carried = instruction.Operands[i] switch
                    {
                        LocalVariable source => source,
                        MemoryOperand { Index: null, Scale: 0, Addend: 0, Base: LocalVariable through } => through,
                        _ => null,
                    };

                    if (carried != null && classPointers.Contains(carried))
                    {
                        grew |= classPointers.Add(destination);
                        break;
                    }
                }
            }
        } while (grew);

        // AssetRipper: iteration 066 - from 2021 il2cpp guards a static access with
        // `if (!klass->cctor_finished_or_no_cctor) il2cpp_codegen_runtime_class_init(klass)`, a test of a whole
        // 32-bit word rather than of one bit. The offset of that word comes from the measured struct table.
        var classInitWordLoads = new HashSet<LocalVariable>();

        // AssetRipper: iteration 066 - a local holding an address the code names outright. The method-init flag is a
        // static byte; A64 reaches it through a page base kept in a callee-saved register, so its store is
        // `[page + offset] = 1` rather than a store to a constant address.
        var constantAddresses = new HashSet<LocalVariable>();

        foreach (var instruction in cfg.Instructions)
        {
            if (instruction is { OpCode: OpCode.Move, Operands: [LocalVariable destination, MemoryOperand { Index: null, Scale: 0, Addend: > 0, Base: LocalVariable owner } loaded] }
                && classPointers.Contains(owner))
            {
                classByteLoads.Add(destination);
                if (cctorFinishedOffset is { } cctor && loaded.Addend == cctor)
                    classInitWordLoads.Add(destination);
            }

            if (instruction is { OpCode: OpCode.Move, Operands: [LocalVariable constant, Immediate { Value: not 0 }] })
                constantAddresses.Add(constant);
        }

        var evidence = new GuardEvidence
        {
            ClassPointers = classPointers,
            ClassByteLoads = classByteLoads,
            ClassInitWordLoads = classInitWordLoads,
            ConstantAddresses = constantAddresses,
            CctorFinishedOffset = cctorFinishedOffset,
        };

        var reachableBefore = Reachable(cfg);

        // AssetRipper: one guard's removal is what makes the next recognisable - an inner class-init guard copied
        // into the metadata-init region has to fold before that region reconverges - so repeat while anything goes.
        for (var round = 0; round < 4; round++)
        {
            var removedThisRound = false;
            foreach (var guard in cfg.Blocks.ToList())
                if (cfg.Blocks.Contains(guard))
                    removedThisRound |= TryRemoveGuard(cfg, guard, initialisedFlagOffset, evidence);

            removedAny |= removedThisRound;
            if (!removedThisRound)
                break;
        }

        removedAny |= RemoveBareClassInitCalls(cfg);

        // AssetRipper: iteration 066 - a fold can leave behind a block that only the folded arm reached, by a path
        // RemoveOrphans does not follow (a cycle, or an arm shared with a block that is itself now dead). The
        // rendering and the generator both walk every block in the graph, so a dead block left there reads as a
        // call the method makes. Only what this pass made unreachable is removed.
        if (removedAny)
            RemoveMadeUnreachable(cfg, reachableBefore);

        if (removedAny)
            DeadCodeEliminator.Run(cfg);
    }

    // wasm keeps the initialized-flag check inside the class-init function, so callers make bare unguarded
    // calls with no region to excise (just drop the call)
    private static bool RemoveBareClassInitCalls(ISILControlFlowGraph cfg)
    {
        var removedAny = false;

        foreach (var block in cfg.Blocks)
        {
            foreach (var instruction in block.Instructions)
            {
                if (!instruction.IsCall
                    || instruction.Operands[0] is not StringLiteral { Value: ClassInitExport or ClassInitActual or ClassInitCodegen })
                    continue;

                instruction.OpCode = OpCode.Nop;
                instruction.SetOperands();
                removedAny = true;
            }
        }

        return removedAny;
    }

    private static bool TryRemoveGuard(ISILControlFlowGraph cfg, Block guard, long initialisedFlagOffset, GuardEvidence evidence)
    {
        if (guard.BlockType != BlockType.TwoWay || guard.Successors.Count != 2
            || guard.Instructions.Count == 0 || guard.Instructions[^1].OpCode != OpCode.ConditionalJump)
            return false;

        // see if we're checking Il2CppClass::initialized_and_no_error
        // that means this is runtime_init boilerplate and we can drop the block
        var classInitWordTest = guard.Instructions.Any(i => IsClassInitWordTest(i, evidence));
        var initialisedFlagTest = classInitWordTest || guard.Instructions.Any(i => i.OpCode == OpCode.And
            && i.Operands is [_, var flag, var mask]
            && (flag is MemoryOperand { Index: null, Scale: 0, Base: LocalVariable } direct && direct.Addend == initialisedFlagOffset && IsOne(mask)
                || IsClassFlagTest(flag, mask, evidence.ClassByteLoads)));

        // Either successor could be the init entry; the other is then the merge.
        var first = guard.Successors[0];
        var second = guard.Successors[1];

        var removed = TryExcise(cfg, guard, first, second, initialisedFlagTest, evidence)
            || TryExcise(cfg, guard, second, first, initialisedFlagTest, evidence)
            || TryExciseThroughForwardingBlock(cfg, guard, first, second, initialisedFlagTest, evidence)
            || TryExciseThroughForwardingBlock(cfg, guard, second, first, initialisedFlagTest, evidence)
            || (initialisedFlagTest && TryFoldVacuousGuard(cfg, guard)) // AssetRipper
            || (classInitWordTest && (TryFoldDuplicatedTail(cfg, guard, first, second) || TryFoldDuplicatedTail(cfg, guard, second, first)))
            || (classInitWordTest && TryFoldClassInitWordTest(cfg, guard, evidence));

        if (removed && classInitWordTest)
            System.Threading.Interlocked.Increment(ref ClassInitWordGuards);

        return removed;
    }

    /// <summary>
    /// AssetRipper: iteration 066 - <c>klass-&gt;cctor_finished_or_no_cctor == 0</c> on a known class pointer.
    /// </summary>
    /// <remarks>
    /// The word is the runtime's own record of whether the static constructor has run; nothing managed reads it,
    /// so a comparison of it with zero is the guard and nothing else. The offset is the measured one, so a build
    /// whose layout is not known recognises nothing here rather than something wrong.
    /// </remarks>
    private static bool IsClassInitWordTest(Instruction instruction, GuardEvidence evidence)
    {
        if (evidence.CctorFinishedOffset is not { } cctor || instruction.OpCode is not (OpCode.CheckEqual or OpCode.CheckNotEqual)
            || instruction.Operands is not [_, var left, var right])
            return false;

        bool IsWord(IOperand operand) => operand switch
        {
            LocalVariable local => evidence.ClassInitWordLoads.Contains(local),
            MemoryOperand { Index: null, Scale: 0, Base: LocalVariable owner } memory => memory.Addend == cctor
                && (owner.Type is RuntimeClassTypeAnalysisContext || evidence.ClassPointers.Contains(owner)),
            _ => false,
        };

        return IsWord(left) && IsZero(right) || IsWord(right) && IsZero(left);
    }

    /// <summary>
    /// AssetRipper: iteration 066 - a class-init guard whose init arm is the initializer followed by a copy of the
    /// other arm.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <c>if (!klass-&gt;cctor_finished_or_no_cctor) il2cpp_codegen_runtime_class_init(klass); rest;</c> has no merge
    /// when the compiler tail-duplicates <c>rest</c> into the init arm, which it routinely does for a short
    /// continuation: one arm is <c>init(); rest'</c> and the other is <c>rest</c>, both ending in their own return.
    /// The region walk then never reconverges and the guard - with the runtime word it reads - survived on every
    /// iOS fixture.
    /// </para>
    /// <para>
    /// The fold is taken only on proof that <c>rest'</c> is <c>rest</c>: instruction for instruction, the same
    /// opcodes, the same constants and callees, every value from outside the two stretches the same local, and
    /// every value defined inside them mapped one to one. Dropping the initializer call is what excising the
    /// region does in the reconverging shape too; this is the same decision with the copy accounted for.
    /// </para>
    /// </remarks>
    private static bool TryFoldDuplicatedTail(ISILControlFlowGraph cfg, Block guard, Block initArm, Block otherArm)
    {
        if (ReferenceEquals(initArm, otherArm) || initArm == cfg.ExitBlock || otherArm == cfg.ExitBlock)
            return false;

        var index = 0;
        while (index < initArm.Instructions.Count && initArm.Instructions[index].OpCode is OpCode.Phi or OpCode.Nop)
            index++;

        if (index >= initArm.Instructions.Count
            || initArm.Instructions[index] is not { OpCode: OpCode.Call or OpCode.CallVoid, Operands: [StringLiteral { Value: ClassInitExport or ClassInitActual or ClassInitCodegen }, ..] } initCall)
            return false;

        var initResult = initCall.OpCode == OpCode.Call && initCall.Operands.Count > 1 ? initCall.Operands[1] as LocalVariable : null;

        if (!TailsAreEquivalent(cfg, initArm, index + 1, otherArm, initResult))
            return false;

        // Send the guard to the other arm; the init arm keeps any other entrance it has.
        DetachEdge(guard, initArm);

        var terminator = guard.Instructions[^1];
        terminator.OpCode = OpCode.Jump;
        terminator.SetOperands(otherArm);
        guard.CalculateBlockType();

        RemoveOrphans(cfg, initArm);
        System.Threading.Interlocked.Increment(ref DuplicatedTailGuardsFolded);
        return true;
    }

    /// <summary>AssetRipper: iteration 066 - class-init guards folded on the identity of the word they test alone.</summary>
    public static int ClassInitWordTestsFolded;

    /// <summary>
    /// AssetRipper: iteration 066 - a class-init guard whose arms no longer have the shape of one.
    /// </summary>
    /// <remarks>
    /// <para>
    /// By the time this runs the initializer call is often gone - resolved, its result unused, it was dropped as
    /// dead - and the copy of the continuation in its arm has been simplified differently from the original (a
    /// double negation on one side, an inverted branch on the other), so neither the region walk nor the
    /// duplicated-tail proof applies, and the test with its runtime word survives into the output.
    /// </para>
    /// <para>
    /// The test itself is the evidence. <c>cctor_finished_or_no_cctor</c> is the runtime's own record of whether a
    /// static constructor has run; generated code reads it in exactly one place, the
    /// <c>IL2CPP_RUNTIME_CLASS_INIT</c> macro, which is <c>if (!klass-&gt;cctor_finished_or_no_cctor)
    /// il2cpp_codegen_runtime_class_init(klass);</c> and nothing else - so the arm taken when the word is zero is
    /// the initializer followed by a copy of the other arm. The offset is the measured one and the base has to be a
    /// class pointer. Folding keeps the initialised side, which is the same decision every other route here takes
    /// when it drops the initializer. Which side that is follows from the comparison and every negation between it
    /// and the branch; if that chain cannot be read in the guard block, nothing is folded.
    /// </para>
    /// </remarks>
    private static bool TryFoldClassInitWordTest(ISILControlFlowGraph cfg, Block guard, GuardEvidence evidence)
    {
        if (guard.Instructions[^1] is not { OpCode: OpCode.ConditionalJump, Operands: [Block target, LocalVariable condition] })
            return false;

        var other = guard.Successors.FirstOrDefault(successor => !ReferenceEquals(successor, target));
        if (other is null || !guard.Successors.Contains(target))
            return false;

        // true when `condition` being true means the class is not yet initialised
        bool? trueMeansUninitialised = null;
        var negations = 0;
        var wanted = condition.Name;

        for (var i = guard.Instructions.Count - 2; i >= 0 && trueMeansUninitialised is null; i--)
        {
            var instruction = guard.Instructions[i];
            if (instruction.Destination is not LocalVariable { Name: var defined } || defined != wanted)
                continue;

            switch (instruction)
            {
                case { OpCode: OpCode.Not, Operands: [_, LocalVariable negated] }:
                    negations++;
                    wanted = negated.Name;
                    break;
                case { OpCode: OpCode.CheckEqual } when IsClassInitWordTest(instruction, evidence):
                    trueMeansUninitialised = negations % 2 == 0;
                    break;
                case { OpCode: OpCode.CheckNotEqual } when IsClassInitWordTest(instruction, evidence):
                    trueMeansUninitialised = negations % 2 == 1;
                    break;
                default:
                    return false;
            }
        }

        if (trueMeansUninitialised is not { } uninitialisedOnTrue)
            return false;

        var initArm = uninitialisedOnTrue ? target : other;
        var initialised = uninitialisedOnTrue ? other : target;

        if (initArm == cfg.ExitBlock || initArm == cfg.EntryBlock)
            return false;

        DetachEdge(guard, initArm);

        var terminator = guard.Instructions[^1];
        terminator.OpCode = OpCode.Jump;
        terminator.SetOperands(initialised);
        guard.CalculateBlockType();

        RemoveOrphans(cfg, initArm);
        System.Threading.Interlocked.Increment(ref ClassInitWordTestsFolded);
        return true;
    }

    /// <summary>Straight-line stretches from (a, start) and (b, 0) that compute the same thing and end the same way.</summary>
    private static bool TailsAreEquivalent(ISILControlFlowGraph cfg, Block a, int start, Block b, LocalVariable? excluded)
    {
        var mapping = new Dictionary<string, string>();
        var aIndex = start;
        var bIndex = 0;
        var budget = 128;

        while (budget-- > 0)
        {
            // converged on one block: everything from here is shared, so equal so far is equal
            if (ReferenceEquals(a, b) && aIndex == 0 && bIndex == 0)
                return true;

            var nextA = NextReal(ref a, ref aIndex, cfg);
            var nextB = NextReal(ref b, ref bIndex, cfg);

            if (ReferenceEquals(a, b) && nextA is not null && ReferenceEquals(nextA, nextB))
                return true;

            if (nextA is null || nextB is null)
                return false;

            if (nextA.OpCode != nextB.OpCode || nextA.Operands.Count != nextB.Operands.Count)
                return false;

            if (nextA.OpCode is OpCode.Phi or OpCode.ConditionalJump or OpCode.IndirectJump)
                return false;

            var defines = nextA.Destination is LocalVariable && nextA.OpCode is not OpCode.Return;
            for (var i = 0; i < nextA.Operands.Count; i++)
            {
                if (!OperandsMatch(nextA.Operands[i], nextB.Operands[i], defines && i == (nextA.OpCode == OpCode.Call ? 1 : 0), mapping, excluded))
                    return false;
            }

            if (nextA.OpCode == OpCode.Return)
                return true;

            aIndex++;
            bIndex++;
        }

        return false;
    }

    /// <summary>The next instruction worth comparing, following a block that ends by falling or jumping into one successor.</summary>
    private static Instruction? NextReal(ref Block block, ref int index, ISILControlFlowGraph cfg)
    {
        for (var hops = 0; hops < 32; hops++)
        {
            while (index < block.Instructions.Count && block.Instructions[index].OpCode is OpCode.Nop or OpCode.Jump)
                index++;

            if (index < block.Instructions.Count)
                return block.Instructions[index];

            if (block.Successors.Count != 1 || block.Successors[0] == cfg.ExitBlock)
                return null;

            block = block.Successors[0];
            index = 0;

            if (block.Instructions.Any(i => i.OpCode == OpCode.Phi))
                return null;
        }

        return null;
    }

    private static bool OperandsMatch(object a, object b, bool isDefinition, Dictionary<string, string> mapping, LocalVariable? excluded)
    {
        switch (a, b)
        {
            case (LocalVariable left, LocalVariable right):
                if (excluded is not null && (left.Name == excluded.Name || right.Name == excluded.Name))
                    return false;
                if (isDefinition)
                {
                    if (mapping.ContainsKey(left.Name))
                        return false;
                    mapping[left.Name] = right.Name;
                    return true;
                }

                return mapping.TryGetValue(left.Name, out var mapped) ? mapped == right.Name : left.Name == right.Name;
            case (MemoryOperand left, MemoryOperand right):
                return left.Addend == right.Addend && left.Scale == right.Scale
                    && OptionalMatch(left.Base, right.Base, mapping, excluded) && OptionalMatch(left.Index, right.Index, mapping, excluded);
            case (Immediate left, Immediate right):
                return left.Value == right.Value;
            case (StringLiteral left, StringLiteral right):
                return left.Value == right.Value;
            case (Block, Block):
                return false; // a branch target inside the stretch is not straight-line
            default:
                return ReferenceEquals(a, b) || (a.GetType() == b.GetType() && a.Equals(b));
        }
    }

    private static bool OptionalMatch(IOperand? a, IOperand? b, Dictionary<string, string> mapping, LocalVariable? excluded)
        => a is null ? b is null : b is not null && OperandsMatch(a, b, false, mapping, excluded);

    private static HashSet<Block> Reachable(ISILControlFlowGraph cfg)
    {
        var seen = new HashSet<Block>();
        var pending = new Stack<Block>();
        pending.Push(cfg.EntryBlock);
        while (pending.Count > 0)
        {
            var block = pending.Pop();
            if (!seen.Add(block))
                continue;
            foreach (var successor in block.Successors)
                pending.Push(successor);
        }

        return seen;
    }

    /// <summary>AssetRipper: iteration 066 - blocks reachable before this pass and not after it.</summary>
    public static int BlocksMadeUnreachableRemoved;

    private static void RemoveMadeUnreachable(ISILControlFlowGraph cfg, HashSet<Block> reachableBefore)
    {
        var reachable = Reachable(cfg);
        var dead = cfg.Blocks.Where(block => reachableBefore.Contains(block) && !reachable.Contains(block)
                                             && block != cfg.EntryBlock && block != cfg.ExitBlock).ToList();
        foreach (var block in dead)
        {
            foreach (var successor in block.Successors.ToList())
                DetachEdge(block, successor);
            foreach (var predecessor in block.Predecessors.ToList())
                predecessor.Successors.Remove(block);
            block.Predecessors.Clear();
            cfg.Blocks.Remove(block);
        }

        System.Threading.Interlocked.Add(ref BlocksMadeUnreachableRemoved, dead.Count);
    }

    /// <summary>Removes the edge and the phi inputs it carried.</summary>
    private static void DetachEdge(Block from, Block to)
    {
        var slot = to.Predecessors.IndexOf(from);
        if (slot < 0)
            return;

        foreach (var phi in to.Instructions)
            if (phi.OpCode == OpCode.Phi && 1 + slot < phi.Operands.Count)
                phi.RemoveOperandAt(1 + slot);

        to.Predecessors.RemoveAt(slot);
        from.Successors.Remove(to);
    }

    /// <summary>Deletes a block nothing enters any more, and whatever only it entered.</summary>
    private static void RemoveOrphans(ISILControlFlowGraph cfg, Block start)
    {
        var pending = new Stack<Block>();
        pending.Push(start);

        while (pending.Count > 0)
        {
            var block = pending.Pop();
            if (block == cfg.EntryBlock || block == cfg.ExitBlock || block.Predecessors.Count != 0 || !cfg.Blocks.Contains(block))
                continue;

            foreach (var successor in block.Successors.ToList())
            {
                DetachEdge(block, successor);
                pending.Push(successor);
            }

            cfg.Blocks.Remove(block);
        }
    }

    /// <summary>
    /// AssetRipper: iteration 066 - a guard whose skip arm is a block that only forwards to where the region rejoins.
    /// </summary>
    /// <remarks>
    /// Once a class-init guard inside a metadata-init region has folded, what the outer guard skips to is the remnant
    /// of the inner test - a block that computes a value nothing reads and jumps on - and the region rejoins one
    /// block further. The guard is redirected to the remnant, which still leads where it led.
    /// </remarks>
    private static bool TryExciseThroughForwardingBlock(ISILControlFlowGraph cfg, Block guard, Block initEntry, Block forwarding, bool initialisedFlagTest, GuardEvidence evidence)
    {
        if (forwarding.Predecessors.Count != 1 || forwarding.Successors.Count != 1 || forwarding == cfg.ExitBlock
            || forwarding.Instructions.Any(i => i.OpCode is not (OpCode.Nop or OpCode.Jump) && !IsSideEffectFree(i)))
            return false;

        var merge = forwarding.Successors[0];
        if (merge == cfg.EntryBlock || merge == cfg.ExitBlock || merge == initEntry || merge == guard)
            return false;

        if (!TryCollectRegion(cfg, guard, initEntry, merge, initialisedFlagTest, evidence, out var region, out var shared) || shared)
            return false;

        foreach (var block in region)
            foreach (var successor in block.Successors.ToList())
                if (!region.Contains(successor))
                    DetachEdge(block, successor);

        DetachEdge(guard, initEntry);

        var terminator = guard.Instructions[^1];
        terminator.OpCode = OpCode.Jump;
        terminator.SetOperands(forwarding);
        guard.CalculateBlockType();

        foreach (var block in region)
        {
            foreach (var successor in block.Successors)
                successor.Predecessors.Remove(block);
            block.Successors.Clear();
            block.Predecessors.Clear();
            cfg.Blocks.Remove(block);
        }

        System.Threading.Interlocked.Increment(ref GuardsExcisedThroughForwardingBlock);
        return true;
    }

    /// <summary>
    /// AssetRipper: folds a class flag test whose two arms both do nothing and meet again.
    /// </summary>
    /// <remarks>
    /// The compiler does not always give the guard the shape of one arm skipping the other: it can
    /// leave a diamond, with both arms reaching a common block. Once the initializer call in one of
    /// them has been eliminated — its result is unused, so an earlier pass takes it — both arms are
    /// empty and the test decides nothing, but it still reads a byte of Il2CppClass that has no
    /// managed meaning. Two thousand of those survived on the test game.
    /// </remarks>
    private static bool TryFoldVacuousGuard(ISILControlFlowGraph cfg, Block guard)
    {
        if (guard.Successors.Count != 2)
            return false;

        var first = guard.Successors[0];
        var second = guard.Successors[1];

        if (ReferenceEquals(first, second) || !IsEmptyArm(guard, first) || !IsEmptyArm(guard, second))
            return false;

        var merge = first.Successors[0];

        if (!ReferenceEquals(merge, second.Successors[0]) || ReferenceEquals(merge, guard)
            || ReferenceEquals(merge, cfg.EntryBlock) || ReferenceEquals(merge, cfg.ExitBlock))
            return false;

        var firstIndex = merge.Predecessors.IndexOf(first);
        var secondIndex = merge.Predecessors.IndexOf(second);

        if (firstIndex < 0 || secondIndex < 0)
            return false;

        // The merge sees one predecessor where it saw two, and both carried the same values, because
        // neither arm computed anything. Drop the second's phi inputs; the first's slot becomes the
        // guard's.
        foreach (var phi in merge.Instructions)
            if (phi.OpCode == OpCode.Phi && 1 + secondIndex < phi.Operands.Count)
                phi.RemoveOperandAt(1 + secondIndex);

        merge.Predecessors.RemoveAt(secondIndex);
        merge.Predecessors[merge.Predecessors.IndexOf(first)] = guard;

        guard.Successors.Clear();
        guard.Successors.Add(merge);

        var terminator = guard.Instructions[^1];
        terminator.OpCode = OpCode.Jump;
        terminator.SetOperands(merge);
        guard.CalculateBlockType();

        foreach (var arm in (Block[])[first, second])
        {
            arm.Successors.Clear();
            arm.Predecessors.Clear();
            cfg.Blocks.Remove(arm);
        }

        return true;
    }

    /// <summary>An arm of a guard that only exists to rejoin: one way in, one way out, nothing done.</summary>
    private static bool IsEmptyArm(Block guard, Block arm)
        => arm.Predecessors.Count == 1 && ReferenceEquals(arm.Predecessors[0], guard)
           && arm.Successors.Count == 1
           && arm.Instructions.All(i => i.OpCode is OpCode.Nop or OpCode.Jump);

    private static bool IsOne(IOperand operand) => operand is Immediate { Value: 1 };

    /// <summary>
    /// AssetRipper: whether this tests one bit of a byte of an <c>Il2CppClass</c>.
    /// </summary>
    /// <remarks>
    /// The hardcoded offset above is one Unity version's <c>initialized_and_no_error</c>, and the
    /// struct moves: on 2019.2 that byte is at 0x12E, and older code generations guard on
    /// <c>has_cctor</c> in the byte after it instead, with a mask of 2. Rather than track a table of
    /// versions, recognise the shape — a single bit of a byte of a known class pointer. Nothing but
    /// this boilerplate reads an Il2CppClass bitfield, and the region behind the test still has to
    /// reconverge and do nothing observable before it is dropped.
    /// </remarks>
    private static bool IsClassFlagTest(IOperand flag, IOperand mask, HashSet<LocalVariable> classByteLoads) =>
        // any single bit: the load is a byte, a halfword or a word depending on which flag it is
        // after, so `& 0x200` is bit 1 of the byte after the one `& 2` reads
        mask is Immediate { Value: > 0 and <= 0x8000_0000 and var bit } && (bit & (bit - 1)) == 0
        && flag switch
        {
            // the load may still be its own instruction: copy propagation has not run yet here
            LocalVariable local => classByteLoads.Contains(local),
            MemoryOperand { Index: null, Scale: 0, Addend: > 0, Base: LocalVariable owner } =>
                owner.Type is RuntimeClassTypeAnalysisContext || classByteLoads.Contains(owner),
            _ => false,
        };

    private static bool TryExcise(ISILControlFlowGraph cfg, Block guard, Block initEntry, Block merge, bool initialisedFlagTest, GuardEvidence? evidence = null)
    {
        if (merge == cfg.EntryBlock || merge == cfg.ExitBlock)
            return false;

        if (!TryCollectRegion(cfg, guard, initEntry, merge, initialisedFlagTest, evidence, out var region, out var shared))
            return false;

        // AssetRipper: the compiler shares one initialisation region between several guards, so
        // removing it for this one would take it from the others. Redirecting this guard past it is
        // the whole of what is wanted anyway; the region goes when the last guard stops entering it.
        if (shared)
            RedirectGuard(guard, initEntry, merge);
        else
            Excise(cfg, guard, initEntry, merge, region);

        return true;
    }

    /// <summary>AssetRipper: sends the guard straight to the merge, leaving the region for its other users.</summary>
    private static void RedirectGuard(Block guard, Block initEntry, Block merge)
    {
        guard.Successors.Remove(initEntry);
        initEntry.Predecessors.Remove(guard);

        // The merge is already the guard's other successor, so the edge and its phi slot are in place.
        var terminator = guard.Instructions[^1];
        terminator.OpCode = OpCode.Jump;
        terminator.SetOperands(merge);
        guard.CalculateBlockType();
    }

    private static bool TryCollectRegion(ISILControlFlowGraph cfg, Block guard, Block initEntry, Block merge,
        bool initialisedFlagTest, GuardEvidence? evidence, out HashSet<Block> region, out bool shared)
    {
        region = [];
        shared = false;

        if (initEntry == merge || initEntry == guard)
            return false;

        var sawMetadataInit = false;
        var sawClassInit = false;
        var sawFlagStore = false;
        var reconverges = false;

        var queue = new Queue<Block>();
        queue.Enqueue(initEntry);

        while (queue.Count > 0)
        {
            var block = queue.Dequeue();

            if (block == merge)
            {
                reconverges = true;
                continue;
            }

            // The region must not run into the method boundary or loop back through the guard.
            if (block == cfg.EntryBlock || block == cfg.ExitBlock || block == guard)
                return false;

            if (!region.Add(block))
                continue;

            if (!ClassifyBlock(block, initialisedFlagTest, evidence, ref sawMetadataInit, ref sawClassInit, ref sawFlagStore))
                return false;

            foreach (var successor in block.Successors)
                queue.Enqueue(successor);
        }

        // AssetRipper: behind a class flag test the init call may already have been eliminated as dead
        // — its result is unused and, once resolved, it is not treated as having an effect — leaving a
        // region that does nothing at all. That is still the guard, and the shape has already been
        // checked: every block in it is side-effect-free and it reconverges on the merge.
        if (!reconverges || !(sawClassInit || (sawMetadataInit && sawFlagStore) || initialisedFlagTest))
            return false;

        var collected = region;
        foreach (var block in collected)
        {
            // AssetRipper: an entrance from elsewhere no longer disqualifies the region, it only means
            // the region cannot be deleted with it.
            if (block.Predecessors.Any(predecessor => predecessor != guard && !collected.Contains(predecessor)))
                shared = true;
            if (block.Successors.Any(successor => successor != merge && !collected.Contains(successor)))
                return false;
        }

        return true;
    }

    // A region block is acceptable only if every instruction is intra-region control flow, an init
    // call, the flag store, or otherwise side-effect-free (writes a local, not memory). A managed call
    // or any other store would have an effect we cannot silently drop, so it disqualifies the region.
    private static bool ClassifyBlock(Block block, bool initialisedFlagTest, GuardEvidence? evidence, ref bool sawMetadataInit, ref bool sawClassInit, ref bool sawFlagStore)
    {
        foreach (var instruction in block.Instructions)
        {
            switch (instruction.OpCode)
            {
                case OpCode.Jump:
                // AssetRipper: a guard can be two tests deep - has_cctor outside, cctor_finished
                // inside - so the region's own branching is part of it. Which blocks the region
                // covers is checked separately, by walking successors back to the merge. A phi only
                // names which version of a value arrived, which is nothing to carry out of a region
                // nobody enters.
                case OpCode.ConditionalJump:
                case OpCode.Phi:
                    break;

                // Behind an initialized_and_no_error test the callee is the class initializer, even if we didn't resolve it.
                // If we didn't, that's fine, just skip.
                case OpCode.Call or OpCode.CallVoid when initialisedFlagTest:
                    sawClassInit = true;
                    break;

                case OpCode.Call or OpCode.CallVoid:
                    if (instruction.Operands is not [StringLiteral { Value: var name }, ..])
                        return false;

                    if (name is InitializeRuntimeMetadata or InitializeMethod)
                        sawMetadataInit = true;
                    else if (name is ClassInitExport or ClassInitActual or ClassInitCodegen)
                        sawClassInit = true;
                    else
                        return false;

                    break;

                case OpCode.Move when instruction.Operands is [MemoryOperand { IsConstant: true }, _]:
                    sawFlagStore = true;
                    break;

                // AssetRipper: iteration 066 - the same store through a page base the code names outright
                case OpCode.Move when instruction.Operands is [MemoryOperand { Index: null, Scale: 0, Base: LocalVariable page }, _]
                                      && evidence is not null && evidence.ConstantAddresses.Contains(page):
                    sawFlagStore = true;
                    break;

                default:
                    if (!IsSideEffectFree(instruction))
                        return false;
                    break;
            }
        }

        return true;
    }

    // True for instructions that only compute a value into a local (or do nothing). A store - any
    // instruction whose destination operand is a memory or field reference rather than a local - is
    // excluded, as is anything that transfers control or merges values (phi/return/indirect).
    private static bool IsSideEffectFree(Instruction instruction) =>
        instruction.OpCode switch
        {
            OpCode.Nop => true,
            OpCode.Move or OpCode.Add or OpCode.Subtract or OpCode.Multiply or OpCode.Divide or OpCode.Modulo
                or OpCode.ShiftLeft or OpCode.ShiftRight or OpCode.And or OpCode.Or or OpCode.Xor
                or OpCode.Not or OpCode.Negate
                or (>= OpCode.CheckEqual and <= OpCode.CheckLessOrEqual)
                => instruction.Operands is [LocalVariable, ..],
            _ => false,
        };

    internal static void Excise(ISILControlFlowGraph cfg, Block guard, Block initEntry, Block merge, HashSet<Block> region)
    {
        // 1. Repair the merge's phis: drop the inputs from the region's back-edges.
        for (var i = merge.Predecessors.Count - 1; i >= 0; i--)
        {
            if (!region.Contains(merge.Predecessors[i]))
                continue;

            foreach (var phi in merge.Instructions)
                if (phi.OpCode == OpCode.Phi && 1 + i < phi.Operands.Count)
                    phi.RemoveOperandAt(1 + i);

            merge.Predecessors.RemoveAt(i);
        }

        // 2. Fold the guard so it goes straight to the merge.
        guard.Successors.Remove(initEntry);
        initEntry.Predecessors.Remove(guard);

        var terminator = guard.Instructions[^1];
        terminator.OpCode = OpCode.Jump;
        terminator.SetOperands(merge);
        guard.CalculateBlockType();

        // 3. Delete the region. 
        foreach (var block in region)
        {
            foreach (var successor in block.Successors)
                successor.Predecessors.Remove(block);
            foreach (var predecessor in block.Predecessors)
                predecessor.Successors.Remove(block);

            block.Successors.Clear();
            block.Predecessors.Clear();
            cfg.Blocks.Remove(block);
        }
    }
}
