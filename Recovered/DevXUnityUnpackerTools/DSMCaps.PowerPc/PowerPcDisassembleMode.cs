using System;

namespace DSMCaps.PowerPc
{
	[Flags]
	public enum PowerPcDisassembleMode
	{
		BigEndian = int.MinValue,
		Bit32 = 0x4,
		Bit64 = 0x8,
		LittleEndian = 0x0,
		QuadProcessingExtensions = 0x10
	}
}
