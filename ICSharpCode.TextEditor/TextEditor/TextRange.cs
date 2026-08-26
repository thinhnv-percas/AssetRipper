using ICSharpCode.TextEditor.Document;

namespace TextEditor;

public class TextRange : AbstractSegment
{
	private IDocument _document;

	public TextRange(IDocument document, int offset, int length)
	{
		_document = document;
		base.offset = offset;
		base.length = length;
	}
}
