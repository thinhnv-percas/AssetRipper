using System.Security.Cryptography;
using System.Text;

internal class ConvertNameToHash
{
	internal static string _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A = "2.80";

	internal static string _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_0020
	{
		get
		{
			string text = DevXSystemInfo.get_MachineName().ToLower();
			if (text.IndexOf('.') >= 0)
			{
				text = text.Substring(0, text.IndexOf('.'));
			}
			return text;
		}
	}

	internal static string _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A
	{
		get
		{
			string text = DevXSystemInfo.UserName.ToLower();
			if (text.IndexOf('.') >= 0)
			{
				text = text.Substring(0, text.IndexOf('.'));
			}
			if (text.IndexOf('@') >= 0)
			{
				text = text.Substring(0, text.IndexOf('@'));
			}
			if (text.IndexOf('\\') >= 0)
			{
				text = text.Substring(text.IndexOf('\\') + 1);
			}
			return text;
		}
	}

	internal static string Get()
	{
		return _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A(DevXSystemInfo.get_MachineName() + "-" + DevXSystemInfo.UserName + _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A);
	}

	internal static string _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A(string _0020)
	{
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] bytes = new ASCIIEncoding().GetBytes(_0020 + "123");
		bytes = mD5CryptoServiceProvider.ComputeHash(bytes);
		if (bytes.Length > 8)
		{
			byte[] array = bytes;
			bytes = new byte[8];
			for (int i = 0; i < 8; i++)
			{
				bytes[i] = array[i];
			}
		}
		return _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020(bytes);
	}

	internal static string _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020(byte[] _0020)
	{
		string text = string.Empty;
		for (int i = 0; i < _0020.Length; i++)
		{
			byte num = _0020[i];
			int num2 = num & 0xF;
			int num3 = (num >> 4) & 0xF;
			text = ((num3 <= 9) ? (text + num3.ToString()) : (text + ((char)(ushort)(num3 - 10 + 65)).ToString()));
			text = ((num2 <= 9) ? (text + num2.ToString()) : (text + ((char)(ushort)(num2 - 10 + 65)).ToString()));
			if (i + 1 != _0020.Length && (i + 1) % 2 == 0)
			{
				text += "-";
			}
		}
		return text.Trim();
	}
}
