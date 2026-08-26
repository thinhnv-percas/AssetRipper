namespace ImageMagick;

public sealed class DrawablePushPattern : IDrawable, IDrawingWand
{
	public string ID { get; set; }

	public double Height { get; set; }

	public double Width { get; set; }

	public double X { get; set; }

	public double Y { get; set; }

	public DrawablePushPattern(string id, double x, double y, double width, double height)
	{
		ID = id;
		X = x;
		Y = y;
		Width = width;
		Height = height;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PushPattern(ID, X, Y, Width, Height);
	}
}
