using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickRegistryErrorException : MagickErrorException
{
	internal MagickRegistryErrorException(string message)
		: base(message)
	{
	}
}
