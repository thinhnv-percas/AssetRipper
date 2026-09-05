using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using System.Reflection;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery.Cpp2IL;

/// <summary>
/// Resolves the field accesses Cpp2IL's own resolver leaves as raw memory operands because the
/// offset lands inside a value type field rather than on a field boundary.
/// </summary>
/// <remarks>
/// <para>
/// <c>HutongGames.PlayMaker.FsmColor</c> holds a <c>Color value</c> at 0x38, so a load from 0x3C is
/// that colour's <c>g</c> component. Cpp2IL's <c>MetadataResolver.ResolveFieldOffsets</c> matches
/// only an exact offset and marks the rest as a TODO, which costs every such access its meaning:
/// <c>FsmVector2(FsmVector2 source)</c> reads as two dead placeholders instead of
/// <c>value.y = source.value.y</c>.
/// </para>
/// <para>
/// This runs after <c>MethodAnalysisContext.Analyze</c>, so it sees only what that left behind, and
/// it does not re-type the locals it resolves the way Cpp2IL's iterated resolver would. That costs
/// the accesses a further pass would have reached; it is the price of not forking the analysis.
/// </para>
/// </remarks>
public static class NestedFieldResolver
{
	/// <summary>
	/// How far to descend into nested value types. Deep enough for a struct in a struct in a class,
	/// and a bound on the self-referential shape a primitive has in metadata — <c>System.Single</c>
	/// holds a <c>System.Single</c>.
	/// </summary>
	private const int MaximumDepth = 4;

	/// <summary>
	/// Rewrites what it can resolve into <see cref="NestedFieldReference"/> operands.
	/// </summary>
	public static void Resolve(MethodAnalysisContext method)
	{
		if (method.ControlFlowGraph is null)
		{
			return;
		}

		foreach (Instruction instruction in method.ControlFlowGraph.Instructions)
		{
			for (int i = 0; i < instruction.Operands.Count; i++)
			{
				if (instruction.Operands[i] is not MemoryOperand memory)
				{
					continue;
				}

				// Has to be [base (local) + addend (field offset)], the same shape Cpp2IL requires.
				if (memory.Index != null || memory.Scale != 0 || memory.Addend <= 0)
				{
					continue;
				}

				if (memory.Base is not LocalVariable local || local.Type is null)
				{
					continue;
				}

				// A static field access, a generic instance and a value typed base each need layout
				// rules of their own. Only the plain case is taken, and a reference typed base at
				// that, because a write through the chain needs the address of the outer field and a
				// value typed local on the stack is a copy.
				if (local.Type is StaticFieldStorageTypeAnalysisContext or GenericInstanceTypeAnalysisContext
					|| local.Type.IsValueType
					|| local.Type.GenericParameters.Count > 0)
				{
					continue;
				}

				List<FieldAnalysisContext>? path = FindPath(local.Type, memory.Addend);

				// A single field is Cpp2IL's own case; if it did not take it, neither do we.
				if (path is null || path.Count < 2)
				{
					continue;
				}

				instruction.SetOperand(i, new NestedFieldReference(local, path, (int)memory.Addend));
			}
		}
	}

	/// <summary>
	/// Finds the chain of fields that reaches <paramref name="targetOffset"/>, outermost first,
	/// descending into a value type field when the offset falls inside it. Null when the offset does
	/// not land on a field, which includes running off the end of the last one.
	/// </summary>
	private static List<FieldAnalysisContext>? FindPath(TypeAnalysisContext owner, long targetOffset, int depth = 0)
	{
		if (depth > MaximumDepth || targetOffset < 0)
		{
			return null;
		}

		// The field the offset falls in is the one with the greatest offset not past it. An inherited
		// field sits at its own offset in the derived layout, so the whole chain is searched.
		FieldAnalysisContext? containing = null;
		int containingOffset = -1;

		for (TypeAnalysisContext? candidate = owner; candidate != null; candidate = candidate.BaseType)
		{
			foreach (FieldAnalysisContext field in candidate.Fields)
			{
				if (field.IsStatic || (field.Attributes & FieldAttributes.Literal) != 0)
				{
					continue;
				}

				// A const has no storage but its metadata offset is 0, which would match at offset 0.
				if (field.BackingData is not { } data || data.FieldOffset > targetOffset || data.FieldOffset <= containingOffset)
				{
					continue;
				}

				containing = field;
				containingOffset = data.FieldOffset;
			}
		}

		if (containing is null)
		{
			return null;
		}

		if (containingOffset == targetOffset)
		{
			return [containing];
		}

		// Only a value type has an interior to descend into. Anything else means the offset has run
		// past the end of the last field, where any answer would be a guess.
		TypeAnalysisContext fieldType = containing.FieldType;

		if (!fieldType.IsValueType || fieldType.IsEnumType || fieldType.GenericParameters.Count > 0)
		{
			return null;
		}

		// A value type's own field offsets are relative to its data, so the search restarts at zero.
		List<FieldAnalysisContext>? inner = FindPath(fieldType, targetOffset - containingOffset, depth + 1);

		if (inner is null)
		{
			return null;
		}

		inner.Insert(0, containing);
		return inner;
	}
}
