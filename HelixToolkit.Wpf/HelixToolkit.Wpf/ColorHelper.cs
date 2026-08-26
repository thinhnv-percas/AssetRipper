using System;
using System.Globalization;
using System.Windows.Media;

namespace HelixToolkit.Wpf;

public static class ColorHelper
{
	public static Color UndefinedColor = Color.FromArgb(0, 0, 0, 0);

	public static Color ChangeAlpha(this Color c, byte alpha)
	{
		return Color.FromArgb(alpha, c.R, c.G, c.B);
	}

	public static Color ChangeIntensity(this Color c, double factor)
	{
		double[] array = ColorToHsv(c);
		array[2] *= factor;
		if (array[2] > 1.0)
		{
			array[2] = 1.0;
		}
		return HsvToColor(array);
	}

	public static double ColorDifference(Color c1, Color c2)
	{
		double num = (double)(c1.R - c2.R) / 255.0;
		double num2 = (double)(c1.G - c2.G) / 255.0;
		double num3 = (double)(c1.B - c2.B) / 255.0;
		double num4 = (double)(c1.A - c2.A) / 255.0;
		double d = num * num + num2 * num2 + num3 * num3 + num4 * num4;
		return Math.Sqrt(d);
	}

	public static string ColorToHex(Color color)
	{
		return $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
	}

	public static double[] ColorToHsv(Color color)
	{
		byte r = color.R;
		byte g = color.G;
		byte b = color.B;
		double num = 0.0;
		double num2 = (int)Math.Min(Math.Min(r, g), b);
		double num3 = (int)Math.Max(Math.Max(r, g), b);
		double num4 = num3 - num2;
		double num5 = ((num3 != 0.0) ? (num4 / num3) : 0.0);
		if (num5 == 0.0)
		{
			num = 0.0;
		}
		else
		{
			if ((double)(int)r == num3)
			{
				num = (double)(g - b) / num4;
			}
			else if ((double)(int)g == num3)
			{
				num = 2.0 + (double)(b - r) / num4;
			}
			else if ((double)(int)b == num3)
			{
				num = 4.0 + (double)(r - g) / num4;
			}
			num *= 60.0;
			if (num < 0.0)
			{
				num += 360.0;
			}
		}
		return new double[3]
		{
			num / 360.0,
			num5,
			num3 / 255.0
		};
	}

	public static byte[] ColorToHsvBytes(Color color)
	{
		double[] array = ColorToHsv(color);
		return new byte[3]
		{
			(byte)(array[0] * 255.0),
			(byte)(array[1] * 255.0),
			(byte)(array[2] * 255.0)
		};
	}

	public static uint ColorToUint(Color c)
	{
		uint num = (uint)(c.A << 24);
		num += (uint)(c.R << 16);
		num += (uint)(c.G << 8);
		return num + c.B;
	}

	public static Color Complementary(Color c)
	{
		double[] array = ColorToHsv(c);
		double num = array[0] - 0.5;
		if (num < 0.0)
		{
			num++;
		}
		return HsvToColor(num, array[1], array[2]);
	}

	public static Color HexToColor(string value)
	{
		value = value.Trim('#');
		if (value.Length == 0)
		{
			return UndefinedColor;
		}
		if (value.Length <= 6)
		{
			value = "FF" + value.PadLeft(6, '0');
		}
		if (uint.TryParse(value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
		{
			return UIntToColor(result);
		}
		return UndefinedColor;
	}

	public static Color HsvToColor(byte hue, byte saturation, byte value)
	{
		double num = (double)(int)hue * 360.0 / 255.0;
		double num2 = (double)(int)saturation / 255.0;
		double num3 = (double)(int)value / 255.0;
		double num4;
		double num5;
		double num6;
		if (num2 == 0.0)
		{
			num4 = num3;
			num5 = num3;
			num6 = num3;
		}
		else
		{
			num = ((num != 360.0) ? (num / 60.0) : 0.0);
			int num7 = (int)Math.Truncate(num);
			double num8 = num - (double)num7;
			double num9 = num3 * (1.0 - num2);
			double num10 = num3 * (1.0 - num2 * num8);
			double num11 = num3 * (1.0 - num2 * (1.0 - num8));
			switch (num7)
			{
			case 0:
				num4 = num3;
				num5 = num11;
				num6 = num9;
				break;
			case 1:
				num4 = num10;
				num5 = num3;
				num6 = num9;
				break;
			case 2:
				num4 = num9;
				num5 = num3;
				num6 = num11;
				break;
			case 3:
				num4 = num9;
				num5 = num10;
				num6 = num3;
				break;
			case 4:
				num4 = num11;
				num5 = num9;
				num6 = num3;
				break;
			default:
				num4 = num3;
				num5 = num9;
				num6 = num10;
				break;
			}
		}
		return Color.FromArgb(byte.MaxValue, (byte)(num4 * 255.0), (byte)(num5 * 255.0), (byte)(num6 * 255.0));
	}

	public static Color HsvToColor(double[] hsv)
	{
		if (hsv.Length != 3)
		{
			throw new InvalidOperationException("Wrong length of hsv array.");
		}
		return HsvToColor(hsv[0], hsv[1], hsv[2]);
	}

	public static Color HsvToColor(double hue, double sat, double val)
	{
		double num2;
		double num3;
		double num = (num2 = (num3 = 0.0));
		if (sat == 0.0)
		{
			num = (num2 = (num3 = val));
		}
		else
		{
			if (hue == 1.0)
			{
				hue = 0.0;
			}
			hue *= 6.0;
			int num4 = (int)Math.Floor(hue);
			double num5 = hue - (double)num4;
			double num6 = val * (1.0 - sat);
			double num7 = val * (1.0 - sat * num5);
			double num8 = val * (1.0 - sat * (1.0 - num5));
			switch (num4)
			{
			case 0:
				num = val;
				num2 = num8;
				num3 = num6;
				break;
			case 1:
				num = num7;
				num2 = val;
				num3 = num6;
				break;
			case 2:
				num = num6;
				num2 = val;
				num3 = num8;
				break;
			case 3:
				num = num6;
				num2 = num7;
				num3 = val;
				break;
			case 4:
				num = num8;
				num2 = num6;
				num3 = val;
				break;
			case 5:
				num = val;
				num2 = num6;
				num3 = num7;
				break;
			}
		}
		return Color.FromRgb((byte)(num * 255.0), (byte)(num2 * 255.0), (byte)(num3 * 255.0));
	}

	public static double HueDifference(Color c1, Color c2)
	{
		double[] array = ColorToHsv(c1);
		double[] array2 = ColorToHsv(c2);
		double num = array[0] - array2[0];
		if (num > 0.5)
		{
			num--;
		}
		if (num < -0.5)
		{
			num++;
		}
		double d = num * num;
		return Math.Sqrt(d);
	}

	public static Color Interpolate(Color c0, Color c1, double x)
	{
		double num = (double)(int)c0.R * (1.0 - x) + (double)(int)c1.R * x;
		double num2 = (double)(int)c0.G * (1.0 - x) + (double)(int)c1.G * x;
		double num3 = (double)(int)c0.B * (1.0 - x) + (double)(int)c1.B * x;
		double num4 = (double)(int)c0.A * (1.0 - x) + (double)(int)c1.A * x;
		return Color.FromArgb((byte)num4, (byte)num, (byte)num2, (byte)num3);
	}

	public static Color UIntToColor(uint color)
	{
		byte a = (byte)(color >> 24);
		byte r = (byte)(color >> 16);
		byte g = (byte)(color >> 8);
		byte b = (byte)color;
		return Color.FromArgb(a, r, g, b);
	}
}
