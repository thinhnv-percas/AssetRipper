using System;
using System.Windows.Markup;

namespace HelixToolkit.Wpf;

public class GradientExtension : MarkupExtension
{
	public enum GradientBrushType
	{
		Hue,
		Rainbow
	}

	private readonly GradientBrushType type;

	public GradientExtension(GradientBrushType type)
	{
		this.type = type;
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return type switch
		{
			GradientBrushType.Hue => GradientBrushes.Hue, 
			GradientBrushType.Rainbow => GradientBrushes.Rainbow, 
			_ => null, 
		};
	}
}
