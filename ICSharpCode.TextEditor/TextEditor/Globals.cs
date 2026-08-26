using System.Drawing;

namespace TextEditor;

public static class Globals
{
	public static int InRange(this int x, int lo, int hi)
	{
		if (x >= lo)
		{
			if (x <= hi)
			{
				return x;
			}
			return hi;
		}
		return lo;
	}

	public static bool IsInRange(this int x, int lo, int hi)
	{
		if (x >= lo)
		{
			return x <= hi;
		}
		return false;
	}

	public static Color HalfMix(this Color one, Color two)
	{
		return Color.FromArgb(one.A + two.A >> 1, one.R + two.R >> 1, one.G + two.G >> 1, one.B + two.B >> 1);
	}
}
