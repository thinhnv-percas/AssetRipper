namespace ImageMagick;

public enum ErrorMetric
{
	Undefined,
	Absolute,
	Fuzz,
	MeanAbsolute,
	MeanErrorPerPixel,
	MeanSquared,
	NormalizedCrossCorrelation,
	PeakAbsolute,
	PeakSignalToNoiseRatio,
	PerceptualHash,
	RootMeanSquared,
	StructuralSimilarity,
	StructuralDissimilarity
}
