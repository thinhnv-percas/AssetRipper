using System;
using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class HelixVisual3D : ParametricSurface3D
{
	public static readonly DependencyProperty OriginProperty = DependencyProperty.Register("Origin", typeof(Point3D), typeof(HelixVisual3D), new PropertyMetadata(new Point3D(0.0, 0.0, 0.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty DiameterProperty = DependencyProperty.Register("Diameter", typeof(double), typeof(HelixVisual3D), new UIPropertyMetadata(0.5, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty LengthProperty = DependencyProperty.Register("Length", typeof(double), typeof(HelixVisual3D), new UIPropertyMetadata(1.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty PhaseProperty = DependencyProperty.Register("Phase", typeof(double), typeof(HelixVisual3D), new UIPropertyMetadata(0.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(HelixVisual3D), new UIPropertyMetadata(1.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty TurnsProperty = DependencyProperty.Register("Turns", typeof(double), typeof(HelixVisual3D), new UIPropertyMetadata(1.0, MeshElement3D.GeometryChanged));

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

	public double Phase
	{
		get
		{
			return (double)GetValue(PhaseProperty);
		}
		set
		{
			SetValue(PhaseProperty, value);
		}
	}

	public double Radius
	{
		get
		{
			return (double)GetValue(RadiusProperty);
		}
		set
		{
			SetValue(RadiusProperty, value);
		}
	}

	public double Turns
	{
		get
		{
			return (double)GetValue(TurnsProperty);
		}
		set
		{
			SetValue(TurnsProperty, value);
		}
	}

	protected override Point3D Evaluate(double u, double v, out Point texCoord)
	{
		v *= Math.PI * 2.0;
		double num = Turns * 2.0 * Math.PI;
		double num2 = Radius / 2.0;
		double diameter = Diameter;
		double num3 = Diameter / num2;
		double num4 = Phase / 180.0 * Math.PI;
		double x = num2 * Math.Cos(num * u + num4) * (2.0 + num3 * Math.Cos(v));
		double y = num2 * Math.Sin(num * u + num4) * (2.0 + num3 * Math.Cos(v));
		double z = u * Length + diameter * Math.Sin(v);
		texCoord = new Point(u, 0.0);
		return Origin + new Vector3D(x, y, z);
	}
}
