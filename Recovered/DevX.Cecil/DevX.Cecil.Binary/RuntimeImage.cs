using System;

namespace DevX.Cecil.Binary
{
	[Flags]
	public enum RuntimeImage : uint
	{
		ILOnly = 0x1,
		F32BitsRequired = 0x2,
		StrongNameSigned = 0x8,
		TrackDebugData = 0x10000
	}
}
