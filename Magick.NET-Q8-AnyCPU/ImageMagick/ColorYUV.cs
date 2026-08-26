namespace ImageMagick;

public sealed class ColorYUV : ColorBase
{
	public double U { get; set; }

	public double V { get; set; }

	public double Y { get; set; }

	public ColorYUV(double y, double u, double v)
		: base(new MagickColor(0, 0, 0))
	{
		Y = y;
		U = u;
		V = v;
	}

	private ColorYUV(MagickColor color)
		: base(color)
	{
		Y = 1.0 / (double)(int)Quantum.Max * (0.298839 * (double)(int)color.R + 0.586811 * (double)(int)color.G + 0.11435 * (double)(int)color.B);
		U = 1.0 / (double)(int)Quantum.Max * (-0.147 * (double)(int)color.R - 0.289 * (double)(int)color.G + 0.436 * (double)(int)color.B) + 0.5;
		V = 1.0 / (double)(int)Quantum.Max * (0.615 * (double)(int)color.R - 0.515 * (double)(int)color.G - 0.1 * (double)(int)color.B) + 0.5;
	}

	public static implicit operator ColorYUV(MagickColor color)
	{
		return FromMagickColor(color);
	}

	public static ColorYUV FromMagickColor(MagickColor color)
	{
		if (color == null)
		{
			return null;
		}
		return new ColorYUV(color);
	}

	protected override void UpdateColor()
	{
		base.Color.R = Quantum.ScaleToQuantum(Y - 3.945707070708279E-05 * (U - 0.5) + 1.139827967171717 * (V - 0.5));
		base.Color.G = Quantum.ScaleToQuantum(Y - 0.39461016414141414 * (U - 0.5) - 0.5805003156565657 * (V - 0.5));
		base.Color.B = Quantum.ScaleToQuantum(Y + 2.0319996843434343 * (U - 0.5) - 0.0004813762626262513 * (V - 0.5));
	}
}
