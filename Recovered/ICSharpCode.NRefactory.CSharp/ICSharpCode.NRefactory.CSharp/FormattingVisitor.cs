using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class FormattingVisitor : DepthFirstAstVisitor
	{
		private readonly CSharpFormatter formatter;

		private readonly FormattingChanges changes;

		private readonly IDocument document;

		private readonly CancellationToken token;

		private Indent curIndent;

		private string nextStatementIndent;

		public bool HadErrors
		{
			get;
			set;
		}

		private CSharpFormattingOptions policy => formatter.Policy;

		private TextEditorOptions options => formatter.TextEditorOptions;

		private FormattingChanges.TextReplaceAction AddChange(int offset, int removedChars, string insertedText)
		{
			return changes.AddChange(offset, removedChars, insertedText);
		}

		public FormattingVisitor(CSharpFormatter formatter, IDocument document, FormattingChanges changes, CancellationToken token)
		{
			if (formatter == null)
			{
				throw new ArgumentNullException("formatter");
			}
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			if (changes == null)
			{
				throw new ArgumentNullException("changes");
			}
			this.formatter = formatter;
			this.changes = changes;
			this.document = document;
			this.token = token;
			curIndent = new Indent(formatter.TextEditorOptions);
		}

		private void VisitChildrenToFormat(AstNode parent, Action<AstNode> callback)
		{
			AstNode child;
			AstNode nextSibling;
			for (child = parent.FirstChild; child != null; child = nextSibling)
			{
				token.ThrowIfCancellationRequested();
				nextSibling = child.GetNextSibling(NoWhitespacePredicate);
				if (formatter.FormattingRegions.Count > 0)
				{
					if (formatter.FormattingRegions.Any((DomRegion r) => (!r.IsInside(child.StartLocation)) ? r.IsInside(child.EndLocation) : true))
					{
						callback(child);
					}
					else
					{
						DomRegion childRegion = child.Region;
						if (formatter.FormattingRegions.Any((DomRegion r) => (!childRegion.IsInside(r.Begin)) ? childRegion.IsInside(r.End) : true))
						{
							callback(child);
						}
					}
					if (child.StartLocation > formatter.lastFormattingLocation)
					{
						break;
					}
				}
				else
				{
					callback(child);
				}
			}
		}

		protected override void VisitChildren(AstNode node)
		{
			VisitChildrenToFormat(node, delegate(AstNode n)
			{
				n.AcceptVisitor(this);
			});
		}

		private void AdjustNewLineBlock(AstNode startNode, int targetMinimumNewLineCount)
		{
			string text = (policy.EmptyLineFormatting == EmptyLineFormatting.Indent) ? curIndent.IndentString : "";
			TextLocation endLocation = startNode.EndLocation;
			AstNode nextSibling = startNode.NextSibling;
			int i = 0;
			while (i < targetMinimumNewLineCount)
			{
				if (!(nextSibling is WhitespaceNode))
				{
					if (!(nextSibling is NewLineNode))
					{
						break;
					}
					endLocation = nextSibling.EndLocation;
					i++;
					if (policy.EmptyLineFormatting == EmptyLineFormatting.DoNotChange)
					{
						if (nextSibling.NextSibling == null)
						{
							break;
						}
					}
					else
					{
						if (!IsSpacing(document.GetLineByNumber(nextSibling.StartLocation.Line)))
						{
							if (policy.RemoveEndOfLineWhiteSpace)
							{
								int offset = document.GetOffset(nextSibling.StartLocation);
								int num = SearchWhitespaceStart(offset);
								if (num != offset)
								{
									AddChange(num, offset - num, null);
								}
							}
						}
						else
						{
							string indentation = GetIndentation(nextSibling.StartLocation.Line);
							if (indentation != text)
							{
								int offset2 = document.GetOffset(new TextLocation(nextSibling.StartLocation.Line, 0));
								AddChange(offset2, indentation.Length, text);
							}
						}
						if (nextSibling.NextSibling == null)
						{
							break;
						}
					}
				}
				nextSibling = nextSibling.NextSibling;
			}
			if (i < targetMinimumNewLineCount)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (; i < targetMinimumNewLineCount; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(text);
					}
					stringBuilder.Append(options.EolMarker);
				}
				int offset3 = document.GetOffset(endLocation);
				if (offset3 >= 0)
				{
					AddChange(offset3, 0, stringBuilder.ToString());
				}
			}
			else if (i == targetMinimumNewLineCount)
			{
			}
		}

		public void EnsureMinimumNewLinesAfter(AstNode node, int blankLines)
		{
			if ((!(node is PreProcessorDirective) || ((PreProcessorDirective)node).Type != PreProcessorDirectiveType.Pragma) && blankLines >= 0)
			{
				if (formatter.FormattingMode != FormattingMode.Intrusive)
				{
					blankLines = Math.Min(1, blankLines);
				}
				AdjustNewLineBlock(node, blankLines);
			}
		}

		public void EnsureMinimumBlankLinesBefore(AstNode node, int blankLines)
		{
			if (formatter.FormattingMode != FormattingMode.Intrusive)
			{
				return;
			}
			TextLocation startLocation = node.StartLocation;
			int num = startLocation.Line;
			do
			{
				num--;
			}
			while (num > 0 && IsSpacing(document.GetLineByNumber(num)));
			if (num > 0 && !IsSpacing(document.GetLineByNumber(num)))
			{
				num++;
			}
			if (startLocation.Line - num >= blankLines)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < blankLines; i++)
			{
				stringBuilder.Append(options.EolMarker);
			}
			int offset = document.GetOffset(startLocation.Line, 1);
			if (startLocation.Line == num)
			{
				AddChange(offset, 0, stringBuilder.ToString());
			}
			else if (num + 1 <= document.LineCount)
			{
				int offset2 = document.GetOffset(num + 1, 1);
				if (offset - offset2 > 0 || stringBuilder.Length != 0)
				{
					AddChange(offset2, offset - offset2, stringBuilder.ToString());
				}
			}
		}

		private bool IsSimpleAccessor(Accessor accessor)
		{
			if (accessor.IsNull || accessor.Body.IsNull || accessor.Body.FirstChild == null)
			{
				return true;
			}
			Statement statement = accessor.Body.Statements.FirstOrDefault();
			if (statement == null)
			{
				return true;
			}
			if (!(statement is ReturnStatement) && !(statement is ExpressionStatement) && !(statement is EmptyStatement) && !(statement is ThrowStatement))
			{
				return false;
			}
			if (statement.GetNextSibling((AstNode s) => s.Role == BlockStatement.StatementRole) != null)
			{
				return false;
			}
			return !(accessor.Body.Statements.FirstOrDefault() is BlockStatement);
		}

		private static bool IsSpacing(char ch)
		{
			if (ch != ' ')
			{
				return ch == '\t';
			}
			return true;
		}

		private bool IsSpacing(ISegment segment)
		{
			int endOffset = segment.EndOffset;
			for (int i = segment.Offset; i < endOffset; i++)
			{
				if (!IsSpacing(document.GetCharAt(i)))
				{
					return false;
				}
			}
			return true;
		}

		private int SearchLastNonWsChar(int startOffset, int endOffset)
		{
			startOffset = Math.Max(0, startOffset);
			endOffset = Math.Max(startOffset, endOffset);
			if (startOffset >= endOffset)
			{
				return startOffset;
			}
			int result = -1;
			bool flag = false;
			for (int i = startOffset; i < endOffset && i < document.TextLength; i++)
			{
				char charAt = document.GetCharAt(i);
				if (!IsSpacing(charAt))
				{
					if (charAt == '/' && i + 1 < document.TextLength && document.GetCharAt(i + 1) == '/')
					{
						return result;
					}
					if (charAt == '/' && i + 1 < document.TextLength && document.GetCharAt(i + 1) == '*')
					{
						flag = true;
						i++;
					}
					else if (flag && charAt == '*' && i + 1 < document.TextLength && document.GetCharAt(i + 1) == '/')
					{
						flag = false;
						i++;
					}
					else if (!flag)
					{
						result = i;
					}
				}
			}
			return result;
		}

		private void ForceSpace(int startOffset, int endOffset, bool forceSpace)
		{
			int num = SearchLastNonWsChar(startOffset, endOffset);
			if (num < 0)
			{
				return;
			}
			int num2 = Math.Max(0, endOffset - num - 1);
			if (forceSpace)
			{
				if (num2 != 1)
				{
					AddChange(num + 1, num2, " ");
				}
			}
			else if (num2 > 0 && !forceSpace)
			{
				AddChange(num + 1, num2, "");
			}
		}

		private void ForceSpacesAfter(AstNode n, bool forceSpaces)
		{
			if (n == null)
			{
				return;
			}
			TextLocation endLocation = n.EndLocation;
			int offset = document.GetOffset(endLocation);
			if (endLocation.Column <= document.GetLineByNumber(endLocation.Line).Length)
			{
				int i;
				for (i = offset; i < document.TextLength && IsSpacing(document.GetCharAt(i)); i++)
				{
				}
				ForceSpace(offset - 1, i, forceSpaces);
			}
		}

		private int ForceSpacesBefore(AstNode n, bool forceSpaces)
		{
			if (n == null || n.IsNull)
			{
				return 0;
			}
			TextLocation startLocation = n.StartLocation;
			if (startLocation.Column <= 1 || GetIndentation(startLocation.Line).Length == startLocation.Column - 1)
			{
				return 0;
			}
			int offset = document.GetOffset(startLocation);
			int num = offset - 1;
			while (num >= 0 && IsSpacing(document.GetCharAt(num)))
			{
				num--;
			}
			ForceSpace(num, offset, forceSpaces);
			return num;
		}

		private int ForceSpacesBeforeRemoveNewLines(AstNode n, bool forceSpace = true)
		{
			if (n == null || n.IsNull)
			{
				return 0;
			}
			int offset = document.GetOffset(n.StartLocation);
			int num;
			for (num = offset - 1; num >= 0; num--)
			{
				char charAt = document.GetCharAt(num);
				if (!IsSpacing(charAt) && charAt != '\r' && charAt != '\n')
				{
					break;
				}
			}
			int removedChars = Math.Max(0, offset - 1 - num);
			AddChange(num + 1, removedChars, forceSpace ? " " : "");
			return num;
		}

		internal static bool NoWhitespacePredicate(AstNode arg)
		{
			if (!(arg is NewLineNode))
			{
				return !(arg is WhitespaceNode);
			}
			return false;
		}

		private static bool IsMember(AstNode nextSibling)
		{
			if (nextSibling != null)
			{
				return nextSibling.NodeType == NodeType.Member;
			}
			return false;
		}

		private static bool ShouldBreakLine(NewLinePlacement placement, CSharpTokenNode token)
		{
			switch (placement)
			{
			case NewLinePlacement.NewLine:
				return true;
			case NewLinePlacement.SameLine:
				return false;
			default:
				if (token.IsNull)
				{
					return false;
				}
				return token.GetPrevNode((AstNode n) => n.Role != Roles.NewLine && n.Role != Roles.Whitespace && n.Role != Roles.Comment).EndLocation.Line != token.StartLocation.Line;
			}
		}

		private void ForceSpaceBefore(AstNode node, bool forceSpace)
		{
			int offset = document.GetOffset(node.StartLocation);
			int endOffset = offset;
			int startOffset = SearchWhitespaceStart(offset - 1);
			ForceSpace(startOffset, endOffset, forceSpace);
		}

		public void FixSemicolon(CSharpTokenNode semicolon)
		{
			if (!semicolon.IsNull)
			{
				int offset = document.GetOffset(semicolon.StartLocation);
				int num = offset;
				while (num - 1 > 0 && char.IsWhiteSpace(document.GetCharAt(num - 1)))
				{
					num--;
				}
				if (policy.SpaceBeforeSemicolon)
				{
					AddChange(num, offset - num, " ");
				}
				else if (num < offset)
				{
					AddChange(num, offset - num, null);
				}
			}
		}

		private void PlaceOnNewLine(NewLinePlacement newLine, AstNode keywordNode)
		{
			if (keywordNode == null || keywordNode.StartLocation.IsEmpty)
			{
				return;
			}
			AstNode prevNode = keywordNode.GetPrevNode(NoWhitespacePredicate);
			if (!(prevNode is Comment) && !(prevNode is PreProcessorDirective))
			{
				if (newLine == NewLinePlacement.DoNotCare)
				{
					newLine = ((prevNode.EndLocation.Line != keywordNode.StartLocation.Line) ? NewLinePlacement.NewLine : NewLinePlacement.SameLine);
				}
				int offset = document.GetOffset(keywordNode.StartLocation);
				int num = SearchWhitespaceStart(offset);
				string insertedText = (newLine == NewLinePlacement.NewLine) ? (options.EolMarker + curIndent.IndentString) : " ";
				AddChange(num, offset - num, insertedText);
			}
		}

		private void FixStatementIndentation(TextLocation location)
		{
			if (location.Line < 1 || location.Column < 1)
			{
				Console.WriteLine("invalid location!");
				return;
			}
			int offset = document.GetOffset(location);
			if (offset <= 0)
			{
				Console.WriteLine("possible wrong offset");
				Console.WriteLine(Environment.StackTrace);
				return;
			}
			bool flag = IsLineIsEmptyUpToEol(offset);
			int start = SearchWhitespaceLineStart(offset);
			string replacementText = nextStatementIndent ?? ((flag ? "" : options.EolMarker) + curIndent.IndentString);
			nextStatementIndent = null;
			EnsureText(start, offset, replacementText);
		}

		private void FixIndentation(AstNode node)
		{
			FixIndentation(node.StartLocation, 0);
		}

		private void FixIndentation(TextLocation location, int relOffset)
		{
			if (location.Line < 1 || location.Line > document.LineCount)
			{
				Console.WriteLine("Invalid location " + location);
				Console.WriteLine(Environment.StackTrace);
				return;
			}
			string indentation = GetIndentation(location.Line);
			string indentString = curIndent.IndentString;
			if (indentString != indentation && location.Column - 1 + relOffset == indentation.Length)
			{
				AddChange(document.GetOffset(location.Line, 1), indentation.Length, indentString);
			}
		}

		private void FixIndentationForceNewLine(AstNode node)
		{
			PreProcessorDirective preProcessorDirective = node as PreProcessorDirective;
			if (node.GetPrevNode() is NewLineNode)
			{
				if (preProcessorDirective != null && !policy.IndentPreprocessorDirectives)
				{
					AstNode prevNode = node.GetPrevNode();
					int offset = document.GetOffset(prevNode.EndLocation);
					int offset2 = document.GetOffset(node.StartLocation);
					AddChange(offset, offset2 - offset, "");
				}
				else
				{
					FixIndentation(node);
				}
			}
			else
			{
				if (preProcessorDirective != null && preProcessorDirective.Type == PreProcessorDirectiveType.Endif)
				{
					return;
				}
				AstNode astNode = node.GetPrevSibling((AstNode n) => !(n is WhitespaceNode)) ?? node;
				int offset3 = document.GetOffset(astNode.EndLocation);
				int offset4 = document.GetOffset(node.StartLocation);
				if (offset3 < offset4)
				{
					if (preProcessorDirective != null && !policy.IndentPreprocessorDirectives)
					{
						AddChange(offset3, offset4 - offset3, "");
					}
					else
					{
						AddChange(offset3, offset4 - offset3, curIndent.IndentString);
					}
				}
			}
		}

		private string GetIndentation(int lineNumber)
		{
			IDocumentLine lineByNumber = document.GetLineByNumber(lineNumber);
			StringBuilder stringBuilder = new StringBuilder();
			int endOffset = lineByNumber.EndOffset;
			for (int i = lineByNumber.Offset; i < endOffset; i++)
			{
				char charAt = document.GetCharAt(i);
				if (!IsSpacing(charAt))
				{
					break;
				}
				stringBuilder.Append(charAt);
			}
			return stringBuilder.ToString();
		}

		private void EnsureText(int start, int end, string replacementText)
		{
			int num = end - start;
			if (num == 0 && string.IsNullOrEmpty(replacementText))
			{
				return;
			}
			if (replacementText == null || replacementText.Length != num)
			{
				AddChange(start, num, replacementText);
				return;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < num)
				{
					if (document.GetCharAt(start + num2) != replacementText[num2])
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			AddChange(start, num, replacementText);
		}

		private void FixOpenBrace(BraceStyle braceStyle, AstNode lbrace)
		{
			if (lbrace.IsNull)
			{
				return;
			}
			switch (braceStyle)
			{
			case BraceStyle.DoNotChange:
				break;
			case BraceStyle.EndOfLine:
			case BraceStyle.BannerStyle:
			{
				AstNode prevNode = lbrace.GetPrevNode(NoWhitespacePredicate);
				if (prevNode is PreProcessorDirective)
				{
					break;
				}
				int offset = document.GetOffset(prevNode.EndLocation);
				if (prevNode is Comment || prevNode is PreProcessorDirective)
				{
					int offset3 = document.GetOffset(lbrace.GetNextNode().StartLocation);
					EnsureText(offset, offset3, "");
					while (prevNode is Comment || prevNode is PreProcessorDirective)
					{
						prevNode = prevNode.GetPrevNode();
					}
					offset = document.GetOffset(prevNode.EndLocation);
					AddChange(offset, 0, " {");
				}
				else
				{
					int offset4 = document.GetOffset(lbrace.StartLocation);
					EnsureText(offset, offset4, " ");
				}
				break;
			}
			case BraceStyle.EndOfLineWithoutSpace:
			{
				AstNode prevNode = lbrace.GetPrevNode(NoWhitespacePredicate);
				if (!(prevNode is PreProcessorDirective))
				{
					int offset = document.GetOffset(prevNode.EndLocation);
					int offset2 = document.GetOffset(lbrace.StartLocation);
					EnsureText(offset, offset2, "");
				}
				break;
			}
			case BraceStyle.NextLine:
			{
				AstNode prevNode = lbrace.GetPrevNode(NoWhitespacePredicate);
				if (!(prevNode is PreProcessorDirective))
				{
					int offset = document.GetOffset(prevNode.EndLocation);
					int offset2 = document.GetOffset(lbrace.StartLocation);
					EnsureText(offset, offset2, options.EolMarker + curIndent.IndentString);
				}
				break;
			}
			case BraceStyle.NextLineShifted:
			{
				AstNode prevNode = lbrace.GetPrevNode(NoWhitespacePredicate);
				if (!(prevNode is PreProcessorDirective))
				{
					int offset = document.GetOffset(prevNode.EndLocation);
					int offset2 = document.GetOffset(lbrace.StartLocation);
					curIndent.Push(IndentType.Block);
					EnsureText(offset, offset2, options.EolMarker + curIndent.IndentString);
					curIndent.Pop();
				}
				break;
			}
			case BraceStyle.NextLineShifted2:
			{
				AstNode prevNode = lbrace.GetPrevNode(NoWhitespacePredicate);
				if (!(prevNode is PreProcessorDirective))
				{
					int offset = document.GetOffset(prevNode.EndLocation);
					int offset2 = document.GetOffset(lbrace.StartLocation);
					curIndent.Push(IndentType.Block);
					EnsureText(offset, offset2, options.EolMarker + curIndent.IndentString);
					curIndent.Pop();
				}
				break;
			}
			}
		}

		private void CorrectClosingBrace(AstNode rbrace)
		{
			if (!rbrace.IsNull)
			{
				int offset = document.GetOffset(rbrace.StartLocation);
				AstNode prevNode = rbrace.GetPrevNode();
				int start = (prevNode != null) ? document.GetOffset(prevNode.EndLocation) : 0;
				if (prevNode is NewLineNode)
				{
					EnsureText(start, offset, curIndent.IndentString);
				}
				else
				{
					EnsureText(start, offset, options.EolMarker + curIndent.IndentString);
				}
			}
		}

		private void FixClosingBrace(BraceStyle braceStyle, AstNode rbrace)
		{
			if (!rbrace.IsNull)
			{
				switch (braceStyle)
				{
				case BraceStyle.DoNotChange:
					break;
				case BraceStyle.NextLineShifted:
				case BraceStyle.BannerStyle:
					curIndent.Push(IndentType.Block);
					CorrectClosingBrace(rbrace);
					curIndent.Pop();
					break;
				case BraceStyle.EndOfLine:
				case BraceStyle.EndOfLineWithoutSpace:
				case BraceStyle.NextLine:
					CorrectClosingBrace(rbrace);
					break;
				case BraceStyle.NextLineShifted2:
					curIndent.Push(IndentType.Block);
					CorrectClosingBrace(rbrace);
					curIndent.Pop();
					break;
				}
			}
		}

		public override void VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
		{
			FixAttributesAndDocComment(propertyDeclaration);
			bool oneLine = false;
			bool flag = false;
			switch (((!propertyDeclaration.Getter.IsNull && !propertyDeclaration.Getter.Body.IsNull) || (!propertyDeclaration.Setter.IsNull && !propertyDeclaration.Setter.Body.IsNull)) ? policy.SimplePropertyFormatting : policy.AutoPropertyFormatting)
			{
			case PropertyFormatting.AllowOneLine:
			{
				bool flag2 = IsSimpleAccessor(propertyDeclaration.Getter) && IsSimpleAccessor(propertyDeclaration.Setter);
				int line = propertyDeclaration.RBraceToken.StartLocation.Line;
				line = ((!propertyDeclaration.Getter.IsNull && propertyDeclaration.Setter.IsNull) ? propertyDeclaration.Getter.StartLocation.Line : ((!propertyDeclaration.Getter.IsNull || propertyDeclaration.Setter.IsNull) ? ((propertyDeclaration.Getter.StartLocation < propertyDeclaration.Setter.StartLocation) ? propertyDeclaration.Getter : propertyDeclaration.Setter).StartLocation.Line : propertyDeclaration.Setter.StartLocation.Line));
				if (!flag2 || Math.Min(propertyDeclaration.Getter.StartLocation.Line, propertyDeclaration.Setter.StartLocation.Line) != propertyDeclaration.LBraceToken.StartLocation.Line || propertyDeclaration.Getter.StartLocation.Line == propertyDeclaration.Setter.StartLocation.Line)
				{
					if (!flag2 || propertyDeclaration.LBraceToken.StartLocation.Line != line)
					{
						flag = true;
						FixOpenBrace(policy.PropertyBraceStyle, propertyDeclaration.LBraceToken);
						break;
					}
					ForceSpacesBefore(propertyDeclaration.Getter, forceSpaces: true);
					ForceSpacesBefore(propertyDeclaration.Setter, forceSpaces: true);
					ForceSpacesBeforeRemoveNewLines(propertyDeclaration.RBraceToken);
					oneLine = true;
					break;
				}
				goto case PropertyFormatting.ForceOneLine;
			}
			case PropertyFormatting.ForceNewLine:
				flag = true;
				FixOpenBrace(policy.PropertyBraceStyle, propertyDeclaration.LBraceToken);
				break;
			case PropertyFormatting.ForceOneLine:
				if (IsSimpleAccessor(propertyDeclaration.Getter) && IsSimpleAccessor(propertyDeclaration.Setter))
				{
					CSharpTokenNode lBraceToken = propertyDeclaration.LBraceToken;
					CSharpTokenNode rBraceToken = propertyDeclaration.RBraceToken;
					ForceSpacesBeforeRemoveNewLines(lBraceToken);
					if (!propertyDeclaration.Getter.IsNull)
					{
						ForceSpacesBeforeRemoveNewLines(propertyDeclaration.Getter);
					}
					if (!propertyDeclaration.Setter.IsNull)
					{
						ForceSpacesBeforeRemoveNewLines(propertyDeclaration.Setter);
					}
					ForceSpacesBeforeRemoveNewLines(rBraceToken);
					oneLine = true;
				}
				else
				{
					flag = true;
					FixOpenBrace(policy.PropertyBraceStyle, propertyDeclaration.LBraceToken);
				}
				break;
			}
			if (policy.IndentPropertyBody)
			{
				curIndent.Push(IndentType.Block);
			}
			FormatAccessor(propertyDeclaration.Getter, policy.PropertyGetBraceStyle, policy.SimpleGetBlockFormatting, oneLine);
			FormatAccessor(propertyDeclaration.Setter, policy.PropertySetBraceStyle, policy.SimpleSetBlockFormatting, oneLine);
			if (policy.IndentPropertyBody)
			{
				curIndent.Pop();
			}
			if (flag)
			{
				FixClosingBrace(policy.PropertyBraceStyle, propertyDeclaration.RBraceToken);
			}
		}

		private void FormatAccessor(Accessor accessor, BraceStyle braceStyle, PropertyFormatting blockFormatting, bool oneLine)
		{
			if (accessor.IsNull)
			{
				return;
			}
			if (!oneLine)
			{
				if (!IsLineIsEmptyUpToEol(accessor.StartLocation))
				{
					int offset = document.GetOffset(accessor.StartLocation);
					int num = SearchWhitespaceStart(offset);
					string indentString = curIndent.IndentString;
					AddChange(num, offset - num, options.EolMarker + indentString);
				}
				else
				{
					FixIndentation(accessor);
				}
			}
			else
			{
				blockFormatting = PropertyFormatting.ForceOneLine;
				if (!accessor.Body.IsNull)
				{
					ForceSpacesBeforeRemoveNewLines(accessor.Body.LBraceToken);
					ForceSpacesBeforeRemoveNewLines(accessor.Body.RBraceToken);
				}
			}
			if (accessor.IsNull || accessor.Body.IsNull)
			{
				return;
			}
			if (IsSimpleAccessor(accessor))
			{
				switch (blockFormatting)
				{
				default:
					return;
				case PropertyFormatting.AllowOneLine:
					if (accessor.Body.LBraceToken.StartLocation.Line == accessor.Body.RBraceToken.StartLocation.Line)
					{
						nextStatementIndent = " ";
						VisitBlockWithoutFixingBraces(accessor.Body, policy.IndentBlocks);
						nextStatementIndent = null;
						if (!oneLine)
						{
							ForceSpacesBeforeRemoveNewLines(accessor.Body.RBraceToken);
						}
						return;
					}
					break;
				case PropertyFormatting.ForceOneLine:
				{
					FixOpenBrace(BraceStyle.EndOfLine, accessor.Body.LBraceToken);
					Statement statement = accessor.Body.Statements.FirstOrDefault();
					if (statement != null)
					{
						ForceSpacesBeforeRemoveNewLines(statement);
						statement.AcceptVisitor(this);
					}
					if (!oneLine)
					{
						ForceSpacesBeforeRemoveNewLines(accessor.Body.RBraceToken);
					}
					return;
				}
				case PropertyFormatting.ForceNewLine:
					break;
				}
				FixOpenBrace(braceStyle, accessor.Body.LBraceToken);
				VisitBlockWithoutFixingBraces(accessor.Body, policy.IndentBlocks);
				if (!oneLine)
				{
					FixClosingBrace(braceStyle, accessor.Body.RBraceToken);
				}
			}
			else
			{
				FixOpenBrace(braceStyle, accessor.Body.LBraceToken);
				VisitBlockWithoutFixingBraces(accessor.Body, policy.IndentBlocks);
				FixClosingBrace(braceStyle, accessor.Body.RBraceToken);
			}
		}

		public override void VisitAccessor(Accessor accessor)
		{
			FixAttributesAndDocComment(accessor);
			base.VisitAccessor(accessor);
		}

		public override void VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration)
		{
			FixAttributesAndDocComment(indexerDeclaration);
			ForceSpacesBefore(indexerDeclaration.LBracketToken, policy.SpaceBeforeIndexerDeclarationBracket);
			ForceSpacesAfter(indexerDeclaration.LBracketToken, policy.SpaceWithinIndexerDeclarationBracket);
			FormatArguments(indexerDeclaration);
			bool oneLine = false;
			bool flag = false;
			switch (policy.SimplePropertyFormatting)
			{
			case PropertyFormatting.AllowOneLine:
			{
				bool num3 = IsSimpleAccessor(indexerDeclaration.Getter) && IsSimpleAccessor(indexerDeclaration.Setter);
				int line = indexerDeclaration.RBraceToken.StartLocation.Line;
				line = ((!indexerDeclaration.Getter.IsNull && indexerDeclaration.Setter.IsNull) ? indexerDeclaration.Getter.StartLocation.Line : ((!indexerDeclaration.Getter.IsNull || indexerDeclaration.Setter.IsNull) ? ((indexerDeclaration.Getter.StartLocation < indexerDeclaration.Setter.StartLocation) ? indexerDeclaration.Getter : indexerDeclaration.Setter).StartLocation.Line : indexerDeclaration.Setter.StartLocation.Line));
				if (!num3 || indexerDeclaration.LBraceToken.StartLocation.Line != line)
				{
					flag = true;
					FixOpenBrace(policy.PropertyBraceStyle, indexerDeclaration.LBraceToken);
					break;
				}
				ForceSpacesBefore(indexerDeclaration.Getter, forceSpaces: true);
				ForceSpacesBefore(indexerDeclaration.Setter, forceSpaces: true);
				ForceSpacesBeforeRemoveNewLines(indexerDeclaration.RBraceToken);
				oneLine = true;
				break;
			}
			case PropertyFormatting.ForceNewLine:
				flag = true;
				FixOpenBrace(policy.PropertyBraceStyle, indexerDeclaration.LBraceToken);
				break;
			case PropertyFormatting.ForceOneLine:
				if (IsSimpleAccessor(indexerDeclaration.Getter) && IsSimpleAccessor(indexerDeclaration.Setter))
				{
					int offset = document.GetOffset(indexerDeclaration.LBraceToken.StartLocation);
					int num = SearchWhitespaceStart(offset);
					int num2 = SearchWhitespaceEnd(offset);
					AddChange(num, offset - num, " ");
					AddChange(offset + 1, num2 - offset - 2, " ");
					offset = document.GetOffset(indexerDeclaration.RBraceToken.StartLocation);
					num = SearchWhitespaceStart(offset);
					AddChange(num, offset - num, " ");
					oneLine = true;
				}
				else
				{
					flag = true;
					FixOpenBrace(policy.PropertyBraceStyle, indexerDeclaration.LBraceToken);
				}
				break;
			}
			if (policy.IndentPropertyBody)
			{
				curIndent.Push(IndentType.Block);
			}
			FormatAccessor(indexerDeclaration.Getter, policy.PropertyGetBraceStyle, policy.SimpleGetBlockFormatting, oneLine);
			FormatAccessor(indexerDeclaration.Setter, policy.PropertySetBraceStyle, policy.SimpleSetBlockFormatting, oneLine);
			if (policy.IndentPropertyBody)
			{
				curIndent.Pop();
			}
			if (flag)
			{
				FixClosingBrace(policy.PropertyBraceStyle, indexerDeclaration.RBraceToken);
			}
		}

		private static bool IsSimpleEvent(AstNode node)
		{
			return node is EventDeclaration;
		}

		public override void VisitCustomEventDeclaration(CustomEventDeclaration eventDeclaration)
		{
			FixAttributesAndDocComment(eventDeclaration);
			FixOpenBrace(policy.EventBraceStyle, eventDeclaration.LBraceToken);
			if (policy.IndentEventBody)
			{
				curIndent.Push(IndentType.Block);
			}
			if (!eventDeclaration.AddAccessor.IsNull)
			{
				FixIndentation(eventDeclaration.AddAccessor);
				if (!eventDeclaration.AddAccessor.Body.IsNull)
				{
					if (!policy.AllowEventAddBlockInline || eventDeclaration.AddAccessor.Body.LBraceToken.StartLocation.Line != eventDeclaration.AddAccessor.Body.RBraceToken.StartLocation.Line)
					{
						FixOpenBrace(policy.EventAddBraceStyle, eventDeclaration.AddAccessor.Body.LBraceToken);
						VisitBlockWithoutFixingBraces(eventDeclaration.AddAccessor.Body, policy.IndentBlocks);
						FixClosingBrace(policy.EventAddBraceStyle, eventDeclaration.AddAccessor.Body.RBraceToken);
					}
					else
					{
						nextStatementIndent = " ";
						VisitBlockWithoutFixingBraces(eventDeclaration.AddAccessor.Body, policy.IndentBlocks);
						nextStatementIndent = null;
					}
				}
			}
			if (!eventDeclaration.RemoveAccessor.IsNull)
			{
				FixIndentation(eventDeclaration.RemoveAccessor);
				if (!eventDeclaration.RemoveAccessor.Body.IsNull)
				{
					if (!policy.AllowEventRemoveBlockInline || eventDeclaration.RemoveAccessor.Body.LBraceToken.StartLocation.Line != eventDeclaration.RemoveAccessor.Body.RBraceToken.StartLocation.Line)
					{
						FixOpenBrace(policy.EventRemoveBraceStyle, eventDeclaration.RemoveAccessor.Body.LBraceToken);
						VisitBlockWithoutFixingBraces(eventDeclaration.RemoveAccessor.Body, policy.IndentBlocks);
						FixClosingBrace(policy.EventRemoveBraceStyle, eventDeclaration.RemoveAccessor.Body.RBraceToken);
					}
					else
					{
						nextStatementIndent = " ";
						VisitBlockWithoutFixingBraces(eventDeclaration.RemoveAccessor.Body, policy.IndentBlocks);
						nextStatementIndent = null;
					}
				}
			}
			if (policy.IndentEventBody)
			{
				curIndent.Pop();
			}
			FixClosingBrace(policy.EventBraceStyle, eventDeclaration.RBraceToken);
		}

		public override void VisitEventDeclaration(EventDeclaration eventDeclaration)
		{
			FixAttributesAndDocComment(eventDeclaration);
			foreach (CSharpModifierToken modifierToken in eventDeclaration.ModifierTokens)
			{
				ForceSpacesAfter(modifierToken, forceSpaces: true);
			}
			ForceSpacesBeforeRemoveNewLines(eventDeclaration.EventToken.GetNextSibling(NoWhitespacePredicate));
			eventDeclaration.ReturnType.AcceptVisitor(this);
			ForceSpacesAfter(eventDeclaration.ReturnType, forceSpaces: true);
			FixSemicolon(eventDeclaration.SemicolonToken);
		}

		public override void VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
		{
			FixAttributesAndDocComment(fieldDeclaration);
			fieldDeclaration.ReturnType.AcceptVisitor(this);
			ForceSpacesAfter(fieldDeclaration.ReturnType, forceSpaces: true);
			FormatCommas(fieldDeclaration, policy.SpaceBeforeFieldDeclarationComma, policy.SpaceAfterFieldDeclarationComma);
			TextLocation startLocation = fieldDeclaration.ReturnType.StartLocation;
			foreach (VariableInitializer variable in fieldDeclaration.Variables)
			{
				if (startLocation.Line != variable.StartLocation.Line)
				{
					curIndent.Push(IndentType.Block);
					FixStatementIndentation(variable.StartLocation);
					curIndent.Pop();
					startLocation = variable.StartLocation;
				}
				variable.AcceptVisitor(this);
			}
			FixSemicolon(fieldDeclaration.SemicolonToken);
		}

		public override void VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration)
		{
			FixAttributesAndDocComment(fixedFieldDeclaration);
			FormatCommas(fixedFieldDeclaration, policy.SpaceBeforeFieldDeclarationComma, policy.SpaceAfterFieldDeclarationComma);
			TextLocation startLocation = fixedFieldDeclaration.StartLocation;
			curIndent.Push(IndentType.Block);
			foreach (FixedVariableInitializer variable in fixedFieldDeclaration.Variables)
			{
				if (startLocation.Line != variable.StartLocation.Line)
				{
					FixStatementIndentation(variable.StartLocation);
					startLocation = variable.StartLocation;
				}
				variable.AcceptVisitor(this);
			}
			curIndent.Pop();
			FixSemicolon(fixedFieldDeclaration.SemicolonToken);
		}

		public override void VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration)
		{
			FixAttributesAndDocComment(enumMemberDeclaration);
			Expression initializer = enumMemberDeclaration.Initializer;
			if (!initializer.IsNull)
			{
				ForceSpacesAround(enumMemberDeclaration.AssignToken, policy.SpaceAroundAssignment);
				initializer.AcceptVisitor(this);
			}
		}

		public override void VisitMethodDeclaration(MethodDeclaration methodDeclaration)
		{
			FixAttributesAndDocComment(methodDeclaration);
			ForceSpacesBefore(methodDeclaration.LParToken, policy.SpaceBeforeMethodDeclarationParentheses);
			if (methodDeclaration.Parameters.Any())
			{
				ForceSpacesAfter(methodDeclaration.LParToken, policy.SpaceWithinMethodDeclarationParentheses);
				FormatArguments(methodDeclaration);
			}
			else
			{
				ForceSpacesAfter(methodDeclaration.LParToken, policy.SpaceBetweenEmptyMethodDeclarationParentheses);
				ForceSpacesBefore(methodDeclaration.RParToken, policy.SpaceBetweenEmptyMethodDeclarationParentheses);
			}
			foreach (Constraint constraint in methodDeclaration.Constraints)
			{
				constraint.AcceptVisitor(this);
			}
			if (!methodDeclaration.Body.IsNull)
			{
				FixOpenBrace(policy.MethodBraceStyle, methodDeclaration.Body.LBraceToken);
				VisitBlockWithoutFixingBraces(methodDeclaration.Body, policy.IndentMethodBody);
				FixClosingBrace(policy.MethodBraceStyle, methodDeclaration.Body.RBraceToken);
			}
		}

		public override void VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration)
		{
			FixAttributesAndDocComment(operatorDeclaration);
			ForceSpacesBefore(operatorDeclaration.LParToken, policy.SpaceBeforeMethodDeclarationParentheses);
			if (operatorDeclaration.Parameters.Any())
			{
				ForceSpacesAfter(operatorDeclaration.LParToken, policy.SpaceWithinMethodDeclarationParentheses);
				FormatArguments(operatorDeclaration);
			}
			else
			{
				ForceSpacesAfter(operatorDeclaration.LParToken, policy.SpaceBetweenEmptyMethodDeclarationParentheses);
				ForceSpacesBefore(operatorDeclaration.RParToken, policy.SpaceBetweenEmptyMethodDeclarationParentheses);
			}
			if (!operatorDeclaration.Body.IsNull)
			{
				FixOpenBrace(policy.MethodBraceStyle, operatorDeclaration.Body.LBraceToken);
				VisitBlockWithoutFixingBraces(operatorDeclaration.Body, policy.IndentMethodBody);
				FixClosingBrace(policy.MethodBraceStyle, operatorDeclaration.Body.RBraceToken);
			}
		}

		public override void VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
		{
			FixAttributesAndDocComment(constructorDeclaration);
			ForceSpacesBefore(constructorDeclaration.LParToken, policy.SpaceBeforeConstructorDeclarationParentheses);
			if (constructorDeclaration.Parameters.Any())
			{
				ForceSpacesAfter(constructorDeclaration.LParToken, policy.SpaceWithinConstructorDeclarationParentheses);
				FormatArguments(constructorDeclaration);
			}
			else
			{
				ForceSpacesAfter(constructorDeclaration.LParToken, policy.SpaceBetweenEmptyConstructorDeclarationParentheses);
				ForceSpacesBefore(constructorDeclaration.RParToken, policy.SpaceBetweenEmptyConstructorDeclarationParentheses);
			}
			ConstructorInitializer initializer = constructorDeclaration.Initializer;
			if (!initializer.IsNull)
			{
				curIndent.Push(IndentType.Block);
				PlaceOnNewLine(policy.NewLineBeforeConstructorInitializerColon, constructorDeclaration.ColonToken);
				PlaceOnNewLine(policy.NewLineAfterConstructorInitializerColon, initializer);
				initializer.AcceptVisitor(this);
				curIndent.Pop();
			}
			if (!constructorDeclaration.Body.IsNull)
			{
				FixOpenBrace(policy.ConstructorBraceStyle, constructorDeclaration.Body.LBraceToken);
				VisitBlockWithoutFixingBraces(constructorDeclaration.Body, policy.IndentMethodBody);
				FixClosingBrace(policy.ConstructorBraceStyle, constructorDeclaration.Body.RBraceToken);
			}
		}

		public override void VisitConstructorInitializer(ConstructorInitializer constructorInitializer)
		{
			ForceSpacesBefore(constructorInitializer.LParToken, policy.SpaceBeforeMethodCallParentheses);
			if (constructorInitializer.Arguments.Any())
			{
				ForceSpacesAfter(constructorInitializer.LParToken, policy.SpaceWithinMethodCallParentheses);
			}
			else
			{
				ForceSpacesAfter(constructorInitializer.LParToken, policy.SpaceBetweenEmptyMethodCallParentheses);
				ForceSpacesBefore(constructorInitializer.RParToken, policy.SpaceBetweenEmptyMethodCallParentheses);
			}
			FormatArguments(constructorInitializer);
		}

		public override void VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
		{
			FixAttributesAndDocComment(destructorDeclaration);
			CSharpTokenNode lParToken = destructorDeclaration.LParToken;
			ForceSpaceBefore(lParToken, policy.SpaceBeforeConstructorDeclarationParentheses);
			if (!destructorDeclaration.Body.IsNull)
			{
				FixOpenBrace(policy.DestructorBraceStyle, destructorDeclaration.Body.LBraceToken);
				VisitBlockWithoutFixingBraces(destructorDeclaration.Body, policy.IndentMethodBody);
				FixClosingBrace(policy.DestructorBraceStyle, destructorDeclaration.Body.RBraceToken);
			}
		}

		private int GetGlobalNewLinesFor(AstNode child)
		{
			if (child.NextSibling == null)
			{
				return 0;
			}
			if (child.NextSibling.Role == Roles.RBrace)
			{
				return 0;
			}
			int num = 1;
			AstNode nextSibling = child.GetNextSibling(NoWhitespacePredicate);
			if (nextSibling is PreProcessorDirective)
			{
				PreProcessorDirective preProcessorDirective = (PreProcessorDirective)nextSibling;
				if (preProcessorDirective.Type == PreProcessorDirectiveType.Endif)
				{
					return -1;
				}
				if (preProcessorDirective.Type == PreProcessorDirectiveType.Undef)
				{
					return -1;
				}
			}
			if ((child is UsingDeclaration || child is UsingAliasDeclaration) && !(nextSibling is UsingDeclaration) && !(nextSibling is UsingAliasDeclaration))
			{
				num += policy.MinimumBlankLinesAfterUsings;
			}
			else if (child is TypeDeclaration && nextSibling is TypeDeclaration)
			{
				num += policy.MinimumBlankLinesBetweenTypes;
			}
			return num;
		}

		public override void VisitSyntaxTree(SyntaxTree unit)
		{
			bool first = true;
			VisitChildrenToFormat(unit, delegate(AstNode child)
			{
				if (first && (child is UsingDeclaration || child is UsingAliasDeclaration))
				{
					EnsureMinimumBlankLinesBefore(child, policy.MinimumBlankLinesBeforeUsings);
					first = false;
				}
				if (NoWhitespacePredicate(child))
				{
					FixIndentation(child);
				}
				child.AcceptVisitor(this);
				if (NoWhitespacePredicate(child) && !first)
				{
					EnsureMinimumNewLinesAfter(child, GetGlobalNewLinesFor(child));
				}
			});
		}

		public override void VisitAttributeSection(AttributeSection attributeSection)
		{
			VisitChildrenToFormat(attributeSection, delegate(AstNode child)
			{
				child.AcceptVisitor(this);
				if (child.NextSibling != null && child.NextSibling.Role == Roles.RBracket)
				{
					ForceSpacesAfter(child, forceSpaces: false);
				}
			});
		}

		public override void VisitAttribute(Attribute attribute)
		{
			if (attribute.HasArgumentList)
			{
				ForceSpacesBefore(attribute.LParToken, policy.SpaceBeforeMethodCallParentheses);
				if (attribute.Arguments.Any())
				{
					ForceSpacesAfter(attribute.LParToken, policy.SpaceWithinMethodCallParentheses);
				}
				else
				{
					ForceSpacesAfter(attribute.LParToken, policy.SpaceBetweenEmptyMethodCallParentheses);
					ForceSpacesBefore(attribute.RParToken, policy.SpaceBetweenEmptyMethodCallParentheses);
				}
				FormatArguments(attribute);
			}
		}

		public override void VisitUsingDeclaration(UsingDeclaration usingDeclaration)
		{
			ForceSpacesAfter(usingDeclaration.UsingToken, forceSpaces: true);
			FixSemicolon(usingDeclaration.SemicolonToken);
		}

		public override void VisitUsingAliasDeclaration(UsingAliasDeclaration usingDeclaration)
		{
			ForceSpacesAfter(usingDeclaration.UsingToken, forceSpaces: true);
			ForceSpacesAround(usingDeclaration.AssignToken, policy.SpaceAroundAssignment);
			FixSemicolon(usingDeclaration.SemicolonToken);
		}

		public override void VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
		{
			FixOpenBrace(policy.NamespaceBraceStyle, namespaceDeclaration.LBraceToken);
			if (policy.IndentNamespaceBody)
			{
				curIndent.Push(IndentType.Block);
			}
			bool first = true;
			bool startFormat = false;
			VisitChildrenToFormat(namespaceDeclaration, delegate(AstNode child)
			{
				if (first)
				{
					startFormat = (child.StartLocation > namespaceDeclaration.LBraceToken.StartLocation);
				}
				if (child.Role == Roles.LBrace)
				{
					AstNode nextSibling = child.GetNextSibling(NoWhitespacePredicate);
					int num = 1;
					num = ((!(nextSibling is UsingDeclaration) && !(nextSibling is UsingAliasDeclaration)) ? (num + policy.MinimumBlankLinesBeforeFirstDeclaration) : (num + policy.MinimumBlankLinesBeforeUsings));
					EnsureMinimumNewLinesAfter(child, num);
					startFormat = true;
				}
				else if (child.Role == Roles.RBrace)
				{
					startFormat = false;
				}
				else if (startFormat && NoWhitespacePredicate(child))
				{
					if (first && (child is UsingDeclaration || child is UsingAliasDeclaration))
					{
						first = false;
					}
					if (NoWhitespacePredicate(child))
					{
						FixIndentationForceNewLine(child);
					}
					child.AcceptVisitor(this);
					if (NoWhitespacePredicate(child))
					{
						EnsureMinimumNewLinesAfter(child, GetGlobalNewLinesFor(child));
					}
				}
			});
			if (policy.IndentNamespaceBody)
			{
				curIndent.Pop();
			}
			FixClosingBrace(policy.NamespaceBraceStyle, namespaceDeclaration.RBraceToken);
		}

		private void FixAttributesAndDocComment(EntityDeclaration entity)
		{
			AstNode astNode = entity.FirstChild;
			while (astNode != null && astNode.Role == Roles.Comment)
			{
				astNode = astNode.GetNextSibling(NoWhitespacePredicate);
				FixIndentation(astNode);
			}
			if (entity.Attributes.Count > 0)
			{
				AstNode astNode2 = null;
				entity.Attributes.First().AcceptVisitor(this);
				foreach (AttributeSection item in entity.Attributes.Skip(1))
				{
					FixIndentation(item);
					item.AcceptVisitor(this);
					astNode2 = item;
				}
				if (astNode2 != null)
				{
					FixIndentation(astNode2.GetNextNode(NoWhitespacePredicate));
				}
				else
				{
					FixIndentation(entity.Attributes.First().GetNextNode(NoWhitespacePredicate));
				}
			}
		}

		public override void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
		{
			FixAttributesAndDocComment(typeDeclaration);
			bool flag = false;
			BraceStyle braceStyle;
			switch (typeDeclaration.ClassType)
			{
			case ClassType.Class:
				braceStyle = policy.ClassBraceStyle;
				flag = policy.IndentClassBody;
				break;
			case ClassType.Struct:
				braceStyle = policy.StructBraceStyle;
				flag = policy.IndentStructBody;
				break;
			case ClassType.Interface:
				braceStyle = policy.InterfaceBraceStyle;
				flag = policy.IndentInterfaceBody;
				break;
			case ClassType.Enum:
				braceStyle = policy.EnumBraceStyle;
				flag = policy.IndentEnumBody;
				break;
			default:
				throw new InvalidOperationException("unsupported class type : " + typeDeclaration.ClassType);
			}
			foreach (Constraint constraint in typeDeclaration.Constraints)
			{
				constraint.AcceptVisitor(this);
			}
			FixOpenBrace(braceStyle, typeDeclaration.LBraceToken);
			if (flag)
			{
				curIndent.Push(IndentType.Block);
			}
			bool startFormat = true;
			bool first = true;
			VisitChildrenToFormat(typeDeclaration, delegate(AstNode child)
			{
				if (first)
				{
					startFormat = (child.StartLocation > typeDeclaration.LBraceToken.StartLocation);
					first = false;
				}
				if (child.Role == Roles.LBrace)
				{
					startFormat = true;
					if (braceStyle != 0)
					{
						EnsureMinimumNewLinesAfter(child, GetTypeLevelNewLinesFor(child));
					}
				}
				else if (child.Role == Roles.RBrace)
				{
					startFormat = false;
				}
				else if (startFormat && NoWhitespacePredicate(child))
				{
					if (child.Role == Roles.Comma)
					{
						ForceSpacesBeforeRemoveNewLines(child, forceSpace: false);
						EnsureMinimumNewLinesAfter(child, 1);
					}
					else
					{
						if (NoWhitespacePredicate(child))
						{
							FixIndentationForceNewLine(child);
						}
						child.AcceptVisitor(this);
						if (NoWhitespacePredicate(child) && child.GetNextSibling(NoWhitespacePredicate).Role != Roles.Comma)
						{
							EnsureMinimumNewLinesAfter(child, GetTypeLevelNewLinesFor(child));
						}
					}
				}
			});
			if (flag)
			{
				curIndent.Pop();
			}
			FixClosingBrace(braceStyle, typeDeclaration.RBraceToken);
		}

		private int GetTypeLevelNewLinesFor(AstNode child)
		{
			int num = 1;
			AstNode nextSibling = child.GetNextSibling(NoWhitespacePredicate);
			if (child is PreProcessorDirective)
			{
				PreProcessorDirective obj = (PreProcessorDirective)child;
				if (obj.Type == PreProcessorDirectiveType.Region)
				{
					num += policy.MinimumBlankLinesInsideRegion;
				}
				if (obj.Type == PreProcessorDirectiveType.Endregion)
				{
					if (child.GetNextSibling(NoWhitespacePredicate) is CSharpTokenNode)
					{
						return 1;
					}
					num += policy.MinimumBlankLinesAroundRegion;
				}
				return num;
			}
			if (nextSibling is PreProcessorDirective)
			{
				PreProcessorDirective preProcessorDirective = (PreProcessorDirective)nextSibling;
				if (preProcessorDirective.Type == PreProcessorDirectiveType.Region)
				{
					if (child is CSharpTokenNode)
					{
						return 1;
					}
					num += policy.MinimumBlankLinesAroundRegion;
				}
				if (preProcessorDirective.Type == PreProcessorDirectiveType.Endregion)
				{
					num += policy.MinimumBlankLinesInsideRegion;
				}
				if (preProcessorDirective.Type == PreProcessorDirectiveType.Endif)
				{
					return -1;
				}
				if (preProcessorDirective.Type == PreProcessorDirectiveType.Undef)
				{
					return -1;
				}
				return num;
			}
			if (child.Role == Roles.LBrace)
			{
				return 1;
			}
			if (child is Comment)
			{
				return 1;
			}
			if (child is EventDeclaration && nextSibling is EventDeclaration)
			{
				return num + policy.MinimumBlankLinesBetweenEventFields;
			}
			if ((child is FieldDeclaration || child is FixedFieldDeclaration) && (nextSibling is FieldDeclaration || nextSibling is FixedFieldDeclaration))
			{
				return num + policy.MinimumBlankLinesBetweenFields;
			}
			if (child is TypeDeclaration && nextSibling is TypeDeclaration)
			{
				return num + policy.MinimumBlankLinesBetweenTypes;
			}
			if (nextSibling.Role == Roles.TypeMemberRole)
			{
				num += policy.MinimumBlankLinesBetweenMembers;
			}
			return num;
		}

		public override void VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration)
		{
			ForceSpacesBefore(delegateDeclaration.LParToken, policy.SpaceBeforeDelegateDeclarationParentheses);
			if (delegateDeclaration.Parameters.Any())
			{
				ForceSpacesAfter(delegateDeclaration.LParToken, policy.SpaceWithinDelegateDeclarationParentheses);
				ForceSpacesBefore(delegateDeclaration.RParToken, policy.SpaceWithinDelegateDeclarationParentheses);
			}
			else
			{
				ForceSpacesAfter(delegateDeclaration.LParToken, policy.SpaceBetweenEmptyDelegateDeclarationParentheses);
				ForceSpacesBefore(delegateDeclaration.RParToken, policy.SpaceBetweenEmptyDelegateDeclarationParentheses);
			}
			FormatCommas(delegateDeclaration, policy.SpaceBeforeDelegateDeclarationParameterComma, policy.SpaceAfterDelegateDeclarationParameterComma);
			base.VisitDelegateDeclaration(delegateDeclaration);
		}

		public override void VisitComment(Comment comment)
		{
			if (comment.StartsLine && !HadErrors && (!policy.KeepCommentsAtFirstColumn || comment.StartLocation.Column > 1))
			{
				FixIndentation(comment);
			}
		}

		public override void VisitConstraint(Constraint constraint)
		{
			VisitChildrenToFormat(constraint, delegate(AstNode node)
			{
				if (node is AstType)
				{
					node.AcceptVisitor(this);
				}
				else if (node.Role == Roles.LPar)
				{
					ForceSpacesBefore(node, forceSpaces: false);
					ForceSpacesAfter(node, forceSpaces: false);
				}
				else if (node.Role == Roles.Comma)
				{
					ForceSpacesBefore(node, forceSpaces: false);
					ForceSpacesAfter(node, forceSpaces: true);
				}
			});
		}

		public override void VisitExpressionStatement(ExpressionStatement expressionStatement)
		{
			base.VisitExpressionStatement(expressionStatement);
			FixSemicolon(expressionStatement.SemicolonToken);
		}

		private void VisitBlockWithoutFixingBraces(BlockStatement blockStatement, bool indent)
		{
			if (indent)
			{
				curIndent.Push(IndentType.Block);
			}
			VisitChildrenToFormat(blockStatement, delegate(AstNode child)
			{
				if (child.Role != Roles.LBrace && child.Role != Roles.RBrace)
				{
					if (child is Statement)
					{
						FixStatementIndentation(child.StartLocation);
						child.AcceptVisitor(this);
					}
					else if (child is Comment)
					{
						child.AcceptVisitor(this);
					}
					else if (!(child is NewLineNode) && child.StartLocation.Column > 1)
					{
						FixStatementIndentation(child.StartLocation);
					}
				}
			});
			if (indent)
			{
				curIndent.Pop();
			}
		}

		public override void VisitBlockStatement(BlockStatement blockStatement)
		{
			FixIndentation(blockStatement);
			VisitBlockWithoutFixingBraces(blockStatement, policy.IndentBlocks);
			FixIndentation(blockStatement.RBraceToken);
		}

		public override void VisitBreakStatement(BreakStatement breakStatement)
		{
			FixSemicolon(breakStatement.SemicolonToken);
		}

		public override void VisitCheckedStatement(CheckedStatement checkedStatement)
		{
			FixEmbeddedStatment(policy.StatementBraceStyle, checkedStatement.Body);
		}

		public override void VisitContinueStatement(ContinueStatement continueStatement)
		{
			FixSemicolon(continueStatement.SemicolonToken);
		}

		public override void VisitEmptyStatement(EmptyStatement emptyStatement)
		{
		}

		public override void VisitFixedStatement(FixedStatement fixedStatement)
		{
			FixEmbeddedStatment(policy.StatementBraceStyle, fixedStatement.EmbeddedStatement);
		}

		public override void VisitForeachStatement(ForeachStatement foreachStatement)
		{
			ForceSpacesBeforeRemoveNewLines(foreachStatement.LParToken, policy.SpaceBeforeForeachParentheses);
			ForceSpacesAfter(foreachStatement.LParToken, policy.SpacesWithinForeachParentheses);
			ForceSpacesBeforeRemoveNewLines(foreachStatement.RParToken, policy.SpacesWithinForeachParentheses);
			FixEmbeddedStatment(policy.StatementBraceStyle, foreachStatement.EmbeddedStatement);
		}

		private void FixEmbeddedStatment(BraceStyle braceStyle, AstNode node)
		{
			FixEmbeddedStatment(braceStyle, null, allowInLine: false, node);
		}

		private void FixEmbeddedStatment(BraceStyle braceStyle, CSharpTokenNode token, bool allowInLine, AstNode node, bool statementAlreadyIndented = false)
		{
			if (node == null)
			{
				return;
			}
			bool num = node is BlockStatement;
			FormattingChanges.TextReplaceAction textReplaceAction = null;
			FormattingChanges.TextReplaceAction textReplaceAction2 = null;
			BlockStatement blockStatement = null;
			if (num)
			{
				BlockStatement blockStatement2 = node as BlockStatement;
				if (allowInLine && blockStatement2.StartLocation.Line == blockStatement2.EndLocation.Line && blockStatement2.Statements.Count() <= 1)
				{
					if (blockStatement2.Statements.Count() == 1)
					{
						nextStatementIndent = " ";
					}
				}
				else
				{
					if (!statementAlreadyIndented)
					{
						FixOpenBrace(braceStyle, blockStatement2.LBraceToken);
					}
					blockStatement = blockStatement2;
				}
				if (braceStyle == BraceStyle.NextLineShifted2)
				{
					curIndent.Push(IndentType.Block);
				}
			}
			else if (allowInLine && token.StartLocation.Line == node.EndLocation.Line)
			{
				nextStatementIndent = " ";
			}
			bool flag = false;
			if (policy.IndentBlocks && (!policy.AlignEmbeddedStatements || !(node is IfElseStatement) || !(node.Parent is IfElseStatement)) && (!policy.AlignEmbeddedStatements || !(node is UsingStatement) || !(node.Parent is UsingStatement)) && (!policy.AlignEmbeddedStatements || !(node is LockStatement) || !(node.Parent is LockStatement)))
			{
				curIndent.Push(IndentType.Block);
				flag = true;
			}
			if (num)
			{
				VisitBlockWithoutFixingBraces((BlockStatement)node, indent: false);
			}
			else
			{
				if (!statementAlreadyIndented)
				{
					PlaceOnNewLine(policy.EmbeddedStatementPlacement, node);
					nextStatementIndent = null;
				}
				node.AcceptVisitor(this);
			}
			nextStatementIndent = null;
			if (flag)
			{
				curIndent.Pop();
			}
			if (textReplaceAction != null && textReplaceAction2 != null)
			{
				textReplaceAction.DependsOn = textReplaceAction2;
				textReplaceAction2.DependsOn = textReplaceAction;
			}
			if (num && braceStyle == BraceStyle.NextLineShifted2)
			{
				curIndent.Pop();
			}
			if (blockStatement != null)
			{
				FixClosingBrace(braceStyle, blockStatement.RBraceToken);
			}
		}

		public bool IsLineIsEmptyUpToEol(TextLocation startLocation)
		{
			return IsLineIsEmptyUpToEol(document.GetOffset(startLocation) - 1);
		}

		private bool IsLineIsEmptyUpToEol(int startOffset)
		{
			for (int num = startOffset - 1; num >= 0; num--)
			{
				char charAt = document.GetCharAt(num);
				if (charAt != ' ' && charAt != '\t')
				{
					return NewLine.IsNewLine(charAt);
				}
			}
			return true;
		}

		private int SearchWhitespaceStart(int startOffset)
		{
			if (startOffset < 0)
			{
				throw new ArgumentOutOfRangeException("startoffset", "value : " + startOffset);
			}
			for (int num = startOffset - 1; num >= 0; num--)
			{
				if (!char.IsWhiteSpace(document.GetCharAt(num)))
				{
					return num + 1;
				}
			}
			return 0;
		}

		private int SearchWhitespaceEnd(int startOffset)
		{
			if (startOffset > document.TextLength)
			{
				throw new ArgumentOutOfRangeException("startoffset", "value : " + startOffset);
			}
			for (int i = startOffset + 1; i < document.TextLength; i++)
			{
				if (!char.IsWhiteSpace(document.GetCharAt(i)))
				{
					return i + 1;
				}
			}
			return document.TextLength - 1;
		}

		private int SearchWhitespaceLineStart(int startOffset)
		{
			if (startOffset < 0)
			{
				throw new ArgumentOutOfRangeException("startoffset", "value : " + startOffset);
			}
			for (int num = startOffset - 1; num >= 0; num--)
			{
				char charAt = document.GetCharAt(num);
				if (charAt != ' ' && charAt != '\t')
				{
					return num + 1;
				}
			}
			return 0;
		}

		public override void VisitForStatement(ForStatement forStatement)
		{
			foreach (AstNode child in forStatement.Children)
			{
				if (child.Role == Roles.Semicolon)
				{
					if (!(child.GetNextSibling(NoWhitespacePredicate) is CSharpTokenNode) && !(child.GetNextSibling(NoWhitespacePredicate) is EmptyStatement))
					{
						ForceSpacesBefore(child, policy.SpaceBeforeForSemicolon);
						ForceSpacesAfter(child, policy.SpaceAfterForSemicolon);
					}
				}
				else if (child.Role == Roles.LPar)
				{
					ForceSpacesBeforeRemoveNewLines(child, policy.SpaceBeforeForParentheses);
					ForceSpacesAfter(child, policy.SpacesWithinForParentheses);
				}
				else if (child.Role == Roles.RPar)
				{
					ForceSpacesBeforeRemoveNewLines(child, policy.SpacesWithinForParentheses);
				}
				else if (child.Role == Roles.EmbeddedStatement)
				{
					FixEmbeddedStatment(policy.StatementBraceStyle, child);
				}
				else
				{
					child.AcceptVisitor(this);
				}
			}
		}

		public override void VisitGotoStatement(GotoStatement gotoStatement)
		{
			VisitChildren(gotoStatement);
			FixSemicolon(gotoStatement.SemicolonToken);
		}

		public override void VisitIfElseStatement(IfElseStatement ifElseStatement)
		{
			ForceSpacesBeforeRemoveNewLines(ifElseStatement.LParToken, policy.SpaceBeforeIfParentheses);
			Align(ifElseStatement.LParToken, ifElseStatement.Condition, policy.SpacesWithinIfParentheses);
			ForceSpacesBeforeRemoveNewLines(ifElseStatement.RParToken, policy.SpacesWithinIfParentheses);
			if (!ifElseStatement.TrueStatement.IsNull)
			{
				FixEmbeddedStatment(policy.StatementBraceStyle, ifElseStatement.IfToken, policy.AllowIfBlockInline, ifElseStatement.TrueStatement);
			}
			if (!ifElseStatement.FalseStatement.IsNull)
			{
				NewLinePlacement newLine = policy.ElseNewLinePlacement;
				if (!(ifElseStatement.TrueStatement is BlockStatement))
				{
					newLine = NewLinePlacement.NewLine;
				}
				PlaceOnNewLine(newLine, ifElseStatement.ElseToken);
				if (ifElseStatement.FalseStatement is IfElseStatement)
				{
					PlaceOnNewLine(policy.ElseIfNewLinePlacement, ((IfElseStatement)ifElseStatement.FalseStatement).IfToken);
				}
				FixEmbeddedStatment(policy.StatementBraceStyle, ifElseStatement.ElseToken, policy.AllowIfBlockInline, ifElseStatement.FalseStatement, ifElseStatement.FalseStatement is IfElseStatement);
			}
		}

		public override void VisitLabelStatement(LabelStatement labelStatement)
		{
			VisitChildren(labelStatement);
		}

		public override void VisitLockStatement(LockStatement lockStatement)
		{
			ForceSpacesBeforeRemoveNewLines(lockStatement.LParToken, policy.SpaceBeforeLockParentheses);
			ForceSpacesAfter(lockStatement.LParToken, policy.SpacesWithinLockParentheses);
			ForceSpacesBeforeRemoveNewLines(lockStatement.RParToken, policy.SpacesWithinLockParentheses);
			FixEmbeddedStatment(policy.StatementBraceStyle, lockStatement.EmbeddedStatement);
		}

		public override void VisitReturnStatement(ReturnStatement returnStatement)
		{
			VisitChildren(returnStatement);
			FixSemicolon(returnStatement.SemicolonToken);
		}

		public override void VisitSwitchStatement(SwitchStatement switchStatement)
		{
			ForceSpacesBeforeRemoveNewLines(switchStatement.LParToken, policy.SpaceBeforeSwitchParentheses);
			ForceSpacesAfter(switchStatement.LParToken, policy.SpacesWithinSwitchParentheses);
			ForceSpacesBeforeRemoveNewLines(switchStatement.RParToken, policy.SpacesWithinSwitchParentheses);
			FixOpenBrace(policy.StatementBraceStyle, switchStatement.LBraceToken);
			VisitChildren(switchStatement);
			FixClosingBrace(policy.StatementBraceStyle, switchStatement.RBraceToken);
		}

		public override void VisitSwitchSection(SwitchSection switchSection)
		{
			if (policy.IndentSwitchBody)
			{
				curIndent.Push(IndentType.Block);
			}
			foreach (CaseLabel caseLabel in switchSection.CaseLabels)
			{
				FixStatementIndentation(caseLabel.StartLocation);
				caseLabel.AcceptVisitor(this);
			}
			if (policy.IndentCaseBody)
			{
				curIndent.Push(IndentType.Block);
			}
			foreach (Statement statement in switchSection.Statements)
			{
				if (statement is BreakStatement && !policy.IndentBreakStatements && policy.IndentCaseBody)
				{
					curIndent.Pop();
					FixStatementIndentation(statement.StartLocation);
					statement.AcceptVisitor(this);
					curIndent.Push(IndentType.Block);
				}
				else
				{
					FixStatementIndentation(statement.StartLocation);
					statement.AcceptVisitor(this);
				}
			}
			if (policy.IndentCaseBody)
			{
				curIndent.Pop();
			}
			if (policy.IndentSwitchBody)
			{
				curIndent.Pop();
			}
		}

		public override void VisitCaseLabel(CaseLabel caseLabel)
		{
			ForceSpacesBefore(caseLabel.ColonToken, forceSpaces: false);
		}

		public override void VisitThrowStatement(ThrowStatement throwStatement)
		{
			VisitChildren(throwStatement);
			FixSemicolon(throwStatement.SemicolonToken);
		}

		public override void VisitTryCatchStatement(TryCatchStatement tryCatchStatement)
		{
			if (!tryCatchStatement.TryBlock.IsNull)
			{
				FixEmbeddedStatment(policy.StatementBraceStyle, tryCatchStatement.TryBlock);
			}
			foreach (CatchClause catchClause in tryCatchStatement.CatchClauses)
			{
				PlaceOnNewLine(policy.CatchNewLinePlacement, catchClause.CatchToken);
				if (!catchClause.LParToken.IsNull)
				{
					ForceSpacesBeforeRemoveNewLines(catchClause.LParToken, policy.SpaceBeforeCatchParentheses);
					ForceSpacesAfter(catchClause.LParToken, policy.SpacesWithinCatchParentheses);
					ForceSpacesBeforeRemoveNewLines(catchClause.RParToken, policy.SpacesWithinCatchParentheses);
				}
				FixEmbeddedStatment(policy.StatementBraceStyle, catchClause.Body);
			}
			if (!tryCatchStatement.FinallyBlock.IsNull)
			{
				PlaceOnNewLine(policy.FinallyNewLinePlacement, tryCatchStatement.FinallyToken);
				FixEmbeddedStatment(policy.StatementBraceStyle, tryCatchStatement.FinallyBlock);
			}
		}

		public override void VisitCatchClause(CatchClause catchClause)
		{
		}

		public override void VisitUncheckedStatement(UncheckedStatement uncheckedStatement)
		{
			FixEmbeddedStatment(policy.StatementBraceStyle, uncheckedStatement.Body);
		}

		public override void VisitUnsafeStatement(UnsafeStatement unsafeStatement)
		{
			FixEmbeddedStatment(policy.StatementBraceStyle, unsafeStatement.Body);
		}

		public override void VisitUsingStatement(UsingStatement usingStatement)
		{
			ForceSpacesBeforeRemoveNewLines(usingStatement.LParToken, policy.SpaceBeforeUsingParentheses);
			Align(usingStatement.LParToken, usingStatement.ResourceAcquisition, policy.SpacesWithinUsingParentheses);
			ForceSpacesBeforeRemoveNewLines(usingStatement.RParToken, policy.SpacesWithinUsingParentheses);
			FixEmbeddedStatment(policy.StatementBraceStyle, usingStatement.EmbeddedStatement);
		}

		public override void VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement)
		{
			AstType type = variableDeclarationStatement.Type;
			type.AcceptVisitor(this);
			if ((variableDeclarationStatement.Modifiers & Modifiers.Const) == Modifiers.Const)
			{
				ForceSpacesAround(type, forceSpaces: true);
			}
			else
			{
				ForceSpacesAfter(type, forceSpaces: true);
			}
			TextLocation startLocation = variableDeclarationStatement.StartLocation;
			foreach (VariableInitializer variable in variableDeclarationStatement.Variables)
			{
				if (startLocation.Line != variable.StartLocation.Line)
				{
					FixStatementIndentation(variable.StartLocation);
					startLocation = variable.StartLocation;
				}
				variable.AcceptVisitor(this);
			}
			FormatCommas(variableDeclarationStatement, policy.SpaceBeforeLocalVariableDeclarationComma, policy.SpaceAfterLocalVariableDeclarationComma);
			FixSemicolon(variableDeclarationStatement.SemicolonToken);
		}

		public override void VisitDoWhileStatement(DoWhileStatement doWhileStatement)
		{
			FixEmbeddedStatment(policy.StatementBraceStyle, doWhileStatement.EmbeddedStatement);
			PlaceOnNewLine((!(doWhileStatement.EmbeddedStatement is BlockStatement)) ? NewLinePlacement.NewLine : policy.WhileNewLinePlacement, doWhileStatement.WhileToken);
			Align(doWhileStatement.LParToken, doWhileStatement.Condition, policy.SpacesWithinWhileParentheses);
			ForceSpacesBeforeRemoveNewLines(doWhileStatement.RParToken, policy.SpacesWithinWhileParentheses);
		}

		private void Align(AstNode lPar, AstNode alignNode, bool space)
		{
			int num = 0;
			bool num2 = lPar.StartLocation.Line == alignNode.StartLocation.Line;
			if (num2)
			{
				num = Math.Max(0, lPar.StartLocation.Column + (space ? 1 : 0) - curIndent.IndentString.Length);
				curIndent.ExtraSpaces += num;
				ForceSpacesAfter(lPar, space);
			}
			else
			{
				curIndent.Push(IndentType.Continuation);
				FixIndentation(alignNode);
			}
			alignNode.AcceptVisitor(this);
			if (num2)
			{
				curIndent.ExtraSpaces -= num;
			}
			else
			{
				curIndent.Pop();
			}
		}

		public override void VisitWhileStatement(WhileStatement whileStatement)
		{
			ForceSpacesBeforeRemoveNewLines(whileStatement.LParToken, policy.SpaceBeforeWhileParentheses);
			Align(whileStatement.LParToken, whileStatement.Condition, policy.SpacesWithinWhileParentheses);
			ForceSpacesBeforeRemoveNewLines(whileStatement.RParToken, policy.SpacesWithinWhileParentheses);
			FixEmbeddedStatment(policy.StatementBraceStyle, whileStatement.EmbeddedStatement);
		}

		public override void VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement)
		{
			FixSemicolon(yieldBreakStatement.SemicolonToken);
		}

		public override void VisitYieldReturnStatement(YieldReturnStatement yieldStatement)
		{
			yieldStatement.Expression.AcceptVisitor(this);
			FixSemicolon(yieldStatement.SemicolonToken);
		}

		public override void VisitVariableInitializer(VariableInitializer variableInitializer)
		{
			if (!variableInitializer.AssignToken.IsNull)
			{
				ForceSpacesAround(variableInitializer.AssignToken, policy.SpaceAroundAssignment);
			}
			if (!variableInitializer.Initializer.IsNull)
			{
				int num = 0;
				bool num2 = variableInitializer.AssignToken.StartLocation.Line == variableInitializer.Initializer.StartLocation.Line;
				if (num2)
				{
					num = Math.Max(0, variableInitializer.AssignToken.StartLocation.Column + 1 - curIndent.IndentString.Length);
					curIndent.ExtraSpaces += num;
				}
				else
				{
					curIndent.Push(IndentType.Continuation);
					FixIndentation(variableInitializer.Initializer);
				}
				variableInitializer.Initializer.AcceptVisitor(this);
				if (num2)
				{
					curIndent.ExtraSpaces -= num;
				}
				else
				{
					curIndent.Pop();
				}
			}
		}

		public override void VisitComposedType(ComposedType composedType)
		{
			ArraySpecifier arraySpecifier = composedType.ArraySpecifiers.FirstOrDefault();
			if (arraySpecifier != null)
			{
				ForceSpacesBefore(arraySpecifier.LBracketToken, policy.SpaceBeforeArrayDeclarationBrackets);
			}
			if (composedType.HasNullableSpecifier)
			{
				ForceSpacesBefore(composedType.NullableSpecifierToken, forceSpaces: false);
			}
			if (composedType.PointerRank > 0)
			{
				foreach (CSharpTokenNode pointerToken in composedType.PointerTokens)
				{
					ForceSpacesBefore(pointerToken, forceSpaces: false);
				}
			}
			base.VisitComposedType(composedType);
		}

		public override void VisitAnonymousMethodExpression(AnonymousMethodExpression lambdaExpression)
		{
			FormatArguments(lambdaExpression);
			if (!lambdaExpression.Body.IsNull)
			{
				Indent indent = curIndent;
				curIndent = curIndent.GetIndentWithoutSpace();
				FixOpenBrace(policy.AnonymousMethodBraceStyle, lambdaExpression.Body.LBraceToken);
				VisitBlockWithoutFixingBraces(lambdaExpression.Body, policy.IndentBlocks);
				FixClosingBrace(policy.AnonymousMethodBraceStyle, lambdaExpression.Body.RBraceToken);
				curIndent = indent;
			}
		}

		public override void VisitAssignmentExpression(AssignmentExpression assignmentExpression)
		{
			ForceSpacesAround(assignmentExpression.OperatorToken, policy.SpaceAroundAssignment);
			base.VisitAssignmentExpression(assignmentExpression);
		}

		public override void VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
		{
			bool flag = false;
			switch (binaryOperatorExpression.Operator)
			{
			case BinaryOperatorType.Equality:
			case BinaryOperatorType.InEquality:
				flag = policy.SpaceAroundEqualityOperator;
				break;
			case BinaryOperatorType.GreaterThan:
			case BinaryOperatorType.GreaterThanOrEqual:
			case BinaryOperatorType.LessThan:
			case BinaryOperatorType.LessThanOrEqual:
				flag = policy.SpaceAroundRelationalOperator;
				break;
			case BinaryOperatorType.ConditionalAnd:
			case BinaryOperatorType.ConditionalOr:
				flag = policy.SpaceAroundLogicalOperator;
				break;
			case BinaryOperatorType.BitwiseAnd:
			case BinaryOperatorType.BitwiseOr:
			case BinaryOperatorType.ExclusiveOr:
				flag = policy.SpaceAroundBitwiseOperator;
				break;
			case BinaryOperatorType.Add:
			case BinaryOperatorType.Subtract:
				flag = policy.SpaceAroundAdditiveOperator;
				break;
			case BinaryOperatorType.Multiply:
			case BinaryOperatorType.Divide:
			case BinaryOperatorType.Modulus:
				flag = policy.SpaceAroundMultiplicativeOperator;
				break;
			case BinaryOperatorType.ShiftLeft:
			case BinaryOperatorType.ShiftRight:
				flag = policy.SpaceAroundShiftOperator;
				break;
			case BinaryOperatorType.NullCoalescing:
				flag = policy.SpaceAroundNullCoalescingOperator;
				break;
			}
			CSharpTokenNode operatorToken = binaryOperatorExpression.OperatorToken;
			if (operatorToken.PrevSibling != null && operatorToken.PrevSibling.Role != Roles.NewLine)
			{
				ForceSpacesBefore(operatorToken, flag);
			}
			else
			{
				ForceSpacesAfter(binaryOperatorExpression.Left, forceSpaces: false);
				FixIndentation(operatorToken);
			}
			ForceSpacesAfter(operatorToken, (operatorToken.NextSibling != null && operatorToken.NextSibling.Role != Roles.NewLine) & flag);
			binaryOperatorExpression.Left.AcceptVisitor(this);
			if (binaryOperatorExpression.Left.EndLocation.Line != binaryOperatorExpression.Right.StartLocation.Line)
			{
				if (operatorToken.StartLocation.Line == binaryOperatorExpression.Right.StartLocation.Line)
				{
					FixStatementIndentation(operatorToken.StartLocation);
				}
				else
				{
					FixStatementIndentation(binaryOperatorExpression.Right.StartLocation);
				}
			}
			binaryOperatorExpression.Right.AcceptVisitor(this);
		}

		public override void VisitConditionalExpression(ConditionalExpression conditionalExpression)
		{
			ForceSpacesBefore(conditionalExpression.QuestionMarkToken, policy.SpaceBeforeConditionalOperatorCondition);
			ForceSpacesAfter(conditionalExpression.QuestionMarkToken, policy.SpaceAfterConditionalOperatorCondition);
			ForceSpacesBefore(conditionalExpression.ColonToken, policy.SpaceBeforeConditionalOperatorSeparator);
			ForceSpacesAfter(conditionalExpression.ColonToken, policy.SpaceAfterConditionalOperatorSeparator);
			base.VisitConditionalExpression(conditionalExpression);
		}

		public override void VisitCastExpression(CastExpression castExpression)
		{
			if (castExpression.RParToken != null)
			{
				ForceSpacesAfter(castExpression.LParToken, policy.SpacesWithinCastParentheses);
				ForceSpacesBefore(castExpression.RParToken, policy.SpacesWithinCastParentheses);
				ForceSpacesAfter(castExpression.RParToken, policy.SpaceAfterTypecast);
			}
			base.VisitCastExpression(castExpression);
		}

		private void ForceSpacesAround(AstNode node, bool forceSpaces)
		{
			if (!node.IsNull)
			{
				ForceSpacesBefore(node, forceSpaces);
				ForceSpacesAfter(node, forceSpaces);
			}
		}

		private void FormatCommas(AstNode parent, bool before, bool after)
		{
			if (!parent.IsNull)
			{
				foreach (CSharpTokenNode item in from node in parent.Children
					where node.Role == Roles.Comma
					select node)
				{
					ForceSpacesAfter(item, after);
					ForceSpacesBefore(item, before);
				}
			}
		}

		private bool DoWrap(Wrapping wrapping, AstNode wrapNode, int argumentCount)
		{
			if (wrapping != Wrapping.WrapAlways)
			{
				if (options.WrapLineLength > 0 && argumentCount > 1 && wrapping == Wrapping.WrapIfTooLong)
				{
					return wrapNode.StartLocation.Column >= options.WrapLineLength;
				}
				return false;
			}
			return true;
		}

		private void FormatArguments(AstNode node)
		{
			ConstructorDeclaration constructorDeclaration = node as ConstructorDeclaration;
			Wrapping wrapping;
			NewLinePlacement placement;
			NewLinePlacement newLinePlacement;
			bool flag;
			bool flag2;
			bool flag3;
			bool forceSpaces;
			bool flag4;
			CSharpTokenNode cSharpTokenNode;
			CSharpTokenNode cSharpTokenNode2;
			List<AstNode> list;
			if (constructorDeclaration != null)
			{
				wrapping = policy.MethodDeclarationParameterWrapping;
				placement = policy.NewLineAferMethodDeclarationOpenParentheses;
				newLinePlacement = policy.MethodDeclarationClosingParenthesesOnNewLine;
				flag = policy.AlignToFirstMethodDeclarationParameter;
				flag2 = policy.SpaceWithinConstructorDeclarationParentheses;
				flag3 = policy.SpaceAfterConstructorDeclarationParameterComma;
				forceSpaces = policy.SpaceBeforeConstructorDeclarationParameterComma;
				flag4 = policy.SpaceBetweenEmptyMethodDeclarationParentheses;
				cSharpTokenNode = constructorDeclaration.LParToken;
				cSharpTokenNode2 = constructorDeclaration.RParToken;
				list = constructorDeclaration.Parameters.Cast<AstNode>().ToList();
			}
			else if (node is IndexerDeclaration)
			{
				IndexerDeclaration obj = (IndexerDeclaration)node;
				wrapping = policy.IndexerDeclarationParameterWrapping;
				placement = policy.NewLineAferIndexerDeclarationOpenBracket;
				newLinePlacement = policy.IndexerDeclarationClosingBracketOnNewLine;
				flag = policy.AlignToFirstIndexerDeclarationParameter;
				flag2 = policy.SpaceWithinIndexerDeclarationBracket;
				flag3 = policy.SpaceAfterIndexerDeclarationParameterComma;
				forceSpaces = policy.SpaceBeforeIndexerDeclarationParameterComma;
				flag4 = policy.SpaceBetweenEmptyMethodDeclarationParentheses;
				cSharpTokenNode = obj.LBracketToken;
				cSharpTokenNode2 = obj.RBracketToken;
				list = obj.Parameters.Cast<AstNode>().ToList();
			}
			else if (node is OperatorDeclaration)
			{
				OperatorDeclaration obj2 = (OperatorDeclaration)node;
				wrapping = policy.MethodDeclarationParameterWrapping;
				placement = policy.NewLineAferMethodDeclarationOpenParentheses;
				newLinePlacement = policy.MethodDeclarationClosingParenthesesOnNewLine;
				flag = policy.AlignToFirstMethodDeclarationParameter;
				flag2 = policy.SpaceWithinMethodDeclarationParentheses;
				flag3 = policy.SpaceAfterMethodDeclarationParameterComma;
				forceSpaces = policy.SpaceBeforeMethodDeclarationParameterComma;
				flag4 = policy.SpaceBetweenEmptyMethodDeclarationParentheses;
				cSharpTokenNode = obj2.LParToken;
				cSharpTokenNode2 = obj2.RParToken;
				list = obj2.Parameters.Cast<AstNode>().ToList();
			}
			else if (node is MethodDeclaration)
			{
				MethodDeclaration obj3 = node as MethodDeclaration;
				wrapping = policy.MethodDeclarationParameterWrapping;
				placement = policy.NewLineAferMethodDeclarationOpenParentheses;
				newLinePlacement = policy.MethodDeclarationClosingParenthesesOnNewLine;
				flag = policy.AlignToFirstMethodDeclarationParameter;
				flag2 = policy.SpaceWithinMethodDeclarationParentheses;
				flag3 = policy.SpaceAfterMethodDeclarationParameterComma;
				forceSpaces = policy.SpaceBeforeMethodDeclarationParameterComma;
				flag4 = policy.SpaceBetweenEmptyMethodDeclarationParentheses;
				cSharpTokenNode = obj3.LParToken;
				cSharpTokenNode2 = obj3.RParToken;
				list = obj3.Parameters.Cast<AstNode>().ToList();
			}
			else if (node is IndexerExpression)
			{
				IndexerExpression obj4 = (IndexerExpression)node;
				wrapping = policy.IndexerArgumentWrapping;
				placement = policy.NewLineAferIndexerOpenBracket;
				flag = policy.AlignToFirstIndexerArgument;
				newLinePlacement = policy.IndexerClosingBracketOnNewLine;
				flag2 = policy.SpacesWithinBrackets;
				flag3 = policy.SpaceAfterBracketComma;
				flag4 = flag2;
				forceSpaces = policy.SpaceBeforeBracketComma;
				cSharpTokenNode2 = obj4.RBracketToken;
				cSharpTokenNode = obj4.LBracketToken;
				list = obj4.Arguments.Cast<AstNode>().ToList();
			}
			else if (node is ObjectCreateExpression)
			{
				ObjectCreateExpression obj5 = node as ObjectCreateExpression;
				wrapping = policy.MethodCallArgumentWrapping;
				placement = policy.NewLineAferMethodCallOpenParentheses;
				flag = policy.AlignToFirstMethodCallArgument;
				newLinePlacement = policy.MethodCallClosingParenthesesOnNewLine;
				flag2 = policy.SpacesWithinNewParentheses;
				flag3 = policy.SpaceAfterNewParameterComma;
				forceSpaces = policy.SpaceBeforeNewParameterComma;
				flag4 = policy.SpacesBetweenEmptyNewParentheses;
				cSharpTokenNode2 = obj5.RParToken;
				cSharpTokenNode = obj5.LParToken;
				list = obj5.Arguments.Cast<AstNode>().ToList();
			}
			else if (node is Attribute)
			{
				Attribute obj6 = node as Attribute;
				wrapping = policy.MethodCallArgumentWrapping;
				placement = policy.NewLineAferMethodCallOpenParentheses;
				flag = policy.AlignToFirstMethodCallArgument;
				newLinePlacement = policy.MethodCallClosingParenthesesOnNewLine;
				flag2 = policy.SpacesWithinNewParentheses;
				flag3 = policy.SpaceAfterNewParameterComma;
				forceSpaces = policy.SpaceBeforeNewParameterComma;
				flag4 = policy.SpacesBetweenEmptyNewParentheses;
				cSharpTokenNode2 = obj6.RParToken;
				cSharpTokenNode = obj6.LParToken;
				list = obj6.Arguments.Cast<AstNode>().ToList();
			}
			else if (node is LambdaExpression)
			{
				LambdaExpression obj7 = node as LambdaExpression;
				wrapping = policy.MethodDeclarationParameterWrapping;
				placement = policy.NewLineAferMethodDeclarationOpenParentheses;
				newLinePlacement = policy.MethodDeclarationClosingParenthesesOnNewLine;
				flag = policy.AlignToFirstMethodDeclarationParameter;
				flag2 = policy.SpaceWithinMethodDeclarationParentheses;
				flag3 = policy.SpaceAfterMethodDeclarationParameterComma;
				forceSpaces = policy.SpaceBeforeMethodDeclarationParameterComma;
				flag4 = policy.SpaceBetweenEmptyMethodDeclarationParentheses;
				cSharpTokenNode = obj7.LParToken;
				cSharpTokenNode2 = obj7.RParToken;
				list = obj7.Parameters.Cast<AstNode>().ToList();
			}
			else if (node is AnonymousMethodExpression)
			{
				AnonymousMethodExpression obj8 = node as AnonymousMethodExpression;
				wrapping = policy.MethodDeclarationParameterWrapping;
				placement = policy.NewLineAferMethodDeclarationOpenParentheses;
				newLinePlacement = policy.MethodDeclarationClosingParenthesesOnNewLine;
				flag = policy.AlignToFirstMethodDeclarationParameter;
				flag2 = policy.SpaceWithinMethodDeclarationParentheses;
				flag3 = policy.SpaceAfterMethodDeclarationParameterComma;
				forceSpaces = policy.SpaceBeforeMethodDeclarationParameterComma;
				flag4 = policy.SpaceBetweenEmptyMethodDeclarationParentheses;
				cSharpTokenNode = obj8.LParToken;
				cSharpTokenNode2 = obj8.RParToken;
				list = obj8.Parameters.Cast<AstNode>().ToList();
			}
			else if (node is ConstructorInitializer)
			{
				ConstructorInitializer obj9 = node as ConstructorInitializer;
				wrapping = policy.MethodDeclarationParameterWrapping;
				placement = policy.NewLineAferMethodDeclarationOpenParentheses;
				newLinePlacement = policy.MethodDeclarationClosingParenthesesOnNewLine;
				flag = policy.AlignToFirstMethodDeclarationParameter;
				flag2 = policy.SpaceWithinMethodDeclarationParentheses;
				flag3 = policy.SpaceAfterMethodDeclarationParameterComma;
				forceSpaces = policy.SpaceBeforeMethodDeclarationParameterComma;
				flag4 = policy.SpaceBetweenEmptyMethodDeclarationParentheses;
				cSharpTokenNode = obj9.LParToken;
				cSharpTokenNode2 = obj9.RParToken;
				list = obj9.Arguments.Cast<AstNode>().ToList();
			}
			else
			{
				InvocationExpression obj10 = node as InvocationExpression;
				wrapping = policy.MethodCallArgumentWrapping;
				placement = policy.NewLineAferMethodCallOpenParentheses;
				newLinePlacement = policy.MethodCallClosingParenthesesOnNewLine;
				flag = policy.AlignToFirstMethodCallArgument;
				flag2 = policy.SpaceWithinMethodCallParentheses;
				flag3 = policy.SpaceAfterMethodCallParameterComma;
				forceSpaces = policy.SpaceBeforeMethodCallParameterComma;
				flag4 = policy.SpaceBetweenEmptyMethodCallParentheses;
				cSharpTokenNode2 = obj10.RParToken;
				cSharpTokenNode = obj10.LParToken;
				list = obj10.Arguments.Cast<AstNode>().ToList();
			}
			if (formatter.FormattingMode == FormattingMode.OnTheFly)
			{
				wrapping = Wrapping.DoNotChange;
			}
			int count = 1;
			AstNode astNode = list.FirstOrDefault();
			if (astNode != null && astNode.GetPrevNode().Role == Roles.NewLine)
			{
				flag = false;
				count = 0;
			}
			if (DoWrap(wrapping, cSharpTokenNode2, list.Count) && list.Any())
			{
				if (ShouldBreakLine(placement, cSharpTokenNode))
				{
					curIndent.Push(IndentType.Continuation);
					foreach (AstNode item in list)
					{
						FixStatementIndentation(item.StartLocation);
						item.AcceptVisitor(this);
					}
					curIndent.Pop();
				}
				else if (!flag)
				{
					curIndent.Push(IndentType.Continuation);
					foreach (AstNode item2 in list.Take(count))
					{
						FixStatementIndentation(item2.StartLocation);
						item2.AcceptVisitor(this);
					}
					foreach (AstNode item3 in list.Skip(count))
					{
						FixStatementIndentation(item3.StartLocation);
						item3.AcceptVisitor(this);
					}
					curIndent.Pop();
				}
				else
				{
					int num = Math.Max(0, list.First().StartLocation.Column - 1 - curIndent.IndentString.Length);
					curIndent.ExtraSpaces += num;
					foreach (AstNode item4 in list.Take(count))
					{
						item4.AcceptVisitor(this);
					}
					foreach (AstNode item5 in list.Skip(count))
					{
						FixStatementIndentation(item5.StartLocation);
						item5.AcceptVisitor(this);
					}
					curIndent.ExtraSpaces -= num;
				}
				if (!cSharpTokenNode2.IsNull)
				{
					if (ShouldBreakLine(newLinePlacement, cSharpTokenNode2))
					{
						FixStatementIndentation(cSharpTokenNode2.StartLocation);
					}
					else if (newLinePlacement == NewLinePlacement.SameLine)
					{
						ForceSpacesBeforeRemoveNewLines(cSharpTokenNode2, flag2);
					}
				}
			}
			else
			{
				foreach (AstNode item6 in list.Take(count))
				{
					if (policy.IndentBlocksInsideExpressions)
					{
						curIndent.Push(IndentType.Continuation);
					}
					item6.AcceptVisitor(this);
					if (policy.IndentBlocksInsideExpressions)
					{
						curIndent.Pop();
					}
				}
				foreach (AstNode item7 in list.Skip(count))
				{
					if (item7.GetPrevSibling(NoWhitespacePredicate) != null)
					{
						if (wrapping == Wrapping.DoNotWrap)
						{
							ForceSpacesBeforeRemoveNewLines(item7, flag3 && item7.GetPrevSibling(NoWhitespacePredicate).Role == Roles.Comma);
							if (policy.IndentBlocksInsideExpressions)
							{
								curIndent.Push(IndentType.Continuation);
							}
							item7.AcceptVisitor(this);
							if (policy.IndentBlocksInsideExpressions)
							{
								curIndent.Pop();
							}
						}
						else if (!flag && item7.PrevSibling.Role == Roles.NewLine)
						{
							curIndent.Push(IndentType.Continuation);
							FixStatementIndentation(item7.StartLocation);
							item7.AcceptVisitor(this);
							curIndent.Pop();
						}
						else if (item7.PrevSibling.StartLocation.Line == item7.StartLocation.Line)
						{
							ForceSpacesBefore(item7, flag3 && item7.GetPrevSibling(NoWhitespacePredicate).Role == Roles.Comma);
							if (policy.IndentBlocksInsideExpressions)
							{
								curIndent.Push(IndentType.Continuation);
							}
							item7.AcceptVisitor(this);
							if (policy.IndentBlocksInsideExpressions)
							{
								curIndent.Pop();
							}
						}
						else
						{
							int num2 = Math.Max(0, list.First().StartLocation.Column - 1 - curIndent.IndentString.Length);
							curIndent.ExtraSpaces += num2;
							FixStatementIndentation(item7.StartLocation);
							item7.AcceptVisitor(this);
							curIndent.ExtraSpaces -= num2;
						}
					}
					else
					{
						item7.AcceptVisitor(this);
					}
				}
				if (!cSharpTokenNode2.IsNull)
				{
					if (wrapping == Wrapping.DoNotWrap)
					{
						ForceSpacesBeforeRemoveNewLines(cSharpTokenNode2, list.Any() ? flag2 : flag4);
					}
					else if (cSharpTokenNode2.GetPrevNode((AstNode n) => (n.Role != Roles.Argument && n.Role != Roles.Parameter && n.Role != Roles.LPar) ? (n.Role == Roles.Comma) : true).EndLocation.Line == cSharpTokenNode2.StartLocation.Line)
					{
						ForceSpacesBeforeRemoveNewLines(cSharpTokenNode2, list.Any() ? flag2 : flag4);
					}
					else
					{
						FixStatementIndentation(cSharpTokenNode2.StartLocation);
					}
				}
			}
			if (!cSharpTokenNode2.IsNull)
			{
				foreach (CSharpTokenNode item8 in from n in cSharpTokenNode2.Parent.Children
					where n.Role == Roles.Comma
					select n)
				{
					ForceSpacesBefore(item8, forceSpaces);
				}
			}
		}

		public override void VisitInvocationExpression(InvocationExpression invocationExpression)
		{
			if (!invocationExpression.Target.IsNull)
			{
				invocationExpression.Target.AcceptVisitor(this);
			}
			ForceSpacesBefore(invocationExpression.LParToken, policy.SpaceBeforeMethodCallParentheses);
			if (invocationExpression.Arguments.Any())
			{
				ForceSpacesAfter(invocationExpression.LParToken, policy.SpaceWithinMethodCallParentheses);
			}
			else
			{
				ForceSpacesAfter(invocationExpression.LParToken, policy.SpaceBetweenEmptyMethodCallParentheses);
				ForceSpacesBefore(invocationExpression.RParToken, policy.SpaceBetweenEmptyMethodCallParentheses);
			}
			bool flag = false;
			if (invocationExpression.Target is MemberReferenceExpression)
			{
				MemberReferenceExpression memberReferenceExpression = (MemberReferenceExpression)invocationExpression.Target;
				if (memberReferenceExpression.Target is InvocationExpression)
				{
					if (DoWrap(policy.ChainedMethodCallWrapping, memberReferenceExpression.DotToken, 2))
					{
						curIndent.Push(IndentType.Block);
						flag = true;
						FixStatementIndentation(memberReferenceExpression.DotToken.StartLocation);
					}
					else if (policy.ChainedMethodCallWrapping == Wrapping.DoNotWrap)
					{
						ForceSpacesBeforeRemoveNewLines(memberReferenceExpression.DotToken, forceSpace: false);
					}
				}
			}
			FormatArguments(invocationExpression);
			if (flag)
			{
				curIndent.Pop();
			}
		}

		public override void VisitIndexerExpression(IndexerExpression indexerExpression)
		{
			ForceSpacesBeforeRemoveNewLines(indexerExpression.LBracketToken, policy.SpacesBeforeBrackets);
			ForceSpacesAfter(indexerExpression.LBracketToken, policy.SpacesWithinBrackets);
			if (!indexerExpression.Target.IsNull)
			{
				indexerExpression.Target.AcceptVisitor(this);
			}
			FormatArguments(indexerExpression);
		}

		public override void VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression)
		{
			CSharpTokenNode lParToken = parenthesizedExpression.LParToken;
			Expression expression = parenthesizedExpression.Expression;
			int num = 0;
			if (lParToken.StartLocation.Line == expression.StartLocation.Line)
			{
				ForceSpacesAfter(lParToken, policy.SpacesWithinParentheses);
			}
			else
			{
				num += options.IndentSize;
				curIndent.ExtraSpaces += num;
				FixIndentation(expression);
			}
			base.VisitParenthesizedExpression(parenthesizedExpression);
			CSharpTokenNode rParToken = parenthesizedExpression.RParToken;
			curIndent.ExtraSpaces -= num;
			if (rParToken.StartLocation.Line == expression.EndLocation.Line)
			{
				ForceSpacesBefore(rParToken, policy.SpacesWithinParentheses);
			}
			else
			{
				FixIndentation(rParToken);
			}
		}

		public override void VisitSizeOfExpression(SizeOfExpression sizeOfExpression)
		{
			ForceSpacesBeforeRemoveNewLines(sizeOfExpression.LParToken, policy.SpaceBeforeSizeOfParentheses);
			ForceSpacesAfter(sizeOfExpression.LParToken, policy.SpacesWithinSizeOfParentheses);
			ForceSpacesBeforeRemoveNewLines(sizeOfExpression.RParToken, policy.SpacesWithinSizeOfParentheses);
			base.VisitSizeOfExpression(sizeOfExpression);
		}

		public override void VisitTypeOfExpression(TypeOfExpression typeOfExpression)
		{
			ForceSpacesBeforeRemoveNewLines(typeOfExpression.LParToken, policy.SpaceBeforeTypeOfParentheses);
			ForceSpacesAfter(typeOfExpression.LParToken, policy.SpacesWithinTypeOfParentheses);
			ForceSpacesBeforeRemoveNewLines(typeOfExpression.RParToken, policy.SpacesWithinTypeOfParentheses);
			base.VisitTypeOfExpression(typeOfExpression);
		}

		public override void VisitCheckedExpression(CheckedExpression checkedExpression)
		{
			ForceSpacesAfter(checkedExpression.LParToken, policy.SpacesWithinCheckedExpressionParantheses);
			ForceSpacesBeforeRemoveNewLines(checkedExpression.RParToken, policy.SpacesWithinCheckedExpressionParantheses);
			base.VisitCheckedExpression(checkedExpression);
		}

		public override void VisitUncheckedExpression(UncheckedExpression uncheckedExpression)
		{
			ForceSpacesAfter(uncheckedExpression.LParToken, policy.SpacesWithinCheckedExpressionParantheses);
			ForceSpacesBeforeRemoveNewLines(uncheckedExpression.RParToken, policy.SpacesWithinCheckedExpressionParantheses);
			base.VisitUncheckedExpression(uncheckedExpression);
		}

		public override void VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression)
		{
			ForceSpacesBeforeRemoveNewLines(objectCreateExpression.LParToken, policy.SpaceBeforeNewParentheses);
			if (objectCreateExpression.Arguments.Any())
			{
				if (!objectCreateExpression.LParToken.IsNull)
				{
					ForceSpacesAfter(objectCreateExpression.LParToken, policy.SpacesWithinNewParentheses);
				}
			}
			else if (!objectCreateExpression.LParToken.IsNull)
			{
				ForceSpacesAfter(objectCreateExpression.LParToken, policy.SpacesBetweenEmptyNewParentheses);
			}
			if (!objectCreateExpression.Type.IsNull)
			{
				objectCreateExpression.Type.AcceptVisitor(this);
			}
			objectCreateExpression.Initializer.AcceptVisitor(this);
			FormatArguments(objectCreateExpression);
		}

		public override void VisitArrayCreateExpression(ArrayCreateExpression arrayObjectCreateExpression)
		{
			FormatCommas(arrayObjectCreateExpression, policy.SpaceBeforeMethodCallParameterComma, policy.SpaceAfterMethodCallParameterComma);
			base.VisitArrayCreateExpression(arrayObjectCreateExpression);
		}

		public override void VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression)
		{
			Indent indent = curIndent;
			curIndent = curIndent.Clone();
			curIndent.ExtraSpaces = 0;
			if (DoWrap(policy.ArrayInitializerWrapping, arrayInitializerExpression.RBraceToken, arrayInitializerExpression.Elements.Count))
			{
				FixOpenBrace(policy.ArrayInitializerBraceStyle, arrayInitializerExpression.LBraceToken);
				curIndent.Push(IndentType.Block);
				foreach (Expression element in arrayInitializerExpression.Elements)
				{
					FixStatementIndentation(element.StartLocation);
					element.AcceptVisitor(this);
				}
				curIndent.Pop();
				FixClosingBrace(policy.ArrayInitializerBraceStyle, arrayInitializerExpression.RBraceToken);
			}
			else if (policy.ArrayInitializerWrapping == Wrapping.DoNotWrap)
			{
				ForceSpacesBeforeRemoveNewLines(arrayInitializerExpression.LBraceToken);
				foreach (Expression element2 in arrayInitializerExpression.Elements)
				{
					ForceSpacesBeforeRemoveNewLines(element2);
					element2.AcceptVisitor(this);
				}
				ForceSpacesBeforeRemoveNewLines(arrayInitializerExpression.RBraceToken);
			}
			else
			{
				CSharpTokenNode lBraceToken = arrayInitializerExpression.LBraceToken;
				CSharpTokenNode rBraceToken = arrayInitializerExpression.RBraceToken;
				foreach (AstNode child in arrayInitializerExpression.Children)
				{
					if (child.Role == Roles.LBrace)
					{
						if (lBraceToken.StartLocation.Line == rBraceToken.StartLocation.Line && policy.AllowOneLinedArrayInitialziers)
						{
							ForceSpacesAfter(child, forceSpaces: true);
						}
						else
						{
							FixOpenBrace(policy.ArrayInitializerBraceStyle, child);
						}
						curIndent.Push(IndentType.Block);
					}
					else if (child.Role == Roles.RBrace)
					{
						curIndent.Pop();
						if (lBraceToken.StartLocation.Line == rBraceToken.StartLocation.Line && policy.AllowOneLinedArrayInitialziers)
						{
							ForceSpaceBefore(child, forceSpace: true);
						}
						else
						{
							FixClosingBrace(policy.ArrayInitializerBraceStyle, child);
						}
					}
					else if (child.Role == Roles.Expression)
					{
						if (child.PrevSibling != null)
						{
							if (child.PrevSibling.Role == Roles.NewLine)
							{
								FixIndentation(child);
							}
							if (child.PrevSibling.Role == Roles.Comma)
							{
								ForceSpaceBefore(child, forceSpace: true);
							}
						}
						child.AcceptVisitor(this);
						if (child.NextSibling != null && child.NextSibling.Role == Roles.Comma)
						{
							ForceSpacesAfter(child, forceSpaces: false);
						}
					}
					else
					{
						child.AcceptVisitor(this);
					}
				}
			}
			curIndent = indent;
		}

		public override void VisitParameterDeclaration(ParameterDeclaration parameterDeclaration)
		{
			CSharpTokenNode assignToken = parameterDeclaration.AssignToken;
			if (!assignToken.IsNull)
			{
				ForceSpacesAround(assignToken, policy.SpaceAroundAssignment);
			}
			base.VisitParameterDeclaration(parameterDeclaration);
		}

		public override void VisitLambdaExpression(LambdaExpression lambdaExpression)
		{
			FormatArguments(lambdaExpression);
			ForceSpacesBeforeRemoveNewLines(lambdaExpression.ArrowToken);
			if (!lambdaExpression.Body.IsNull)
			{
				BlockStatement blockStatement = lambdaExpression.Body as BlockStatement;
				if (blockStatement != null)
				{
					Indent indent = curIndent;
					curIndent = curIndent.GetIndentWithoutSpace();
					FixOpenBrace(policy.AnonymousMethodBraceStyle, blockStatement.LBraceToken);
					VisitBlockWithoutFixingBraces(blockStatement, policy.IndentMethodBody);
					FixClosingBrace(policy.AnonymousMethodBraceStyle, blockStatement.RBraceToken);
					curIndent = indent;
				}
				else
				{
					ForceSpacesAfter(lambdaExpression.ArrowToken, forceSpaces: true);
					lambdaExpression.Body.AcceptVisitor(this);
				}
			}
		}

		public override void VisitNamedExpression(NamedExpression namedExpression)
		{
			ForceSpacesAround(namedExpression.AssignToken, policy.SpaceAroundAssignment);
			base.VisitNamedExpression(namedExpression);
		}

		public override void VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression)
		{
			ForceSpacesAfter(namedArgumentExpression.ColonToken, policy.SpaceInNamedArgumentAfterDoubleColon);
			base.VisitNamedArgumentExpression(namedArgumentExpression);
		}

		public override void VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
		{
			CSharpTokenNode dotToken = memberReferenceExpression.DotToken;
			if (dotToken.PrevSibling.EndLocation.Line == dotToken.StartLocation.Line)
			{
				ForceSpacesBefore(dotToken, forceSpaces: false);
			}
			ForceSpacesAfter(dotToken, forceSpaces: false);
			base.VisitMemberReferenceExpression(memberReferenceExpression);
		}

		public override void VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression)
		{
			ForceSpacesAround(pointerReferenceExpression.ArrowToken, policy.SpaceAroundUnsafeArrowOperator);
			base.VisitPointerReferenceExpression(pointerReferenceExpression);
		}

		public override void VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression)
		{
			base.VisitUnaryOperatorExpression(unaryOperatorExpression);
			switch (unaryOperatorExpression.Operator)
			{
			case UnaryOperatorType.Any:
				break;
			case UnaryOperatorType.Not:
			case UnaryOperatorType.BitNot:
			case UnaryOperatorType.Minus:
			case UnaryOperatorType.Plus:
			case UnaryOperatorType.Increment:
			case UnaryOperatorType.Decrement:
				ForceSpacesBeforeRemoveNewLines(unaryOperatorExpression.Expression, forceSpace: false);
				break;
			case UnaryOperatorType.PostIncrement:
			case UnaryOperatorType.PostDecrement:
				ForceSpacesBeforeRemoveNewLines(unaryOperatorExpression.OperatorToken, forceSpace: false);
				break;
			case UnaryOperatorType.Dereference:
				ForceSpacesAfter(unaryOperatorExpression.OperatorToken, policy.SpaceAfterUnsafeAsteriskOfOperator);
				break;
			case UnaryOperatorType.AddressOf:
				ForceSpacesAfter(unaryOperatorExpression.OperatorToken, policy.SpaceAfterUnsafeAddressOfOperator);
				break;
			case UnaryOperatorType.Await:
				ForceSpacesBeforeRemoveNewLines(unaryOperatorExpression.Expression);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private int GetUpdatedStartLocation(QueryExpression queryExpression)
		{
			return queryExpression.StartLocation.Column;
		}

		public override void VisitQueryExpression(QueryExpression queryExpression)
		{
			Indent indent = curIndent.Clone();
			int num = GetUpdatedStartLocation(queryExpression) - 1 - curIndent.CurIndent / options.TabSize;
			if (num < 0)
			{
				num = 0;
			}
			curIndent.ExtraSpaces = num;
			VisitChildren(queryExpression);
			curIndent = indent;
		}

		public override void VisitQueryFromClause(QueryFromClause queryFromClause)
		{
			FixClauseIndentation(queryFromClause, queryFromClause.FromKeyword);
		}

		public override void VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause)
		{
			VisitChildren(queryContinuationClause);
		}

		public override void VisitQueryGroupClause(QueryGroupClause queryGroupClause)
		{
			FixClauseIndentation(queryGroupClause, queryGroupClause.GroupKeyword);
		}

		public override void VisitQueryJoinClause(QueryJoinClause queryJoinClause)
		{
			FixClauseIndentation(queryJoinClause, queryJoinClause.JoinKeyword);
		}

		public override void VisitQueryLetClause(QueryLetClause queryLetClause)
		{
			FixClauseIndentation(queryLetClause, queryLetClause.LetKeyword);
		}

		public override void VisitQuerySelectClause(QuerySelectClause querySelectClause)
		{
			FixClauseIndentation(querySelectClause, querySelectClause.SelectKeyword);
		}

		public override void VisitQueryOrderClause(QueryOrderClause queryOrderClause)
		{
			FixClauseIndentation(queryOrderClause, queryOrderClause.OrderbyToken);
		}

		public override void VisitQueryWhereClause(QueryWhereClause queryWhereClause)
		{
			FixClauseIndentation(queryWhereClause, queryWhereClause.WhereKeyword);
		}

		private void FixClauseIndentation(QueryClause clause, AstNode keyword)
		{
			if (clause.GetParent<QueryExpression>().Clauses.First() != clause)
			{
				PlaceOnNewLine(policy.NewLineBeforeNewQueryClause, keyword);
			}
			int indentSize = options.IndentSize;
			curIndent.ExtraSpaces += indentSize;
			foreach (AstNode child in clause.Children)
			{
				if (child is Expression)
				{
					FixIndentation(child);
					child.AcceptVisitor(this);
				}
				CSharpTokenNode cSharpTokenNode = child as CSharpTokenNode;
				if (cSharpTokenNode != null && cSharpTokenNode.GetNextSibling(NoWhitespacePredicate).StartLocation.Line != cSharpTokenNode.EndLocation.Line)
				{
					ForceSpacesAfter(cSharpTokenNode, forceSpaces: false);
				}
			}
			curIndent.ExtraSpaces -= indentSize;
		}
	}
}
