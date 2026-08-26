using System;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Crc64 : HashAlgorithm
{
	public const ulong DefaultSeed = 0uL;

	internal readonly ulong[] table1;

	internal readonly ulong seed2;

	internal ulong seed1;

	public override int HashSize => 64;

	public Crc64(ulong polynomial)
		: this(polynomial, 0uL)
	{
	}

	public Crc64(ulong polynomial, ulong seed)
	{
		table1 = GetTable(polynomial);
		seed2 = (seed1 = seed);
	}

	public override void Initialize()
	{
		seed1 = seed2;
	}

	protected override void HashCore(byte[] array, int ibStart, int cbSize)
	{
		seed1 = CalculateHash(seed1, table1, array, ibStart, cbSize);
	}

	protected override byte[] HashFinal()
	{
		return HashValue = doSth(seed1);
	}

	internal static ulong CalculateHash(ulong seed, ulong[] table, IList<byte> buffer, int start, int size)
	{
		ulong num = seed;
		for (int i = start; i < start + size; i++)
		{
			num = ((num >> 8) ^ table[(buffer[i] ^ num) & 0xFF]);
		}
		return num;
	}

	internal static byte[] doSth(ulong _0020)
	{
		byte[] bytes = BitConverter.GetBytes(_0020);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
		}
		return bytes;
	}

	internal static ulong[] GetTable(ulong v)
	{
		if (v == 15564440312192434176uL && Crc64Iso.table != null)
		{
			return Crc64Iso.table;
		}
		ulong[] array = CreateTable(v);
		if (v == 15564440312192434176uL)
		{
			Crc64Iso.table = array;
		}
		return array;
	}

	internal static ulong[] CreateTable(ulong polynomial)
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
