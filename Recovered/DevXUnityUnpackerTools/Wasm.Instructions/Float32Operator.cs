using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class Float32Operator : Operator
	{
		public Float32Operator(byte opCode, WasmType declaringType, string mnemonic)
			: base(opCode, declaringType, mnemonic)
		{
		}

		public override Instruction ReadImmediates(BinaryWasmReader reader)
		{
			return Create(reader.ReadFloat32());
		}

		public Float32Instruction Create(float immediate)
		{
			return new Float32Instruction(this, immediate);
		}

		public Float32Instruction CastInstruction(Instruction value)
		{
			return (Float32Instruction)value;
		}
	}
}
