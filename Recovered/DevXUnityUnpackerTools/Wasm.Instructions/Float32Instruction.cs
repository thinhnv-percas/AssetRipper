using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class Float32Instruction : Instruction
	{
		private Float32Operator _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		[CompilerGenerated]
		private float _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A;

		public override Operator Op => _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		public float Immediate
		{
			get;
			set;
		}

		public Float32Instruction(Float32Operator op, float immediate)
		{
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020 = op;
			Immediate = immediate;
		}

		public override void WriteImmediatesTo(BinaryWasmWriter writer)
		{
			writer.WriteFloat32(Immediate);
		}

		public override void Dump(TextWriter writer)
		{
			Op.Dump(writer);
			writer.Write(" ");
			writer.Write(Immediate);
		}
	}
}
