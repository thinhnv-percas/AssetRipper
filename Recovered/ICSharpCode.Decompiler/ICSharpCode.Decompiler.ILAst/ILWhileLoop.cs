using System.Collections.Generic;

namespace ICSharpCode.Decompiler.ILAst
{
	public class ILWhileLoop : ILNode
	{
		public ILExpression Condition;

		public ILBlock BodyBlock;

		public override IEnumerable<ILNode> GetChildren()
		{
			if (Condition != null)
			{
				yield return Condition;
			}
			if (BodyBlock != null)
			{
				yield return BodyBlock;
			}
		}

		public override void WriteTo(ITextOutput output)
		{
			output.WriteLine("");
			output.Write("loop (");
			if (Condition != null)
			{
				Condition.WriteTo(output);
			}
			output.WriteLine(") {");
			output.Indent();
			BodyBlock.WriteTo(output);
			output.Unindent();
			output.WriteLine("}");
		}
	}
}
