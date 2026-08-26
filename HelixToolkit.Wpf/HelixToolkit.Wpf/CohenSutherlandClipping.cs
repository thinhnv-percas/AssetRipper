namespace HelixToolkit.Wpf;

public class CohenSutherlandClipping
{
	private const int BOTTOM = 4;

	private const int INSIDE = 0;

	private const int LEFT = 1;

	private const int RIGHT = 2;

	private const int TOP = 8;

	private readonly double xmax;

	private readonly double xmin;

	private readonly double ymax;

	private readonly double ymin;

	public CohenSutherlandClipping(double xmin, double xmax, double ymin, double ymax)
	{
		this.xmin = xmin;
		this.ymin = ymin;
		this.xmax = xmax;
		this.ymax = ymax;
	}

	public bool ClipLine(ref double x0, ref double y0, ref double x1, ref double y1)
	{
		int num = ComputeOutCode(x0, y0);
		int num2 = ComputeOutCode(x1, y1);
		bool result = false;
		while (true)
		{
			if ((num | num2) == 0)
			{
				result = true;
				break;
			}
			if ((num & num2) != 0)
			{
				break;
			}
			double num3 = 0.0;
			double num4 = 0.0;
			int num5 = ((num != 0) ? num : num2);
			if ((num5 & 8) != 0)
			{
				num3 = x0 + (x1 - x0) * (ymax - y0) / (y1 - y0);
				num4 = ymax;
			}
			else if ((num5 & 4) != 0)
			{
				num3 = x0 + (x1 - x0) * (ymin - y0) / (y1 - y0);
				num4 = ymin;
			}
			else if ((num5 & 2) != 0)
			{
				num4 = y0 + (y1 - y0) * (xmax - x0) / (x1 - x0);
				num3 = xmax;
			}
			else if ((num5 & 1) != 0)
			{
				num4 = y0 + (y1 - y0) * (xmin - x0) / (x1 - x0);
				num3 = xmin;
			}
			if (num5 == num)
			{
				x0 = num3;
				y0 = num4;
				num = ComputeOutCode(x0, y0);
			}
			else
			{
				x1 = num3;
				y1 = num4;
				num2 = ComputeOutCode(x1, y1);
			}
		}
		return result;
	}

	public bool IsInside(double x, double y)
	{
		return ComputeOutCode(x, y) == 0;
	}

	private int ComputeOutCode(double x, double y)
	{
		int num = 0;
		if (x < xmin)
		{
			num |= 1;
		}
		else if (x > xmax)
		{
			num |= 2;
		}
		if (y < ymin)
		{
			num |= 4;
		}
		else if (y > ymax)
		{
			num |= 8;
		}
		return num;
	}
}
