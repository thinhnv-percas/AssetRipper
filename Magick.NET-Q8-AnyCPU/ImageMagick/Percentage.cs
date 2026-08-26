using System;
using System.Globalization;

namespace ImageMagick;

public struct Percentage : IEquatable<Percentage>, IComparable<Percentage>
{
	private readonly double _value;

	public Percentage(double value)
	{
		_value = value;
	}

	public Percentage(int value)
	{
		_value = value;
	}

	public static explicit operator Percentage(double value)
	{
		return new Percentage(value);
	}

	public static explicit operator Percentage(int value)
	{
		return new Percentage(value);
	}

	public static explicit operator double(Percentage percentage)
	{
		return percentage.ToDouble();
	}

	public static explicit operator int(Percentage percentage)
	{
		return percentage.ToInt32();
	}

	public static bool operator ==(Percentage left, Percentage right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Percentage left, Percentage right)
	{
		return !object.Equals(left, right);
	}

	public static bool operator >(Percentage left, Percentage right)
	{
		if ((object)left == null)
		{
			return (object)right == null;
		}
		return left.CompareTo(right) == 1;
	}

	public static bool operator <(Percentage left, Percentage right)
	{
		if ((object)left == null)
		{
			return (object)right != null;
		}
		return left.CompareTo(right) == -1;
	}

	public static bool operator >=(Percentage left, Percentage right)
	{
		if ((object)left == null)
		{
			return (object)right == null;
		}
		return left.CompareTo(right) >= 0;
	}

	public static bool operator <=(Percentage left, Percentage right)
	{
		if ((object)left == null)
		{
			return (object)right != null;
		}
		return left.CompareTo(right) <= 0;
	}

	public static double operator *(double value, Percentage percentage)
	{
		return percentage.Multiply(value);
	}

	public static int operator *(int value, Percentage percentage)
	{
		return percentage.Multiply(value);
	}

	public int CompareTo(Percentage other)
	{
		return _value.CompareTo(other._value);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj.GetType() == typeof(Percentage))
		{
			return Equals((Percentage)obj);
		}
		if (obj.GetType() == typeof(double))
		{
			return _value.Equals(obj);
		}
		if (obj.GetType() == typeof(int))
		{
			return ((int)_value).Equals((int)obj);
		}
		return false;
	}

	public bool Equals(Percentage other)
	{
		return _value.Equals(other._value);
	}

	public override int GetHashCode()
	{
		return _value.GetHashCode();
	}

	public double Multiply(double value)
	{
		return value * _value / 100.0;
	}

	public int Multiply(int value)
	{
		return (int)((double)value * _value / 100.0);
	}

	public double ToDouble()
	{
		return _value;
	}

	public int ToInt32()
	{
		return (int)Math.Round(_value, MidpointRounding.AwayFromZero);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "{0:0.##}%", new object[1] { _value });
	}

	internal static Percentage FromQuantum(double value)
	{
		return new Percentage(value / (double)(int)Quantum.Max * 100.0);
	}

	internal double ToQuantum()
	{
		return (double)(int)Quantum.Max * (_value / 100.0);
	}

	internal byte ToQuantumType()
	{
		return (byte)((double)(int)Quantum.Max * (_value / 100.0));
	}
}
