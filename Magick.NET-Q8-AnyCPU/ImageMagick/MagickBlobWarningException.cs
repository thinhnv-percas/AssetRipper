using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickBlobWarningException : MagickWarningException
{
	internal MagickBlobWarningException(string message)
		: base(message)
	{
	}
}
