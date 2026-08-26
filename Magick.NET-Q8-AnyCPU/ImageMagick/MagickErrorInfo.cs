namespace ImageMagick;

public sealed class MagickErrorInfo
{
	public double MeanErrorPerPixel { get; private set; }

	public double NormalizedMaximumError { get; private set; }

	public double NormalizedMeanError { get; private set; }

	internal MagickErrorInfo()
		: this(0.0, 0.0, 0.0)
	{
	}

	internal MagickErrorInfo(double meanErrorPerPixel, double normalizedMeanError, double normalizedMaximumError)
	{
		MeanErrorPerPixel = meanErrorPerPixel;
		NormalizedMeanError = normalizedMeanError;
		NormalizedMaximumError = normalizedMaximumError;
	}
}
