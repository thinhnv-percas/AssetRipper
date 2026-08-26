using System;

namespace DSMCaps
{
	[Flags]
	internal enum NativeDisassembleMode
	{
		LittleEndian = 0x0,
		Arm = 0x0,
		Bit16 = 0x2,
		Bit32 = 0x4,
		Bit64 = 0x8,
		ArmThumb = 0x10,
		ArmCortexM = 0x20,
		ArmV8 = 0x40,
		MipsMicro = 0x10,
		Mips3 = 0x20,
		Mips32R6 = 0x40,
		Mips2 = 0x80,
		SparcV9 = 0x10,
		PowerPcQuadProcessingExtensions = 0x10,
		M68K000 = 0x2,
		M68K010 = 0x4,
		M68K020 = 0x8,
		M68K030 = 0x10,
		M68K040 = 0x20,
		M68K060 = 0x40,
		BigEndian = int.MinValue,
		Mips32 = 0x4,
		Mips64 = 0x8,
		M680X6301 = 0x2,
		M680X6309 = 0x4,
		M680X6800 = 0x8,
		M680X6801 = 0x10,
		M680X6805 = 0x20,
		M680X6808 = 0x40,
		M680X6809 = 0x80,
		M680X6811 = 0x100,
		M680XCpu12 = 0x200,
		M680XHcS08 = 0x400
	}
}
