using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickTypeErrorException : MagickErrorException
{
	internal MagickTypeErrorException(string message)
		: base(message)
	{
	}
}
