using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class NullaryInstruction : Instruction
	{
		private NullaryOperator _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		public override Operator Op => _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		public NullaryInstruction(NullaryOperator op)
		{
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020 = op;
		}

		public override void WriteImmediatesTo(BinaryWasmWriter writer)
		{
		}
	}
}
