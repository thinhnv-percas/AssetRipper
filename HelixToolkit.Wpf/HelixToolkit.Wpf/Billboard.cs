using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class Billboard
{
	internal Point3D Position;

	internal double Left;

	internal double Right;

	internal double Top;

	internal double Bottom;

	internal double DepthOffset;

	internal double WorldDepthOffset;

	public Billboard(Point3D position, double size, double depthOffset, double worldDepthOffset = 0.0)
	{
		double num = size / 2.0;
		Position = position;
		Left = 0.0 - num;
		Right = num;
		Top = 0.0 - num;
		Bottom = num;
		DepthOffset = depthOffset;
		WorldDepthOffset = worldDepthOffset;
	}

	public Billboard(Point3D position, double width = 1.0, double height = 1.0, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Center, VerticalAlignment verticalAlignment = VerticalAlignment.Center, double depthOffset = 0.0, double worldDepthOffset = 0.0)
	{
		double num = -0.5;
		if (horizontalAlignment == HorizontalAlignment.Left)
		{
			num = 0.0;
		}
		if (horizontalAlignment == HorizontalAlignment.Right)
		{
			num = -1.0;
		}
		double num2 = -0.5;
		if (verticalAlignment == VerticalAlignment.Top)
		{
			num2 = 0.0;
		}
		if (verticalAlignment == VerticalAlignment.Bottom)
		{
			num2 = -1.0;
		}
		double num3 = num * width;
		double num4 = num2 * height;
		Position = position;
		Left = num3;
		Right = num3 + width;
		Top = num4;
		Bottom = num4 + height;
		DepthOffset = depthOffset;
		WorldDepthOffset = worldDepthOffset;
	}
}
