using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICSharpCode.NRefactory.CSharp.Completion
{
	public class CSharpCompletionEngineBase
	{
		public class MiniLexer
		{
			private readonly string text;

			public bool IsFistNonWs = true;

			public bool IsInSingleComment;

			public bool IsInString;

			public bool IsInVerbatimString;

			public bool IsInChar;

			public bool IsInMultiLineComment;

			public bool IsInPreprocessorDirective;

			public MiniLexer(string text)
			{
				this.text = text;
			}

			public bool Parse(Func<char, int, bool> act = null)
			{
				return Parse(0, text.Length, act);
			}

			public bool Parse(int start, int length, Func<char, int, bool> act = null)
			{
				for (int i = start; i < length; i++)
				{
					char c = text[i];
					char c2 = (i + 1 < text.Length) ? text[i + 1] : '\0';
					switch (c)
					{
					case '#':
						if (IsFistNonWs)
						{
							IsInPreprocessorDirective = true;
						}
						break;
					case '/':
						if (!IsInString && !IsInChar && !IsInVerbatimString && !IsInSingleComment && !IsInMultiLineComment)
						{
							if (c2 == '/')
							{
								i++;
								IsInSingleComment = true;
								IsInPreprocessorDirective = false;
							}
							if (c2 == '*' && !IsInPreprocessorDirective)
							{
								IsInMultiLineComment = true;
								i++;
							}
						}
						break;
					case '*':
						if (!IsInString && !IsInChar && !IsInVerbatimString && !IsInSingleComment && c2 == '/')
						{
							i++;
							IsInMultiLineComment = false;
						}
						break;
					case '@':
						if (!IsInString && !IsInChar && !IsInVerbatimString && !IsInSingleComment && !IsInMultiLineComment && c2 == '"')
						{
							i++;
							IsInVerbatimString = true;
						}
						break;
					case '\n':
					case '\r':
						IsInSingleComment = false;
						IsInString = false;
						IsInChar = false;
						IsFistNonWs = true;
						IsInPreprocessorDirective = false;
						break;
					case '\\':
						if (IsInString || IsInChar)
						{
							i++;
						}
						break;
					case '"':
						if (IsInSingleComment || IsInMultiLineComment || IsInChar)
						{
							break;
						}
						if (IsInVerbatimString)
						{
							if (c2 == '"')
							{
								i++;
							}
							else
							{
								IsInVerbatimString = false;
							}
						}
						else
						{
							IsInString = !IsInString;
						}
						break;
					case '\'':
						if (!IsInSingleComment && !IsInMultiLineComment && !IsInString && !IsInVerbatimString)
						{
							IsInChar = !IsInChar;
						}
						break;
					}
					if (act != null && act(c, i))
					{
						return true;
					}
					IsFistNonWs &= (c == ' ' || c == '\t' || c == '\n' || c == '\r');
				}
				return false;
			}
		}

		public class ExpressionResult
		{
			public AstNode Node
			{
				get;
				private set;
			}

			public SyntaxTree Unit
			{
				get;
				private set;
			}

			public ExpressionResult(AstNode item2, SyntaxTree item3)
			{
				Node = item2;
				Unit = item3;
			}

			public override string ToString()
			{
				return $"[ExpressionResult: Node={Node}, Unit={Unit}]";
			}
		}

		protected class ExpressionResolveResult
		{
			public ResolveResult Result
			{
				get;
				set;
			}

			public CSharpResolver Resolver
			{
				get;
				set;
			}

			public CSharpAstResolver AstResolver
			{
				get;
				set;
			}

			public ExpressionResolveResult(ResolveResult item1, CSharpResolver item2, CSharpAstResolver item3)
			{
				Result = item1;
				Resolver = item2;
				AstResolver = item3;
			}
		}

		protected IDocument document;

		protected int offset;

		protected TextLocation location;

		protected IUnresolvedTypeDefinition currentType;

		protected IUnresolvedMember currentMember;

		private ICompilation compilation;

		private Version languageVersion = new Version(5, 0);

		private Tuple<string, TextLocation> memberText;

		public CSharpTypeResolveContext ctx
		{
			get;
			private set;
		}

		public IProjectContent ProjectContent
		{
			get;
			private set;
		}

		protected ICompilation Compilation
		{
			get
			{
				if (compilation == null)
				{
					compilation = ProjectContent.Resolve(ctx).Compilation;
				}
				return compilation;
			}
		}

		public Version LanguageVersion
		{
			get
			{
				return languageVersion;
			}
			set
			{
				languageVersion = value;
			}
		}

		public ICompletionContextProvider CompletionContextProvider
		{
			get;
			private set;
		}

		protected CSharpCompletionEngineBase(IProjectContent content, ICompletionContextProvider completionContextProvider, CSharpTypeResolveContext ctx)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			if (ctx == null)
			{
				throw new ArgumentNullException("ctx");
			}
			if (completionContextProvider == null)
			{
				throw new ArgumentNullException("completionContextProvider");
			}
			ProjectContent = content;
			CompletionContextProvider = completionContextProvider;
			this.ctx = ctx;
		}

		public void SetOffset(int offset)
		{
			Reset();
			this.offset = offset;
			location = document.GetLocation(offset);
			CompletionContextProvider.GetCurrentMembers(offset, out currentType, out currentMember);
		}

		public bool GetParameterCompletionCommandOffset(out int cpos)
		{
			cpos = offset - 1;
			IUnresolvedMember unresolvedMember = currentMember;
			if (unresolvedMember == null || unresolvedMember is IType || IsInsideCommentStringOrDirective())
			{
				return false;
			}
			int num = document.GetOffset(unresolvedMember.Region.BeginLine, unresolvedMember.Region.BeginColumn);
			int num2 = 0;
			int num3 = 0;
			Stack<int> stack = new Stack<int>();
			while (cpos > num)
			{
				char charAt = document.GetCharAt(cpos);
				if (charAt == ')')
				{
					num2++;
				}
				if (charAt == '>')
				{
					num3++;
				}
				if (charAt == '}')
				{
					num2 = ((stack.Count > 0) ? stack.Pop() : 0);
					num3 = 0;
				}
				if (stack.Count == 0 && ((num2 == 0 && charAt == '(') || (num3 == 0 && charAt == '<')))
				{
					if (GetCurrentParameterIndex(num, cpos + 1) != -1)
					{
						cpos++;
						return true;
					}
					return false;
				}
				if (charAt == '(')
				{
					num2--;
				}
				if (charAt == '<')
				{
					num3--;
				}
				if (charAt == '{')
				{
					stack.Push(num2);
					num3 = 0;
				}
				cpos--;
			}
			return false;
		}

		public int GetCurrentParameterIndex(int triggerOffset, int endOffset)
		{
			List<string> usedNamedParameters;
			return GetCurrentParameterIndex(triggerOffset, endOffset, out usedNamedParameters);
		}

		public int GetCurrentParameterIndex(int triggerOffset, int endOffset, out List<string> usedNamedParameters)
		{
			usedNamedParameters = new List<string>();
			Stack<int> stack = new Stack<int>();
			Stack<Stack<int>> stack2 = new Stack<Stack<int>>();
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			StringBuilder stringBuilder = new StringBuilder();
			bool flag6 = false;
			for (int i = triggerOffset; i < endOffset; i++)
			{
				char charAt = document.GetCharAt(i);
				char c = (i + 1 < document.TextLength) ? document.GetCharAt(i + 1) : '\0';
				if (charAt == ':')
				{
					usedNamedParameters.Add(stringBuilder.ToString());
					stringBuilder.Length = 0;
				}
				else if (char.IsLetterOrDigit(charAt) || charAt == '_')
				{
					stringBuilder.Append(charAt);
				}
				else if (!char.IsWhiteSpace(charAt))
				{
					stringBuilder.Length = 0;
				}
				if (!char.IsWhiteSpace(charAt) && stack.Count > 0)
				{
					flag6 = true;
				}
				switch (charAt)
				{
				case '{':
					if (!(flag2 | flag4 | flag3 | flag | flag5))
					{
						stack2.Push(stack);
						stack = new Stack<int>();
					}
					break;
				case '(':
				case '[':
					if (!(flag2 | flag4 | flag3 | flag | flag5))
					{
						stack.Push(0);
					}
					break;
				case '}':
					if (!(flag2 | flag4 | flag3 | flag | flag5))
					{
						if (stack2.Count <= 0)
						{
							return -1;
						}
						stack = stack2.Pop();
					}
					break;
				case ')':
				case ']':
					if (!(flag2 | flag4 | flag3 | flag | flag5))
					{
						if (stack.Count <= 0)
						{
							return -1;
						}
						stack.Pop();
					}
					break;
				case '<':
					if (!(flag2 | flag4 | flag3 | flag | flag5))
					{
						stack.Push(0);
					}
					break;
				case '=':
					if (c == '>')
					{
						i++;
					}
					break;
				case '>':
					if (!(flag2 | flag4 | flag3 | flag | flag5) && stack.Count > 0)
					{
						stack.Pop();
					}
					break;
				case ',':
					if (!(flag2 | flag4 | flag3 | flag | flag5) && stack.Count > 0)
					{
						stack.Push(stack.Pop() + 1);
					}
					break;
				case '/':
					if (!(flag2 | flag4 | flag3))
					{
						if (c == '/')
						{
							i++;
							flag = true;
						}
						if (c == '*')
						{
							flag5 = true;
						}
					}
					break;
				case '*':
					if (!(flag2 | flag4 | flag3 | flag) && c == '/')
					{
						i++;
						flag5 = false;
					}
					break;
				case '@':
					if (!(flag2 | flag4 | flag3 | flag | flag5) && c == '"')
					{
						i++;
						flag3 = true;
					}
					break;
				case '\\':
					if (flag2 | flag4)
					{
						i++;
					}
					break;
				case '"':
					if (flag | flag5 | flag4)
					{
						break;
					}
					if (flag3)
					{
						if (c == '"')
						{
							i++;
						}
						else
						{
							flag3 = false;
						}
					}
					else
					{
						flag2 = !flag2;
					}
					break;
				case '\'':
					if (!(flag | flag5 | flag2 | flag3))
					{
						flag4 = !flag4;
					}
					break;
				default:
					if (NewLine.IsNewLine(charAt))
					{
						flag = false;
						flag2 = false;
						flag4 = false;
					}
					break;
				}
			}
			if (stack.Count != 1 || stack2.Count > 0)
			{
				return -1;
			}
			if (!flag6)
			{
				return 0;
			}
			return stack.Pop() + 1;
		}

		protected bool IsInsideCommentStringOrDirective(int offset)
		{
			MiniLexer miniLexer = new MiniLexer(document.Text);
			miniLexer.Parse(0, offset);
			if (!miniLexer.IsInSingleComment && !miniLexer.IsInString && !miniLexer.IsInVerbatimString && !miniLexer.IsInChar && !miniLexer.IsInMultiLineComment)
			{
				return miniLexer.IsInPreprocessorDirective;
			}
			return true;
		}

		protected bool IsInsideCommentStringOrDirective()
		{
			MiniLexer miniLexer = new MiniLexer(GetMemberTextToCaret().Item1);
			miniLexer.Parse();
			if (!miniLexer.IsInSingleComment && !miniLexer.IsInString && !miniLexer.IsInVerbatimString && !miniLexer.IsInChar && !miniLexer.IsInMultiLineComment)
			{
				return miniLexer.IsInPreprocessorDirective;
			}
			return true;
		}

		protected bool IsInsideDocComment()
		{
			Tuple<string, TextLocation> memberTextToCaret = GetMemberTextToCaret();
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			for (int i = 0; i < memberTextToCaret.Item1.Length - 1; i++)
			{
				char c = memberTextToCaret.Item1[i];
				char c2 = memberTextToCaret.Item1[i + 1];
				switch (c)
				{
				case '/':
					if (flag2 | flag4 | flag3)
					{
						break;
					}
					if (c2 == '/')
					{
						i++;
						flag = true;
						flag6 = (i + 1 < memberTextToCaret.Item1.Length && memberTextToCaret.Item1[i + 1] == '/');
						if (flag6)
						{
							i++;
						}
					}
					if (c2 == '*')
					{
						flag5 = true;
					}
					break;
				case '*':
					if (!(flag2 | flag4 | flag3 | flag) && c2 == '/')
					{
						i++;
						flag5 = false;
					}
					break;
				case '@':
					if (!(flag2 | flag4 | flag3 | flag | flag5) && c2 == '"')
					{
						i++;
						flag3 = true;
					}
					break;
				case '\n':
				case '\r':
					flag = false;
					flag2 = false;
					flag4 = false;
					break;
				case '\\':
					if (flag2 | flag4)
					{
						i++;
					}
					break;
				case '"':
					if (flag | flag5 | flag4)
					{
						break;
					}
					if (flag3)
					{
						if (c2 == '"')
						{
							i++;
						}
						else
						{
							flag3 = false;
						}
					}
					else
					{
						flag2 = !flag2;
					}
					break;
				case '\'':
					if (!(flag | flag5 | flag2 | flag3))
					{
						flag4 = !flag4;
					}
					break;
				}
			}
			return flag && flag6;
		}

		protected CSharpResolver GetState()
		{
			return new CSharpResolver(ctx);
		}

		private static Stack<Tuple<char, int>> GetBracketStack(string memberText)
		{
			Stack<Tuple<char, int>> stack = new Stack<Tuple<char, int>>();
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			for (int i = 0; i < memberText.Length; i++)
			{
				char c = memberText[i];
				char c2 = (i + 1 < memberText.Length) ? memberText[i + 1] : '\0';
				switch (c)
				{
				case '(':
				case '[':
				case '{':
					if (!(flag2 | flag4 | flag3 | flag | flag5))
					{
						stack.Push(Tuple.Create(c, i));
					}
					break;
				case ')':
				case ']':
				case '}':
					if (!(flag2 | flag4 | flag3 | flag | flag5) && stack.Count > 0)
					{
						stack.Pop();
					}
					break;
				case '/':
					if (!(flag2 | flag4 | flag3))
					{
						if (c2 == '/')
						{
							i++;
							flag = true;
						}
						if (c2 == '*')
						{
							flag5 = true;
						}
					}
					break;
				case '*':
					if (!(flag2 | flag4 | flag3 | flag) && c2 == '/')
					{
						i++;
						flag5 = false;
					}
					break;
				case '@':
					if (!(flag2 | flag4 | flag3 | flag | flag5) && c2 == '"')
					{
						i++;
						flag3 = true;
					}
					break;
				case '\\':
					if (flag2 | flag4)
					{
						i++;
					}
					break;
				case '"':
					if (flag | flag5 | flag4)
					{
						break;
					}
					if (flag3)
					{
						if (c2 == '"')
						{
							i++;
						}
						else
						{
							flag3 = false;
						}
					}
					else
					{
						flag2 = !flag2;
					}
					break;
				case '\'':
					if (!(flag | flag5 | flag2 | flag3))
					{
						flag4 = !flag4;
					}
					break;
				default:
					if (NewLine.IsNewLine(c))
					{
						flag = false;
						flag2 = false;
						flag4 = false;
					}
					break;
				}
			}
			return stack;
		}

		public static void AppendMissingClosingBrackets(StringBuilder wrapper, bool appendSemicolon)
		{
			string text = wrapper.ToString();
			Stack<Tuple<char, int>> bracketStack = GetBracketStack(text);
			bool flag = !appendSemicolon;
			while (bracketStack.Count > 0)
			{
				Tuple<char, int> tuple = bracketStack.Pop();
				switch (tuple.Item1)
				{
				case '(':
					wrapper.Append(')');
					if (appendSemicolon)
					{
						flag = false;
					}
					break;
				case '[':
					wrapper.Append(']');
					if (appendSemicolon)
					{
						flag = false;
					}
					break;
				case '<':
					wrapper.Append('>');
					if (appendSemicolon)
					{
						flag = false;
					}
					break;
				case '{':
				{
					int num = tuple.Item2 - 1;
					if (!flag)
					{
						flag = true;
						wrapper.Append(';');
					}
					bool flag2 = false;
					while (num >= "try".Length)
					{
						char c = text[num];
						if (!char.IsWhiteSpace(c))
						{
							if (c == 'y' && text[num - 1] == 'r' && text[num - 2] == 't' && (num - 3 < 0 || !char.IsLetterOrDigit(text[num - 3])))
							{
								wrapper.Append("} catch {}");
								flag2 = true;
							}
							break;
						}
						num--;
					}
					if (!flag2)
					{
						wrapper.Append('}');
					}
					break;
				}
				}
			}
			if (!flag)
			{
				wrapper.Append(';');
			}
		}

		protected StringBuilder CreateWrapper(string continuation, bool appendSemicolon, string afterContinuation, string memberText, TextLocation memberLocation, ref int closingBrackets, ref int generatedLines)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (memberLocation != new TextLocation(1, 1))
			{
				stringBuilder.Append("class Stub {");
				stringBuilder.AppendLine();
				closingBrackets++;
				generatedLines++;
			}
			stringBuilder.Append(memberText);
			stringBuilder.Append(continuation);
			AppendMissingClosingBrackets(stringBuilder, appendSemicolon);
			stringBuilder.Append(afterContinuation);
			if (closingBrackets > 0)
			{
				stringBuilder.Append(new string('}', closingBrackets));
			}
			return stringBuilder;
		}

		protected SyntaxTree ParseStub(string continuation, bool appendSemicolon = true, string afterContinuation = null)
		{
			Tuple<string, TextLocation> memberTextToCaret = GetMemberTextToCaret();
			if (memberTextToCaret == null)
			{
				return null;
			}
			string item = memberTextToCaret.Item1;
			TextLocation item2 = memberTextToCaret.Item2;
			int closingBrackets = 1;
			int generatedLines = 0;
			StringBuilder stringBuilder = CreateWrapper(continuation, appendSemicolon, afterContinuation, item, item2, ref closingBrackets, ref generatedLines);
			CSharpParser cSharpParser = new CSharpParser();
			foreach (string conditionalSymbol in CompletionContextProvider.ConditionalSymbols)
			{
				cSharpParser.CompilerSettings.ConditionalSymbols.Add(conditionalSymbol);
			}
			cSharpParser.InitialLocation = new TextLocation(item2.Line - generatedLines, 1);
			return cSharpParser.Parse(stringBuilder.ToString());
		}

		protected virtual void Reset()
		{
			memberText = null;
		}

		protected Tuple<string, TextLocation> GetMemberTextToCaret()
		{
			if (memberText == null)
			{
				memberText = CompletionContextProvider.GetMemberTextToCaret(offset, currentType, currentMember);
			}
			return memberText;
		}

		protected ExpressionResult GetInvocationBeforeCursor(bool afterBracket)
		{
			SyntaxTree syntaxTree = ParseStub("a", appendSemicolon: false);
			Attribute attribute = syntaxTree.GetNodeAt<AttributeSection>(location.Line, location.Column - 2)?.Attributes.LastOrDefault();
			if (attribute != null)
			{
				return new ExpressionResult(attribute, syntaxTree);
			}
			AstNode nodeAt = syntaxTree.GetNodeAt(location.Line, location.Column - 1, (AstNode n) => (!(n is InvocationExpression)) ? (n is ObjectCreateExpression) : true);
			AstNode astNode = null;
			if (nodeAt is InvocationExpression)
			{
				astNode = ((InvocationExpression)nodeAt).Target;
			}
			else if (nodeAt is ObjectCreateExpression)
			{
				astNode = nodeAt;
			}
			else
			{
				syntaxTree = ParseStub(")};", appendSemicolon: false);
				nodeAt = syntaxTree.GetNodeAt(location.Line, location.Column - 1, (AstNode n) => (!(n is InvocationExpression)) ? (n is ObjectCreateExpression) : true);
				if (nodeAt is InvocationExpression)
				{
					astNode = ((InvocationExpression)nodeAt).Target;
				}
				else if (nodeAt is ObjectCreateExpression)
				{
					astNode = nodeAt;
				}
			}
			if (astNode == null)
			{
				syntaxTree = ParseStub("a");
				attribute = syntaxTree.GetNodeAt<AttributeSection>(location.Line, location.Column - 2)?.Attributes.LastOrDefault();
				if (attribute != null)
				{
					return new ExpressionResult(attribute, syntaxTree);
				}
				nodeAt = syntaxTree.GetNodeAt(location.Line, location.Column - 1, (AstNode n) => (!(n is InvocationExpression)) ? (n is ObjectCreateExpression) : true);
				astNode = null;
				if (nodeAt is InvocationExpression)
				{
					astNode = ((InvocationExpression)nodeAt).Target;
				}
				else if (nodeAt is ObjectCreateExpression)
				{
					astNode = nodeAt;
				}
			}
			if (astNode == null)
			{
				return null;
			}
			return new ExpressionResult(astNode, syntaxTree);
		}

		protected ExpressionResolveResult ResolveExpression(ExpressionResult tuple)
		{
			return ResolveExpression(tuple.Node);
		}

		protected ExpressionResolveResult ResolveExpression(AstNode expr)
		{
			if (expr == null)
			{
				return null;
			}
			AstNode node = (expr is Expression || expr is AstType) ? expr : ((!(expr is VariableDeclarationStatement)) ? expr : ((VariableDeclarationStatement)expr).Type);
			try
			{
				AstNode astNode = expr.AncestorsAndSelf.FirstOrDefault((AstNode n) => (!(n is EntityDeclaration)) ? (n is SyntaxTree) : true);
				if (astNode == null)
				{
					return null;
				}
				CSharpResolver cSharpResolver = GetState();
				if (astNode is Accessor)
				{
					IProperty property = cSharpResolver.CurrentMember as IProperty;
					if (property != null && property.CanSet && (astNode.Role == IndexerDeclaration.SetterRole || astNode.Role == PropertyDeclaration.SetterRole))
					{
						cSharpResolver = cSharpResolver.WithCurrentMember(property.Setter);
					}
				}
				AstNode astNode2 = astNode.Children.FirstOrDefault((AstNode r) => r.Role == Roles.Body);
				if (astNode2 != null && astNode2.Contains(expr.StartLocation))
				{
					astNode = astNode2;
				}
				CSharpAstResolver resolver = CompletionContextProvider.GetResolver(cSharpResolver, astNode);
				ResolveResult item = resolver.Resolve(node);
				CSharpResolver cSharpResolver2 = resolver.GetResolverStateBefore(node);
				if (cSharpResolver2.CurrentMember == null)
				{
					cSharpResolver2 = cSharpResolver2.WithCurrentMember(cSharpResolver.CurrentMember);
				}
				if (cSharpResolver2.CurrentTypeDefinition == null)
				{
					cSharpResolver2 = cSharpResolver2.WithCurrentTypeDefinition(cSharpResolver.CurrentTypeDefinition);
				}
				if (cSharpResolver2.CurrentUsingScope == null)
				{
					cSharpResolver2 = cSharpResolver2.WithCurrentUsingScope(cSharpResolver.CurrentUsingScope);
				}
				return new ExpressionResolveResult(item, cSharpResolver2, resolver);
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
				return null;
			}
		}
	}
}
