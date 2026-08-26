using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace HelixToolkit.Wpf;

public class ImageMaterialExtension : MarkupExtension
{
	private readonly string path;

	public double Opacity { get; set; }

	public UriKind UriKind { get; set; }

	public bool IsEmissive { get; set; }

	public ImageMaterialExtension(string path)
	{
		this.path = path;
		Opacity = 1.0;
		UriKind = UriKind.RelativeOrAbsolute;
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		if (IsEmissive)
		{
			return MaterialHelper.CreateEmissiveImageMaterial(path, Brushes.Black, UriKind);
		}
		return MaterialHelper.CreateImageMaterial(path, Opacity, UriKind);
	}
}
