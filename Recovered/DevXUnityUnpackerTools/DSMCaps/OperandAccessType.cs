using System;

namespace DSMCaps
{
	[Flags]
	public enum OperandAccessType : byte
	{
		Invalid = 0x0,
		Read = 0x1,
		Write = 0x2
	}
}
