using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

// Remove null and bounds checks which are explicit in il2cpp but implicit in IL
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

            if (terminator.Operands[0] is not Block target || GetInjectedThrowType(target) is not { } thrownType)
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
            _ => false
        };

    // The full name of the exception if this block does nothing but throw an injected check's exception, else null.
    private static string? GetInjectedThrowType(Block block)
    {
        string? thrown = null;

        foreach (var instruction in block.Instructions)
        {
            switch (instruction.OpCode)
            {
                case OpCode.Nop or OpCode.Interrupt:
                case OpCode.Return when thrown != null:
                    continue;

                case OpCode.Throw when thrown == null
                    && instruction.Operands is [TypeAnalysisContext { FullName: "System.NullReferenceException" or "System.IndexOutOfRangeException" } exception]:
                    thrown = exception.FullName;
                    continue;

                // AssetRipper: the helper that raises one of these never returns, so the compiler puts
                // the calls next to each other and the block that only builds the exception falls
                // straight into the one that throws a different one. Building it is the whole of the
                // block either way, and that is what makes it a check's epilogue.
                case OpCode.Newobj when thrown == null
                    && instruction.Operands is [_, TypeAnalysisContext { FullName: "System.NullReferenceException" or "System.IndexOutOfRangeException" } constructed]:
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
