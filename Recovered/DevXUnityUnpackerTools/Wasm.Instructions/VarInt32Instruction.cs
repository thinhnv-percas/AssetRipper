using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class VarInt32Instruction : Instruction
	{
		internal VarInt32Operator _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		[CompilerGenerated]
		internal int _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A;

		public override Operator Op => _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		public int Immediate
		{
			get;
			set;
		}

		public VarInt32Instruction(VarInt32Operator op, int immediate)
		{
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020 = op;
			Immediate = immediate;
		}

		public override void WriteImmediatesTo(BinaryWasmWriter writer)
		{
			writer.WriteVarInt32(Immediate);
		}

		public override void Dump(TextWriter writer)
		{
			Op.Dump(writer);
			writer.Write(" ");
			writer.Write(Immediate);
		}
	}
}
