using System;

namespace LZ4pn
{
	public static class LZ4Codec
	{
		private class _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020
		{
			public unsafe byte* src_base;

			public unsafe byte* nextToUpdate;

			public int[] hashTable;

			public ushort[] chainTable;
		}

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A = 14;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020 = 6;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A = 16;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020 = 4;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A = 6;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020 = 8;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A = 5;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020 = 12;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A = 13;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020 = 16;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A = 65536;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020 = 65535;

		private const int _0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020 = 65535;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A = 4;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020 = 15;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A = 4;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020 = 15;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A = 8;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020 = 4;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A = 65547;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020 = 12;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A = 4096;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020 = 20;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A = 13;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020 = 8192;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A = 19;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020 = 15;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A = 32768;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020 = 17;

		private static readonly int[] _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A = new int[8]
		{
			0,
			3,
			2,
			3,
			0,
			0,
			0,
			0
		};

		private static readonly int[] _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020 = new int[8]
		{
			0,
			0,
			0,
			-1,
			0,
			1,
			2,
			3
		};

		private static readonly int[] _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A = new int[32]
		{
			0,
			0,
			3,
			0,
			3,
			1,
			3,
			0,
			3,
			2,
			2,
			1,
			3,
			2,
			0,
			1,
			3,
			3,
			1,
			2,
			2,
			2,
			2,
			0,
			3,
			1,
			2,
			0,
			1,
			0,
			1,
			1
		};

		private static readonly int[] _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020 = new int[64]
		{
			0,
			0,
			0,
			0,
			0,
			1,
			1,
			2,
			0,
			3,
			1,
			3,
			1,
			4,
			2,
			7,
			0,
			2,
			3,
			6,
			1,
			5,
			3,
			5,
			1,
			3,
			4,
			4,
			2,
			5,
			6,
			7,
			7,
			0,
			1,
			2,
			3,
			3,
			4,
			6,
			2,
			6,
			5,
			5,
			3,
			4,
			5,
			6,
			7,
			1,
			2,
			4,
			6,
			4,
			4,
			5,
			7,
			2,
			6,
			5,
			7,
			6,
			7,
			7
		};

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A = 256;

		private const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020 = 18;

		public static int MaximumOutputLength(int inputLength)
		{
			return inputLength + inputLength / 255 + 16;
		}

		internal static void _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(byte[] _0020, int _0020_000A, ref int _0020_0020, byte[] _0020_000A_000A, int _0020_000A_0020, ref int _0020_0020_000A)
		{
			if (_0020_0020 < 0)
			{
				_0020_0020 = _0020.Length - _0020_000A;
			}
			if (_0020_0020 == 0)
			{
				_0020_0020_000A = 0;
				return;
			}
			if (_0020 == null)
			{
				throw new ArgumentNullException("input");
			}
			if (_0020_000A < 0 || _0020_000A + _0020_0020 > _0020.Length)
			{
				throw new ArgumentException("inputOffset and inputLength are invalid for given input");
			}
			if (_0020_0020_000A < 0)
			{
				_0020_0020_000A = _0020_000A_000A.Length - _0020_000A_0020;
			}
			if (_0020_000A_000A == null)
			{
				throw new ArgumentNullException("output");
			}
			if (_0020_000A_0020 >= 0 && _0020_000A_0020 + _0020_0020_000A <= _0020_000A_000A.Length)
			{
				return;
			}
			throw new ArgumentException("outputOffset and outputLength are invalid for given output");
		}

		private unsafe static void _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(byte* _0020, byte* _0020_000A, int _0020_0020)
		{
			while (_0020_0020 >= 8)
			{
				*(long*)_0020_000A = *(long*)_0020;
				_0020_000A += 8;
				_0020 += 8;
				_0020_0020 -= 8;
			}
			if (_0020_0020 >= 4)
			{
				*(uint*)_0020_000A = *(uint*)_0020;
				_0020_000A += 4;
				_0020 += 4;
				_0020_0020 -= 4;
			}
			if (_0020_0020 >= 2)
			{
				*(ushort*)_0020_000A = *(ushort*)_0020;
				_0020_000A += 2;
				_0020 += 2;
				_0020_0020 -= 2;
			}
			if (_0020_0020 >= 1)
			{
				*_0020_000A = *_0020;
			}
		}

		private unsafe static void _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A(byte* _0020, int _0020_000A, byte _0020_0020)
		{
			if (_0020_000A >= 8)
			{
				ulong num = _0020_0020;
				num |= num << 8;
				num |= num << 16;
				num |= num << 32;
				do
				{
					*(ulong*)_0020 = num;
					_0020 += 8;
					_0020_000A -= 8;
				}
				while (_0020_000A >= 8);
			}
			while (_0020_000A-- > 0)
			{
				byte* intPtr = _0020;
				_0020 = intPtr + 1;
				*intPtr = _0020_0020;
			}
		}

		public unsafe static int Encode32(byte* input, byte* output, int inputLength, int outputLength)
		{
			if (inputLength < 65547)
			{
				fixed (ushort* _0020 = &(new ushort[8192])[0])
				{
					return _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020(_0020, input, output, inputLength, outputLength);
				}
			}
			fixed (byte** _00202 = &(new byte*[4096])[0])
			{
				return _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A(_00202, input, output, inputLength, outputLength);
			}
		}

		public unsafe static int Encode32(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(input, inputOffset, ref inputLength, output, outputOffset, ref outputLength);
			if (outputLength == 0)
			{
				return 0;
			}
			fixed (byte* ptr = &input[inputOffset])
			{
				byte* input2 = ptr;
				fixed (byte* output2 = &output[outputOffset])
				{
					return Encode32(input2, output2, inputLength, outputLength);
				}
			}
		}

		public static byte[] Encode32(byte[] input, int inputOffset, int inputLength)
		{
			if (inputLength < 0)
			{
				inputLength = input.Length - inputOffset;
			}
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (inputOffset < 0 || inputOffset + inputLength > input.Length)
			{
				throw new ArgumentException("inputOffset and inputLength are invalid for given input");
			}
			byte[] array = new byte[MaximumOutputLength(inputLength)];
			int num = Encode32(input, inputOffset, inputLength, array, 0, array.Length);
			if (num != array.Length)
			{
				if (num < 0)
				{
					throw new InvalidOperationException("Compression has been corrupted");
				}
				byte[] array2 = new byte[num];
				Buffer.BlockCopy(array, 0, array2, 0, num);
				return array2;
			}
			return array;
		}

		public unsafe static int Decode32(byte* input, int inputLength, byte* output, int outputLength, bool knownOutputLength)
		{
			if (knownOutputLength)
			{
				if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A(input, output, outputLength) != inputLength)
				{
					throw new ArgumentException("LZ4 block is corrupted, or invalid length has been given.");
				}
				return outputLength;
			}
			int num = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020(input, output, inputLength, outputLength);
			if (num < 0)
			{
				throw new ArgumentException("LZ4 block is corrupted, or invalid length has been given.");
			}
			return num;
		}

		public unsafe static int Decode32(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength, bool knownOutputLength)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(input, inputOffset, ref inputLength, output, outputOffset, ref outputLength);
			if (outputLength == 0)
			{
				return 0;
			}
			fixed (byte* ptr = &input[inputOffset])
			{
				byte* input2 = ptr;
				fixed (byte* output2 = &output[outputOffset])
				{
					return Decode32(input2, inputLength, output2, outputLength, knownOutputLength);
				}
			}
		}

		public static byte[] Decode32(byte[] input, int inputOffset, int inputLength, int outputLength)
		{
			if (inputLength < 0)
			{
				inputLength = input.Length - inputOffset;
			}
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (inputOffset < 0 || inputOffset + inputLength > input.Length)
			{
				throw new ArgumentException("inputOffset and inputLength are invalid for given input");
			}
			byte[] array = new byte[outputLength];
			if (Decode32(input, inputOffset, inputLength, array, 0, outputLength, knownOutputLength: true) != outputLength)
			{
				throw new ArgumentException("outputLength is not valid");
			}
			return array;
		}

		public unsafe static int Encode64(byte* input, byte* output, int inputLength, int outputLength)
		{
			if (inputLength < 65547)
			{
				fixed (ushort* _0020 = &(new ushort[8192])[0])
				{
					return _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020(_0020, input, output, inputLength, outputLength);
				}
			}
			fixed (uint* _00202 = &(new uint[4096])[0])
			{
				return _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A(_00202, input, output, inputLength, outputLength);
			}
		}

		public unsafe static int Encode64(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(input, inputOffset, ref inputLength, output, outputOffset, ref outputLength);
			if (outputLength == 0)
			{
				return 0;
			}
			fixed (byte* ptr = &input[inputOffset])
			{
				byte* input2 = ptr;
				fixed (byte* output2 = &output[outputOffset])
				{
					return Encode64(input2, output2, inputLength, outputLength);
				}
			}
		}

		public static byte[] Encode64(byte[] input, int inputOffset, int inputLength)
		{
			if (inputLength < 0)
			{
				inputLength = input.Length - inputOffset;
			}
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (inputOffset < 0 || inputOffset + inputLength > input.Length)
			{
				throw new ArgumentException("inputOffset and inputLength are invalid for given input");
			}
			byte[] array = new byte[MaximumOutputLength(inputLength)];
			int num = Encode64(input, inputOffset, inputLength, array, 0, array.Length);
			if (num != array.Length)
			{
				if (num < 0)
				{
					throw new InvalidOperationException("Compression has been corrupted");
				}
				byte[] array2 = new byte[num];
				Buffer.BlockCopy(array, 0, array2, 0, num);
				return array2;
			}
			return array;
		}

		public unsafe static int Decode64(byte* input, int inputLength, byte* output, int outputLength, bool knownOutputLength)
		{
			if (knownOutputLength)
			{
				if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(input, output, outputLength) != inputLength)
				{
					throw new ArgumentException("LZ4 block is corrupted, or invalid length has been given.");
				}
				return outputLength;
			}
			int num = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(input, output, inputLength, outputLength);
			if (num < 0)
			{
				throw new ArgumentException("LZ4 block is corrupted, or invalid length has been given.");
			}
			return num;
		}

		public unsafe static int Decode64(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength, bool knownOutputLength)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(input, inputOffset, ref inputLength, output, outputOffset, ref outputLength);
			if (outputLength == 0)
			{
				return 0;
			}
			fixed (byte* ptr = &input[inputOffset])
			{
				byte* input2 = ptr;
				fixed (byte* output2 = &output[outputOffset])
				{
					return Decode64(input2, inputLength, output2, outputLength, knownOutputLength);
				}
			}
		}

		public static byte[] Decode64(byte[] input, int inputOffset, int inputLength, int outputLength)
		{
			if (inputLength < 0)
			{
				inputLength = input.Length - inputOffset;
			}
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (inputOffset < 0 || inputOffset + inputLength > input.Length)
			{
				throw new ArgumentException("inputOffset and inputLength are invalid for given input");
			}
			byte[] array = new byte[outputLength];
			if (Decode64(input, inputOffset, inputLength, array, 0, outputLength, knownOutputLength: true) != outputLength)
			{
				throw new ArgumentException("outputLength is not valid");
			}
			return array;
		}

		private unsafe static _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020 _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020(byte* _0020)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020 obj = new _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020
			{
				hashTable = new int[32768],
				chainTable = new ushort[65536]
			};
			fixed (ushort* _00202 = &obj.chainTable[0])
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A((byte*)_00202, 131072, byte.MaxValue);
			}
			obj.src_base = _0020;
			obj.nextToUpdate = _0020 + 1;
			return obj;
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A(byte* _0020, byte* _0020_000A, int _0020_0020, int _0020_000A_000A)
		{
			return _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020(_0020), _0020, _0020_000A, _0020_0020, _0020_000A_000A);
		}

		public unsafe static int Encode32HC(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			if (inputLength == 0)
			{
				return 0;
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(input, inputOffset, ref inputLength, output, outputOffset, ref outputLength);
			fixed (byte* ptr = &input[inputOffset])
			{
				byte* _0020 = ptr;
				fixed (byte* _0020_000A = &output[outputOffset])
				{
					int num = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A(_0020, _0020_000A, inputLength, outputLength);
					if (num > 0)
					{
						return num;
					}
					return -1;
				}
			}
		}

		public static byte[] Encode32HC(byte[] input, int inputOffset, int inputLength)
		{
			if (inputLength == 0)
			{
				return new byte[0];
			}
			int num = MaximumOutputLength(inputLength);
			byte[] array = new byte[num];
			int num2 = Encode32HC(input, inputOffset, inputLength, array, 0, num);
			if (num2 < 0)
			{
				throw new ArgumentException("Provided data seems to be corrupted.");
			}
			if (num2 != num)
			{
				byte[] array2 = new byte[num2];
				Buffer.BlockCopy(array, 0, array2, 0, num2);
				array = array2;
			}
			return array;
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020(byte* _0020, byte* _0020_000A, int _0020_0020, int _0020_000A_000A)
		{
			return _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020(_0020), _0020, _0020_000A, _0020_0020, _0020_000A_000A);
		}

		public unsafe static int Encode64HC(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			if (inputLength == 0)
			{
				return 0;
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(input, inputOffset, ref inputLength, output, outputOffset, ref outputLength);
			fixed (byte* ptr = &input[inputOffset])
			{
				byte* _0020 = ptr;
				fixed (byte* _0020_000A = &output[outputOffset])
				{
					int num = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020(_0020, _0020_000A, inputLength, outputLength);
					if (num > 0)
					{
						return num;
					}
					return -1;
				}
			}
		}

		public static byte[] Encode64HC(byte[] input, int inputOffset, int inputLength)
		{
			if (inputLength == 0)
			{
				return new byte[0];
			}
			int num = MaximumOutputLength(inputLength);
			byte[] array = new byte[num];
			int num2 = Encode64HC(input, inputOffset, inputLength, array, 0, num);
			if (num2 < 0)
			{
				throw new ArgumentException("Provided data seems to be corrupted.");
			}
			if (num2 != num)
			{
				byte[] array2 = new byte[num2];
				Buffer.BlockCopy(array, 0, array2, 0, num2);
				array = array2;
			}
			return array;
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A(byte** _0020, byte* _0020_000A, byte* _0020_0020, int _0020_000A_000A, int _0020_000A_0020)
		{
			fixed (int* ptr14 = &_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A[0])
			{
				byte* ptr = _0020_000A;
				byte* ptr2 = _0020_000A + _0020_000A_000A;
				byte* ptr3 = ptr2 - 12;
				byte* ptr4 = _0020_0020;
				byte* ptr5 = ptr4 + _0020_000A_0020;
				byte* ptr6 = ptr2 - 5;
				byte* ptr7 = ptr6 - 1;
				byte* ptr8 = ptr6 - 3;
				byte* ptr9 = ptr5 - 6;
				byte* ptr10 = ptr5 - 8;
				if (_0020_000A_000A >= 13)
				{
					_0020[(uint)((int)(*(uint*)_0020_000A) * -1640531535) >> 20] = _0020_000A;
					byte* ptr11 = _0020_000A + 1;
					uint num = (uint)((int)(*(uint*)ptr11) * -1640531535) >> 20;
					while (true)
					{
						int num2 = 67;
						byte* ptr12 = ptr11;
						byte* ptr13;
						while (true)
						{
							uint num3 = num;
							int num5 = num2++ >> 6;
							ptr11 = ptr12;
							ptr12 = ptr11 + num5;
							if (ptr12 > ptr3)
							{
								break;
							}
							num = (uint)((int)(*(uint*)ptr12) * -1640531535) >> 20;
							ptr13 = _0020[num3];
							_0020[num3] = ptr11;
							if (ptr13 < ptr11 - 65535 || *(uint*)ptr13 != *(uint*)ptr11)
							{
								continue;
							}
							goto IL_00ef;
						}
						break;
						IL_01cb:
						byte* ptr15;
						int num7;
						while (true)
						{
							*(ushort*)ptr4 = (ushort)(ptr11 - ptr13);
							ptr4 += 2;
							ptr11 += 4;
							ptr13 += 4;
							ptr = ptr11;
							while (true)
							{
								if (ptr11 >= ptr8)
								{
									if (ptr11 < ptr7 && *(ushort*)ptr13 == *(ushort*)ptr11)
									{
										ptr11 += 2;
										ptr13 += 2;
									}
									if (ptr11 < ptr6 && *ptr13 == *ptr11)
									{
										ptr11++;
									}
									break;
								}
								int num6 = *(int*)ptr13 ^ *(int*)ptr11;
								if (num6 != 0)
								{
									ptr11 += ptr14[(uint)((num6 & -num6) * 125613361) >> 27];
									break;
								}
								ptr11 += 4;
								ptr13 += 4;
							}
							num7 = (int)(ptr11 - ptr);
							if (ptr4 + (num7 >> 8) > ptr9)
							{
								return 0;
							}
							if (num7 >= 15)
							{
								byte* intPtr = ptr15;
								*intPtr = (byte)(*intPtr + 15);
								for (num7 -= 15; num7 > 509; num7 -= 510)
								{
									byte* intPtr2 = ptr4;
									ptr4 = intPtr2 + 1;
									*intPtr2 = byte.MaxValue;
									byte* intPtr3 = ptr4;
									ptr4 = intPtr3 + 1;
									*intPtr3 = byte.MaxValue;
								}
								if (num7 > 254)
								{
									num7 -= 255;
									byte* intPtr4 = ptr4;
									ptr4 = intPtr4 + 1;
									*intPtr4 = byte.MaxValue;
								}
								byte* intPtr5 = ptr4;
								ptr4 = intPtr5 + 1;
								*intPtr5 = (byte)num7;
							}
							else
							{
								byte* intPtr6 = ptr15;
								*intPtr6 = (byte)(*intPtr6 + (byte)num7);
							}
							if (ptr11 > ptr3)
							{
								break;
							}
							_0020[(uint)((int)(*(uint*)(ptr11 - 2)) * -1640531535) >> 20] = ptr11 - 2;
							uint num3 = (uint)((int)(*(uint*)ptr11) * -1640531535) >> 20;
							ptr13 = _0020[num3];
							_0020[num3] = ptr11;
							if (ptr13 > ptr11 - 65536 && *(uint*)ptr13 == *(uint*)ptr11)
							{
								byte* intPtr7 = ptr4;
								ptr4 = intPtr7 + 1;
								ptr15 = intPtr7;
								*ptr15 = 0;
								continue;
							}
							goto IL_0359;
						}
						ptr = ptr11;
						break;
						IL_00ef:
						while (ptr11 > ptr && ptr13 > _0020_000A && ptr11[-1] == ptr13[-1])
						{
							ptr11--;
							ptr13--;
						}
						num7 = (int)(ptr11 - ptr);
						byte* intPtr8 = ptr4;
						ptr4 = intPtr8 + 1;
						ptr15 = intPtr8;
						if (ptr4 + num7 + (num7 >> 8) > ptr10)
						{
							return 0;
						}
						if (num7 >= 15)
						{
							int num8 = num7 - 15;
							*ptr15 = 240;
							if (num8 > 254)
							{
								do
								{
									byte* intPtr9 = ptr4;
									ptr4 = intPtr9 + 1;
									*intPtr9 = byte.MaxValue;
									num8 -= 255;
								}
								while (num8 > 254);
								byte* intPtr10 = ptr4;
								ptr4 = intPtr10 + 1;
								*intPtr10 = (byte)num8;
								_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ptr, ptr4, num7);
								ptr4 += num7;
								goto IL_01cb;
							}
							byte* intPtr11 = ptr4;
							ptr4 = intPtr11 + 1;
							*intPtr11 = (byte)num8;
						}
						else
						{
							*ptr15 = (byte)(num7 << 4);
						}
						byte* ptr16 = ptr4 + num7;
						do
						{
							*(uint*)ptr4 = *(uint*)ptr;
							ptr4 += 4;
							ptr += 4;
							*(uint*)ptr4 = *(uint*)ptr;
							ptr4 += 4;
							ptr += 4;
						}
						while (ptr4 < ptr16);
						ptr4 = ptr16;
						goto IL_01cb;
						IL_0359:
						byte* intPtr12 = ptr11;
						ptr11 = intPtr12 + 1;
						ptr = intPtr12;
						num = (uint)((int)(*(uint*)ptr11) * -1640531535) >> 20;
					}
				}
				int num9 = (int)(ptr2 - ptr);
				if (ptr4 + num9 + 1 + (num9 + 255 - 15) / 255 > ptr5)
				{
					return 0;
				}
				if (num9 >= 15)
				{
					byte* intPtr13 = ptr4;
					ptr4 = intPtr13 + 1;
					*intPtr13 = 240;
					for (num9 -= 15; num9 > 254; num9 -= 255)
					{
						byte* intPtr14 = ptr4;
						ptr4 = intPtr14 + 1;
						*intPtr14 = byte.MaxValue;
					}
					byte* intPtr15 = ptr4;
					ptr4 = intPtr15 + 1;
					*intPtr15 = (byte)num9;
				}
				else
				{
					byte* intPtr16 = ptr4;
					ptr4 = intPtr16 + 1;
					*intPtr16 = (byte)(num9 << 4);
				}
				_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ptr, ptr4, (int)(ptr2 - ptr));
				ptr4 += ptr2 - ptr;
				return (int)(ptr4 - _0020_0020);
			}
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020(ushort* _0020, byte* _0020_000A, byte* _0020_0020, int _0020_000A_000A, int _0020_000A_0020)
		{
			fixed (int* ptr14 = &_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A[0])
			{
				byte* ptr = _0020_000A;
				byte* ptr2 = _0020_000A + _0020_000A_000A;
				byte* ptr3 = ptr2 - 12;
				byte* ptr4 = _0020_0020;
				byte* ptr5 = ptr4 + _0020_000A_0020;
				byte* ptr6 = ptr2 - 5;
				byte* ptr7 = ptr6 - 1;
				byte* ptr8 = ptr6 - 3;
				byte* ptr9 = ptr5 - 6;
				byte* ptr10 = ptr5 - 8;
				if (_0020_000A_000A >= 13)
				{
					byte* ptr11 = _0020_000A + 1;
					uint num = (uint)((int)(*(uint*)ptr11) * -1640531535) >> 19;
					while (true)
					{
						int num2 = 67;
						byte* ptr12 = ptr11;
						byte* ptr13;
						while (true)
						{
							uint num3 = num;
							int num5 = num2++ >> 6;
							ptr11 = ptr12;
							ptr12 = ptr11 + num5;
							if (ptr12 > ptr3)
							{
								break;
							}
							num = (uint)((int)(*(uint*)ptr12) * -1640531535) >> 19;
							ptr13 = _0020_000A + (int)_0020[num3];
							_0020[num3] = (ushort)(ptr11 - _0020_000A);
							if (*(uint*)ptr13 != *(uint*)ptr11)
							{
								continue;
							}
							goto IL_00ce;
						}
						break;
						IL_01aa:
						byte* ptr15;
						while (true)
						{
							*(ushort*)ptr4 = (ushort)(ptr11 - ptr13);
							ptr4 += 2;
							ptr11 += 4;
							ptr13 += 4;
							ptr = ptr11;
							while (true)
							{
								if (ptr11 >= ptr8)
								{
									if (ptr11 < ptr7 && *(ushort*)ptr13 == *(ushort*)ptr11)
									{
										ptr11 += 2;
										ptr13 += 2;
									}
									if (ptr11 < ptr6 && *ptr13 == *ptr11)
									{
										ptr11++;
									}
									break;
								}
								int num6 = *(int*)ptr13 ^ *(int*)ptr11;
								if (num6 != 0)
								{
									ptr11 += ptr14[(uint)((num6 & -num6) * 125613361) >> 27];
									break;
								}
								ptr11 += 4;
								ptr13 += 4;
							}
							int num7 = (int)(ptr11 - ptr);
							if (ptr4 + (num7 >> 8) > ptr9)
							{
								return 0;
							}
							if (num7 >= 15)
							{
								byte* intPtr = ptr15;
								*intPtr = (byte)(*intPtr + 15);
								for (num7 -= 15; num7 > 509; num7 -= 510)
								{
									byte* intPtr2 = ptr4;
									ptr4 = intPtr2 + 1;
									*intPtr2 = byte.MaxValue;
									byte* intPtr3 = ptr4;
									ptr4 = intPtr3 + 1;
									*intPtr3 = byte.MaxValue;
								}
								if (num7 > 254)
								{
									num7 -= 255;
									byte* intPtr4 = ptr4;
									ptr4 = intPtr4 + 1;
									*intPtr4 = byte.MaxValue;
								}
								byte* intPtr5 = ptr4;
								ptr4 = intPtr5 + 1;
								*intPtr5 = (byte)num7;
							}
							else
							{
								byte* intPtr6 = ptr15;
								*intPtr6 = (byte)(*intPtr6 + (byte)num7);
							}
							if (ptr11 > ptr3)
							{
								break;
							}
							_0020[(uint)((int)(*(uint*)(ptr11 - 2)) * -1640531535) >> 19] = (ushort)(ptr11 - 2 - _0020_000A);
							uint num3 = (uint)((int)(*(uint*)ptr11) * -1640531535) >> 19;
							ptr13 = _0020_000A + (int)_0020[num3];
							_0020[num3] = (ushort)(ptr11 - _0020_000A);
							if (*(uint*)ptr13 == *(uint*)ptr11)
							{
								byte* intPtr7 = ptr4;
								ptr4 = intPtr7 + 1;
								ptr15 = intPtr7;
								*ptr15 = 0;
								continue;
							}
							goto IL_032c;
						}
						ptr = ptr11;
						break;
						IL_00ce:
						while (ptr11 > ptr && ptr13 > _0020_000A && ptr11[-1] == ptr13[-1])
						{
							ptr11--;
							ptr13--;
						}
						int num8 = (int)(ptr11 - ptr);
						byte* intPtr8 = ptr4;
						ptr4 = intPtr8 + 1;
						ptr15 = intPtr8;
						if (ptr4 + num8 + (num8 >> 8) > ptr10)
						{
							return 0;
						}
						if (num8 >= 15)
						{
							int num7 = num8 - 15;
							*ptr15 = 240;
							if (num7 > 254)
							{
								do
								{
									byte* intPtr9 = ptr4;
									ptr4 = intPtr9 + 1;
									*intPtr9 = byte.MaxValue;
									num7 -= 255;
								}
								while (num7 > 254);
								byte* intPtr10 = ptr4;
								ptr4 = intPtr10 + 1;
								*intPtr10 = (byte)num7;
								_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ptr, ptr4, num8);
								ptr4 += num8;
								goto IL_01aa;
							}
							byte* intPtr11 = ptr4;
							ptr4 = intPtr11 + 1;
							*intPtr11 = (byte)num7;
						}
						else
						{
							*ptr15 = (byte)(num8 << 4);
						}
						byte* ptr16 = ptr4 + num8;
						do
						{
							*(uint*)ptr4 = *(uint*)ptr;
							ptr4 += 4;
							ptr += 4;
							*(uint*)ptr4 = *(uint*)ptr;
							ptr4 += 4;
							ptr += 4;
						}
						while (ptr4 < ptr16);
						ptr4 = ptr16;
						goto IL_01aa;
						IL_032c:
						byte* intPtr12 = ptr11;
						ptr11 = intPtr12 + 1;
						ptr = intPtr12;
						num = (uint)((int)(*(uint*)ptr11) * -1640531535) >> 19;
					}
				}
				int num9 = (int)(ptr2 - ptr);
				if (ptr4 + num9 + 1 + (num9 - 15 + 255) / 255 > ptr5)
				{
					return 0;
				}
				if (num9 >= 15)
				{
					byte* intPtr13 = ptr4;
					ptr4 = intPtr13 + 1;
					*intPtr13 = 240;
					for (num9 -= 15; num9 > 254; num9 -= 255)
					{
						byte* intPtr14 = ptr4;
						ptr4 = intPtr14 + 1;
						*intPtr14 = byte.MaxValue;
					}
					byte* intPtr15 = ptr4;
					ptr4 = intPtr15 + 1;
					*intPtr15 = (byte)num9;
				}
				else
				{
					byte* intPtr16 = ptr4;
					ptr4 = intPtr16 + 1;
					*intPtr16 = (byte)(num9 << 4);
				}
				_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ptr, ptr4, (int)(ptr2 - ptr));
				ptr4 += ptr2 - ptr;
				return (int)(ptr4 - _0020_0020);
			}
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A(byte* _0020, byte* _0020_000A, int _0020_0020)
		{
			fixed (int* ptr9 = &_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A[0])
			{
				byte* ptr = _0020;
				byte* ptr2 = _0020_000A;
				byte* ptr3 = ptr2 + _0020_0020;
				byte* ptr4 = ptr3 - 5;
				byte* ptr5 = ptr3 - 8;
				byte* ptr6 = ptr3 - 8;
				while (true)
				{
					byte* intPtr = ptr;
					ptr = intPtr + 1;
					uint num = *intPtr;
					int num2;
					if ((num2 = (int)(num >> 4)) == 15)
					{
						int num3;
						while (true)
						{
							byte* intPtr2 = ptr;
							ptr = intPtr2 + 1;
							if ((num3 = *intPtr2) != 255)
							{
								break;
							}
							num2 += 255;
						}
						num2 += num3;
					}
					byte* ptr7 = ptr2 + num2;
					if (ptr7 > ptr5)
					{
						if (ptr7 != ptr3)
						{
							break;
						}
						_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ptr, ptr2, num2);
						ptr += num2;
						return (int)(ptr - _0020);
					}
					do
					{
						*(uint*)ptr2 = *(uint*)ptr;
						ptr2 += 4;
						ptr += 4;
						*(uint*)ptr2 = *(uint*)ptr;
						ptr2 += 4;
						ptr += 4;
					}
					while (ptr2 < ptr7);
					ptr -= ptr2 - ptr7;
					ptr2 = ptr7;
					byte* ptr8 = ptr7 - (int)(*(ushort*)ptr);
					ptr += 2;
					if (ptr8 < _0020_000A)
					{
						break;
					}
					if ((num2 = (int)(num & 0xF)) == 15)
					{
						while (*ptr == byte.MaxValue)
						{
							ptr++;
							num2 += 255;
						}
						int num4 = num2;
						byte* intPtr3 = ptr;
						ptr = intPtr3 + 1;
						num2 = num4 + *intPtr3;
					}
					if (ptr2 - ptr8 < 4)
					{
						*ptr2 = *ptr8;
						ptr2[1] = ptr8[1];
						ptr2[2] = ptr8[2];
						ptr2[3] = ptr8[3];
						ptr2 += 4;
						ptr8 += 4;
						ptr8 -= ptr9[ptr2 - ptr8];
						*(uint*)ptr2 = *(uint*)ptr8;
						ptr2 = ptr2;
						ptr8 = ptr8;
					}
					else
					{
						*(uint*)ptr2 = *(uint*)ptr8;
						ptr2 += 4;
						ptr8 += 4;
					}
					ptr7 = ptr2 + num2;
					if (ptr7 > ptr6)
					{
						if (ptr7 > ptr4)
						{
							break;
						}
						do
						{
							*(uint*)ptr2 = *(uint*)ptr8;
							ptr2 += 4;
							ptr8 += 4;
							*(uint*)ptr2 = *(uint*)ptr8;
							ptr2 += 4;
							ptr8 += 4;
						}
						while (ptr2 < ptr5);
						while (ptr2 < ptr7)
						{
							byte* intPtr4 = ptr2;
							ptr2 = intPtr4 + 1;
							byte* intPtr5 = ptr8;
							ptr8 = intPtr5 + 1;
							*intPtr4 = *intPtr5;
						}
						ptr2 = ptr7;
					}
					else
					{
						do
						{
							*(uint*)ptr2 = *(uint*)ptr8;
							ptr2 += 4;
							ptr8 += 4;
							*(uint*)ptr2 = *(uint*)ptr8;
							ptr2 += 4;
							ptr8 += 4;
						}
						while (ptr2 < ptr7);
						ptr2 = ptr7;
					}
				}
				return (int)(-(ptr - _0020));
			}
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020(byte* _0020, byte* _0020_000A, int _0020_0020, int _0020_000A_000A)
		{
			fixed (int* ptr13 = &_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A[0])
			{
				byte* ptr = _0020;
				byte* ptr2 = ptr + _0020_0020;
				byte* ptr3 = _0020_000A;
				byte* ptr4 = ptr3 + _0020_000A_000A;
				byte* ptr5 = ptr2 - 8;
				byte* ptr6 = ptr2 - 6;
				byte* ptr7 = ptr4 - 8;
				byte* ptr8 = ptr4 - 8;
				byte* ptr9 = ptr4 - 5;
				byte* ptr10 = ptr4 - 12;
				if (ptr != ptr2)
				{
					while (true)
					{
						byte* intPtr = ptr;
						ptr = intPtr + 1;
						uint num = *intPtr;
						int num2;
						if ((num2 = (int)(num >> 4)) == 15)
						{
							int num3 = 255;
							while (ptr < ptr2 && num3 == 255)
							{
								byte* intPtr2 = ptr;
								ptr = intPtr2 + 1;
								num3 = *intPtr2;
								num2 += num3;
							}
						}
						byte* ptr11 = ptr3 + num2;
						if (ptr11 > ptr10 || ptr + num2 > ptr5)
						{
							if (ptr11 > ptr4 || ptr + num2 != ptr2)
							{
								break;
							}
							_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ptr, ptr3, num2);
							ptr3 += num2;
							return (int)(ptr3 - _0020_000A);
						}
						do
						{
							*(uint*)ptr3 = *(uint*)ptr;
							ptr3 += 4;
							ptr += 4;
							*(uint*)ptr3 = *(uint*)ptr;
							ptr3 += 4;
							ptr += 4;
						}
						while (ptr3 < ptr11);
						ptr -= ptr3 - ptr11;
						ptr3 = ptr11;
						byte* ptr12 = ptr11 - (int)(*(ushort*)ptr);
						ptr += 2;
						if (ptr12 < _0020_000A)
						{
							break;
						}
						if ((num2 = (int)(num & 0xF)) == 15)
						{
							while (ptr < ptr6)
							{
								byte* intPtr3 = ptr;
								ptr = intPtr3 + 1;
								int num4 = *intPtr3;
								num2 += num4;
								if (num4 != 255)
								{
									break;
								}
							}
						}
						if (ptr3 - ptr12 < 4)
						{
							*ptr3 = *ptr12;
							ptr3[1] = ptr12[1];
							ptr3[2] = ptr12[2];
							ptr3[3] = ptr12[3];
							ptr3 += 4;
							ptr12 += 4;
							ptr12 -= ptr13[ptr3 - ptr12];
							*(uint*)ptr3 = *(uint*)ptr12;
							ptr3 = ptr3;
							ptr12 = ptr12;
						}
						else
						{
							*(uint*)ptr3 = *(uint*)ptr12;
							ptr3 += 4;
							ptr12 += 4;
						}
						ptr11 = ptr3 + num2;
						if (ptr11 > ptr8)
						{
							if (ptr11 > ptr9)
							{
								break;
							}
							do
							{
								*(uint*)ptr3 = *(uint*)ptr12;
								ptr3 += 4;
								ptr12 += 4;
								*(uint*)ptr3 = *(uint*)ptr12;
								ptr3 += 4;
								ptr12 += 4;
							}
							while (ptr3 < ptr7);
							while (ptr3 < ptr11)
							{
								byte* intPtr4 = ptr3;
								ptr3 = intPtr4 + 1;
								byte* intPtr5 = ptr12;
								ptr12 = intPtr5 + 1;
								*intPtr4 = *intPtr5;
							}
							ptr3 = ptr11;
						}
						else
						{
							do
							{
								*(uint*)ptr3 = *(uint*)ptr12;
								ptr3 += 4;
								ptr12 += 4;
								*(uint*)ptr3 = *(uint*)ptr12;
								ptr3 += 4;
								ptr12 += 4;
							}
							while (ptr3 < ptr11);
							ptr3 = ptr11;
						}
					}
				}
				return (int)(-(ptr - _0020));
			}
		}

		private unsafe static void _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020 _0020, byte* _0020_000A)
		{
			fixed (ushort* ptr2 = _0020.chainTable)
			{
				fixed (int* ptr = _0020.hashTable)
				{
					byte* src_base = _0020.src_base;
					while (_0020.nextToUpdate < _0020_000A)
					{
						byte* nextToUpdate = _0020.nextToUpdate;
						int num = (int)(nextToUpdate - (ptr[(uint)((int)(*(uint*)nextToUpdate) * -1640531535) >> 17] + src_base));
						if (num > 65535)
						{
							num = 65535;
						}
						ptr2[(int)nextToUpdate & 0xFFFF] = (ushort)num;
						ptr[(uint)((int)(*(uint*)nextToUpdate) * -1640531535) >> 17] = (int)(nextToUpdate - src_base);
						_0020.nextToUpdate++;
					}
				}
			}
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020(byte* _0020, byte* _0020_000A, byte* _0020_0020)
		{
			fixed (int* ptr2 = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A)
			{
				byte* ptr = _0020;
				while (ptr < _0020_0020 - 3)
				{
					int num = *(int*)_0020_000A ^ *(int*)ptr;
					if (num != 0)
					{
						ptr += ptr2[(uint)((num & -num) * 125613361) >> 27];
						return (int)(ptr - _0020);
					}
					ptr += 4;
					_0020_000A += 4;
				}
				if (ptr < _0020_0020 - 1 && *(ushort*)_0020_000A == *(ushort*)ptr)
				{
					ptr += 2;
					_0020_000A += 2;
				}
				if (ptr < _0020_0020 && *_0020_000A == *ptr)
				{
					ptr++;
				}
				return (int)(ptr - _0020);
			}
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020 _0020, byte* _0020_000A, byte* _0020_0020, ref byte* _0020_000A_000A)
		{
			fixed (ushort* ptr3 = _0020.chainTable)
			{
				fixed (int* ptr = _0020.hashTable)
				{
					byte* src_base = _0020.src_base;
					int num = 256;
					int num2 = 0;
					int num3 = 0;
					ushort num4 = 0;
					_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A(_0020, _0020_000A);
					byte* ptr2 = ptr[(uint)((int)(*(uint*)_0020_000A) * -1640531535) >> 17] + src_base;
					if (ptr2 >= _0020_000A - 4)
					{
						if (*(uint*)ptr2 == *(uint*)_0020_000A)
						{
							num4 = (ushort)(_0020_000A - ptr2);
							num2 = (num3 = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020(_0020_000A + 4, ptr2 + 4, _0020_0020) + 4);
							_0020_000A_000A = ptr2;
						}
						ptr2 -= (int)ptr3[(int)ptr2 & 0xFFFF];
					}
					while (ptr2 >= _0020_000A - 65535 && num != 0)
					{
						num--;
						if (ptr2[num3] == _0020_000A[num3] && *(uint*)ptr2 == *(uint*)_0020_000A)
						{
							int num5 = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020(_0020_000A + 4, ptr2 + 4, _0020_0020) + 4;
							if (num5 > num3)
							{
								num3 = num5;
								_0020_000A_000A = ptr2;
							}
						}
						ptr2 -= (int)ptr3[(int)ptr2 & 0xFFFF];
					}
					if (num2 != 0)
					{
						byte* ptr4 = _0020_000A;
						byte* ptr5;
						for (ptr5 = _0020_000A + num2 - 3; ptr4 < ptr5 - (int)num4; ptr4++)
						{
							ptr3[(int)ptr4 & 0xFFFF] = num4;
						}
						do
						{
							ptr3[(int)ptr4 & 0xFFFF] = num4;
							ptr[(uint)((int)(*(uint*)ptr4) * -1640531535) >> 17] = (int)(ptr4 - src_base);
							ptr4++;
						}
						while (ptr4 < ptr5);
						_0020.nextToUpdate = ptr5;
					}
					return num3;
				}
			}
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020 _0020, byte* _0020_000A, byte* _0020_0020, byte* _0020_000A_000A, int _0020_000A_0020, ref byte* _0020_0020_000A, ref byte* _0020_0020_0020)
		{
			fixed (ushort* ptr7 = _0020.chainTable)
			{
				fixed (int* ptr = _0020.hashTable)
				{
					fixed (int* ptr6 = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A)
					{
						byte* src_base = _0020.src_base;
						int num = 256;
						int num2 = (int)(_0020_000A - _0020_0020);
						_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A(_0020, _0020_000A);
						byte* ptr2 = ptr[(uint)((int)(*(uint*)_0020_000A) * -1640531535) >> 17] + src_base;
						while (ptr2 >= _0020_000A - 65535 && num != 0)
						{
							num--;
							if (_0020_0020[_0020_000A_0020] == (ptr2 - num2)[_0020_000A_0020] && *(uint*)ptr2 == *(uint*)_0020_000A)
							{
								byte* ptr3 = ptr2 + 4;
								byte* ptr4 = _0020_000A + 4;
								byte* ptr5 = _0020_000A;
								while (true)
								{
									if (ptr4 >= _0020_000A_000A - 3)
									{
										if (ptr4 < _0020_000A_000A - 1 && *(ushort*)ptr3 == *(ushort*)ptr4)
										{
											ptr4 += 2;
											ptr3 += 2;
										}
										if (ptr4 < _0020_000A_000A && *ptr3 == *ptr4)
										{
											ptr4++;
										}
										break;
									}
									int num3 = *(int*)ptr3 ^ *(int*)ptr4;
									if (num3 != 0)
									{
										ptr4 += ptr6[(uint)((num3 & -num3) * 125613361) >> 27];
										break;
									}
									ptr4 += 4;
									ptr3 += 4;
								}
								ptr3 = ptr2;
								while (ptr5 > _0020_0020 && ptr3 > _0020.src_base && ptr5[-1] == ptr3[-1])
								{
									ptr5--;
									ptr3--;
								}
								if (ptr4 - ptr5 > _0020_000A_0020)
								{
									_0020_000A_0020 = (int)(ptr4 - ptr5);
									_0020_0020_000A = ptr3;
									_0020_0020_0020 = ptr5;
								}
							}
							ptr2 -= (int)ptr7[(int)ptr2 & 0xFFFF];
						}
						return _0020_000A_0020;
					}
				}
			}
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(ref byte* _0020, ref byte* _0020_000A, ref byte* _0020_0020, int _0020_000A_000A, byte* _0020_000A_0020, byte* _0020_0020_000A)
		{
			int num = (int)(_0020 - _0020_0020);
			byte* ptr = _0020_000A++;
			if (_0020_000A + num + 8 + (num >> 8) > _0020_0020_000A)
			{
				return 1;
			}
			int num2;
			if (num >= 15)
			{
				*ptr = 240;
				for (num2 = num - 15; num2 > 254; num2 -= 255)
				{
					*(_0020_000A++) = byte.MaxValue;
				}
				*(_0020_000A++) = (byte)num2;
			}
			else
			{
				*ptr = (byte)(num << 4);
			}
			byte* ptr2 = _0020_000A + num;
			do
			{
				*(uint*)_0020_000A = *(uint*)_0020_0020;
				_0020_000A += 4;
				_0020_0020 += 4;
				*(uint*)_0020_000A = *(uint*)_0020_0020;
				_0020_000A += 4;
				_0020_0020 += 4;
			}
			while (_0020_000A < ptr2);
			_0020_000A = ptr2;
			*(ushort*)_0020_000A = (ushort)(_0020 - _0020_000A_0020);
			_0020_000A += 2;
			num2 = _0020_000A_000A - 4;
			if (_0020_000A + 6 + (num >> 8) > _0020_0020_000A)
			{
				return 1;
			}
			if (num2 >= 15)
			{
				byte* intPtr = ptr;
				*intPtr = (byte)(*intPtr + 15);
				for (num2 -= 15; num2 > 509; num2 -= 510)
				{
					*(_0020_000A++) = byte.MaxValue;
					*(_0020_000A++) = byte.MaxValue;
				}
				if (num2 > 254)
				{
					num2 -= 255;
					*(_0020_000A++) = byte.MaxValue;
				}
				*(_0020_000A++) = (byte)num2;
			}
			else
			{
				byte* intPtr2 = ptr;
				*intPtr2 = (byte)(*intPtr2 + (byte)num2);
			}
			_0020 += _0020_000A_000A;
			_0020_0020 = _0020;
			return 0;
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020 _0020, byte* _0020_000A, byte* _0020_0020, int _0020_000A_000A, int _0020_000A_0020)
		{
			byte* ptr = _0020_000A;
			byte* ptr2 = _0020_000A + _0020_000A_000A;
			byte* ptr3 = ptr2 - 12;
			byte* ptr4 = ptr2 - 5;
			byte* ptr5 = _0020_0020;
			byte* _0020_0020_000A = ptr5 + _0020_000A_0020;
			byte* ptr6 = null;
			byte* ptr7 = null;
			byte* ptr8 = null;
			byte* ptr9 = null;
			byte* ptr10 = null;
			byte* ptr11 = _0020_000A + 1;
			while (ptr11 < ptr3)
			{
				int num = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A(_0020, ptr11, ptr4, ref ptr6);
				if (num == 0)
				{
					ptr11++;
					continue;
				}
				byte* ptr12 = ptr11;
				byte* ptr13 = ptr6;
				int num2 = num;
				while (true)
				{
					int num3 = (ptr11 + num < ptr3) ? _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020(_0020, ptr11 + num - 2, ptr11 + 1, ptr4, num, ref ptr8, ref ptr7) : num;
					if (num3 == num)
					{
						if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(ref ptr11, ref ptr5, ref ptr, num, ptr6, _0020_0020_000A) == 0)
						{
							break;
						}
						return 0;
					}
					if (ptr12 < ptr11 && ptr7 < ptr11 + num2)
					{
						ptr11 = ptr12;
						ptr6 = ptr13;
						num = num2;
					}
					if (ptr7 - ptr11 < 3)
					{
						num = num3;
						ptr11 = ptr7;
						ptr6 = ptr8;
						continue;
					}
					int num6;
					while (true)
					{
						if (ptr7 - ptr11 < 18)
						{
							int num4 = num;
							if (num4 > 18)
							{
								num4 = 18;
							}
							if (ptr11 + num4 > ptr7 + num3 - 4)
							{
								num4 = (int)(ptr7 - ptr11) + num3 - 4;
							}
							int num5 = num4 - (int)(ptr7 - ptr11);
							if (num5 > 0)
							{
								ptr7 += num5;
								ptr8 += num5;
								num3 -= num5;
							}
						}
						num6 = ((ptr7 + num3 < ptr3) ? _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020(_0020, ptr7 + num3 - 3, ptr7, ptr4, num3, ref ptr10, ref ptr9) : num3);
						if (num6 == num3)
						{
							break;
						}
						if (ptr9 < ptr11 + num + 3)
						{
							if (ptr9 < ptr11 + num)
							{
								ptr7 = ptr9;
								ptr8 = ptr10;
								num3 = num6;
								continue;
							}
							goto IL_01af;
						}
						if (ptr7 < ptr11 + num)
						{
							if (ptr7 - ptr11 < 15)
							{
								if (num > 18)
								{
									num = 18;
								}
								if (ptr11 + num > ptr7 + num3 - 4)
								{
									num = (int)(ptr7 - ptr11) + num3 - 4;
								}
								int num7 = num - (int)(ptr7 - ptr11);
								if (num7 > 0)
								{
									ptr7 += num7;
									ptr8 += num7;
									num3 -= num7;
								}
							}
							else
							{
								num = (int)(ptr7 - ptr11);
							}
						}
						if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(ref ptr11, ref ptr5, ref ptr, num, ptr6, _0020_0020_000A) != 0)
						{
							return 0;
						}
						ptr11 = ptr7;
						ptr6 = ptr8;
						num = num3;
						ptr7 = ptr9;
						ptr8 = ptr10;
						num3 = num6;
					}
					if (ptr7 < ptr11 + num)
					{
						num = (int)(ptr7 - ptr11);
					}
					if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(ref ptr11, ref ptr5, ref ptr, num, ptr6, _0020_0020_000A) != 0)
					{
						return 0;
					}
					ptr11 = ptr7;
					if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(ref ptr11, ref ptr5, ref ptr, num3, ptr8, _0020_0020_000A) == 0)
					{
						break;
					}
					return 0;
					IL_01af:
					if (ptr7 < ptr11 + num)
					{
						int num8 = (int)(ptr11 + num - ptr7);
						ptr7 += num8;
						ptr8 += num8;
						num3 -= num8;
						if (num3 < 4)
						{
							ptr7 = ptr9;
							ptr8 = ptr10;
							num3 = num6;
						}
					}
					if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(ref ptr11, ref ptr5, ref ptr, num, ptr6, _0020_0020_000A) != 0)
					{
						return 0;
					}
					ptr11 = ptr9;
					ptr6 = ptr10;
					num = num6;
					ptr12 = ptr7;
					ptr13 = ptr8;
					num2 = num3;
				}
			}
			int num9 = (int)(ptr2 - ptr);
			if (ptr5 - _0020_0020 + num9 + 1 + (num9 + 255 - 15) / 255 > (uint)_0020_000A_0020)
			{
				return 0;
			}
			if (num9 >= 15)
			{
				byte* intPtr = ptr5;
				ptr5 = intPtr + 1;
				*intPtr = 240;
				for (num9 -= 15; num9 > 254; num9 -= 255)
				{
					byte* intPtr2 = ptr5;
					ptr5 = intPtr2 + 1;
					*intPtr2 = byte.MaxValue;
				}
				byte* intPtr3 = ptr5;
				ptr5 = intPtr3 + 1;
				*intPtr3 = (byte)num9;
			}
			else
			{
				byte* intPtr4 = ptr5;
				ptr5 = intPtr4 + 1;
				*intPtr4 = (byte)(num9 << 4);
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ptr, ptr5, (int)(ptr2 - ptr));
			ptr5 += ptr2 - ptr;
			return (int)(ptr5 - _0020_0020);
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A(uint* _0020, byte* _0020_000A, byte* _0020_0020, int _0020_000A_000A, int _0020_000A_0020)
		{
			fixed (int* ptr15 = &_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020[0])
			{
				byte* ptr = _0020_000A;
				byte* ptr2 = _0020_000A + _0020_000A_000A;
				byte* ptr3 = ptr2 - 12;
				byte* ptr4 = _0020_0020;
				byte* ptr5 = ptr4 + _0020_000A_0020;
				byte* ptr6 = ptr2 - 5;
				byte* ptr7 = ptr6 - 1;
				byte* ptr8 = ptr6 - 3;
				byte* ptr9 = ptr6 - 7;
				byte* ptr10 = ptr5 - 6;
				byte* ptr11 = ptr5 - 8;
				if (_0020_000A_000A >= 13)
				{
					_0020[(uint)((int)(*(uint*)_0020_000A) * -1640531535) >> 20] = (uint)(_0020_000A - _0020_000A);
					byte* ptr12 = _0020_000A + 1;
					uint num = (uint)((int)(*(uint*)ptr12) * -1640531535) >> 20;
					while (true)
					{
						int num2 = 67;
						byte* ptr13 = ptr12;
						byte* ptr14;
						while (true)
						{
							uint num3 = num;
							int num5 = num2++ >> 6;
							ptr12 = ptr13;
							ptr13 = ptr12 + num5;
							if (ptr13 > ptr3)
							{
								break;
							}
							num = (uint)((int)(*(uint*)ptr13) * -1640531535) >> 20;
							ptr14 = _0020_000A + _0020[num3];
							_0020[num3] = (uint)(ptr12 - _0020_000A);
							if (ptr14 < ptr12 - 65535 || *(uint*)ptr14 != *(uint*)ptr12)
							{
								continue;
							}
							goto IL_00fb;
						}
						break;
						IL_01c5:
						byte* ptr16;
						int num7;
						while (true)
						{
							*(ushort*)ptr4 = (ushort)(ptr12 - ptr14);
							ptr4 += 2;
							ptr12 += 4;
							ptr14 += 4;
							ptr = ptr12;
							while (true)
							{
								if (ptr12 >= ptr9)
								{
									if (ptr12 < ptr8 && *(uint*)ptr14 == *(uint*)ptr12)
									{
										ptr12 += 4;
										ptr14 += 4;
									}
									if (ptr12 < ptr7 && *(ushort*)ptr14 == *(ushort*)ptr12)
									{
										ptr12 += 2;
										ptr14 += 2;
									}
									if (ptr12 < ptr6 && *ptr14 == *ptr12)
									{
										ptr12++;
									}
									break;
								}
								long num6 = *(long*)ptr14 ^ *(long*)ptr12;
								if (num6 != 0L)
								{
									ptr12 += ptr15[(ulong)((num6 & -num6) * 151050438428048703L) >> 58];
									break;
								}
								ptr12 += 8;
								ptr14 += 8;
							}
							num7 = (int)(ptr12 - ptr);
							if (ptr4 + (num7 >> 8) > ptr10)
							{
								return 0;
							}
							if (num7 >= 15)
							{
								byte* intPtr = ptr16;
								*intPtr = (byte)(*intPtr + 15);
								for (num7 -= 15; num7 > 509; num7 -= 510)
								{
									byte* intPtr2 = ptr4;
									ptr4 = intPtr2 + 1;
									*intPtr2 = byte.MaxValue;
									byte* intPtr3 = ptr4;
									ptr4 = intPtr3 + 1;
									*intPtr3 = byte.MaxValue;
								}
								if (num7 > 254)
								{
									num7 -= 255;
									byte* intPtr4 = ptr4;
									ptr4 = intPtr4 + 1;
									*intPtr4 = byte.MaxValue;
								}
								byte* intPtr5 = ptr4;
								ptr4 = intPtr5 + 1;
								*intPtr5 = (byte)num7;
							}
							else
							{
								byte* intPtr6 = ptr16;
								*intPtr6 = (byte)(*intPtr6 + (byte)num7);
							}
							if (ptr12 > ptr3)
							{
								break;
							}
							_0020[(uint)((int)(*(uint*)(ptr12 - 2)) * -1640531535) >> 20] = (uint)(ptr12 - 2 - _0020_000A);
							uint num3 = (uint)((int)(*(uint*)ptr12) * -1640531535) >> 20;
							ptr14 = _0020_000A + _0020[num3];
							_0020[num3] = (uint)(ptr12 - _0020_000A);
							if (ptr14 > ptr12 - 65536 && *(uint*)ptr14 == *(uint*)ptr12)
							{
								byte* intPtr7 = ptr4;
								ptr4 = intPtr7 + 1;
								ptr16 = intPtr7;
								*ptr16 = 0;
								continue;
							}
							goto IL_036f;
						}
						ptr = ptr12;
						break;
						IL_00fb:
						while (ptr12 > ptr && ptr14 > _0020_000A && ptr12[-1] == ptr14[-1])
						{
							ptr12--;
							ptr14--;
						}
						num7 = (int)(ptr12 - ptr);
						byte* intPtr8 = ptr4;
						ptr4 = intPtr8 + 1;
						ptr16 = intPtr8;
						if (ptr4 + num7 + (num7 >> 8) > ptr11)
						{
							return 0;
						}
						if (num7 >= 15)
						{
							int num8 = num7 - 15;
							*ptr16 = 240;
							if (num8 > 254)
							{
								do
								{
									byte* intPtr9 = ptr4;
									ptr4 = intPtr9 + 1;
									*intPtr9 = byte.MaxValue;
									num8 -= 255;
								}
								while (num8 > 254);
								byte* intPtr10 = ptr4;
								ptr4 = intPtr10 + 1;
								*intPtr10 = (byte)num8;
								_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ptr, ptr4, num7);
								ptr4 += num7;
								goto IL_01c5;
							}
							byte* intPtr11 = ptr4;
							ptr4 = intPtr11 + 1;
							*intPtr11 = (byte)num8;
						}
						else
						{
							*ptr16 = (byte)(num7 << 4);
						}
						byte* ptr17 = ptr4 + num7;
						do
						{
							*(long*)ptr4 = *(long*)ptr;
							ptr4 += 8;
							ptr += 8;
						}
						while (ptr4 < ptr17);
						ptr4 = ptr17;
						goto IL_01c5;
						IL_036f:
						byte* intPtr12 = ptr12;
						ptr12 = intPtr12 + 1;
						ptr = intPtr12;
						num = (uint)((int)(*(uint*)ptr12) * -1640531535) >> 20;
					}
				}
				int num9 = (int)(ptr2 - ptr);
				if (ptr4 + num9 + 1 + (num9 + 255 - 15) / 255 > ptr5)
				{
					return 0;
				}
				if (num9 >= 15)
				{
					byte* intPtr13 = ptr4;
					ptr4 = intPtr13 + 1;
					*intPtr13 = 240;
					for (num9 -= 15; num9 > 254; num9 -= 255)
					{
						byte* intPtr14 = ptr4;
						ptr4 = intPtr14 + 1;
						*intPtr14 = byte.MaxValue;
					}
					byte* intPtr15 = ptr4;
					ptr4 = intPtr15 + 1;
					*intPtr15 = (byte)num9;
				}
				else
				{
					byte* intPtr16 = ptr4;
					ptr4 = intPtr16 + 1;
					*intPtr16 = (byte)(num9 << 4);
				}
				_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ptr, ptr4, (int)(ptr2 - ptr));
				ptr4 += ptr2 - ptr;
				return (int)(ptr4 - _0020_0020);
			}
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020(ushort* _0020, byte* _0020_000A, byte* _0020_0020, int _0020_000A_000A, int _0020_000A_0020)
		{
			fixed (int* ptr15 = &_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020[0])
			{
				byte* ptr = _0020_000A;
				byte* ptr2 = _0020_000A + _0020_000A_000A;
				byte* ptr3 = ptr2 - 12;
				byte* ptr4 = _0020_0020;
				byte* ptr5 = ptr4 + _0020_000A_0020;
				byte* ptr6 = ptr2 - 5;
				byte* ptr7 = ptr6 - 1;
				byte* ptr8 = ptr6 - 3;
				byte* ptr9 = ptr6 - 7;
				byte* ptr10 = ptr5 - 6;
				byte* ptr11 = ptr5 - 8;
				if (_0020_000A_000A >= 13)
				{
					byte* ptr12 = _0020_000A + 1;
					uint num = (uint)((int)(*(uint*)ptr12) * -1640531535) >> 19;
					while (true)
					{
						int num2 = 67;
						byte* ptr13 = ptr12;
						byte* ptr14;
						while (true)
						{
							uint num3 = num;
							int num5 = num2++ >> 6;
							ptr12 = ptr13;
							ptr13 = ptr12 + num5;
							if (ptr13 > ptr3)
							{
								break;
							}
							num = (uint)((int)(*(uint*)ptr13) * -1640531535) >> 19;
							ptr14 = _0020_000A + (int)_0020[num3];
							_0020[num3] = (ushort)(ptr12 - _0020_000A);
							if (*(uint*)ptr14 != *(uint*)ptr12)
							{
								continue;
							}
							goto IL_00d4;
						}
						break;
						IL_019e:
						byte* ptr16;
						while (true)
						{
							*(ushort*)ptr4 = (ushort)(ptr12 - ptr14);
							ptr4 += 2;
							ptr12 += 4;
							ptr14 += 4;
							ptr = ptr12;
							while (true)
							{
								if (ptr12 >= ptr9)
								{
									if (ptr12 < ptr8 && *(uint*)ptr14 == *(uint*)ptr12)
									{
										ptr12 += 4;
										ptr14 += 4;
									}
									if (ptr12 < ptr7 && *(ushort*)ptr14 == *(ushort*)ptr12)
									{
										ptr12 += 2;
										ptr14 += 2;
									}
									if (ptr12 < ptr6 && *ptr14 == *ptr12)
									{
										ptr12++;
									}
									break;
								}
								long num6 = *(long*)ptr14 ^ *(long*)ptr12;
								if (num6 != 0L)
								{
									ptr12 += ptr15[(ulong)((num6 & -num6) * 151050438428048703L) >> 58];
									break;
								}
								ptr12 += 8;
								ptr14 += 8;
							}
							int num7 = (int)(ptr12 - ptr);
							if (ptr4 + (num7 >> 8) > ptr10)
							{
								return 0;
							}
							if (num7 >= 15)
							{
								byte* intPtr = ptr16;
								*intPtr = (byte)(*intPtr + 15);
								for (num7 -= 15; num7 > 509; num7 -= 510)
								{
									byte* intPtr2 = ptr4;
									ptr4 = intPtr2 + 1;
									*intPtr2 = byte.MaxValue;
									byte* intPtr3 = ptr4;
									ptr4 = intPtr3 + 1;
									*intPtr3 = byte.MaxValue;
								}
								if (num7 > 254)
								{
									num7 -= 255;
									byte* intPtr4 = ptr4;
									ptr4 = intPtr4 + 1;
									*intPtr4 = byte.MaxValue;
								}
								byte* intPtr5 = ptr4;
								ptr4 = intPtr5 + 1;
								*intPtr5 = (byte)num7;
							}
							else
							{
								byte* intPtr6 = ptr16;
								*intPtr6 = (byte)(*intPtr6 + (byte)num7);
							}
							if (ptr12 > ptr3)
							{
								break;
							}
							_0020[(uint)((int)(*(uint*)(ptr12 - 2)) * -1640531535) >> 19] = (ushort)(ptr12 - 2 - _0020_000A);
							uint num3 = (uint)((int)(*(uint*)ptr12) * -1640531535) >> 19;
							ptr14 = _0020_000A + (int)_0020[num3];
							_0020[num3] = (ushort)(ptr12 - _0020_000A);
							if (*(uint*)ptr14 == *(uint*)ptr12)
							{
								byte* intPtr7 = ptr4;
								ptr4 = intPtr7 + 1;
								ptr16 = intPtr7;
								*ptr16 = 0;
								continue;
							}
							goto IL_0339;
						}
						ptr = ptr12;
						break;
						IL_00d4:
						while (ptr12 > ptr && ptr14 > _0020_000A && ptr12[-1] == ptr14[-1])
						{
							ptr12--;
							ptr14--;
						}
						int num8 = (int)(ptr12 - ptr);
						byte* intPtr8 = ptr4;
						ptr4 = intPtr8 + 1;
						ptr16 = intPtr8;
						if (ptr4 + num8 + (num8 >> 8) > ptr11)
						{
							return 0;
						}
						if (num8 >= 15)
						{
							int num7 = num8 - 15;
							*ptr16 = 240;
							if (num7 > 254)
							{
								do
								{
									byte* intPtr9 = ptr4;
									ptr4 = intPtr9 + 1;
									*intPtr9 = byte.MaxValue;
									num7 -= 255;
								}
								while (num7 > 254);
								byte* intPtr10 = ptr4;
								ptr4 = intPtr10 + 1;
								*intPtr10 = (byte)num7;
								_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ptr, ptr4, num8);
								ptr4 += num8;
								goto IL_019e;
							}
							byte* intPtr11 = ptr4;
							ptr4 = intPtr11 + 1;
							*intPtr11 = (byte)num7;
						}
						else
						{
							*ptr16 = (byte)(num8 << 4);
						}
						byte* ptr17 = ptr4 + num8;
						do
						{
							*(long*)ptr4 = *(long*)ptr;
							ptr4 += 8;
							ptr += 8;
						}
						while (ptr4 < ptr17);
						ptr4 = ptr17;
						goto IL_019e;
						IL_0339:
						byte* intPtr12 = ptr12;
						ptr12 = intPtr12 + 1;
						ptr = intPtr12;
						num = (uint)((int)(*(uint*)ptr12) * -1640531535) >> 19;
					}
				}
				int num9 = (int)(ptr2 - ptr);
				if (ptr4 + num9 + 1 + (num9 - 15 + 255) / 255 > ptr5)
				{
					return 0;
				}
				if (num9 >= 15)
				{
					byte* intPtr13 = ptr4;
					ptr4 = intPtr13 + 1;
					*intPtr13 = 240;
					for (num9 -= 15; num9 > 254; num9 -= 255)
					{
						byte* intPtr14 = ptr4;
						ptr4 = intPtr14 + 1;
						*intPtr14 = byte.MaxValue;
					}
					byte* intPtr15 = ptr4;
					ptr4 = intPtr15 + 1;
					*intPtr15 = (byte)num9;
				}
				else
				{
					byte* intPtr16 = ptr4;
					ptr4 = intPtr16 + 1;
					*intPtr16 = (byte)(num9 << 4);
				}
				_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ptr, ptr4, (int)(ptr2 - ptr));
				ptr4 += ptr2 - ptr;
				return (int)(ptr4 - _0020_0020);
			}
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(byte* _0020, byte* _0020_000A, int _0020_0020)
		{
			fixed (int* ptr10 = &_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A[0])
			{
				fixed (int* ptr9 = &_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020[0])
				{
					byte* ptr = _0020;
					byte* ptr2 = _0020_000A;
					byte* ptr3 = ptr2 + _0020_0020;
					byte* ptr4 = ptr3 - 5;
					byte* ptr5 = ptr3 - 8;
					byte* ptr6 = ptr3 - 8 - 4;
					while (true)
					{
						byte* intPtr = ptr;
						ptr = intPtr + 1;
						byte b = *intPtr;
						int num;
						if ((num = b >> 4) == 15)
						{
							int num2;
							while (true)
							{
								byte* intPtr2 = ptr;
								ptr = intPtr2 + 1;
								if ((num2 = *intPtr2) != 255)
								{
									break;
								}
								num += 255;
							}
							num += num2;
						}
						byte* ptr7 = ptr2 + num;
						if (ptr7 > ptr5)
						{
							if (ptr7 != ptr3)
							{
								break;
							}
							_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ptr, ptr2, num);
							ptr += num;
							return (int)(ptr - _0020);
						}
						do
						{
							*(long*)ptr2 = *(long*)ptr;
							ptr2 += 8;
							ptr += 8;
						}
						while (ptr2 < ptr7);
						ptr -= ptr2 - ptr7;
						ptr2 = ptr7;
						byte* ptr8 = ptr7 - (int)(*(ushort*)ptr);
						ptr += 2;
						if (ptr8 < _0020_000A)
						{
							break;
						}
						if ((num = (b & 0xF)) == 15)
						{
							while (*ptr == byte.MaxValue)
							{
								ptr++;
								num += 255;
							}
							int num3 = num;
							byte* intPtr3 = ptr;
							ptr = intPtr3 + 1;
							num = num3 + *intPtr3;
						}
						if (ptr2 - ptr8 < 8)
						{
							int num4 = ptr9[ptr2 - ptr8];
							*ptr2 = *ptr8;
							ptr2[1] = ptr8[1];
							ptr2[2] = ptr8[2];
							ptr2[3] = ptr8[3];
							ptr2 += 4;
							ptr8 += 4;
							ptr8 -= ptr10[ptr2 - ptr8];
							*(uint*)ptr2 = *(uint*)ptr8;
							ptr2 += 4;
							ptr8 -= num4;
						}
						else
						{
							*(long*)ptr2 = *(long*)ptr8;
							ptr2 += 8;
							ptr8 += 8;
						}
						ptr7 = ptr2 + num - 4;
						if (ptr7 > ptr6)
						{
							if (ptr7 > ptr4)
							{
								break;
							}
							while (ptr2 < ptr5)
							{
								*(long*)ptr2 = *(long*)ptr8;
								ptr2 += 8;
								ptr8 += 8;
							}
							while (ptr2 < ptr7)
							{
								byte* intPtr4 = ptr2;
								ptr2 = intPtr4 + 1;
								byte* intPtr5 = ptr8;
								ptr8 = intPtr5 + 1;
								*intPtr4 = *intPtr5;
							}
							ptr2 = ptr7;
						}
						else
						{
							do
							{
								*(long*)ptr2 = *(long*)ptr8;
								ptr2 += 8;
								ptr8 += 8;
							}
							while (ptr2 < ptr7);
							ptr2 = ptr7;
						}
					}
					return (int)(-(ptr - _0020));
				}
			}
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(byte* _0020, byte* _0020_000A, int _0020_0020, int _0020_000A_000A)
		{
			fixed (int* ptr14 = &_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A[0])
			{
				fixed (int* ptr13 = &_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020[0])
				{
					byte* ptr = _0020;
					byte* ptr2 = ptr + _0020_0020;
					byte* ptr3 = _0020_000A;
					byte* ptr4 = ptr3 + _0020_000A_000A;
					byte* ptr5 = ptr2 - 8;
					byte* ptr6 = ptr2 - 6;
					byte* ptr7 = ptr4 - 8;
					byte* ptr8 = ptr4 - 12;
					byte* ptr9 = ptr4 - 5;
					byte* ptr10 = ptr4 - 12;
					if (ptr != ptr2)
					{
						while (true)
						{
							byte* intPtr = ptr;
							ptr = intPtr + 1;
							byte b = *intPtr;
							int num;
							if ((num = b >> 4) == 15)
							{
								int num2 = 255;
								while (ptr < ptr2 && num2 == 255)
								{
									byte* intPtr2 = ptr;
									ptr = intPtr2 + 1;
									num2 = *intPtr2;
									num += num2;
								}
							}
							byte* ptr11 = ptr3 + num;
							if (ptr11 > ptr10 || ptr + num > ptr5)
							{
								if (ptr11 > ptr4 || ptr + num != ptr2)
								{
									break;
								}
								_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ptr, ptr3, num);
								ptr3 += num;
								return (int)(ptr3 - _0020_000A);
							}
							do
							{
								*(long*)ptr3 = *(long*)ptr;
								ptr3 += 8;
								ptr += 8;
							}
							while (ptr3 < ptr11);
							ptr -= ptr3 - ptr11;
							ptr3 = ptr11;
							byte* ptr12 = ptr11 - (int)(*(ushort*)ptr);
							ptr += 2;
							if (ptr12 < _0020_000A)
							{
								break;
							}
							if ((num = (b & 0xF)) == 15)
							{
								while (ptr < ptr6)
								{
									byte* intPtr3 = ptr;
									ptr = intPtr3 + 1;
									int num3 = *intPtr3;
									num += num3;
									if (num3 != 255)
									{
										break;
									}
								}
							}
							if (ptr3 - ptr12 < 8)
							{
								int num4 = ptr13[ptr3 - ptr12];
								*ptr3 = *ptr12;
								ptr3[1] = ptr12[1];
								ptr3[2] = ptr12[2];
								ptr3[3] = ptr12[3];
								ptr3 += 4;
								ptr12 += 4;
								ptr12 -= ptr14[ptr3 - ptr12];
								*(uint*)ptr3 = *(uint*)ptr12;
								ptr3 += 4;
								ptr12 -= num4;
							}
							else
							{
								*(long*)ptr3 = *(long*)ptr12;
								ptr3 += 8;
								ptr12 += 8;
							}
							ptr11 = ptr3 + num - 4;
							if (ptr11 > ptr8)
							{
								if (ptr11 > ptr9)
								{
									break;
								}
								while (ptr3 < ptr7)
								{
									*(long*)ptr3 = *(long*)ptr12;
									ptr3 += 8;
									ptr12 += 8;
								}
								while (ptr3 < ptr11)
								{
									byte* intPtr4 = ptr3;
									ptr3 = intPtr4 + 1;
									byte* intPtr5 = ptr12;
									ptr12 = intPtr5 + 1;
									*intPtr4 = *intPtr5;
								}
								ptr3 = ptr11;
							}
							else
							{
								do
								{
									*(long*)ptr3 = *(long*)ptr12;
									ptr3 += 8;
									ptr12 += 8;
								}
								while (ptr3 < ptr11);
								ptr3 = ptr11;
							}
						}
					}
					return (int)(-(ptr - _0020));
				}
			}
		}

		private unsafe static void _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020 _0020, byte* _0020_000A)
		{
			fixed (ushort* ptr2 = _0020.chainTable)
			{
				fixed (int* ptr = _0020.hashTable)
				{
					byte* src_base = _0020.src_base;
					while (_0020.nextToUpdate < _0020_000A)
					{
						byte* nextToUpdate = _0020.nextToUpdate;
						int num = (int)(nextToUpdate - (ptr[(uint)((int)(*(uint*)nextToUpdate) * -1640531535) >> 17] + src_base));
						if (num > 65535)
						{
							num = 65535;
						}
						ptr2[(int)nextToUpdate & 0xFFFF] = (ushort)num;
						ptr[(uint)((int)(*(uint*)nextToUpdate) * -1640531535) >> 17] = (int)(nextToUpdate - src_base);
						_0020.nextToUpdate++;
					}
				}
			}
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020(byte* _0020, byte* _0020_000A, byte* _0020_0020)
		{
			fixed (int* ptr2 = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020)
			{
				byte* ptr = _0020;
				while (ptr < _0020_0020 - 7)
				{
					long num = *(long*)_0020_000A ^ *(long*)ptr;
					if (num != 0L)
					{
						ptr += ptr2[(ulong)((num & -num) * 151050438428048703L) >> 58];
						return (int)(ptr - _0020);
					}
					ptr += 8;
					_0020_000A += 8;
				}
				if (ptr < _0020_0020 - 3 && *(uint*)_0020_000A == *(uint*)ptr)
				{
					ptr += 4;
					_0020_000A += 4;
				}
				if (ptr < _0020_0020 - 1 && *(ushort*)_0020_000A == *(ushort*)ptr)
				{
					ptr += 2;
					_0020_000A += 2;
				}
				if (ptr < _0020_0020 && *_0020_000A == *ptr)
				{
					ptr++;
				}
				return (int)(ptr - _0020);
			}
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020 _0020, byte* _0020_000A, byte* _0020_0020, ref byte* _0020_000A_000A)
		{
			fixed (ushort* ptr3 = _0020.chainTable)
			{
				fixed (int* ptr = _0020.hashTable)
				{
					byte* src_base = _0020.src_base;
					int num = 256;
					int num2 = 0;
					int num3 = 0;
					ushort num4 = 0;
					_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A(_0020, _0020_000A);
					byte* ptr2 = ptr[(uint)((int)(*(uint*)_0020_000A) * -1640531535) >> 17] + src_base;
					if (ptr2 >= _0020_000A - 4)
					{
						if (*(uint*)ptr2 == *(uint*)_0020_000A)
						{
							num4 = (ushort)(_0020_000A - ptr2);
							num2 = (num3 = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020(_0020_000A + 4, ptr2 + 4, _0020_0020) + 4);
							_0020_000A_000A = ptr2;
						}
						ptr2 -= (int)ptr3[(int)ptr2 & 0xFFFF];
					}
					while (ptr2 >= _0020_000A - 65535 && num != 0)
					{
						num--;
						if (ptr2[num3] == _0020_000A[num3] && *(uint*)ptr2 == *(uint*)_0020_000A)
						{
							int num5 = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020(_0020_000A + 4, ptr2 + 4, _0020_0020) + 4;
							if (num5 > num3)
							{
								num3 = num5;
								_0020_000A_000A = ptr2;
							}
						}
						ptr2 -= (int)ptr3[(int)ptr2 & 0xFFFF];
					}
					if (num2 != 0)
					{
						byte* ptr4 = _0020_000A;
						byte* ptr5;
						for (ptr5 = _0020_000A + num2 - 3; ptr4 < ptr5 - (int)num4; ptr4++)
						{
							ptr3[(int)ptr4 & 0xFFFF] = num4;
						}
						do
						{
							ptr3[(int)ptr4 & 0xFFFF] = num4;
							ptr[(uint)((int)(*(uint*)ptr4) * -1640531535) >> 17] = (int)(ptr4 - src_base);
							ptr4++;
						}
						while (ptr4 < ptr5);
						_0020.nextToUpdate = ptr5;
					}
					return num3;
				}
			}
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020 _0020, byte* _0020_000A, byte* _0020_0020, byte* _0020_000A_000A, int _0020_000A_0020, ref byte* _0020_0020_000A, ref byte* _0020_0020_0020)
		{
			fixed (ushort* ptr7 = _0020.chainTable)
			{
				fixed (int* ptr = _0020.hashTable)
				{
					fixed (int* ptr6 = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020)
					{
						byte* src_base = _0020.src_base;
						int num = 256;
						int num2 = (int)(_0020_000A - _0020_0020);
						_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A(_0020, _0020_000A);
						byte* ptr2 = ptr[(uint)((int)(*(uint*)_0020_000A) * -1640531535) >> 17] + src_base;
						while (ptr2 >= _0020_000A - 65535 && num != 0)
						{
							num--;
							if (_0020_0020[_0020_000A_0020] == (ptr2 - num2)[_0020_000A_0020] && *(uint*)ptr2 == *(uint*)_0020_000A)
							{
								byte* ptr3 = ptr2 + 4;
								byte* ptr4 = _0020_000A + 4;
								byte* ptr5 = _0020_000A;
								while (true)
								{
									if (ptr4 >= _0020_000A_000A - 7)
									{
										if (ptr4 < _0020_000A_000A - 3 && *(uint*)ptr3 == *(uint*)ptr4)
										{
											ptr4 += 4;
											ptr3 += 4;
										}
										if (ptr4 < _0020_000A_000A - 1 && *(ushort*)ptr3 == *(ushort*)ptr4)
										{
											ptr4 += 2;
											ptr3 += 2;
										}
										if (ptr4 < _0020_000A_000A && *ptr3 == *ptr4)
										{
											ptr4++;
										}
										break;
									}
									long num3 = *(long*)ptr3 ^ *(long*)ptr4;
									if (num3 != 0L)
									{
										ptr4 += ptr6[(ulong)((num3 & -num3) * 151050438428048703L) >> 58];
										break;
									}
									ptr4 += 8;
									ptr3 += 8;
								}
								ptr3 = ptr2;
								while (ptr5 > _0020_0020 && ptr3 > _0020.src_base && ptr5[-1] == ptr3[-1])
								{
									ptr5--;
									ptr3--;
								}
								if (ptr4 - ptr5 > _0020_000A_0020)
								{
									_0020_000A_0020 = (int)(ptr4 - ptr5);
									_0020_0020_000A = ptr3;
									_0020_0020_0020 = ptr5;
								}
							}
							ptr2 -= (int)ptr7[(int)ptr2 & 0xFFFF];
						}
						return _0020_000A_0020;
					}
				}
			}
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(ref byte* _0020, ref byte* _0020_000A, ref byte* _0020_0020, int _0020_000A_000A, byte* _0020_000A_0020, byte* _0020_0020_000A)
		{
			byte* ptr = _0020_000A++;
			int num = (int)(_0020 - _0020_0020);
			if (_0020_000A + num + 8 + (num >> 8) > _0020_0020_000A)
			{
				return 1;
			}
			int num2;
			if (num >= 15)
			{
				*ptr = 240;
				for (num2 = num - 15; num2 > 254; num2 -= 255)
				{
					*(_0020_000A++) = byte.MaxValue;
				}
				*(_0020_000A++) = (byte)num2;
			}
			else
			{
				*ptr = (byte)(num << 4);
			}
			byte* ptr2 = _0020_000A + num;
			do
			{
				*(long*)_0020_000A = *(long*)_0020_0020;
				_0020_000A += 8;
				_0020_0020 += 8;
			}
			while (_0020_000A < ptr2);
			_0020_000A = ptr2;
			*(ushort*)_0020_000A = (ushort)(_0020 - _0020_000A_0020);
			_0020_000A += 2;
			num2 = _0020_000A_000A - 4;
			if (_0020_000A + 6 + (num >> 8) > _0020_0020_000A)
			{
				return 1;
			}
			if (num2 >= 15)
			{
				byte* intPtr = ptr;
				*intPtr = (byte)(*intPtr + 15);
				for (num2 -= 15; num2 > 509; num2 -= 510)
				{
					*(_0020_000A++) = byte.MaxValue;
					*(_0020_000A++) = byte.MaxValue;
				}
				if (num2 > 254)
				{
					num2 -= 255;
					*(_0020_000A++) = byte.MaxValue;
				}
				*(_0020_000A++) = (byte)num2;
			}
			else
			{
				byte* intPtr2 = ptr;
				*intPtr2 = (byte)(*intPtr2 + (byte)num2);
			}
			_0020 += _0020_000A_000A;
			_0020_0020 = _0020;
			return 0;
		}

		private unsafe static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020 _0020, byte* _0020_000A, byte* _0020_0020, int _0020_000A_000A, int _0020_000A_0020)
		{
			byte* ptr = _0020_000A;
			byte* ptr2 = _0020_000A + _0020_000A_000A;
			byte* ptr3 = ptr2 - 12;
			byte* ptr4 = ptr2 - 5;
			byte* ptr5 = _0020_0020;
			byte* _0020_0020_000A = ptr5 + _0020_000A_0020;
			byte* ptr6 = null;
			byte* ptr7 = null;
			byte* ptr8 = null;
			byte* ptr9 = null;
			byte* ptr10 = null;
			byte* ptr11 = _0020_000A + 1;
			while (ptr11 < ptr3)
			{
				int num = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A(_0020, ptr11, ptr4, ref ptr6);
				if (num == 0)
				{
					ptr11++;
					continue;
				}
				byte* ptr12 = ptr11;
				byte* ptr13 = ptr6;
				int num2 = num;
				while (true)
				{
					int num3 = (ptr11 + num < ptr3) ? _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020(_0020, ptr11 + num - 2, ptr11 + 1, ptr4, num, ref ptr8, ref ptr7) : num;
					if (num3 == num)
					{
						if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(ref ptr11, ref ptr5, ref ptr, num, ptr6, _0020_0020_000A) == 0)
						{
							break;
						}
						return 0;
					}
					if (ptr12 < ptr11 && ptr7 < ptr11 + num2)
					{
						ptr11 = ptr12;
						ptr6 = ptr13;
						num = num2;
					}
					if (ptr7 - ptr11 < 3)
					{
						num = num3;
						ptr11 = ptr7;
						ptr6 = ptr8;
						continue;
					}
					int num6;
					while (true)
					{
						if (ptr7 - ptr11 < 18)
						{
							int num4 = num;
							if (num4 > 18)
							{
								num4 = 18;
							}
							if (ptr11 + num4 > ptr7 + num3 - 4)
							{
								num4 = (int)(ptr7 - ptr11) + num3 - 4;
							}
							int num5 = num4 - (int)(ptr7 - ptr11);
							if (num5 > 0)
							{
								ptr7 += num5;
								ptr8 += num5;
								num3 -= num5;
							}
						}
						num6 = ((ptr7 + num3 < ptr3) ? _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020(_0020, ptr7 + num3 - 3, ptr7, ptr4, num3, ref ptr10, ref ptr9) : num3);
						if (num6 == num3)
						{
							break;
						}
						if (ptr9 < ptr11 + num + 3)
						{
							if (ptr9 < ptr11 + num)
							{
								ptr7 = ptr9;
								ptr8 = ptr10;
								num3 = num6;
								continue;
							}
							goto IL_01af;
						}
						if (ptr7 < ptr11 + num)
						{
							if (ptr7 - ptr11 < 15)
							{
								if (num > 18)
								{
									num = 18;
								}
								if (ptr11 + num > ptr7 + num3 - 4)
								{
									num = (int)(ptr7 - ptr11) + num3 - 4;
								}
								int num7 = num - (int)(ptr7 - ptr11);
								if (num7 > 0)
								{
									ptr7 += num7;
									ptr8 += num7;
									num3 -= num7;
								}
							}
							else
							{
								num = (int)(ptr7 - ptr11);
							}
						}
						if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(ref ptr11, ref ptr5, ref ptr, num, ptr6, _0020_0020_000A) != 0)
						{
							return 0;
						}
						ptr11 = ptr7;
						ptr6 = ptr8;
						num = num3;
						ptr7 = ptr9;
						ptr8 = ptr10;
						num3 = num6;
					}
					if (ptr7 < ptr11 + num)
					{
						num = (int)(ptr7 - ptr11);
					}
					if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(ref ptr11, ref ptr5, ref ptr, num, ptr6, _0020_0020_000A) != 0)
					{
						return 0;
					}
					ptr11 = ptr7;
					if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(ref ptr11, ref ptr5, ref ptr, num3, ptr8, _0020_0020_000A) == 0)
					{
						break;
					}
					return 0;
					IL_01af:
					if (ptr7 < ptr11 + num)
					{
						int num8 = (int)(ptr11 + num - ptr7);
						ptr7 += num8;
						ptr8 += num8;
						num3 -= num8;
						if (num3 < 4)
						{
							ptr7 = ptr9;
							ptr8 = ptr10;
							num3 = num6;
						}
					}
					if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(ref ptr11, ref ptr5, ref ptr, num, ptr6, _0020_0020_000A) != 0)
					{
						return 0;
					}
					ptr11 = ptr9;
					ptr6 = ptr10;
					num = num6;
					ptr12 = ptr7;
					ptr13 = ptr8;
					num2 = num3;
				}
			}
			int num9 = (int)(ptr2 - ptr);
			if (ptr5 - _0020_0020 + num9 + 1 + (num9 + 255 - 15) / 255 > (uint)_0020_000A_0020)
			{
				return 0;
			}
			if (num9 >= 15)
			{
				byte* intPtr = ptr5;
				ptr5 = intPtr + 1;
				*intPtr = 240;
				for (num9 -= 15; num9 > 254; num9 -= 255)
				{
					byte* intPtr2 = ptr5;
					ptr5 = intPtr2 + 1;
					*intPtr2 = byte.MaxValue;
				}
				byte* intPtr3 = ptr5;
				ptr5 = intPtr3 + 1;
				*intPtr3 = (byte)num9;
			}
			else
			{
				byte* intPtr4 = ptr5;
				ptr5 = intPtr4 + 1;
				*intPtr4 = (byte)(num9 << 4);
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ptr, ptr5, (int)(ptr2 - ptr));
			ptr5 += ptr2 - ptr;
			return (int)(ptr5 - _0020_0020);
		}
	}
}
