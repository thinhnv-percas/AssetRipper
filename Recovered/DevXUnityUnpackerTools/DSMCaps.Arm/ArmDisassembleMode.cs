using System;

namespace DSMCaps.Arm
{
	[Flags]
	public enum ArmDisassembleMode
	{
		Arm = 0x0,
		BigEndian = int.MinValue,
		LittleEndian = 0x0,
		CortexM = 0x20,
		Thumb = 0x10,
		V8 = 0x40
	}
}
