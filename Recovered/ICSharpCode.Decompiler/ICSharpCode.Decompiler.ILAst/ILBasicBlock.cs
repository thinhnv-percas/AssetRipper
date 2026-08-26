using System.Collections.Generic;

namespace ICSharpCode.Decompiler.ILAst
{
	public class ILBasicBlock : ILNode
	{
		public List<ILNode> Body = new List<ILNode>();

		public override IEnumerable<ILNode> GetChildren()
		{
			return Body;
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
