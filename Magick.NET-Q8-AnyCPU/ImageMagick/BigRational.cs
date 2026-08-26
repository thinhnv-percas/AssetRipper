using System;
using System.Text;

namespace ImageMagick;

internal struct BigRational : IEquatable<BigRational>
{
	public long Denominator { get; private set; }

	public long Numerator { get; private set; }

	private bool IsIndeterminate
	{
		get
		{
			if (Denominator != 0L)
			{
				return false;
			}
			return Numerator == 0;
		}
	}

	private bool IsInteger => Denominator == 1;

	private bool IsNegativeInfinity
	{
		get
		{
			if (Denominator != 0L)
			{
				return false;
			}
			return Numerator == -1;
		}
	}

	private bool IsPositiveInfinity
	{
		get
		{
			if (Denominator != 0L)
			{
				return false;
			}
			return Numerator == 1;
		}
	}

	private bool IsZero
	{
		get
		{
			if (Denominator != 1)
			{
				return false;
			}
			return Numerator == 0;
		}
	}

	public BigRational(long numerator, long denominator)
		: this(numerator, denominator, simplify: false)
	{
	}

	public BigRational(long numerator, long denominator, bool simplify)
	{
		Numerator = numerator;
		Denominator = denominator;
		if (simplify)
		{
			Simplify();
		}
	}

	public BigRational(double value, bool bestPrecision)
	{
		if (double.IsNaN(value))
		{
			long numerator = (Denominator = 0L);
			Numerator = numerator;
			return;
		}
		if (double.IsPositiveInfinity(value))
		{
			Numerator = 1L;
			Denominator = 0L;
			return;
		}
		if (double.IsNegativeInfinity(value))
		{
			Numerator = -1L;
			Denominator = 0L;
			return;
		}
		Numerator = 1L;
		Denominator = 1L;
		double num2 = Math.Abs(value);
		double num3 = (double)Numerator / (double)Denominator;
		double num4 = (bestPrecision ? double.Epsilon : 1E-06);
		while (Math.Abs(num3 - num2) > num4)
		{
			if (num3 < num2)
			{
				Numerator++;
			}
			else
			{
				Denominator++;
				Numerator = (int)(num2 * (double)Denominator);
			}
			num3 = (double)Numerator / (double)Denominator;
		}
		if (value < 0.0)
		{
			Numerator *= -1L;
		}
		Simplify();
	}

	public bool Equals(BigRational other)
	{
		if (Denominator == other.Denominator)
		{
			return Numerator == other.Numerator;
		}
		if (Numerator == 0L && Denominator == 0L)
		{
			if (other.Numerator == 0L)
			{
				return other.Denominator == 0;
			}
			return false;
		}
		if (other.Numerator == 0L && other.Denominator == 0L)
		{
			if (Numerator == 0L)
			{
				return Denominator == 0;
			}
			return false;
		}
		return Numerator * other.Denominator == Denominator * other.Numerator;
	}

	public override int GetHashCode()
	{
		return ((Numerator * 397) ^ Denominator).GetHashCode();
	}

	public string ToString(IFormatProvider provider)
	{
		if (IsIndeterminate)
		{
			return "Indeterminate";
		}
		if (IsPositiveInfinity)
		{
			return "PositiveInfinity";
		}
		if (IsNegativeInfinity)
		{
			return "NegativeInfinity";
		}
		if (IsZero)
		{
			return "0";
		}
		if (IsInteger)
		{
			return Numerator.ToString(provider);
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(Numerator.ToString(provider));
		stringBuilder.Append("/");
		stringBuilder.Append(Denominator.ToString(provider));
		return stringBuilder.ToString();
	}

	private static long GreatestCommonDivisor(long a, long b)
	{
		if (b != 0L)
		{
			return GreatestCommonDivisor(b, a % b);
		}
		return a;
	}

	private void Simplify()
	{
		if (IsIndeterminate || IsNegativeInfinity || IsPositiveInfinity || IsInteger || IsZero)
		{
			return;
		}
		if (Numerator == 0L)
		{
			Denominator = 0L;
			return;
		}
		if (Numerator == Denominator)
		{
			Numerator = 1L;
			Denominator = 1L;
		}
		long num = GreatestCommonDivisor(Math.Abs(Numerator), Math.Abs(Denominator));
		if (num > 1)
		{
			Numerator /= num;
			Denominator /= num;
		}
	}
}
