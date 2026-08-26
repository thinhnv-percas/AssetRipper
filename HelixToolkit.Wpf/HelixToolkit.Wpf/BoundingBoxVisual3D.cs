using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class BoundingBoxVisual3D : ModelVisual3D
{
	public static readonly DependencyProperty BoundingBoxProperty = DependencyProperty.Register("BoundingBox", typeof(Rect3D), typeof(BoundingBoxVisual3D), new UIPropertyMetadata(default(Rect3D), BoxChanged));

	public static readonly DependencyProperty DiameterProperty = DependencyProperty.Register("Diameter", typeof(double), typeof(BoundingBoxVisual3D), new UIPropertyMetadata(0.1, BoxChanged));

	public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(BoundingBoxVisual3D), new UIPropertyMetadata(Brushes.Yellow, FillChanged));

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

	public double Diameter
	{
		get
		{
			return (double)GetValue(DiameterProperty);
		}
		set
		{
			SetValue(DiameterProperty, value);
		}
	}

	public Brush Fill
	{
		get
		{
			return (Brush)GetValue(FillProperty);
		}
		set
		{
			SetValue(FillProperty, value);
		}
	}

	protected virtual void OnBoxChanged()
	{
		base.Children.Clear();
		if (!BoundingBox.IsEmpty)
		{
			Rect3D boundingBox = BoundingBox;
			Point3D point3D = new Point3D(boundingBox.X, boundingBox.Y, boundingBox.Z);
			Point3D point3D2 = new Point3D(boundingBox.X, boundingBox.Y + boundingBox.SizeY, boundingBox.Z);
			Point3D point3D3 = new Point3D(boundingBox.X + boundingBox.SizeX, boundingBox.Y + boundingBox.SizeY, boundingBox.Z);
			Point3D point3D4 = new Point3D(boundingBox.X + boundingBox.SizeX, boundingBox.Y, boundingBox.Z);
			Point3D point3D5 = new Point3D(boundingBox.X, boundingBox.Y, boundingBox.Z + boundingBox.SizeZ);
			Point3D point3D6 = new Point3D(boundingBox.X, boundingBox.Y + boundingBox.SizeY, boundingBox.Z + boundingBox.SizeZ);
			Point3D point3D7 = new Point3D(boundingBox.X + boundingBox.SizeX, boundingBox.Y + boundingBox.SizeY, boundingBox.Z + boundingBox.SizeZ);
			Point3D point3D8 = new Point3D(boundingBox.X + boundingBox.SizeX, boundingBox.Y, boundingBox.Z + boundingBox.SizeZ);
			AddEdge(point3D, point3D2);
			AddEdge(point3D2, point3D3);
			AddEdge(point3D3, point3D4);
			AddEdge(point3D4, point3D);
			AddEdge(point3D5, point3D6);
			AddEdge(point3D6, point3D7);
			AddEdge(point3D7, point3D8);
			AddEdge(point3D8, point3D5);
			AddEdge(point3D, point3D5);
			AddEdge(point3D2, point3D6);
			AddEdge(point3D3, point3D7);
			AddEdge(point3D4, point3D8);
		}
	}

	protected virtual void OnFillChanged()
	{
		foreach (MeshElement3D child in base.Children)
		{
			if (child != null)
			{
				child.Fill = Fill;
			}
		}
	}

	private static void BoxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((BoundingBoxVisual3D)d).OnBoxChanged();
	}

	private static void FillChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((BoundingBoxVisual3D)d).OnFillChanged();
	}

	private void AddEdge(Point3D p1, Point3D p2)
	{
		PipeVisual3D pipeVisual3D = new PipeVisual3D();
		pipeVisual3D.BeginEdit();
		pipeVisual3D.Diameter = Diameter;
		pipeVisual3D.ThetaDiv = 10;
		pipeVisual3D.Fill = Fill;
		pipeVisual3D.Point1 = p1;
		pipeVisual3D.Point2 = p2;
		pipeVisual3D.EndEdit();
		base.Children.Add(pipeVisual3D);
	}
}
