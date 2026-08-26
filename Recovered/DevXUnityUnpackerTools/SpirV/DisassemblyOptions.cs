using System;

namespace SpirV
{
	[Flags]
	public enum DisassemblyOptions
	{
		None = 0x0,
		ShowTypes = 0x1,
		ShowNames = 0x2,
		Default = 0x3
	}
}
