using System;

namespace XnaGeometry
{
	public static class MathHelper
	{
		public const double E = Math.E;

		public const double Log10E = 0.43429449200630188;

		public const double Log2E = 1.4426950216293335;

		public const double Pi = Math.PI;

		public const double PiOver2 = Math.PI / 2.0;

		public const double PiOver4 = Math.PI / 4.0;

		public const double TwoPi = Math.PI * 2.0;

		public static double Barycentric(double value1, double value2, double value3, double amount1, double amount2)
		{
			return value1 + (value2 - value1) * amount1 + (value3 - value1) * amount2;
		}

		public static double CatmullRom(double value1, double value2, double value3, double value4, double amount)
		{
			double num = amount * amount;
			double num2 = num * amount;
			return 0.5 * (2.0 * value2 + (value3 - value1) * amount + (2.0 * value1 - 5.0 * value2 + 4.0 * value3 - value4) * num + (3.0 * value2 - value1 - 3.0 * value3 + value4) * num2);
		}

		public static double Clamp(double value, double min, double max)
		{
			value = ((value > max) ? max : value);
			value = ((value < min) ? min : value);
			return value;
		}

		public static double Distance(double value1, double value2)
		{
			return Math.Abs(value1 - value2);
		}

		public static double Hermite(double value1, double tangent1, double value2, double tangent2, double amount)
		{
			double num = amount * amount * amount;
			double num2 = amount * amount;
			double num3 = (amount == 0.0) ? value1 : ((amount != 1.0) ? ((2.0 * value1 - 2.0 * value2 + tangent2 + tangent1) * num + (3.0 * value2 - 3.0 * value1 - 2.0 * tangent1 - tangent2) * num2 + tangent1 * amount + value1) : value2);
			return num3;
		}

		public static double Lerp(double value1, double value2, double amount)
		{
			return value1 + (value2 - value1) * amount;
		}

		public static double Max(double value1, double value2)
		{
			return Math.Max(value1, value2);
		}

		public static double Min(double value1, double value2)
		{
			return Math.Min(value1, value2);
		}

		public static double SmoothStep(double value1, double value2, double amount)
		{
			double amount2 = Clamp(amount, 0.0, 1.0);
			return Hermite(value1, 0.0, value2, 0.0, amount2);
		}

		public static double ToDegrees(double radians)
		{
			return radians * (180.0 / Math.PI);
		}

		public static double ToRadians(double degrees)
		{
			return degrees * (Math.PI / 180.0);
		}

		public static double WrapAngle(double angle)
		{
			angle = Math.IEEERemainder(angle, 6.2831854820251465);
			if (angle <= -3.1415927410125732)
			{
				angle += 6.2831854820251465;
			}
			else if (angle > 3.1415927410125732)
			{
				angle -= 6.2831854820251465;
			}
			return angle;
		}

		public static bool IsPowerOfTwo(int value)
		{
			if (value > 0)
			{
				return (value & (value - 1)) == 0;
			}
			return false;
		}
	}
}
