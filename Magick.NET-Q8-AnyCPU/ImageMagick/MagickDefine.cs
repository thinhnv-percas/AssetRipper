namespace ImageMagick;

public sealed class MagickDefine : IDefine
{
	public MagickFormat Format { get; private set; }

	public string Name { get; private set; }

	public string Value { get; private set; }

	public MagickDefine(string name, string value)
	{
		Format = MagickFormat.Unknown;
		Name = name;
		Value = value;
	}

	public MagickDefine(MagickFormat format, string name, string value)
	{
		Format = format;
		Name = name;
		Value = value;
	}
}
