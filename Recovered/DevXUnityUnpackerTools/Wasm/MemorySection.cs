using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class MemorySection : Section
	{
		[CompilerGenerated]
		internal List<MemoryType> _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		internal byte[] _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020;

		public override SectionName Name => new SectionName(SectionCode.Memory);

		public List<MemoryType> Memories
		{
			get;
			internal set;
		}

		public byte[] ExtraPayload
		{
			get;
			set;
		}

		public MemorySection()
		{
			Memories = new List<MemoryType>();
			ExtraPayload = new byte[0];
		}

		public MemorySection(IEnumerable<MemoryType> memories)
			: this(memories, new byte[0])
		{
		}

		public MemorySection(IEnumerable<MemoryType> memories, byte[] extraPayload)
		{
			Memories = new List<MemoryType>(memories);
			ExtraPayload = extraPayload;
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32((uint)Memories.Count);
			foreach (MemoryType memory in Memories)
			{
				memory.WriteTo(writer);
			}
			writer.Writer.Write(ExtraPayload);
		}

		public override void Dump(TextWriter writer)
		{
			writer.Write(Name.ToString());
			writer.Write("; number of entries: ");
			writer.Write(Memories.Count);
			writer.WriteLine();
			for (int i = 0; i < Memories.Count; i++)
			{
				writer.Write("#");
				writer.Write(i);
				writer.Write(" -> ");
				Memories[i].Dump(writer);
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

		public static MemorySection ReadSectionPayload(SectionHeader header, BinaryWasmReader reader)
		{
			long position = reader.Position;
			uint num = reader.ReadVarUInt32();
			List<MemoryType> list = new List<MemoryType>();
			for (uint num2 = 0u; num2 < num; num2++)
			{
				list.Add(MemoryType.ReadFrom(reader));
			}
			byte[] extraPayload = reader.ReadRemainingPayload(position, header);
			return new MemorySection(list, extraPayload);
		}
	}
}
