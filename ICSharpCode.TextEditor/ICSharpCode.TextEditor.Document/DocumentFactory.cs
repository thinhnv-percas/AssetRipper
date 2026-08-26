using System.Text;
using ICSharpCode.TextEditor.Util;

namespace ICSharpCode.TextEditor.Document;

public class DocumentFactory
{
	public IDocument CreateDocument()
	{
		DefaultDocument defaultDocument = new DefaultDocument();
		defaultDocument.TextBufferStrategy = new GapTextBufferStrategy();
		defaultDocument.FormattingStrategy = new DefaultFormattingStrategy();
		defaultDocument.LineManager = new LineManager(defaultDocument, null);
		defaultDocument.FoldingManager = new FoldingManager(defaultDocument, defaultDocument.LineManager);
		defaultDocument.FoldingManager.FoldingStrategy = null;
		defaultDocument.MarkerStrategy = new MarkerStrategy(defaultDocument);
		defaultDocument.BookmarkManager = new BookmarkManager(defaultDocument, defaultDocument.LineManager);
		return defaultDocument;
	}

	public IDocument CreateFromTextBuffer(ITextBufferStrategy textBuffer)
	{
		DefaultDocument obj = (DefaultDocument)CreateDocument();
		obj.TextContent = textBuffer.GetText(0, textBuffer.Length);
		obj.TextBufferStrategy = textBuffer;
		return obj;
	}

	public IDocument CreateFromFile(string fileName)
	{
		IDocument document = CreateDocument();
		document.TextContent = FileReader.ReadFileContent(fileName, Encoding.Default);
		return document;
	}
}
