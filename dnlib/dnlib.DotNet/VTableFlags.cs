using System;

namespace dnlib.DotNet;

[Flags]
public enum VTableFlags : ushort
{
	[Obsolete("Use Bit32", false)]
	_32Bit = 1,
	Bit32 = _32Bit,
	[Obsolete("Use Bit64", false)]
	_64Bit = 2,
	Bit64 = _64Bit,
	FromUnmanaged = 4,
	FromUnmanagedRetainAppDomain = 8,
	CallMostDerived = 0x10
}
