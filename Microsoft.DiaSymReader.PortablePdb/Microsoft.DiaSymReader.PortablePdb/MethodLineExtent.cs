using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.DiaSymReader.PortablePdb;

[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
internal struct MethodLineExtent
{
	internal sealed class MethodComparer : IComparer<MethodLineExtent>
	{
		public static readonly MethodComparer Instance = new MethodComparer();

		public int Compare(MethodLineExtent x, MethodLineExtent y)
		{
			return x.Method.CompareTo(y.Method);
		}
	}

	internal sealed class MinLineComparer : IComparer<MethodLineExtent>
	{
		public static readonly MinLineComparer Instance = new MinLineComparer();

		public int Compare(MethodLineExtent x, MethodLineExtent y)
		{
			return x.MinLine - y.MinLine;
		}
	}

	public readonly MethodId Method;

	public readonly int Version;

	public readonly int MinLine;

	public readonly int MaxLine;

	public MethodLineExtent(MethodId method, int version, int minLine, int maxLine)
	{
		Method = method;
		Version = version;
		MinLine = minLine;
		MaxLine = maxLine;
	}

	public static MethodLineExtent Merge(MethodLineExtent left, MethodLineExtent right)
	{
		return new MethodLineExtent(left.Method, left.Version, Math.Min(left.MinLine, right.MinLine), Math.Max(left.MaxLine, right.MaxLine));
	}

	public MethodLineExtent ApplyDelta(int delta)
	{
		return new MethodLineExtent(Method, Version, MinLine + delta, MaxLine + delta);
	}

	private string GetDebuggerDisplay()
	{
		return $"{Method.Value} v{Version} [{MinLine}-{MaxLine}]";
	}
}
