using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickCorruptImageErrorException : MagickErrorException
{
	internal MagickCorruptImageErrorException(string message)
		: base(message)
	{
	}
}
