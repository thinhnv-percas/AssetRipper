using System.Collections.Generic;
using Wasm.Instructions;

namespace Wasm.Optimize
{
	public sealed class UnreachableCodeOptimization : PeepholeOptimization
	{
		public static readonly UnreachableCodeOptimization Instance = new UnreachableCodeOptimization();

		private static readonly HashSet<Operator> _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A = new HashSet<Operator>
		{
			_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_0020,
			_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A,
			_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_000A
		};

		private UnreachableCodeOptimization()
		{
		}

		public override uint Match(IList<Wasm.Instructions.Instruction> instructions)
		{
			if (instructions.Count <= 1)
			{
				return 0u;
			}
			Wasm.Instructions.Instruction instruction = instructions[0];
			if (_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Contains(instruction.Op))
			{
				return (uint)instructions.Count;
			}
			return 0u;
		}

		public override IList<Wasm.Instructions.Instruction> Rewrite(IList<Wasm.Instructions.Instruction> matched)
		{
			return new Wasm.Instructions.Instruction[1]
			{
				matched[0]
			};
		}
	}
}
