using System;

namespace dnlib.PE;

[Flags]
public enum Characteristics : ushort
{
	RelocsStripped = 1,
	ExecutableImage = 2,
	LineNumsStripped = 4,
	LocalSymsStripped = 8,
	AggressiveWsTrim = 0x10,
	LargeAddressAware = 0x20,
	Reserved1 = 0x40,
	BytesReversedLo = 0x80,
	[Obsolete("Use Bit32Machine", false)]
	_32BitMachine = 0x100,
	Bit32Machine = _32BitMachine,
	DebugStripped = 0x200,
	RemovableRunFromSwap = 0x400,
	NetRunFromSwap = 0x800,
	System = 0x1000,
	Dll = 0x2000,
	UpSystemOnly = 0x4000,
	BytesReversedHi = 0x8000
}
