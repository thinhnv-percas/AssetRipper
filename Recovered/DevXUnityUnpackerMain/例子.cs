using System;
using System.IO;
using Unity.IO.Compression;

public class 例子
{
	internal static uint _0020_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(string _0020)
	{
		if (string.IsNullOrEmpty(_0020))
		{
			return 123u;
		}
		int num = 0;
		int num2 = 352654597;
		int num3 = num2;
		for (int num4 = _0020.Length; num4 > 0; num4 -= 4)
		{
			num2 = ((num + 1 < _0020.Length) ? (((num2 << 5) + num2 + (num2 >> 27)) ^ (int)(_0020[num] | ((uint)_0020[num + 1] << 16))) : ((num >= _0020.Length) ? (((num2 << 5) + num2 + (num2 >> 27)) ^ 0) : (((num2 << 5) + num2 + (num2 >> 27)) ^ _0020[num])));
			if (num4 <= 2)
			{
				break;
			}
			num += 2;
			num3 = ((num + 1 >= _0020.Length) ? ((num >= _0020.Length) ? (((num3 << 5) + num3 + (num3 >> 27)) ^ 0) : (((num3 << 5) + num3 + (num3 >> 27)) ^ _0020[num])) : (((num3 << 5) + num3 + (num3 >> 27)) ^ (int)(_0020[num] | ((uint)_0020[num + 1] << 16))));
			num += 2;
		}
		return (uint)(num2 + num3 * 1566083941);
	}

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
				secret += _0020_0020_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020._0020_0020_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A();
			}
			uint num = 1162040133 + _0020_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(secret.Substring(0, secret.Length / 2));
			uint num2 = (uint)(-1788517053 + (int)_0020_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(secret.Substring(secret.Length / 2)));
			byte[] array = new byte[in_buff.Length - 1];
			byte b = in_buff[0];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = in_buff[i + 1];
				num = (num * 4343255 + b + 5235457) % 4294967294u;
				num2 = (num2 * 5354354 + b + 22646641) % 4294967294u;
				array[i] = (byte)(array[i] - (byte)num2);
				array[i] = (byte)(array[i] ^ num);
				b = array[i];
			}
			MemoryStream stream = new MemoryStream(array);
			try
			{
				using (GZipStream _0020 = new GZipStream(stream, CompressionMode.Decompress))
				{
					MemoryStream memoryStream = new MemoryStream();
					_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020(_0020, memoryStream);
					array = memoryStream.ToArray();
				}
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

	internal static void _0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020(Stream _0020, Stream _0020_000A, byte[] _0020_0020 = null)
	{
		if (_0020_0020 == null)
		{
			_0020_0020 = new byte[4096];
		}
		int num;
		do
		{
			num = _0020.Read(_0020_0020, 0, _0020_0020.Length);
			_0020_000A.Write(_0020_0020, 0, num);
		}
		while (num > 0);
	}
}
