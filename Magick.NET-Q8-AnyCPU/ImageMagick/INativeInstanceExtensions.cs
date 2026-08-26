using System;

namespace ImageMagick;

internal static class INativeInstanceExtensions
{
	internal static IntPtr GetInstance(this INativeInstance self)
	{
		return self?.Instance ?? IntPtr.Zero;
	}
}
