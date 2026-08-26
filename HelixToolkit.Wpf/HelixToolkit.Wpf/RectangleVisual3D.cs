using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class RectangleVisual3D : MeshElement3D
{
	public static readonly DependencyProperty DivLengthProperty = DependencyProperty.Register("DivLength", typeof(int), typeof(RectangleVisual3D), new UIPropertyMetadata(10, MeshElement3D.GeometryChanged, CoerceDivValue));

	public static readonly DependencyProperty DivWidthProperty = DependencyProperty.Register("DivWidth", typeof(int), typeof(RectangleVisual3D), new UIPropertyMetadata(10, MeshElement3D.GeometryChanged, CoerceDivValue));

	public static readonly DependencyProperty LengthDirectionProperty = DependencyProperty.Register("LengthDirection", typeof(Vector3D), typeof(RectangleVisual3D), new PropertyMetadata(new Vector3D(1.0, 0.0, 0.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty LengthProperty = DependencyProperty.Register("Length", typeof(double), typeof(RectangleVisual3D), new PropertyMetadata(10.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty NormalProperty = DependencyProperty.Register("Normal", typeof(Vector3D), typeof(RectangleVisual3D), new PropertyMetadata(new Vector3D(0.0, 0.0, 1.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty OriginProperty = DependencyProperty.Register("Origin", typeof(Point3D), typeof(RectangleVisual3D), new PropertyMetadata(new Point3D(0.0, 0.0, 0.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width", typeof(double), typeof(RectangleVisual3D), new PropertyMetadata(10.0, MeshElement3D.GeometryChanged));

	public int DivLength
	{
		get
		{
			return (int)GetValue(DivLengthProperty);
		}
		set
		{
			SetValue(DivLengthProperty, value);
		}
	}

	public int DivWidth
	{
		get
		{
			return (int)GetValue(DivWidthProperty);
		}
		set
		{
			SetValue(DivWidthProperty, value);
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

	public Point3D Origin
	{
		get
		{
			return (Point3D)GetValue(OriginProperty);
		}
		set
		{
			SetValue(OriginProperty, value);
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

	protected override MeshGeometry3D Tessellate()
	{
		Vector3D lengthDirection = LengthDirection;
		Vector3D normal = Normal;
		Vector3D vector3D = Vector3D.CrossProduct(normal, lengthDirection);
		lengthDirection = Vector3D.CrossProduct(vector3D, normal);
		lengthDirection.Normalize();
		vector3D.Normalize();
		normal.Normalize();
		double length = Length;
		double width = Width;
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < DivLength; i++)
		{
			double num = -0.5 + (double)i / (double)(DivLength - 1);
			for (int j = 0; j < DivWidth; j++)
			{
				double num2 = -0.5 + (double)j / (double)(DivWidth - 1);
				list.Add(Origin + lengthDirection * length * num + vector3D * width * num2);
			}
		}
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false);
		meshBuilder.AddRectangularMesh(list, DivWidth);
		return meshBuilder.ToMesh();
	}

	private static object CoerceDivValue(DependencyObject d, object baseValue)
	{
		return Math.Max(2, (int)baseValue);
	}
}
