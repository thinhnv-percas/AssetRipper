namespace ICSharpCode.NRefactory.CSharp
{
	public class GlobalBodyState : BracesBodyState
	{
		public override char ClosedBracket => '\0';

		public GlobalBodyState()
		{
		}

		public GlobalBodyState(CSharpIndentEngine engine)
		{
			Initialize(engine);
		}

		public GlobalBodyState(GlobalBodyState prototype, CSharpIndentEngine engine)
			: base(prototype, engine)
		{
		}

		public override IndentState Clone(CSharpIndentEngine engine)
		{
			return new GlobalBodyState(this, engine);
		}

		public override void InitializeState()
		{
			ThisLineIndent = new Indent(Engine.textEditorOptions);
			NextLineIndent = ThisLineIndent.Clone();
		}
	}
}
