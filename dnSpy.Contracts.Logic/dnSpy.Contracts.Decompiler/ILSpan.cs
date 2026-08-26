using System;
using System.Collections.Generic;
using System.Linq;

namespace dnSpy.Contracts.Decompiler;

public readonly struct ILSpan : IEquatable<ILSpan>
{
	private sealed class ILSpanComparer : IComparer<ILSpan>
	{
		public static readonly IComparer<ILSpan> Instance = new ILSpanComparer();

		public int Compare(ILSpan x, ILSpan y)
		{
			int num = (int)(x.Start - y.Start);
			if (num != 0)
			{
				return num;
			}
			return (int)(y.End - x.End);
		}
	}

	private readonly uint start;

	private readonly uint end;

	public uint Start => start;

	public uint End => end;

	public uint Length => end - start;

	public bool IsEmpty => end == start;

	public ILSpan(uint start, uint length)
	{
		this.start = start;
		end = start + length;
	}

	public static ILSpan FromBounds(uint start, uint end)
	{
		if (end < start)
		{
			throw new ArgumentOutOfRangeException("end");
		}
		return new ILSpan(start, end - start);
	}

	public static List<ILSpan> OrderAndCompact(IEnumerable<ILSpan> input)
	{
		return OrderAndCompactList(input.ToList());
	}

	public static List<ILSpan> OrderAndCompactList(List<ILSpan> input)
	{
		if (input.Count <= 1)
		{
			return input;
		}
		input.Sort(ILSpanComparer.Instance);
		List<ILSpan> list = new List<ILSpan>();
		ILSpan item = input[0];
		list.Add(item);
		for (int i = 1; i < input.Count; i++)
		{
			ILSpan iLSpan = input[i];
			if (item.End == iLSpan.Start)
			{
				item = (list[list.Count - 1] = new ILSpan(item.Start, iLSpan.End - item.Start));
			}
			else if (iLSpan.Start > item.End)
			{
				list.Add(iLSpan);
				item = iLSpan;
			}
			else if (iLSpan.End > item.End)
			{
				item = (list[list.Count - 1] = new ILSpan(item.Start, iLSpan.End - item.Start));
			}
		}
		return list;
	}

	public static bool operator ==(ILSpan left, ILSpan right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(ILSpan left, ILSpan right)
	{
		return !left.Equals(right);
	}

	public bool Equals(ILSpan other)
	{
		return start == other.start && end == other.end;
	}

	public override bool Equals(object obj)
	{
		return obj is ILSpan && Equals((ILSpan)obj);
	}

	public override int GetHashCode()
	{
		return (int)(start ^ ((end << 16) | (end >> 16)));
	}

	public override string ToString()
	{
		return "[" + start.ToString("X4") + "," + end.ToString("X4") + ")";
	}
}
