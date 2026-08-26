namespace ImageMagick;

public sealed class ColorGray : ColorBase
{
	private double _shade;

	public double Shade
	{
		get
		{
			return _shade;
		}
		set
		{
			if (!(value < 0.0) && !(value > 1.0))
			{
				_shade = value;
			}
		}
	}

	public ColorGray(double shade)
		: base(new MagickColor(0, 0, 0))
	{
		Throw.IfTrue("shade", shade < 0.0 || shade > 1.0, "Invalid shade specified");
		_shade = shade;
	}

	private ColorGray(MagickColor color)
		: base(color)
	{
		_shade = (int)Quantum.ScaleToQuantum((int)color.R);
	}

	public static implicit operator ColorGray(MagickColor color)
	{
		return FromMagickColor(color);
	}

	public static ColorGray FromMagickColor(MagickColor color)
	{
		if (color == null)
		{
			return null;
		}
		return new ColorGray(color);
	}

	protected override void UpdateColor()
	{
		byte b = Quantum.ScaleToQuantum(_shade);
		base.Color.R = b;
		base.Color.G = b;
		base.Color.B = b;
	}
}
