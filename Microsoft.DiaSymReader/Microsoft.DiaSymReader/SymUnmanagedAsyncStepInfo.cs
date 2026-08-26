using System;

namespace Microsoft.DiaSymReader;

public struct SymUnmanagedAsyncStepInfo : IEquatable<SymUnmanagedAsyncStepInfo>
{
	public int YieldOffset { get; }

	public int ResumeOffset { get; }

	public int ResumeMethod { get; }

	public SymUnmanagedAsyncStepInfo(int yieldOffset, int resumeOffset, int resumeMethod)
	{
		YieldOffset = yieldOffset;
		ResumeOffset = resumeOffset;
		ResumeMethod = resumeMethod;
	}

	public override bool Equals(object obj)
	{
		if (obj is SymUnmanagedAsyncStepInfo)
		{
			return Equals((SymUnmanagedAsyncStepInfo)obj);
		}
		return false;
	}

	public bool Equals(SymUnmanagedAsyncStepInfo other)
	{
		if (YieldOffset == other.YieldOffset && ResumeMethod == other.ResumeMethod)
		{
			return ResumeOffset == other.ResumeOffset;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return YieldOffset ^ ResumeMethod ^ ResumeOffset;
	}
}
