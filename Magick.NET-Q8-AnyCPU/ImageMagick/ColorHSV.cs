using System;

namespace ImageMagick;

public sealed class ColorHSV : ColorBase
{
	public double Hue { get; set; }

	public double Saturation { get; set; }

	public double Value { get; set; }

	public ColorHSV(double hue, double saturation, double value)
		: base(new MagickColor(0, 0, 0))
	{
		Hue = hue;
		Saturation = saturation;
		Value = value;
	}

	private ColorHSV(MagickColor color)
		: base(color)
	{
		Initialize((int)color.R, (int)color.G, (int)color.B);
	}

	public static implicit operator ColorHSV(MagickColor color)
	{
		return FromMagickColor(color);
	}

	public static ColorHSV FromMagickColor(MagickColor color)
	{
		if (color == null)
		{
			return null;
		}
		return new ColorHSV(color);
	}

	public void HueShift(double degrees)
	{
		Hue += degrees / 360.0;
		while (Hue >= 1.0)
		{
			Hue--;
		}
		while (Hue < 0.0)
		{
			Hue++;
		}
	}

	protected override void UpdateColor()
	{
		if (Math.Abs(Saturation) < double.Epsilon)
		{
			MagickColor color = base.Color;
			MagickColor color2 = base.Color;
			byte b = (base.Color.B = Quantum.ScaleToQuantum(Value));
			byte r = (color2.G = b);
			color.R = r;
			return;
		}
		double num = 6.0 * (Hue - Math.Floor(Hue));
		double num2 = num - Math.Floor(num);
		double value = Value * (1.0 - Saturation);
		double value2 = Value * (1.0 - Saturation * num2);
		double value3 = Value * (1.0 - Saturation * (1.0 - num2));
		switch ((int)num)
		{
		default:
			base.Color.R = Quantum.ScaleToQuantum(Value);
			base.Color.G = Quantum.ScaleToQuantum(value3);
			base.Color.B = Quantum.ScaleToQuantum(value);
			break;
		case 1:
			base.Color.R = Quantum.ScaleToQuantum(value2);
			base.Color.G = Quantum.ScaleToQuantum(Value);
			base.Color.B = Quantum.ScaleToQuantum(value);
			break;
		case 2:
			base.Color.R = Quantum.ScaleToQuantum(value);
			base.Color.G = Quantum.ScaleToQuantum(Value);
			base.Color.B = Quantum.ScaleToQuantum(value3);
			break;
		case 3:
			base.Color.R = Quantum.ScaleToQuantum(value);
			base.Color.G = Quantum.ScaleToQuantum(value2);
			base.Color.B = Quantum.ScaleToQuantum(Value);
			break;
		case 4:
			base.Color.R = Quantum.ScaleToQuantum(value3);
			base.Color.G = Quantum.ScaleToQuantum(value);
			base.Color.B = Quantum.ScaleToQuantum(Value);
			break;
		case 5:
			base.Color.R = Quantum.ScaleToQuantum(Value);
			base.Color.G = Quantum.ScaleToQuantum(value);
			base.Color.B = Quantum.ScaleToQuantum(value2);
			break;
		}
	}

	private void Initialize(double red, double green, double blue)
	{
		Hue = 0.0;
		Saturation = 0.0;
		Value = 0.0;
		double num = Math.Min(Math.Min(red, green), blue);
		double num2 = Math.Max(Math.Max(red, green), blue);
		if (Math.Abs(num2) < double.Epsilon)
		{
			return;
		}
		double num3 = num2 - num;
		Saturation = num3 / num2;
		Value = 1.0 / (double)(int)Quantum.Max * num2;
		if (!(Math.Abs(num3) < double.Epsilon))
		{
			if (Math.Abs(red - num2) < double.Epsilon)
			{
				Hue = (green - blue) / num3;
			}
			else if (Math.Abs(green - num2) < double.Epsilon)
			{
				Hue = 2.0 + (blue - red) / num3;
			}
			else
			{
				Hue = 4.0 + (red - green) / num3;
			}
			Hue /= 6.0;
			if (Hue < 0.0)
			{
				Hue++;
			}
		}
	}
}
