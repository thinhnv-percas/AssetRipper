using System;

namespace ICSharpCode.NRefactory.CSharp
{
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

		public override void WriteIdentifier(Identifier identifier)
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
			base.WriteIdentifier(identifier);
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

		public override void WriteToken(Role role, string token)
		{
			if ((lastWritten == LastWritten.Plus && token[0] == '+') || (lastWritten == LastWritten.Minus && token[0] == '-') || (lastWritten == LastWritten.Ampersand && token[0] == '&') || (lastWritten == LastWritten.QuestionMark && token[0] == '?') || (lastWritten == LastWritten.Division && token[0] == '*'))
			{
				base.Space();
			}
			base.WriteToken(role, token);
			if (token == "+")
			{
				lastWritten = LastWritten.Plus;
			}
			else if (token == "-")
			{
				lastWritten = LastWritten.Minus;
			}
			else if (token == "&")
			{
				lastWritten = LastWritten.Ampersand;
			}
			else if (token == "?")
			{
				lastWritten = LastWritten.QuestionMark;
			}
			else if (token == "/")
			{
				lastWritten = LastWritten.Division;
			}
			else
			{
				lastWritten = LastWritten.Other;
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

		public override void WriteComment(CommentType commentType, string content)
		{
			if (lastWritten == LastWritten.Division)
			{
				base.Space();
			}
			base.WriteComment(commentType, content);
			lastWritten = LastWritten.Whitespace;
		}

		public override void WritePreProcessorDirective(PreProcessorDirectiveType type, string argument)
		{
			base.WritePreProcessorDirective(type, argument);
			lastWritten = LastWritten.Whitespace;
		}

		public override void WritePrimitiveValue(object value, string literalValue = null)
		{
			base.WritePrimitiveValue(value, literalValue);
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
			else if (value is float)
			{
				float f = (float)value;
				if (!float.IsInfinity(f) && !float.IsNaN(f))
				{
					lastWritten = LastWritten.Other;
				}
			}
			else if (value is double)
			{
				double d = (double)value;
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
}
