using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickResourceLimitWarningException : MagickWarningException
{
	internal MagickResourceLimitWarningException(string message)
		: base(message)
	{
	}
}
