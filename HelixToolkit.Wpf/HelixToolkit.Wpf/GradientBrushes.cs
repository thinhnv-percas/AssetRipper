using System.Windows.Media;

namespace HelixToolkit.Wpf;

public static class GradientBrushes
{
	public static LinearGradientBrush BlueWhiteRed = BrushHelper.CreateGradientBrush(Colors.Blue, Colors.White, Colors.Red);

	public static LinearGradientBrush Hue = BrushHelper.CreateHsvBrush();

	public static LinearGradientBrush HueStripes = BrushHelper.CreateSteppedGradientBrush(Hue, 12);

	public static LinearGradientBrush Rainbow = BrushHelper.CreateRainbowBrush();

	public static LinearGradientBrush RainbowStripes = BrushHelper.CreateSteppedGradientBrush(Rainbow, 12);
}
