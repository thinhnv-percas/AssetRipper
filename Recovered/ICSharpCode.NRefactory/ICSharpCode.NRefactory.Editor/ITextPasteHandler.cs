namespace ICSharpCode.NRefactory.Editor
{
	public interface ITextPasteHandler
	{
		string FormatPlainText(int offset, string text, byte[] copyData);

		byte[] GetCopyData(ISegment segment);
	}
}
