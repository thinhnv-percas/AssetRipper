using System;

namespace ImageMagick;

[Serializable]
public sealed class MagickModuleErrorException : MagickErrorException
{
	internal MagickModuleErrorException(string message)
		: base(message)
	{
	}
}
