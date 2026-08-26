namespace ICSharpCode.Decompiler.ILAst
{
	internal struct Interval
	{
		public readonly int Start;

		public readonly int End;

		public Interval(int start, int end)
		{
			Start = start;
			End = end;
		}

		public override string ToString()
		{
			return $"({Start} to {End})";
		}
	}
}
