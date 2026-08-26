using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;
using Wasm.Instructions;

namespace Wasm
{
	public sealed class DataSegment
	{
		[CompilerGenerated]
		private uint _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020;

		[CompilerGenerated]
		private InitializerExpression _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020;

		[CompilerGenerated]
		private byte[] _0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A;

		public uint MemoryIndex
		{
			get;
			set;
		}

		public InitializerExpression Offset
		{
			get;
			set;
		}

		public byte[] Data
		{
			get;
			set;
		}

		public DataSegment(uint memoryIndex, InitializerExpression offset, byte[] data)
		{
			MemoryIndex = memoryIndex;
			Offset = offset;
			Data = data;
		}

		public void WriteTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32(MemoryIndex);
			Offset.WriteTo(writer);
			writer.WriteVarUInt32((uint)Data.Length);
			writer.Writer.Write(Data);
		}

		public static DataSegment ReadFrom(BinaryWasmReader reader)
		{
			uint memoryIndex = reader.ReadVarUInt32();
			InitializerExpression offset = InitializerExpression.ReadFrom(reader);
			uint count = reader.ReadVarUInt32();
			byte[] data = reader.ReadBytes((int)count);
			return new DataSegment(memoryIndex, offset, data);
		}

		public void Dump(TextWriter writer)
		{
			writer.Write("- Memory index: ");
			writer.Write(MemoryIndex);
			writer.WriteLine();
			writer.Write("- Offset:");
			TextWriter textWriter = DumpHelpers.CreateIndentedTextWriter(writer);
			foreach (Wasm.Instructions.Instruction bodyInstruction in Offset.BodyInstructions)
			{
				textWriter.WriteLine();
				bodyInstruction.Dump(textWriter);
			}
			writer.WriteLine();
			writer.Write("- Data:");
			textWriter.WriteLine();
			DumpHelpers.DumpBytes(Data, textWriter);
		}
	}
}
