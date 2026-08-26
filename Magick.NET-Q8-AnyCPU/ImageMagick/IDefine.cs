namespace ImageMagick;

public interface IDefine
{
	MagickFormat Format { get; }

	string Name { get; }

	string Value { get; }
}
