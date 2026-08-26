using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class StartSection : Section
	{
		[CompilerGenerated]
		internal uint _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020;

		[CompilerGenerated]
		internal byte[] _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020;

		public override SectionName Name => new SectionName(SectionCode.Start);

		public uint StartFunctionIndex
		{
			get;
			set;
		}

		public byte[] ExtraPayload
		{
			get;
			set;
		}

		public StartSection(uint startFunctionIndex)
			: this(startFunctionIndex, new byte[0])
		{
		}

		public StartSection(uint startFunctionIndex, byte[] extraPayload)
		{
			StartFunctionIndex = startFunctionIndex;
			ExtraPayload = extraPayload;
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32(StartFunctionIndex);
			writer.Writer.Write(ExtraPayload);
		}

		public override void Dump(TextWriter writer)
		{
			writer.Write(Name.ToString());
			writer.Write("; entry point: function #");
			writer.Write(StartFunctionIndex);
			writer.WriteLine();
			if (ExtraPayload.Length != 0)
			{
				writer.Write("Extra payload size: ");
				writer.Write(ExtraPayload.Length);
				writer.WriteLine();
				DumpHelpers.DumpBytes(ExtraPayload, writer);
				writer.WriteLine();
			}
		}

		public static StartSection ReadSectionPayload(SectionHeader header, BinaryWasmReader reader)
		{
			long position = reader.Position;
			uint startFunctionIndex = reader.ReadVarUInt32();
			byte[] extraPayload = reader.ReadRemainingPayload(position, header);
			return new StartSection(startFunctionIndex, extraPayload);
		}
	}
}
