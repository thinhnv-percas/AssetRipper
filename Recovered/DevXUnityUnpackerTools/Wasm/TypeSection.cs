using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class TypeSection : Section
	{
		[CompilerGenerated]
		internal List<FunctionType> _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_000A;

		[CompilerGenerated]
		internal byte[] _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020;

		public List<FunctionType> FunctionTypes
		{
			get;
			internal set;
		}

		public byte[] ExtraPayload
		{
			get;
			set;
		}

		public override SectionName Name => new SectionName(SectionCode.Type);

		public TypeSection()
			: this(Enumerable.Empty<FunctionType>())
		{
		}

		public TypeSection(IEnumerable<FunctionType> functionTypes)
			: this(functionTypes, new byte[0])
		{
		}

		public TypeSection(IEnumerable<FunctionType> functionTypes, byte[] extraPayload)
		{
			FunctionTypes = new List<FunctionType>(functionTypes);
			ExtraPayload = extraPayload;
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32((uint)FunctionTypes.Count);
			foreach (FunctionType functionType in FunctionTypes)
			{
				functionType.WriteTo(writer);
			}
			writer.Writer.Write(ExtraPayload);
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
				writer.Write(" -> ");
				FunctionTypes[i].Dump(writer);
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

		public static TypeSection ReadSectionPayload(SectionHeader header, BinaryWasmReader reader)
		{
			long position = reader.Position;
			uint num = reader.ReadVarUInt32();
			List<FunctionType> list = new List<FunctionType>((int)num);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				list.Add(FunctionType.ReadFrom(reader));
			}
			byte[] extraPayload = reader.ReadRemainingPayload(position, header);
			return new TypeSection(list, extraPayload);
		}
	}
}
