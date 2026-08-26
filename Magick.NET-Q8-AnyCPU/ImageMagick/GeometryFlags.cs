namespace ImageMagick;

internal enum GeometryFlags
{
	NoValue = 0,
	PercentValue = 0x1000,
	IgnoreAspectRatio = 0x2000,
	Less = 0x4000,
	Greater = 0x8000,
	FillArea = 0x10000,
	LimitPixels = 0x20000
}
