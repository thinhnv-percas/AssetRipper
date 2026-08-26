using System;
using System.Collections.Generic;

namespace ICSharpCode.Decompiler.ILAst;

internal class StateRange
{
	private readonly List<Interval> data = new List<Interval>();

	public bool IsEmpty => data.Count == 0;

	public StateRange()
	{
	}

	public StateRange(int start, int end)
	{
		data.Add(new Interval(start, end));
	}

	public int? TryGetSingleState()
	{
		if (data.Count != 1)
		{
			return null;
		}
		Interval interval = data[0];
		if (interval.Start == interval.End)
		{
			return interval.Start;
		}
		return null;
	}

	public bool Contains(int val)
	{
		foreach (Interval datum in data)
		{
			if (datum.Start <= val && val <= datum.End)
			{
				return true;
			}
		}
		return false;
	}

	public void UnionWith(StateRange other)
	{
		data.AddRange(other.data);
	}

	public void UnionWith(StateRange other, int minVal, int maxVal)
	{
		foreach (Interval datum in other.data)
		{
			int num = Math.Max(datum.Start, minVal);
			int num2 = Math.Min(datum.End, maxVal);
			if (num <= num2)
			{
				data.Add(new Interval(num, num2));
			}
		}
	}

	public void Simplify()
	{
		if (data.Count < 2)
		{
			return;
		}
		data.Sort((Interval a, Interval b) => a.Start.CompareTo(b.Start));
		Interval value = data[0];
		int num = 0;
		for (int num2 = 1; num2 < data.Count; num2++)
		{
			Interval interval = data[num2];
			if (interval.Start <= value.End + 1)
			{
				value = new Interval(value.Start, Math.Max(value.End, interval.End));
				data[num] = value;
			}
			else
			{
				value = interval;
				num = num2;
			}
		}
		int num3 = data.Count - num - 1;
		if (num3 > 0)
		{
			data.RemoveRange(num + 1, num3);
		}
	}

	public override string ToString()
	{
		return string.Join(",", data);
	}

	public Interval ToEnclosingInterval()
	{
		if (data.Count == 0)
		{
			throw new SymbolicAnalysisFailedException();
		}
		return new Interval(data[0].Start, data[data.Count - 1].End);
	}
}
