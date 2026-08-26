using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class Float64Instruction : Instruction
	{
		internal Float64Operator _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		[CompilerGenerated]
		internal double _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A;

		public override Operator Op => _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		public double Immediate
		{
			get;
			set;
		}

		public Float64Instruction(Float64Operator op, double immediate)
		{
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020 = op;
			Immediate = immediate;
		}

		public override void WriteImmediatesTo(BinaryWasmWriter writer)
		{
			writer.WriteFloat64(Immediate);
		}

		public override void Dump(TextWriter writer)
		{
			Op.Dump(writer);
			writer.Write(" ");
			writer.Write(Immediate);
		}
	}
}
