namespace ICSharpCode.NRefactory.CSharp
{
	public class VerbatimStringState : IndentState
	{
		public bool IsEscaped;

		public VerbatimStringState()
		{
		}

		public VerbatimStringState(VerbatimStringState prototype, CSharpIndentEngine engine)
			: base(prototype, engine)
		{
			IsEscaped = prototype.IsEscaped;
		}

		public override void Push(char ch)
		{
			base.Push(ch);
			if (IsEscaped && ch != '"')
			{
				ExitState();
				Engine.currentState.Push(ch);
			}
			IsEscaped = (ch == '"' && !IsEscaped);
		}

		public override void InitializeState()
		{
			ThisLineIndent = Parent.ThisLineIndent.Clone();
			NextLineIndent = new Indent(Engine.textEditorOptions);
		}

		public override IndentState Clone(CSharpIndentEngine engine)
		{
			return new VerbatimStringState(this, engine);
		}
	}
}
