using System;
using System.Windows;

namespace WFTools3D
{
	public static class MathUtils
	{
		public static readonly double PI = Math.PI;

		public static readonly double PIx2 = PI * 2.0;

		public static readonly double PIo2 = PI * 0.5;

		public static double NormalizeAngle(double angle)
		{
			if (angle < 0.0 - PI || angle > PI)
			{
				angle = Math.IEEERemainder(angle, PIx2);
				if (angle < 0.0 - PI)
				{
					angle += PIx2;
				}
				else if (angle > PI)
				{
					angle -= PIx2;
				}
			}
			return angle;
		}

		public static double ToRadians(double angleInDegrees)
		{
			return angleInDegrees * PI / 180.0;
		}

		public static double ToDegrees(double angleInRadians)
		{
			return angleInRadians * 180.0 / PI;
		}

		public static double ToSeconds(int d, int h, int m, double s)
		{
			return (double)(((d * 24 + h) * 60 + m) * 60) + s;
		}

		public static bool IsValidIndex(int index, int count)
		{
			if (index < 0 || index >= count)
			{
				return false;
			}
			return true;
		}

		public static bool IsValidNumber(double value)
		{
			if (double.IsNaN(value) || double.IsInfinity(value))
			{
				return false;
			}
			return true;
		}

		public static double Clamp(double value, double minValue, double maxValue)
		{
			return Math.Min(Math.Max(value, minValue), maxValue);
		}

		public static bool IsValid(this Point pt)
		{
			if (!IsValidNumber(pt.X) || !IsValidNumber(pt.Y))
			{
				return false;
			}
			return true;
		}
	}
}
