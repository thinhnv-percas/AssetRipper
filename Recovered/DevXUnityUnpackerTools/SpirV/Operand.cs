using System.Runtime.CompilerServices;

namespace SpirV
{
	public class Operand
	{
		[CompilerGenerated]
		internal readonly string _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		internal readonly OperandType _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		[CompilerGenerated]
		internal readonly OperandQuantifier _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020;

		public string Name
		{
			get;
		}

		public OperandType Type
		{
			get;
		}

		public OperandQuantifier Quantifier
		{
			get;
		}

		public Operand(OperandType kind, string name, OperandQuantifier quantifier)
		{
			_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A = name;
			_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020 = kind;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020 = quantifier;
		}
	}
}
