using System;

namespace ImageMagick;

[Serializable]
public class MagickWarningException : MagickException
{
	internal MagickWarningException(string message)
		: base(message)
	{
	}
}
