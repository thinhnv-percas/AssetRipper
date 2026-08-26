namespace ICSharpCode.NRefactory.CSharp
{
	public class DocCommentState : IndentState
	{
		public DocCommentState()
		{
		}

		public DocCommentState(DocCommentState prototype, CSharpIndentEngine engine)
			: base(prototype, engine)
		{
		}

		public override void Push(char ch)
		{
			base.Push(ch);
			if (ch == Engine.newLineChar)
			{
				ExitState();
			}
		}

		public override void InitializeState()
		{
			ThisLineIndent = Parent.ThisLineIndent.Clone();
			NextLineIndent = Parent.NextLineIndent.Clone();
		}

		public override IndentState Clone(CSharpIndentEngine engine)
		{
			return new DocCommentState(this, engine);
		}
	}
}
