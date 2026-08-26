using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickCorruptImageWarningException : MagickWarningException
{
	internal MagickCorruptImageWarningException(string message)
		: base(message)
	{
	}
}
