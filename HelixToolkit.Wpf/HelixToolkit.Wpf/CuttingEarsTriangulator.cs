using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace HelixToolkit.Wpf;

public static class CuttingEarsTriangulator
{
	private const double Epsilon = 1E-10;

	public static Int32Collection Triangulate(IList<Point> contour)
	{
		Int32Collection int32Collection = new Int32Collection();
		int count = contour.Count;
		if (count < 3)
		{
			return null;
		}
		int[] array = new int[count];
		if (Area(contour) > 0.0)
		{
			for (int i = 0; i < count; i++)
			{
				array[i] = i;
			}
		}
		else
		{
			for (int j = 0; j < count; j++)
			{
				array[j] = count - 1 - j;
			}
		}
		int num = count;
		int num2 = 2 * num;
		int num3 = num - 1;
		while (num > 2)
		{
			if (0 >= num2--)
			{
				return null;
			}
			int num4 = num3;
			if (num <= num4)
			{
				num4 = 0;
			}
			num3 = num4 + 1;
			if (num <= num3)
			{
				num3 = 0;
			}
			int num5 = num3 + 1;
			if (num <= num5)
			{
				num5 = 0;
			}
			if (Snip(contour, num4, num3, num5, num, array))
			{
				int value = array[num4];
				int value2 = array[num3];
				int value3 = array[num5];
				int32Collection.Add(value);
				int32Collection.Add(value2);
				int32Collection.Add(value3);
				int num6 = num3;
				for (int k = num3 + 1; k < num; k++)
				{
					array[num6] = array[k];
					num6++;
				}
				num--;
				num2 = 2 * num;
			}
		}
		return int32Collection;
	}

	private static double Area(IList<Point> contour)
	{
		int count = contour.Count;
		double num = 0.0;
		int index = count - 1;
		int num2 = 0;
		while (num2 < count)
		{
			num += contour[index].X * contour[num2].Y - contour[num2].X * contour[index].Y;
			index = num2++;
		}
		return num * 0.5;
	}

	private static bool InsideTriangle(double Ax, double Ay, double Bx, double By, double Cx, double Cy, double Px, double Py)
	{
		double num = Cx - Bx;
		double num2 = Cy - By;
		double num3 = Ax - Cx;
		double num4 = Ay - Cy;
		double num5 = Bx - Ax;
		double num6 = By - Ay;
		double num7 = Px - Ax;
		double num8 = Py - Ay;
		double num9 = Px - Bx;
		double num10 = Py - By;
		double num11 = Px - Cx;
		double num12 = Py - Cy;
		double num13 = num * num10 - num2 * num9;
		double num14 = num5 * num8 - num6 * num7;
		double num15 = num3 * num12 - num4 * num11;
		return num13 > -1E-10 && num15 > -1E-10 && num14 > -1E-10;
	}

	private static bool Snip(IList<Point> contour, int u, int v, int w, int n, int[] V)
	{
		double x = contour[V[u]].X;
		double y = contour[V[u]].Y;
		double x2 = contour[V[v]].X;
		double y2 = contour[V[v]].Y;
		double x3 = contour[V[w]].X;
		double y3 = contour[V[w]].Y;
		if (1E-10 > (x2 - x) * (y3 - y) - (y2 - y) * (x3 - x))
		{
			return false;
		}
		for (int i = 0; i < n; i++)
		{
			if (i != u && i != v && i != w)
			{
				double x4 = contour[V[i]].X;
				double y4 = contour[V[i]].Y;
				if (InsideTriangle(x, y, x2, y2, x3, y3, x4, y4))
				{
					return false;
				}
			}
		}
		return true;
	}
}
