using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.ISIL;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: names where a load's base lost its type, by walking the definitions back to it.
/// </summary>
/// <remarks>
/// <para>
/// A load is reported where the generator gave up on it, which is the right place to count it and the
/// wrong place to explain it. A base typed <c>object</c> three copies downstream of an unresolved call
/// says nothing about the call; grouping such loads by what they look like has four times in this
/// project produced a family that turned out to be several unrelated causes with nothing to do about
/// them in common. So the walk follows the definitions - through a copy, through the base side of an
/// addition, through every input of a phi - and the caller classifies whatever it ends on.
/// </para>
/// <para>
/// A phi is a join, so it has an origin only when every input agrees on one; where they disagree the
/// phi itself is the answer and the walk stops rather than picking an input, which is the same
/// principle as refusing to type a phi whose inputs disagree. Definitions form cycles - a loop-carried
/// value is defined by a phi reached from its own use - so each local is entered once and a revisit
/// contributes nothing rather than recursing. A cycle is not a disagreement: a phi with one cyclic
/// input and one real one takes the real one.
/// </para>
/// <para>
/// The result is a category, a colon, and the evidence for it, so that a group can be split again
/// without another pass over the run. The walking half is here and takes no metadata, so it can be
/// tested on its own; deciding what a *typed* base means needs field offsets and is the caller's.
/// </para>
/// </remarks>
public static class UnresolvedLoadProvenance
{
	/// <summary>
	/// How far back the walk will follow a chain of definitions before saying it does not know.
	/// </summary>
	public const int DepthLimit = 24;

	/// <summary>
	/// The origin of the value <paramref name="baseOperand"/> holds, as "CATEGORY:evidence".
	/// </summary>
	/// <param name="baseOperand">The base of the memory operand that could not be resolved.</param>
	/// <param name="definitions">Every instruction that defines a local, in program order.</param>
	/// <param name="classifyIfTyped">
	/// What it means for the walk to end here, or null when the local has no type and the walk should
	/// carry on. Everything a type is needed for is on this side of the line: the walk itself never
	/// looks at one, which is what lets its cases be tested without a game behind them.
	/// </param>
	/// <param name="isArrayTyped">Whether a local is an array, for recognising an element address.</param>
	public static string Of(
		IOperand? baseOperand,
		Func<LocalVariable, IReadOnlyList<Instruction>> definitions,
		Func<LocalVariable, string?> classifyIfTyped,
		Func<LocalVariable, bool> isArrayTyped)
	{
		if (baseOperand is not LocalVariable local)
		{
			return baseOperand is null ? "UNKNOWN:absolute-address" : "UNKNOWN:base-is-" + baseOperand.GetType().Name;
		}

		return Trace(local, definitions, classifyIfTyped, isArrayTyped, [], 0) ?? "UNKNOWN:cycle";
	}

	private static string? Trace(
		LocalVariable local,
		Func<LocalVariable, IReadOnlyList<Instruction>> definitions,
		Func<LocalVariable, string?> classifyIfTyped,
		Func<LocalVariable, bool> isArrayTyped,
		HashSet<LocalVariable> visited,
		int depth)
	{
		if (depth > DepthLimit)
		{
			return "UNKNOWN:too-deep";
		}

		// A revisit is a cycle. Returning null rather than a category lets a phi ignore this input
		// instead of reading the loop as a disagreement, which every loop-carried value would be.
		if (!visited.Add(local))
		{
			return null;
		}

		if (classifyIfTyped(local) is { } typed)
		{
			return typed;
		}

		IReadOnlyList<Instruction> defining = definitions(local);

		if (defining.Count == 0)
		{
			// No definition at all: a register's entry value. Usually one an unresolved call read
			// first, since such a call keeps the whole register file as its arguments and so makes
			// every register look defined.
			return "TYPE_PROPAGATION:entry-value";
		}

		// The representation is meant to be SSA, but a pass that rewrites an instruction can leave a
		// local with more than one definition - and by the point this runs SSA has been destructed
		// anyway, so this is the form a disagreement actually takes. Merge them as a phi's inputs are.
		if (defining.Count > 1)
		{
			return Merge(defining.Select(d => Through(d, definitions, classifyIfTyped, isArrayTyped, visited, depth)), "multiple-definitions");
		}

		return Through(defining[0], definitions, classifyIfTyped, isArrayTyped, visited, depth);
	}

	private static string? Through(
		Instruction defining,
		Func<LocalVariable, IReadOnlyList<Instruction>> definitions,
		Func<LocalVariable, string?> classifyIfTyped,
		Func<LocalVariable, bool> isArrayTyped,
		HashSet<LocalVariable> visited,
		int depth)
	{
		OperandList operands = defining.Operands;

		switch (defining.OpCode)
		{
			case OpCode.Phi:
			{
				List<string?> inputs = [];

				for (int i = 1; i < operands.Count; i++)
				{
					inputs.Add(operands[i] is LocalVariable input
						? Trace(input, definitions, classifyIfTyped, isArrayTyped, visited, depth + 1)
						: "UNKNOWN:phi-input-" + operands[i].GetType().Name);
				}

				return Merge(inputs, "phi");
			}

			case OpCode.Move when operands.Count > 1:
				return operands[1] switch
				{
					LocalVariable copied => Trace(copied, definitions, classifyIfTyped, isArrayTyped, visited, depth + 1),
					// The base was itself loaded from memory, so what typed *that* load's base is the
					// question and the walk carries on rather than stopping at "a memory operand".
					MemoryOperand { Base: LocalVariable through } => Trace(through, definitions, classifyIfTyped, isArrayTyped, visited, depth + 1),
					MemoryOperand => "UNKNOWN:loaded-from-an-unbased-address",
					// The field's type is in hand and the destination still has none, so what is
					// missing is the rule that should have carried it across.
					FieldReference => "TYPE_PROPAGATION:field-read",
					AddressOf => "TYPE_PROPAGATION:address-of",
					Immediate => "UNKNOWN:immediate",
					_ => "UNKNOWN:move-from-" + operands[1].GetType().Name,
				};

			case OpCode.Add when operands.Count > 2:
			{
				// An element address is an addition whose index side was scaled by the stride. Neither
				// side alone says so, so it is checked before either is followed.
				if (IsElementAddress(operands[1], operands[2], definitions, isArrayTyped))
				{
					return "ARRAY_ELEMENT:computed-element-address";
				}

				IOperand baseSide = operands[2] is Immediate
					? operands[1]
					: operands[1] is Immediate ? operands[2] : PreferTyped(operands[1], operands[2], classifyIfTyped);

				return baseSide is LocalVariable added
					? Trace(added, definitions, classifyIfTyped, isArrayTyped, visited, depth + 1)
					: "UNKNOWN:add-of-" + baseSide.GetType().Name;
			}

			// A resolved call gives its result the return type, so an untyped result means there was
			// no signature to take one from.
			case OpCode.Call:
			case OpCode.CallVoid:
			case OpCode.IndirectCall:
				return "MISSING_METADATA:unresolved-call-result";

			case OpCode.Newobj:
			case OpCode.NewArr:
			case OpCode.Box:
			case OpCode.IsInst:
				return "TYPE_PROPAGATION:" + defining.OpCode.ToString().ToLowerInvariant();

			default:
				return "UNKNOWN:" + defining.OpCode.ToString().ToLowerInvariant();
		}
	}

	/// <summary>
	/// The one origin every input agrees on, or the disagreement itself.
	/// </summary>
	private static string? Merge(IEnumerable<string?> origins, string disagreement)
	{
		string? agreed = null;

		foreach (string? origin in origins)
		{
			// A cycle says nothing, so it neither agrees nor disagrees.
			if (origin is null)
			{
				continue;
			}

			if (agreed is null)
			{
				agreed = origin;
			}
			else if (agreed != origin)
			{
				return "PHI_AMBIGUITY:" + disagreement;
			}
		}

		return agreed;
	}

	private static IOperand PreferTyped(IOperand first, IOperand second, Func<LocalVariable, string?> classifyIfTyped)
		=> first is LocalVariable typedFirst && classifyIfTyped(typedFirst) is not null
			? first
			: second is LocalVariable typedSecond && classifyIfTyped(typedSecond) is not null ? second : first;

	/// <summary>
	/// Whether an addition is an array and a scaled index, which is how an element's address is built.
	/// </summary>
	private static bool IsElementAddress(IOperand first, IOperand second, Func<LocalVariable, IReadOnlyList<Instruction>> definitions, Func<LocalVariable, bool> isArrayTyped)
	{
		return (IsArray(first) && IsScaledIndex(second, definitions)) || (IsArray(second) && IsScaledIndex(first, definitions));

		bool IsArray(IOperand operand) => operand is LocalVariable local && isArrayTyped(local);

		static bool IsScaledIndex(IOperand operand, Func<LocalVariable, IReadOnlyList<Instruction>> definitions)
			=> operand is LocalVariable index
				&& definitions(index).Any(s => s.OpCode is OpCode.Multiply or OpCode.ShiftLeft);
	}
}
