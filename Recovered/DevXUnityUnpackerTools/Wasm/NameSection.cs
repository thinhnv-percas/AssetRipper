using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class NameSection : Section
	{
		public const string CustomName = "name";

		[CompilerGenerated]
		private List<NameEntry> _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_0020;

		public override SectionName Name => new SectionName("name");

		public List<NameEntry> Names
		{
			get;
			private set;
		}

		public NameSection()
		{
			Names = new List<NameEntry>();
		}

		public NameSection(IEnumerable<NameEntry> names)
		{
			Names = new List<NameEntry>(names);
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			foreach (NameEntry name in Names)
			{
				name.WriteTo(writer);
			}
		}

		public override void Dump(TextWriter writer)
		{
			writer.Write(Name.ToString());
			writer.Write("; number of entries: ");
			writer.Write(Names.Count);
			writer.WriteLine();
			for (int i = 0; i < Names.Count; i++)
			{
				writer.Write("#");
				writer.Write(i);
				writer.Write(" -> ");
				Names[i].Dump(writer);
				writer.WriteLine();
			}
		}

		public static NameSection ReadSectionPayload(SectionHeader header, BinaryWasmReader reader)
		{
			NameSection nameSection = new NameSection();
			long position = reader.Position;
			while (reader.Position - position < header.PayloadLength)
			{
				nameSection.Names.Add(NameEntry.Read(reader));
			}
			return nameSection;
		}
	}
}
