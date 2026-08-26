using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickPolicyWarningException : MagickErrorException
{
	internal MagickPolicyWarningException(string message)
		: base(message)
	{
	}
}
