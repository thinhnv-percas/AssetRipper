using System;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public readonly struct AsyncStepInfo
{
	public uint YieldOffset { get; }

	public MethodDef ResumeMethod { get; }

	public uint ResumeOffset { get; }

	public AsyncStepInfo(uint yieldOffset, MethodDef resumeMethod, uint resumeOffset)
	{
		YieldOffset = yieldOffset;
		ResumeMethod = resumeMethod ?? throw new ArgumentNullException("resumeMethod");
		ResumeOffset = resumeOffset;
	}
}
