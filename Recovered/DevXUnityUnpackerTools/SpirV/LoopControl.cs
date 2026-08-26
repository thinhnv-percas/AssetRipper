using System;

namespace SpirV
{
	[Flags]
	public enum LoopControl : uint
	{
		None = 0x0,
		Unroll = 0x1,
		DontUnroll = 0x2,
		DependencyInfinite = 0x4,
		DependencyLength = 0x8
	}
}
