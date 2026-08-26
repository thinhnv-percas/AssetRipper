using System.Drawing;

namespace ImageMagick;

public sealed class ColorRGB : ColorBase
{
	public byte B
	{
		get
		{
			return base.Color.B;
		}
		set
		{
			base.Color.B = value;
		}
	}

	public byte G
	{
		get
		{
			return base.Color.G;
		}
		set
		{
			base.Color.G = value;
		}
	}

	public byte R
	{
		get
		{
			return base.Color.R;
		}
		set
		{
			base.Color.R = value;
		}
	}

	public ColorRGB(Color color)
		: base(new MagickColor(color))
	{
	}

	public ColorRGB(MagickColor value)
		: base(value)
	{
	}

	public ColorRGB(byte red, byte green, byte blue)
		: base(new MagickColor(red, green, blue))
	{
	}

	public static implicit operator ColorRGB(MagickColor color)
	{
		return FromMagickColor(color);
	}

	public static ColorRGB FromMagickColor(MagickColor color)
	{
		if (color == null)
		{
			return null;
		}
		return new ColorRGB(color);
	}

	public ColorRGB ComplementaryColor()
	{
		ColorHSV colorHSV = ColorHSV.FromMagickColor(this);
		colorHSV.HueShift(180.0);
		return new ColorRGB(colorHSV);
	}
}
