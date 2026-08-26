using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace HelixToolkit.Wpf;

public class MaterialExtension : MarkupExtension
{
	private readonly Color color;

	public double Opacity { get; set; }

	public double SpecularIntensity { get; set; }

	public double SpecularPower { get; set; }

	public MaterialExtension(Color color)
	{
		this.color = color;
		SpecularPower = 100.0;
		SpecularIntensity = 1.0;
		Opacity = 1.0;
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		SolidColorBrush diffuse = new SolidColorBrush(color);
		SolidColorBrush specular = BrushHelper.CreateGrayBrush(SpecularIntensity);
		return MaterialHelper.CreateMaterial(diffuse, null, specular, Opacity, SpecularPower);
	}
}
