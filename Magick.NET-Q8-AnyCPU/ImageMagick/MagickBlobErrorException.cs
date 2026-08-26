using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickBlobErrorException : MagickErrorException
{
	internal MagickBlobErrorException(string message)
		: base(message)
	{
	}
}
