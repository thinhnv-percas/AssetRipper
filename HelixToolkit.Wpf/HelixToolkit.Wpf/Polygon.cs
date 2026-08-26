using System.Windows.Media;

namespace HelixToolkit.Wpf;

public class Polygon
{
	internal PointCollection points;

	public PointCollection Points
	{
		get
		{
			return points ?? (points = new PointCollection());
		}
		set
		{
			points = value;
		}
	}

	public Int32Collection Triangulate()
	{
		return SweepLinePolygonTriangulator.Triangulate(points);
	}
}
