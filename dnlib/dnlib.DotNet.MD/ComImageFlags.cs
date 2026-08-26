using System;

namespace dnlib.DotNet.MD;

[Flags]
public enum ComImageFlags : uint
{
	ILOnly = 1u,
	[Obsolete("Use Bit32Required", false)]
	_32BitRequired = 2u,
	Bit32Required = _32BitRequired,
	ILLibrary = 4u,
	StrongNameSigned = 8u,
	NativeEntryPoint = 0x10u,
	TrackDebugData = 0x10000u,
	[Obsolete("Use Bit32Preferred", false)]
	_32BitPreferred = 0x20000u,
	Bit32Preferred = _32BitPreferred
}
