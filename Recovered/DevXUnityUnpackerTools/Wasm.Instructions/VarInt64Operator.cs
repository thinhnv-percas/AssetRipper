using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class VarInt64Operator : Operator
	{
		public VarInt64Operator(byte opCode, WasmType declaringType, string mnemonic)
			: base(opCode, declaringType, mnemonic)
		{
		}

		public override Instruction ReadImmediates(BinaryWasmReader reader)
		{
			return Create(reader.ReadVarInt64());
		}

		public VarInt64Instruction Create(long immediate)
		{
			return new VarInt64Instruction(this, immediate);
		}

		public VarInt64Instruction CastInstruction(Instruction value)
		{
			return (VarInt64Instruction)value;
		}
	}
}
