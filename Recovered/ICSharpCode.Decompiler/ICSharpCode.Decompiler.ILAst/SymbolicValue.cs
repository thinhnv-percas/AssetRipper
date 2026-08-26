namespace ICSharpCode.Decompiler.ILAst
{
	internal struct SymbolicValue
	{
		public readonly int Constant;

		public readonly SymbolicValueType Type;

		public SymbolicValue(SymbolicValueType type, int constant = 0)
		{
			Type = type;
			Constant = constant;
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
			return $"[SymbolicValue {Type}: {Constant}]";
		}
	}
}
