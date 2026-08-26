using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class Float64Operator : Operator
	{
		public Float64Operator(byte opCode, WasmType declaringType, string mnemonic)
			: base(opCode, declaringType, mnemonic)
		{
		}

		public override Instruction ReadImmediates(BinaryWasmReader Reader)
		{
			return Create(Reader.ReadFloat64());
		}

		public Float64Instruction Create(double Immediate)
		{
			return new Float64Instruction(this, Immediate);
		}

		public Float64Instruction CastInstruction(Instruction Value)
		{
			return (Float64Instruction)Value;
		}
	}
}
