using ICSharpCode.NRefactory.Editor;
using System;
using System.Text;

namespace ICSharpCode.NRefactory.CSharp
{
	public class TextPasteIndentEngine : IDocumentIndentEngine, ICloneable, ITextPasteHandler
	{
		private IStateMachineIndentEngine engine;

		internal readonly TextEditorOptions textEditorOptions;

		internal readonly CSharpFormattingOptions formattingOptions;

		public IDocument Document => engine.Document;

		public string ThisLineIndent => engine.ThisLineIndent;

		public string NextLineIndent => engine.NextLineIndent;

		public string CurrentIndent => engine.CurrentIndent;

		public bool NeedsReindent => engine.NeedsReindent;

		public int Offset => engine.Offset;

		public TextLocation Location => engine.Location;

		public bool EnableCustomIndentLevels
		{
			get
			{
				return engine.EnableCustomIndentLevels;
			}
			set
			{
				engine.EnableCustomIndentLevels = value;
			}
		}

		public TextPasteIndentEngine(IStateMachineIndentEngine decoratedEngine, TextEditorOptions textEditorOptions, CSharpFormattingOptions formattingOptions)
		{
			engine = decoratedEngine;
			this.textEditorOptions = textEditorOptions;
			this.formattingOptions = formattingOptions;
			engine.EnableCustomIndentLevels = false;
		}

		string ITextPasteHandler.FormatPlainText(int offset, string text, byte[] copyData)
		{
			if (copyData != null && copyData.Length == 1)
			{
				text = TextPasteUtils.Strategies[(PasteStrategy)copyData[0]].Decode(text);
			}
			engine.Update(offset);
			if (engine.IsInsideStringLiteral)
			{
				int num = text.IndexOf('"');
				if (num > 0)
				{
					int num2 = offset;
					while (num2 < engine.Document.TextLength)
					{
						char charAt = engine.Document.GetCharAt(num2);
						engine.Push(charAt);
						if (NewLine.IsNewLine(charAt))
						{
							break;
						}
						num2++;
						if (!engine.IsInsideStringLiteral)
						{
							return TextPasteUtils.StringLiteralStrategy.Encode(text);
						}
					}
					return TextPasteUtils.StringLiteralStrategy.Encode(text.Substring(0, num)) + text.Substring(num);
				}
				return TextPasteUtils.StringLiteralStrategy.Encode(text);
			}
			if (engine.IsInsideVerbatimString)
			{
				int num3 = text.IndexOf('"');
				if (num3 > 0)
				{
					int num4 = offset;
					while (num4 < engine.Document.TextLength)
					{
						char charAt2 = engine.Document.GetCharAt(num4);
						engine.Push(charAt2);
						num4++;
						if (!engine.IsInsideVerbatimString)
						{
							return TextPasteUtils.VerbatimStringStrategy.Encode(text);
						}
					}
					return TextPasteUtils.VerbatimStringStrategy.Encode(text.Substring(0, num3)) + text.Substring(num3);
				}
				return TextPasteUtils.VerbatimStringStrategy.Encode(text);
			}
			bool flag = engine.Document.GetLineByOffset(offset).Offset == offset;
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			IStateMachineIndentEngine stateMachineIndentEngine = engine.Clone();
			bool flag2 = false;
			bool flag3 = false;
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				if (stateMachineIndentEngine.IsInsideVerbatimString || stateMachineIndentEngine.IsInsideMultiLineComment)
				{
					stateMachineIndentEngine.Push(c);
					stringBuilder2.Append(c);
					continue;
				}
				int delimiterLength = NewLine.GetDelimiterLength(c, (i + 1 < text.Length) ? text[i + 1] : ' ');
				if (delimiterLength > 0)
				{
					flag2 = true;
					if ((flag3 | flag) && (stringBuilder2.Length > 0 || formattingOptions.EmptyLineFormatting == EmptyLineFormatting.Indent))
					{
						stringBuilder.Append(stateMachineIndentEngine.ThisLineIndent);
					}
					stringBuilder.Append(stringBuilder2);
					stringBuilder.Append(textEditorOptions.EolMarker);
					stringBuilder2.Length = 0;
					flag3 = true;
					i += delimiterLength - 1;
					stateMachineIndentEngine.Push(textEditorOptions.EolMarker[0]);
				}
				else
				{
					if (flag2)
					{
						if (c == '\t' || c == ' ')
						{
							stateMachineIndentEngine.Push(c);
							continue;
						}
						flag2 = false;
					}
					stringBuilder2.Append(c);
					stateMachineIndentEngine.Push(c);
				}
				if (stateMachineIndentEngine.IsInsideVerbatimString || (stateMachineIndentEngine.IsInsideMultiLineComment && !stateMachineIndentEngine.LineBeganInsideVerbatimString && !stateMachineIndentEngine.LineBeganInsideMultiLineComment))
				{
					if (flag3 && (stringBuilder2.Length > 0 || formattingOptions.EmptyLineFormatting == EmptyLineFormatting.Indent))
					{
						stringBuilder.Append(stateMachineIndentEngine.ThisLineIndent);
					}
					flag = false;
					stringBuilder.Append(stringBuilder2);
					stringBuilder2.Length = 0;
					flag3 = false;
				}
			}
			if (flag3 && (!flag || stringBuilder2.Length > 0))
			{
				stringBuilder.Append(stateMachineIndentEngine.ThisLineIndent);
			}
			if (stringBuilder2.Length > 0)
			{
				stringBuilder.Append(stringBuilder2);
			}
			return stringBuilder.ToString();
		}

		byte[] ITextPasteHandler.GetCopyData(ISegment segment)
		{
			engine.Update(segment.Offset);
			if (engine.IsInsideStringLiteral)
			{
				return new byte[1]
				{
					1
				};
			}
			if (engine.IsInsideVerbatimString)
			{
				return new byte[1]
				{
					2
				};
			}
			return null;
		}

		public void Push(char ch)
		{
			engine.Push(ch);
		}

		public void Reset()
		{
			engine.Reset();
		}

		public void Update(int offset)
		{
			engine.Update(offset);
		}

		public IDocumentIndentEngine Clone()
		{
			return new TextPasteIndentEngine(engine, textEditorOptions, formattingOptions);
		}

		object ICloneable.Clone()
		{
			return Clone();
		}
	}
}
