using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public sealed class MethodDefComparer : IComparer<MethodDef>
{
	public static readonly MethodDefComparer Instance = new MethodDefComparer();

	public int Compare(MethodDef x, MethodDef y)
	{
		int num = StringComparer.OrdinalIgnoreCase.Compare(x.Name, y.Name);
		if (num != 0)
		{
			return num;
		}
		num = x.MethodSig.GetParamCount().CompareTo(y.MethodSig.GetParamCount());
		if (num != 0)
		{
			return num;
		}
		num = x.MethodSig.GetGenParamCount().CompareTo(y.MethodSig.GetGenParamCount());
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
