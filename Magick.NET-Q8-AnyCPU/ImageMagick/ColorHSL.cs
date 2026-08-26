using System;

namespace ImageMagick;

public sealed class ColorHSL : ColorBase
{
	public double Hue { get; set; }

	public double Lightness { get; set; }

	public double Saturation { get; set; }

	public ColorHSL(double hue, double saturation, double lightness)
		: base(new MagickColor(0, 0, 0))
	{
		Hue = hue;
		Saturation = saturation;
		Lightness = lightness;
	}

	private ColorHSL(MagickColor color)
		: base(color)
	{
		Initialize((int)color.R, (int)color.G, (int)color.B);
	}

	public static implicit operator ColorHSL(MagickColor color)
	{
		return FromMagickColor(color);
	}

	public static ColorHSL FromMagickColor(MagickColor color)
	{
		if (color == null)
		{
			return null;
		}
		return new ColorHSL(color);
	}

	protected override void UpdateColor()
	{
		double num = Hue * 360.0;
		double num2 = ((!(Lightness <= 0.5)) ? ((2.0 - 2.0 * Lightness) * Saturation) : (2.0 * Lightness * Saturation));
		double num3 = Lightness - 0.5 * num2;
		num -= 360.0 * Math.Floor(num / 360.0);
		num /= 60.0;
		double num4 = num2 * (1.0 - Math.Abs(num - 2.0 * Math.Floor(num / 2.0) - 1.0));
		switch ((int)Math.Floor(num))
		{
		default:
			base.Color.R = Quantum.ScaleToQuantum(num3 + num2);
			base.Color.G = Quantum.ScaleToQuantum(num3 + num4);
			base.Color.B = Quantum.ScaleToQuantum(num3);
			break;
		case 1:
			base.Color.R = Quantum.ScaleToQuantum(num3 + num4);
			base.Color.G = Quantum.ScaleToQuantum(num3 + num2);
			base.Color.B = Quantum.ScaleToQuantum(num3);
			break;
		case 2:
			base.Color.R = Quantum.ScaleToQuantum(num3);
			base.Color.G = Quantum.ScaleToQuantum(num3 + num2);
			base.Color.B = Quantum.ScaleToQuantum(num3 + num4);
			break;
		case 3:
			base.Color.R = Quantum.ScaleToQuantum(num3);
			base.Color.G = Quantum.ScaleToQuantum(num3 + num4);
			base.Color.B = Quantum.ScaleToQuantum(num3 + num2);
			break;
		case 4:
			base.Color.R = Quantum.ScaleToQuantum(num3 + num4);
			base.Color.G = Quantum.ScaleToQuantum(num3);
			base.Color.B = Quantum.ScaleToQuantum(num3 + num2);
			break;
		case 5:
			base.Color.R = Quantum.ScaleToQuantum(num3 + num2);
			base.Color.G = Quantum.ScaleToQuantum(num3);
			base.Color.B = Quantum.ScaleToQuantum(num3 + num4);
			break;
		}
	}

	private void Initialize(double red, double green, double blue)
	{
		double num = 1.0 / (double)(int)Quantum.Max;
		double num2 = Math.Max(red, Math.Max(green, blue)) * num;
		double num3 = Math.Min(red, Math.Max(green, blue)) * num;
		double num4 = num2 - num3;
		Lightness = (num2 + num3) / 2.0;
		if (num4 <= 0.0)
		{
			Hue = 0.0;
			Saturation = 0.0;
			return;
		}
		if (Math.Abs(num2 - num * red) < double.Epsilon)
		{
			Hue = (num * green - num * blue) / num4;
			if (num * green < num * blue)
			{
				Hue += 6.0;
			}
		}
		else if (Math.Abs(num2 - num * green) < double.Epsilon)
		{
			Hue = 2.0 + (num * blue - num * red) / num4;
		}
		else
		{
			Hue = 4.0 + (num * red - num * green) / num4;
		}
		Hue *= 1.0 / 6.0;
		if (Lightness <= 0.5)
		{
			Saturation = num4 / (2.0 * Lightness);
		}
		else
		{
			Saturation = num4 / (2.0 - 2.0 * Lightness);
		}
	}
}
