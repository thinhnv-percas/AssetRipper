using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class VarUInt32Instruction : Instruction
	{
		private Operator _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		[CompilerGenerated]
		private uint _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A;

		public override Operator Op => _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		public uint Immediate
		{
			get;
			set;
		}

		public VarUInt32Instruction(Operator op, uint immediate)
		{
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020 = op;
			Immediate = immediate;
		}

		public override void WriteImmediatesTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32(Immediate);
		}

		public override void Dump(TextWriter writer)
		{
			Op.Dump(writer);
			writer.Write(" ");
			writer.Write(Immediate);
		}
	}
}
