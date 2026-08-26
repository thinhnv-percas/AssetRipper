using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class ExportSection : Section
	{
		[CompilerGenerated]
		internal List<ExportedValue> _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020;

		[CompilerGenerated]
		internal byte[] _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020;

		public override SectionName Name => new SectionName(SectionCode.Export);

		public List<ExportedValue> Exports
		{
			get;
			internal set;
		}

		public byte[] ExtraPayload
		{
			get;
			set;
		}

		public ExportSection()
		{
			Exports = new List<ExportedValue>();
			ExtraPayload = new byte[0];
		}

		public ExportSection(IEnumerable<ExportedValue> exports)
			: this(exports, new byte[0])
		{
		}

		public ExportSection(IEnumerable<ExportedValue> exports, byte[] extraPayload)
		{
			Exports = new List<ExportedValue>(exports);
			ExtraPayload = extraPayload;
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32((uint)Exports.Count);
			foreach (ExportedValue export in Exports)
			{
				export.WriteTo(writer);
			}
			writer.Writer.Write(ExtraPayload);
		}

		public static ExportSection ReadSectionPayload(SectionHeader header, BinaryWasmReader reader)
		{
			long position = reader.Position;
			uint num = reader.ReadVarUInt32();
			List<ExportedValue> list = new List<ExportedValue>();
			for (uint num2 = 0u; num2 < num; num2++)
			{
				list.Add(new ExportedValue(reader.ReadString(), (ExternalKind)reader.ReadByte(), reader.ReadVarUInt32()));
			}
			byte[] extraPayload = reader.ReadRemainingPayload(position, header);
			return new ExportSection(list, extraPayload);
		}

		public override void Dump(TextWriter writer)
		{
			writer.Write(Name.ToString());
			writer.Write("; number of entries: ");
			writer.Write(Exports.Count);
			writer.WriteLine();
			for (int i = 0; i < Exports.Count; i++)
			{
				writer.Write("#");
				writer.Write(i);
				writer.Write(" -> ");
				Exports[i].Dump(writer);
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
