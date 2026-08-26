using System;

namespace SpirV
{
	[Flags]
	public enum SelectionControl : uint
	{
		None = 0x0,
		Flatten = 0x1,
		DontFlatten = 0x2
	}
}
