namespace ImageMagick;

public sealed class DrawableClipUnits : IDrawable, IDrawingWand
{
	public ClipPathUnit Units { get; set; }

	public DrawableClipUnits(ClipPathUnit units)
	{
		Units = units;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.ClipUnits(Units);
	}
}
