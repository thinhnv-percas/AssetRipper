using System;
using System.Globalization;

namespace ImageMagick;

public struct PointD : IEquatable<PointD>
{
	private double _x;

	private double _y;

	public double X => _x;

	public double Y => _y;

	public PointD(double xy)
	{
		_x = xy;
		_y = xy;
	}

	public PointD(double x, double y)
	{
		_x = x;
		_y = y;
	}

	public PointD(string value)
	{
		this = default(PointD);
		Throw.IfNullOrEmpty("value", value);
		Initialize(value);
	}

	public static bool operator ==(PointD left, PointD right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(PointD left, PointD right)
	{
		return !object.Equals(left, right);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj.GetType() != typeof(PointD))
		{
			return false;
		}
		return Equals((PointD)obj);
	}

	public bool Equals(PointD other)
	{
		if (X == other.X)
		{
			return Y == other.Y;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return X.GetHashCode() ^ Y.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "{0}x{1}", new object[2] { _x, _y });
	}

	internal static PointD FromPointInfo(PointInfo point)
	{
		if (point == null)
		{
			return default(PointD);
		}
		return new PointD(point.X, point.Y);
	}

	private void Initialize(string value)
	{
		string[] array = value.Split('x');
		Throw.IfTrue("value", array.Length > 2, "Invalid point specified.");
		Throw.IfFalse("value", double.TryParse(array[0], NumberStyles.Number, CultureInfo.InvariantCulture, out var result), "Invalid point specified.");
		double result2;
		if (array.Length == 2)
		{
			Throw.IfFalse("value", double.TryParse(array[1], NumberStyles.Number, CultureInfo.InvariantCulture, out result2), "Invalid point specified.");
		}
		else
		{
			result2 = result;
		}
		_x = result;
		_y = result2;
	}
}
