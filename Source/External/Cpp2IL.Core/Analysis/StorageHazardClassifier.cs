using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;

namespace Cpp2IL.Core.Analysis;

/// <summary>What one storage hazard turned out to be.</summary>
public enum StorageHazardKind
{
    /// <summary>
    /// Proven within one block: another name of the slot is written between the last write under the
    /// address-taken name and the point the address is handed off, or read after a hand-off that could
    /// write through it with no write in between. The pointer and the name disagree about the value.
    /// </summary>
    TrueAlias,

    /// <summary>The address never leaves the expression it was taken in and nothing conflicts in its block.</summary>
    SpillAlias,

    /// <summary>The names are joined by a copy and nothing conflicts: they hold one value.</summary>
    Copy,

    /// <summary>Within one block the other name's whole life ends before the address is taken.</summary>
    Reuse,

    /// <summary>No control-flow path joins the address-take and any access of the other name.</summary>
    NonAlias,

    /// <summary>A path joins them across blocks and nothing decides the order.</summary>
    Unknown,
}

/// <summary>A storage hazard with the verdict and the instructions that decided it.</summary>
public sealed record ClassifiedStorageHazard(StorageHazard Hazard, StorageHazardKind Kind, string Evidence);

/// <summary>
/// AssetRipper: decides what each <see cref="StorageHazard"/> is. Iteration 061 counted 22 to 103 per
/// fixture - one stack slot held in several IL locals while its address is taken - without saying
/// which lose a value. This says, and says UNKNOWN where the order of events is not established.
/// </summary>
/// <remarks>
/// <para>
/// Order is used only where it is a fact: the position of two instructions in one block. Across blocks
/// the only fact used is reachability, which settles one question outright - if no path runs between
/// the address-take and an access of the other name, in either direction, they are never in play
/// together. Instruction indices are not an order across blocks and are never used as one.
/// </para>
/// <para>
/// Nothing here rewrites anything. A <see cref="StorageHazardKind.TrueAlias"/> is a finding; fixing one
/// means retargeting the address-take onto the name that holds the value, which is what
/// <c>SsaForm.RetargetAddressTakesOverwrittenBeforeUse</c> already does inside a block during SSA.
/// </para>
/// </remarks>
public static class StorageHazardClassifier
{
    /// <param name="operandsAreRead">
    /// Whether the emitted body reads an instruction's operands. An unresolved call becomes a
    /// placeholder that loads none of its sixteen raw registers, so a stack slot that happens to sit in
    /// one of them is not read there - and counting it made every such throw-helper call a "read after
    /// the hand-off". Null reads every operand.
    /// </param>
    public static List<ClassifiedStorageHazard> Classify(
        ISILControlFlowGraph graph,
        IReadOnlyList<StorageHazard> hazards,
        System.Func<Instruction, bool>? operandsAreRead = null)
    {
        List<ClassifiedStorageHazard> results = [];
        if (hazards.Count == 0)
            return results;

        var position = new Dictionary<Instruction, (Block Block, int At)>();
        foreach (var block in graph.Blocks)
        {
            for (var at = 0; at < block.Instructions.Count; at++)
                position[block.Instructions[at]] = (block, at);
        }

        var reach = new Dictionary<Block, HashSet<Block>>();

        foreach (var hazard in hazards)
            results.Add(ClassifyOne(graph, hazard, position, reach, operandsAreRead));

        return results;
    }

    private static ClassifiedStorageHazard ClassifyOne(
        ISILControlFlowGraph graph,
        StorageHazard hazard,
        Dictionary<Instruction, (Block Block, int At)> position,
        Dictionary<Block, HashSet<Block>> reach,
        System.Func<Instruction, bool>? operandsAreRead)
    {
        HashSet<LocalVariable> names = [.. hazard.Locals];

        List<(Instruction Instruction, LocalVariable Taken, bool Leaves)> takes = [];
        Dictionary<LocalVariable, List<Instruction>> defs = [];
        Dictionary<LocalVariable, List<Instruction>> uses = [];
        bool copied = false;

        foreach (var (instruction, _) in position)
        {
            var destinationAt = StorageIdentities.DestinationPosition(instruction);
            for (var operandAt = 0; operandAt < instruction.Operands.Count; operandAt++)
            {
                var operand = instruction.Operands[operandAt];
                if (operandAt == destinationAt && operand is LocalVariable written && names.Contains(written))
                {
                    Add(defs, written, instruction);
                    continue;
                }

                // An address taken inside a call the body never emits is handed to nothing.
                if (operand is AddressOf { Target: LocalVariable addressed } && names.Contains(addressed))
                {
                    if (operandsAreRead?.Invoke(instruction) ?? true)
                        takes.Add((instruction, addressed, Leaves(instruction, operandAt)));
                }
                else if (operand is LocalVariable read && names.Contains(read) && (operandsAreRead?.Invoke(instruction) ?? true))
                    Add(uses, read, instruction);
            }

            if (instruction is { OpCode: OpCode.Move, Operands: [LocalVariable to, LocalVariable from] }
                && names.Contains(to) && names.Contains(from))
                copied = true;
        }

        var verdict = StorageHazardKind.NonAlias;
        string evidence = "no path joins the address-take and the other names";

        foreach (var (take, taken, leaves) in takes)
        {
            var (takeBlock, takeAt) = position[take];

            foreach (var other in names.Where(name => name != taken))
            {
                IEnumerable<(Instruction Instruction, bool IsWrite)> accesses =
                    Get(defs, other).Select(i => (i, true)).Concat(Get(uses, other).Select(i => (i, false)));

                foreach (var (access, isWrite) in accesses)
                {
                    var (accessBlock, accessAt) = position[access];

                    if (accessBlock == takeBlock)
                    {
                        // A write under another name after the last write under the taken name, and
                        // before the address is handed off: the callee reads the slot the pointer
                        // names, which does not hold what was just written.
                        if (isWrite && accessAt < takeAt && leaves
                            && !Get(defs, taken).Any(d => position[d].Block == takeBlock && position[d].At > accessAt && position[d].At < takeAt))
                            return new(hazard, StorageHazardKind.TrueAlias, $"{other.Name} written at {access} before {take}");

                        // A read under another name after a hand-off that may write through the
                        // pointer, with no write under that name in between.
                        if (!isWrite && accessAt > takeAt && leaves
                            && !Get(defs, other).Any(d => position[d].Block == takeBlock && position[d].At > takeAt && position[d].At < accessAt))
                            return new(hazard, StorageHazardKind.TrueAlias, $"{other.Name} read at {access} after {take}");

                        if (verdict == StorageHazardKind.NonAlias)
                        {
                            verdict = copied ? StorageHazardKind.Copy : leaves ? StorageHazardKind.Reuse : StorageHazardKind.SpillAlias;
                            evidence = $"{other.Name} at {access} does not conflict with {take} in its block";
                        }

                        continue;
                    }

                    if (Reaches(takeBlock, accessBlock, reach) || Reaches(accessBlock, takeBlock, reach))
                    {
                        verdict = StorageHazardKind.Unknown;
                        evidence = $"{other.Name} at {access} and {take} are joined by a path across blocks";
                    }
                }
            }
        }

        return new(hazard, verdict, evidence);
    }

    private static bool Leaves(Instruction instruction, int operandAt) => instruction.OpCode switch
    {
        OpCode.Call or OpCode.IndirectCall => operandAt >= 2,
        OpCode.CallVoid => operandAt >= 1,
        OpCode.Return => true,
        OpCode.Move => operandAt == 1 && instruction.Operands[0] is not LocalVariable,
        _ => false,
    };

    private static bool Reaches(Block from, Block to, Dictionary<Block, HashSet<Block>> cache)
    {
        if (!cache.TryGetValue(from, out var reached))
        {
            reached = [];
            var pending = new Stack<Block>(from.Successors);
            while (pending.Count > 0)
            {
                var block = pending.Pop();
                if (reached.Add(block))
                    foreach (var next in block.Successors)
                        pending.Push(next);
            }
            cache[from] = reached;
        }
        return reached.Contains(to);
    }

    private static void Add(Dictionary<LocalVariable, List<Instruction>> map, LocalVariable local, Instruction instruction)
    {
        if (!map.TryGetValue(local, out var list))
            map[local] = list = [];
        list.Add(instruction);
    }

    private static IReadOnlyList<Instruction> Get(Dictionary<LocalVariable, List<Instruction>> map, LocalVariable local)
        => map.TryGetValue(local, out var list) ? list : [];
}
