using System.Collections.Generic;

namespace DecompTools.Decompiler.IL;

public class ILVariableEqualityComparer : IEqualityComparer<ILVariable>
{
	public static readonly ILVariableEqualityComparer Instance = new ILVariableEqualityComparer();

	public bool Equals(ILVariable x, ILVariable y)
	{
		if (x == y)
		{
			return true;
		}
		if (x == null || y == null)
		{
			return false;
		}
		if (x.Kind == VariableKind.StackSlot || y.Kind == VariableKind.StackSlot)
		{
			return false;
		}
		if (x.Function != y.Function || x.Kind != y.Kind)
		{
			return false;
		}
		if (x.Index.HasValue)
		{
			return x.Index == y.Index;
		}
		if (x.StateMachineField != null)
		{
			return x.StateMachineField.Equals(y.StateMachineField);
		}
		return false;
	}

	public int GetHashCode(ILVariable obj)
	{
		if (obj.Kind == VariableKind.StackSlot)
		{
			return obj.GetHashCode();
		}
		return (obj.Function, obj.Kind, obj.Index).GetHashCode();
	}
}
