using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickTypeWarningException : MagickWarningException
{
	internal MagickTypeWarningException(string message)
		: base(message)
	{
	}
}
