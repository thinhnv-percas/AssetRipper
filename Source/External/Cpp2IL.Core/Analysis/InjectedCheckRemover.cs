using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

// Remove null, bounds and array store checks which are explicit in il2cpp but implicit in IL
public static class InjectedCheckRemover
{
    public static void Run(MethodAnalysisContext method) => Run(method.ControlFlowGraph!);

    public static void Run(ISILControlFlowGraph cfg)
    {
        var defOf = BuildDefMap(cfg);
        var removedAny = false;

        foreach (var block in cfg.Blocks)
        {
            if (block.BlockType != BlockType.TwoWay || block.Instructions.Count == 0)
                continue;

            var terminator = block.Instructions[^1];

            if (terminator.OpCode != OpCode.ConditionalJump)
                continue;

            if (terminator.Operands[0] is not Block target || GetInjectedThrowType(FollowToEpilogue(target)) is not { } thrownType)
                continue;

            if (terminator.Operands[1] is not LocalVariable condition
                || !defOf.TryGetValue(condition, out var definition)
                || !IsInjectedCheck(ChaseCondition(definition, defOf), thrownType))
                continue;

            terminator.OpCode = OpCode.Nop;
            terminator.SetOperands();

            block.Successors.Remove(target);
            target.Predecessors.Remove(block);
            block.CalculateBlockType();
            removedAny = true;
        }

        if (!removedAny)
            return;

        // delete any throw blocks
        cfg.RemoveUnreachableBlocks();
        DeadCodeEliminator.Run(cfg);
    }

    /// <summary>
    /// AssetRipper: the comparison behind a condition, through the copies and inversions that carry it.
    /// </summary>
    /// <remarks>
    /// A64 has no branch-if-greater-or-equal on the flags it sets for a bounds check, so the condition
    /// arrives as the negation of a less-than. Matching only the comparison itself left every bounds
    /// check in place. The branch's polarity does not matter here: the block it targets does nothing
    /// but throw, so the edge goes either way.
    /// </remarks>
    private static Instruction ChaseCondition(Instruction definition, Dictionary<LocalVariable, Instruction> defOf)
    {
        for (var depth = 0; depth < 8; depth++)
        {
            // AssetRipper: one cmp sets both C and Z, and a bounds check branches on "lower or same",
            // which the lifter models as `!C || Z` - an Or of two flags that are really one comparison.
            // Stopping at the Or left every check of this shape in place, and the guard then read as
            // `array.Length < index || (object)(array.Length - index) == null`.
            if (definition is { OpCode: OpCode.Or, Operands: [_, LocalVariable left, LocalVariable right] }
                && OneComparisonBehind(left, right, defOf) is { } comparison)
                return comparison;

            if (definition is not { OpCode: OpCode.Not or OpCode.Move } || definition.Operands.Count < 2
                || definition.Operands[1] is not LocalVariable source || !defOf.TryGetValue(source, out var next))
                return definition;

            definition = next;
        }

        return definition;
    }

    /// <summary>
    /// AssetRipper: the single comparison two flag locals were both computed from, when together they
    /// say "less or equal": one is the carry of a <c>CheckLess</c> and the other the zero flag of the
    /// same subtraction. Null when the two are unrelated, which is what keeps a real <c>||</c> from
    /// being mistaken for a check.
    /// </summary>
    private static Instruction? OneComparisonBehind(LocalVariable left, LocalVariable right, Dictionary<LocalVariable, Instruction> defOf)
    {
        if (!defOf.TryGetValue(left, out var leftDefinition) || !defOf.TryGetValue(right, out var rightDefinition))
            return null;

        leftDefinition = ChaseCopies(leftDefinition, defOf);
        rightDefinition = ChaseCopies(rightDefinition, defOf);

        return Paired(leftDefinition, rightDefinition) ?? Paired(rightDefinition, leftDefinition);

        Instruction? Paired(Instruction less, Instruction zero)
        {
            if (less.OpCode != OpCode.CheckLess || less.Operands.Count < 3)
                return null;

            if (zero is not { OpCode: OpCode.CheckEqual, Operands: [_, LocalVariable difference, Immediate { Value: 0 }] }
                || !defOf.TryGetValue(difference, out var subtraction))
                return null;

            subtraction = ChaseCopies(subtraction, defOf);

            if (subtraction is not { OpCode: OpCode.Subtract, Operands.Count: >= 3 }
                || !Equals(subtraction.Operands[1], less.Operands[1]) || !Equals(subtraction.Operands[2], less.Operands[2]))
                return null;

            return less;
        }
    }

    // The copies and inversions carrying a flag, without the Or reduction, so the reduction cannot recurse.
    private static Instruction ChaseCopies(Instruction definition, Dictionary<LocalVariable, Instruction> defOf)
    {
        for (var depth = 0; depth < 8; depth++)
        {
            if (definition is not { OpCode: OpCode.Not or OpCode.Move } || definition.Operands.Count < 2
                || definition.Operands[1] is not LocalVariable source || !defOf.TryGetValue(source, out var next))
                return definition;

            definition = next;
        }

        return definition;
    }

    private static bool IsInjectedCheck(Instruction definition, string thrownType) =>
        thrownType switch
        {
            "System.NullReferenceException" => definition is { OpCode: OpCode.CheckEqual } && definition.Operands[2] is Immediate { Value: 0 },
            "System.IndexOutOfRangeException" => definition.OpCode is >= OpCode.CheckEqual and <= OpCode.CheckLessOrEqual,
            // AssetRipper: stelem.ref's covariance check, which reads as "(value as T) == null" once
            // Object::IsInst is recognised. Injected exactly like the two above: the source never
            // wrote it, and IL does the same check itself.
            "System.ArrayTypeMismatchException" => definition is { OpCode: OpCode.CheckEqual } && definition.Operands[2] is Immediate { Value: 0 },
            _ => false
        };

    /// <summary>The exceptions il2cpp's injected checks raise, which IL raises for itself.</summary>
    private static readonly HashSet<string> InjectedExceptions =
    [
        "System.NullReferenceException",
        "System.IndexOutOfRangeException",
        "System.ArrayTypeMismatchException",
    ];

    /// <summary>
    /// AssetRipper: the block a branch really lands in, past any that only merge values on the way.
    /// </summary>
    /// <remarks>
    /// A dozen checks branching to one throw make the throw's block a join, and a join of nothing:
    /// SSA gives it a phi for every register live there, and the compiler puts a landing block in
    /// front of it that does nothing else. A check that targets that landing block is targeting the
    /// throw.
    /// </remarks>
    private static Block FollowToEpilogue(Block block)
    {
        for (var depth = 0; depth < 4; depth++)
        {
            if (block.Successors.Count != 1)
                return block;

            foreach (var instruction in block.Instructions)
                if (instruction.OpCode is not (OpCode.Nop or OpCode.Interrupt or OpCode.Phi))
                    return block;

            block = block.Successors[0];
        }

        return block;
    }

    // The full name of the exception if this block does nothing but throw an injected check's exception, else null.
    private static string? GetInjectedThrowType(Block block)
    {
        string? thrown = null;

        foreach (var instruction in block.Instructions)
        {
            switch (instruction.OpCode)
            {
                // AssetRipper: a phi is not code. It is the merge of the predecessors' values, and a
                // block a dozen checks branch to has one for every register live there - which is why
                // a throw block full of them was not recognised as a check's epilogue, and why every
                // check pointing at it survived. Thirty-seven of them converging on one throw in a
                // single method is what forces a decompiler into `goto`s.
                case OpCode.Phi:
                case OpCode.Nop or OpCode.Interrupt:
                case OpCode.Return when thrown != null:
                    continue;

                case OpCode.Throw when thrown == null
                    && instruction.Operands is [TypeAnalysisContext exception] && InjectedExceptions.Contains(exception.FullName):
                    thrown = exception.FullName;
                    continue;

                // AssetRipper: once the block is known to be a check's epilogue, whatever else it
                // builds or throws is part of the same epilogue. The helpers never return, so the
                // compiler runs them together — an array store check's block builds its
                // ArrayTypeMismatchException and falls straight into the one that raises something
                // else — and insisting on exactly one matched none of them.
                case OpCode.Throw or OpCode.Newobj when thrown != null
                    && instruction.Operands[^1] is TypeAnalysisContext:
                    continue;

                // AssetRipper: the helper that raises one of these never returns, so the compiler puts
                // the calls next to each other and the block that only builds the exception falls
                // straight into the one that throws a different one. Building it is the whole of the
                // block either way, and that is what makes it a check's epilogue.
                case OpCode.Newobj when thrown == null
                    && instruction.Operands is [_, TypeAnalysisContext constructed] && InjectedExceptions.Contains(constructed.FullName):
                    thrown = constructed.FullName;
                    continue;

                default:
                    return null;
            }
        }

        return thrown;
    }

    private static Dictionary<LocalVariable, Instruction> BuildDefMap(ISILControlFlowGraph cfg)
    {
        var defs = new Dictionary<LocalVariable, Instruction>();

        foreach (var instruction in cfg.Instructions)
            if (instruction.Destination is LocalVariable local)
                defs[local] = instruction;

        return defs;
    }
}
