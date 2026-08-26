using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickStreamErrorException : MagickErrorException
{
	internal MagickStreamErrorException(string message)
		: base(message)
	{
	}
}
