using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickConfigureWarningException : MagickWarningException
{
	internal MagickConfigureWarningException(string message)
		: base(message)
	{
	}
}
