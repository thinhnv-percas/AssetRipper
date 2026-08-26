using System;

namespace DevX.Cecil.Binary
{
	[Flags]
	public enum SectionCharacteristics : uint
	{
		TypeNoPad = 0x8,
		ContainsCode = 0x20,
		ContainsInitializedData = 0x40,
		ContainsUninitializedData = 0x80,
		LnkOther = 0x100,
		LnkInfo = 0x200,
		LnkRemove = 0x800,
		LnkCOMDAT = 0x1000,
		GPRel = 0x8000,
		MemPurgeable = 0x20000,
		MemLocked = 0x40000,
		MemPreload = 0x80000,
		Align1Bytes = 0x100000,
		Align2Bytes = 0x200000,
		Align4Bytes = 0x300000,
		Align8Bytes = 0x400000,
		Align16Bytes = 0x500000,
		Align32Bytes = 0x600000,
		Align64Bytes = 0x700000,
		Align128Bytes = 0x800000,
		Align256Bytes = 0x900000,
		Align512Bytes = 0xA00000,
		Align1024Bytes = 0xB00000,
		Align2048Bytes = 0xC00000,
		Align4096Bytes = 0xD00000,
		Align8192Bytes = 0xE00000,
		LnkNRelocOvfl = 0x1000000,
		MemDiscardable = 0x2000000,
		MemNotCached = 0x4000000,
		MemNotPaged = 0x8000000,
		MemShared = 0x10000000,
		MemExecute = 0x20000000,
		MemoryRead = 0x40000000,
		MemoryWrite = 0x80000000
	}
}
