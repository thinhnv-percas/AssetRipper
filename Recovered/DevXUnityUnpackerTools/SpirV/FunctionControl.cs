using System;

namespace SpirV
{
	[Flags]
	public enum FunctionControl : uint
	{
		None = 0x0,
		Inline = 0x1,
		DontInline = 0x2,
		Pure = 0x4,
		Const = 0x8
	}
}
