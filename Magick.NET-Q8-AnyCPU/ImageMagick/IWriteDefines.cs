namespace ImageMagick;

public interface IWriteDefines : IDefines
{
	MagickFormat Format { get; }
}
