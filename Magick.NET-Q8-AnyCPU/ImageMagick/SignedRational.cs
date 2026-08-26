using System;
using System.Globalization;

namespace ImageMagick;

public struct SignedRational : IEquatable<SignedRational>
{
	public int Numerator { get; private set; }

	public int Denominator { get; private set; }

	public SignedRational(double value)
		: this(value, bestPrecision: false)
	{
	}

	public SignedRational(double value, bool bestPrecision)
	{
		BigRational bigRational = new BigRational(value, bestPrecision);
		Numerator = (int)bigRational.Numerator;
		Denominator = (int)bigRational.Denominator;
	}

	public SignedRational(int value)
		: this(value, 1)
	{
	}

	public SignedRational(int numerator, int denominator)
		: this(numerator, denominator, simplify: true)
	{
	}

	public SignedRational(int numerator, int denominator, bool simplify)
	{
		BigRational bigRational = new BigRational(numerator, denominator, simplify);
		Numerator = (int)bigRational.Numerator;
		Denominator = (int)bigRational.Denominator;
	}

	public static bool operator ==(SignedRational left, SignedRational right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(SignedRational left, SignedRational right)
	{
		return !object.Equals(left, right);
	}

	public static SignedRational FromDouble(double value)
	{
		return new SignedRational(value, bestPrecision: false);
	}

	public static SignedRational FromDouble(double value, bool bestPrecision)
	{
		return new SignedRational(value, bestPrecision);
	}

	public override bool Equals(object obj)
	{
		if (obj is SignedRational)
		{
			return Equals((SignedRational)obj);
		}
		return false;
	}

	public bool Equals(SignedRational other)
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
