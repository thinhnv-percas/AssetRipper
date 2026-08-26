using System;

namespace ImageMagick.Defines;

[Flags]
public enum ProfileTypes
{
	App = 1,
	EightBim = 2,
	Exif = 4,
	Icc = 8,
	Iptc = 0x10,
	Xmp = 0x20
}
