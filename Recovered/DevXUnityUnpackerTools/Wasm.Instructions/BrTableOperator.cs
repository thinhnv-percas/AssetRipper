using System.Collections.Generic;
using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class BrTableOperator : Operator
	{
		public BrTableOperator(byte opCode, WasmType declaringType, string mnemonic)
			: base(opCode, declaringType, mnemonic)
		{
		}

		public override Instruction ReadImmediates(BinaryWasmReader reader)
		{
			uint num = reader.ReadVarUInt32();
			List<uint> list = new List<uint>((int)num);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				list.Add(reader.ReadVarUInt32());
			}
			uint defaultTarget = reader.ReadVarUInt32();
			return Create(list, defaultTarget);
		}

		public BrTableInstruction Create(IEnumerable<uint> targetTable, uint defaultTarget)
		{
			return new BrTableInstruction(this, targetTable, defaultTarget);
		}

		public BrTableInstruction CastInstruction(Instruction value)
		{
			return (BrTableInstruction)value;
		}
	}
}
