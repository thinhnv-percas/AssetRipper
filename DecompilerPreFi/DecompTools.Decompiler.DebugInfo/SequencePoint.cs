namespace DecompTools.Decompiler.DebugInfo;

public struct SequencePoint
{
	public int Offset { get; set; }

	public int EndOffset { get; set; }

	public int StartLine { get; set; }

	public int StartColumn { get; set; }

	public int EndLine { get; set; }

	public int EndColumn { get; set; }

	public bool IsHidden => StartLine == 16707566 && StartLine == EndLine;

	public string DocumentUrl { get; set; }

	internal void SetHidden()
	{
		int startLine = (EndLine = 16707566);
		StartLine = startLine;
	}
}
