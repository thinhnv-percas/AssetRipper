using ICSharpCode.SharpZipLib.Checksum;
using System;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption
{
	public abstract class PkzipClassic : SymmetricAlgorithm
	{
		public static byte[] GenerateKeys(byte[] seed)
		{
			if (seed == null)
			{
				throw new ArgumentNullException(_0020_0020_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020._0020_0020_0020_000A_000A_0020_000A_0020_000A_0020);
			}
			if (seed.Length == 0)
			{
				throw new ArgumentException(_0020_0020_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020._0020_0020_0020_000A_000A_0020_000A_0020_0020_000A, _0020_0020_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020._0020_0020_0020_000A_000A_0020_000A_0020_000A_0020);
			}
			uint[] array = new uint[3]
			{
				305419896u,
				591751049u,
				878082192u
			};
			for (int i = 0; i < seed.Length; i++)
			{
				array[0] = Crc32._0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A(array[0], seed[i]);
				array[1] = array[1] + (byte)array[0];
				array[1] = array[1] * 134775813 + 1;
				array[2] = Crc32._0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A(array[2], (byte)(array[1] >> 24));
			}
			return new byte[12]
			{
				(byte)(array[0] & 0xFF),
				(byte)((array[0] >> 8) & 0xFF),
				(byte)((array[0] >> 16) & 0xFF),
				(byte)((array[0] >> 24) & 0xFF),
				(byte)(array[1] & 0xFF),
				(byte)((array[1] >> 8) & 0xFF),
				(byte)((array[1] >> 16) & 0xFF),
				(byte)((array[1] >> 24) & 0xFF),
				(byte)(array[2] & 0xFF),
				(byte)((array[2] >> 8) & 0xFF),
				(byte)((array[2] >> 16) & 0xFF),
				(byte)((array[2] >> 24) & 0xFF)
			};
		}
	}
}
