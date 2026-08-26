using System;

namespace ImageMagick;

[Flags]
public enum ExifParts
{
	None = 0,
	IfdTags = 1,
	ExifTags = 4,
	GPSTags = 8,
	All = IfdTags | ExifTags | GPSTags
}
