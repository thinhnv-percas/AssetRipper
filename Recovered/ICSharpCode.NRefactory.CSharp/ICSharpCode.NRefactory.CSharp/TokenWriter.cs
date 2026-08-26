using System;
using System.IO;

namespace ICSharpCode.NRefactory.CSharp
{
	public abstract class TokenWriter
	{
		public abstract void StartNode(AstNode node);

		public abstract void EndNode(AstNode node);

		public abstract void WriteIdentifier(Identifier identifier);

		public abstract void WriteKeyword(Role role, string keyword);

		public abstract void WriteToken(Role role, string token);

		public abstract void WritePrimitiveValue(object value, string literalValue = null);

		public abstract void WritePrimitiveType(string type);

		public abstract void Space();

		public abstract void Indent();

		public abstract void Unindent();

		public abstract void NewLine();

		public abstract void WriteComment(CommentType commentType, string content);

		public abstract void WritePreProcessorDirective(PreProcessorDirectiveType type, string argument);

		public static TokenWriter Create(TextWriter writer, string indentation = "\t")
		{
			return new InsertSpecialsDecorator(new InsertRequiredSpacesDecorator(new TextWriterTokenWriter(writer)
			{
				IndentationString = indentation
			}));
		}

		public static TokenWriter CreateWriterThatSetsLocationsInAST(TextWriter writer, string indentation = "\t")
		{
			TextWriterTokenWriter textWriterTokenWriter = new TextWriterTokenWriter(writer)
			{
				IndentationString = indentation
			};
			return new InsertSpecialsDecorator(new InsertRequiredSpacesDecorator(new InsertMissingTokensDecorator(textWriterTokenWriter, textWriterTokenWriter)));
		}

		public static TokenWriter WrapInWriterThatSetsLocationsInAST(TokenWriter writer)
		{
			if (!(writer is ILocatable))
			{
				throw new InvalidOperationException("writer does not provide locations!");
			}
			return new InsertSpecialsDecorator(new InsertRequiredSpacesDecorator(new InsertMissingTokensDecorator(writer, (ILocatable)writer)));
		}
	}
}
