using System;

namespace SpirV
{
	[Flags]
	public enum ImageOperands : uint
	{
		None = 0x0,
		Bias = 0x1,
		Lod = 0x2,
		Grad = 0x4,
		ConstOffset = 0x8,
		Offset = 0x10,
		ConstOffsets = 0x20,
		Sample = 0x40,
		MinLod = 0x80
	}
}
