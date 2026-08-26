using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SpirV
{
	public class Instruction
	{
		[CompilerGenerated]
		private readonly string _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		private readonly IList<Operand> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;

		public string Name
		{
			get;
		}

		public IList<Operand> Operands
		{
			get;
		}

		public Instruction(string name)
			: this(name, new List<Operand>())
		{
		}

		public Instruction(string name, IList<Operand> operands)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A = operands;
			_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A = name;
		}
	}
}
