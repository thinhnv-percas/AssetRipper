using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class TableSection : Section
	{
		[CompilerGenerated]
		private List<TableType> _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A;

		[CompilerGenerated]
		private byte[] _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020;

		public List<TableType> Tables
		{
			get;
			private set;
		}

		public byte[] ExtraPayload
		{
			get;
			set;
		}

		public override SectionName Name => new SectionName(SectionCode.Table);

		public TableSection()
			: this(Enumerable.Empty<TableType>())
		{
		}

		public TableSection(IEnumerable<TableType> tables)
			: this(tables, new byte[0])
		{
		}

		public TableSection(IEnumerable<TableType> tables, byte[] extraPayload)
		{
			Tables = new List<TableType>(tables);
			ExtraPayload = extraPayload;
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32((uint)Tables.Count);
			foreach (TableType table in Tables)
			{
				table.WriteTo(writer);
			}
			writer.Writer.Write(ExtraPayload);
		}

		public override void Dump(TextWriter writer)
		{
			writer.Write(Name.ToString());
			writer.Write("; number of entries: ");
			writer.Write(Tables.Count);
			writer.WriteLine();
			for (int i = 0; i < Tables.Count; i++)
			{
				writer.Write("#");
				writer.Write(i);
				writer.Write(" -> ");
				Tables[i].Dump(writer);
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

		public static TableSection ReadSectionPayload(SectionHeader header, BinaryWasmReader reader)
		{
			long position = reader.Position;
			uint num = reader.ReadVarUInt32();
			List<TableType> list = new List<TableType>((int)num);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				list.Add(TableType.ReadFrom(reader));
			}
			byte[] extraPayload = reader.ReadRemainingPayload(position, header);
			return new TableSection(list, extraPayload);
		}
	}
}
