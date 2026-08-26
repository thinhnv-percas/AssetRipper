using System.Collections.Generic;

namespace ICSharpCode.Decompiler.ILAst
{
	public class ILSwitch : ILNode
	{
		public class CaseBlock : ILBlock
		{
			public List<int> Values;

			public override void WriteTo(ITextOutput output)
			{
				if (Values != null)
				{
					foreach (int value in Values)
					{
						output.WriteLine("case {0}:", value);
					}
				}
				else
				{
					output.WriteLine("default:");
				}
				output.Indent();
				base.WriteTo(output);
				output.Unindent();
			}
		}

		public ILExpression Condition;

		public List<CaseBlock> CaseBlocks = new List<CaseBlock>();

		public override IEnumerable<ILNode> GetChildren()
		{
			if (Condition != null)
			{
				yield return Condition;
			}
			foreach (CaseBlock caseBlock in CaseBlocks)
			{
				yield return caseBlock;
			}
		}

		public override void WriteTo(ITextOutput output)
		{
			output.Write("switch (");
			Condition.WriteTo(output);
			output.WriteLine(") {");
			output.Indent();
			foreach (CaseBlock caseBlock in CaseBlocks)
			{
				caseBlock.WriteTo(output);
			}
			output.Unindent();
			output.WriteLine("}");
		}
	}
}
