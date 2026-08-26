using System;
using System.Collections.Generic;
using System.Text;

namespace @as
{
	internal abstract class FbxBinary
	{
		internal static readonly byte[] headerString = Encoding.ASCII.GetBytes("Kaydara FBX Binary  \0\u001a\0");

		internal static readonly byte[] sourceId = new byte[16]
		{
			88,
			171,
			169,
			240,
			108,
			162,
			216,
			63,
			77,
			71,
			73,
			163,
			180,
			178,
			231,
			61
		};

		internal static readonly byte[] key = new byte[16]
		{
			226,
			79,
			123,
			95,
			205,
			228,
			200,
			109,
			219,
			216,
			251,
			215,
			64,
			88,
			198,
			120
		};

		internal static readonly byte[] extension = new byte[16]
		{
			248,
			90,
			140,
			106,
			222,
			245,
			217,
			126,
			236,
			233,
			12,
			227,
			117,
			143,
			41,
			11
		};

		internal const int footerZeroes1 = 17;

		internal const int footerZeroes2 = 120;

		internal const int footerCodeSize = 16;

		internal const string binarySeparator = "\0\u0001";

		internal const string asciiSeparator = "::";

		internal const string timePath1 = "FBXHeaderExtension";

		internal const string timePath2 = "CreationTimeStamp";

		internal static readonly Stack<string> timePath = new Stack<string>(new string[2]
		{
			"FBXHeaderExtension",
			"CreationTimeStamp"
		});

		internal static bool CheckEqual(byte[] data, byte[] original)
		{
			for (int i = 0; i < original.Length; i++)
			{
				if (data[i] != original[i])
				{
					return false;
				}
			}
			return true;
		}

		internal static void WriteHeader(_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A stream)
		{
			stream.Write(headerString, 0, headerString.Length);
		}

		internal static bool ReadHeader(_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020 stream)
		{
			byte[] array = new byte[headerString.Length];
			stream._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A(array, 0, array.Length);
			return CheckEqual(array, headerString);
		}

		internal static void Encrypt(byte[] a, byte[] b)
		{
			byte b2 = 64;
			for (int i = 0; i < 16; i++)
			{
				a[i] = (byte)(a[i] ^ (byte)(b2 ^ b[i]));
				b2 = a[i];
			}
		}

		internal static int GetTimestampVar(_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A timestamp, string element)
		{
			_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A = timestamp[element];
			if (_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A != null && _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A.Count > 0)
			{
				object obj = _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A[0];
				if (obj is int)
				{
					return (int)obj;
				}
				if (obj is long)
				{
					return (int)(long)obj;
				}
			}
			throw new _0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020(timePath, -1, "Timestamp has no " + element);
		}

		internal static byte[] GenerateFooterCode(FbxNodeList document)
		{
			_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A relative = document.GetRelative("FBXHeaderExtension/CreationTimeStamp");
			if (relative == null)
			{
				throw new _0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020(timePath, -1, "No creation timestamp");
			}
			try
			{
				return GenerateFooterCode(GetTimestampVar(relative, "Year"), GetTimestampVar(relative, "Month"), GetTimestampVar(relative, "Day"), GetTimestampVar(relative, "Hour"), GetTimestampVar(relative, "Minute"), GetTimestampVar(relative, "Second"), GetTimestampVar(relative, "Millisecond"));
			}
			catch (ArgumentOutOfRangeException)
			{
				throw new _0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020(timePath, -1, "Invalid timestamp");
			}
		}

		internal static byte[] GenerateFooterCode(int year, int month, int day, int hour, int minute, int second, int millisecond)
		{
			if (year < 0 || year > 9999)
			{
				throw new ArgumentOutOfRangeException("year");
			}
			if (month < 0 || month > 12)
			{
				throw new ArgumentOutOfRangeException("month");
			}
			if (day < 0 || day > 31)
			{
				throw new ArgumentOutOfRangeException("day");
			}
			if (hour < 0 || hour >= 24)
			{
				throw new ArgumentOutOfRangeException("hour");
			}
			if (minute < 0 || minute >= 60)
			{
				throw new ArgumentOutOfRangeException("minute");
			}
			if (second < 0 || second >= 60)
			{
				throw new ArgumentOutOfRangeException("second");
			}
			if (millisecond < 0 || millisecond >= 1000)
			{
				throw new ArgumentOutOfRangeException("millisecond");
			}
			byte[] array = (byte[])sourceId.Clone();
			string s = $"{second:00}{month:00}{hour:00}{day:00}{millisecond / 10:00}{year:0000}{minute:00}";
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			Encrypt(array, bytes);
			Encrypt(array, key);
			Encrypt(array, bytes);
			return array;
		}

		internal void WriteFooter(_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A stream, int version, _0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A document)
		{
			stream.Write(GenerateFooterCode(document));
			byte[] buffer = new byte[Math.Max(17, 120)];
			stream.Write(buffer, 0, 17);
			stream.Write(version);
			stream.Write(buffer, 0, 120);
			stream.Write(extension, 0, extension.Length);
		}

		internal static bool AllZero(byte[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != 0)
				{
					return false;
				}
			}
			return true;
		}

		internal bool CheckFooter(_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020 stream, FbxVersion version)
		{
			byte[] array = new byte[Math.Max(17, 120)];
			stream._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A(array, 0, 17);
			bool num = AllZero(array);
			int num2 = stream._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A();
			bool num3 = num & (num2 == (int)version);
			stream._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A(array, 0, 120);
			bool num4 = num3 & AllZero(array);
			stream._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A(array, 0, extension.Length);
			return num4 & CheckEqual(array, extension);
		}
	}
}
