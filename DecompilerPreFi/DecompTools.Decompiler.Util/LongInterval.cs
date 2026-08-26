using System;
using System.Collections.Generic;

namespace DecompTools.Decompiler.Util;

public struct LongInterval : IEquatable<LongInterval>
{
	public readonly long Start;

	public readonly long End;

	public long InclusiveEnd => End - 1;

	public bool IsEmpty => Start > InclusiveEnd;

	public LongInterval(long start, long end)
	{
		if (start > end - 1 && start != end)
		{
			throw new ArgumentException("The end must be after the start", "end");
		}
		Start = start;
		End = end;
	}

	public static LongInterval Inclusive(long start, long inclusiveEnd)
	{
		if (start > inclusiveEnd)
		{
			throw new ArgumentException();
		}
		return new LongInterval(start, inclusiveEnd + 1);
	}

	public bool Contains(long val)
	{
		return Start <= val && val <= InclusiveEnd;
	}

	public LongInterval Intersect(LongInterval other)
	{
		long num = Math.Max(Start, other.Start);
		long num2 = Math.Min(InclusiveEnd, other.InclusiveEnd);
		if (num <= num2)
		{
			return new LongInterval(num, num2 + 1);
		}
		return default(LongInterval);
	}

	public IEnumerable<long> Range()
	{
		checked
		{
			if (End == long.MinValue)
			{
				long i = Start;
				while (true)
				{
					yield return i;
					if (i == long.MaxValue)
					{
						break;
					}
					i++;
				}
			}
			else
			{
				for (long i2 = Start; i2 < End; i2++)
				{
					yield return i2;
				}
			}
		}
	}

	public override string ToString()
	{
		if (End == long.MinValue)
		{
			if (Start == long.MinValue)
			{
				return string.Format("[long.MinValue..long.MaxValue]", End);
			}
			return $"[{Start}..long.MaxValue]";
		}
		if (Start == long.MinValue)
		{
			return $"[long.MinValue..{End})";
		}
		return $"[{Start}..{End})";
	}

	public override bool Equals(object obj)
	{
		return obj is LongInterval && Equals((LongInterval)obj);
	}

	public bool Equals(LongInterval other)
	{
		return Start == other.Start && End == other.End;
	}

	public override int GetHashCode()
	{
		return (Start ^ End ^ (End << 7)).GetHashCode();
	}

	public static bool operator ==(LongInterval lhs, LongInterval rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(LongInterval lhs, LongInterval rhs)
	{
		return !(lhs == rhs);
	}
}
