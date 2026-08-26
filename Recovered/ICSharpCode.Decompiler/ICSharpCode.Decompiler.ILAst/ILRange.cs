using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.ILAst
{
	public struct ILRange
	{
		public readonly int From;

		public readonly int To;

		public ILRange(int from, int to)
		{
			From = from;
			To = to;
		}

		public override string ToString()
		{
			return $"{From:X2}-{To:X2}";
		}

		public static List<ILRange> OrderAndJoin(IEnumerable<ILRange> input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("Input is null!");
			}
			List<ILRange> list = new List<ILRange>();
			foreach (ILRange item in from r in input
				orderby r.From
				select r)
			{
				if (list.Count > 0)
				{
					ILRange iLRange = list[list.Count - 1];
					if (item.From <= iLRange.To)
					{
						list[list.Count - 1] = new ILRange(iLRange.From, Math.Max(iLRange.To, item.To));
						continue;
					}
				}
				list.Add(item);
			}
			return list;
		}

		public static List<ILRange> Invert(IEnumerable<ILRange> input, int codeSize)
		{
			if (input == null)
			{
				throw new ArgumentNullException("Input is null!");
			}
			if (codeSize <= 0)
			{
				throw new ArgumentException("Code size must be grater than 0");
			}
			List<ILRange> list = OrderAndJoin(input);
			List<ILRange> list2 = new List<ILRange>(list.Count + 1);
			if (list.Count == 0)
			{
				list2.Add(new ILRange(0, codeSize));
			}
			else
			{
				if (list.First().From != 0)
				{
					list2.Add(new ILRange(0, list.First().From));
				}
				for (int i = 0; i < list.Count - 1; i++)
				{
					list2.Add(new ILRange(list[i].To, list[i + 1].From));
				}
				if (list.Last().To != codeSize)
				{
					list2.Add(new ILRange(list.Last().To, codeSize));
				}
			}
			return list2;
		}
	}
}
