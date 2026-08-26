using System.IO;
using System.Text;
using Wasm.Binary;

namespace Wasm
{
	public abstract class Section
	{
		public abstract SectionName Name
		{
			get;
		}

		public Section()
		{
		}

		public abstract void WritePayloadTo(BinaryWasmWriter writer);

		internal void WriteCustomNameAndPayloadTo(BinaryWasmWriter writer)
		{
			if (Name.IsCustom)
			{
				writer.WriteString(Name.CustomName);
			}
			WritePayloadTo(writer);
		}

		public MemoryStream PayloadAsMemoryStream()
		{
			MemoryStream memoryStream = new MemoryStream();
			WritePayloadTo(new BinaryWasmWriter(new BinaryWriter(memoryStream)));
			memoryStream.Seek(0L, SeekOrigin.Begin);
			return memoryStream;
		}

		public virtual void Dump(TextWriter writer)
		{
			DumpNameAndPayload(writer);
		}

		public void DumpNameAndPayload(TextWriter writer)
		{
			writer.Write(Name.ToString());
			writer.Write("; payload length: ");
			using (MemoryStream memoryStream = PayloadAsMemoryStream())
			{
				writer.Write(memoryStream.Length);
				writer.WriteLine();
				DumpHelpers.DumpStream(memoryStream, writer);
				writer.WriteLine();
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			Dump(new StringWriter(stringBuilder));
			return stringBuilder.ToString();
		}
	}
}
