using System;
using Humanizer.Bytes;

namespace Humanizer;

public static class ByteSizeExtensions
{
	public static ByteSize Bits(this byte input)
	{
		return ByteSize.FromBits(input);
	}

	public static ByteSize Bits(this sbyte input)
	{
		return ByteSize.FromBits(input);
	}

	public static ByteSize Bits(this short input)
	{
		return ByteSize.FromBits(input);
	}

	public static ByteSize Bits(this ushort input)
	{
		return ByteSize.FromBits(input);
	}

	public static ByteSize Bits(this int input)
	{
		return ByteSize.FromBits(input);
	}

	public static ByteSize Bits(this uint input)
	{
		return ByteSize.FromBits(input);
	}

	public static ByteSize Bits(this long input)
	{
		return ByteSize.FromBits(input);
	}

	public static ByteSize Bytes(this byte input)
	{
		return ByteSize.FromBytes((int)input);
	}

	public static ByteSize Bytes(this sbyte input)
	{
		return ByteSize.FromBytes(input);
	}

	public static ByteSize Bytes(this short input)
	{
		return ByteSize.FromBytes(input);
	}

	public static ByteSize Bytes(this ushort input)
	{
		return ByteSize.FromBytes((int)input);
	}

	public static ByteSize Bytes(this int input)
	{
		return ByteSize.FromBytes(input);
	}

	public static ByteSize Bytes(this uint input)
	{
		return ByteSize.FromBytes(input);
	}

	public static ByteSize Bytes(this double input)
	{
		return ByteSize.FromBytes(input);
	}

	public static ByteSize Bytes(this long input)
	{
		return ByteSize.FromBytes(input);
	}

	public static ByteSize Kilobytes(this byte input)
	{
		return ByteSize.FromKilobytes((int)input);
	}

	public static ByteSize Kilobytes(this sbyte input)
	{
		return ByteSize.FromKilobytes(input);
	}

	public static ByteSize Kilobytes(this short input)
	{
		return ByteSize.FromKilobytes(input);
	}

	public static ByteSize Kilobytes(this ushort input)
	{
		return ByteSize.FromKilobytes((int)input);
	}

	public static ByteSize Kilobytes(this int input)
	{
		return ByteSize.FromKilobytes(input);
	}

	public static ByteSize Kilobytes(this uint input)
	{
		return ByteSize.FromKilobytes(input);
	}

	public static ByteSize Kilobytes(this double input)
	{
		return ByteSize.FromKilobytes(input);
	}

	public static ByteSize Kilobytes(this long input)
	{
		return ByteSize.FromKilobytes(input);
	}

	public static ByteSize Megabytes(this byte input)
	{
		return ByteSize.FromMegabytes((int)input);
	}

	public static ByteSize Megabytes(this sbyte input)
	{
		return ByteSize.FromMegabytes(input);
	}

	public static ByteSize Megabytes(this short input)
	{
		return ByteSize.FromMegabytes(input);
	}

	public static ByteSize Megabytes(this ushort input)
	{
		return ByteSize.FromMegabytes((int)input);
	}

	public static ByteSize Megabytes(this int input)
	{
		return ByteSize.FromMegabytes(input);
	}

	public static ByteSize Megabytes(this uint input)
	{
		return ByteSize.FromMegabytes(input);
	}

	public static ByteSize Megabytes(this double input)
	{
		return ByteSize.FromMegabytes(input);
	}

	public static ByteSize Megabytes(this long input)
	{
		return ByteSize.FromMegabytes(input);
	}

	public static ByteSize Gigabytes(this byte input)
	{
		return ByteSize.FromGigabytes((int)input);
	}

	public static ByteSize Gigabytes(this sbyte input)
	{
		return ByteSize.FromGigabytes(input);
	}

	public static ByteSize Gigabytes(this short input)
	{
		return ByteSize.FromGigabytes(input);
	}

	public static ByteSize Gigabytes(this ushort input)
	{
		return ByteSize.FromGigabytes((int)input);
	}

	public static ByteSize Gigabytes(this int input)
	{
		return ByteSize.FromGigabytes(input);
	}

	public static ByteSize Gigabytes(this uint input)
	{
		return ByteSize.FromGigabytes(input);
	}

	public static ByteSize Gigabytes(this double input)
	{
		return ByteSize.FromGigabytes(input);
	}

	public static ByteSize Gigabytes(this long input)
	{
		return ByteSize.FromGigabytes(input);
	}

	public static ByteSize Terabytes(this byte input)
	{
		return ByteSize.FromTerabytes((int)input);
	}

	public static ByteSize Terabytes(this sbyte input)
	{
		return ByteSize.FromTerabytes(input);
	}

	public static ByteSize Terabytes(this short input)
	{
		return ByteSize.FromTerabytes(input);
	}

	public static ByteSize Terabytes(this ushort input)
	{
		return ByteSize.FromTerabytes((int)input);
	}

	public static ByteSize Terabytes(this int input)
	{
		return ByteSize.FromTerabytes(input);
	}

	public static ByteSize Terabytes(this uint input)
	{
		return ByteSize.FromTerabytes(input);
	}

	public static ByteSize Terabytes(this double input)
	{
		return ByteSize.FromTerabytes(input);
	}

	public static ByteSize Terabytes(this long input)
	{
		return ByteSize.FromTerabytes(input);
	}

	public static string Humanize(this ByteSize input, string format = null)
	{
		if (!string.IsNullOrWhiteSpace(format))
		{
			return input.ToString(format);
		}
		return input.ToString();
	}

	public static ByteRate Per(this ByteSize size, TimeSpan interval)
	{
		return new ByteRate(size, interval);
	}
}
