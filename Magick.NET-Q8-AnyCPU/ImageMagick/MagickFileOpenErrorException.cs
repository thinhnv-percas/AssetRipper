using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickFileOpenErrorException : MagickErrorException
{
	internal MagickFileOpenErrorException(string message)
		: base(message)
	{
	}
}
