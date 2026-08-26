using System;

namespace SpirV
{
	[Flags]
	public enum KernelProfilingInfo : uint
	{
		None = 0x0,
		CmdExecTime = 0x1
	}
}
