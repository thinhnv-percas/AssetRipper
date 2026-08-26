using System;

namespace ImageMagick;

[Flags]
public enum Channels
{
	None = 0,
	Red = 1,
	Gray = Red,
	Cyan = Red,
	Green = 2,
	Magenta = Green,
	Blue = 4,
	Yellow = Blue,
	Black = 8,
	Alpha = 0x10,
	Opacity = Alpha,
	Index = 0x20,
	Composite = Red | Green | Blue | Black | Alpha,
	All = 0x7FFFFFF,
	TrueAlpha = 0x100,
	RGB = 7,
	CMYK = 0xF,
	Grays = 0x400,
	Sync = 0x20000,
	Default = All
}
