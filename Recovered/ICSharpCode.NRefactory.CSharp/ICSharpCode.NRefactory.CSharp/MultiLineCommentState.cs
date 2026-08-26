namespace ICSharpCode.NRefactory.CSharp
{
	public class MultiLineCommentState : IndentState
	{
		public bool IsAnyCharPushed;

		public MultiLineCommentState()
		{
		}

		public MultiLineCommentState(MultiLineCommentState prototype, CSharpIndentEngine engine)
			: base(prototype, engine)
		{
			IsAnyCharPushed = prototype.IsAnyCharPushed;
		}

		public override void Push(char ch)
		{
			base.Push(ch);
			if (ch == '/' && Engine.previousChar == '*' && IsAnyCharPushed)
			{
				ExitState();
			}
			IsAnyCharPushed = true;
		}

		public override void InitializeState()
		{
			ThisLineIndent = Parent.ThisLineIndent.Clone();
			NextLineIndent = ThisLineIndent.Clone();
		}

		public override IndentState Clone(CSharpIndentEngine engine)
		{
			return new MultiLineCommentState(this, engine);
		}
	}
}
