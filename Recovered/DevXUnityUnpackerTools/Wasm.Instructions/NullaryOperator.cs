using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class NullaryOperator : Operator
	{
		internal NullaryInstruction _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020;

		public NullaryOperator(byte opCode, WasmType declaringType, string mnemonic)
			: base(opCode, declaringType, mnemonic)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020 = new NullaryInstruction(this);
		}

		public NullaryInstruction Create()
		{
			return _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020;
		}

		public override Instruction ReadImmediates(BinaryWasmReader reader)
		{
			return _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020;
		}
	}
}
