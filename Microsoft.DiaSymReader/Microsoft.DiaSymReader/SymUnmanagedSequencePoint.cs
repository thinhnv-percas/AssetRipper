using System.Diagnostics;

namespace Microsoft.DiaSymReader;

[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public struct SymUnmanagedSequencePoint
{
	public readonly int Offset;

	public readonly ISymUnmanagedDocument Document;

	public readonly int StartLine;

	public readonly int StartColumn;

	public readonly int EndLine;

	public readonly int EndColumn;

	public bool IsHidden => StartLine == 16707566;

	public SymUnmanagedSequencePoint(int offset, ISymUnmanagedDocument document, int startLine, int startColumn, int endLine, int endColumn)
	{
		Offset = offset;
		Document = document;
		StartLine = startLine;
		StartColumn = startColumn;
		EndLine = endLine;
		EndColumn = endColumn;
	}

	private string GetDebuggerDisplay()
	{
		return $"SequencePoint: Offset = {Offset:x4}, Range = ({StartLine}, {StartColumn})..({EndLine}, {EndColumn})";
	}
}
