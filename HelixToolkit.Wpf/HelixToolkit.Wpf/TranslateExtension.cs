using System;
using System.Windows.Markup;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class TranslateExtension : MarkupExtension
{
	public Vector3D Offset { get; set; }

	public TranslateExtension(double dx, double dy, double dz)
	{
		Offset = new Vector3D(dx, dy, dz);
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return new TranslateTransform3D(Offset);
	}
}
