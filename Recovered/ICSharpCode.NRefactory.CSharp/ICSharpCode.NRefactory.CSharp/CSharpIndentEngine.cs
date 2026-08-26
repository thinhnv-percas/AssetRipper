using ICSharpCode.NRefactory.Editor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICSharpCode.NRefactory.CSharp
{
	public class CSharpIndentEngine : IStateMachineIndentEngine, IDocumentIndentEngine, ICloneable
	{
		internal readonly CSharpFormattingOptions formattingOptions;

		internal readonly TextEditorOptions textEditorOptions;

		internal readonly IDocument document;

		internal readonly char newLineChar;

		internal IndentState currentState;

		internal HashSet<string> conditionalSymbols;

		internal HashSet<string> customConditionalSymbols;

		internal CloneableStack<bool> ifDirectiveEvalResults = new CloneableStack<bool>();

		internal CloneableStack<Indent> ifDirectiveIndents = new CloneableStack<Indent>();

		internal StringBuilder wordToken;

		internal string previousKeyword;

		internal int offset;

		internal int line = 1;

		internal int column = 1;

		internal bool isLineStart = true;

		internal bool isLineStartBeforeWordToken = true;

		internal char currentChar;

		internal char previousChar;

		internal char previousNewline;

		internal StringBuilder currentIndent = new StringBuilder();

		internal bool lineBeganInsideVerbatimString;

		internal bool lineBeganInsideMultiLineComment;

		public IDocument Document => document;

		public string ThisLineIndent => currentState.ThisLineIndent.IndentString;

		public string NextLineIndent => currentState.NextLineIndent.IndentString;

		public string CurrentIndent => currentIndent.ToString();

		public bool NeedsReindent
		{
			get
			{
				if (Location.Column == 1)
				{
					return ThisLineIndent.Length > 0;
				}
				if (isLineStart)
				{
					return false;
				}
				return ThisLineIndent != CurrentIndent.ToString();
			}
		}

		public int Offset => offset;

		public TextLocation Location => new TextLocation(line, column);

		public bool EnableCustomIndentLevels
		{
			get;
			set;
		}

		public bool IsInsidePreprocessorDirective => currentState is PreProcessorState;

		public bool IsInsidePreprocessorComment => currentState is PreProcessorCommentState;

		public bool IsInsideStringLiteral => currentState is StringLiteralState;

		public bool IsInsideVerbatimString => currentState is VerbatimStringState;

		public bool IsInsideCharacter => currentState is CharacterState;

		public bool IsInsideString
		{
			get
			{
				if (!IsInsideStringLiteral && !IsInsideVerbatimString)
				{
					return IsInsideCharacter;
				}
				return true;
			}
		}

		public bool IsInsideLineComment => currentState is LineCommentState;

		public bool IsInsideMultiLineComment => currentState is MultiLineCommentState;

		public bool IsInsideDocLineComment => currentState is DocCommentState;

		public bool IsInsideComment
		{
			get
			{
				if (!IsInsideLineComment && !IsInsideMultiLineComment)
				{
					return IsInsideDocLineComment;
				}
				return true;
			}
		}

		public bool IsInsideOrdinaryComment
		{
			get
			{
				if (!IsInsideLineComment)
				{
					return IsInsideMultiLineComment;
				}
				return true;
			}
		}

		public bool IsInsideOrdinaryCommentOrString
		{
			get
			{
				if (!IsInsideOrdinaryComment)
				{
					return IsInsideString;
				}
				return true;
			}
		}

		public bool LineBeganInsideVerbatimString => lineBeganInsideVerbatimString;

		public bool LineBeganInsideMultiLineComment => lineBeganInsideMultiLineComment;

		public CSharpIndentEngine(IDocument document, TextEditorOptions textEditorOptions, CSharpFormattingOptions formattingOptions)
		{
			this.formattingOptions = formattingOptions;
			this.textEditorOptions = textEditorOptions;
			this.document = document;
			currentState = new GlobalBodyState(this);
			conditionalSymbols = new HashSet<string>();
			customConditionalSymbols = new HashSet<string>();
			wordToken = new StringBuilder();
			previousKeyword = string.Empty;
			newLineChar = textEditorOptions.EolMarker[0];
		}

		public CSharpIndentEngine(CSharpIndentEngine prototype)
		{
			formattingOptions = prototype.formattingOptions;
			textEditorOptions = prototype.textEditorOptions;
			document = prototype.document;
			newLineChar = prototype.newLineChar;
			currentState = prototype.currentState.Clone(this);
			conditionalSymbols = new HashSet<string>(prototype.conditionalSymbols);
			customConditionalSymbols = new HashSet<string>(prototype.customConditionalSymbols);
			wordToken = new StringBuilder(prototype.wordToken.ToString());
			previousKeyword = string.Copy(prototype.previousKeyword);
			offset = prototype.offset;
			line = prototype.line;
			column = prototype.column;
			isLineStart = prototype.isLineStart;
			isLineStartBeforeWordToken = prototype.isLineStartBeforeWordToken;
			currentChar = prototype.currentChar;
			previousChar = prototype.previousChar;
			previousNewline = prototype.previousNewline;
			currentIndent = new StringBuilder(prototype.CurrentIndent.ToString());
			lineBeganInsideMultiLineComment = prototype.lineBeganInsideMultiLineComment;
			lineBeganInsideVerbatimString = prototype.lineBeganInsideVerbatimString;
			ifDirectiveEvalResults = prototype.ifDirectiveEvalResults.Clone();
			ifDirectiveIndents = prototype.ifDirectiveIndents.Clone();
			EnableCustomIndentLevels = prototype.EnableCustomIndentLevels;
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		IDocumentIndentEngine IDocumentIndentEngine.Clone()
		{
			return Clone();
		}

		public IStateMachineIndentEngine Clone()
		{
			return new CSharpIndentEngine(this);
		}

		public void Push(char ch)
		{
			if (((wordToken.Length == 0) ? char.IsLetter(ch) : char.IsLetterOrDigit(ch)) || ch == '_')
			{
				wordToken.Append(ch);
			}
			else if (wordToken.Length > 0)
			{
				currentState.CheckKeyword(wordToken.ToString());
				previousKeyword = wordToken.ToString();
				wordToken.Length = 0;
				isLineStartBeforeWordToken = false;
			}
			if (!NewLine.IsNewLine(ch))
			{
				currentState.Push(currentChar = ch);
				offset++;
				previousNewline = '\0';
				if (currentChar != ' ' && currentChar != '\t')
				{
					previousChar = currentChar;
					isLineStart = false;
				}
				if (isLineStart)
				{
					currentIndent.Append(ch);
				}
				if (ch == '\t')
				{
					int num = (column - 1 + textEditorOptions.IndentSize) / textEditorOptions.IndentSize;
					column = 1 + num * textEditorOptions.IndentSize;
				}
				else
				{
					column++;
				}
			}
			else if (ch == '\n' && previousNewline == '\r')
			{
				offset++;
			}
			else
			{
				currentState.Push(currentChar = newLineChar);
				offset++;
				previousNewline = ch;
				if (currentChar == newLineChar)
				{
					currentIndent.Length = 0;
					isLineStart = true;
					isLineStartBeforeWordToken = true;
					column = 1;
					line++;
					lineBeganInsideMultiLineComment = IsInsideMultiLineComment;
					lineBeganInsideVerbatimString = IsInsideVerbatimString;
				}
			}
		}

		public void Reset()
		{
			currentState = new GlobalBodyState(this);
			conditionalSymbols.Clear();
			ifDirectiveEvalResults.Clear();
			ifDirectiveIndents.Clear();
			offset = 0;
			line = 1;
			column = 1;
			isLineStart = true;
			currentChar = '\0';
			previousChar = '\0';
			currentIndent.Length = 0;
			lineBeganInsideMultiLineComment = false;
			lineBeganInsideVerbatimString = false;
		}

		public void Update(int offset)
		{
			if (Offset > offset)
			{
				Reset();
			}
			while (Offset < offset)
			{
				Push(Document.GetCharAt(Offset));
			}
		}

		public void DefineSymbol(string defineSymbol)
		{
			if (!customConditionalSymbols.Contains(defineSymbol))
			{
				customConditionalSymbols.Add(defineSymbol);
			}
		}

		public void RemoveSymbol(string undefineSymbol)
		{
			if (customConditionalSymbols.Contains(undefineSymbol))
			{
				customConditionalSymbols.Remove(undefineSymbol);
			}
		}
	}
}
