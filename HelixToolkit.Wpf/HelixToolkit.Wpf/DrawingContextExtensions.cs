using System;
using System.Windows;
using System.Windows.Media;

namespace HelixToolkit.Wpf;

public static class DrawingContextExtensions
{
	public static void DrawArc(this DrawingContext dc, Brush brush, Pen pen, Point start, Point end, SweepDirection direction, double radiusX, double radiusY)
	{
		PathGeometry pathGeometry = new PathGeometry();
		PathFigure pathFigure = new PathFigure();
		pathGeometry.Figures.Add(pathFigure);
		pathFigure.StartPoint = start;
		pathFigure.Segments.Add(new ArcSegment(end, new Size(radiusX, radiusY), 0.0, isLargeArc: false, direction, isStroked: true));
		dc.DrawGeometry(brush, pen, pathGeometry);
	}

	public static void DrawArc(this DrawingContext dc, Brush brush, Pen pen, Point position, double startAngle, double endAngle, SweepDirection direction, double radiusX, double radiusY)
	{
		double num = startAngle / 180.0 * Math.PI;
		double num2 = endAngle / 180.0 * Math.PI;
		Point start = position + new Vector(Math.Cos(num) * radiusX, (0.0 - Math.Sin(num)) * radiusY);
		Point end = position + new Vector(Math.Cos(num2) * radiusX, (0.0 - Math.Sin(num2)) * radiusY);
		dc.DrawArc(brush, pen, start, end, direction, radiusX, radiusY);
	}

	public static void DrawArc(this DrawingContext dc, Brush brush, Pen pen, Point position, double startAngle, double endAngle, double radiusX, double radiusY)
	{
		dc.DrawArc(brush, pen, position, startAngle, endAngle, SweepDirection.Counterclockwise, radiusX, radiusY);
	}
}
