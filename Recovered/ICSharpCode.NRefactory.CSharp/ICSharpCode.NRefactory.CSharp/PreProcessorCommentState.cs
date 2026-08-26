namespace ICSharpCode.NRefactory.CSharp
{
	public class PreProcessorCommentState : IndentState
	{
		public PreProcessorCommentState()
		{
		}

		public PreProcessorCommentState(PreProcessorCommentState prototype, CSharpIndentEngine engine)
			: base(prototype, engine)
		{
		}

		public override void Push(char ch)
		{
			base.Push(ch);
			if (ch == '#' && Engine.isLineStart)
			{
				ChangeState<PreProcessorState>();
			}
		}

		public override void InitializeState()
		{
			if (Engine.formattingOptions.IndentPreprocessorDirectives && Engine.ifDirectiveIndents.Count > 0)
			{
				ThisLineIndent = Engine.ifDirectiveIndents.Peek().Clone();
				NextLineIndent = ThisLineIndent.Clone();
			}
			else
			{
				ThisLineIndent = Parent.NextLineIndent.Clone();
				NextLineIndent = ThisLineIndent.Clone();
			}
		}

		public override IndentState Clone(CSharpIndentEngine engine)
		{
			return new PreProcessorCommentState(this, engine);
		}
	}
}
