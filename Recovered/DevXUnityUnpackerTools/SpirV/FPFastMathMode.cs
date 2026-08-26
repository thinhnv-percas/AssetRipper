using System;

namespace SpirV
{
	[Flags]
	public enum FPFastMathMode : uint
	{
		None = 0x0,
		NotNaN = 0x1,
		NotInf = 0x2,
		NSZ = 0x4,
		AllowRecip = 0x8,
		Fast = 0x10
	}
}
