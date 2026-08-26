using System;
using System.Collections.Generic;
using ICSharpCode.AvalonEdit.Document;

namespace ICSharpCode.AvalonEdit.Editing;

public class TextSegmentReadOnlySectionProvider<T> : IReadOnlySectionProvider where T : TextSegment
{
	private readonly TextSegmentCollection<T> segments;

	public TextSegmentCollection<T> Segments => segments;

	public TextSegmentReadOnlySectionProvider(TextDocument textDocument)
	{
		segments = new TextSegmentCollection<T>(textDocument);
	}

	public TextSegmentReadOnlySectionProvider(TextSegmentCollection<T> segments)
	{
		if (segments == null)
		{
			throw new ArgumentNullException("segments");
		}
		this.segments = segments;
	}

	public virtual bool CanInsert(int offset)
	{
		foreach (T item in segments.FindSegmentsContaining(offset))
		{
			if (item.StartOffset < offset && offset < item.EndOffset)
			{
				return false;
			}
		}
		return true;
	}

	public virtual IEnumerable<ISegment> GetDeletableSegments(ISegment segment)
	{
		if (segment == null)
		{
			throw new ArgumentNullException("segment");
		}
		if (segment.Length == 0 && CanInsert(segment.Offset))
		{
			yield return segment;
			yield break;
		}
		int readonlyUntil = segment.Offset;
		foreach (T ts in segments.FindOverlappingSegments(segment))
		{
			int start = ts.StartOffset;
			int end = start + ts.Length;
			if (start > readonlyUntil)
			{
				yield return new SimpleSegment(readonlyUntil, start - readonlyUntil);
			}
			if (end > readonlyUntil)
			{
				readonlyUntil = end;
			}
		}
		int endOffset = segment.EndOffset;
		if (readonlyUntil < endOffset)
		{
			yield return new SimpleSegment(readonlyUntil, endOffset - readonlyUntil);
		}
	}
}
