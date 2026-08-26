using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class IfElseInstruction : Instruction
	{
		[CompilerGenerated]
		internal WasmType _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		[CompilerGenerated]
		internal List<Instruction> _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020;

		[CompilerGenerated]
		internal List<Instruction> _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A;

		public override Operator Op => _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A;

		public WasmType Type
		{
			get;
			set;
		}

		public List<Instruction> IfBranch
		{
			get;
			internal set;
		}

		public List<Instruction> ElseBranch
		{
			get;
			internal set;
		}

		public bool HasElseBranch => ElseBranch != null;

		public IfElseInstruction(WasmType type, IEnumerable<Instruction> ifBranch, IEnumerable<Instruction> elseBranch)
		{
			Type = type;
			IfBranch = new List<Instruction>(ifBranch);
			ElseBranch = ((elseBranch == null) ? null : new List<Instruction>(elseBranch));
		}

		public override void WriteImmediatesTo(BinaryWasmWriter writer)
		{
			writer.WriteWasmType(Type);
			WriteContentsTo(writer);
		}

		public void WriteContentsTo(BinaryWasmWriter writer)
		{
			foreach (Instruction item in IfBranch)
			{
				item.WriteTo(writer);
			}
			if (HasElseBranch)
			{
				writer.Writer.Write((byte)5);
				foreach (Instruction item2 in ElseBranch)
				{
					item2.WriteTo(writer);
				}
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
			foreach (Instruction item in IfBranch)
			{
				textWriter.WriteLine();
				item.Dump(textWriter);
			}
			writer.WriteLine();
			if (HasElseBranch)
			{
				writer.Write("else");
				foreach (Instruction item2 in ElseBranch)
				{
					textWriter.WriteLine();
					item2.Dump(textWriter);
				}
				writer.WriteLine();
			}
			writer.Write("end");
		}
	}
}
