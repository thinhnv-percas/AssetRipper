using System;
using System.Collections.Generic;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace TextEditor;

public class HighlightGroup : IDisposable
{
	private List<TextMarker> _markers = new List<TextMarker>();

	private TextEditorControl _editor;

	private IDocument _document;

	public IList<TextMarker> Markers => _markers.AsReadOnly();

	public HighlightGroup(TextEditorControl editor)
	{
		_editor = editor;
		_document = editor.Document;
	}

	public void AddMarker(TextMarker marker)
	{
		_markers.Add(marker);
		_document.MarkerStrategy.AddMarker(marker);
	}

	public void ClearMarkers()
	{
		foreach (TextMarker marker in _markers)
		{
			_document.MarkerStrategy.RemoveMarker(marker);
		}
		_markers.Clear();
		_editor.Refresh();
	}

	public void Dispose()
	{
		ClearMarkers();
		GC.SuppressFinalize(this);
	}

	~HighlightGroup()
	{
		Dispose();
	}
}
