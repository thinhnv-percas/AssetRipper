using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.ILAst
{
	public static class ILAstBuilderExtensionMethods
	{
		public static List<T> CutRange<T>(this List<T> list, int start, int count)
		{
			List<T> list2 = new List<T>(count);
			for (int i = 0; i < count; i++)
			{
				list2.Add(list[start + i]);
			}
			list.RemoveRange(start, count);
			return list2;
		}

		public static T[] Union<T>(this T[] a, T b)
		{
			if (a.Length == 0)
			{
				return new T[1]
				{
					b
				};
			}
			if (Array.IndexOf(a, b) >= 0)
			{
				return a;
			}
			T[] array = new T[a.Length + 1];
			Array.Copy(a, 0, array, 0, a.Length);
			array[array.Length - 1] = b;
			return array;
		}

		public static T[] Union<T>(this T[] a, T[] b)
		{
			if (a == b)
			{
				return a;
			}
			if (a.Length == 0)
			{
				return b;
			}
			if (b.Length == 0)
			{
				return a;
			}
			if (a.Length == 1)
			{
				if (b.Length == 1)
				{
					if (!a[0].Equals(b[0]))
					{
						return new T[2]
						{
							a[0],
							b[0]
						};
					}
					return a;
				}
				return b.Union(a[0]);
			}
			if (b.Length == 1)
			{
				return a.Union(b[0]);
			}
			return Enumerable.Union(a, b).ToArray();
		}
	}
}
