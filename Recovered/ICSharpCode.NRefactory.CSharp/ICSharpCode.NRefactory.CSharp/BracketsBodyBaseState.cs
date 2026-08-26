namespace ICSharpCode.NRefactory.CSharp
{
	public abstract class BracketsBodyBaseState : IndentState
	{
		public abstract char ClosedBracket
		{
			get;
		}

		protected BracketsBodyBaseState()
		{
		}

		protected BracketsBodyBaseState(BracketsBodyBaseState prototype, CSharpIndentEngine engine)
			: base(prototype, engine)
		{
		}

		public override void Push(char ch)
		{
			base.Push(ch);
			switch (ch)
			{
			case '#':
				if (Engine.isLineStart)
				{
					ChangeState<PreProcessorState>();
				}
				break;
			case '/':
				if (Engine.previousChar == '/')
				{
					ChangeState<LineCommentState>();
				}
				break;
			case '*':
				if (Engine.previousChar == '/')
				{
					ChangeState<MultiLineCommentState>();
				}
				break;
			case '"':
				if (Engine.previousChar == '@')
				{
					ChangeState<VerbatimStringState>();
				}
				else
				{
					ChangeState<StringLiteralState>();
				}
				break;
			case '\'':
				ChangeState<CharacterState>();
				break;
			case '{':
				ChangeState<BracesBodyState>();
				break;
			case '(':
				ChangeState<ParenthesesBodyState>();
				break;
			case '[':
				ChangeState<SquareBracketsBodyState>();
				break;
			default:
				if (ch == ClosedBracket)
				{
					ExitState();
				}
				break;
			}
		}
	}
}
