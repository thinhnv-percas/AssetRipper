using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class PanoramaCube3D : ModelVisual3D
{
	public static readonly DependencyProperty AutoCenterProperty = DependencyProperty.Register("AutoCenter", typeof(bool), typeof(PanoramaCube3D), new UIPropertyMetadata(true));

	public static readonly DependencyProperty ShowSeamsProperty = DependencyProperty.Register("ShowSeams", typeof(bool), typeof(PanoramaCube3D), new UIPropertyMetadata(false, GeometryChanged));

	public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(double), typeof(PanoramaCube3D), new UIPropertyMetadata(100.0, GeometryChanged));

	public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(PanoramaCube3D), new UIPropertyMetadata(null, SourceChanged));

	private readonly ModelVisual3D visualChild;

	public bool AutoCenter
	{
		get
		{
			return (bool)GetValue(AutoCenterProperty);
		}
		set
		{
			SetValue(AutoCenterProperty, value);
		}
	}

	public bool ShowSeams
	{
		get
		{
			return (bool)GetValue(ShowSeamsProperty);
		}
		set
		{
			SetValue(ShowSeamsProperty, value);
		}
	}

	public double Size
	{
		get
		{
			return (double)GetValue(SizeProperty);
		}
		set
		{
			SetValue(SizeProperty, value);
		}
	}

	public string Source
	{
		get
		{
			return (string)GetValue(SourceProperty);
		}
		set
		{
			SetValue(SourceProperty, value);
		}
	}

	public PanoramaCube3D()
	{
		visualChild = new ModelVisual3D();
		base.Children.Add(visualChild);
	}

	protected static void SourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
	{
		((PanoramaCube3D)obj).UpdateModel();
	}

	private static void GeometryChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((PanoramaCube3D)d).UpdateModel();
	}

	private GeometryModel3D AddCubeSide(Vector3D normal, Vector3D up, string fileName)
	{
		string fullPath = Path.GetFullPath(fileName);
		if (!File.Exists(fullPath))
		{
			return null;
		}
		BitmapImage bitmapImage = new BitmapImage();
		bitmapImage.BeginInit();
		bitmapImage.UriSource = new Uri(fullPath);
		bitmapImage.EndInit();
		ImageBrush brush = new ImageBrush(bitmapImage);
		DiffuseMaterial material = new DiffuseMaterial(brush);
		MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
		Vector3D vector3D = Vector3D.CrossProduct(normal, up);
		Point3D point3D = new Point3D(0.0, 0.0, 0.0);
		double num = (ShowSeams ? 0.995 : 1.0);
		num *= Size;
		Vector3D vector3D2 = normal * Size;
		vector3D *= num;
		up *= num;
		Point3D value = point3D + vector3D2 - up - vector3D;
		Point3D value2 = point3D + vector3D2 - up + vector3D;
		Point3D value3 = point3D + vector3D2 + up + vector3D;
		Point3D value4 = point3D + vector3D2 + up - vector3D;
		meshGeometry3D.Positions.Add(value);
		meshGeometry3D.Positions.Add(value2);
		meshGeometry3D.Positions.Add(value3);
		meshGeometry3D.Positions.Add(value4);
		meshGeometry3D.TextureCoordinates.Add(new Point(0.0, 1.0));
		meshGeometry3D.TextureCoordinates.Add(new Point(1.0, 1.0));
		meshGeometry3D.TextureCoordinates.Add(new Point(1.0, 0.0));
		meshGeometry3D.TextureCoordinates.Add(new Point(0.0, 0.0));
		meshGeometry3D.TriangleIndices.Add(0);
		meshGeometry3D.TriangleIndices.Add(1);
		meshGeometry3D.TriangleIndices.Add(2);
		meshGeometry3D.TriangleIndices.Add(2);
		meshGeometry3D.TriangleIndices.Add(3);
		meshGeometry3D.TriangleIndices.Add(0);
		return new GeometryModel3D(meshGeometry3D, material);
	}

	private void UpdateModel()
	{
		string directoryName = Path.GetDirectoryName(Source);
		string text = Path.GetFileName(Source);
		if (string.IsNullOrEmpty(text))
		{
			text = "cube";
		}
		string fileName = Path.Combine(directoryName, text + "_f.jpg");
		string fileName2 = Path.Combine(directoryName, text + "_l.jpg");
		string fileName3 = Path.Combine(directoryName, text + "_r.jpg");
		string fileName4 = Path.Combine(directoryName, text + "_b.jpg");
		string fileName5 = Path.Combine(directoryName, text + "_u.jpg");
		string fileName6 = Path.Combine(directoryName, text + "_d.jpg");
		Model3DGroup model3DGroup = new Model3DGroup();
		model3DGroup.Children.Add(AddCubeSide(new Vector3D(0.0, 1.0, 0.0), new Vector3D(0.0, 0.0, 1.0), fileName));
		model3DGroup.Children.Add(AddCubeSide(new Vector3D(-1.0, 0.0, 0.0), new Vector3D(0.0, 0.0, 1.0), fileName2));
		model3DGroup.Children.Add(AddCubeSide(new Vector3D(1.0, 0.0, 0.0), new Vector3D(0.0, 0.0, 1.0), fileName3));
		model3DGroup.Children.Add(AddCubeSide(new Vector3D(0.0, -1.0, 0.0), new Vector3D(0.0, 0.0, 1.0), fileName4));
		model3DGroup.Children.Add(AddCubeSide(new Vector3D(0.0, 0.0, 1.0), new Vector3D(0.0, -1.0, 0.0), fileName5));
		model3DGroup.Children.Add(AddCubeSide(new Vector3D(0.0, 0.0, -1.0), new Vector3D(0.0, 1.0, 0.0), fileName6));
		visualChild.Content = model3DGroup;
	}
}
