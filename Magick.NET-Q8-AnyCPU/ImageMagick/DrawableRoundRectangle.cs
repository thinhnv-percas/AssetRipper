namespace ImageMagick;

public sealed class DrawableRoundRectangle : IDrawable, IDrawingWand
{
	public double CornerHeight { get; set; }

	public double CornerWidth { get; set; }

	public double LowerRightX { get; set; }

	public double LowerRightY { get; set; }

	public double UpperLeftX { get; set; }

	public double UpperLeftY { get; set; }

	public DrawableRoundRectangle(double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY, double cornerWidth, double cornerHeight)
	{
		UpperLeftX = upperLeftX;
		UpperLeftY = upperLeftY;
		LowerRightX = lowerRightX;
		LowerRightY = lowerRightY;
		CornerWidth = cornerWidth;
		CornerHeight = cornerHeight;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.RoundRectangle(UpperLeftX, UpperLeftY, LowerRightX, LowerRightY, CornerWidth, CornerHeight);
	}
}
