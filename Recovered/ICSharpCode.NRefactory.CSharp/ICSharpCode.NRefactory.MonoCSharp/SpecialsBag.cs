#define FULL_AST
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class SpecialsBag
	{
		public enum CommentType
		{
			Single,
			Multi,
			Documentation,
			InactiveCode
		}

		public class SpecialVisitor
		{
			public virtual void Visit(Comment comment)
			{
			}

			public virtual void Visit(NewLineToken newLineToken)
			{
			}

			public virtual void Visit(PreProcessorDirective preProcessorDirective)
			{
			}
		}

		public abstract class SpecialBase
		{
			public abstract void Accept(SpecialVisitor visitor);
		}

		public class Comment : SpecialBase
		{
			public readonly CommentType CommentType;

			public readonly bool StartsLine;

			public readonly int Line;

			public readonly int Col;

			public readonly int EndLine;

			public readonly int EndCol;

			public readonly string Content;

			public Comment(CommentType commentType, bool startsLine, int line, int col, int endLine, int endCol, string content)
			{
				CommentType = commentType;
				StartsLine = startsLine;
				Line = line;
				Col = col;
				EndLine = endLine;
				EndCol = endCol;
				Content = content;
			}

			public override string ToString()
			{
				return $"[Comment: CommentType={CommentType}, Line={Line}, Col={Col}, EndLine={EndLine}, EndCol={EndCol}, Content={Content}]";
			}

			public override void Accept(SpecialVisitor visitor)
			{
				visitor.Visit(this);
			}
		}

		public class NewLineToken : SpecialBase
		{
			public readonly int Line;

			public readonly int Col;

			public readonly NewLine NewLine;

			public NewLineToken(int line, int col, NewLine newLine)
			{
				Line = line;
				Col = col;
				NewLine = newLine;
			}

			public override void Accept(SpecialVisitor visitor)
			{
				visitor.Visit(this);
			}
		}

		public class PragmaPreProcessorDirective : PreProcessorDirective
		{
			public List<Constant> Codes = new List<Constant>();

			public bool Disalbe
			{
				get;
				set;
			}

			public int WarningColumn
			{
				get;
				set;
			}

			public int DisableRestoreColumn
			{
				get;
				set;
			}

			public PragmaPreProcessorDirective(int line, int col, int endLine, int endCol, Tokenizer.PreprocessorDirective cmd, string arg)
				: base(line, col, endLine, endCol, cmd, arg)
			{
			}
		}

		public class LineProcessorDirective : PreProcessorDirective
		{
			public int LineNumber
			{
				get;
				set;
			}

			public string FileName
			{
				get;
				set;
			}

			public LineProcessorDirective(int line, int col, int endLine, int endCol, Tokenizer.PreprocessorDirective cmd, string arg)
				: base(line, col, endLine, endCol, cmd, arg)
			{
			}
		}

		public class PreProcessorDirective : SpecialBase
		{
			public readonly int Line;

			public readonly int Col;

			public readonly int EndLine;

			public readonly int EndCol;

			public readonly Tokenizer.PreprocessorDirective Cmd;

			public readonly string Arg;

			public bool Take = true;

			public PreProcessorDirective(int line, int col, int endLine, int endCol, Tokenizer.PreprocessorDirective cmd, string arg)
			{
				Line = line;
				Col = col;
				EndLine = endLine;
				EndCol = endCol;
				Cmd = cmd;
				Arg = arg;
			}

			public override void Accept(SpecialVisitor visitor)
			{
				visitor.Visit(this);
			}

			public override string ToString()
			{
				return $"[PreProcessorDirective: Line={Line}, Col={Col}, EndLine={EndLine}, EndCol={EndCol}, Cmd={Cmd}, Arg={Arg}]";
			}
		}

		public enum NewLine
		{
			Unix,
			Windows
		}

		public readonly List<SpecialBase> Specials = new List<SpecialBase>();

		private CommentType curComment;

		private bool startsLine;

		private int startLine;

		private int startCol;

		private StringBuilder contentBuilder = new StringBuilder();

		private bool inComment;

		private int lastNewLine = -1;

		private int lastNewCol = -1;

		public bool Suppress
		{
			get;
			set;
		}

		[Conditional("FULL_AST")]
		public void StartComment(CommentType type, bool startsLine, int startLine, int startCol)
		{
			if (!Suppress)
			{
				inComment = true;
				curComment = type;
				this.startsLine = startsLine;
				this.startLine = startLine;
				this.startCol = startCol;
				contentBuilder.Length = 0;
			}
		}

		[Conditional("FULL_AST")]
		public void PushCommentChar(int ch)
		{
			if (!Suppress && ch >= 0)
			{
				contentBuilder.Append((char)ch);
			}
		}

		[Conditional("FULL_AST")]
		public void PushCommentString(string str)
		{
			if (!Suppress)
			{
				contentBuilder.Append(str);
			}
		}

		[Conditional("FULL_AST")]
		public void EndComment(int endLine, int endColumn)
		{
			if (!Suppress && inComment)
			{
				inComment = false;
				if (startLine != endLine || startCol != endColumn)
				{
					Specials.Add(new Comment(curComment, startsLine, startLine, startCol, endLine, endColumn, contentBuilder.ToString()));
				}
			}
		}

		[Conditional("FULL_AST")]
		public void AddPreProcessorDirective(int startLine, int startCol, int endLine, int endColumn, Tokenizer.PreprocessorDirective cmd, string arg)
		{
			if (!Suppress)
			{
				if (inComment)
				{
					EndComment(startLine, startCol);
				}
				switch (cmd)
				{
				case Tokenizer.PreprocessorDirective.Pragma:
					Specials.Add(new PragmaPreProcessorDirective(startLine, startCol, endLine, endColumn, cmd, arg));
					break;
				case Tokenizer.PreprocessorDirective.Line:
					Specials.Add(new LineProcessorDirective(startLine, startCol, endLine, endColumn, cmd, arg));
					break;
				default:
					Specials.Add(new PreProcessorDirective(startLine, startCol, endLine, endColumn, cmd, arg));
					break;
				}
			}
		}

		public PragmaPreProcessorDirective SetPragmaDisable(bool disable)
		{
			if (Suppress)
			{
				return null;
			}
			PragmaPreProcessorDirective pragmaPreProcessorDirective = Specials[Specials.Count - 1] as PragmaPreProcessorDirective;
			if (pragmaPreProcessorDirective == null)
			{
				return null;
			}
			pragmaPreProcessorDirective.Disalbe = disable;
			return pragmaPreProcessorDirective;
		}

		public PragmaPreProcessorDirective GetPragmaPreProcessorDirective()
		{
			if (Suppress)
			{
				return null;
			}
			return Specials[Specials.Count - 1] as PragmaPreProcessorDirective;
		}

		public LineProcessorDirective GetCurrentLineProcessorDirective()
		{
			if (Suppress)
			{
				return null;
			}
			return Specials[Specials.Count - 1] as LineProcessorDirective;
		}

		[Conditional("FULL_AST")]
		public void AddNewLine(int line, int col, NewLine newLine)
		{
			if (!Suppress && (line != lastNewLine || col != lastNewCol))
			{
				lastNewLine = line;
				lastNewCol = col;
				Specials.Add(new NewLineToken(line, col, newLine));
			}
		}

		public void SkipIf()
		{
			if (Specials.Count > 0)
			{
				PreProcessorDirective preProcessorDirective = Specials[Specials.Count - 1] as PreProcessorDirective;
				if (preProcessorDirective != null)
				{
					preProcessorDirective.Take = false;
				}
			}
		}
	}
}
