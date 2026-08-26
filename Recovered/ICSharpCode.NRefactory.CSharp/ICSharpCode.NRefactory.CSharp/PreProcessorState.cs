using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ICSharpCode.NRefactory.CSharp
{
	public class PreProcessorState : IndentState
	{
		public enum PreProcessorDirective
		{
			None,
			If,
			Elif,
			Else,
			Endif,
			Region,
			Endregion,
			Pragma,
			Warning,
			Error,
			Line,
			Define,
			Undef
		}

		public PreProcessorDirective DirectiveType;

		public StringBuilder DirectiveStatement;

		private static readonly Dictionary<string, PreProcessorDirective> preProcessorDirectives = new Dictionary<string, PreProcessorDirective>
		{
			{
				"if",
				PreProcessorDirective.If
			},
			{
				"elif",
				PreProcessorDirective.Elif
			},
			{
				"else",
				PreProcessorDirective.Else
			},
			{
				"endif",
				PreProcessorDirective.Endif
			},
			{
				"region",
				PreProcessorDirective.Region
			},
			{
				"endregion",
				PreProcessorDirective.Endregion
			},
			{
				"pragma",
				PreProcessorDirective.Pragma
			},
			{
				"warning",
				PreProcessorDirective.Warning
			},
			{
				"error",
				PreProcessorDirective.Error
			},
			{
				"line",
				PreProcessorDirective.Line
			},
			{
				"define",
				PreProcessorDirective.Define
			},
			{
				"undef",
				PreProcessorDirective.Undef
			}
		};

		public PreProcessorState()
		{
			DirectiveType = PreProcessorDirective.None;
			DirectiveStatement = new StringBuilder();
		}

		public PreProcessorState(PreProcessorState prototype, CSharpIndentEngine engine)
			: base(prototype, engine)
		{
			DirectiveType = prototype.DirectiveType;
			DirectiveStatement = new StringBuilder(prototype.DirectiveStatement.ToString());
		}

		public override void Push(char ch)
		{
			if (Engine.wordToken.ToString() == "endregion")
			{
				CheckKeywordOnPush("endregion");
			}
			base.Push(ch);
			if (DirectiveType != 0)
			{
				DirectiveStatement.Append(ch);
			}
			if (ch != Engine.newLineChar)
			{
				return;
			}
			ExitState();
			switch (DirectiveType)
			{
			case PreProcessorDirective.Region:
			case PreProcessorDirective.Endregion:
			case PreProcessorDirective.Pragma:
			case PreProcessorDirective.Warning:
			case PreProcessorDirective.Error:
			case PreProcessorDirective.Line:
				break;
			case PreProcessorDirective.If:
				Engine.ifDirectiveEvalResults.Push(eval(DirectiveStatement.ToString()));
				if (!Engine.ifDirectiveEvalResults.Peek())
				{
					ChangeState<PreProcessorCommentState>();
				}
				break;
			case PreProcessorDirective.Elif:
				if (Engine.ifDirectiveEvalResults.Count > 0 && !Engine.ifDirectiveEvalResults.Peek())
				{
					ExitState();
					Engine.ifDirectiveEvalResults.Pop();
					goto case PreProcessorDirective.If;
				}
				ChangeState<PreProcessorCommentState>();
				break;
			case PreProcessorDirective.Else:
				if (Engine.ifDirectiveEvalResults.Count > 0 && Engine.ifDirectiveEvalResults.Peek())
				{
					ChangeState<PreProcessorCommentState>();
				}
				else if (Engine.currentState is PreProcessorCommentState)
				{
					ExitState();
				}
				break;
			case PreProcessorDirective.Define:
			{
				string item2 = DirectiveStatement.ToString().Trim();
				if (!Engine.conditionalSymbols.Contains(item2))
				{
					Engine.conditionalSymbols.Add(item2);
				}
				break;
			}
			case PreProcessorDirective.Undef:
			{
				string item = DirectiveStatement.ToString().Trim();
				if (Engine.conditionalSymbols.Contains(item))
				{
					Engine.conditionalSymbols.Remove(item);
				}
				break;
			}
			case PreProcessorDirective.Endif:
				if (Engine.currentState is PreProcessorCommentState)
				{
					ExitState();
				}
				Engine.ifDirectiveEvalResults.Pop();
				Engine.ifDirectiveIndents.Pop();
				break;
			}
		}

		public override void InitializeState()
		{
			if (Engine.formattingOptions.IndentPreprocessorDirectives)
			{
				if (Engine.ifDirectiveIndents.Count > 0)
				{
					ThisLineIndent = Engine.ifDirectiveIndents.Peek().Clone();
				}
				else
				{
					ThisLineIndent = Parent.ThisLineIndent.Clone();
				}
			}
			else
			{
				ThisLineIndent = new Indent(Engine.textEditorOptions);
			}
			NextLineIndent = Parent.NextLineIndent.Clone();
		}

		public override void CheckKeywordOnPush(string keyword)
		{
			if (keyword == "endregion")
			{
				DirectiveType = PreProcessorDirective.Endregion;
				ThisLineIndent = Parent.NextLineIndent.Clone();
			}
		}

		public override void CheckKeyword(string keyword)
		{
			if (DirectiveType == PreProcessorDirective.None && preProcessorDirectives.ContainsKey(keyword))
			{
				DirectiveType = preProcessorDirectives[keyword];
				if (DirectiveType == PreProcessorDirective.Region)
				{
					ThisLineIndent = Parent.NextLineIndent.Clone();
				}
				else if (DirectiveType == PreProcessorDirective.If)
				{
					Engine.ifDirectiveIndents.Push(ThisLineIndent.Clone());
				}
			}
		}

		public override IndentState Clone(CSharpIndentEngine engine)
		{
			return new PreProcessorState(this, engine);
		}

		private static bool is_identifier_start_character(int c)
		{
			if ((c < 97 || c > 122) && (c < 65 || c > 90) && c != 95)
			{
				return char.IsLetter((char)c);
			}
			return true;
		}

		private static bool is_identifier_part_character(char c)
		{
			if (c >= 'a' && c <= 'z')
			{
				return true;
			}
			if (c >= 'A' && c <= 'Z')
			{
				return true;
			}
			switch (c)
			{
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
			case '_':
				return true;
			default:
				if (c < '\u0080')
				{
					return false;
				}
				if (!char.IsLetter(c))
				{
					return char.GetUnicodeCategory(c) == UnicodeCategory.ConnectorPunctuation;
				}
				return true;
			}
		}

		private bool eval_val(string s)
		{
			if (s == "true")
			{
				return true;
			}
			if (s == "false")
			{
				return false;
			}
			if (Engine.conditionalSymbols == null || !Engine.conditionalSymbols.Contains(s))
			{
				if (Engine.customConditionalSymbols != null)
				{
					return Engine.customConditionalSymbols.Contains(s);
				}
				return false;
			}
			return true;
		}

		private bool pp_primary(ref string s)
		{
			s = s.Trim();
			int length = s.Length;
			if (length > 0)
			{
				char c = s[0];
				if (c == '(')
				{
					s = s.Substring(1);
					bool result = pp_expr(ref s, isTerm: false);
					if (s.Length > 0 && s[0] == ')')
					{
						s = s.Substring(1);
						return result;
					}
					return false;
				}
				if (is_identifier_start_character(c))
				{
					for (int i = 1; i < length; i++)
					{
						c = s[i];
						if (!is_identifier_part_character(c))
						{
							bool result2 = eval_val(s.Substring(0, i));
							s = s.Substring(i);
							return result2;
						}
					}
					bool result3 = eval_val(s);
					s = "";
					return result3;
				}
			}
			return false;
		}

		private bool pp_unary(ref string s)
		{
			s = s.Trim();
			int length = s.Length;
			if (length > 0)
			{
				if (s[0] == '!')
				{
					if (length > 1 && s[1] == '=')
					{
						return false;
					}
					s = s.Substring(1);
					return !pp_primary(ref s);
				}
				return pp_primary(ref s);
			}
			return false;
		}

		private bool pp_eq(ref string s)
		{
			bool flag = pp_unary(ref s);
			s = s.Trim();
			int length = s.Length;
			if (length > 0)
			{
				if (s[0] == '=')
				{
					if (length > 2 && s[1] == '=')
					{
						s = s.Substring(2);
						return flag == pp_unary(ref s);
					}
					return false;
				}
				if (s[0] == '!' && length > 1 && s[1] == '=')
				{
					s = s.Substring(2);
					return flag != pp_unary(ref s);
				}
			}
			return flag;
		}

		private bool pp_and(ref string s)
		{
			bool flag = pp_eq(ref s);
			s = s.Trim();
			int length = s.Length;
			if (length > 0 && s[0] == '&')
			{
				if (length > 2 && s[1] == '&')
				{
					s = s.Substring(2);
					return flag & pp_and(ref s);
				}
				return false;
			}
			return flag;
		}

		private bool pp_expr(ref string s, bool isTerm)
		{
			bool flag = pp_and(ref s);
			s = s.Trim();
			int length = s.Length;
			if (length > 0)
			{
				if (s[0] == '|')
				{
					if (length > 2 && s[1] == '|')
					{
						s = s.Substring(2);
						return flag | pp_expr(ref s, isTerm);
					}
					return false;
				}
				if (isTerm)
				{
					return false;
				}
			}
			return flag;
		}

		private bool eval(string s)
		{
			bool result = pp_expr(ref s, isTerm: true);
			s = s.Trim();
			if (s.Length != 0)
			{
				return false;
			}
			return result;
		}
	}
}
