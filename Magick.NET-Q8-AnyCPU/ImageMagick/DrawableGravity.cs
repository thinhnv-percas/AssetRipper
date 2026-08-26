namespace ImageMagick;

public sealed class DrawableGravity : IDrawable, IDrawingWand
{
	public Gravity Gravity { get; set; }

	public DrawableGravity(Gravity gravity)
	{
		Gravity = gravity;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Gravity(Gravity);
	}
}
