using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickImageErrorException : MagickErrorException
{
	internal MagickImageErrorException(string message)
		: base(message)
	{
	}
}
