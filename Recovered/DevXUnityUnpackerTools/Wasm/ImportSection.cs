using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class ImportSection : Section
	{
		[CompilerGenerated]
		internal List<ImportedValue> _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_000A;

		[CompilerGenerated]
		internal byte[] _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020;

		public override SectionName Name => new SectionName(SectionCode.Import);

		public List<ImportedValue> Imports
		{
			get;
			internal set;
		}

		public byte[] ExtraPayload
		{
			get;
			set;
		}

		public ImportSection()
		{
			Imports = new List<ImportedValue>();
			ExtraPayload = new byte[0];
		}

		public ImportSection(IEnumerable<ImportedValue> imports)
			: this(imports, new byte[0])
		{
		}

		public ImportSection(IEnumerable<ImportedValue> imports, byte[] extraPayload)
		{
			Imports = new List<ImportedValue>(imports);
			ExtraPayload = extraPayload;
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32((uint)Imports.Count);
			foreach (ImportedValue import in Imports)
			{
				import.WriteTo(writer);
			}
			writer.Writer.Write(ExtraPayload);
		}

		public static ImportSection ReadSectionPayload(SectionHeader header, BinaryWasmReader reader)
		{
			long position = reader.Position;
			uint num = reader.ReadVarUInt32();
			List<ImportedValue> list = new List<ImportedValue>();
			for (uint num2 = 0u; num2 < num; num2++)
			{
				list.Add(ImportedValue.ReadFrom(reader));
			}
			byte[] extraPayload = reader.ReadRemainingPayload(position, header);
			return new ImportSection(list, extraPayload);
		}

		public override void Dump(TextWriter writer)
		{
			writer.Write(Name.ToString());
			writer.Write("; number of entries: ");
			writer.Write(Imports.Count);
			writer.WriteLine();
			for (int i = 0; i < Imports.Count; i++)
			{
				writer.Write("#");
				writer.Write(i);
				writer.Write(" -> ");
				Imports[i].Dump(writer);
				writer.WriteLine();
			}
			if (ExtraPayload.Length != 0)
			{
				writer.Write("Extra payload size: ");
				writer.Write(ExtraPayload.Length);
				writer.WriteLine();
				DumpHelpers.DumpBytes(ExtraPayload, writer);
				writer.WriteLine();
			}
		}
	}
}
