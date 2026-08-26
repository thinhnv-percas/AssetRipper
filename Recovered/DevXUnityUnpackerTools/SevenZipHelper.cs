using SevenZip;
using SevenZip.Compression.LZMA;
using System;
using System.IO;

public static class SevenZipHelper
{
	private static int _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A = 2097152;

	private static int _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020 = 2;

	private static int _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A = 3;

	private static int _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020 = 0;

	private static int _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A = 2;

	private static int _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020 = 32;

	private static bool _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A = false;

	private static CoderPropID[] _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020 = new CoderPropID[8]
	{
		CoderPropID.DictionarySize,
		CoderPropID.PosStateBits,
		CoderPropID.LitContextBits,
		CoderPropID.LitPosBits,
		CoderPropID.Algorithm,
		CoderPropID.NumFastBytes,
		CoderPropID.MatchFinder,
		CoderPropID.EndMarker
	};

	private static object[] _0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A = new object[8]
	{
		_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A,
		_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020,
		_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A,
		_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020,
		_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A,
		_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020,
		"bt4",
		_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A
	};

	public static void Decompress(Stream inStream, Stream outStream, long compressedSize, long? deCompressedSize = default(long?))
	{
		byte[] array = new byte[5];
		inStream.Read(array, 0, 5);
		Decoder decoder = new Decoder();
		decoder.SetDecoderProperties(array);
		if (!deCompressedSize.HasValue)
		{
			long num = 0L;
			for (int i = 0; i < 8; i++)
			{
				int num2 = inStream.ReadByte();
				num |= (long)((ulong)(byte)num2 << 8 * i);
			}
			deCompressedSize = num;
			if (deCompressedSize > 1073741824)
			{
				throw new Exception("Lzma Size not valid! deCompressedSize: " + deCompressedSize);
			}
		}
		decoder.Code(inStream, outStream, compressedSize, deCompressedSize.Value, null);
	}

	public static void Compress(Stream inStream, Stream outStream, bool save_deCompressedSize = true)
	{
		Encoder encoder = new Encoder();
		encoder.SetCoderProperties(_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020, _0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A);
		encoder.WriteCoderProperties(outStream);
		if (save_deCompressedSize)
		{
			long length = inStream.Length;
			for (int i = 0; i < 8; i++)
			{
				outStream.WriteByte((byte)(length >> 8 * i));
			}
		}
		encoder.Code(inStream, outStream, -1L, -1L, null);
	}

	public static byte[] Compress(byte[] inputBytes, bool save_deCompressedSize = true)
	{
		byte[] array = null;
		Encoder encoder = new Encoder();
		encoder.SetCoderProperties(_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020, _0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A);
		using (MemoryStream memoryStream2 = new MemoryStream(inputBytes))
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				encoder.WriteCoderProperties(memoryStream);
				if (save_deCompressedSize)
				{
					long length = memoryStream2.Length;
					for (int i = 0; i < 8; i++)
					{
						memoryStream.WriteByte((byte)(length >> 8 * i));
					}
				}
				encoder.Code(memoryStream2, memoryStream, -1L, -1L, null);
				return memoryStream.ToArray();
			}
		}
	}

	internal static byte[] _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A(byte[] _0020, long _0020_000A, long? _0020_0020 = default(long?))
	{
		MemoryStream memoryStream = new MemoryStream();
		Decompress(new MemoryStream(_0020), memoryStream, _0020_000A, _0020_0020);
		return memoryStream.ToArray();
	}

	internal static Stream _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A(Stream _0020, long _0020_000A, long? _0020_0020 = default(long?))
	{
		Stream stream = TempManager.Create(null);
		Decompress(_0020, stream, _0020_000A, _0020_0020);
		stream.Position = 0L;
		return stream;
	}
}
