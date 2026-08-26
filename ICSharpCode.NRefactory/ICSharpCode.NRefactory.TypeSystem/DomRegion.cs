using System;
using System.Globalization;

namespace ICSharpCode.NRefactory.TypeSystem;

[Serializable]
public struct DomRegion : IEquatable<DomRegion>
{
	private readonly string fileName;

	private readonly int beginLine;

	private readonly int endLine;

	private readonly int beginColumn;

	private readonly int endColumn;

	public static readonly DomRegion Empty;

	public bool IsEmpty => BeginLine <= 0;

	public string FileName => fileName;

	public int BeginLine => beginLine;

	public int EndLine => endLine;

	public int BeginColumn => beginColumn;

	public int EndColumn => endColumn;

	public TextLocation Begin => new TextLocation(beginLine, beginColumn);

	public TextLocation End => new TextLocation(endLine, endColumn);

	public DomRegion(int beginLine, int beginColumn, int endLine, int endColumn)
		: this(null, beginLine, beginColumn, endLine, endColumn)
	{
	}

	public DomRegion(string fileName, int beginLine, int beginColumn, int endLine, int endColumn)
	{
		this.fileName = fileName;
		this.beginLine = beginLine;
		this.beginColumn = beginColumn;
		this.endLine = endLine;
		this.endColumn = endColumn;
	}

	public DomRegion(int beginLine, int beginColumn)
		: this(null, beginLine, beginColumn)
	{
	}

	public DomRegion(string fileName, int beginLine, int beginColumn)
	{
		this.fileName = fileName;
		this.beginLine = beginLine;
		this.beginColumn = beginColumn;
		endLine = -1;
		endColumn = -1;
	}

	public DomRegion(TextLocation begin, TextLocation end)
		: this(null, begin, end)
	{
	}

	public DomRegion(string fileName, TextLocation begin, TextLocation end)
	{
		this.fileName = fileName;
		beginLine = begin.Line;
		beginColumn = begin.Column;
		endLine = end.Line;
		endColumn = end.Column;
	}

	public DomRegion(TextLocation begin)
		: this(null, begin)
	{
	}

	public DomRegion(string fileName, TextLocation begin)
	{
		this.fileName = fileName;
		beginLine = begin.Line;
		beginColumn = begin.Column;
		endLine = -1;
		endColumn = -1;
	}

	public bool IsInside(int line, int column)
	{
		if (IsEmpty)
		{
			return false;
		}
		if (line >= BeginLine && (line <= EndLine || EndLine == -1) && (line != BeginLine || column >= BeginColumn))
		{
			if (line == EndLine)
			{
				return column <= EndColumn;
			}
			return true;
		}
		return false;
	}

	public bool IsInside(TextLocation location)
	{
		return IsInside(location.Line, location.Column);
	}

	public bool Contains(int line, int column)
	{
		if (IsEmpty)
		{
			return false;
		}
		if (line >= BeginLine && (line <= EndLine || EndLine == -1) && (line != BeginLine || column >= BeginColumn))
		{
			if (line == EndLine)
			{
				return column < EndColumn;
			}
			return true;
		}
		return false;
	}

	public bool Contains(TextLocation location)
	{
		return Contains(location.Line, location.Column);
	}

	public bool IntersectsWith(DomRegion region)
	{
		if (region.Begin <= End)
		{
			return region.End >= Begin;
		}
		return false;
	}

	public bool OverlapsWith(DomRegion region)
	{
		TextLocation textLocation = ((Begin > region.Begin) ? Begin : region.Begin);
		TextLocation textLocation2 = ((End < region.End) ? End : region.End);
		return textLocation < textLocation2;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "[DomRegion FileName={0}, Begin=({1}, {2}), End=({3}, {4})]", fileName, beginLine, beginColumn, endLine, endColumn);
	}

	public override bool Equals(object obj)
	{
		if (obj is DomRegion)
		{
			return Equals((DomRegion)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = ((fileName != null) ? fileName.GetHashCode() : 0);
		return num ^ (beginColumn + 1100009 * beginLine + 1200007 * endLine + 1300021 * endColumn);
	}

	public bool Equals(DomRegion other)
	{
		if (beginLine == other.beginLine && beginColumn == other.beginColumn && endLine == other.endLine && endColumn == other.endColumn)
		{
			return fileName == other.fileName;
		}
		return false;
	}

	public static bool operator ==(DomRegion left, DomRegion right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(DomRegion left, DomRegion right)
	{
		return !left.Equals(right);
	}
}
