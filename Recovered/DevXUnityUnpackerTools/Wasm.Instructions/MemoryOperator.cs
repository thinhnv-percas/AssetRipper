using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class MemoryOperator : Operator
	{
		public MemoryOperator(byte opCode, WasmType declaringType, string mnemonic)
			: base(opCode, declaringType, mnemonic)
		{
		}

		public override Instruction ReadImmediates(BinaryWasmReader reader)
		{
			return Create(reader.ReadVarUInt32(), reader.ReadVarUInt32());
		}

		public MemoryInstruction Create(uint log2Alignment, uint offset)
		{
			return new MemoryInstruction(this, log2Alignment, offset);
		}

		public MemoryInstruction CastInstruction(Instruction value)
		{
			return (MemoryInstruction)value;
		}
	}
}
