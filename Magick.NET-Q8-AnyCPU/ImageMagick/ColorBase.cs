using System;

namespace ImageMagick;

public abstract class ColorBase : IEquatable<ColorBase>, IComparable<ColorBase>
{
	protected MagickColor Color { get; private set; }

	protected ColorBase(MagickColor color)
	{
		Color = color;
	}

	public static implicit operator MagickColor(ColorBase color)
	{
		if (color == null)
		{
			return null;
		}
		return color.ToMagickColor();
	}

	public static bool operator ==(ColorBase left, ColorBase right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(ColorBase left, ColorBase right)
	{
		return !object.Equals(left, right);
	}

	public static bool operator >(ColorBase left, ColorBase right)
	{
		if ((object)left == null)
		{
			return (object)right == null;
		}
		return left.CompareTo(right) == 1;
	}

	public static bool operator <(ColorBase left, ColorBase right)
	{
		if ((object)left == null)
		{
			return (object)right != null;
		}
		return left.CompareTo(right) == -1;
	}

	public static bool operator >=(ColorBase left, ColorBase right)
	{
		if ((object)left == null)
		{
			return (object)right == null;
		}
		return left.CompareTo(right) >= 0;
	}

	public static bool operator <=(ColorBase left, ColorBase right)
	{
		if ((object)left == null)
		{
			return (object)right != null;
		}
		return left.CompareTo(right) <= 0;
	}

	public int CompareTo(ColorBase other)
	{
		if ((object)other == null)
		{
			return 1;
		}
		UpdateColor();
		other.UpdateColor();
		return Color.CompareTo(other.Color);
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as ColorBase);
	}

	public bool Equals(ColorBase other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		UpdateColor();
		other.UpdateColor();
		return Color.Equals(other.Color);
	}

	public bool FuzzyEquals(ColorBase other, Percentage fuzz)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		UpdateColor();
		other.UpdateColor();
		return Color.FuzzyEquals(other.Color, fuzz);
	}

	public override int GetHashCode()
	{
		UpdateColor();
		return Color.GetHashCode();
	}

	public MagickColor ToMagickColor()
	{
		UpdateColor();
		return new MagickColor(Color);
	}

	public override string ToString()
	{
		return ToMagickColor().ToString();
	}

	protected virtual void UpdateColor()
	{
	}
}
