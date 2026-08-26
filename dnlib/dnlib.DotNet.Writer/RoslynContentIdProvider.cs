using System;

namespace dnlib.DotNet.Writer;

internal static class RoslynContentIdProvider
{
	public static void GetContentId(byte[] hash, out Guid guid, out uint timestamp)
	{
		if (hash.Length < 20)
		{
			throw new InvalidOperationException();
		}
		byte[] array = new byte[16];
		Array.Copy(hash, 0, array, 0, array.Length);
		array[7] = (byte)((array[7] & 0xF) | 0x40);
		array[8] = (byte)((array[8] & 0x3F) | 0x80);
		guid = new Guid(array);
		timestamp = (uint)(int.MinValue | ((hash[19] << 24) | (hash[18] << 16) | (hash[17] << 8) | hash[16]));
	}
}
