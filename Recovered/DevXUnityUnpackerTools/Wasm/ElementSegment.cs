using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;
using Wasm.Instructions;

namespace Wasm
{
	public sealed class ElementSegment
	{
		[CompilerGenerated]
		internal uint _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A;

		[CompilerGenerated]
		internal InitializerExpression _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020;

		[CompilerGenerated]
		internal List<uint> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A;

		public uint TableIndex
		{
			get;
			set;
		}

		public InitializerExpression Offset
		{
			get;
			set;
		}

		public List<uint> Elements
		{
			get;
			internal set;
		}

		public ElementSegment(uint tableIndex, InitializerExpression offset, IEnumerable<uint> elements)
		{
			TableIndex = tableIndex;
			Offset = offset;
			Elements = new List<uint>(elements);
		}

		public void WriteTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32(TableIndex);
			Offset.WriteTo(writer);
			writer.WriteVarUInt32((uint)Elements.Count);
			foreach (uint element in Elements)
			{
				writer.WriteVarUInt32(element);
			}
		}

		public static ElementSegment ReadFrom(BinaryWasmReader reader)
		{
			uint tableIndex = reader.ReadVarUInt32();
			InitializerExpression offset = InitializerExpression.ReadFrom(reader);
			uint num = reader.ReadVarUInt32();
			List<uint> list = new List<uint>((int)num);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				list.Add(reader.ReadVarUInt32());
			}
			return new ElementSegment(tableIndex, offset, list);
		}

		public void Dump(TextWriter writer)
		{
			writer.Write("- Table index: ");
			writer.Write(TableIndex);
			writer.WriteLine();
			writer.Write("- Offset:");
			TextWriter textWriter = DumpHelpers.CreateIndentedTextWriter(writer);
			foreach (Wasm.Instructions.Instruction bodyInstruction in Offset.BodyInstructions)
			{
				textWriter.WriteLine();
				bodyInstruction.Dump(textWriter);
			}
			writer.WriteLine();
			writer.Write("- Elements:");
			for (int i = 0; i < Elements.Count; i++)
			{
				textWriter.WriteLine();
				textWriter.Write("#{0} -> func #{1}", i, Elements[i]);
			}
		}
	}
}
