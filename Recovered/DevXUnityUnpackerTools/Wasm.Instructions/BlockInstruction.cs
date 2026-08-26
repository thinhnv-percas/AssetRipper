using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class BlockInstruction : Instruction
	{
		internal BlockOperator _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		[CompilerGenerated]
		internal WasmType _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		[CompilerGenerated]
		internal List<Instruction> _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A;

		public override Operator Op => _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		public WasmType Type
		{
			get;
			set;
		}

		public int Arity
		{
			get
			{
				if (Type != WasmType.Empty)
				{
					return 1;
				}
				return 0;
			}
		}

		public List<Instruction> Contents
		{
			get;
			internal set;
		}

		public BlockInstruction(BlockOperator op, WasmType type, IEnumerable<Instruction> contents)
		{
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020 = op;
			Type = type;
			Contents = new List<Instruction>(contents);
		}

		public override void WriteImmediatesTo(BinaryWasmWriter writer)
		{
			writer.WriteWasmType(Type);
			WriteContentsTo(writer);
		}

		public void WriteContentsTo(BinaryWasmWriter writer)
		{
			foreach (Instruction content in Contents)
			{
				content.WriteTo(writer);
			}
			writer.Writer.Write((byte)11);
		}

		public override void Dump(TextWriter writer)
		{
			Op.Dump(writer);
			writer.Write(" (result: ");
			DumpHelpers.DumpWasmType(Type, writer);
			writer.Write(")");
			TextWriter textWriter = DumpHelpers.CreateIndentedTextWriter(writer);
			foreach (Instruction content in Contents)
			{
				textWriter.WriteLine();
				content.Dump(textWriter);
			}
			writer.WriteLine();
			writer.Write("end");
		}
	}
}
