using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class GlobalSection : Section
	{
		[CompilerGenerated]
		internal List<GlobalVariable> _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020;

		[CompilerGenerated]
		internal byte[] _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020;

		public override SectionName Name => new SectionName(SectionCode.Global);

		public List<GlobalVariable> GlobalVariables
		{
			get;
			internal set;
		}

		public byte[] ExtraPayload
		{
			get;
			set;
		}

		public GlobalSection()
		{
			GlobalVariables = new List<GlobalVariable>();
		}

		public GlobalSection(IEnumerable<GlobalVariable> globalVariables)
			: this(globalVariables, new byte[0])
		{
		}

		public GlobalSection(IEnumerable<GlobalVariable> globalVariables, byte[] extraPayload)
		{
			GlobalVariables = new List<GlobalVariable>(globalVariables);
			ExtraPayload = extraPayload;
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32((uint)GlobalVariables.Count);
			foreach (GlobalVariable globalVariable in GlobalVariables)
			{
				globalVariable.WriteTo(writer);
			}
			writer.Writer.Write(ExtraPayload);
		}

		public static GlobalSection ReadSectionPayload(SectionHeader header, BinaryWasmReader reader)
		{
			long position = reader.Position;
			uint num = reader.ReadVarUInt32();
			List<GlobalVariable> list = new List<GlobalVariable>();
			for (uint num2 = 0u; num2 < num; num2++)
			{
				list.Add(GlobalVariable.ReadFrom(reader));
			}
			byte[] extraPayload = reader.ReadRemainingPayload(position, header);
			return new GlobalSection(list, extraPayload);
		}

		public override void Dump(TextWriter writer)
		{
			writer.Write(Name.ToString());
			writer.Write("; number of entries: ");
			writer.Write(GlobalVariables.Count);
			writer.WriteLine();
			TextWriter textWriter = DumpHelpers.CreateIndentedTextWriter(writer);
			for (int i = 0; i < GlobalVariables.Count; i++)
			{
				writer.Write("#{0}:", i);
				textWriter.WriteLine();
				GlobalVariables[i].Dump(textWriter);
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
