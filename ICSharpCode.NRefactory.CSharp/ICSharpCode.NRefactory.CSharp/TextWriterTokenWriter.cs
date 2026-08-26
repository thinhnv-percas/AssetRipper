using System;
using System.Globalization;
using System.IO;
using System.Text;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;

namespace ICSharpCode.NRefactory.CSharp;

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

	public override void WriteIdentifier(Identifier identifier, object data)
	{
		WriteIndentation();
		if (!BoxedTextColor.Keyword.Equals(data) && (identifier.IsVerbatim || CSharpOutputVisitor.IsKeyword(identifier.Name, identifier)))
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

	public override void WriteToken(Role role, string token, object data)
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

	public override void WriteComment(CommentType commentType, string content, CommentReference[] refs)
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
		TextWriter textWriter = new StringWriter();
		TextWriterTokenWriter textWriterTokenWriter = new TextWriterTokenWriter(textWriter);
		textWriterTokenWriter.WritePrimitiveValue(value, CSharpMetadataTextColorProvider.Instance.GetColor(value));
		return textWriter.ToString();
	}

	public override void WritePrimitiveValue(object value, object data = null, string literalValue = null)
	{
		WritePrimitiveValue(value, data, literalValue, ref column, delegate(string a, object b)
		{
			textWriter.Write(a);
		}, WriteToken);
	}

	public static void WritePrimitiveValue(object value, object data, string literalValue, ref int column, Action<string, object> writer, Action<Role, string, object> writeToken)
	{
		if (literalValue != null)
		{
			writer(literalValue, data ?? BoxedTextColor.Text);
			column += literalValue.Length;
		}
		else if (value == null)
		{
			writer("null", BoxedTextColor.Keyword);
			column += 4;
		}
		else if (value is bool)
		{
			if ((bool)value)
			{
				writer("true", BoxedTextColor.Keyword);
				column += 4;
			}
			else
			{
				writer("false", BoxedTextColor.Keyword);
				column += 5;
			}
		}
		else if (value is string str)
		{
			string text = "\"" + ConvertString(str) + "\"";
			column += text.Length;
			writer(text, BoxedTextColor.String);
		}
		else if (value is char)
		{
			string text2 = "'" + ConvertCharLiteral((char)value) + "'";
			column += text2.Length;
			writer(text2, BoxedTextColor.Char);
		}
		else if (value is decimal num)
		{
			string text3 = num.ToString(NumberFormatInfo.InvariantInfo) + "m";
			column += text3.Length;
			writer(text3, BoxedTextColor.Number);
		}
		else if (value is float num2)
		{
			if (float.IsInfinity(num2) || float.IsNaN(num2))
			{
				writer("float", BoxedTextColor.Keyword);
				column += 5;
				writeToken(Roles.Dot, ".", BoxedTextColor.Operator);
				if (float.IsPositiveInfinity(num2))
				{
					writer("PositiveInfinity", BoxedTextColor.LiteralField);
					column += "PositiveInfinity".Length;
				}
				else if (float.IsNegativeInfinity(num2))
				{
					writer("NegativeInfinity", BoxedTextColor.LiteralField);
					column += "NegativeInfinity".Length;
				}
				else
				{
					writer("NaN", BoxedTextColor.LiteralField);
					column += 3;
				}
			}
			else
			{
				string text4 = num2.ToString("R", NumberFormatInfo.InvariantInfo) + "f";
				if (num2 == 0f && 1f / num2 == float.NegativeInfinity)
				{
					text4 = "-" + text4;
				}
				column += text4.Length;
				writer(text4, BoxedTextColor.Number);
			}
		}
		else if (value is double num3)
		{
			if (double.IsInfinity(num3) || double.IsNaN(num3))
			{
				writer("double", BoxedTextColor.Keyword);
				column += 6;
				writeToken(Roles.Dot, ".", BoxedTextColor.Operator);
				if (double.IsPositiveInfinity(num3))
				{
					writer("PositiveInfinity", BoxedTextColor.LiteralField);
					column += "PositiveInfinity".Length;
				}
				else if (double.IsNegativeInfinity(num3))
				{
					writer("NegativeInfinity", BoxedTextColor.LiteralField);
					column += "NegativeInfinity".Length;
				}
				else
				{
					writer("NaN", BoxedTextColor.LiteralField);
					column += 3;
				}
			}
			else
			{
				string text5 = num3.ToString("R", NumberFormatInfo.InvariantInfo);
				if (num3 == 0.0 && 1.0 / num3 == double.NegativeInfinity)
				{
					text5 = "-" + text5;
				}
				if (text5.IndexOf('.') < 0 && text5.IndexOf('E') < 0)
				{
					text5 += ".0";
				}
				column += text5.Length;
				writer(text5, BoxedTextColor.Number);
			}
		}
		else if (value is IFormattable)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(((IFormattable)value).ToString(null, NumberFormatInfo.InvariantInfo));
			if (value is uint)
			{
				stringBuilder.Append("u");
			}
			else if (value is ulong)
			{
				stringBuilder.Append("UL");
			}
			else if (value is long)
			{
				stringBuilder.Append("L");
			}
			writer(stringBuilder.ToString(), BoxedTextColor.Number);
			column += stringBuilder.Length;
		}
		else
		{
			string text6 = value.ToString();
			writer(text6, CSharpMetadataTextColorProvider.Instance.GetColor(value));
			column += text6.Length;
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

	private static void AppendChar(StringBuilder sb, char ch)
	{
		switch (ch)
		{
		case '\\':
			sb.Append("\\\\");
			return;
		case '\0':
			sb.Append("\\0");
			return;
		case '\a':
			sb.Append("\\a");
			return;
		case '\b':
			sb.Append("\\b");
			return;
		case '\f':
			sb.Append("\\f");
			return;
		case '\n':
			sb.Append("\\n");
			return;
		case '\r':
			sb.Append("\\r");
			return;
		case '\t':
			sb.Append("\\t");
			return;
		case '\v':
			sb.Append("\\v");
			return;
		}
		if (char.IsControl(ch) || char.IsSurrogate(ch) || (char.IsWhiteSpace(ch) && ch != ' '))
		{
			sb.Append("\\u");
			int num = ch;
			sb.Append(num.ToString("x4"));
		}
		else
		{
			sb.Append(ch);
		}
	}

	public static string ConvertString(string str)
	{
		int i = 0;
		while (true)
		{
			if (i >= str.Length)
			{
				return str;
			}
			char c = str[i];
			switch (c)
			{
			default:
				if (!char.IsControl(c) && !char.IsSurrogate(c) && (!char.IsWhiteSpace(c) || c == ' '))
				{
					goto IL_007a;
				}
				break;
			case '\0':
			case '\a':
			case '\b':
			case '\t':
			case '\n':
			case '\v':
			case '\f':
			case '\r':
			case '"':
			case '\\':
				break;
			}
			break;
			IL_007a:
			i++;
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (i > 0)
		{
			stringBuilder.Append(str, 0, i);
		}
		for (; i < str.Length; i++)
		{
			char c2 = str[i];
			if (c2 == '"')
			{
				stringBuilder.Append("\\\"");
			}
			else
			{
				AppendChar(stringBuilder, c2);
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
