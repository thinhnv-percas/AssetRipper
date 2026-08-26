using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickOptionWarningException : MagickWarningException
{
	internal MagickOptionWarningException(string message)
		: base(message)
	{
	}
}
