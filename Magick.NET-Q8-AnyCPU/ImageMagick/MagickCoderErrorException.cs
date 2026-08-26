using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickCoderErrorException : MagickErrorException
{
	internal MagickCoderErrorException(string message)
		: base(message)
	{
	}
}
