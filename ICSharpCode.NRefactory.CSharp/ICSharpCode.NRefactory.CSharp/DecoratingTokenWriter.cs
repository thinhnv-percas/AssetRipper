using System;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.NRefactory.CSharp;

public abstract class DecoratingTokenWriter : TokenWriter
{
	private TokenWriter decoratedWriter;

	protected DecoratingTokenWriter(TokenWriter decoratedWriter)
	{
		if (decoratedWriter == null)
		{
			throw new ArgumentNullException("decoratedWriter");
		}
		this.decoratedWriter = decoratedWriter;
	}

	public override void StartNode(AstNode node)
	{
		decoratedWriter.StartNode(node);
	}

	public override void EndNode(AstNode node)
	{
		decoratedWriter.EndNode(node);
	}

	public override void WriteSpecialsUpToNode(AstNode node)
	{
		decoratedWriter.WriteSpecialsUpToNode(node);
	}

	public override void WriteIdentifier(Identifier identifier, object data)
	{
		decoratedWriter.WriteIdentifier(identifier, data);
	}

	public override void WriteKeyword(Role role, string keyword)
	{
		decoratedWriter.WriteKeyword(role, keyword);
	}

	public override void WriteToken(Role role, string token, object data)
	{
		decoratedWriter.WriteToken(role, token, data);
	}

	public override void WritePrimitiveValue(object value, object data = null, string literalValue = null)
	{
		decoratedWriter.WritePrimitiveValue(value, data, literalValue);
	}

	public override void WritePrimitiveType(string type)
	{
		decoratedWriter.WritePrimitiveType(type);
	}

	public override void Space()
	{
		decoratedWriter.Space();
	}

	public override void Indent()
	{
		decoratedWriter.Indent();
	}

	public override void Unindent()
	{
		decoratedWriter.Unindent();
	}

	public override void NewLine()
	{
		decoratedWriter.NewLine();
	}

	public override void WriteComment(CommentType commentType, string content, CommentReference[] refs)
	{
		decoratedWriter.WriteComment(commentType, content, refs);
	}

	public override void WritePreProcessorDirective(PreProcessorDirectiveType type, string argument)
	{
		decoratedWriter.WritePreProcessorDirective(type, argument);
	}

	public override void DebugStart(AstNode node, int? start)
	{
		decoratedWriter.DebugStart(node, start);
	}

	public override void DebugHidden(AstNode hiddenNode)
	{
		decoratedWriter.DebugHidden(hiddenNode);
	}

	public override void DebugExpression(AstNode node)
	{
		decoratedWriter.DebugExpression(node);
	}

	public override void DebugEnd(AstNode node, int? end)
	{
		decoratedWriter.DebugEnd(node, end);
	}

	public override int? GetLocation()
	{
		return decoratedWriter.GetLocation();
	}

	public override void AddHighlightedKeywordReference(object reference, int start, int end)
	{
		decoratedWriter.AddHighlightedKeywordReference(reference, start, end);
	}

	public override void AddBracePair(int leftStart, int leftEnd, int rightStart, int rightEnd, CodeBracesRangeFlags flags)
	{
		decoratedWriter.AddBracePair(leftStart, leftEnd, rightStart, rightEnd, flags);
	}

	public override void AddLineSeparator(int position)
	{
		decoratedWriter.AddLineSeparator(position);
	}
}
