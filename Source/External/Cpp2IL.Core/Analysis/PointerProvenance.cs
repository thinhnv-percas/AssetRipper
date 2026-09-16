using System;
using System.Collections.Generic;
using Cpp2IL.Core.ISIL;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: what produced the pointer a value holds, found by walking the definitions back
/// through the copies and merges that carry it.
/// </summary>
/// <remarks>
/// <para>
/// A pointer is almost never used where it was made. Between the two sit the copies a register
/// allocator leaves, the phis SSA puts at every join, and the duplicate definitions SSA destruction
/// leaves behind - so a pass that matches on the producing instruction and reads only the operand in
/// front of it matches nothing, which is exactly how the first form of
/// <see cref="InterfaceInvokeDataRecovery"/> behaved: 592 of the calls it wanted were one Move or one
/// Phi away from the call it was looking for, and it fired on none of them.
/// </para>
/// <para>
/// The walk is the one this project has arrived at four times now and is kept in one place here. A
/// merge answers only when every branch reaches the same producer, because a pointer that comes from
/// two places is two pointers and picking one is the guess every other walker in this file exists to
/// avoid. A revisit contributes nothing rather than recursing, so a loop-carried value does not read
/// as a disagreement. Each branch of a merge is given its own visited set, which here is a guard
/// rather than a rule: because a cut-off branch is ignored rather than counted as a disagreement,
/// and because a local that leads to two producers has no answer of its own anyway, sharing one set
/// was measured to give the same result on every case in the test file. It is kept so that the
/// equivalence stays a local fact - <see cref="BasePointerOrigin"/>, where a cut-off branch is a
/// distinct answer, does need the rule, and a test there fails without it.
/// </para>
/// <para>
/// It answers with the instruction, not with a name for it. Naming is a separate decision that needs
/// metadata, and keeping it out means this walk can be tested without a game behind it.
/// </para>
/// </remarks>
public static class PointerProvenance
{
    /// <summary>How far back a chain of copies and merges is followed before the answer is unknown.</summary>
    public const int DepthLimit = 24;

    /// <summary>
    /// The one instruction that produced the value <paramref name="operand"/> holds, or null when
    /// there is not exactly one.
    /// </summary>
    /// <param name="operand">The value whose producer is wanted.</param>
    /// <param name="definitions">Every instruction defining a local, in program order.</param>
    public static Instruction? Producer(IOperand? operand, Func<LocalVariable, IReadOnlyList<Instruction>> definitions)
        => operand is LocalVariable local ? Walk(local, definitions, [], 0) : null;

    private static Instruction? Walk(
        LocalVariable local,
        Func<LocalVariable, IReadOnlyList<Instruction>> definitions,
        HashSet<LocalVariable> visited,
        int depth)
    {
        if (depth > DepthLimit || !visited.Add(local))
        {
            // Out of depth, or back where the walk has been: either way this branch says nothing.
            // Null rather than a producer, so a merge reading it ignores the branch instead of
            // treating a loop as a disagreement.
            return null;
        }

        IReadOnlyList<Instruction> defining = definitions(local);

        if (defining.Count == 0)
        {
            return null;
        }

        if (defining.Count > 1)
        {
            return Agreed(defining, definitions, visited, depth);
        }

        return Through(defining[0], definitions, visited, depth);
    }

    /// <summary>Follows one definition, which is either a link in the chain or the end of it.</summary>
    private static Instruction? Through(
        Instruction definition,
        Func<LocalVariable, IReadOnlyList<Instruction>> definitions,
        HashSet<LocalVariable> visited,
        int depth)
    {
        if (definition.OpCode == OpCode.Move && definition.Operands.Count > 1 && definition.Operands[1] is LocalVariable copied)
        {
            return Walk(copied, definitions, visited, depth + 1);
        }

        if (definition.OpCode == OpCode.Phi)
        {
            List<Instruction?> inputs = [];

            for (int i = 1; i < definition.Operands.Count; i++)
            {
                inputs.Add(definition.Operands[i] is LocalVariable input
                    // Each branch gets its own visited set: two inputs reaching one local is
                    // convergence, not a cycle, and sharing the set would report the second as one.
                    ? Walk(input, definitions, [.. visited], depth + 1)
                    : null);
            }

            return Single(inputs);
        }

        return definition;
    }

    /// <summary>The producer every one of several definitions of the same local agrees on.</summary>
    private static Instruction? Agreed(
        IReadOnlyList<Instruction> defining,
        Func<LocalVariable, IReadOnlyList<Instruction>> definitions,
        HashSet<LocalVariable> visited,
        int depth)
    {
        List<Instruction?> reached = [];

        foreach (Instruction candidate in defining)
        {
            reached.Add(Through(candidate, definitions, [.. visited], depth));
        }

        return Single(reached);
    }

    /// <summary>
    /// The one producer a set of branches agrees on, ignoring the branches that said nothing.
    /// </summary>
    /// <remarks>
    /// A branch that reached a cycle or ran out of depth contributes nothing rather than a
    /// disagreement - a phi with one cyclic input and one real one takes the real one, which is what
    /// a loop-carried value needs. A genuine disagreement is no answer at all.
    /// </remarks>
    private static Instruction? Single(IReadOnlyList<Instruction?> reached)
    {
        Instruction? agreed = null;

        foreach (Instruction? candidate in reached)
        {
            if (candidate is null)
            {
                continue;
            }

            if (agreed is null)
            {
                agreed = candidate;
            }
            else if (!ReferenceEquals(agreed, candidate))
            {
                return null;
            }
        }

        return agreed;
    }
}
