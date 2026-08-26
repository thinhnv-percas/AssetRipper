using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickMissingDelegateErrorException : MagickErrorException
{
	internal MagickMissingDelegateErrorException(string message)
		: base(message)
	{
	}
}
