namespace ImageMagick;

public sealed class DrawableComposite : IDrawable, IDrawingWand
{
	private readonly IMagickImage _image;

	public CompositeOperator Compose { get; set; }

	public double Height { get; set; }

	public double Width { get; set; }

	public double X { get; set; }

	public double Y { get; set; }

	public DrawableComposite(double x, double y, IMagickImage image)
		: this(image)
	{
		X = x;
		Y = y;
		Width = _image.Width;
		Height = _image.Height;
		Compose = CompositeOperator.CopyAlpha;
	}

	public DrawableComposite(double x, double y, CompositeOperator compose, IMagickImage image)
		: this(image)
	{
		X = x;
		Y = y;
		Width = _image.Width;
		Height = _image.Height;
		Compose = compose;
	}

	public DrawableComposite(MagickGeometry offset, IMagickImage image)
		: this(image)
	{
		Throw.IfNull("offset", offset);
		X = offset.X;
		Y = offset.Y;
		Width = offset.Width;
		Height = offset.Height;
		Compose = CompositeOperator.CopyAlpha;
	}

	public DrawableComposite(MagickGeometry offset, CompositeOperator compose, IMagickImage image)
		: this(image)
	{
		Throw.IfNull("offset", offset);
		X = offset.X;
		Y = offset.Y;
		Width = offset.Width;
		Height = offset.Height;
		Compose = compose;
	}

	private DrawableComposite(IMagickImage image)
	{
		Throw.IfNull("image", image);
		_image = image;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Composite(X, Y, Width, Height, Compose, _image);
	}
}
