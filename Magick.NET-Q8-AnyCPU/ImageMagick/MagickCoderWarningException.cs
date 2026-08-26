using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickCoderWarningException : MagickWarningException
{
	internal MagickCoderWarningException(string message)
		: base(message)
	{
	}
}
