using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class CoordinateSystemVisual3D : ModelVisual3D
{
	public static readonly DependencyProperty ArrowLengthsProperty = DependencyProperty.Register("ArrowLengths", typeof(double), typeof(CoordinateSystemVisual3D), new UIPropertyMetadata(1.0, GeometryChanged));

	public static readonly DependencyProperty XAxisColorProperty = DependencyProperty.Register("XAxisColor", typeof(Color), typeof(CoordinateSystemVisual3D), new UIPropertyMetadata(Color.FromRgb(150, 75, 75)));

	public static readonly DependencyProperty YAxisColorProperty = DependencyProperty.Register("YAxisColor", typeof(Color), typeof(CoordinateSystemVisual3D), new UIPropertyMetadata(Color.FromRgb(75, 150, 75)));

	public static readonly DependencyProperty ZAxisColorProperty = DependencyProperty.Register("ZAxisColor", typeof(Color), typeof(CoordinateSystemVisual3D), new UIPropertyMetadata(Color.FromRgb(75, 75, 150)));

	public double ArrowLengths
	{
		get
		{
			return (double)GetValue(ArrowLengthsProperty);
		}
		set
		{
			SetValue(ArrowLengthsProperty, value);
		}
	}

	public Color XAxisColor
	{
		get
		{
			return (Color)GetValue(XAxisColorProperty);
		}
		set
		{
			SetValue(XAxisColorProperty, value);
		}
	}

	public Color YAxisColor
	{
		get
		{
			return (Color)GetValue(YAxisColorProperty);
		}
		set
		{
			SetValue(YAxisColorProperty, value);
		}
	}

	public Color ZAxisColor
	{
		get
		{
			return (Color)GetValue(ZAxisColorProperty);
		}
		set
		{
			SetValue(ZAxisColorProperty, value);
		}
	}

	public CoordinateSystemVisual3D()
	{
		OnGeometryChanged();
	}

	protected static void GeometryChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
	{
		((CoordinateSystemVisual3D)obj).OnGeometryChanged();
	}

	protected virtual void OnGeometryChanged()
	{
		base.Children.Clear();
		double arrowLengths = ArrowLengths;
		double num = arrowLengths * 0.1;
		ArrowVisual3D arrowVisual3D = new ArrowVisual3D();
		arrowVisual3D.BeginEdit();
		arrowVisual3D.Point2 = new Point3D(arrowLengths, 0.0, 0.0);
		arrowVisual3D.Diameter = num;
		arrowVisual3D.Fill = new SolidColorBrush(XAxisColor);
		arrowVisual3D.EndEdit();
		base.Children.Add(arrowVisual3D);
		ArrowVisual3D arrowVisual3D2 = new ArrowVisual3D();
		arrowVisual3D2.BeginEdit();
		arrowVisual3D2.Point2 = new Point3D(0.0, arrowLengths, 0.0);
		arrowVisual3D2.Diameter = num;
		arrowVisual3D2.Fill = new SolidColorBrush(YAxisColor);
		arrowVisual3D2.EndEdit();
		base.Children.Add(arrowVisual3D2);
		ArrowVisual3D arrowVisual3D3 = new ArrowVisual3D();
		arrowVisual3D3.BeginEdit();
		arrowVisual3D3.Point2 = new Point3D(0.0, 0.0, arrowLengths);
		arrowVisual3D3.Diameter = num;
		arrowVisual3D3.Fill = new SolidColorBrush(ZAxisColor);
		arrowVisual3D3.EndEdit();
		base.Children.Add(arrowVisual3D3);
		base.Children.Add(new CubeVisual3D
		{
			SideLength = num,
			Fill = Brushes.Black
		});
	}
}
