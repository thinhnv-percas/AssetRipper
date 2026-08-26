using System;

namespace ImageMagick;

internal static class IntPtrExtensions
{
	internal static IMagickImage CreateIMagickImage(this IntPtr self)
	{
		return MagickImage.Create(self);
	}
}
