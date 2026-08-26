using System.Drawing;

namespace ImageMagick;

public sealed class DrawableRectangle : IDrawable, IDrawingWand
{
	public double LowerRightX { get; set; }

	public double LowerRightY { get; set; }

	public double UpperLeftX { get; set; }

	public double UpperLeftY { get; set; }

	public DrawableRectangle(Rectangle rectangle)
	{
		UpperLeftX = rectangle.X;
		UpperLeftY = rectangle.Y;
		LowerRightX = rectangle.Right;
		LowerRightY = rectangle.Bottom;
	}

	public static explicit operator DrawableRectangle(Rectangle rectangle)
	{
		return FromRectangle(rectangle);
	}

	public static DrawableRectangle FromRectangle(Rectangle rectangle)
	{
		return new DrawableRectangle(rectangle);
	}

	public DrawableRectangle(double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY)
	{
		UpperLeftX = upperLeftX;
		UpperLeftY = upperLeftY;
		LowerRightX = lowerRightX;
		LowerRightY = lowerRightY;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Rectangle(UpperLeftX, UpperLeftY, LowerRightX, LowerRightY);
	}
}
