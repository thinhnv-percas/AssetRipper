using System;
using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader.PortablePdb;

internal static class InteropUtilities
{
	public static int StringToBuffer(string str, int bufferLength, out int count, char[] buffer)
	{
		count = str.Length + 1;
		if (buffer == null)
		{
			return 0;
		}
		if (count > bufferLength)
		{
			count = 0;
			return -2147024882;
		}
		str.CopyTo(0, buffer, 0, str.Length);
		buffer[str.Length] = '\0';
		return 0;
	}

	public static int BytesToBuffer(byte[] bytes, int bufferLength, out int count, byte[] buffer)
	{
		count = bytes.Length;
		if (buffer == null)
		{
			return 0;
		}
		if (count > bufferLength)
		{
			count = 0;
			return -2147024882;
		}
		Buffer.BlockCopy(bytes, 0, buffer, 0, count);
		return 0;
	}

	internal static void TransferOwnershipOrRelease(ref object objectOpt, object newOwnerOpt)
	{
		if (newOwnerOpt != null)
		{
			if (objectOpt != null && Marshal.IsComObject(objectOpt))
			{
				Marshal.ReleaseComObject(objectOpt);
			}
			objectOpt = null;
		}
	}
}
