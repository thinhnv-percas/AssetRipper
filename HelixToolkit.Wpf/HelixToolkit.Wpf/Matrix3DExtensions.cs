using System;
using System.Globalization;
using System.Text;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public static class Matrix3DExtensions
{
	public static Matrix3D Inverse(this Matrix3D m)
	{
		m.Invert();
		return m;
	}

	public static double[,] ToArray(this Matrix3D matrix)
	{
		return new double[4, 4]
		{
			{ matrix.M11, matrix.M12, matrix.M13, matrix.M14 },
			{ matrix.M21, matrix.M22, matrix.M23, matrix.M24 },
			{ matrix.M31, matrix.M32, matrix.M33, matrix.M34 },
			{ matrix.OffsetX, matrix.OffsetY, matrix.OffsetZ, matrix.M44 }
		};
	}

	public static string ToString(this Matrix3D matrix, int columnWidth)
	{
		return matrix.ConvertToString("N" + columnWidth, 20);
	}

	public static string ToString(this Matrix3D matrix, string format, int columnWidth)
	{
		if (format == null)
		{
			throw new ArgumentNullException("format");
		}
		return matrix.ConvertToString(format, "\t", "\n", columnWidth, CultureInfo.InvariantCulture);
	}

	public static string ToString(this Matrix3D matrix, string format, string columnSeparator, string lineSeparator, int columnWidth, CultureInfo provider)
	{
		return matrix.ConvertToString(format, columnSeparator, lineSeparator, columnWidth, provider);
	}

	internal static string ConvertToString(this Matrix3D matrix, string format, int columnWidth)
	{
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		return matrix.ConvertToString(format, "\t", "\n", columnWidth, invariantCulture);
	}

	internal static string ConvertToString(this Matrix3D matrix, string format, string columnSeparator, string lineSeparator, int columnWidth, CultureInfo provider)
	{
		string format2 = "{0:" + format + "}";
		double[,] array = matrix.ToArray();
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.GetLength(0); i++)
		{
			for (int j = 0; j < array.GetLength(1); j++)
			{
				string value = string.Format(provider, format2, new object[1] { array[i, j] }).PadLeft(columnWidth);
				stringBuilder.Append(value);
				if (j < 3)
				{
					stringBuilder.Append(columnSeparator);
				}
			}
			if (i < 3)
			{
				stringBuilder.Append(lineSeparator);
			}
		}
		return stringBuilder.ToString();
	}
}
