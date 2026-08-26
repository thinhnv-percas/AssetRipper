using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;

namespace ICSharpCode.AvalonEdit.Search;

internal class SearchResultBackgroundRenderer : IBackgroundRenderer
{
	private TextSegmentCollection<SearchResult> currentResults = new TextSegmentCollection<SearchResult>();

	private Brush markerBrush;

	private Pen markerPen;

	public TextSegmentCollection<SearchResult> CurrentResults => currentResults;

	public KnownLayer Layer => KnownLayer.Selection;

	public Brush MarkerBrush
	{
		get
		{
			return markerBrush;
		}
		set
		{
			markerBrush = value;
			markerPen = new Pen(markerBrush, 1.0);
		}
	}

	public SearchResultBackgroundRenderer()
	{
		markerBrush = Brushes.LightGreen;
		markerPen = new Pen(markerBrush, 1.0);
	}

	public void Draw(TextView textView, DrawingContext drawingContext)
	{
		if (textView == null)
		{
			throw new ArgumentNullException("textView");
		}
		if (drawingContext == null)
		{
			throw new ArgumentNullException("drawingContext");
		}
		if (currentResults == null || !textView.VisualLinesValid)
		{
			return;
		}
		ReadOnlyCollection<VisualLine> visualLines = textView.VisualLines;
		if (visualLines.Count == 0)
		{
			return;
		}
		int offset = visualLines.First().FirstDocumentLine.Offset;
		int endOffset = visualLines.Last().LastDocumentLine.EndOffset;
		foreach (SearchResult item in currentResults.FindOverlappingSegments(offset, endOffset - offset))
		{
			BackgroundGeometryBuilder backgroundGeometryBuilder = new BackgroundGeometryBuilder();
			backgroundGeometryBuilder.AlignToWholePixels = true;
			backgroundGeometryBuilder.BorderThickness = ((markerPen != null) ? markerPen.Thickness : 0.0);
			backgroundGeometryBuilder.CornerRadius = 3.0;
			backgroundGeometryBuilder.AddSegment(textView, item);
			Geometry geometry = backgroundGeometryBuilder.CreateGeometry();
			if (geometry != null)
			{
				drawingContext.DrawGeometry(markerBrush, markerPen, geometry);
			}
		}
	}
}
