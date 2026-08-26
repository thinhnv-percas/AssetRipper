using System;
using System.Globalization;

namespace ImageMagick;

public struct Rational : IEquatable<Rational>
{
	[CLSCompliant(false)]
	public uint Numerator { get; private set; }

	[CLSCompliant(false)]
	public uint Denominator { get; private set; }

	public Rational(double value)
		: this(value, bestPrecision: false)
	{
	}

	public Rational(double value, bool bestPrecision)
	{
		BigRational bigRational = new BigRational(Math.Abs(value), bestPrecision);
		Numerator = (uint)bigRational.Numerator;
		Denominator = (uint)bigRational.Denominator;
	}

	[CLSCompliant(false)]
	public Rational(uint value)
		: this(value, 1u)
	{
	}

	[CLSCompliant(false)]
	public Rational(uint numerator, uint denominator)
		: this(numerator, denominator, simplify: true)
	{
	}

	[CLSCompliant(false)]
	public Rational(uint numerator, uint denominator, bool simplify)
	{
		BigRational bigRational = new BigRational(numerator, denominator, simplify);
		Numerator = (uint)bigRational.Numerator;
		Denominator = (uint)bigRational.Denominator;
	}

	public static bool operator ==(Rational left, Rational right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Rational left, Rational right)
	{
		return !object.Equals(left, right);
	}

	public static Rational FromDouble(double value)
	{
		return new Rational(value, bestPrecision: false);
	}

	public static Rational FromDouble(double value, bool bestPrecision)
	{
		return new Rational(value, bestPrecision);
	}

	public override bool Equals(object obj)
	{
		if (obj is Rational)
		{
			return Equals((Rational)obj);
		}
		return false;
	}

	public bool Equals(Rational other)
	{
		BigRational bigRational = new BigRational(Numerator, Denominator);
		BigRational other2 = new BigRational(other.Numerator, other.Denominator);
		return bigRational.Equals(other2);
	}

	public override int GetHashCode()
	{
		return new BigRational(Numerator, Denominator).GetHashCode();
	}

	public double ToDouble()
	{
		return (double)Numerator / (double)Denominator;
	}

	public override string ToString()
	{
		return ToString(CultureInfo.InvariantCulture);
	}

	public string ToString(IFormatProvider provider)
	{
		return new BigRational(Numerator, Denominator).ToString(provider);
	}
}
