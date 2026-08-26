using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Utils;

namespace ICSharpCode.AvalonEdit.Rendering;

public sealed class BackgroundGeometryBuilder
{
	private double cornerRadius;

	private bool alignToMiddleOfPixels;

	private PathFigureCollection figures = new PathFigureCollection();

	private PathFigure figure;

	private int insertionIndex;

	private double lastTop;

	private double lastBottom;

	private double lastLeft;

	private double lastRight;

	public double CornerRadius
	{
		get
		{
			return cornerRadius;
		}
		set
		{
			cornerRadius = value;
		}
	}

	public bool AlignToWholePixels { get; set; }

	public double BorderThickness { get; set; }

	[Obsolete("Use the AlignToWholePixels and BorderThickness properties instead. Setting AlignToWholePixels=true and setting the BorderThickness to the pixel size is equivalent to aligning the geometry to the middle of pixels.")]
	public bool AlignToMiddleOfPixels
	{
		get
		{
			return alignToMiddleOfPixels;
		}
		set
		{
			alignToMiddleOfPixels = value;
		}
	}

	public bool ExtendToFullWidthAtLineEnd { get; set; }

	public void AddSegment(TextView textView, ISegment segment)
	{
		if (textView == null)
		{
			throw new ArgumentNullException("textView");
		}
		Size pixelSize = PixelSnapHelpers.GetPixelSize(textView);
		foreach (Rect item in GetRectsForSegment(textView, segment, ExtendToFullWidthAtLineEnd))
		{
			AddRectangle(pixelSize, item);
		}
	}

	public void AddRectangle(TextView textView, Rect rectangle)
	{
		AddRectangle(PixelSnapHelpers.GetPixelSize(textView), rectangle);
	}

	private void AddRectangle(Size pixelSize, Rect r)
	{
		if (AlignToWholePixels)
		{
			double num = 0.5 * BorderThickness;
			AddRectangle(PixelSnapHelpers.Round(r.Left - num, pixelSize.Width) + num, PixelSnapHelpers.Round(r.Top - num, pixelSize.Height) + num, PixelSnapHelpers.Round(r.Right + num, pixelSize.Width) - num, PixelSnapHelpers.Round(r.Bottom + num, pixelSize.Height) - num);
		}
		else if (alignToMiddleOfPixels)
		{
			AddRectangle(PixelSnapHelpers.PixelAlign(r.Left, pixelSize.Width), PixelSnapHelpers.PixelAlign(r.Top, pixelSize.Height), PixelSnapHelpers.PixelAlign(r.Right, pixelSize.Width), PixelSnapHelpers.PixelAlign(r.Bottom, pixelSize.Height));
		}
		else
		{
			AddRectangle(r.Left, r.Top, r.Right, r.Bottom);
		}
	}

	public static IEnumerable<Rect> GetRectsForSegment(TextView textView, ISegment segment, bool extendToFullWidthAtLineEnd = false)
	{
		if (textView == null)
		{
			throw new ArgumentNullException("textView");
		}
		if (segment == null)
		{
			throw new ArgumentNullException("segment");
		}
		return GetRectsForSegmentImpl(textView, segment, extendToFullWidthAtLineEnd);
	}

	private static IEnumerable<Rect> GetRectsForSegmentImpl(TextView textView, ISegment segment, bool extendToFullWidthAtLineEnd)
	{
		int segmentStart = segment.Offset;
		int segmentEnd = segment.Offset + segment.Length;
		segmentStart = segmentStart.CoerceValue(0, textView.Document.TextLength);
		segmentEnd = segmentEnd.CoerceValue(0, textView.Document.TextLength);
		TextViewPosition start;
		TextViewPosition end;
		if (segment is SelectionSegment)
		{
			SelectionSegment selectionSegment = (SelectionSegment)segment;
			start = new TextViewPosition(textView.Document.GetLocation(selectionSegment.StartOffset), selectionSegment.StartVisualColumn);
			end = new TextViewPosition(textView.Document.GetLocation(selectionSegment.EndOffset), selectionSegment.EndVisualColumn);
		}
		else
		{
			start = new TextViewPosition(textView.Document.GetLocation(segmentStart));
			end = new TextViewPosition(textView.Document.GetLocation(segmentEnd));
		}
		foreach (VisualLine vl in textView.VisualLines)
		{
			int vlStartOffset = vl.FirstDocumentLine.Offset;
			if (vlStartOffset > segmentEnd)
			{
				break;
			}
			int vlEndOffset = vl.LastDocumentLine.Offset + vl.LastDocumentLine.Length;
			if (vlEndOffset < segmentStart)
			{
				continue;
			}
			int segmentStartVC = ((segmentStart >= vlStartOffset) ? vl.ValidateVisualColumn(start, extendToFullWidthAtLineEnd) : 0);
			int segmentEndVC = ((segmentEnd <= vlEndOffset) ? vl.ValidateVisualColumn(end, extendToFullWidthAtLineEnd) : (extendToFullWidthAtLineEnd ? int.MaxValue : vl.VisualLengthWithEndOfLineMarker));
			foreach (Rect item in ProcessTextLines(textView, vl, segmentStartVC, segmentEndVC))
			{
				yield return item;
			}
		}
	}

	public static IEnumerable<Rect> GetRectsFromVisualSegment(TextView textView, VisualLine line, int startVC, int endVC)
	{
		if (textView == null)
		{
			throw new ArgumentNullException("textView");
		}
		if (line == null)
		{
			throw new ArgumentNullException("line");
		}
		return ProcessTextLines(textView, line, startVC, endVC);
	}

	private static IEnumerable<Rect> ProcessTextLines(TextView textView, VisualLine visualLine, int segmentStartVC, int segmentEndVC)
	{
		TextLine lastTextLine = visualLine.TextLines.Last();
		Vector scrollOffset = textView.ScrollOffset;
		for (int i = 0; i < visualLine.TextLines.Count; i++)
		{
			TextLine line = visualLine.TextLines[i];
			double y = visualLine.GetTextLineVisualYPosition(line, VisualYPosition.LineTop);
			int visualStartCol = visualLine.GetTextLineVisualStartColumn(line);
			int visualEndCol = visualStartCol + line.Length;
			visualEndCol = ((line != lastTextLine) ? (visualEndCol - line.TrailingWhitespaceLength) : (visualEndCol - 1));
			if (segmentEndVC < visualStartCol)
			{
				break;
			}
			if (lastTextLine != line && segmentStartVC > visualEndCol)
			{
				continue;
			}
			int segmentStartVCInLine = Math.Max(segmentStartVC, visualStartCol);
			int segmentEndVCInLine = Math.Min(segmentEndVC, visualEndCol);
			y -= scrollOffset.Y;
			Rect lastRect = Rect.Empty;
			if (segmentStartVCInLine == segmentEndVCInLine)
			{
				double textLineVisualXPosition = visualLine.GetTextLineVisualXPosition(line, segmentStartVCInLine);
				textLineVisualXPosition -= scrollOffset.X;
				if ((segmentEndVCInLine == visualEndCol && i < visualLine.TextLines.Count - 1 && segmentEndVC > segmentEndVCInLine && line.TrailingWhitespaceLength == 0) || (segmentStartVCInLine == visualStartCol && i > 0 && segmentStartVC < segmentStartVCInLine && visualLine.TextLines[i - 1].TrailingWhitespaceLength == 0))
				{
					continue;
				}
				lastRect = new Rect(textLineVisualXPosition, y, textView.EmptyLineSelectionWidth, line.Height);
			}
			else if (segmentStartVCInLine <= visualEndCol)
			{
				foreach (TextBounds b in line.GetTextBounds(segmentStartVCInLine, segmentEndVCInLine - segmentStartVCInLine))
				{
					double left = b.Rectangle.Left - scrollOffset.X;
					double right = b.Rectangle.Right - scrollOffset.X;
					if (!lastRect.IsEmpty)
					{
						yield return lastRect;
					}
					lastRect = new Rect(Math.Min(left, right), y, Math.Abs(right - left), line.Height);
				}
			}
			if (segmentEndVC > visualEndCol)
			{
				double left2 = ((segmentStartVC <= visualLine.VisualLengthWithEndOfLineMarker) ? ((line == lastTextLine) ? line.WidthIncludingTrailingWhitespace : line.Width) : visualLine.GetTextLineVisualXPosition(lastTextLine, segmentStartVC));
				double right2 = ((line == lastTextLine && segmentEndVC != int.MaxValue) ? visualLine.GetTextLineVisualXPosition(lastTextLine, segmentEndVC) : Math.Max(((IScrollInfo)textView).ExtentWidth, ((IScrollInfo)textView).ViewportWidth));
				Rect extendSelection = new Rect(Math.Min(left2, right2), y, Math.Abs(right2 - left2), line.Height);
				if (!lastRect.IsEmpty)
				{
					if (extendSelection.IntersectsWith(lastRect))
					{
						lastRect.Union(extendSelection);
						yield return lastRect;
					}
					else
					{
						yield return lastRect;
						yield return extendSelection;
					}
				}
				else
				{
					yield return extendSelection;
				}
			}
			else
			{
				yield return lastRect;
			}
		}
	}

	public void AddRectangle(double left, double top, double right, double bottom)
	{
		if (!top.IsClose(lastBottom))
		{
			CloseFigure();
		}
		if (figure == null)
		{
			figure = new PathFigure();
			figure.StartPoint = new Point(left, top + cornerRadius);
			if (Math.Abs(left - right) > cornerRadius)
			{
				figure.Segments.Add(MakeArc(left + cornerRadius, top, SweepDirection.Clockwise));
				figure.Segments.Add(MakeLineSegment(right - cornerRadius, top));
				figure.Segments.Add(MakeArc(right, top + cornerRadius, SweepDirection.Clockwise));
			}
			figure.Segments.Add(MakeLineSegment(right, bottom - cornerRadius));
			insertionIndex = figure.Segments.Count;
		}
		else
		{
			if (!lastRight.IsClose(right))
			{
				double num = ((right < lastRight) ? (0.0 - cornerRadius) : cornerRadius);
				SweepDirection dir = ((right < lastRight) ? SweepDirection.Clockwise : SweepDirection.Counterclockwise);
				SweepDirection dir2 = ((!(right < lastRight)) ? SweepDirection.Clockwise : SweepDirection.Counterclockwise);
				figure.Segments.Insert(insertionIndex++, MakeArc(lastRight + num, lastBottom, dir));
				figure.Segments.Insert(insertionIndex++, MakeLineSegment(right - num, top));
				figure.Segments.Insert(insertionIndex++, MakeArc(right, top + cornerRadius, dir2));
			}
			figure.Segments.Insert(insertionIndex++, MakeLineSegment(right, bottom - cornerRadius));
			figure.Segments.Insert(insertionIndex, MakeLineSegment(lastLeft, lastTop + cornerRadius));
			if (!lastLeft.IsClose(left))
			{
				double num2 = ((left < lastLeft) ? cornerRadius : (0.0 - cornerRadius));
				SweepDirection dir3 = ((!(left < lastLeft)) ? SweepDirection.Clockwise : SweepDirection.Counterclockwise);
				SweepDirection dir4 = ((left < lastLeft) ? SweepDirection.Clockwise : SweepDirection.Counterclockwise);
				figure.Segments.Insert(insertionIndex, MakeArc(lastLeft, lastBottom - cornerRadius, dir3));
				figure.Segments.Insert(insertionIndex, MakeLineSegment(lastLeft - num2, lastBottom));
				figure.Segments.Insert(insertionIndex, MakeArc(left + num2, lastBottom, dir4));
			}
		}
		lastTop = top;
		lastBottom = bottom;
		lastLeft = left;
		lastRight = right;
	}

	private ArcSegment MakeArc(double x, double y, SweepDirection dir)
	{
		ArcSegment arcSegment = new ArcSegment(new Point(x, y), new Size(cornerRadius, cornerRadius), 0.0, isLargeArc: false, dir, isStroked: true);
		arcSegment.Freeze();
		return arcSegment;
	}

	private static LineSegment MakeLineSegment(double x, double y)
	{
		LineSegment lineSegment = new LineSegment(new Point(x, y), isStroked: true);
		lineSegment.Freeze();
		return lineSegment;
	}

	public void CloseFigure()
	{
		if (figure != null)
		{
			figure.Segments.Insert(insertionIndex, MakeLineSegment(lastLeft, lastTop + cornerRadius));
			if (Math.Abs(lastLeft - lastRight) > cornerRadius)
			{
				figure.Segments.Insert(insertionIndex, MakeArc(lastLeft, lastBottom - cornerRadius, SweepDirection.Clockwise));
				figure.Segments.Insert(insertionIndex, MakeLineSegment(lastLeft + cornerRadius, lastBottom));
				figure.Segments.Insert(insertionIndex, MakeArc(lastRight - cornerRadius, lastBottom, SweepDirection.Clockwise));
			}
			figure.IsClosed = true;
			figures.Add(figure);
			figure = null;
		}
	}

	public Geometry CreateGeometry()
	{
		CloseFigure();
		if (figures.Count != 0)
		{
			PathGeometry pathGeometry = new PathGeometry(figures);
			pathGeometry.Freeze();
			return pathGeometry;
		}
		return null;
	}
}
