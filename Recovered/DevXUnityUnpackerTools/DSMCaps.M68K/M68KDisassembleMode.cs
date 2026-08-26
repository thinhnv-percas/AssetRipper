using System;

namespace DSMCaps.M68K
{
	[Flags]
	public enum M68KDisassembleMode
	{
		BigEndian = int.MinValue,
		M68K000 = 0x2,
		M68K010 = 0x4,
		M68K020 = 0x8,
		M68K030 = 0x10,
		M68K040 = 0x20,
		M68K060 = 0x40
	}
}
