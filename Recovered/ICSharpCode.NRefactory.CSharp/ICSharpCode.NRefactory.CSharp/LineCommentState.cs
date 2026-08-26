namespace ICSharpCode.NRefactory.CSharp
{
	public class LineCommentState : IndentState
	{
		public bool CheckForDocComment = true;

		public LineCommentState()
		{
		}

		public LineCommentState(LineCommentState prototype, CSharpIndentEngine engine)
			: base(prototype, engine)
		{
			CheckForDocComment = prototype.CheckForDocComment;
		}

		public override void Push(char ch)
		{
			base.Push(ch);
			if (ch == Engine.newLineChar)
			{
				Engine.previousChar = '\0';
				ExitState();
			}
			else if (ch == '/' && CheckForDocComment)
			{
				ExitState();
				ChangeState<DocCommentState>();
			}
			CheckForDocComment = false;
		}

		public override void InitializeState()
		{
			ThisLineIndent = Parent.ThisLineIndent.Clone();
			NextLineIndent = Parent.NextLineIndent.Clone();
		}

		public override IndentState Clone(CSharpIndentEngine engine)
		{
			return new LineCommentState(this, engine);
		}
	}
}
