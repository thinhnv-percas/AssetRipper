using System;
using System.IO;
using Unity.IO.Compression;

[DevXUnity_DoNotObfuscate]
[DevXUnity_StringEncryptionStrong]
public class 例子
{
	internal static uint GetStringHash(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			return 123u;
		}
		int num = 0;
		int num2 = 352654597;
		int num3 = num2;
		for (int num4 = s.Length; num4 > 0; num4 -= 4)
		{
			num2 = ((num + 1 < s.Length) ? (((num2 << 5) + num2 + (num2 >> 27)) ^ (int)(s[num] | ((uint)s[num + 1] << 16))) : ((num >= s.Length) ? (((num2 << 5) + num2 + (num2 >> 27)) ^ 0) : (((num2 << 5) + num2 + (num2 >> 27)) ^ s[num])));
			if (num4 <= 2)
			{
				break;
			}
			num += 2;
			num3 = ((num + 1 >= s.Length) ? ((num >= s.Length) ? (((num3 << 5) + num3 + (num3 >> 27)) ^ 0) : (((num3 << 5) + num3 + (num3 >> 27)) ^ s[num])) : (((num3 << 5) + num3 + (num3 >> 27)) ^ (int)(s[num] | ((uint)s[num + 1] << 16))));
			num += 2;
		}
		return (uint)(num2 + num3 * 1566083941);
	}

	[DevXUnity_DoNotObfuscate]
	public static byte[] 测试(byte[] in_buff, string secret)
	{
		try
		{
			if (in_buff == null || in_buff.Length <= 1)
			{
				return null;
			}
			if (secret == null || secret.Length < 4)
			{
				secret += "G$#34";
			}
			uint num = 1162040133 + GetStringHash(secret.Substring(0, secret.Length / 2));
			uint num2 = 2506450243u + GetStringHash(secret.Substring(secret.Length / 2));
			byte[] array = new byte[in_buff.Length - 1];
			byte b = in_buff[0];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = in_buff[i + 1];
				num = (num * 4343255 + b + 5235457) % 4294967294u;
				num2 = (num2 * 5354354 + b + 22646641) % 4294967294u;
				array[i] -= (byte)num2;
				array[i] = (byte)(array[i] ^ num);
				b = array[i];
			}
			MemoryStream stream = new MemoryStream(array);
			try
			{
				using GZipStream input_stream = new GZipStream(stream, CompressionMode.Decompress);
				MemoryStream memoryStream = new MemoryStream();
				Copy(input_stream, memoryStream);
				array = memoryStream.ToArray();
			}
			catch (Exception)
			{
			}
			return array;
		}
		catch
		{
			return null;
		}
	}

	internal static void Copy(Stream input_stream, Stream out_stream, byte[] buffer = null)
	{
		if (buffer == null)
		{
			buffer = new byte[4096];
		}
		int num;
		do
		{
			num = input_stream.Read(buffer, 0, buffer.Length);
			out_stream.Write(buffer, 0, num);
		}
		while (num > 0);
	}
}
