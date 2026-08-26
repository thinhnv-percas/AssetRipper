using System.Collections.Generic;
using Wasm.Instructions;

namespace Wasm.Optimize
{
	public sealed class TeeLocalOptimization : PeepholeOptimization
	{
		public static readonly TeeLocalOptimization Instance = new TeeLocalOptimization();

		internal TeeLocalOptimization()
		{
		}

		public override uint Match(IList<Wasm.Instructions.Instruction> instructions)
		{
			if (instructions.Count < 2)
			{
				return 0u;
			}
			Wasm.Instructions.Instruction instruction = instructions[0];
			if (instruction.Op != _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A)
			{
				return 0u;
			}
			Wasm.Instructions.Instruction instruction2 = instructions[1];
			if (instruction2.Op != _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020)
			{
				return 0u;
			}
			VarUInt32Instruction varUInt32Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A.CastInstruction(instruction);
			VarUInt32Instruction varUInt32Instruction2 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020.CastInstruction(instruction2);
			if (varUInt32Instruction.Immediate == varUInt32Instruction2.Immediate)
			{
				return 2u;
			}
			return 0u;
		}

		public override IList<Wasm.Instructions.Instruction> Rewrite(IList<Wasm.Instructions.Instruction> matched)
		{
			VarUInt32Instruction varUInt32Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A.CastInstruction(matched[0]);
			return new Wasm.Instructions.Instruction[1]
			{
				_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020.Create(varUInt32Instruction.Immediate)
			};
		}
	}
}
