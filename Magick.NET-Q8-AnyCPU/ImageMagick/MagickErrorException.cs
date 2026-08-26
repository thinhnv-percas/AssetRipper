using System;

namespace ImageMagick;

[Serializable]
public class MagickErrorException : MagickException
{
	internal MagickErrorException(string message)
		: base(message)
	{
	}
}
