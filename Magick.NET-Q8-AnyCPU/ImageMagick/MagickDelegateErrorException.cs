using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickDelegateErrorException : MagickErrorException
{
	internal MagickDelegateErrorException(string message)
		: base(message)
	{
	}
}
