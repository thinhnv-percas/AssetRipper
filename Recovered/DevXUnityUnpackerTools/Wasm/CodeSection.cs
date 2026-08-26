using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class CodeSection : Section
	{
		[CompilerGenerated]
		internal List<FunctionBody> _0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A;

		[CompilerGenerated]
		internal byte[] _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020;

		public override SectionName Name => new SectionName(SectionCode.Code);

		public List<FunctionBody> Bodies
		{
			get;
			internal set;
		}

		public byte[] ExtraPayload
		{
			get;
			set;
		}

		public CodeSection()
		{
			Bodies = new List<FunctionBody>();
			ExtraPayload = new byte[0];
		}

		public CodeSection(IEnumerable<FunctionBody> bodies)
			: this(bodies, new byte[0])
		{
		}

		public CodeSection(IEnumerable<FunctionBody> bodies, byte[] extraPayload)
		{
			Bodies = new List<FunctionBody>(bodies);
			ExtraPayload = extraPayload;
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32((uint)Bodies.Count);
			foreach (FunctionBody body in Bodies)
			{
				body.WriteTo(writer);
			}
			writer.Writer.Write(ExtraPayload);
		}

		public static CodeSection ReadSectionPayload(SectionHeader header, BinaryWasmReader reader)
		{
			long position = reader.Position;
			uint num = reader.ReadVarUInt32();
			List<FunctionBody> list = new List<FunctionBody>();
			for (uint num2 = 0u; num2 < num; num2++)
			{
				list.Add(FunctionBody.ReadFrom(reader));
			}
			byte[] extraPayload = reader.ReadRemainingPayload(position, header);
			return new CodeSection(list, extraPayload);
		}

		public override void Dump(TextWriter writer)
		{
			writer.Write(Name.ToString());
			writer.Write("; number of entries: ");
			writer.Write(Bodies.Count);
			writer.WriteLine();
			TextWriter textWriter = DumpHelpers.CreateIndentedTextWriter(writer);
			for (int i = 0; i < Bodies.Count; i++)
			{
				writer.Write("#{0}: ", i);
				textWriter.WriteLine();
				Bodies[i].Dump(textWriter);
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
