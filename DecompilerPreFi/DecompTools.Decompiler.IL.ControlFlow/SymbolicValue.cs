using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.ControlFlow;

internal struct SymbolicValue
{
	public readonly int Constant;

	public readonly SymbolicValueType Type;

	public readonly LongSet ValueSet;

	public SymbolicValue(SymbolicValueType type, int constant = 0)
	{
		Type = type;
		Constant = constant;
	}

	public SymbolicValue(SymbolicValueType type, LongSet valueSet)
	{
		Type = type;
		Constant = 0;
		ValueSet = valueSet;
	}

	public SymbolicValue AsBool()
	{
		if (Type == SymbolicValueType.State)
		{
			return new SymbolicValue(SymbolicValueType.StateInSet, new LongSet(-Constant).Invert());
		}
		return this;
	}

	public override string ToString()
	{
		return $"[SymbolicValue {Type}: {Constant}]";
	}
}
