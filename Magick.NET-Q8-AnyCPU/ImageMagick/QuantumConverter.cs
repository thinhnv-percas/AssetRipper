using System;

namespace ImageMagick;

internal static class QuantumConverter
{
	public unsafe static byte[] ToArray(IntPtr nativeData, int length)
	{
		if (nativeData == IntPtr.Zero)
		{
			return null;
		}
		byte[] array = new byte[length];
		byte* ptr = (byte*)(void*)nativeData;
		for (int i = 0; i < length; i++)
		{
			array[i] = *(ptr++);
		}
		return array;
	}
}
