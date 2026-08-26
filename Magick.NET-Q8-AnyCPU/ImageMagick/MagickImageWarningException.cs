using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickImageWarningException : MagickWarningException
{
	internal MagickImageWarningException(string message)
		: base(message)
	{
	}
}
