using System;
using System.IO;
using dnSpy.Contracts.Decompiler;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.NRefactory.VB;

public class TextWriterOutputFormatter : IOutputFormatter
{
	private readonly TextWriter textWriter;

	private int indentation;

	private bool needsIndent = true;

	public int NextPosition => 0;

	public TextWriterOutputFormatter(TextWriter textWriter)
	{
		if (textWriter == null)
		{
			throw new ArgumentNullException("textWriter");
		}
		this.textWriter = textWriter;
	}

	public void WriteIdentifier(string ident, object data, object extraData)
	{
		WriteIndentation();
		textWriter.Write(ident);
	}

	public void WriteKeyword(string keyword)
	{
		WriteIndentation();
		textWriter.Write(keyword);
	}

	public void WriteToken(string token, object data)
	{
		WriteIndentation();
		textWriter.Write(token);
	}

	public void Space()
	{
		WriteIndentation();
		textWriter.Write(' ');
	}

	private void WriteIndentation()
	{
		if (needsIndent)
		{
			needsIndent = false;
			for (int i = 0; i < indentation; i++)
			{
				textWriter.Write('\t');
			}
		}
	}

	public void NewLine()
	{
		textWriter.WriteLine();
		needsIndent = true;
	}

	public void Indent()
	{
		indentation++;
	}

	public void Unindent()
	{
		indentation--;
	}

	public virtual void StartNode(AstNode node)
	{
	}

	public virtual void EndNode(AstNode node)
	{
	}

	public void WriteComment(bool isDocumentation, string content, CommentReference[] refs)
	{
		WriteIndentation();
		if (isDocumentation)
		{
			textWriter.Write("'''");
		}
		else
		{
			textWriter.Write("'");
		}
		textWriter.WriteLine(content);
	}

	public void DebugHidden(object hiddenILSpans)
	{
	}

	public void DebugStart(AstNode node)
	{
	}

	public void DebugExpression(AstNode node)
	{
	}

	public void DebugEnd(AstNode node)
	{
	}

	public void AddHighlightedKeywordReference(object reference, int start, int end)
	{
	}

	public void AddBracePair(int leftStart, int leftEnd, int rightStart, int rightEnd, CodeBracesRangeFlags flags)
	{
	}

	public void AddBlock(int start, int end, CodeBracesRangeFlags flags)
	{
	}

	public void AddLineSeparator(int position)
	{
	}
}
