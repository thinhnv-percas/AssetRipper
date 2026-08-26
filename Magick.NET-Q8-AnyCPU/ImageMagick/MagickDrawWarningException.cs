using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickDrawWarningException : MagickWarningException
{
	internal MagickDrawWarningException(string message)
		: base(message)
	{
	}
}
