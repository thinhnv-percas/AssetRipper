using System.Collections.Generic;

namespace ICSharpCode.Decompiler.ILAst
{
	public class ILBlock : ILNode
	{
		public ILExpression EntryGoto;

		public List<ILNode> Body;

		public ILBlock(params ILNode[] body)
		{
			Body = new List<ILNode>(body);
		}

		public ILBlock(List<ILNode> body)
		{
			Body = body;
		}

		public override IEnumerable<ILNode> GetChildren()
		{
			if (EntryGoto != null)
			{
				yield return EntryGoto;
			}
			foreach (ILNode item in Body)
			{
				yield return item;
			}
		}

		public override void WriteTo(ITextOutput output)
		{
			foreach (ILNode child in GetChildren())
			{
				child.WriteTo(output);
				output.WriteLine();
			}
		}
	}
}
