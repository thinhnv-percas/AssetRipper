using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickRegistryWarningException : MagickWarningException
{
	internal MagickRegistryWarningException(string message)
		: base(message)
	{
	}
}
