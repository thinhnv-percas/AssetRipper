using System;

namespace ImageMagick;

internal static class ShortConverter
{
	public unsafe static ushort[] ToArray(IntPtr nativeData, int length)
	{
		if (nativeData == IntPtr.Zero)
		{
			return null;
		}
		ushort[] array = new ushort[length];
		ushort* ptr = (ushort*)(void*)nativeData;
		for (int i = 0; i < length; i++)
		{
			array[i] = *(ptr++);
		}
		return array;
	}
}
