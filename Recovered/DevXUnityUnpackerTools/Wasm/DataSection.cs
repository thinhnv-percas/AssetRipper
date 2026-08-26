using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class DataSection : Section
	{
		[CompilerGenerated]
		internal List<DataSegment> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020;

		[CompilerGenerated]
		internal byte[] _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020;

		public override SectionName Name => new SectionName(SectionCode.Data);

		public List<DataSegment> Segments
		{
			get;
			internal set;
		}

		public byte[] ExtraPayload
		{
			get;
			set;
		}

		public DataSection()
		{
			Segments = new List<DataSegment>();
			ExtraPayload = new byte[0];
		}

		public DataSection(IEnumerable<DataSegment> segments)
			: this(segments, new byte[0])
		{
		}

		public DataSection(IEnumerable<DataSegment> segments, byte[] extraPayload)
		{
			Segments = new List<DataSegment>(segments);
			ExtraPayload = extraPayload;
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32((uint)Segments.Count);
			foreach (DataSegment segment in Segments)
			{
				segment.WriteTo(writer);
			}
			writer.Writer.Write(ExtraPayload);
		}

		public static DataSection ReadSectionPayload(SectionHeader header, BinaryWasmReader reader)
		{
			long position = reader.Position;
			uint num = reader.ReadVarUInt32();
			List<DataSegment> list = new List<DataSegment>();
			for (uint num2 = 0u; num2 < num; num2++)
			{
				list.Add(DataSegment.ReadFrom(reader));
			}
			byte[] extraPayload = reader.ReadRemainingPayload(position, header);
			return new DataSection(list, extraPayload);
		}

		public override void Dump(TextWriter writer)
		{
			writer.Write(Name.ToString());
			writer.Write("; number of entries: ");
			writer.Write(Segments.Count);
			writer.WriteLine();
			TextWriter textWriter = DumpHelpers.CreateIndentedTextWriter(writer);
			for (int i = 0; i < Segments.Count; i++)
			{
				writer.Write("#{0}:", i);
				textWriter.WriteLine();
				Segments[i].Dump(textWriter);
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
