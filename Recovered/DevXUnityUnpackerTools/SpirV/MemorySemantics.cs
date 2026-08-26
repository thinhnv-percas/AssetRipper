using System;

namespace SpirV
{
	[Flags]
	public enum MemorySemantics : uint
	{
		Relaxed = 0x0,
		None = 0x0,
		Acquire = 0x2,
		Release = 0x4,
		AcquireRelease = 0x8,
		SequentiallyConsistent = 0x10,
		UniformMemory = 0x40,
		SubgroupMemory = 0x80,
		WorkgroupMemory = 0x100,
		CrossWorkgroupMemory = 0x200,
		AtomicCounterMemory = 0x400,
		ImageMemory = 0x800
	}
}
