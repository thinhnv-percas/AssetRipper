using System;
using System.Windows.Markup;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class PerspectiveCameraExtension : MarkupExtension
{
	public double FieldOfView { get; set; }

	public Vector3D LookDirection { get; set; }

	public Point3D Position { get; set; }

	public Vector3D UpDirection { get; set; }

	public PerspectiveCameraExtension(double x, double y, double z)
		: this(x, y, z, 0.0 - x, 0.0 - y, 0.0 - z)
	{
	}

	public PerspectiveCameraExtension(double x, double y, double z, double dx, double dy, double dz)
	{
		Position = new Point3D(x, y, z);
		LookDirection = new Vector3D(dx, dy, dz);
		UpDirection = new Vector3D(0.0, 0.0, 1.0);
		FieldOfView = 60.0;
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return new PerspectiveCamera(Position, LookDirection, UpDirection, FieldOfView);
	}
}
