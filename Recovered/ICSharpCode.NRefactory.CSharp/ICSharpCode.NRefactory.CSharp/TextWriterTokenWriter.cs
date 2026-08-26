using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace ICSharpCode.NRefactory.CSharp
{
	public class TextWriterTokenWriter : TokenWriter, ILocatable
	{
		private readonly TextWriter textWriter;

		private int indentation;

		private bool needsIndent = true;

		private bool isAtStartOfLine = true;

		private int line;

		private int column;

		public int Indentation
		{
			get
			{
				return indentation;
			}
			set
			{
				indentation = value;
			}
		}

		public TextLocation Location => new TextLocation(line, column + (needsIndent ? (indentation * IndentationString.Length) : 0));

		public string IndentationString
		{
			get;
			set;
		}

		public TextWriterTokenWriter(TextWriter textWriter)
		{
			if (textWriter == null)
			{
				throw new ArgumentNullException("textWriter");
			}
			this.textWriter = textWriter;
			IndentationString = "\t";
			line = 1;
			column = 1;
		}

		public override void WriteIdentifier(Identifier identifier)
		{
			WriteIndentation();
			if (identifier.IsVerbatim || CSharpOutputVisitor.IsKeyword(identifier.Name, identifier))
			{
				textWriter.Write('@');
				column++;
			}
			textWriter.Write(identifier.Name);
			column += identifier.Name.Length;
			isAtStartOfLine = false;
		}

		public override void WriteKeyword(Role role, string keyword)
		{
			WriteIndentation();
			column += keyword.Length;
			textWriter.Write(keyword);
			isAtStartOfLine = false;
		}

		public override void WriteToken(Role role, string token)
		{
			WriteIndentation();
			column += token.Length;
			textWriter.Write(token);
			isAtStartOfLine = false;
		}

		public override void Space()
		{
			WriteIndentation();
			column++;
			textWriter.Write(' ');
		}

		protected void WriteIndentation()
		{
			if (needsIndent)
			{
				needsIndent = false;
				for (int i = 0; i < indentation; i++)
				{
					textWriter.Write(IndentationString);
				}
				column += indentation * IndentationString.Length;
			}
		}

		public override void NewLine()
		{
			textWriter.WriteLine();
			column = 1;
			line++;
			needsIndent = true;
			isAtStartOfLine = true;
		}

		public override void Indent()
		{
			indentation++;
		}

		public override void Unindent()
		{
			indentation--;
		}

		public override void WriteComment(CommentType commentType, string content)
		{
			WriteIndentation();
			switch (commentType)
			{
			case CommentType.SingleLine:
				textWriter.Write("//");
				textWriter.WriteLine(content);
				column += 2 + content.Length;
				needsIndent = true;
				isAtStartOfLine = true;
				break;
			case CommentType.MultiLine:
				textWriter.Write("/*");
				textWriter.Write(content);
				textWriter.Write("*/");
				column += 2;
				UpdateEndLocation(content, ref line, ref column);
				column += 2;
				isAtStartOfLine = false;
				break;
			case CommentType.Documentation:
				textWriter.Write("///");
				textWriter.WriteLine(content);
				column += 3 + content.Length;
				needsIndent = true;
				isAtStartOfLine = true;
				break;
			case CommentType.MultiLineDocumentation:
				textWriter.Write("/**");
				textWriter.Write(content);
				textWriter.Write("*/");
				column += 3;
				UpdateEndLocation(content, ref line, ref column);
				column += 2;
				isAtStartOfLine = false;
				break;
			default:
				textWriter.Write(content);
				column += content.Length;
				break;
			}
		}

		private static void UpdateEndLocation(string content, ref int line, ref int column)
		{
			if (string.IsNullOrEmpty(content))
			{
				return;
			}
			for (int i = 0; i < content.Length; column++, i++)
			{
				char c = content[i];
				if (c != '\n')
				{
					if (c != '\r')
					{
						continue;
					}
					if (i + 1 < content.Length && content[i + 1] == '\n')
					{
						i++;
					}
				}
				line++;
				column = 0;
			}
		}

		public override void WritePreProcessorDirective(PreProcessorDirectiveType type, string argument)
		{
			if (!isAtStartOfLine)
			{
				NewLine();
			}
			WriteIndentation();
			textWriter.Write('#');
			string text = type.ToString().ToLowerInvariant();
			textWriter.Write(text);
			column += 1 + text.Length;
			if (!string.IsNullOrEmpty(argument))
			{
				textWriter.Write(' ');
				textWriter.Write(argument);
				column += 1 + argument.Length;
			}
			NewLine();
		}

		public static string PrintPrimitiveValue(object value)
		{
			StringWriter stringWriter = new StringWriter();
			new TextWriterTokenWriter(stringWriter).WritePrimitiveValue(value);
			return stringWriter.ToString();
		}

		public override void WritePrimitiveValue(object value, string literalValue = null)
		{
			if (literalValue != null)
			{
				textWriter.Write(literalValue);
				column += literalValue.Length;
			}
			else if (value == null)
			{
				textWriter.Write("null");
				column += 4;
			}
			else if (value is bool)
			{
				if ((bool)value)
				{
					textWriter.Write("true");
					column += 4;
				}
				else
				{
					textWriter.Write("false");
					column += 5;
				}
			}
			else if (value is string)
			{
				string text = "\"" + ConvertString(value.ToString()) + "\"";
				column += text.Length;
				textWriter.Write(text);
			}
			else if (value is char)
			{
				string text2 = "'" + ConvertCharLiteral((char)value) + "'";
				column += text2.Length;
				textWriter.Write(text2);
			}
			else if (value is decimal)
			{
				string text3 = ((decimal)value).ToString(NumberFormatInfo.InvariantInfo) + "m";
				column += text3.Length;
				textWriter.Write(text3);
			}
			else if (value is float)
			{
				float num = (float)value;
				if (float.IsInfinity(num) || float.IsNaN(num))
				{
					textWriter.Write("float");
					column += 5;
					WriteToken(Roles.Dot, ".");
					if (float.IsPositiveInfinity(num))
					{
						textWriter.Write("PositiveInfinity");
						column += "PositiveInfinity".Length;
					}
					else if (float.IsNegativeInfinity(num))
					{
						textWriter.Write("NegativeInfinity");
						column += "NegativeInfinity".Length;
					}
					else
					{
						textWriter.Write("NaN");
						column += 3;
					}
				}
				else
				{
					if (num == 0f && 1f / num == float.NegativeInfinity)
					{
						textWriter.Write("-");
						column++;
					}
					string text4 = num.ToString("R", NumberFormatInfo.InvariantInfo) + "f";
					column += text4.Length;
					textWriter.Write(text4);
				}
			}
			else if (value is double)
			{
				double num2 = (double)value;
				if (double.IsInfinity(num2) || double.IsNaN(num2))
				{
					textWriter.Write("double");
					column += 6;
					WriteToken(Roles.Dot, ".");
					if (double.IsPositiveInfinity(num2))
					{
						textWriter.Write("PositiveInfinity");
						column += "PositiveInfinity".Length;
					}
					else if (double.IsNegativeInfinity(num2))
					{
						textWriter.Write("NegativeInfinity");
						column += "NegativeInfinity".Length;
					}
					else
					{
						textWriter.Write("NaN");
						column += 3;
					}
				}
				else
				{
					if (num2 == 0.0 && 1.0 / num2 == double.NegativeInfinity)
					{
						textWriter.Write("-");
					}
					string text5 = num2.ToString("R", NumberFormatInfo.InvariantInfo);
					if (text5.IndexOf('.') < 0 && text5.IndexOf('E') < 0)
					{
						text5 += ".0";
					}
					textWriter.Write(text5);
				}
			}
			else if (value is IFormattable)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(((IFormattable)value).ToString(null, NumberFormatInfo.InvariantInfo));
				if (value is uint || value is ulong)
				{
					stringBuilder.Append("u");
				}
				if (value is long || value is ulong)
				{
					stringBuilder.Append("L");
				}
				textWriter.Write(stringBuilder.ToString());
				column += stringBuilder.Length;
			}
			else
			{
				textWriter.Write(value.ToString());
				column += value.ToString().Length;
			}
		}

		public static string ConvertCharLiteral(char ch)
		{
			if (ch == '\'')
			{
				return "\\'";
			}
			return ConvertChar(ch);
		}

		private static string ConvertChar(char ch)
		{
			switch (ch)
			{
			case '\\':
				return "\\\\";
			case '\0':
				return "\\0";
			case '\a':
				return "\\a";
			case '\b':
				return "\\b";
			case '\f':
				return "\\f";
			case '\n':
				return "\\n";
			case '\r':
				return "\\r";
			case '\t':
				return "\\t";
			case '\v':
				return "\\v";
			default:
				if (char.IsControl(ch) || char.IsSurrogate(ch) || (char.IsWhiteSpace(ch) && ch != ' '))
				{
					int num = ch;
					return "\\u" + num.ToString("x4");
				}
				return ch.ToString();
			}
		}

		public static string ConvertString(string str)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in str)
			{
				if (c == '"')
				{
					stringBuilder.Append("\\\"");
				}
				else
				{
					stringBuilder.Append(ConvertChar(c));
				}
			}
			return stringBuilder.ToString();
		}

		public override void WritePrimitiveType(string type)
		{
			textWriter.Write(type);
			column += type.Length;
			if (type == "new")
			{
				textWriter.Write("()");
				column += 2;
			}
		}

		public override void StartNode(AstNode node)
		{
			WriteIndentation();
		}

		public override void EndNode(AstNode node)
		{
		}
	}
}
