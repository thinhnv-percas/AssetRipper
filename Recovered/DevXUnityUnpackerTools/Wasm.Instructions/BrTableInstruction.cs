using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class BrTableInstruction : Instruction
	{
		internal BrTableOperator _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		[CompilerGenerated]
		internal List<uint> _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A;

		[CompilerGenerated]
		internal uint _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020;

		public override Operator Op => _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		public List<uint> TargetTable
		{
			get;
			internal set;
		}

		public uint DefaultTarget
		{
			get;
			set;
		}

		public BrTableInstruction(BrTableOperator op, IEnumerable<uint> targetTable, uint defaultTarget)
		{
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020 = op;
			TargetTable = new List<uint>(targetTable);
			DefaultTarget = defaultTarget;
		}

		public override void WriteImmediatesTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32((uint)TargetTable.Count);
			foreach (uint item in TargetTable)
			{
				writer.WriteVarUInt32(item);
			}
			writer.WriteVarUInt32(DefaultTarget);
		}

		public override void Dump(TextWriter writer)
		{
			Op.Dump(writer);
			writer.Write(" default=");
			writer.Write(DefaultTarget);
			TextWriter textWriter = DumpHelpers.CreateIndentedTextWriter(writer);
			for (int i = 0; i < TargetTable.Count; i++)
			{
				textWriter.WriteLine();
				textWriter.Write(i);
				textWriter.Write(" -> ");
				textWriter.Write(TargetTable[i]);
			}
			writer.WriteLine();
		}
	}
}
