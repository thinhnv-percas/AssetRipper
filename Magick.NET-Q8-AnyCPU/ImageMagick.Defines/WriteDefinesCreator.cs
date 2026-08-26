namespace ImageMagick.Defines;

public abstract class WriteDefinesCreator : DefinesCreator, IWriteDefines, IDefines
{
	MagickFormat IWriteDefines.Format => base.Format;

	protected WriteDefinesCreator(MagickFormat format)
		: base(format)
	{
	}
}
