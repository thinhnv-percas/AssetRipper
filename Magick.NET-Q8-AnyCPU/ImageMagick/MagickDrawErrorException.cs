using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickDrawErrorException : MagickErrorException
{
	internal MagickDrawErrorException(string message)
		: base(message)
	{
	}
}
