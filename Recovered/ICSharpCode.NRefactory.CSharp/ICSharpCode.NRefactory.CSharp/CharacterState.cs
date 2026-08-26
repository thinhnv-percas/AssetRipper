namespace ICSharpCode.NRefactory.CSharp
{
	public class CharacterState : IndentState
	{
		public bool IsEscaped;

		public CharacterState()
		{
		}

		public CharacterState(CharacterState prototype, CSharpIndentEngine engine)
			: base(prototype, engine)
		{
			IsEscaped = prototype.IsEscaped;
		}

		public override void Push(char ch)
		{
			base.Push(ch);
			if (ch == Engine.newLineChar)
			{
				ExitState();
			}
			else if (!IsEscaped && ch == '\'')
			{
				ExitState();
			}
			IsEscaped = (ch == '\\' && !IsEscaped);
		}

		public override void InitializeState()
		{
			ThisLineIndent = Parent.ThisLineIndent.Clone();
			NextLineIndent = Parent.NextLineIndent.Clone();
		}

		public override IndentState Clone(CSharpIndentEngine engine)
		{
			return new CharacterState(this, engine);
		}
	}
}
