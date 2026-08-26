using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public abstract class MemberRefComparer<T> : IComparer<T> where T : IMemberRef
{
	public int Compare(T x, T y)
	{
		int num = StringComparer.OrdinalIgnoreCase.Compare(x.Name, y.Name);
		if (num != 0)
		{
			return num;
		}
		num = x.MDToken.Raw.CompareTo(y.MDToken.Raw);
		if (num != 0)
		{
			return num;
		}
		return x.GetHashCode().CompareTo(y.GetHashCode());
	}
}
