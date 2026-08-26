using System;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Crc64 : HashAlgorithm
{
	public const ulong DefaultSeed = 0uL;

	private readonly ulong[] _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A;

	private readonly ulong _0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A;

	private ulong _0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020;

	public override int HashSize => 64;

	public Crc64(ulong polynomial)
		: this(polynomial, 0uL)
	{
	}

	public Crc64(ulong polynomial, ulong seed)
	{
		_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A = _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020(polynomial);
		_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A = (_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020 = seed);
	}

	public override void Initialize()
	{
		_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020 = _0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A;
	}

	protected override void HashCore(byte[] array, int ibStart, int cbSize)
	{
		_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020 = CalculateHash(_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020, _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A, array, ibStart, cbSize);
	}

	protected override byte[] HashFinal()
	{
		return HashValue = _0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020(_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020);
	}

	protected static ulong CalculateHash(ulong seed, ulong[] table, IList<byte> buffer, int start, int size)
	{
		ulong num = seed;
		for (int i = start; i < start + size; i++)
		{
			num = (num >> 8) ^ table[(buffer[i] ^ num) & 0xFF];
		}
		return num;
	}

	private static byte[] _0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020(ulong P_0)
	{
		byte[] bytes = BitConverter.GetBytes(P_0);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
		}
		return bytes;
	}

	private static ulong[] _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020(ulong P_0)
	{
		if (P_0 == 15564440312192434176uL && Crc64Iso._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A != null)
		{
			return Crc64Iso._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A;
		}
		ulong[] array = CreateTable(P_0);
		if (P_0 == 15564440312192434176uL)
		{
			Crc64Iso._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A = array;
		}
		return array;
	}

	protected static ulong[] CreateTable(ulong polynomial)
	{
		ulong[] array = new ulong[256];
		for (int i = 0; i < 256; i++)
		{
			ulong num = (ulong)i;
			for (int j = 0; j < 8; j++)
			{
				num = (((num & 1) != 1) ? (num >> 1) : ((num >> 1) ^ polynomial));
			}
			array[i] = num;
		}
		return array;
	}
}
