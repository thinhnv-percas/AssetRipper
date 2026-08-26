using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace HelixToolkit.Wpf;

public class LinearGradientBrushExtension : MarkupExtension
{
	private readonly LinearGradientBrush brush;

	public LinearGradientBrushExtension(Color startColor, Color endColor, double angle)
	{
		brush = new LinearGradientBrush(startColor, endColor, angle);
	}

	public LinearGradientBrushExtension(Color startColor, Color endColor)
		: this(startColor, endColor, 90.0)
	{
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return brush;
	}
}
