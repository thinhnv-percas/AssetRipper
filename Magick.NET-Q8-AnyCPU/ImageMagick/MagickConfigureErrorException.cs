using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickConfigureErrorException : MagickErrorException
{
	internal MagickConfigureErrorException(string message)
		: base(message)
	{
	}
}
