using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickStreamWarningException : MagickWarningException
{
	internal MagickStreamWarningException(string message)
		: base(message)
	{
	}
}
