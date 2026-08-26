using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickFileOpenWarningException : MagickWarningException
{
	internal MagickFileOpenWarningException(string message)
		: base(message)
	{
	}
}
