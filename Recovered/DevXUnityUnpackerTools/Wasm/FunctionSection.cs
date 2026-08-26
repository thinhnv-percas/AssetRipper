using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class FunctionSection : Section
	{
		[CompilerGenerated]
		private List<uint> _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_000A;

		[CompilerGenerated]
		private byte[] _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020;

		public override SectionName Name => new SectionName(SectionCode.Function);

		public List<uint> FunctionTypes
		{
			get;
			private set;
		}

		public byte[] ExtraPayload
		{
			get;
			set;
		}

		public FunctionSection()
		{
			FunctionTypes = new List<uint>();
			ExtraPayload = new byte[0];
		}

		public FunctionSection(IEnumerable<uint> functionTypes)
			: this(functionTypes, new byte[0])
		{
		}

		public FunctionSection(IEnumerable<uint> functionTypes, byte[] extraPayload)
		{
			FunctionTypes = new List<uint>(functionTypes);
			ExtraPayload = extraPayload;
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32((uint)FunctionTypes.Count);
			foreach (uint functionType in FunctionTypes)
			{
				writer.WriteVarUInt32(functionType);
			}
			writer.Writer.Write(ExtraPayload);
		}

		public static FunctionSection ReadSectionPayload(SectionHeader header, BinaryWasmReader reader)
		{
			long position = reader.Position;
			uint num = reader.ReadVarUInt32();
			List<uint> list = new List<uint>();
			for (uint num2 = 0u; num2 < num; num2++)
			{
				list.Add(reader.ReadVarUInt32());
			}
			byte[] extraPayload = reader.ReadRemainingPayload(position, header);
			return new FunctionSection(list, extraPayload);
		}

		public override void Dump(TextWriter writer)
		{
			writer.Write(Name.ToString());
			writer.Write("; number of entries: ");
			writer.Write(FunctionTypes.Count);
			writer.WriteLine();
			for (int i = 0; i < FunctionTypes.Count; i++)
			{
				writer.Write("#");
				writer.Write(i);
				writer.Write(" -> type #");
				writer.Write(FunctionTypes[i]);
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
