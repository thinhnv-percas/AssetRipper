using System;

namespace ImageMagick;

internal static class IMagickImageExtensions
{
	internal static IntPtr GetInstance(this IMagickImage self)
	{
		if (self == null)
		{
			return IntPtr.Zero;
		}
		return ((self as INativeInstance) ?? throw new NotSupportedException()).Instance;
	}

	internal static MagickErrorInfo CreateErrorInfo(this IMagickImage self)
	{
		if (self == null)
		{
			return null;
		}
		MagickImage obj = self as MagickImage;
		if (obj == null)
		{
			throw new NotSupportedException();
		}
		return MagickImage.CreateErrorInfo(obj);
	}

	internal static void SetNext(this IMagickImage self, IMagickImage next)
	{
		MagickImage obj = self as MagickImage;
		if (obj == null)
		{
			throw new NotSupportedException();
		}
		obj.SetNext(next);
	}
}
