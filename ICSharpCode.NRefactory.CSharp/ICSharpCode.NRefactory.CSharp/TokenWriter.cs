using System;
using System.IO;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;

namespace ICSharpCode.NRefactory.CSharp;

public abstract class TokenWriter
{
	public abstract void StartNode(AstNode node);

	public abstract void EndNode(AstNode node);

	public virtual void WriteSpecialsUpToNode(AstNode node)
	{
	}

	public abstract void WriteIdentifier(Identifier identifier, object data);

	public abstract void WriteKeyword(Role role, string keyword);

	public abstract void WriteToken(Role role, string token, object data);

	public abstract void WritePrimitiveValue(object value, object data = null, string literalValue = null);

	public abstract void WritePrimitiveType(string type);

	public abstract void Space();

	public abstract void Indent();

	public abstract void Unindent();

	public abstract void NewLine();

	public abstract void WriteComment(CommentType commentType, string content, CommentReference[] refs);

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

	public virtual void DebugStart(AstNode node, int? start)
	{
	}

	public virtual void DebugHidden(AstNode hiddenNode)
	{
	}

	public virtual void DebugExpression(AstNode node)
	{
	}

	public virtual void DebugEnd(AstNode node, int? end)
	{
	}

	public virtual int? GetLocation()
	{
		return null;
	}

	public void WriteTokenOperator(Role tokenRole, string token)
	{
		WriteToken(tokenRole, token, BoxedTextColor.Operator);
	}

	public void WriteTokenPunctuation(Role tokenRole, string token)
	{
		WriteToken(tokenRole, token, BoxedTextColor.Punctuation);
	}

	public void WriteTokenBrace(Role tokenRole, string token)
	{
		WriteToken(tokenRole, token, BoxedTextColor.Punctuation);
	}

	public void WriteTokenNumber(Role tokenRole, string token)
	{
		WriteToken(tokenRole, token, BoxedTextColor.Number);
	}

	public virtual void AddHighlightedKeywordReference(object reference, int start, int end)
	{
	}

	public virtual void AddBracePair(int leftStart, int leftEnd, int rightStart, int rightEnd, CodeBracesRangeFlags flags)
	{
	}

	public virtual void AddLineSeparator(int position)
	{
	}
}
