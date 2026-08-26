using System;
using System.Globalization;

namespace ImageMagick;

public sealed class Density : IEquatable<Density>
{
	public DensityUnit Units { get; private set; }

	public double X { get; private set; }

	public double Y { get; private set; }

	public Density(double xy)
		: this(xy, xy)
	{
	}

	public Density(double xy, DensityUnit units)
		: this(xy, xy, units)
	{
	}

	public Density(double x, double y)
		: this(x, y, DensityUnit.PixelsPerInch)
	{
	}

	public Density(double x, double y, DensityUnit units)
	{
		X = x;
		Y = y;
		Units = units;
	}

	public Density(string value)
	{
		Initialize(value);
	}

	public static bool operator ==(Density left, Density right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Density left, Density right)
	{
		return !object.Equals(left, right);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj.GetType() != typeof(Density))
		{
			return false;
		}
		return Equals((Density)obj);
	}

	public bool Equals(Density other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (X == other.X && Y == other.Y)
		{
			return Units == other.Units;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return X.GetHashCode() ^ Y.GetHashCode() ^ Units.GetHashCode();
	}

	public MagickGeometry ToGeometry(double width, double height)
	{
		int width2 = (int)(width * X);
		int height2 = (int)(height * Y);
		return new MagickGeometry(width2, height2);
	}

	public override string ToString()
	{
		return ToString(Units);
	}

	public string ToString(DensityUnit units)
	{
		string text = string.Format(CultureInfo.InvariantCulture, "{0}x{1}", new object[2] { X, Y });
		return units switch
		{
			DensityUnit.PixelsPerCentimeter => text + " cm", 
			DensityUnit.PixelsPerInch => text + " inch", 
			_ => text, 
		};
	}

	internal static Density Create(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return null;
		}
		return new Density(value);
	}

	internal static Density Clone(Density value)
	{
		if (value == null)
		{
			return null;
		}
		return new Density(value.X, value.Y, value.Units);
	}

	private void Initialize(string value)
	{
		Throw.IfNullOrEmpty("value", value);
		string[] array = value.Split(' ');
		Throw.IfTrue("value", array.Length > 2, "Invalid density specified.");
		if (array.Length == 2)
		{
			if (array[1].Equals("cm", StringComparison.OrdinalIgnoreCase))
			{
				Units = DensityUnit.PixelsPerCentimeter;
			}
			else
			{
				if (!array[1].Equals("inch", StringComparison.OrdinalIgnoreCase))
				{
					throw new ArgumentException("Invalid density specified.", "value");
				}
				Units = DensityUnit.PixelsPerInch;
			}
		}
		string[] array2 = array[0].Split('x');
		Throw.IfTrue("value", array2.Length > 2, "Invalid density specified.");
		Throw.IfFalse("value", double.TryParse(array2[0], NumberStyles.Number, CultureInfo.InvariantCulture, out var result), "Invalid density specified.");
		double result2;
		if (array2.Length == 1)
		{
			result2 = result;
		}
		else
		{
			Throw.IfFalse("value", double.TryParse(array2[1], NumberStyles.Number, CultureInfo.InvariantCulture, out result2), "Invalid density specified.");
		}
		X = result;
		Y = result2;
	}
}
