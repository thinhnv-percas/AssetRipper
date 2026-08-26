using System;
using System.Collections.Generic;

namespace ImageMagick;

internal sealed class HexColor
{
	public static List<byte> Parse(string value)
	{
		if (value.Length < 13)
		{
			return new List<byte>(ParseQ8(value));
		}
		return new List<byte>(ParseQ16(value));
	}

	private static IEnumerable<byte> ParseQ16(string value)
	{
		if (value.Length == 13 || value.Length == 17)
		{
			yield return ParseHexQ8(value, 1);
			yield return ParseHexQ8(value, 5);
			yield return ParseHexQ8(value, 9);
			if (value.Length == 17)
			{
				yield return ParseHexQ8(value, 13);
			}
			yield break;
		}
		throw new ArgumentException("Invalid hex value.", "value");
	}

	private static byte ParseHexQ8(string color, int offset)
	{
		ushort num = 0;
		ushort num2 = 1;
		int num3 = 3;
		while (num3 >= 0)
		{
			char c = color[offset + num3];
			if (c >= '0' && c <= '9')
			{
				num += (ushort)(num2 * (c - 48));
			}
			else if (c >= 'a' && c <= 'f')
			{
				num += (ushort)(num2 * (c - 97 + 10));
			}
			else
			{
				if (c < 'A' || c > 'F')
				{
					throw new ArgumentException("Invalid character: " + c + ".", "color");
				}
				num += (ushort)(num2 * (c - 65 + 10));
			}
			num3--;
			num2 *= 16;
		}
		return Quantum.Convert(num);
	}

	private static IEnumerable<byte> ParseQ8(string value)
	{
		if (value.Length == 3)
		{
			yield return Quantum.Convert(ParseHex(value, 1, 2));
		}
		else if (value.Length == 4 || value.Length == 5)
		{
			byte b = ParseHex(value, 1, 1);
			b += (byte)(b * 16);
			yield return Quantum.Convert(b);
			byte b2 = ParseHex(value, 2, 1);
			b2 += (byte)(b2 * 16);
			yield return Quantum.Convert(b2);
			byte b3 = ParseHex(value, 3, 1);
			b3 += (byte)(b3 * 16);
			yield return Quantum.Convert(b3);
			if (value.Length == 5)
			{
				byte b4 = ParseHex(value, 4, 1);
				b4 += (byte)(b4 * 16);
				yield return Quantum.Convert(b4);
			}
		}
		else
		{
			if (value.Length != 7 && value.Length != 9)
			{
				throw new ArgumentException("Invalid hex value.", "value");
			}
			byte b = ParseHex(value, 1, 2);
			yield return Quantum.Convert(b);
			byte b2 = ParseHex(value, 3, 2);
			yield return Quantum.Convert(b2);
			byte b3 = ParseHex(value, 5, 2);
			yield return Quantum.Convert(b3);
			if (value.Length == 9)
			{
				byte b4 = ParseHex(value, 7, 2);
				yield return Quantum.Convert(b4);
			}
		}
	}

	private static byte ParseHex(string value, int offset, int length)
	{
		byte b = 0;
		byte b2 = 1;
		int num = length - 1;
		while (num >= 0)
		{
			char c = value[offset + num];
			if (c >= '0' && c <= '9')
			{
				b += (byte)(b2 * (c - 48));
			}
			else if (c >= 'a' && c <= 'f')
			{
				b += (byte)(b2 * (c - 97 + 10));
			}
			else
			{
				if (c < 'A' || c > 'F')
				{
					throw new ArgumentException("Invalid character: " + c + ".", "value");
				}
				b += (byte)(b2 * (c - 65 + 10));
			}
			num--;
			b2 *= 16;
		}
		return b;
	}
}
