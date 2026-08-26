using System.Drawing;

namespace ImageMagick;

public sealed class DrawableViewbox : IDrawable, IDrawingWand
{
	public double LowerRightX { get; set; }

	public double LowerRightY { get; set; }

	public double UpperLeftX { get; set; }

	public double UpperLeftY { get; set; }

	public DrawableViewbox(Rectangle rectangle)
	{
		UpperLeftX = rectangle.X;
		UpperLeftY = rectangle.Y;
		LowerRightX = rectangle.Right;
		LowerRightY = rectangle.Bottom;
	}

	public static explicit operator DrawableViewbox(Rectangle rectangle)
	{
		return FromRectangle(rectangle);
	}

	public static DrawableViewbox FromRectangle(Rectangle rectangle)
	{
		return new DrawableViewbox(rectangle);
	}

	public DrawableViewbox(double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY)
	{
		UpperLeftX = upperLeftX;
		UpperLeftY = upperLeftY;
		LowerRightX = lowerRightX;
		LowerRightY = lowerRightY;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Viewbox(UpperLeftX, UpperLeftY, LowerRightX, LowerRightY);
	}
}
