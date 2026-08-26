using System;
using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class BoundingBoxWireFrameVisual3D : LinesVisual3D
{
	public static readonly DependencyProperty BoundingBoxProperty = DependencyProperty.Register("BoundingBox", typeof(Rect3D), typeof(BoundingBoxWireFrameVisual3D), new UIPropertyMetadata(default(Rect3D), BoxChanged));

	public Rect3D BoundingBox
	{
		get
		{
			return (Rect3D)GetValue(BoundingBoxProperty);
		}
		set
		{
			SetValue(BoundingBoxProperty, value);
		}
	}

	protected virtual void OnBoxChanged()
	{
		if (BoundingBox.IsEmpty)
		{
			base.Points = null;
			return;
		}
		Point3DCollection points = new Point3DCollection();
		Rect3D boundingBox = BoundingBox;
		Point3D point3D = new Point3D(boundingBox.X, boundingBox.Y, boundingBox.Z);
		Point3D point3D2 = new Point3D(boundingBox.X, boundingBox.Y + boundingBox.SizeY, boundingBox.Z);
		Point3D point3D3 = new Point3D(boundingBox.X + boundingBox.SizeX, boundingBox.Y + boundingBox.SizeY, boundingBox.Z);
		Point3D point3D4 = new Point3D(boundingBox.X + boundingBox.SizeX, boundingBox.Y, boundingBox.Z);
		Point3D point3D5 = new Point3D(boundingBox.X, boundingBox.Y, boundingBox.Z + boundingBox.SizeZ);
		Point3D point3D6 = new Point3D(boundingBox.X, boundingBox.Y + boundingBox.SizeY, boundingBox.Z + boundingBox.SizeZ);
		Point3D point3D7 = new Point3D(boundingBox.X + boundingBox.SizeX, boundingBox.Y + boundingBox.SizeY, boundingBox.Z + boundingBox.SizeZ);
		Point3D point3D8 = new Point3D(boundingBox.X + boundingBox.SizeX, boundingBox.Y, boundingBox.Z + boundingBox.SizeZ);
		Action<Point3D, Point3D> action = delegate(Point3D p, Point3D q)
		{
			points.Add(p);
			points.Add(q);
		};
		action(point3D, point3D2);
		action(point3D2, point3D3);
		action(point3D3, point3D4);
		action(point3D4, point3D);
		action(point3D5, point3D6);
		action(point3D6, point3D7);
		action(point3D7, point3D8);
		action(point3D8, point3D5);
		action(point3D, point3D5);
		action(point3D2, point3D6);
		action(point3D3, point3D7);
		action(point3D4, point3D8);
		base.Points = points;
	}

	private static void BoxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((BoundingBoxWireFrameVisual3D)d).OnBoxChanged();
	}
}
