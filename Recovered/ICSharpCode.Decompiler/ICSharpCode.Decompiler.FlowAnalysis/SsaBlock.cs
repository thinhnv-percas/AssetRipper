using System.Collections.Generic;
using System.IO;

namespace ICSharpCode.Decompiler.FlowAnalysis
{
	public sealed class SsaBlock
	{
		public readonly List<SsaBlock> Successors = new List<SsaBlock>();

		public readonly List<SsaBlock> Predecessors = new List<SsaBlock>();

		public readonly ControlFlowNodeType NodeType;

		public readonly List<SsaInstruction> Instructions = new List<SsaInstruction>();

		public readonly int BlockIndex;

		internal SsaBlock(ControlFlowNode node)
		{
			NodeType = node.NodeType;
			BlockIndex = node.BlockIndex;
		}

		public override string ToString()
		{
			StringWriter stringWriter = new StringWriter();
			stringWriter.Write("Block #{0} ({1})", BlockIndex, NodeType);
			foreach (SsaInstruction instruction in Instructions)
			{
				stringWriter.WriteLine();
				instruction.WriteTo(stringWriter);
			}
			return stringWriter.ToString();
		}
	}
}
