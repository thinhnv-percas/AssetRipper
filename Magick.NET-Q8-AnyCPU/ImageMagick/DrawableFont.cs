using System;

namespace ImageMagick;

public sealed class DrawableFont : IDrawable, IDrawingWand
{
	private static readonly string[] _FontExtensions = new string[5] { ".ttf", ".tcc", ".pfb", ".pfm", ".otf" };

	public string Family { get; set; }

	public FontStyleType Style { get; set; }

	public FontWeight Weight { get; set; }

	public FontStretch Stretch { get; set; }

	public DrawableFont(string family)
		: this(family, FontStyleType.Any, FontWeight.Normal, FontStretch.Normal)
	{
	}

	public DrawableFont(string family, FontStyleType style, FontWeight weight, FontStretch stretch)
	{
		Throw.IfNullOrEmpty("family", family);
		Family = family;
		Style = style;
		Weight = weight;
		Stretch = stretch;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		if (wand == null)
		{
			return;
		}
		string[] fontExtensions = _FontExtensions;
		foreach (string value in fontExtensions)
		{
			if (Family.EndsWith(value, StringComparison.OrdinalIgnoreCase))
			{
				wand.Font(Family);
				return;
			}
		}
		wand.FontFamily(Family, Style, Weight, Stretch);
	}
}
