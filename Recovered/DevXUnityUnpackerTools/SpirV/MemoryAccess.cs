using System;

namespace SpirV
{
	[Flags]
	public enum MemoryAccess : uint
	{
		None = 0x0,
		Volatile = 0x1,
		Aligned = 0x2,
		Nontemporal = 0x4
	}
}
