namespace ICSharpCode.NRefactory.CSharp
{
	public class NullState : IndentState
	{
		public NullState()
		{
		}

		public NullState(NullState prototype, CSharpIndentEngine engine)
			: base(prototype, engine)
		{
		}

		public override void Push(char ch)
		{
		}

		public override IndentState Clone(CSharpIndentEngine engine)
		{
			return new NullState(this, engine);
		}
	}
}
