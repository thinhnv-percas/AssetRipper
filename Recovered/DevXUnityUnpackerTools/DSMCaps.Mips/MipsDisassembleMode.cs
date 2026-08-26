using System;

namespace DSMCaps.Mips
{
	[Flags]
	public enum MipsDisassembleMode
	{
		BigEndian = int.MinValue,
		Bit32 = 0x4,
		Bit64 = 0x8,
		LittleEndian = 0x0,
		Micro = 0x10,
		Mips2 = 0x80,
		Mips3 = 0x20,
		Mips32R6 = 0x40
	}
}
