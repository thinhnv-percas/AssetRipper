using System.Collections.Generic;

namespace ICSharpCode.Decompiler.ILAst
{
	public class ILCondition : ILNode
	{
		public ILExpression Condition;

		public ILBlock TrueBlock;

		public ILBlock FalseBlock;

		public override IEnumerable<ILNode> GetChildren()
		{
			if (Condition != null)
			{
				yield return Condition;
			}
			if (TrueBlock != null)
			{
				yield return TrueBlock;
			}
			if (FalseBlock != null)
			{
				yield return FalseBlock;
			}
		}

		public override void WriteTo(ITextOutput output)
		{
			output.Write("if (");
			Condition.WriteTo(output);
			output.WriteLine(") {");
			output.Indent();
			TrueBlock.WriteTo(output);
			output.Unindent();
			output.Write("}");
			if (FalseBlock != null)
			{
				output.WriteLine(" else {");
				output.Indent();
				FalseBlock.WriteTo(output);
				output.Unindent();
				output.WriteLine("}");
			}
		}
	}
}
