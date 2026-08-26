#define DEBUG
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics.Hashing;
using System.Runtime.InteropServices;

namespace System;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ValueTuple : IEquatable<ValueTuple>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<ValueTuple>, ITupleInternal
{
	int ITupleInternal.Size => 0;

	public override bool Equals(object obj)
	{
		return obj is ValueTuple;
	}

	public bool Equals(ValueTuple other)
	{
		return true;
	}

	bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
	{
		return other is ValueTuple;
	}

	int IComparable.CompareTo(object other)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is ValueTuple))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		return 0;
	}

	public int CompareTo(ValueTuple other)
	{
		return 0;
	}

	int IStructuralComparable.CompareTo(object other, IComparer comparer)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is ValueTuple))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		return 0;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
	{
		return 0;
	}

	int ITupleInternal.GetHashCode(IEqualityComparer comparer)
	{
		return 0;
	}

	public override string ToString()
	{
		return "()";
	}

	string ITupleInternal.ToStringEnd()
	{
		return ")";
	}

	public static ValueTuple Create()
	{
		return default(ValueTuple);
	}

	public static ValueTuple<T1> Create<T1>(T1 item1)
	{
		return new ValueTuple<T1>(item1);
	}

	public static (T1, T2) Create<T1, T2>(T1 item1, T2 item2)
	{
		return (item1, item2);
	}

	public static (T1, T2, T3) Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
	{
		return (item1, item2, item3);
	}

	public static (T1, T2, T3, T4) Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
	{
		return (item1, item2, item3, item4);
	}

	public static (T1, T2, T3, T4, T5) Create<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
	{
		return (item1, item2, item3, item4, item5);
	}

	public static (T1, T2, T3, T4, T5, T6) Create<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
	{
		return (item1, item2, item3, item4, item5, item6);
	}

	public static (T1, T2, T3, T4, T5, T6, T7) Create<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
	{
		return (item1, item2, item3, item4, item5, item6, item7);
	}

	public static (T1, T2, T3, T4, T5, T6, T7, T8) Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
	{
		return new ValueTuple<T1, T2, T3, T4, T5, T6, T7, ValueTuple<T8>>(item1, item2, item3, item4, item5, item6, item7, Create(item8));
	}

	internal static int CombineHashCodes(int h1, int h2)
	{
		return HashHelpers.Combine(HashHelpers.Combine(HashHelpers.RandomSeed, h1), h2);
	}

	internal static int CombineHashCodes(int h1, int h2, int h3)
	{
		return HashHelpers.Combine(CombineHashCodes(h1, h2), h3);
	}

	internal static int CombineHashCodes(int h1, int h2, int h3, int h4)
	{
		return HashHelpers.Combine(CombineHashCodes(h1, h2, h3), h4);
	}

	internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5)
	{
		return HashHelpers.Combine(CombineHashCodes(h1, h2, h3, h4), h5);
	}

	internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6)
	{
		return HashHelpers.Combine(CombineHashCodes(h1, h2, h3, h4, h5), h6);
	}

	internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7)
	{
		return HashHelpers.Combine(CombineHashCodes(h1, h2, h3, h4, h5, h6), h7);
	}

	internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8)
	{
		return HashHelpers.Combine(CombineHashCodes(h1, h2, h3, h4, h5, h6, h7), h8);
	}
}
public struct ValueTuple<T1> : IEquatable<ValueTuple<T1>>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<ValueTuple<T1>>, ITupleInternal
{
	public T1 Item1;

	int ITupleInternal.Size => 1;

	public ValueTuple(T1 item1)
	{
		Item1 = item1;
	}

	public override bool Equals(object obj)
	{
		return obj is ValueTuple<T1> && Equals((ValueTuple<T1>)obj);
	}

	public bool Equals(ValueTuple<T1> other)
	{
		return EqualityComparer<T1>.Default.Equals(Item1, other.Item1);
	}

	bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
	{
		if (other == null || !(other is ValueTuple<T1>))
		{
			return false;
		}
		ValueTuple<T1> valueTuple = (ValueTuple<T1>)other;
		return comparer.Equals(Item1, valueTuple.Item1);
	}

	int IComparable.CompareTo(object other)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is ValueTuple<T1> valueTuple))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		return Comparer<T1>.Default.Compare(Item1, valueTuple.Item1);
	}

	public int CompareTo(ValueTuple<T1> other)
	{
		return Comparer<T1>.Default.Compare(Item1, other.Item1);
	}

	int IStructuralComparable.CompareTo(object other, IComparer comparer)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is ValueTuple<T1> valueTuple))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		return comparer.Compare(Item1, valueTuple.Item1);
	}

	public override int GetHashCode()
	{
		return EqualityComparer<T1>.Default.GetHashCode(Item1);
	}

	int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
	{
		return comparer.GetHashCode(Item1);
	}

	int ITupleInternal.GetHashCode(IEqualityComparer comparer)
	{
		return comparer.GetHashCode(Item1);
	}

	public override string ToString()
	{
		return "(" + Item1?.ToString() + ")";
	}

	string ITupleInternal.ToStringEnd()
	{
		return Item1?.ToString() + ")";
	}
}
public struct ValueTuple<T1, T2> : IEquatable<(T1, T2)>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<(T1, T2)>, ITupleInternal
{
	public T1 Item1;

	public T2 Item2;

	int ITupleInternal.Size => 2;

	public ValueTuple(T1 item1, T2 item2)
	{
		Item1 = item1;
		Item2 = item2;
	}

	public override bool Equals(object obj)
	{
		return obj is ValueTuple<T1, T2> && Equals(((T1, T2))obj);
	}

	public bool Equals((T1, T2) other)
	{
		return EqualityComparer<T1>.Default.Equals(Item1, other.Item1) && EqualityComparer<T2>.Default.Equals(Item2, other.Item2);
	}

	bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
	{
		if (other == null || !(other is ValueTuple<T1, T2>))
		{
			return false;
		}
		(T1, T2) tuple = ((T1, T2))other;
		return comparer.Equals(Item1, tuple.Item1) && comparer.Equals(Item2, tuple.Item2);
	}

	int IComparable.CompareTo(object other)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is ValueTuple<T1, T2>))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		return CompareTo(((T1, T2))other);
	}

	public int CompareTo((T1, T2) other)
	{
		int num = Comparer<T1>.Default.Compare(Item1, other.Item1);
		if (num != 0)
		{
			return num;
		}
		return Comparer<T2>.Default.Compare(Item2, other.Item2);
	}

	int IStructuralComparable.CompareTo(object other, IComparer comparer)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is (T1, T2) tuple))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		int num = comparer.Compare(Item1, tuple.Item1);
		if (num != 0)
		{
			return num;
		}
		return comparer.Compare(Item2, tuple.Item2);
	}

	public override int GetHashCode()
	{
		return ValueTuple.CombineHashCodes(EqualityComparer<T1>.Default.GetHashCode(Item1), EqualityComparer<T2>.Default.GetHashCode(Item2));
	}

	int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
	{
		return GetHashCodeCore(comparer);
	}

	private int GetHashCodeCore(IEqualityComparer comparer)
	{
		return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2));
	}

	int ITupleInternal.GetHashCode(IEqualityComparer comparer)
	{
		return GetHashCodeCore(comparer);
	}

	public override string ToString()
	{
		return "(" + Item1?.ToString() + ", " + Item2?.ToString() + ")";
	}

	string ITupleInternal.ToStringEnd()
	{
		return Item1?.ToString() + ", " + Item2?.ToString() + ")";
	}
}
public struct ValueTuple<T1, T2, T3> : IEquatable<(T1, T2, T3)>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<(T1, T2, T3)>, ITupleInternal
{
	public T1 Item1;

	public T2 Item2;

	public T3 Item3;

	int ITupleInternal.Size => 3;

	public ValueTuple(T1 item1, T2 item2, T3 item3)
	{
		Item1 = item1;
		Item2 = item2;
		Item3 = item3;
	}

	public override bool Equals(object obj)
	{
		return obj is ValueTuple<T1, T2, T3> && Equals(((T1, T2, T3))obj);
	}

	public bool Equals((T1, T2, T3) other)
	{
		return EqualityComparer<T1>.Default.Equals(Item1, other.Item1) && EqualityComparer<T2>.Default.Equals(Item2, other.Item2) && EqualityComparer<T3>.Default.Equals(Item3, other.Item3);
	}

	bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
	{
		if (other == null || !(other is ValueTuple<T1, T2, T3>))
		{
			return false;
		}
		(T1, T2, T3) tuple = ((T1, T2, T3))other;
		return comparer.Equals(Item1, tuple.Item1) && comparer.Equals(Item2, tuple.Item2) && comparer.Equals(Item3, tuple.Item3);
	}

	int IComparable.CompareTo(object other)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is ValueTuple<T1, T2, T3>))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		return CompareTo(((T1, T2, T3))other);
	}

	public int CompareTo((T1, T2, T3) other)
	{
		int num = Comparer<T1>.Default.Compare(Item1, other.Item1);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T2>.Default.Compare(Item2, other.Item2);
		if (num != 0)
		{
			return num;
		}
		return Comparer<T3>.Default.Compare(Item3, other.Item3);
	}

	int IStructuralComparable.CompareTo(object other, IComparer comparer)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is (T1, T2, T3) tuple))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		int num = comparer.Compare(Item1, tuple.Item1);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item2, tuple.Item2);
		if (num != 0)
		{
			return num;
		}
		return comparer.Compare(Item3, tuple.Item3);
	}

	public override int GetHashCode()
	{
		return ValueTuple.CombineHashCodes(EqualityComparer<T1>.Default.GetHashCode(Item1), EqualityComparer<T2>.Default.GetHashCode(Item2), EqualityComparer<T3>.Default.GetHashCode(Item3));
	}

	int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
	{
		return GetHashCodeCore(comparer);
	}

	private int GetHashCodeCore(IEqualityComparer comparer)
	{
		return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3));
	}

	int ITupleInternal.GetHashCode(IEqualityComparer comparer)
	{
		return GetHashCodeCore(comparer);
	}

	public override string ToString()
	{
		return "(" + Item1?.ToString() + ", " + Item2?.ToString() + ", " + Item3?.ToString() + ")";
	}

	string ITupleInternal.ToStringEnd()
	{
		return Item1?.ToString() + ", " + Item2?.ToString() + ", " + Item3?.ToString() + ")";
	}
}
public struct ValueTuple<T1, T2, T3, T4> : IEquatable<(T1, T2, T3, T4)>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<(T1, T2, T3, T4)>, ITupleInternal
{
	public T1 Item1;

	public T2 Item2;

	public T3 Item3;

	public T4 Item4;

	int ITupleInternal.Size => 4;

	public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4)
	{
		Item1 = item1;
		Item2 = item2;
		Item3 = item3;
		Item4 = item4;
	}

	public override bool Equals(object obj)
	{
		return obj is ValueTuple<T1, T2, T3, T4> && Equals(((T1, T2, T3, T4))obj);
	}

	public bool Equals((T1, T2, T3, T4) other)
	{
		return EqualityComparer<T1>.Default.Equals(Item1, other.Item1) && EqualityComparer<T2>.Default.Equals(Item2, other.Item2) && EqualityComparer<T3>.Default.Equals(Item3, other.Item3) && EqualityComparer<T4>.Default.Equals(Item4, other.Item4);
	}

	bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
	{
		if (other == null || !(other is ValueTuple<T1, T2, T3, T4>))
		{
			return false;
		}
		(T1, T2, T3, T4) tuple = ((T1, T2, T3, T4))other;
		return comparer.Equals(Item1, tuple.Item1) && comparer.Equals(Item2, tuple.Item2) && comparer.Equals(Item3, tuple.Item3) && comparer.Equals(Item4, tuple.Item4);
	}

	int IComparable.CompareTo(object other)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is ValueTuple<T1, T2, T3, T4>))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		return CompareTo(((T1, T2, T3, T4))other);
	}

	public int CompareTo((T1, T2, T3, T4) other)
	{
		int num = Comparer<T1>.Default.Compare(Item1, other.Item1);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T2>.Default.Compare(Item2, other.Item2);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T3>.Default.Compare(Item3, other.Item3);
		if (num != 0)
		{
			return num;
		}
		return Comparer<T4>.Default.Compare(Item4, other.Item4);
	}

	int IStructuralComparable.CompareTo(object other, IComparer comparer)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is (T1, T2, T3, T4) tuple))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		int num = comparer.Compare(Item1, tuple.Item1);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item2, tuple.Item2);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item3, tuple.Item3);
		if (num != 0)
		{
			return num;
		}
		return comparer.Compare(Item4, tuple.Item4);
	}

	public override int GetHashCode()
	{
		return ValueTuple.CombineHashCodes(EqualityComparer<T1>.Default.GetHashCode(Item1), EqualityComparer<T2>.Default.GetHashCode(Item2), EqualityComparer<T3>.Default.GetHashCode(Item3), EqualityComparer<T4>.Default.GetHashCode(Item4));
	}

	int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
	{
		return GetHashCodeCore(comparer);
	}

	private int GetHashCodeCore(IEqualityComparer comparer)
	{
		return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4));
	}

	int ITupleInternal.GetHashCode(IEqualityComparer comparer)
	{
		return GetHashCodeCore(comparer);
	}

	public override string ToString()
	{
		return "(" + Item1?.ToString() + ", " + Item2?.ToString() + ", " + Item3?.ToString() + ", " + Item4?.ToString() + ")";
	}

	string ITupleInternal.ToStringEnd()
	{
		return Item1?.ToString() + ", " + Item2?.ToString() + ", " + Item3?.ToString() + ", " + Item4?.ToString() + ")";
	}
}
public struct ValueTuple<T1, T2, T3, T4, T5> : IEquatable<(T1, T2, T3, T4, T5)>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<(T1, T2, T3, T4, T5)>, ITupleInternal
{
	public T1 Item1;

	public T2 Item2;

	public T3 Item3;

	public T4 Item4;

	public T5 Item5;

	int ITupleInternal.Size => 5;

	public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
	{
		Item1 = item1;
		Item2 = item2;
		Item3 = item3;
		Item4 = item4;
		Item5 = item5;
	}

	public override bool Equals(object obj)
	{
		return obj is ValueTuple<T1, T2, T3, T4, T5> && Equals(((T1, T2, T3, T4, T5))obj);
	}

	public bool Equals((T1, T2, T3, T4, T5) other)
	{
		return EqualityComparer<T1>.Default.Equals(Item1, other.Item1) && EqualityComparer<T2>.Default.Equals(Item2, other.Item2) && EqualityComparer<T3>.Default.Equals(Item3, other.Item3) && EqualityComparer<T4>.Default.Equals(Item4, other.Item4) && EqualityComparer<T5>.Default.Equals(Item5, other.Item5);
	}

	bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
	{
		if (other == null || !(other is ValueTuple<T1, T2, T3, T4, T5>))
		{
			return false;
		}
		(T1, T2, T3, T4, T5) tuple = ((T1, T2, T3, T4, T5))other;
		return comparer.Equals(Item1, tuple.Item1) && comparer.Equals(Item2, tuple.Item2) && comparer.Equals(Item3, tuple.Item3) && comparer.Equals(Item4, tuple.Item4) && comparer.Equals(Item5, tuple.Item5);
	}

	int IComparable.CompareTo(object other)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is ValueTuple<T1, T2, T3, T4, T5>))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		return CompareTo(((T1, T2, T3, T4, T5))other);
	}

	public int CompareTo((T1, T2, T3, T4, T5) other)
	{
		int num = Comparer<T1>.Default.Compare(Item1, other.Item1);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T2>.Default.Compare(Item2, other.Item2);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T3>.Default.Compare(Item3, other.Item3);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T4>.Default.Compare(Item4, other.Item4);
		if (num != 0)
		{
			return num;
		}
		return Comparer<T5>.Default.Compare(Item5, other.Item5);
	}

	int IStructuralComparable.CompareTo(object other, IComparer comparer)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is (T1, T2, T3, T4, T5) tuple))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		int num = comparer.Compare(Item1, tuple.Item1);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item2, tuple.Item2);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item3, tuple.Item3);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item4, tuple.Item4);
		if (num != 0)
		{
			return num;
		}
		return comparer.Compare(Item5, tuple.Item5);
	}

	public override int GetHashCode()
	{
		return ValueTuple.CombineHashCodes(EqualityComparer<T1>.Default.GetHashCode(Item1), EqualityComparer<T2>.Default.GetHashCode(Item2), EqualityComparer<T3>.Default.GetHashCode(Item3), EqualityComparer<T4>.Default.GetHashCode(Item4), EqualityComparer<T5>.Default.GetHashCode(Item5));
	}

	int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
	{
		return GetHashCodeCore(comparer);
	}

	private int GetHashCodeCore(IEqualityComparer comparer)
	{
		return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5));
	}

	int ITupleInternal.GetHashCode(IEqualityComparer comparer)
	{
		return GetHashCodeCore(comparer);
	}

	public override string ToString()
	{
		return "(" + Item1?.ToString() + ", " + Item2?.ToString() + ", " + Item3?.ToString() + ", " + Item4?.ToString() + ", " + Item5?.ToString() + ")";
	}

	string ITupleInternal.ToStringEnd()
	{
		return Item1?.ToString() + ", " + Item2?.ToString() + ", " + Item3?.ToString() + ", " + Item4?.ToString() + ", " + Item5?.ToString() + ")";
	}
}
public struct ValueTuple<T1, T2, T3, T4, T5, T6> : IEquatable<(T1, T2, T3, T4, T5, T6)>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<(T1, T2, T3, T4, T5, T6)>, ITupleInternal
{
	public T1 Item1;

	public T2 Item2;

	public T3 Item3;

	public T4 Item4;

	public T5 Item5;

	public T6 Item6;

	int ITupleInternal.Size => 6;

	public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
	{
		Item1 = item1;
		Item2 = item2;
		Item3 = item3;
		Item4 = item4;
		Item5 = item5;
		Item6 = item6;
	}

	public override bool Equals(object obj)
	{
		return obj is ValueTuple<T1, T2, T3, T4, T5, T6> && Equals(((T1, T2, T3, T4, T5, T6))obj);
	}

	public bool Equals((T1, T2, T3, T4, T5, T6) other)
	{
		return EqualityComparer<T1>.Default.Equals(Item1, other.Item1) && EqualityComparer<T2>.Default.Equals(Item2, other.Item2) && EqualityComparer<T3>.Default.Equals(Item3, other.Item3) && EqualityComparer<T4>.Default.Equals(Item4, other.Item4) && EqualityComparer<T5>.Default.Equals(Item5, other.Item5) && EqualityComparer<T6>.Default.Equals(Item6, other.Item6);
	}

	bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
	{
		if (other == null || !(other is ValueTuple<T1, T2, T3, T4, T5, T6>))
		{
			return false;
		}
		(T1, T2, T3, T4, T5, T6) tuple = ((T1, T2, T3, T4, T5, T6))other;
		return comparer.Equals(Item1, tuple.Item1) && comparer.Equals(Item2, tuple.Item2) && comparer.Equals(Item3, tuple.Item3) && comparer.Equals(Item4, tuple.Item4) && comparer.Equals(Item5, tuple.Item5) && comparer.Equals(Item6, tuple.Item6);
	}

	int IComparable.CompareTo(object other)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is ValueTuple<T1, T2, T3, T4, T5, T6>))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		return CompareTo(((T1, T2, T3, T4, T5, T6))other);
	}

	public int CompareTo((T1, T2, T3, T4, T5, T6) other)
	{
		int num = Comparer<T1>.Default.Compare(Item1, other.Item1);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T2>.Default.Compare(Item2, other.Item2);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T3>.Default.Compare(Item3, other.Item3);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T4>.Default.Compare(Item4, other.Item4);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T5>.Default.Compare(Item5, other.Item5);
		if (num != 0)
		{
			return num;
		}
		return Comparer<T6>.Default.Compare(Item6, other.Item6);
	}

	int IStructuralComparable.CompareTo(object other, IComparer comparer)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is (T1, T2, T3, T4, T5, T6) tuple))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		int num = comparer.Compare(Item1, tuple.Item1);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item2, tuple.Item2);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item3, tuple.Item3);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item4, tuple.Item4);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item5, tuple.Item5);
		if (num != 0)
		{
			return num;
		}
		return comparer.Compare(Item6, tuple.Item6);
	}

	public override int GetHashCode()
	{
		return ValueTuple.CombineHashCodes(EqualityComparer<T1>.Default.GetHashCode(Item1), EqualityComparer<T2>.Default.GetHashCode(Item2), EqualityComparer<T3>.Default.GetHashCode(Item3), EqualityComparer<T4>.Default.GetHashCode(Item4), EqualityComparer<T5>.Default.GetHashCode(Item5), EqualityComparer<T6>.Default.GetHashCode(Item6));
	}

	int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
	{
		return GetHashCodeCore(comparer);
	}

	private int GetHashCodeCore(IEqualityComparer comparer)
	{
		return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6));
	}

	int ITupleInternal.GetHashCode(IEqualityComparer comparer)
	{
		return GetHashCodeCore(comparer);
	}

	public override string ToString()
	{
		return "(" + Item1?.ToString() + ", " + Item2?.ToString() + ", " + Item3?.ToString() + ", " + Item4?.ToString() + ", " + Item5?.ToString() + ", " + Item6?.ToString() + ")";
	}

	string ITupleInternal.ToStringEnd()
	{
		return Item1?.ToString() + ", " + Item2?.ToString() + ", " + Item3?.ToString() + ", " + Item4?.ToString() + ", " + Item5?.ToString() + ", " + Item6?.ToString() + ")";
	}
}
public struct ValueTuple<T1, T2, T3, T4, T5, T6, T7> : IEquatable<(T1, T2, T3, T4, T5, T6, T7)>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<(T1, T2, T3, T4, T5, T6, T7)>, ITupleInternal
{
	public T1 Item1;

	public T2 Item2;

	public T3 Item3;

	public T4 Item4;

	public T5 Item5;

	public T6 Item6;

	public T7 Item7;

	int ITupleInternal.Size => 7;

	public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
	{
		Item1 = item1;
		Item2 = item2;
		Item3 = item3;
		Item4 = item4;
		Item5 = item5;
		Item6 = item6;
		Item7 = item7;
	}

	public override bool Equals(object obj)
	{
		return obj is ValueTuple<T1, T2, T3, T4, T5, T6, T7> && Equals(((T1, T2, T3, T4, T5, T6, T7))obj);
	}

	public bool Equals((T1, T2, T3, T4, T5, T6, T7) other)
	{
		return EqualityComparer<T1>.Default.Equals(Item1, other.Item1) && EqualityComparer<T2>.Default.Equals(Item2, other.Item2) && EqualityComparer<T3>.Default.Equals(Item3, other.Item3) && EqualityComparer<T4>.Default.Equals(Item4, other.Item4) && EqualityComparer<T5>.Default.Equals(Item5, other.Item5) && EqualityComparer<T6>.Default.Equals(Item6, other.Item6) && EqualityComparer<T7>.Default.Equals(Item7, other.Item7);
	}

	bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
	{
		if (other == null || !(other is ValueTuple<T1, T2, T3, T4, T5, T6, T7>))
		{
			return false;
		}
		(T1, T2, T3, T4, T5, T6, T7) tuple = ((T1, T2, T3, T4, T5, T6, T7))other;
		return comparer.Equals(Item1, tuple.Item1) && comparer.Equals(Item2, tuple.Item2) && comparer.Equals(Item3, tuple.Item3) && comparer.Equals(Item4, tuple.Item4) && comparer.Equals(Item5, tuple.Item5) && comparer.Equals(Item6, tuple.Item6) && comparer.Equals(Item7, tuple.Item7);
	}

	int IComparable.CompareTo(object other)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is ValueTuple<T1, T2, T3, T4, T5, T6, T7>))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		return CompareTo(((T1, T2, T3, T4, T5, T6, T7))other);
	}

	public int CompareTo((T1, T2, T3, T4, T5, T6, T7) other)
	{
		int num = Comparer<T1>.Default.Compare(Item1, other.Item1);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T2>.Default.Compare(Item2, other.Item2);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T3>.Default.Compare(Item3, other.Item3);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T4>.Default.Compare(Item4, other.Item4);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T5>.Default.Compare(Item5, other.Item5);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T6>.Default.Compare(Item6, other.Item6);
		if (num != 0)
		{
			return num;
		}
		return Comparer<T7>.Default.Compare(Item7, other.Item7);
	}

	int IStructuralComparable.CompareTo(object other, IComparer comparer)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is (T1, T2, T3, T4, T5, T6, T7) tuple))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		int num = comparer.Compare(Item1, tuple.Item1);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item2, tuple.Item2);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item3, tuple.Item3);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item4, tuple.Item4);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item5, tuple.Item5);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item6, tuple.Item6);
		if (num != 0)
		{
			return num;
		}
		return comparer.Compare(Item7, tuple.Item7);
	}

	public override int GetHashCode()
	{
		return ValueTuple.CombineHashCodes(EqualityComparer<T1>.Default.GetHashCode(Item1), EqualityComparer<T2>.Default.GetHashCode(Item2), EqualityComparer<T3>.Default.GetHashCode(Item3), EqualityComparer<T4>.Default.GetHashCode(Item4), EqualityComparer<T5>.Default.GetHashCode(Item5), EqualityComparer<T6>.Default.GetHashCode(Item6), EqualityComparer<T7>.Default.GetHashCode(Item7));
	}

	int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
	{
		return GetHashCodeCore(comparer);
	}

	private int GetHashCodeCore(IEqualityComparer comparer)
	{
		return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7));
	}

	int ITupleInternal.GetHashCode(IEqualityComparer comparer)
	{
		return GetHashCodeCore(comparer);
	}

	public override string ToString()
	{
		return "(" + Item1?.ToString() + ", " + Item2?.ToString() + ", " + Item3?.ToString() + ", " + Item4?.ToString() + ", " + Item5?.ToString() + ", " + Item6?.ToString() + ", " + Item7?.ToString() + ")";
	}

	string ITupleInternal.ToStringEnd()
	{
		return Item1?.ToString() + ", " + Item2?.ToString() + ", " + Item3?.ToString() + ", " + Item4?.ToString() + ", " + Item5?.ToString() + ", " + Item6?.ToString() + ", " + Item7?.ToString() + ")";
	}
}
public struct ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IEquatable<ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>>, ITupleInternal where TRest : struct
{
	public T1 Item1;

	public T2 Item2;

	public T3 Item3;

	public T4 Item4;

	public T5 Item5;

	public T6 Item6;

	public T7 Item7;

	public TRest Rest;

	int ITupleInternal.Size => (!((object)Rest is ITupleInternal tupleInternal)) ? 8 : (7 + tupleInternal.Size);

	public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest)
	{
		if (!(rest is ITupleInternal))
		{
			throw new ArgumentException("The TRest type argument of ValueTuple`8 must be a ValueTuple.");
		}
		Item1 = item1;
		Item2 = item2;
		Item3 = item3;
		Item4 = item4;
		Item5 = item5;
		Item6 = item6;
		Item7 = item7;
		Rest = rest;
	}

	public override bool Equals(object obj)
	{
		return obj is ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> && Equals((ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>)obj);
	}

	public bool Equals(ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> other)
	{
		return EqualityComparer<T1>.Default.Equals(Item1, other.Item1) && EqualityComparer<T2>.Default.Equals(Item2, other.Item2) && EqualityComparer<T3>.Default.Equals(Item3, other.Item3) && EqualityComparer<T4>.Default.Equals(Item4, other.Item4) && EqualityComparer<T5>.Default.Equals(Item5, other.Item5) && EqualityComparer<T6>.Default.Equals(Item6, other.Item6) && EqualityComparer<T7>.Default.Equals(Item7, other.Item7) && EqualityComparer<TRest>.Default.Equals(Rest, other.Rest);
	}

	bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
	{
		if (other == null || !(other is ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>))
		{
			return false;
		}
		ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> valueTuple = (ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>)other;
		return comparer.Equals(Item1, valueTuple.Item1) && comparer.Equals(Item2, valueTuple.Item2) && comparer.Equals(Item3, valueTuple.Item3) && comparer.Equals(Item4, valueTuple.Item4) && comparer.Equals(Item5, valueTuple.Item5) && comparer.Equals(Item6, valueTuple.Item6) && comparer.Equals(Item7, valueTuple.Item7) && comparer.Equals(Rest, valueTuple.Rest);
	}

	int IComparable.CompareTo(object other)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		return CompareTo((ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>)other);
	}

	public int CompareTo(ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> other)
	{
		int num = Comparer<T1>.Default.Compare(Item1, other.Item1);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T2>.Default.Compare(Item2, other.Item2);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T3>.Default.Compare(Item3, other.Item3);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T4>.Default.Compare(Item4, other.Item4);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T5>.Default.Compare(Item5, other.Item5);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T6>.Default.Compare(Item6, other.Item6);
		if (num != 0)
		{
			return num;
		}
		num = Comparer<T7>.Default.Compare(Item7, other.Item7);
		if (num != 0)
		{
			return num;
		}
		return Comparer<TRest>.Default.Compare(Rest, other.Rest);
	}

	int IStructuralComparable.CompareTo(object other, IComparer comparer)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> valueTuple))
		{
			throw new ArgumentException("The parameter should be a ValueTuple type of appropriate arity.", "other");
		}
		int num = comparer.Compare(Item1, valueTuple.Item1);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item2, valueTuple.Item2);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item3, valueTuple.Item3);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item4, valueTuple.Item4);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item5, valueTuple.Item5);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item6, valueTuple.Item6);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(Item7, valueTuple.Item7);
		if (num != 0)
		{
			return num;
		}
		return comparer.Compare(Rest, valueTuple.Rest);
	}

	public override int GetHashCode()
	{
		if (!((object)Rest is ITupleInternal { Size: var size } tupleInternal))
		{
			return ValueTuple.CombineHashCodes(EqualityComparer<T1>.Default.GetHashCode(Item1), EqualityComparer<T2>.Default.GetHashCode(Item2), EqualityComparer<T3>.Default.GetHashCode(Item3), EqualityComparer<T4>.Default.GetHashCode(Item4), EqualityComparer<T5>.Default.GetHashCode(Item5), EqualityComparer<T6>.Default.GetHashCode(Item6), EqualityComparer<T7>.Default.GetHashCode(Item7));
		}
		if (size >= 8)
		{
			return tupleInternal.GetHashCode();
		}
		switch (8 - size)
		{
		case 1:
			return ValueTuple.CombineHashCodes(EqualityComparer<T7>.Default.GetHashCode(Item7), tupleInternal.GetHashCode());
		case 2:
			return ValueTuple.CombineHashCodes(EqualityComparer<T6>.Default.GetHashCode(Item6), EqualityComparer<T7>.Default.GetHashCode(Item7), tupleInternal.GetHashCode());
		case 3:
			return ValueTuple.CombineHashCodes(EqualityComparer<T5>.Default.GetHashCode(Item5), EqualityComparer<T6>.Default.GetHashCode(Item6), EqualityComparer<T7>.Default.GetHashCode(Item7), tupleInternal.GetHashCode());
		case 4:
			return ValueTuple.CombineHashCodes(EqualityComparer<T4>.Default.GetHashCode(Item4), EqualityComparer<T5>.Default.GetHashCode(Item5), EqualityComparer<T6>.Default.GetHashCode(Item6), EqualityComparer<T7>.Default.GetHashCode(Item7), tupleInternal.GetHashCode());
		case 5:
			return ValueTuple.CombineHashCodes(EqualityComparer<T3>.Default.GetHashCode(Item3), EqualityComparer<T4>.Default.GetHashCode(Item4), EqualityComparer<T5>.Default.GetHashCode(Item5), EqualityComparer<T6>.Default.GetHashCode(Item6), EqualityComparer<T7>.Default.GetHashCode(Item7), tupleInternal.GetHashCode());
		case 6:
			return ValueTuple.CombineHashCodes(EqualityComparer<T2>.Default.GetHashCode(Item2), EqualityComparer<T3>.Default.GetHashCode(Item3), EqualityComparer<T4>.Default.GetHashCode(Item4), EqualityComparer<T5>.Default.GetHashCode(Item5), EqualityComparer<T6>.Default.GetHashCode(Item6), EqualityComparer<T7>.Default.GetHashCode(Item7), tupleInternal.GetHashCode());
		case 7:
		case 8:
			return ValueTuple.CombineHashCodes(EqualityComparer<T1>.Default.GetHashCode(Item1), EqualityComparer<T2>.Default.GetHashCode(Item2), EqualityComparer<T3>.Default.GetHashCode(Item3), EqualityComparer<T4>.Default.GetHashCode(Item4), EqualityComparer<T5>.Default.GetHashCode(Item5), EqualityComparer<T6>.Default.GetHashCode(Item6), EqualityComparer<T7>.Default.GetHashCode(Item7), tupleInternal.GetHashCode());
		default:
			Debug.Assert(condition: false, "Missed all cases for computing ValueTuple hash code");
			return -1;
		}
	}

	int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
	{
		return GetHashCodeCore(comparer);
	}

	private int GetHashCodeCore(IEqualityComparer comparer)
	{
		if (!((object)Rest is ITupleInternal { Size: var size } tupleInternal))
		{
			return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7));
		}
		if (size >= 8)
		{
			return tupleInternal.GetHashCode(comparer);
		}
		switch (8 - size)
		{
		case 1:
			return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item7), tupleInternal.GetHashCode(comparer));
		case 2:
			return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), tupleInternal.GetHashCode(comparer));
		case 3:
			return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), tupleInternal.GetHashCode(comparer));
		case 4:
			return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), tupleInternal.GetHashCode(comparer));
		case 5:
			return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), tupleInternal.GetHashCode(comparer));
		case 6:
			return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), tupleInternal.GetHashCode(comparer));
		case 7:
		case 8:
			return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), tupleInternal.GetHashCode(comparer));
		default:
			Debug.Assert(condition: false, "Missed all cases for computing ValueTuple hash code");
			return -1;
		}
	}

	int ITupleInternal.GetHashCode(IEqualityComparer comparer)
	{
		return GetHashCodeCore(comparer);
	}

	public override string ToString()
	{
		string[] obj;
		T1 val;
		object obj2;
		if (!((object)Rest is ITupleInternal tupleInternal))
		{
			obj = new string[17]
			{
				"(", null, null, null, null, null, null, null, null, null,
				null, null, null, null, null, null, null
			};
			ref T1 reference = ref Item1;
			val = default(T1);
			if (val == null)
			{
				val = reference;
				reference = ref val;
				if (val == null)
				{
					obj2 = null;
					goto IL_0064;
				}
			}
			obj2 = reference.ToString();
			goto IL_0064;
		}
		string[] obj3 = new string[16]
		{
			"(", null, null, null, null, null, null, null, null, null,
			null, null, null, null, null, null
		};
		ref T1 reference2 = ref Item1;
		val = default(T1);
		object obj4;
		if (val == null)
		{
			val = reference2;
			reference2 = ref val;
			if (val == null)
			{
				obj4 = null;
				goto IL_0273;
			}
		}
		obj4 = reference2.ToString();
		goto IL_0273;
		IL_016e:
		object obj5;
		obj[9] = (string)obj5;
		obj[10] = ", ";
		ref T6 reference3 = ref Item6;
		T6 val2 = default(T6);
		object obj6;
		if (val2 == null)
		{
			val2 = reference3;
			reference3 = ref val2;
			if (val2 == null)
			{
				obj6 = null;
				goto IL_01b3;
			}
		}
		obj6 = reference3.ToString();
		goto IL_01b3;
		IL_0339:
		object obj7;
		obj3[7] = (string)obj7;
		obj3[8] = ", ";
		ref T5 reference4 = ref Item5;
		T5 val3 = default(T5);
		object obj8;
		if (val3 == null)
		{
			val3 = reference4;
			reference4 = ref val3;
			if (val3 == null)
			{
				obj8 = null;
				goto IL_037d;
			}
		}
		obj8 = reference4.ToString();
		goto IL_037d;
		IL_00a4:
		object obj9;
		obj[3] = (string)obj9;
		obj[4] = ", ";
		ref T3 reference5 = ref Item3;
		T3 val4 = default(T3);
		object obj10;
		if (val4 == null)
		{
			val4 = reference5;
			reference5 = ref val4;
			if (val4 == null)
			{
				obj10 = null;
				goto IL_00e7;
			}
		}
		obj10 = reference5.ToString();
		goto IL_00e7;
		IL_0064:
		obj[1] = (string)obj2;
		obj[2] = ", ";
		ref T2 reference6 = ref Item2;
		T2 val5 = default(T2);
		if (val5 == null)
		{
			val5 = reference6;
			reference6 = ref val5;
			if (val5 == null)
			{
				obj9 = null;
				goto IL_00a4;
			}
		}
		obj9 = reference6.ToString();
		goto IL_00a4;
		IL_0273:
		obj3[1] = (string)obj4;
		obj3[2] = ", ";
		ref T2 reference7 = ref Item2;
		val5 = default(T2);
		object obj11;
		if (val5 == null)
		{
			val5 = reference7;
			reference7 = ref val5;
			if (val5 == null)
			{
				obj11 = null;
				goto IL_02b3;
			}
		}
		obj11 = reference7.ToString();
		goto IL_02b3;
		IL_00e7:
		obj[5] = (string)obj10;
		obj[6] = ", ";
		ref T4 reference8 = ref Item4;
		T4 val6 = default(T4);
		object obj12;
		if (val6 == null)
		{
			val6 = reference8;
			reference8 = ref val6;
			if (val6 == null)
			{
				obj12 = null;
				goto IL_012a;
			}
		}
		obj12 = reference8.ToString();
		goto IL_012a;
		IL_03c2:
		object obj13;
		obj3[11] = (string)obj13;
		obj3[12] = ", ";
		ref T7 reference9 = ref Item7;
		T7 val7 = default(T7);
		object obj14;
		if (val7 == null)
		{
			val7 = reference9;
			reference9 = ref val7;
			if (val7 == null)
			{
				obj14 = null;
				goto IL_0407;
			}
		}
		obj14 = reference9.ToString();
		goto IL_0407;
		IL_037d:
		obj3[9] = (string)obj8;
		obj3[10] = ", ";
		ref T6 reference10 = ref Item6;
		val2 = default(T6);
		if (val2 == null)
		{
			val2 = reference10;
			reference10 = ref val2;
			if (val2 == null)
			{
				obj13 = null;
				goto IL_03c2;
			}
		}
		obj13 = reference10.ToString();
		goto IL_03c2;
		IL_02b3:
		obj3[3] = (string)obj11;
		obj3[4] = ", ";
		ref T3 reference11 = ref Item3;
		val4 = default(T3);
		object obj15;
		if (val4 == null)
		{
			val4 = reference11;
			reference11 = ref val4;
			if (val4 == null)
			{
				obj15 = null;
				goto IL_02f6;
			}
		}
		obj15 = reference11.ToString();
		goto IL_02f6;
		IL_01f8:
		object obj16;
		obj[13] = (string)obj16;
		obj[14] = ", ";
		obj[15] = Rest.ToString();
		obj[16] = ")";
		return string.Concat(obj);
		IL_01b3:
		obj[11] = (string)obj6;
		obj[12] = ", ";
		ref T7 reference12 = ref Item7;
		val7 = default(T7);
		if (val7 == null)
		{
			val7 = reference12;
			reference12 = ref val7;
			if (val7 == null)
			{
				obj16 = null;
				goto IL_01f8;
			}
		}
		obj16 = reference12.ToString();
		goto IL_01f8;
		IL_012a:
		obj[7] = (string)obj12;
		obj[8] = ", ";
		ref T5 reference13 = ref Item5;
		val3 = default(T5);
		if (val3 == null)
		{
			val3 = reference13;
			reference13 = ref val3;
			if (val3 == null)
			{
				obj5 = null;
				goto IL_016e;
			}
		}
		obj5 = reference13.ToString();
		goto IL_016e;
		IL_02f6:
		obj3[5] = (string)obj15;
		obj3[6] = ", ";
		ref T4 reference14 = ref Item4;
		val6 = default(T4);
		if (val6 == null)
		{
			val6 = reference14;
			reference14 = ref val6;
			if (val6 == null)
			{
				obj7 = null;
				goto IL_0339;
			}
		}
		obj7 = reference14.ToString();
		goto IL_0339;
		IL_0407:
		obj3[13] = (string)obj14;
		obj3[14] = ", ";
		obj3[15] = tupleInternal.ToStringEnd();
		return string.Concat(obj3);
	}

	string ITupleInternal.ToStringEnd()
	{
		string[] array;
		T1 val;
		object obj;
		if (!((object)Rest is ITupleInternal tupleInternal))
		{
			array = new string[16];
			ref T1 reference = ref Item1;
			val = default(T1);
			if (val == null)
			{
				val = reference;
				reference = ref val;
				if (val == null)
				{
					obj = null;
					goto IL_005c;
				}
			}
			obj = reference.ToString();
			goto IL_005c;
		}
		string[] array2 = new string[15];
		ref T1 reference2 = ref Item1;
		val = default(T1);
		object obj2;
		if (val == null)
		{
			val = reference2;
			reference2 = ref val;
			if (val == null)
			{
				obj2 = null;
				goto IL_0262;
			}
		}
		obj2 = reference2.ToString();
		goto IL_0262;
		IL_0165:
		object obj3;
		array[8] = (string)obj3;
		array[9] = ", ";
		ref T6 reference3 = ref Item6;
		T6 val2 = default(T6);
		object obj4;
		if (val2 == null)
		{
			val2 = reference3;
			reference3 = ref val2;
			if (val2 == null)
			{
				obj4 = null;
				goto IL_01aa;
			}
		}
		obj4 = reference3.ToString();
		goto IL_01aa;
		IL_0328:
		object obj5;
		array2[6] = (string)obj5;
		array2[7] = ", ";
		ref T5 reference4 = ref Item5;
		T5 val3 = default(T5);
		object obj6;
		if (val3 == null)
		{
			val3 = reference4;
			reference4 = ref val3;
			if (val3 == null)
			{
				obj6 = null;
				goto IL_036b;
			}
		}
		obj6 = reference4.ToString();
		goto IL_036b;
		IL_009c:
		object obj7;
		array[2] = (string)obj7;
		array[3] = ", ";
		ref T3 reference5 = ref Item3;
		T3 val4 = default(T3);
		object obj8;
		if (val4 == null)
		{
			val4 = reference5;
			reference5 = ref val4;
			if (val4 == null)
			{
				obj8 = null;
				goto IL_00df;
			}
		}
		obj8 = reference5.ToString();
		goto IL_00df;
		IL_005c:
		array[0] = (string)obj;
		array[1] = ", ";
		ref T2 reference6 = ref Item2;
		T2 val5 = default(T2);
		if (val5 == null)
		{
			val5 = reference6;
			reference6 = ref val5;
			if (val5 == null)
			{
				obj7 = null;
				goto IL_009c;
			}
		}
		obj7 = reference6.ToString();
		goto IL_009c;
		IL_0262:
		array2[0] = (string)obj2;
		array2[1] = ", ";
		ref T2 reference7 = ref Item2;
		val5 = default(T2);
		object obj9;
		if (val5 == null)
		{
			val5 = reference7;
			reference7 = ref val5;
			if (val5 == null)
			{
				obj9 = null;
				goto IL_02a2;
			}
		}
		obj9 = reference7.ToString();
		goto IL_02a2;
		IL_00df:
		array[4] = (string)obj8;
		array[5] = ", ";
		ref T4 reference8 = ref Item4;
		T4 val6 = default(T4);
		object obj10;
		if (val6 == null)
		{
			val6 = reference8;
			reference8 = ref val6;
			if (val6 == null)
			{
				obj10 = null;
				goto IL_0122;
			}
		}
		obj10 = reference8.ToString();
		goto IL_0122;
		IL_03b0:
		object obj11;
		array2[10] = (string)obj11;
		array2[11] = ", ";
		ref T7 reference9 = ref Item7;
		T7 val7 = default(T7);
		object obj12;
		if (val7 == null)
		{
			val7 = reference9;
			reference9 = ref val7;
			if (val7 == null)
			{
				obj12 = null;
				goto IL_03f5;
			}
		}
		obj12 = reference9.ToString();
		goto IL_03f5;
		IL_036b:
		array2[8] = (string)obj6;
		array2[9] = ", ";
		ref T6 reference10 = ref Item6;
		val2 = default(T6);
		if (val2 == null)
		{
			val2 = reference10;
			reference10 = ref val2;
			if (val2 == null)
			{
				obj11 = null;
				goto IL_03b0;
			}
		}
		obj11 = reference10.ToString();
		goto IL_03b0;
		IL_02a2:
		array2[2] = (string)obj9;
		array2[3] = ", ";
		ref T3 reference11 = ref Item3;
		val4 = default(T3);
		object obj13;
		if (val4 == null)
		{
			val4 = reference11;
			reference11 = ref val4;
			if (val4 == null)
			{
				obj13 = null;
				goto IL_02e5;
			}
		}
		obj13 = reference11.ToString();
		goto IL_02e5;
		IL_01ef:
		object obj14;
		array[12] = (string)obj14;
		array[13] = ", ";
		array[14] = Rest.ToString();
		array[15] = ")";
		return string.Concat(array);
		IL_01aa:
		array[10] = (string)obj4;
		array[11] = ", ";
		ref T7 reference12 = ref Item7;
		val7 = default(T7);
		if (val7 == null)
		{
			val7 = reference12;
			reference12 = ref val7;
			if (val7 == null)
			{
				obj14 = null;
				goto IL_01ef;
			}
		}
		obj14 = reference12.ToString();
		goto IL_01ef;
		IL_0122:
		array[6] = (string)obj10;
		array[7] = ", ";
		ref T5 reference13 = ref Item5;
		val3 = default(T5);
		if (val3 == null)
		{
			val3 = reference13;
			reference13 = ref val3;
			if (val3 == null)
			{
				obj3 = null;
				goto IL_0165;
			}
		}
		obj3 = reference13.ToString();
		goto IL_0165;
		IL_02e5:
		array2[4] = (string)obj13;
		array2[5] = ", ";
		ref T4 reference14 = ref Item4;
		val6 = default(T4);
		if (val6 == null)
		{
			val6 = reference14;
			reference14 = ref val6;
			if (val6 == null)
			{
				obj5 = null;
				goto IL_0328;
			}
		}
		obj5 = reference14.ToString();
		goto IL_0328;
		IL_03f5:
		array2[12] = (string)obj12;
		array2[13] = ", ";
		array2[14] = tupleInternal.ToStringEnd();
		return string.Concat(array2);
	}
}
