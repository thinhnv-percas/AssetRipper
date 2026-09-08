using System.Collections.Generic;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: a throw ends its block. Nothing after it in the block runs, and it reaches no
/// successor.
/// </summary>
/// <remarks>
/// <para>
/// The control flow graph is built from the lifted ISIL, where a throw is still a call to one of
/// il2cpp's raise helpers, so the block that holds it falls through to whatever follows. Later passes
/// rewrite that call into <see cref="OpCode.Throw"/> - <c>MetadataResolver</c> and
/// <c>KeyFunctionRecovery</c> both do - but nothing revisits the edges, so the block keeps a successor
/// it cannot reach.
/// </para>
/// <para>
/// A throw is also exactly what a null check branches to, and there is one check per dereference. So
/// the throw block ends up with a dozen predecessors and an outgoing edge back into the code, which
/// makes it a loop with an entry per check: irreducible control flow that no decompiler can express
/// as a loop. ILSpy writes the method out as <c>goto</c>s instead, and the blocks never close - one
/// method of the third measurement game came out with 32 <c>goto</c>s and 27 levels of nesting.
/// </para>
/// <para>
/// <c>Instruction.CanContinueToNextInstruction</c> has always said a throw cannot continue. This is
/// the graph being told the same thing, at the point where the throw exists.
/// </para>
/// </remarks>
public static class UnreachableAfterThrow
{
    public static void Run(MethodAnalysisContext method) => Run(method.ControlFlowGraph!);

    public static void Run(ISILControlFlowGraph cfg)
    {
        var changed = false;

        foreach (var block in cfg.Blocks)
        {
            var thrownAt = -1;

            for (var i = 0; i < block.Instructions.Count; i++)
                if (block.Instructions[i].OpCode == OpCode.Throw)
                {
                    thrownAt = i;
                    break;
                }

            if (thrownAt < 0)
                continue;

            for (var i = thrownAt + 1; i < block.Instructions.Count; i++)
            {
                if (block.Instructions[i].OpCode == OpCode.Nop)
                    continue;

                block.Instructions[i].OpCode = OpCode.Nop;
                block.Instructions[i].SetOperands();
                changed = true;
            }

            foreach (var successor in new List<Block>(block.Successors))
            {
                if (successor == cfg.ExitBlock)
                    continue;

                block.Successors.Remove(successor);
                successor.Predecessors.Remove(block);
                changed = true;
            }

            if (!block.Successors.Contains(cfg.ExitBlock))
            {
                block.Successors.Add(cfg.ExitBlock);
                cfg.ExitBlock.Predecessors.Add(block);
            }

            block.CalculateBlockType();
        }

        if (!changed)
            return;

        cfg.RemoveUnreachableBlocks();
        DeadCodeEliminator.Run(cfg);
    }
}
