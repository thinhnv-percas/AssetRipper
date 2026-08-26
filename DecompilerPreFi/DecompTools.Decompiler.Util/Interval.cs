using System;

namespace DecompTools.Decompiler.Util;

public struct Interval : IEquatable<Interval>
{
	public readonly int Start;

	public readonly int End;

	public int InclusiveEnd => End - 1;

	public bool IsEmpty => Start > InclusiveEnd;

	public Interval(int start, int end)
	{
		if (start > end - 1 && start != end)
		{
			throw new ArgumentException("The end must be after the start", "end");
		}
		Start = start;
		End = end;
	}

	public bool Contains(int val)
	{
		return Start <= val && val <= InclusiveEnd;
	}

	public Interval Intersect(Interval other)
	{
		int num = Math.Max(Start, other.Start);
		int num2 = Math.Min(InclusiveEnd, other.InclusiveEnd);
		if (num <= num2)
		{
			return new Interval(num, num2 + 1);
		}
		return default(Interval);
	}

	public override string ToString()
	{
		if (End == int.MinValue)
		{
			return $"[{Start}..int.MaxValue]";
		}
		return $"[{Start}..{End})";
	}

	public override bool Equals(object obj)
	{
		return obj is Interval && Equals((Interval)obj);
	}

	public bool Equals(Interval other)
	{
		return Start == other.Start && End == other.End;
	}

	public override int GetHashCode()
	{
		return Start ^ End ^ (End << 7);
	}

	public static bool operator ==(Interval lhs, Interval rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(Interval lhs, Interval rhs)
	{
		return !(lhs == rhs);
	}
}
