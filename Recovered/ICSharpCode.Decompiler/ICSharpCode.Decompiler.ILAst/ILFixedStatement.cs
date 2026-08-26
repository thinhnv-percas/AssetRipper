using System.Collections.Generic;

namespace ICSharpCode.Decompiler.ILAst
{
	public class ILFixedStatement : ILNode
	{
		public List<ILExpression> Initializers = new List<ILExpression>();

		public ILBlock BodyBlock;

		public override IEnumerable<ILNode> GetChildren()
		{
			foreach (ILExpression initializer in Initializers)
			{
				yield return initializer;
			}
			if (BodyBlock != null)
			{
				yield return BodyBlock;
			}
		}

		public override void WriteTo(ITextOutput output)
		{
			output.Write("fixed (");
			for (int i = 0; i < Initializers.Count; i++)
			{
				if (i > 0)
				{
					output.Write(", ");
				}
				Initializers[i].WriteTo(output);
			}
			output.WriteLine(") {");
			output.Indent();
			BodyBlock.WriteTo(output);
			output.Unindent();
			output.WriteLine("}");
		}
	}
}
