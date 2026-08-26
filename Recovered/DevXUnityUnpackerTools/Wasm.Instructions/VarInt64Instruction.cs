using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class VarInt64Instruction : Instruction
	{
		private Operator _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		[CompilerGenerated]
		private long _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A;

		public override Operator Op => _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		public long Immediate
		{
			get;
			set;
		}

		public VarInt64Instruction(Operator op, long immediate)
		{
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020 = op;
			Immediate = immediate;
		}

		public override void WriteImmediatesTo(BinaryWasmWriter writer)
		{
			writer.WriteVarInt64(Immediate);
		}

		public override void Dump(TextWriter writer)
		{
			Op.Dump(writer);
			writer.Write(" ");
			writer.Write(Immediate);
		}
	}
}
