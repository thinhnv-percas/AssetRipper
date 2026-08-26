using System.IO;
using System.Text;
using Wasm.Binary;

namespace Wasm
{
	public abstract class NameEntry
	{
		public abstract NameEntryKind Kind
		{
			get;
		}

		public abstract void WritePayloadTo(BinaryWasmWriter writer);

		public virtual void Dump(TextWriter writer)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter writer2 = new BinaryWriter(memoryStream))
				{
					WritePayloadTo(new BinaryWasmWriter(writer2));
					memoryStream.Seek(0L, SeekOrigin.Begin);
					writer.WriteLine("entry kind '{0}', payload size: {1}", Kind, memoryStream.Length);
					DumpHelpers.CreateIndentedTextWriter(writer);
					DumpHelpers.DumpStream(memoryStream, writer);
				}
			}
		}

		public void WriteTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt7((byte)Kind);
			writer.WriteLengthPrefixed(WritePayloadTo);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			Dump(new StringWriter(stringBuilder));
			return stringBuilder.ToString();
		}

		public static NameEntry Read(BinaryWasmReader reader)
		{
			NameEntryKind nameEntryKind = (NameEntryKind)reader.ReadVarUInt7();
			uint length = reader.ReadVarUInt32();
			if (nameEntryKind == NameEntryKind.Module)
			{
				return ModuleNameEntry.ReadPayload(reader, length);
			}
			return UnknownNameEntry.ReadPayload(reader, nameEntryKind, length);
		}
	}
}
