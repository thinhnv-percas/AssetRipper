using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class MemoryInstruction : Instruction
	{
		internal MemoryOperator _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		[CompilerGenerated]
		internal uint _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A;

		[CompilerGenerated]
		internal uint _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020;

		public override Operator Op => _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		public uint Log2Alignment
		{
			get;
			internal set;
		}

		public uint Alignment => (uint)(1 << (int)Log2Alignment);

		public uint Offset
		{
			get;
			internal set;
		}

		public MemoryInstruction(MemoryOperator op, uint log2Alignment, uint offset)
		{
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020 = op;
			Log2Alignment = log2Alignment;
			Offset = offset;
		}

		public override void WriteImmediatesTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32(Log2Alignment);
			writer.WriteVarUInt32(Offset);
		}

		public override void Dump(TextWriter writer)
		{
			Op.Dump(writer);
			writer.Write(" offset=");
			writer.Write(Offset);
			writer.Write(" align=");
			writer.Write(Alignment);
		}
	}
}
