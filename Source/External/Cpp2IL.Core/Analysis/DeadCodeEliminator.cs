using System.Collections.Generic;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// Removes pure instructions whose result is never used. This eliminates, among other things, the
/// dead flag/temporary computations the x86 lifter emits eagerly for every comparison - a single
/// <c>cmp</c>/<c>test</c> produces all of CF/OF/SF/ZF/PF plus scratch temporaries, but the branch
/// that follows only consumes one of them.
///
/// Must run while the graph is still in SSA form (every local is assigned exactly once), so that a
/// global use count of zero is sufficient to prove a definition dead. Instructions are turned into
/// nops rather than spliced out; the structural cleanup happens later, out of SSA, where it is safe
/// for phi nodes.
/// </summary>
public static class DeadCodeEliminator
{
    public static void Run(MethodAnalysisContext method) => Run(method.ControlFlowGraph!);

    /// <remarks>
    /// AssetRipper: mark and sweep from the instructions that have an effect, not a use count swept
    /// to a fixpoint. A use count cannot see through a cycle - a loop-carried phi is used by the
    /// next phi round the loop, so every phi in the cycle has a live-looking use even when nothing
    /// outside the cycle reads any of them. The lifter emits the whole flag bundle for every
    /// <c>cmp</c>, and SSA phis those flag registers at each join, so on A64 an entire recovered
    /// comparison - the two class-pointer loads included - stayed in the body behind a ring of
    /// phis that referred only to each other. The same shape is why InterfaceDispatchRecovery has
    /// to zero its merge phis by hand rather than wait for them to die.
    /// </remarks>
    public static void Run(ISILControlFlowGraph cfg)
    {
        // Every definition, not the last one. The form is meant to be SSA, but a pass that rewrites
        // an instruction can leave a local with more than one, and marking only one of them sweeps
        // an assignment a live use still reaches - which reads as "use of unassigned local".
        var definitions = new Dictionary<LocalVariable, List<Instruction>>();

        foreach (var block in cfg.Blocks)
        {
            foreach (var instruction in block.Instructions)
            {
                if (instruction.Destination is not LocalVariable destination)
                    continue;

                if (!definitions.TryGetValue(destination, out var list))
                    definitions[destination] = list = [];

                list.Add(instruction);
            }
        }

        // Roots: anything that is not a pure computation into a register. A store's destination is
        // a memory or field operand rather than a local, so it is a root however removable its
        // opcode looks.
        var live = new HashSet<Instruction>();
        var pending = new Stack<Instruction>();

        foreach (var block in cfg.Blocks)
            foreach (var instruction in block.Instructions)
                if ((!IsRemovable(instruction.OpCode) || instruction.Destination is not LocalVariable)
                    && live.Add(instruction))
                    pending.Push(instruction);

        while (pending.Count > 0)
        {
            foreach (var used in UsedLocals(pending.Pop()))
            {
                if (!definitions.TryGetValue(used, out var defining))
                    continue;

                foreach (var definition in defining)
                    if (live.Add(definition))
                        pending.Push(definition);
            }
        }

        foreach (var block in cfg.Blocks)
        {
            foreach (var instruction in block.Instructions)
            {
                if (live.Contains(instruction) || instruction.OpCode == OpCode.Nop)
                    continue;

                instruction.OpCode = OpCode.Nop;
                instruction.SetOperands();
            }
        }
    }

    /// <summary>
    /// Every local read by the instruction. The single write position - a plain local destination -
    /// is excluded. Memory and field operands always contribute their address/object locals as
    /// reads, even when they are the destination of a store.
    /// </summary>
    private static IEnumerable<LocalVariable> UsedLocals(Instruction instruction)
    {
        var destination = instruction.Destination as LocalVariable;

        foreach (var operand in instruction.Operands)
        {
            switch (operand)
            {
                case LocalVariable local when !ReferenceEquals(local, destination):
                    yield return local;
                    break;
                case MemoryOperand memory:
                    if (memory.Base is LocalVariable baseLocal)
                        yield return baseLocal;
                    if (memory.Index is LocalVariable indexLocal)
                        yield return indexLocal;
                    break;
                // A static field access doesn't read the storage pointer it was resolved from, so that
                // pointer (and the class load feeding it) is free to die.
                case FieldReference { Field.IsStatic: false, Local: { } fieldLocal }:
                    yield return fieldLocal;
                    break;
                // Handing out a slot's address is a read of it as far as we can tell, whatever the callee then does with it.
                case AddressOf { Target: LocalVariable addressed }:
                    yield return addressed;
                    break;
                case AddressOf { Target: ArrayAccess addressedElement }:
                    foreach (var used in ArrayAccessLocals(addressedElement))
                        yield return used;
                    break;
                case ArrayAccess access:
                    foreach (var used in ArrayAccessLocals(access))
                        yield return used;
                    break;
                case ArrayLength { Array: { } lengthArray }:
                    yield return lengthArray;
                    break;
            }
        }
    }

    private static IEnumerable<LocalVariable> ArrayAccessLocals(ArrayAccess access)
    {
        yield return access.Array;

        if (access.Index is LocalVariable index)
            yield return index;
    }

    /// <summary>
    /// Opcodes with no side effects, so removing a never-read result is safe. Calls, stores,
    /// returns and branches are intentionally excluded.
    /// </summary>
    private static bool IsRemovable(OpCode opCode) =>
        opCode switch
        {
            OpCode.Move or OpCode.Phi
                or OpCode.Add or OpCode.Subtract or OpCode.Multiply or OpCode.Divide or OpCode.Modulo
                or OpCode.ShiftLeft or OpCode.ShiftRight
                or OpCode.And or OpCode.Or or OpCode.Xor
                or OpCode.Not or OpCode.Negate=> true,
            >= OpCode.CheckEqual and <= OpCode.CheckLessOrEqual => true,
            _ => false
        };
}
