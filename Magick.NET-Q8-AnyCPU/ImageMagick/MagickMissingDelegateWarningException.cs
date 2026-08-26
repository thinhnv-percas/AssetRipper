using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickMissingDelegateWarningException : MagickWarningException
{
	internal MagickMissingDelegateWarningException(string message)
		: base(message)
	{
	}
}
