using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

internal static class ByteConverter
{
	public unsafe static byte[] ToArray(IntPtr nativeData)
	{
		if (nativeData == IntPtr.Zero)
		{
			return null;
		}
		int num = 0;
		byte* ptr = (byte*)(void*)nativeData;
		while (*(ptr++) != 0)
		{
			num++;
		}
		if (num == 0)
		{
			return new byte[0];
		}
		return ToArray(nativeData, num);
	}

	public static byte[] ToArray(IntPtr nativeData, int length)
	{
		if (nativeData == IntPtr.Zero)
		{
			return null;
		}
		byte[] array = new byte[length];
		Marshal.Copy(nativeData, array, 0, length);
		return array;
	}

	public static int ToUInt(byte[] data, ref int offset)
	{
		if (offset + 4 > data.Length)
		{
			return 0;
		}
		int num = (int)(((data[offset++] << 24) | (data[offset++] << 16) | (data[offset++] << 8) | data[offset++]) & 0xFFFFFFFFu);
		if (num >= 0)
		{
			return num;
		}
		return 0;
	}

	public static short ToShort(byte[] data, ref int offset)
	{
		if (offset + 2 > data.Length)
		{
			return 0;
		}
		return (short)((short)((short)(data[offset++] << 8) | data[offset++]) & 0xFFFF);
	}
}
