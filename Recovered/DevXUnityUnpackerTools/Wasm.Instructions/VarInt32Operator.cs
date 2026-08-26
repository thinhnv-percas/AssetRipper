using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class VarInt32Operator : Operator
	{
		public VarInt32Operator(byte opCode, WasmType declaringType, string mnemonic)
			: base(opCode, declaringType, mnemonic)
		{
		}

		public override Instruction ReadImmediates(BinaryWasmReader reader)
		{
			return Create(reader.ReadVarInt32());
		}

		public VarInt32Instruction Create(int immediate)
		{
			return new VarInt32Instruction(this, immediate);
		}

		public VarInt32Instruction CastInstruction(Instruction value)
		{
			return (VarInt32Instruction)value;
		}
	}
}
