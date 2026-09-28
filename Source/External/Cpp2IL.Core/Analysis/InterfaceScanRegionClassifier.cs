using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>What a surviving interface offset scan region turned out to be.</summary>
public enum InterfaceScanVerdict
{
    /// <summary>
    /// Nothing outside the region reads what it computes, it has no side effect, and every branch in
    /// it reconverges on one block through blocks that hold nothing but the region - so removing it is
    /// a proven no-op on what the method does.
    /// </summary>
    DeadRegionProven,

    /// <summary>
    /// A value the region computes reaches an effect - a call, a store, a return, a throw. Every
    /// instruction in the region reads a region value or is a scan read, so an effect inside it is
    /// exactly that.
    /// </summary>
    ValueEscapes,

    /// <summary>A branch in the region leads to more than one place outside it, so it decides something.</summary>
    ControlDiverges,
}

/// <summary>
/// AssetRipper: classifies the interface offset scans that survive after the dispatch they fed was
/// resolved, and proves - or fails to prove - each one dead. It removes nothing.
/// </summary>
/// <remarks>
/// <para>
/// Iteration 060 found 2248 of Merge-Room's unresolved loads to be the scan il2cpp emits to find an
/// interface's slot in the receiver's vtable - <c>interface_offsets_count</c>, <c>interfaceOffsets</c>,
/// the loop over them - left behind after <see cref="InterfaceInvokeDataRecovery"/> had already
/// resolved the call, and it stopped short of removing them: a region that is removed on the belief
/// that it is dead, and is not, changes what the method does with nothing to say so.
/// </para>
/// <para>
/// So this establishes the belief first. A region is the forward data slice from every read of those
/// two members, plus every branch whose condition the slice computes. It is dead only when all three
/// hold: no instruction outside it reads a local it defines, none of its instructions has an effect,
/// and each of its branches reaches exactly one block outside the region through blocks made of
/// nothing but region instructions, jumps and nops - which is the control-flow proof that the branch
/// chooses between two ways of doing nothing. Anything short of all three is reported under the
/// condition that failed.
/// </para>
/// <para>
/// Measurement only, and last in the analysis beside <see cref="IndirectJumpClassifier"/>, so it sees
/// exactly what the generator will.
/// </para>
/// </remarks>
public static class InterfaceScanRegionClassifier
{
    private static readonly Dictionary<InterfaceScanVerdict, int> Regions = [];
    private static readonly Dictionary<string, int> Escapes = [];

    /// <summary>What a <see cref="InterfaceScanVerdict.ValueEscapes"/> region's value reaches, by the effect's shape.</summary>
    public static IReadOnlyList<KeyValuePair<string, int>> EscapeCounts
    {
        get
        {
            lock (CountLock)
                return [.. Escapes.OrderByDescending(pair => pair.Value)];
        }
    }
    private static readonly Lock CountLock = new();
    private static long _instructionsInProvenRegions;
    private static long _loadsInProvenRegions;
    private static int _bodies;

    public static IReadOnlyList<KeyValuePair<InterfaceScanVerdict, int>> Counts
    {
        get
        {
            lock (CountLock)
                return [.. Regions.OrderByDescending(pair => pair.Value)];
        }
    }

    public static long InstructionsInProvenRegions => Interlocked.Read(ref _instructionsInProvenRegions);
    public static long LoadsInProvenRegions => Interlocked.Read(ref _loadsInProvenRegions);
    public static int BodiesWithScans => Volatile.Read(ref _bodies);

    public static void Run(MethodAnalysisContext method)
    {
        if (method.ControlFlowGraph is not { } graph)
            return;

        var is32Bit = method.AppContext.Binary.is32Bit;
        HashSet<long> scanOffsets = [];
        foreach (var member in (string[])["interface_offsets_count", "interfaceOffsets"])
        {
            if (Il2CppClassUsefulOffsets.TryGetOffset(member, is32Bit, out var offset))
                scanOffsets.Add(offset);
        }

        if (scanOffsets.Count == 0)
            return;

        var verdicts = Classify(graph, operand => IsScanRead(operand, scanOffsets), message => IsilDump.Trace(method, message));

        if (verdicts.Count == 0)
            return;

        Interlocked.Increment(ref _bodies);

        lock (CountLock)
        {
            foreach (var (verdict, _, _) in verdicts)
                Regions[verdict] = Regions.GetValueOrDefault(verdict) + 1;
        }

        foreach (var (verdict, instructions, loads) in verdicts)
        {
            if (verdict != InterfaceScanVerdict.DeadRegionProven)
                continue;

            Interlocked.Add(ref _instructionsInProvenRegions, instructions);
            Interlocked.Add(ref _loadsInProvenRegions, loads);
        }
    }

    /// <summary>
    /// The verdict for the scan region rooted at each receiver class a scan reads, with the region's
    /// size in instructions and in memory reads. Written over the graph and a predicate so the proof
    /// is testable with no metadata behind it.
    /// </summary>
    public static List<(InterfaceScanVerdict Verdict, int Instructions, int Loads)> Classify(
        ISILControlFlowGraph graph, System.Func<IOperand, bool> isScanRead, System.Action<string>? trace = null)
    {
        List<(InterfaceScanVerdict, int, int)> results = [];
        var all = graph.Blocks.SelectMany(block => block.Instructions.Select(instruction => (block, instruction))).ToList();

        // One region per scanned class pointer: the scans of two different receivers are two regions.
        Dictionary<LocalVariable, List<Instruction>> seedsByBase = [];
        foreach (var (_, instruction) in all)
        {
            foreach (var operand in instruction.Operands)
            {
                if (isScanRead(operand) && BaseOf(operand) is { } baseLocal)
                {
                    if (!seedsByBase.TryGetValue(baseLocal, out var list))
                        seedsByBase[baseLocal] = list = [];
                    if (!list.Contains(instruction))
                        list.Add(instruction);
                }
            }
        }

        foreach (var seeds in seedsByBase.Values)
            results.Add(ClassifyRegion(graph, all, seeds, trace));

        return results;
    }

    private static (InterfaceScanVerdict, int, int) ClassifyRegion(
        ISILControlFlowGraph graph, List<(Block Block, Instruction Instruction)> all, List<Instruction> seeds,
        System.Action<string>? trace)
    {
        HashSet<Instruction> region = [.. seeds];
        HashSet<LocalVariable> defined = [];

        // The forward slice: whatever reads a value the region defines is in the region, to a fixpoint.
        bool grew = true;
        while (grew)
        {
            grew = false;
            foreach (var instruction in region.ToList())
            {
                if (instruction.Destination is LocalVariable written && defined.Add(written))
                    grew = true;
            }

            foreach (var (_, instruction) in all)
            {
                if (region.Contains(instruction))
                    continue;
                if (ReadLocals(instruction).Any(defined.Contains))
                {
                    region.Add(instruction);
                    grew = true;
                }
            }
        }

        int loads = region.Sum(instruction => instruction.Operands.Count(operand => operand is MemoryOperand));

        // Everything that reads a region value is in the region by construction, so what is left to
        // check is whether any of those readers is an effect.
        if (region.FirstOrDefault(HasEffect) is { } effect)
        {
            trace?.Invoke($"scan region: ValueEscapes at {effect} (seeds {string.Join(" | ", seeds)})");
            string shape = effect.OpCode switch
            {
                OpCode.Call or OpCode.CallVoid => effect.Operands.Count > 0 && effect.Operands[0] is not MethodAnalysisContext
                    ? "call to an unresolved target"
                    : "call to a resolved method",
                OpCode.IndirectCall or OpCode.IndirectJump => "indirect call or jump through a region value",
                OpCode.Move => "store into memory",
                _ => effect.OpCode.ToString(),
            };
            lock (CountLock)
                Escapes[shape] = Escapes.GetValueOrDefault(shape) + 1;
            return (InterfaceScanVerdict.ValueEscapes, region.Count, loads);
        }

        // Control: each branch in the region has to reconverge through region-only blocks.
        var blockOf = all.ToDictionary(pair => pair.Instruction, pair => pair.Block);
        foreach (var branch in region.Where(instruction => instruction.OpCode == OpCode.ConditionalJump))
        {
            HashSet<Block> exits = [];
            HashSet<Block> seen = [];
            Queue<Block> pending = new(blockOf[branch].Successors);
            while (pending.Count > 0)
            {
                var block = pending.Dequeue();
                if (!seen.Add(block))
                    continue;
                if (block == graph.ExitBlock || !IsScaffolding(block, region))
                {
                    exits.Add(block);
                    continue;
                }
                foreach (var next in block.Successors)
                    pending.Enqueue(next);
            }

            if (exits.Count != 1)
            {
                trace?.Invoke($"scan region: ControlDiverges at {branch} to blocks {string.Join(", ", exits.Select(block => block.ID))}");
                return (InterfaceScanVerdict.ControlDiverges, region.Count, loads);
            }
        }

        return (InterfaceScanVerdict.DeadRegionProven, region.Count, loads);
    }

    private static bool IsScaffolding(Block block, HashSet<Instruction> region)
        => block.Instructions.All(instruction => region.Contains(instruction)
            || instruction.OpCode is OpCode.Nop or OpCode.Jump);

    private static bool HasEffect(Instruction instruction) => instruction.OpCode switch
    {
        OpCode.Call or OpCode.CallVoid or OpCode.IndirectCall or OpCode.IndirectJump
            or OpCode.Return or OpCode.Throw => true,
        // A write through memory is visible to whatever reads that memory.
        OpCode.Move => instruction.Operands.Count > 0 && instruction.Operands[0] is not LocalVariable,
        _ => false,
    };

    private static IEnumerable<LocalVariable> ReadLocals(Instruction instruction)
    {
        // Only the destination's own position is a write. `Add v, v, 16` names one local object as
        // both destination and source, and skipping every operand equal to the destination made the
        // increment read nothing - which is how a loop step fell out of its own scan region.
        var at = StorageIdentities.DestinationPosition(instruction);
        for (var position = 0; position < instruction.Operands.Count; position++)
        {
            if (position == at)
                continue;
            foreach (var local in LocalsIn(instruction.Operands[position]))
                yield return local;
        }
    }

    private static IEnumerable<LocalVariable> LocalsIn(IOperand? operand)
    {
        switch (operand)
        {
            case LocalVariable local:
                yield return local;
                break;
            case MemoryOperand memory:
                foreach (var local in LocalsIn(memory.Base)) yield return local;
                foreach (var local in LocalsIn(memory.Index)) yield return local;
                break;
            case AddressOf address:
                foreach (var local in LocalsIn(address.Target)) yield return local;
                break;
            case FieldReference field:
                yield return field.Local;
                foreach (var local in LocalsIn(field.ElementIndex)) yield return local;
                break;
            case ArrayAccess array:
                yield return array.Array;
                foreach (var local in LocalsIn(array.Index)) yield return local;
                break;
        }
    }

    private static LocalVariable? BaseOf(IOperand operand) => operand is MemoryOperand { Base: LocalVariable local } ? local : null;

    private static bool IsScanRead(IOperand operand, HashSet<long> offsets)
        => operand is MemoryOperand { Base: LocalVariable { Type: { } type }, Index: null } memory
           && type.Name.StartsWith("Il2CppClass", System.StringComparison.Ordinal)
           && offsets.Contains(memory.Addend);
}
