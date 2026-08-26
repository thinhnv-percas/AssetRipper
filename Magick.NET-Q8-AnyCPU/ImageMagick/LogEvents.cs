using System;

namespace ImageMagick;

[Flags]
public enum LogEvents
{
	None = 0,
	Accelerate = 1,
	Annotate = 2,
	Blob = 4,
	Cache = 8,
	Coder = 0x10,
	Configure = 0x20,
	Deprecate = 0x40,
	Draw = 0x80,
	Exception = 0x100,
	Image = 0x200,
	Locale = 0x400,
	Module = 0x800,
	Pixel = 0x1000,
	Policy = 0x2000,
	Resource = 0x4000,
	Trace = 0x8000,
	Transform = 0x10000,
	User = 0x20000,
	Wand = 0x40000,
	All = 0x7FFF7FFF
}
