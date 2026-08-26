using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickModuleWarningException : MagickWarningException
{
	internal MagickModuleWarningException(string message)
		: base(message)
	{
	}
}
