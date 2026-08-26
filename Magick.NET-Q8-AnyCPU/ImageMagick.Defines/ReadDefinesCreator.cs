namespace ImageMagick.Defines;

public abstract class ReadDefinesCreator : DefinesCreator, IReadDefines, IDefines
{
	protected ReadDefinesCreator(MagickFormat format)
		: base(format)
	{
	}
}
