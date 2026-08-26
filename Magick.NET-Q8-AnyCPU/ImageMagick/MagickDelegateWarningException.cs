using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickDelegateWarningException : MagickWarningException
{
	internal MagickDelegateWarningException(string message)
		: base(message)
	{
	}
}
