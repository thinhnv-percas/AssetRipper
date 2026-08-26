using System;

namespace DevX.Cecil
{
	[Flags]
	public enum PropertyAttributes : ushort
	{
		SpecialName = 0x200,
		RTSpecialName = 0x400,
		HasDefault = 0x1000,
		Unused = 0xE9FF
	}
}
