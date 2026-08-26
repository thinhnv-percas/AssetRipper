using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickPolicyErrorException : MagickErrorException
{
	internal MagickPolicyErrorException(string message)
		: base(message)
	{
	}
}
