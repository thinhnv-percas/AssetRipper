using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickCacheErrorException : MagickErrorException
{
	internal MagickCacheErrorException(string message)
		: base(message)
	{
	}
}
