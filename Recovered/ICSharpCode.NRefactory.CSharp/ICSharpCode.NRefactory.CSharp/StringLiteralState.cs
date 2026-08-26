namespace ICSharpCode.NRefactory.CSharp
{
	public class StringLiteralState : IndentState
	{
		public bool IsEscaped;

		public StringLiteralState()
		{
		}

		public StringLiteralState(StringLiteralState prototype, CSharpIndentEngine engine)
			: base(prototype, engine)
		{
			IsEscaped = prototype.IsEscaped;
		}

		public override void Push(char ch)
		{
			base.Push(ch);
			if (ch == Engine.newLineChar || (!IsEscaped && ch == '"'))
			{
				ExitState();
			}
			else
			{
				IsEscaped = (ch == '\\' && !IsEscaped);
			}
		}

		public override void InitializeState()
		{
			ThisLineIndent = Parent.ThisLineIndent.Clone();
			NextLineIndent = Parent.NextLineIndent.Clone();
		}

		public override IndentState Clone(CSharpIndentEngine engine)
		{
			return new StringLiteralState(this, engine);
		}
	}
}
