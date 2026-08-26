using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	public class BracesBodyState : BracketsBodyBaseState
	{
		public enum Body
		{
			None,
			Namespace,
			Class,
			Struct,
			Interface,
			Enum,
			Switch,
			Case,
			Try,
			Catch,
			Finally
		}

		public enum Statement
		{
			None,
			If,
			Else,
			Do,
			While,
			For,
			Foreach,
			Lock,
			Using,
			Return
		}

		public Body CurrentBody;

		public Body NextBody;

		private Statement currentStatement;

		internal CloneableStack<Indent> NestedIfStatementLevels = new CloneableStack<Indent>();

		public Indent LastBlockIndent;

		public bool IsRightHandExpression;

		public bool IsEqualCharPushed;

		public int PreviousLineIndent;

		public bool IsMemberReferenceDotHandled;

		private static readonly Dictionary<string, Body> bodies = new Dictionary<string, Body>
		{
			{
				"namespace",
				Body.Namespace
			},
			{
				"class",
				Body.Class
			},
			{
				"struct",
				Body.Struct
			},
			{
				"interface",
				Body.Interface
			},
			{
				"enum",
				Body.Enum
			},
			{
				"switch",
				Body.Switch
			},
			{
				"try",
				Body.Try
			},
			{
				"catch",
				Body.Catch
			},
			{
				"finally",
				Body.Finally
			}
		};

		private static readonly Dictionary<string, Statement> statements = new Dictionary<string, Statement>
		{
			{
				"if",
				Statement.If
			},
			{
				"do",
				Statement.Do
			},
			{
				"while",
				Statement.While
			},
			{
				"for",
				Statement.For
			},
			{
				"foreach",
				Statement.Foreach
			},
			{
				"lock",
				Statement.Lock
			},
			{
				"using",
				Statement.Using
			},
			{
				"return",
				Statement.Return
			}
		};

		private static readonly HashSet<string> blocks = new HashSet<string>
		{
			"namespace",
			"class",
			"struct",
			"interface",
			"enum",
			"switch",
			"try",
			"catch",
			"finally",
			"if",
			"else",
			"do",
			"while",
			"for",
			"foreach",
			"lock",
			"using"
		};

		private readonly string[] caseDefaultKeywords = new string[2]
		{
			"case",
			"default"
		};

		private readonly string[] classStructKeywords = new string[2]
		{
			"class",
			"struct"
		};

		public Statement CurrentStatement
		{
			get
			{
				return currentStatement;
			}
			set
			{
				if (currentStatement == Statement.None && value != Statement.Else)
				{
					NestedIfStatementLevels.Clear();
				}
				currentStatement = value;
			}
		}

		public override char ClosedBracket => '}';

		public BracesBodyState()
		{
		}

		public BracesBodyState(BracesBodyState prototype, CSharpIndentEngine engine)
			: base(prototype, engine)
		{
			CurrentBody = prototype.CurrentBody;
			NextBody = prototype.NextBody;
			CurrentStatement = prototype.CurrentStatement;
			NestedIfStatementLevels = prototype.NestedIfStatementLevels.Clone();
			IsRightHandExpression = prototype.IsRightHandExpression;
			IsEqualCharPushed = prototype.IsEqualCharPushed;
			IsMemberReferenceDotHandled = prototype.IsMemberReferenceDotHandled;
			LastBlockIndent = prototype.LastBlockIndent;
			PreviousLineIndent = prototype.PreviousLineIndent;
		}

		public override void Push(char ch)
		{
			if (IsEqualCharPushed)
			{
				if (IsRightHandExpression)
				{
					if (ch == Engine.newLineChar)
					{
						NextLineIndent.RemoveAlignment();
						NextLineIndent.Push(IndentType.Continuation);
					}
				}
				else if (ch != '=' && ch != '>')
				{
					IsRightHandExpression = true;
					if (ch == Engine.newLineChar)
					{
						NextLineIndent.Push(IndentType.Continuation);
					}
					else
					{
						NextLineIndent.SetAlignment(Engine.column - NextLineIndent.CurIndent);
					}
				}
				IsEqualCharPushed = (ch == ' ' || ch == '\t');
			}
			if (ch == ';' || (ch == ',' && IsRightHandExpression))
			{
				OnStatementExit();
			}
			else if (ch == '=' && Engine.previousChar != '=' && Engine.previousChar != '<' && Engine.previousChar != '>' && Engine.previousChar != '!')
			{
				IsEqualCharPushed = true;
			}
			else if (ch == '.' && !IsMemberReferenceDotHandled)
			{
				if (Engine.formattingOptions.AlignToMemberReferenceDot && !Engine.isLineStart)
				{
					IsMemberReferenceDotHandled = true;
					NextLineIndent.RemoveAlignment();
					NextLineIndent.SetAlignment(Engine.column - NextLineIndent.CurIndent - 1, forceSpaces: true);
				}
				else if (Engine.isLineStart)
				{
					IsMemberReferenceDotHandled = true;
					ThisLineIndent.RemoveAlignment();
					while (ThisLineIndent.CurIndent > PreviousLineIndent && ThisLineIndent.PopIf(IndentType.Continuation))
					{
					}
					ThisLineIndent.Push(IndentType.Continuation);
					NextLineIndent = ThisLineIndent.Clone();
				}
			}
			else if (ch == ':' && Engine.isLineStart && !IsRightHandExpression)
			{
				ThisLineIndent.Push(IndentType.Continuation);
			}
			else if (ch == Engine.newLineChar)
			{
				PreviousLineIndent = ThisLineIndent.CurIndent;
			}
			if (Engine.wordToken.ToString() == "else")
			{
				CheckKeywordOnPush("else");
			}
			base.Push(ch);
		}

		public override void InitializeState()
		{
			ThisLineIndent = Parent.ThisLineIndent.Clone();
			NextLineIndent = Parent.NextLineIndent.Clone();
			BracesBodyState bracesBodyState = Parent as BracesBodyState;
			if (bracesBodyState == null || bracesBodyState.LastBlockIndent == null || !Engine.EnableCustomIndentLevels)
			{
				NextLineIndent.RemoveAlignment();
				NextLineIndent.PopIf(IndentType.Continuation);
			}
			else
			{
				NextLineIndent = bracesBodyState.LastBlockIndent.Clone();
			}
			if (Engine.isLineStart)
			{
				ThisLineIndent = NextLineIndent.Clone();
			}
			CurrentBody = extractBody(Parent);
			NextBody = Body.None;
			CurrentStatement = Statement.None;
			AddIndentation(CurrentBody);
		}

		public override IndentState Clone(CSharpIndentEngine engine)
		{
			return new BracesBodyState(this, engine);
		}

		public override void OnExit()
		{
			if (Parent is BracesBodyState && !((BracesBodyState)Parent).IsRightHandExpression)
			{
				((BracesBodyState)Parent).OnStatementExit();
			}
			if (Engine.isLineStart)
			{
				ThisLineIndent.RemoveAlignment();
				ThisLineIndent.PopTry();
				if (TryGetBraceStyle(CurrentBody, out BraceStyle style) && (style == BraceStyle.NextLineShifted || style == BraceStyle.NextLineShifted2 || style == BraceStyle.BannerStyle))
				{
					ThisLineIndent.Push(IndentType.Block);
				}
			}
			base.OnExit();
		}

		public virtual void OnStatementExit()
		{
			IsRightHandExpression = false;
			IsMemberReferenceDotHandled = false;
			NextLineIndent.RemoveAlignment();
			NextLineIndent.PopWhile(IndentType.Continuation);
			CurrentStatement = Statement.None;
			NextBody = Body.None;
			LastBlockIndent = null;
		}

		public override void CheckKeywordOnPush(string keyword)
		{
			if (keyword == "else")
			{
				CurrentStatement = Statement.Else;
				if (!Engine.formattingOptions.AlignElseInIfStatements && NestedIfStatementLevels.Count > 0)
				{
					ThisLineIndent = NestedIfStatementLevels.Pop().Clone();
					NextLineIndent = ThisLineIndent.Clone();
				}
				NextLineIndent.Push(IndentType.Continuation);
			}
			if (blocks.Contains(keyword) && Engine.NeedsReindent)
			{
				LastBlockIndent = Indent.ConvertFrom(Engine.CurrentIndent, ThisLineIndent, Engine.textEditorOptions);
			}
		}

		public override void CheckKeyword(string keyword)
		{
			if (bodies.ContainsKey(keyword))
			{
				if (!classStructKeywords.Contains(keyword) || (NextBody != Body.Class && NextBody != Body.Struct && NextBody != Body.Interface))
				{
					NextBody = bodies[keyword];
				}
			}
			else if (caseDefaultKeywords.Contains(keyword) && CurrentBody == Body.Switch && Engine.isLineStartBeforeWordToken)
			{
				ChangeState<SwitchCaseState>();
			}
			else if (keyword == "where" && Engine.isLineStartBeforeWordToken)
			{
				ThisLineIndent.Push(IndentType.Continuation);
			}
			else if (statements.ContainsKey(keyword))
			{
				Statement statement = CurrentStatement;
				CurrentStatement = statements[keyword];
				if (CurrentStatement == Statement.Using && (this is GlobalBodyState || CurrentBody == Body.Namespace))
				{
					return;
				}
				if (Engine.formattingOptions.AlignEmbeddedStatements && statement == Statement.If && CurrentStatement == Statement.If)
				{
					ThisLineIndent.PopIf(IndentType.Continuation);
					NextLineIndent.PopIf(IndentType.Continuation);
				}
				if (Engine.formattingOptions.AlignEmbeddedStatements && statement == Statement.Lock && CurrentStatement == Statement.Lock)
				{
					ThisLineIndent.PopIf(IndentType.Continuation);
					NextLineIndent.PopIf(IndentType.Continuation);
				}
				if (Engine.formattingOptions.AlignEmbeddedStatements && statement == Statement.Using && CurrentStatement == Statement.Using)
				{
					ThisLineIndent.PopIf(IndentType.Continuation);
					NextLineIndent.PopIf(IndentType.Continuation);
				}
				if (CurrentStatement != Statement.If || statement != Statement.Else || Engine.isLineStartBeforeWordToken)
				{
					NextLineIndent.Push(IndentType.Continuation);
				}
				if (CurrentStatement == Statement.If)
				{
					NestedIfStatementLevels.Push(ThisLineIndent);
				}
			}
			if (blocks.Contains(keyword) && Engine.NeedsReindent)
			{
				LastBlockIndent = Indent.ConvertFrom(Engine.CurrentIndent, ThisLineIndent, Engine.textEditorOptions);
			}
		}

		private void AddIndentation(BraceStyle braceStyle)
		{
			switch (braceStyle)
			{
			case BraceStyle.NextLineShifted:
				ThisLineIndent.Push(IndentType.Block);
				NextLineIndent.Push(IndentType.Block);
				break;
			case BraceStyle.DoNotChange:
			case BraceStyle.EndOfLine:
			case BraceStyle.EndOfLineWithoutSpace:
			case BraceStyle.NextLine:
			case BraceStyle.BannerStyle:
				NextLineIndent.Push(IndentType.Block);
				break;
			case BraceStyle.NextLineShifted2:
				ThisLineIndent.Push(IndentType.Block);
				NextLineIndent.Push(IndentType.DoubleBlock);
				break;
			}
		}

		private bool TryGetBraceStyle(Body body, out BraceStyle style)
		{
			style = BraceStyle.DoNotChange;
			switch (body)
			{
			case Body.None:
				if (!Engine.formattingOptions.IndentBlocks)
				{
					return false;
				}
				style = Engine.formattingOptions.StatementBraceStyle;
				return true;
			case Body.Namespace:
				if (!Engine.formattingOptions.IndentNamespaceBody)
				{
					return false;
				}
				style = Engine.formattingOptions.NamespaceBraceStyle;
				return true;
			case Body.Class:
				if (!Engine.formattingOptions.IndentClassBody)
				{
					return false;
				}
				style = Engine.formattingOptions.ClassBraceStyle;
				return true;
			case Body.Struct:
				if (!Engine.formattingOptions.IndentStructBody)
				{
					return false;
				}
				style = Engine.formattingOptions.StructBraceStyle;
				return true;
			case Body.Interface:
				if (!Engine.formattingOptions.IndentInterfaceBody)
				{
					return false;
				}
				style = Engine.formattingOptions.InterfaceBraceStyle;
				return true;
			case Body.Enum:
				if (!Engine.formattingOptions.IndentEnumBody)
				{
					return false;
				}
				style = Engine.formattingOptions.EnumBraceStyle;
				return true;
			case Body.Switch:
				if (!Engine.formattingOptions.IndentSwitchBody)
				{
					return false;
				}
				style = Engine.formattingOptions.StatementBraceStyle;
				return true;
			case Body.Try:
			case Body.Catch:
			case Body.Finally:
				style = Engine.formattingOptions.StatementBraceStyle;
				return true;
			default:
				return false;
			}
		}

		private void AddIndentation(Body body)
		{
			if ((Parent is ParenthesesBodyState || Parent is SquareBracketsBodyState || (Parent is BracesBodyState && ((BracesBodyState)Parent).IsRightHandExpression)) && Engine.formattingOptions.IndentBlocksInsideExpressions && Engine.isLineStart)
			{
				AddIndentation(BraceStyle.NextLineShifted);
			}
			if (TryGetBraceStyle(body, out BraceStyle style))
			{
				AddIndentation(style);
			}
			else
			{
				NextLineIndent.Push(IndentType.Empty);
			}
		}

		private static Body extractBody(IndentState state)
		{
			if (state != null && state is BracesBodyState)
			{
				return ((BracesBodyState)state).NextBody;
			}
			return Body.None;
		}
	}
}
