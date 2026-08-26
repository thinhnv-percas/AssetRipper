using System;

public class EncryptDecryptManager
{
	internal static uint _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020(string _0020)
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

	public static byte[] _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020(byte[] _0020, string _0020_000A)
	{
		if (_0020 == null || _0020.Length == 0)
		{
			return null;
		}
		try
		{
			if (_0020_000A == null || _0020_000A.Length < 4)
			{
				_0020_000A += "G$#34";
			}
			uint num = 1162040133 + _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020(_0020_000A.Substring(0, _0020_000A.Length / 2));
			uint num2 = (uint)(-1788517053 + (int)_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020(_0020_000A.Substring(_0020_000A.Length / 2)));
			byte[] array = new byte[_0020.Length + 1];
			array[0] = (byte)(DateTime.Now.Ticks % 256);
			byte b = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				array[i] = _0020[i - 1];
				num = (num * 4343255 + b + 5235457) % 4294967294u;
				num2 = (num2 * 5354354 + b + 22646641) % 4294967294u;
				b = array[i];
				array[i] = (byte)(array[i] ^ num);
				array[i] = (byte)(array[i] + (byte)num2);
			}
			return array;
		}
		catch
		{
			return null;
		}
	}

	public static byte[] Decrypt(byte[] _0020, string _0020_000A)
	{
		try
		{
			if (_0020 == null || _0020.Length <= 1)
			{
				return null;
			}
			if (_0020_000A == null || _0020_000A.Length < 4)
			{
				_0020_000A += "G$#34";
			}
			uint num = 1162040133 + _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020(_0020_000A.Substring(0, _0020_000A.Length / 2));
			uint num2 = (uint)(-1788517053 + (int)_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020(_0020_000A.Substring(_0020_000A.Length / 2)));
			byte[] array = new byte[_0020.Length - 1];
			byte b = _0020[0];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _0020[i + 1];
				num = (num * 4343255 + b + 5235457) % 4294967294u;
				num2 = (num2 * 5354354 + b + 22646641) % 4294967294u;
				array[i] = (byte)(array[i] - (byte)num2);
				array[i] = (byte)(array[i] ^ num);
				b = array[i];
			}
			return array;
		}
		catch
		{
			return null;
		}
	}
}
