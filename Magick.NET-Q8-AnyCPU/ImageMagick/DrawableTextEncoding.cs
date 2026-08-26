using System.Text;

namespace ImageMagick;

public sealed class DrawableTextEncoding : IDrawable, IDrawingWand
{
	public Encoding Encoding { get; set; }

	public DrawableTextEncoding(Encoding encoding)
	{
		Throw.IfNull("encoding", encoding);
		Encoding = encoding;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.TextEncoding(Encoding);
	}
}
