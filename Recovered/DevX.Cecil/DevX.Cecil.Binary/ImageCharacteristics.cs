using System;

namespace DevX.Cecil.Binary
{
	[Flags]
	public enum ImageCharacteristics : ushort
	{
		RelocsStripped = 0x1,
		ExecutableImage = 0x2,
		LineNumsStripped = 0x4,
		LocalSymsStripped = 0x8,
		AggressiveWSTrim = 0x10,
		LargeAddressAware = 0x20,
		ReservedForFutureUse = 0x40,
		BytesReversedLo = 0x80,
		_32BitsMachine = 0x100,
		DebugStripped = 0x200,
		RemovableRunFromSwap = 0x400,
		NetRunFromSwap = 0x800,
		System = 0x1000,
		Dll = 0x2000,
		UPSystemOnly = 0x4000,
		BytesReversedHI = 0x8000,
		__flags = 0x10E,
		CILOnlyDll = 0x210E,
		CILOnlyExe = 0x10E
	}
}
