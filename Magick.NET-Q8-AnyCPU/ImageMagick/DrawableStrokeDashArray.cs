namespace ImageMagick;

public sealed class DrawableStrokeDashArray : IDrawable, IDrawingWand
{
	private readonly double[] _dash;

	public DrawableStrokeDashArray(params double[] dash)
	{
		_dash = dash;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.StrokeDashArray(_dash);
	}
}
