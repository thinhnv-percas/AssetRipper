using System;

namespace ICSharpCode.NRefactory.CSharp
{
	public class ParenthesesBodyState : BracketsBodyBaseState
	{
		public bool IsSomethingPushed;

		public override char ClosedBracket => ')';

		public ParenthesesBodyState()
		{
		}

		public ParenthesesBodyState(ParenthesesBodyState prototype, CSharpIndentEngine engine)
			: base(prototype, engine)
		{
			IsSomethingPushed = prototype.IsSomethingPushed;
		}

		public override void Push(char ch)
		{
			if (ch == Engine.newLineChar)
			{
				if ((Engine.formattingOptions.AnonymousMethodBraceStyle == BraceStyle.EndOfLine || Engine.formattingOptions.AnonymousMethodBraceStyle == BraceStyle.EndOfLineWithoutSpace) && NextLineIndent.PopIf(IndentType.Continuation))
				{
					NextLineIndent.Push(IndentType.Block);
				}
			}
			else if (!IsSomethingPushed && Engine.formattingOptions.AlignToFirstMethodCallArgument)
			{
				NextLineIndent.PopTry();
				NextLineIndent.ExtraSpaces = Math.Max(0, Engine.column - NextLineIndent.CurIndent - 1);
			}
			base.Push(ch);
			IsSomethingPushed = true;
		}

		public override void InitializeState()
		{
			ThisLineIndent = Parent.ThisLineIndent.Clone();
			NextLineIndent = ThisLineIndent.Clone();
			NextLineIndent.Push(IndentType.Continuation);
		}

		public override IndentState Clone(CSharpIndentEngine engine)
		{
			return new ParenthesesBodyState(this, engine);
		}

		public override void OnExit()
		{
			if (Engine.isLineStart)
			{
				if (ThisLineIndent.ExtraSpaces > 0)
				{
					ThisLineIndent.ExtraSpaces--;
				}
				else
				{
					ThisLineIndent.PopTry();
				}
			}
			base.OnExit();
		}
	}
}
