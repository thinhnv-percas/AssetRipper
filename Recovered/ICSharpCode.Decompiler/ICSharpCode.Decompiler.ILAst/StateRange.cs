using System;
using System.Collections.Generic;

namespace ICSharpCode.Decompiler.ILAst
{
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
			Interval interval = data[0];
			int index = 0;
			for (int j = 1; j < data.Count; j++)
			{
				Interval interval2 = data[j];
				if (interval2.Start <= interval.End + 1)
				{
					interval = new Interval(interval.Start, Math.Max(interval.End, interval2.End));
					data[index] = interval;
					data[j] = new Interval(0, -1);
				}
				else
				{
					interval = interval2;
					index = j;
				}
			}
			data.RemoveAll((Interval i) => i.Start > i.End);
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
}
