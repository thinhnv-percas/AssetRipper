using System;
using System.Globalization;
using System.IO;
using System.Text;
using DecompTools.Decompiler.CSharp.Syntax;

namespace DecompTools.Decompiler.CSharp.OutputVisitor;

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

	public TextLocation Location => new TextLocation(line, checked(column + (needsIndent ? (indentation * IndentationString.Length) : 0)));

	public string IndentationString { get; set; }

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
		checked
		{
			if (identifier.IsVerbatim || CSharpOutputVisitor.IsKeyword(identifier.Name, identifier))
			{
				textWriter.Write('@');
				column++;
			}
			string text = EscapeIdentifier(identifier.Name);
			textWriter.Write(text);
			column += text.Length;
			isAtStartOfLine = false;
		}
	}

	public override void WriteKeyword(Role role, string keyword)
	{
		WriteIndentation();
		checked
		{
			column += keyword.Length;
			textWriter.Write(keyword);
			isAtStartOfLine = false;
		}
	}

	public override void WriteToken(Role role, string token)
	{
		WriteIndentation();
		checked
		{
			column += token.Length;
			textWriter.Write(token);
			isAtStartOfLine = false;
		}
	}

	public override void Space()
	{
		WriteIndentation();
		checked
		{
			column++;
			textWriter.Write(' ');
		}
	}

	protected void WriteIndentation()
	{
		checked
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
	}

	public override void NewLine()
	{
		textWriter.WriteLine();
		column = 1;
		checked
		{
			line++;
			needsIndent = true;
			isAtStartOfLine = true;
		}
	}

	public override void Indent()
	{
		checked
		{
			indentation++;
		}
	}

	public override void Unindent()
	{
		checked
		{
			indentation--;
		}
	}

	public override void WriteComment(CommentType commentType, string content)
	{
		WriteIndentation();
		checked
		{
			switch (commentType)
			{
			case CommentType.SingleLine:
				textWriter.Write("//");
				textWriter.WriteLine(content);
				column = 1;
				line++;
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
				column = 1;
				line++;
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
	}

	private static void UpdateEndLocation(string content, ref int line, ref int column)
	{
		if (string.IsNullOrEmpty(content))
		{
			return;
		}
		checked
		{
			for (int i = 0; i < content.Length; column++, i++)
			{
				char c = content[i];
				char c2 = c;
				if (c2 != '\n')
				{
					if (c2 != '\r')
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
		checked
		{
			column += 1 + text.Length;
			if (!string.IsNullOrEmpty(argument))
			{
				textWriter.Write(' ');
				textWriter.Write(argument);
				column += 1 + argument.Length;
			}
			NewLine();
		}
	}

	public static string PrintPrimitiveValue(object value)
	{
		TextWriter textWriter = new StringWriter();
		TextWriterTokenWriter textWriterTokenWriter = new TextWriterTokenWriter(textWriter);
		textWriterTokenWriter.WritePrimitiveValue(value);
		return textWriter.ToString();
	}

	public override void WritePrimitiveValue(object value, string literalValue = null)
	{
		checked
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
				string text = ConvertString(value.ToString());
				column += text.Length + 2;
				textWriter.Write('"');
				textWriter.Write(text);
				textWriter.Write('"');
			}
			else if (value is char)
			{
				string text2 = ConvertCharLiteral((char)value);
				column += text2.Length + 2;
				textWriter.Write('\'');
				textWriter.Write(text2);
				textWriter.Write('\'');
			}
			else if (value is decimal num)
			{
				string text3 = num.ToString(NumberFormatInfo.InvariantInfo) + "m";
				column += text3.Length;
				textWriter.Write(text3);
			}
			else if (value is float num2)
			{
				if (float.IsInfinity(num2) || float.IsNaN(num2))
				{
					textWriter.Write("float");
					column += 5;
					WriteToken(Roles.Dot, ".");
					if (float.IsPositiveInfinity(num2))
					{
						textWriter.Write("PositiveInfinity");
						column += "PositiveInfinity".Length;
					}
					else if (float.IsNegativeInfinity(num2))
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
					if (num2 == 0f && 1f / num2 == float.NegativeInfinity)
					{
						textWriter.Write("-");
						column++;
					}
					string text4 = num2.ToString("R", NumberFormatInfo.InvariantInfo) + "f";
					column += text4.Length;
					textWriter.Write(text4);
				}
			}
			else if (value is double num3)
			{
				if (double.IsInfinity(num3) || double.IsNaN(num3))
				{
					textWriter.Write("double");
					column += 6;
					WriteToken(Roles.Dot, ".");
					if (double.IsPositiveInfinity(num3))
					{
						textWriter.Write("PositiveInfinity");
						column += "PositiveInfinity".Length;
					}
					else if (double.IsNegativeInfinity(num3))
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
					if (num3 == 0.0 && 1.0 / num3 == double.NegativeInfinity)
					{
						textWriter.Write("-");
					}
					string text5 = num3.ToString("R", NumberFormatInfo.InvariantInfo);
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
	}

	public static string ConvertCharLiteral(char ch)
	{
		if (ch == '\'')
		{
			return "\\'";
		}
		return ConvertChar(ch) ?? ch.ToString();
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
		case ' ':
		case '^':
		case '_':
		case '`':
			return null;
		default:
			switch (char.GetUnicodeCategory(ch))
			{
			case UnicodeCategory.ModifierLetter:
			case UnicodeCategory.NonSpacingMark:
			case UnicodeCategory.SpacingCombiningMark:
			case UnicodeCategory.EnclosingMark:
			case UnicodeCategory.SpaceSeparator:
			case UnicodeCategory.LineSeparator:
			case UnicodeCategory.ParagraphSeparator:
			case UnicodeCategory.Control:
			case UnicodeCategory.Format:
			case UnicodeCategory.Surrogate:
			case UnicodeCategory.PrivateUse:
			case UnicodeCategory.ConnectorPunctuation:
			case UnicodeCategory.ModifierSymbol:
			case UnicodeCategory.OtherNotAssigned:
			{
				int num = ch;
				return "\\u" + num.ToString("x4");
			}
			default:
				return null;
			}
		}
	}

	public static string ConvertString(string str)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in str)
		{
			string text = ((c == '"') ? "\\\"" : ConvertChar(c));
			if (text != null)
			{
				stringBuilder.Append(text);
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	public static string EscapeIdentifier(string identifier)
	{
		if (string.IsNullOrEmpty(identifier))
		{
			return identifier;
		}
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			for (int i = 0; i < identifier.Length; i++)
			{
				if (IsPrintableIdentifierChar(identifier, i))
				{
					if (char.IsSurrogatePair(identifier, i))
					{
						stringBuilder.Append(identifier.Substring(i, 2));
						i++;
					}
					else
					{
						stringBuilder.Append(identifier[i]);
					}
				}
				else if (char.IsSurrogatePair(identifier, i))
				{
					stringBuilder.AppendFormat("\\U{0:x8}", char.ConvertToUtf32(identifier, i));
					i++;
				}
				else
				{
					stringBuilder.AppendFormat("\\u{0:x4}", unchecked((int)identifier[i]));
				}
			}
			return stringBuilder.ToString();
		}
	}

	private static bool IsPrintableIdentifierChar(string identifier, int index)
	{
		switch (identifier[index])
		{
		case '\\':
			return false;
		case ' ':
		case '^':
		case '_':
		case '`':
			return true;
		default:
			switch (char.GetUnicodeCategory(identifier, index))
			{
			case UnicodeCategory.ModifierLetter:
			case UnicodeCategory.NonSpacingMark:
			case UnicodeCategory.SpacingCombiningMark:
			case UnicodeCategory.EnclosingMark:
			case UnicodeCategory.SpaceSeparator:
			case UnicodeCategory.LineSeparator:
			case UnicodeCategory.ParagraphSeparator:
			case UnicodeCategory.Control:
			case UnicodeCategory.Format:
			case UnicodeCategory.Surrogate:
			case UnicodeCategory.PrivateUse:
			case UnicodeCategory.ConnectorPunctuation:
			case UnicodeCategory.ModifierSymbol:
			case UnicodeCategory.OtherNotAssigned:
				return false;
			default:
				return true;
			}
		}
	}

	public override void WritePrimitiveType(string type)
	{
		textWriter.Write(type);
		checked
		{
			column += type.Length;
			if (type == "new")
			{
				textWriter.Write("()");
				column += 2;
			}
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
