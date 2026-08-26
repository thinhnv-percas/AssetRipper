using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DecompTools.Decompiler.Util;

public sealed class ReferenceComparer : IEqualityComparer<object>
{
	public static readonly ReferenceComparer Instance = new ReferenceComparer();

	public new bool Equals(object x, object y)
	{
		return x == y;
	}

	public int GetHashCode(object obj)
	{
		return RuntimeHelpers.GetHashCode(obj);
	}
}
