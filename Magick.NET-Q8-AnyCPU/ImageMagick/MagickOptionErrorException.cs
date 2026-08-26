using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickOptionErrorException : MagickErrorException
{
	internal MagickOptionErrorException(string message)
		: base(message)
	{
	}
}
