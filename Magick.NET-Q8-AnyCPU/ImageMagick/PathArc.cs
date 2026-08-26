namespace ImageMagick;

public sealed class PathArc
{
	public double RadiusX { get; set; }

	public double RadiusY { get; set; }

	public double RotationX { get; set; }

	public bool UseLargeArc { get; set; }

	public bool UseSweep { get; set; }

	public double X { get; set; }

	public double Y { get; set; }

	public PathArc()
	{
	}

	public PathArc(double x, double y, double radiusX, double radiusY, double rotationX, bool useLargeArc, bool useSweep)
	{
		X = x;
		Y = y;
		RadiusX = radiusX;
		RadiusY = radiusY;
		RotationX = rotationX;
		UseLargeArc = useLargeArc;
		UseSweep = useSweep;
	}
}
