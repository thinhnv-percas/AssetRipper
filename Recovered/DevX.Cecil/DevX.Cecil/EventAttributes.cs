using System;

namespace DevX.Cecil
{
	[Flags]
	public enum EventAttributes : ushort
	{
		SpecialName = 0x200,
		RTSpecialName = 0x400
	}
}
