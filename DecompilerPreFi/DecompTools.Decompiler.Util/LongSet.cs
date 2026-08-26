#define DEBUG
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace DecompTools.Decompiler.Util;

public struct LongSet : IEquatable<LongSet>
{
	public readonly ImmutableArray<LongInterval> Intervals;

	public static readonly LongSet Empty = new LongSet(ImmutableArray.Create<LongInterval>());

	public static readonly LongSet Universe = new LongSet(LongInterval.Inclusive(long.MinValue, long.MaxValue));

	public bool IsEmpty => Intervals.IsEmpty;

	public IEnumerable<long> Values => Enumerable.SelectMany<LongInterval, long>((IEnumerable<LongInterval>)Intervals, (Func<LongInterval, IEnumerable<long>>)((LongInterval i) => i.Range()));

	private LongSet(ImmutableArray<LongInterval> intervals)
	{
		Intervals = intervals;
		long num = long.MinValue;
		checked
		{
			for (int i = 0; i < intervals.Length; i++)
			{
				Debug.Assert(!intervals[i].IsEmpty);
				Debug.Assert(num <= intervals[i].Start);
				if (intervals[i].InclusiveEnd == 9223372036854775806L || intervals[i].InclusiveEnd == long.MaxValue)
				{
					Debug.Assert(i == intervals.Length - 1);
				}
				else
				{
					num = intervals[i].End + 1;
				}
			}
		}
	}

	public LongSet(long value)
		: this(ImmutableArray.Create(LongInterval.Inclusive(value, value)))
	{
	}

	public LongSet(LongInterval interval)
		: this(interval.IsEmpty ? Empty.Intervals : ImmutableArray.Create(interval))
	{
	}

	public LongSet(IEnumerable<LongInterval> intervals)
		: this(MergeOverlapping((IEnumerable<LongInterval>)Enumerable.OrderBy<LongInterval, long>(Enumerable.Where<LongInterval>(intervals, (Func<LongInterval, bool>)((LongInterval i) => !i.IsEmpty)), (Func<LongInterval, long>)((LongInterval i) => i.Start))).ToImmutableArray())
	{
	}

	public ulong Count()
	{
		ulong num = 0uL;
		foreach (LongInterval interval in Intervals)
		{
			num += (ulong)(interval.End - interval.Start);
		}
		if (num == 0L && !Intervals.IsEmpty)
		{
			return ulong.MaxValue;
		}
		return num;
	}

	private IEnumerable<LongInterval> DoIntersectWith(LongSet other)
	{
		ImmutableArray<LongInterval>.Enumerator enumA = Intervals.GetEnumerator();
		ImmutableArray<LongInterval>.Enumerator enumB = other.Intervals.GetEnumerator();
		bool moreA = enumA.MoveNext();
		bool moreB = enumB.MoveNext();
		while (moreA & moreB)
		{
			LongInterval a = enumA.Current;
			LongInterval b = enumB.Current;
			LongInterval intersection = a.Intersect(b);
			if (!intersection.IsEmpty)
			{
				yield return intersection;
			}
			if (a.InclusiveEnd < b.InclusiveEnd)
			{
				moreA = enumA.MoveNext();
			}
			else
			{
				moreB = enumB.MoveNext();
			}
		}
	}

	public bool Overlaps(LongSet other)
	{
		return Enumerable.Any<LongInterval>(DoIntersectWith(other));
	}

	public LongSet IntersectWith(LongSet other)
	{
		return new LongSet(DoIntersectWith(other).ToImmutableArray());
	}

	private static IEnumerable<LongInterval> MergeOverlapping(IEnumerable<LongInterval> input)
	{
		long start = long.MinValue;
		long end = long.MinValue;
		bool empty = true;
		foreach (LongInterval element in input)
		{
			Debug.Assert(start <= element.Start);
			Debug.Assert(!element.IsEmpty);
			if (!empty && element.Start <= end)
			{
				end = ((element.End != long.MinValue) ? Math.Max(end, element.End) : long.MinValue);
			}
			else
			{
				if (!empty)
				{
					yield return new LongInterval(start, end);
				}
				else
				{
					empty = false;
				}
				start = element.Start;
				end = element.End;
			}
			if (end == long.MinValue)
			{
				break;
			}
		}
		if (!empty)
		{
			yield return new LongInterval(start, end);
		}
	}

	public LongSet UnionWith(LongSet other)
	{
		IEnumerable<LongInterval> input = Intervals.Merge(other.Intervals, delegate(LongInterval a, LongInterval b)
		{
			long start = a.Start;
			return start.CompareTo(b.Start);
		});
		return new LongSet(MergeOverlapping(input).ToImmutableArray());
	}

	public LongSet AddOffset(long val)
	{
		if (val == 0)
		{
			return this;
		}
		List<LongInterval> list = new List<LongInterval>(checked(Intervals.Length + 1));
		foreach (LongInterval interval in Intervals)
		{
			long num = interval.Start + val;
			long num2 = interval.InclusiveEnd + val;
			if (num <= num2)
			{
				list.Add(LongInterval.Inclusive(num, num2));
				continue;
			}
			list.Add(LongInterval.Inclusive(num, long.MaxValue));
			list.Add(LongInterval.Inclusive(long.MinValue, num2));
		}
		list.Sort(delegate(LongInterval a, LongInterval b)
		{
			long start = a.Start;
			return start.CompareTo(b.Start);
		});
		return new LongSet(MergeOverlapping(list).ToImmutableArray());
	}

	public LongSet ExceptWith(LongSet other)
	{
		return IntersectWith(other.Invert());
	}

	public LongSet Invert()
	{
		if (IsEmpty)
		{
			return Universe;
		}
		List<LongInterval> list = new List<LongInterval>(checked(Intervals.Length + 1));
		long num = long.MinValue;
		foreach (LongInterval interval in Intervals)
		{
			if (interval.Start > num)
			{
				list.Add(new LongInterval(num, interval.Start));
			}
			num = interval.End;
		}
		if (num != long.MinValue)
		{
			list.Add(new LongInterval(num, long.MinValue));
		}
		return new LongSet(list.ToImmutableArray());
	}

	public bool IsSubsetOf(LongSet other)
	{
		return UnionWith(other).SetEquals(other);
	}

	public bool IsSupersetOf(LongSet other)
	{
		return other.IsSubsetOf(this);
	}

	public bool IsProperSubsetOf(LongSet other)
	{
		return IsSubsetOf(other) && !SetEquals(other);
	}

	public bool IsProperSupersetOf(LongSet other)
	{
		return IsSupersetOf(other) && !SetEquals(other);
	}

	public bool Contains(long val)
	{
		int num = upper_bound(val);
		return num > 0 && Intervals[checked(num - 1)].Contains(val);
	}

	internal int upper_bound(long val)
	{
		int num = 0;
		checked
		{
			int num2 = Intervals.Length - 1;
			while (num2 >= num)
			{
				int num3 = num + unchecked(checked(num2 - num) / 2);
				LongInterval longInterval = Intervals[num3];
				if (val < longInterval.Start)
				{
					num2 = num3 - 1;
					continue;
				}
				if (val > longInterval.End)
				{
					num = num3 + 1;
					continue;
				}
				return num3 + 1;
			}
			return num;
		}
	}

	public override string ToString()
	{
		return string.Join(",", Intervals);
	}

	public override bool Equals(object obj)
	{
		return obj is LongSet && SetEquals((LongSet)obj);
	}

	public override int GetHashCode()
	{
		throw new NotImplementedException();
	}

	[Obsolete("Explicitly call SetEquals() instead.")]
	public bool Equals(LongSet other)
	{
		return SetEquals(other);
	}

	public bool SetEquals(LongSet other)
	{
		if (Intervals.Length != other.Intervals.Length)
		{
			return false;
		}
		for (int i = 0; i < Intervals.Length; i = checked(i + 1))
		{
			if (Intervals[i] != other.Intervals[i])
			{
				return false;
			}
		}
		return true;
	}
}
