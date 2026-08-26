#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

internal class TupleTransform
{
	public static bool MatchTupleFieldAccess(LdFlda inst, out IType tupleType, out ILInstruction target, out int position)
	{
		tupleType = inst.Field.DeclaringType;
		target = inst.Target;
		if (!inst.Field.Name.StartsWith("Item", StringComparison.Ordinal))
		{
			position = 0;
			return false;
		}
		if (!int.TryParse(inst.Field.Name.Substring(4), out position))
		{
			return false;
		}
		if (!TupleType.IsTupleCompatible(tupleType, out var tupleCardinality))
		{
			return false;
		}
		checked
		{
			while (target is LdFlda ldFlda && ldFlda.Field.Name == "Rest" && TupleType.IsTupleCompatible(ldFlda.Field.DeclaringType, out tupleCardinality))
			{
				tupleType = ldFlda.Field.DeclaringType;
				target = ldFlda.Target;
				position += 7;
			}
			return true;
		}
	}

	public static bool MatchTupleConstruction(NewObj newobj, out ILInstruction[] arguments)
	{
		arguments = null;
		if (newobj == null)
		{
			return false;
		}
		if (!TupleType.IsTupleCompatible(newobj.Method.DeclaringType, out var tupleCardinality))
		{
			return false;
		}
		arguments = new ILInstruction[tupleCardinality];
		int num = 0;
		checked
		{
			while (tupleCardinality >= 8)
			{
				if (newobj.Arguments.Count != 8)
				{
					return false;
				}
				for (int i = 1; i < 8; i++)
				{
					arguments[num++] = newobj.Arguments[i - 1];
				}
				tupleCardinality -= 7;
				Debug.Assert(num + tupleCardinality == arguments.Length);
				newobj = newobj.Arguments.Last() as NewObj;
				if (newobj == null)
				{
					return false;
				}
				if (!TupleType.IsTupleCompatible(newobj.Method.DeclaringType, out var tupleCardinality2))
				{
					return false;
				}
				if (tupleCardinality2 != tupleCardinality)
				{
					return false;
				}
			}
			Debug.Assert(num + tupleCardinality == arguments.Length);
			if (newobj.Arguments.Count != tupleCardinality)
			{
				return false;
			}
			for (int j = 0; j < tupleCardinality; j++)
			{
				arguments[num++] = newobj.Arguments[j];
			}
			return true;
		}
	}
}
