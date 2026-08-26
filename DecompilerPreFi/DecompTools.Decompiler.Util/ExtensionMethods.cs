using System;

namespace DecompTools.Decompiler.Util;

internal static class ExtensionMethods
{
	public static Predicate<T> And<T>(this Predicate<T> filter1, Predicate<T> filter2)
	{
		if (filter1 == null)
		{
			return filter2;
		}
		if (filter2 == null)
		{
			return filter1;
		}
		return (T m) => filter1(m) && filter2(m);
	}

	public static void Swap<T>(ref T a, ref T b)
	{
		T val = a;
		a = b;
		b = val;
	}
}
