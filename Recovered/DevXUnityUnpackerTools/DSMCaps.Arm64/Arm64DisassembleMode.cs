using System;

namespace DSMCaps.Arm64
{
	[Flags]
	public enum Arm64DisassembleMode
	{
		Arm = 0x0,
		BigEndian = int.MinValue,
		LittleEndian = 0x0
	}
}
