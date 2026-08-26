using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class GridLinesVisual3D : MeshElement3D
{
	public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point3D), typeof(GridLinesVisual3D), new UIPropertyMetadata(default(Point3D), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty MinorDistanceProperty = DependencyProperty.Register("MinorDistance", typeof(double), typeof(GridLinesVisual3D), new PropertyMetadata(2.5, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty LengthDirectionProperty = DependencyProperty.Register("LengthDirection", typeof(Vector3D), typeof(GridLinesVisual3D), new UIPropertyMetadata(new Vector3D(1.0, 0.0, 0.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty LengthProperty = DependencyProperty.Register("Length", typeof(double), typeof(GridLinesVisual3D), new PropertyMetadata(200.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty MajorDistanceProperty = DependencyProperty.Register("MajorDistance", typeof(double), typeof(GridLinesVisual3D), new PropertyMetadata(10.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty NormalProperty = DependencyProperty.Register("Normal", typeof(Vector3D), typeof(GridLinesVisual3D), new UIPropertyMetadata(new Vector3D(0.0, 0.0, 1.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty ThicknessProperty = DependencyProperty.Register("Thickness", typeof(double), typeof(GridLinesVisual3D), new PropertyMetadata(0.08, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width", typeof(double), typeof(GridLinesVisual3D), new PropertyMetadata(200.0, MeshElement3D.GeometryChanged));

	private Vector3D lengthDirection;

	private Vector3D widthDirection;

	public Point3D Center
	{
		get
		{
			return (Point3D)GetValue(CenterProperty);
		}
		set
		{
			SetValue(CenterProperty, value);
		}
	}

	public double Length
	{
		get
		{
			return (double)GetValue(LengthProperty);
		}
		set
		{
			SetValue(LengthProperty, value);
		}
	}

	public Vector3D LengthDirection
	{
		get
		{
			return (Vector3D)GetValue(LengthDirectionProperty);
		}
		set
		{
			SetValue(LengthDirectionProperty, value);
		}
	}

	public double MajorDistance
	{
		get
		{
			return (double)GetValue(MajorDistanceProperty);
		}
		set
		{
			SetValue(MajorDistanceProperty, value);
		}
	}

	public double MinorDistance
	{
		get
		{
			return (double)GetValue(MinorDistanceProperty);
		}
		set
		{
			SetValue(MinorDistanceProperty, value);
		}
	}

	public Vector3D Normal
	{
		get
		{
			return (Vector3D)GetValue(NormalProperty);
		}
		set
		{
			SetValue(NormalProperty, value);
		}
	}

	public double Thickness
	{
		get
		{
			return (double)GetValue(ThicknessProperty);
		}
		set
		{
			SetValue(ThicknessProperty, value);
		}
	}

	public double Width
	{
		get
		{
			return (double)GetValue(WidthProperty);
		}
		set
		{
			SetValue(WidthProperty, value);
		}
	}

	public GridLinesVisual3D()
	{
		base.Fill = Brushes.Gray;
	}

	protected override MeshGeometry3D Tessellate()
	{
		lengthDirection = LengthDirection;
		lengthDirection.Normalize();
		if (Vector3D.DotProduct(Normal, LengthDirection) != 0.0)
		{
			lengthDirection = Normal.FindAnyPerpendicular();
			lengthDirection.Normalize();
		}
		RotateTransform3D rotateTransform3D = new RotateTransform3D(new AxisAngleRotation3D(Normal, 90.0));
		widthDirection = rotateTransform3D.Transform(lengthDirection);
		widthDirection.Normalize();
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: true, generateTexCoords: false);
		double num = (0.0 - Width) / 2.0;
		double num2 = (0.0 - Length) / 2.0;
		double num3 = Width / 2.0;
		double num4 = Length / 2.0;
		double num5 = num;
		double num6;
		for (num6 = MinorDistance / 10.0; num5 <= num3 + num6; num5 += MinorDistance)
		{
			double num7 = Thickness;
			if (IsMultipleOf(num5, MajorDistance))
			{
				num7 *= 2.0;
			}
			AddLineX(meshBuilder, num5, num2, num4, num7);
		}
		for (double num8 = num2; num8 <= num4 + num6; num8 += MinorDistance)
		{
			double num9 = Thickness;
			if (IsMultipleOf(num8, MajorDistance))
			{
				num9 *= 2.0;
			}
			AddLineY(meshBuilder, num8, num, num3, num9);
		}
		MeshGeometry3D meshGeometry3D = meshBuilder.ToMesh();
		meshGeometry3D.Freeze();
		return meshGeometry3D;
	}

	private static bool IsMultipleOf(double y, double d)
	{
		double num = d * (double)(int)(y / d);
		return Math.Abs(y - num) < 0.001;
	}

	private void AddLineX(MeshBuilder mesh, double x, double minY, double maxY, double thickness)
	{
		int count = mesh.Positions.Count;
		mesh.Positions.Add(GetPoint(x - thickness / 2.0, minY));
		mesh.Positions.Add(GetPoint(x - thickness / 2.0, maxY));
		mesh.Positions.Add(GetPoint(x + thickness / 2.0, maxY));
		mesh.Positions.Add(GetPoint(x + thickness / 2.0, minY));
		mesh.Normals.Add(Normal);
		mesh.Normals.Add(Normal);
		mesh.Normals.Add(Normal);
		mesh.Normals.Add(Normal);
		mesh.TriangleIndices.Add(count);
		mesh.TriangleIndices.Add(count + 1);
		mesh.TriangleIndices.Add(count + 2);
		mesh.TriangleIndices.Add(count + 2);
		mesh.TriangleIndices.Add(count + 3);
		mesh.TriangleIndices.Add(count);
	}

	private void AddLineY(MeshBuilder mesh, double y, double minX, double maxX, double thickness)
	{
		int count = mesh.Positions.Count;
		mesh.Positions.Add(GetPoint(minX, y + thickness / 2.0));
		mesh.Positions.Add(GetPoint(maxX, y + thickness / 2.0));
		mesh.Positions.Add(GetPoint(maxX, y - thickness / 2.0));
		mesh.Positions.Add(GetPoint(minX, y - thickness / 2.0));
		mesh.Normals.Add(Normal);
		mesh.Normals.Add(Normal);
		mesh.Normals.Add(Normal);
		mesh.Normals.Add(Normal);
		mesh.TriangleIndices.Add(count);
		mesh.TriangleIndices.Add(count + 1);
		mesh.TriangleIndices.Add(count + 2);
		mesh.TriangleIndices.Add(count + 2);
		mesh.TriangleIndices.Add(count + 3);
		mesh.TriangleIndices.Add(count);
	}

	private Point3D GetPoint(double x, double y)
	{
		return Center + widthDirection * x + lengthDirection * y;
	}
}
