using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace HelixToolkit.Wpf;

public static class BrushHelper
{
	public static Brush ChangeOpacity(Brush brush, double opacity)
	{
		brush = brush.Clone();
		brush.Opacity = opacity;
		return brush;
	}

	public static LinearGradientBrush CreateGradientBrush(params Color[] colors)
	{
		return CreateGradientBrush(colors.ToList());
	}

	public static LinearGradientBrush CreateGradientBrush(IList<Color> colors, bool horizontal = true)
	{
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush
		{
			StartPoint = new Point(0.0, 0.0),
			EndPoint = (horizontal ? new Point(1.0, 0.0) : new Point(0.0, 1.0))
		};
		int count = colors.Count;
		for (int i = 0; i < count; i++)
		{
			GradientStop value = new GradientStop(colors[i], (double)i / (double)(count - 1));
			linearGradientBrush.GradientStops.Add(value);
		}
		return linearGradientBrush;
	}

	public static SolidColorBrush CreateGrayBrush(double intensity)
	{
		byte b = (byte)(255.0 * intensity);
		return new SolidColorBrush(Color.FromArgb(byte.MaxValue, b, b, b));
	}

	public static LinearGradientBrush CreateHsvBrush(double alpha = 1.0, bool horizontal = true)
	{
		byte a = (byte)(alpha * 255.0);
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush
		{
			StartPoint = new Point(0.0, 0.0),
			EndPoint = (horizontal ? new Point(1.0, 0.0) : new Point(0.0, 1.0))
		};
		linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(a, byte.MaxValue, 0, 0), 0.0));
		linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(a, byte.MaxValue, byte.MaxValue, 0), 0.17));
		linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(a, 0, byte.MaxValue, 0), 0.33));
		linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(a, 0, byte.MaxValue, byte.MaxValue), 0.5));
		linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(a, 0, 0, byte.MaxValue), 0.67));
		linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(a, byte.MaxValue, 0, byte.MaxValue), 0.84));
		linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(a, byte.MaxValue, 0, 0), 1.0));
		return linearGradientBrush;
	}

	public static LinearGradientBrush CreateRainbowBrush(bool horizontal = true)
	{
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush
		{
			StartPoint = new Point(0.0, 0.0),
			EndPoint = (horizontal ? new Point(1.0, 0.0) : new Point(0.0, 1.0))
		};
		linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.0));
		linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.17));
		linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.33));
		linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Green, 0.5));
		linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Blue, 0.67));
		linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Indigo, 0.84));
		linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Violet, 1.0));
		return linearGradientBrush;
	}

	public static LinearGradientBrush CreateSteppedGradientBrush(IList<Color> colors, bool horizontal = true)
	{
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush
		{
			StartPoint = new Point(0.0, 0.0),
			EndPoint = (horizontal ? new Point(1.0, 0.0) : new Point(0.0, 1.0))
		};
		int count = colors.Count;
		for (int i = 0; i < count; i++)
		{
			GradientStop value = new GradientStop(colors[i], (double)i / (double)count);
			GradientStop value2 = new GradientStop(colors[i], (double)(i + 1) / (double)count);
			linearGradientBrush.GradientStops.Add(value);
			linearGradientBrush.GradientStops.Add(value2);
		}
		return linearGradientBrush;
	}

	public static LinearGradientBrush CreateSteppedGradientBrush(LinearGradientBrush gradient)
	{
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush
		{
			StartPoint = gradient.StartPoint,
			EndPoint = gradient.EndPoint
		};
		for (int i = 0; i + 1 < gradient.GradientStops.Count; i++)
		{
			GradientStop gradientStop = gradient.GradientStops[i].Clone();
			GradientStop gradientStop2 = gradientStop.Clone();
			gradientStop2.Offset = gradient.GradientStops[i + 1].Offset;
			linearGradientBrush.GradientStops.Add(gradientStop);
			linearGradientBrush.GradientStops.Add(gradientStop2);
		}
		return linearGradientBrush;
	}

	public static LinearGradientBrush CreateSteppedGradientBrush(LinearGradientBrush gradient, int steps)
	{
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush
		{
			StartPoint = gradient.StartPoint,
			EndPoint = gradient.EndPoint
		};
		int count = gradient.GradientStops.Count;
		for (int i = 0; i < steps; i++)
		{
			double num = 1.0 * (double)i / (double)(steps - 1) * (double)(count - 1);
			int num2 = (int)num;
			double x = num - (double)num2;
			int num3 = num2 + 1;
			if (num3 >= count)
			{
				num3 = count - 1;
			}
			Color color = gradient.GradientStops[num2].Color;
			Color color2 = gradient.GradientStops[num3].Color;
			GradientStop gradientStop = new GradientStop();
			GradientStop gradientStop2 = new GradientStop();
			gradientStop.Color = ColorHelper.Interpolate(color, color2, x);
			gradientStop2.Color = gradientStop.Color;
			gradientStop.Offset = 1.0 * (double)i / (double)steps;
			gradientStop2.Offset = 1.0 * (double)(i + 1) / (double)steps;
			linearGradientBrush.GradientStops.Add(gradientStop);
			linearGradientBrush.GradientStops.Add(gradientStop2);
		}
		return linearGradientBrush;
	}

	public static LinearGradientBrush CreateSteppedHsvBrush(int nSteps)
	{
		List<Color> list = new List<Color>();
		for (int i = 0; i < nSteps; i++)
		{
			double hue = (double)i / (double)(nSteps - 1);
			list.Add(ColorHelper.HsvToColor(hue, 1.0, 1.0));
		}
		return CreateSteppedGradientBrush(list);
	}
}
