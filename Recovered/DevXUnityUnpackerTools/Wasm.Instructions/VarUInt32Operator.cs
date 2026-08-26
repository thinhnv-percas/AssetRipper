using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class VarUInt32Operator : Operator
	{
		public VarUInt32Operator(byte opCode, WasmType declaringType, string mnemonic)
			: base(opCode, declaringType, mnemonic)
		{
		}

		public override Instruction ReadImmediates(BinaryWasmReader reader)
		{
			return Create(reader.ReadVarUInt32());
		}

		public VarUInt32Instruction Create(uint immediate)
		{
			return new VarUInt32Instruction(this, immediate);
		}

		public VarUInt32Instruction CastInstruction(Instruction value)
		{
			return (VarUInt32Instruction)value;
		}
	}
}
