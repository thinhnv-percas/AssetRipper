using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	public class SwitchCaseState : BracesBodyState
	{
		private static readonly string[] caseDefaultKeywords = new string[2]
		{
			"case",
			"default"
		};

		private static readonly string[] breakContinueReturnGotoKeywords = new string[4]
		{
			"break",
			"continue",
			"return",
			"goto"
		};

		public SwitchCaseState()
		{
		}

		public SwitchCaseState(SwitchCaseState prototype, CSharpIndentEngine engine)
			: base(prototype, engine)
		{
		}

		public override void Push(char ch)
		{
			if (ch == ClosedBracket)
			{
				ExitState();
				if (Parent is BracesBodyState)
				{
					Parent.OnExit();
				}
			}
			base.Push(ch);
		}

		public override void InitializeState()
		{
			ThisLineIndent = Parent.ThisLineIndent.Clone();
			NextLineIndent = ThisLineIndent.Clone();
			ThisLineIndent.RemoveAlignment();
			ThisLineIndent.PopWhile(IndentType.Continuation);
			NextLineIndent.RemoveAlignment();
			NextLineIndent.PopWhile(IndentType.Continuation);
			if (Engine.formattingOptions.IndentCaseBody)
			{
				NextLineIndent.Push(IndentType.Block);
			}
			else
			{
				NextLineIndent.Push(IndentType.Empty);
			}
		}

		public override void CheckKeyword(string keyword)
		{
			if (caseDefaultKeywords.Contains(keyword) && Engine.isLineStartBeforeWordToken)
			{
				ExitState();
				ChangeState<SwitchCaseState>();
			}
			else if (breakContinueReturnGotoKeywords.Contains(keyword) && Engine.isLineStartBeforeWordToken && !Engine.formattingOptions.IndentBreakStatements)
			{
				ThisLineIndent = Parent.ThisLineIndent.Clone();
			}
			base.CheckKeyword(keyword);
		}

		public override void OnExit()
		{
		}

		public override IndentState Clone(CSharpIndentEngine engine)
		{
			return new SwitchCaseState(this, engine);
		}
	}
}
