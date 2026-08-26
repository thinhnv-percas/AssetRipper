using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickResourceLimitErrorException : MagickErrorException
{
	internal MagickResourceLimitErrorException(string message)
		: base(message)
	{
	}
}
