using System;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption
{
	public sealed class PkzipClassicManaged : PkzipClassic
	{
		internal byte[] _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020;

		public override int BlockSize
		{
			get
			{
				return 8;
			}
			set
			{
				if (value != 8)
				{
					throw new CryptographicException("Block size is invalid");
				}
			}
		}

		public override KeySizes[] LegalKeySizes => new KeySizes[1]
		{
			new KeySizes(96, 96, 0)
		};

		public override KeySizes[] LegalBlockSizes => new KeySizes[1]
		{
			new KeySizes(8, 8, 0)
		};

		public override byte[] Key
		{
			get
			{
				if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020 == null)
				{
					GenerateKey();
				}
				return (byte[])_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020.Clone();
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length != 12)
				{
					throw new CryptographicException("Key size is illegal");
				}
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020 = (byte[])value.Clone();
			}
		}

		public override void GenerateIV()
		{
		}

		public override void GenerateKey()
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020 = new byte[12];
			new Random().NextBytes(_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020);
		}

		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020 = rgbKey;
			return new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A(Key);
		}

		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020 = rgbKey;
			return new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020(Key);
		}
	}
}
