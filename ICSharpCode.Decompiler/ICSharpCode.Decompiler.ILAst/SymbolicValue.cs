namespace ICSharpCode.Decompiler.ILAst;

internal struct SymbolicValue
{
	public readonly int Constant;

	public readonly int Constant2;

	public readonly SymbolicValueType Type;

	public SymbolicValue(SymbolicValueType type, int constant = 0)
	{
		Type = type;
		Constant = constant;
		Constant2 = 0;
	}

	public SymbolicValue(SymbolicValueType type, int constant1, int constant2)
	{
		Type = type;
		Constant = constant1;
		Constant2 = constant2;
	}

	public SymbolicValue AsBool()
	{
		if (Type == SymbolicValueType.State)
		{
			return new SymbolicValue(SymbolicValueType.StateInEquals, -Constant);
		}
		return this;
	}

	public override string ToString()
	{
		if (Type == SymbolicValueType.StateIsInRange)
		{
			return $"[SymbolicValue {Type}: [{Constant}..{Constant2}]]";
		}
		if (Type == SymbolicValueType.StateIsNotInRange)
		{
			return $"[SymbolicValue {Type}: ![{Constant}..{Constant2}]]";
		}
		return $"[SymbolicValue {Type}: {Constant}]";
	}
}
