using System;

namespace dnSpy.Contracts.Decompiler;

public readonly struct TextSpan : IEquatable<TextSpan>
{
	private readonly int start;

	private readonly int end;

	public int Start => start;

	public int End => end;

	public int Length => end - start;

	public bool IsEmpty => end == start;

	public TextSpan(int start, int length)
	{
		if (start < 0)
		{
			throw new ArgumentOutOfRangeException("start");
		}
		this.start = start;
		end = start + length;
		if (end < start)
		{
			throw new ArgumentOutOfRangeException("length");
		}
	}

	public static TextSpan FromBounds(int start, int end)
	{
		return new TextSpan(start, end - start);
	}

	public static bool operator ==(TextSpan left, TextSpan right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(TextSpan left, TextSpan right)
	{
		return !left.Equals(right);
	}

	public bool Contains(int position)
	{
		return start <= position && position < end;
	}

	public bool Intersects(int position)
	{
		return start <= position && position <= end;
	}

	public bool Equals(TextSpan other)
	{
		return start == other.start && end == other.end;
	}

	public override bool Equals(object obj)
	{
		return obj is TextSpan && Equals((TextSpan)obj);
	}

	public override int GetHashCode()
	{
		return start ^ ((end << 16) | (end >> 16));
	}

	public override string ToString()
	{
		return "[" + start + "," + end + ")";
	}
}
