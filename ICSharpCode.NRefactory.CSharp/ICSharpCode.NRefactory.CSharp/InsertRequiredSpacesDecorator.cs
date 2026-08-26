using System;

namespace ICSharpCode.NRefactory.CSharp;

internal class InsertRequiredSpacesDecorator : DecoratingTokenWriter
{
	private enum LastWritten
	{
		Whitespace,
		Other,
		KeywordOrIdentifier,
		Plus,
		Minus,
		Ampersand,
		QuestionMark,
		Division
	}

	private LastWritten lastWritten;

	public InsertRequiredSpacesDecorator(TokenWriter writer)
		: base(writer)
	{
	}

	public override void WriteIdentifier(Identifier identifier, object data)
	{
		if (identifier.IsVerbatim || CSharpOutputVisitor.IsKeyword(identifier.Name, identifier))
		{
			if (lastWritten == LastWritten.KeywordOrIdentifier)
			{
				Space();
			}
		}
		else if (lastWritten == LastWritten.KeywordOrIdentifier)
		{
			base.Space();
		}
		base.WriteIdentifier(identifier, data);
		lastWritten = LastWritten.KeywordOrIdentifier;
	}

	public override void WriteKeyword(Role role, string keyword)
	{
		if (lastWritten == LastWritten.KeywordOrIdentifier)
		{
			Space();
		}
		base.WriteKeyword(role, keyword);
		lastWritten = LastWritten.KeywordOrIdentifier;
	}

	public override void WriteToken(Role role, string token, object data)
	{
		if ((lastWritten == LastWritten.Plus && token[0] == '+') || (lastWritten == LastWritten.Minus && token[0] == '-') || (lastWritten == LastWritten.Ampersand && token[0] == '&') || (lastWritten == LastWritten.QuestionMark && token[0] == '?') || (lastWritten == LastWritten.Division && token[0] == '*'))
		{
			base.Space();
		}
		base.WriteToken(role, token, data);
		switch (token)
		{
		case "+":
			lastWritten = LastWritten.Plus;
			break;
		case "-":
			lastWritten = LastWritten.Minus;
			break;
		case "&":
			lastWritten = LastWritten.Ampersand;
			break;
		case "?":
			lastWritten = LastWritten.QuestionMark;
			break;
		case "/":
			lastWritten = LastWritten.Division;
			break;
		default:
			lastWritten = LastWritten.Other;
			break;
		}
	}

	public override void Space()
	{
		base.Space();
		lastWritten = LastWritten.Whitespace;
	}

	public override void NewLine()
	{
		base.NewLine();
		lastWritten = LastWritten.Whitespace;
	}

	public override void WriteComment(CommentType commentType, string content, CommentReference[] refs)
	{
		if (lastWritten == LastWritten.Division)
		{
			base.Space();
		}
		base.WriteComment(commentType, content, refs);
		lastWritten = LastWritten.Whitespace;
	}

	public override void WritePreProcessorDirective(PreProcessorDirectiveType type, string argument)
	{
		base.WritePreProcessorDirective(type, argument);
		lastWritten = LastWritten.Whitespace;
	}

	public override void WritePrimitiveValue(object value, object data = null, string literalValue = null)
	{
		base.WritePrimitiveValue(value, data, literalValue);
		if (value == null || value is bool)
		{
			return;
		}
		if (value is string)
		{
			lastWritten = LastWritten.Other;
		}
		else if (value is char)
		{
			lastWritten = LastWritten.Other;
		}
		else if (value is decimal)
		{
			lastWritten = LastWritten.Other;
		}
		else if (value is float f)
		{
			if (!float.IsInfinity(f) && !float.IsNaN(f))
			{
				lastWritten = LastWritten.Other;
			}
		}
		else if (value is double d)
		{
			if (!double.IsInfinity(d) && !double.IsNaN(d))
			{
				lastWritten = LastWritten.KeywordOrIdentifier;
			}
		}
		else if (value is IFormattable)
		{
			lastWritten = LastWritten.KeywordOrIdentifier;
		}
		else
		{
			lastWritten = LastWritten.Other;
		}
	}

	public override void WritePrimitiveType(string type)
	{
		if (lastWritten == LastWritten.KeywordOrIdentifier)
		{
			Space();
		}
		base.WritePrimitiveType(type);
		if (type == "new")
		{
			lastWritten = LastWritten.Other;
		}
		else
		{
			lastWritten = LastWritten.KeywordOrIdentifier;
		}
	}
}
