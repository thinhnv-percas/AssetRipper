using System.Collections;
using System.Collections.Generic;
using System.Numerics.Hashing;
using System.Runtime.InteropServices;

namespace System;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct ValueTuple
{
	public static (T1, T2) Create<T1, T2>(T1 item1, T2 item2)
	{
		return (item1, item2);
	}
}
[StructLayout(LayoutKind.Auto)]
internal struct ValueTuple<T1, T2> : IEquatable<(T1, T2)>
{
	public T1 Item1;

	public T2 Item2;

	public ValueTuple(T1 item1, T2 item2)
	{
		Item1 = item1;
		Item2 = item2;
	}

	public override bool Equals(object obj)
	{
		if (obj is ValueTuple<T1, T2>)
		{
			return Equals(((T1, T2))obj);
		}
		return false;
	}

	public bool Equals((T1, T2) other)
	{
		if (EqualityComparer<T1>.Default.Equals(Item1, other.Item1))
		{
			return EqualityComparer<T2>.Default.Equals(Item2, other.Item2);
		}
		return false;
	}

	internal static int CombineHashCodes(int h1, int h2)
	{
		return System.Numerics.Hashing.HashHelpers.Combine(System.Numerics.Hashing.HashHelpers.Combine(System.Numerics.Hashing.HashHelpers.RandomSeed, h1), h2);
	}

	public override int GetHashCode()
	{
		return CombineHashCodes(Item1?.GetHashCode() ?? 0, Item2?.GetHashCode() ?? 0);
	}

	private int GetHashCodeCore(IEqualityComparer comparer)
	{
		return CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2));
	}

	public override string ToString()
	{
		return "(" + Item1?.ToString() + ", " + Item2?.ToString() + ")";
	}
}
