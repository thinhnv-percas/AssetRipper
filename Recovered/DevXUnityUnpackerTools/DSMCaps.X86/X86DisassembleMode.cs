using System;

namespace DSMCaps.X86
{
	[Flags]
	public enum X86DisassembleMode
	{
		Bit16 = 0x2,
		Bit32 = 0x4,
		Bit64 = 0x8,
		LittleEndian = 0x0
	}
}
