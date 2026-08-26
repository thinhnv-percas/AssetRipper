namespace ImageMagick;

public enum MorphologyMethod
{
	Undefined,
	Convolve,
	Correlate,
	Erode,
	Dilate,
	ErodeIntensity,
	DilateIntensity,
	IterativeDistance,
	Open,
	Close,
	OpenIntensity,
	CloseIntensity,
	Smooth,
	EdgeIn,
	EdgeOut,
	Edge,
	TopHat,
	BottomHat,
	HitAndMiss,
	Thinning,
	Thicken,
	Distance,
	Voronoi
}
