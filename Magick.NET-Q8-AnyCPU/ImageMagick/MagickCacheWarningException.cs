using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickCacheWarningException : MagickWarningException
{
	internal MagickCacheWarningException(string message)
		: base(message)
	{
	}
}
