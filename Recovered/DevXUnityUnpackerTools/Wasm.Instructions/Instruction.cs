using System.IO;
using System.Text;
using Wasm.Binary;

namespace Wasm.Instructions
{
	public abstract class Instruction
	{
		public abstract Operator Op
		{
			get;
		}

		public Instruction()
		{
		}

		public abstract void WriteImmediatesTo(BinaryWasmWriter writer);

		public void WriteTo(BinaryWasmWriter writer)
		{
			writer.Writer.Write(Op.OpCode);
			WriteImmediatesTo(writer);
		}

		public virtual void Dump(TextWriter writer)
		{
			Op.Dump(writer);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			Dump(new StringWriter(stringBuilder));
			return stringBuilder.ToString();
		}
	}
}
