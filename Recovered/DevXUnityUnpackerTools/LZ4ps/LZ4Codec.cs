using System;
using System.Diagnostics;

namespace LZ4ps
{
	public static class LZ4Codec
	{
		private class _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A
		{
			public byte[] src;

			public int src_base;

			public int src_end;

			public int src_LASTLITERALS;

			public byte[] dst;

			public int dst_base;

			public int dst_len;

			public int dst_end;

			public int[] hashTable;

			public ushort[] chainTable;

			public int nextToUpdate;
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

		[Conditional("DEBUG")]
		private static void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020(bool _0020, string _0020_000A)
		{
			if (!_0020)
			{
				throw new ArgumentException(_0020_000A);
			}
		}

		internal static void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A(byte[] _0020, int _0020_000A, ushort _0020_0020)
		{
			_0020[_0020_000A] = (byte)_0020_0020;
			_0020[_0020_000A + 1] = (byte)(_0020_0020 >> 8);
		}

		internal static ushort _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020(byte[] _0020, int _0020_000A)
		{
			return (ushort)(_0020[_0020_000A] | (_0020[_0020_000A + 1] << 8));
		}

		internal static uint _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(byte[] _0020, int _0020_000A)
		{
			return (uint)(_0020[_0020_000A] | (_0020[_0020_000A + 1] << 8) | (_0020[_0020_000A + 2] << 16) | (_0020[_0020_000A + 3] << 24));
		}

		private static uint _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A(byte[] _0020, int _0020_000A, int _0020_0020)
		{
			int num = _0020[_0020_000A] | (_0020[_0020_000A + 1] << 8) | (_0020[_0020_000A + 2] << 16) | (_0020[_0020_000A + 3] << 24);
			uint num2 = (uint)(_0020[_0020_0020] | (_0020[_0020_0020 + 1] << 8) | (_0020[_0020_0020 + 2] << 16) | (_0020[_0020_0020 + 3] << 24));
			return (uint)(num ^ (int)num2);
		}

		private static ulong _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020(byte[] _0020, int _0020_000A, int _0020_0020)
		{
			ulong num = _0020[_0020_000A] | ((ulong)_0020[_0020_000A + 1] << 8) | ((ulong)_0020[_0020_000A + 2] << 16) | ((ulong)_0020[_0020_000A + 3] << 24) | ((ulong)_0020[_0020_000A + 4] << 32) | ((ulong)_0020[_0020_000A + 5] << 40) | ((ulong)_0020[_0020_000A + 6] << 48) | ((ulong)_0020[_0020_000A + 7] << 56);
			ulong num2 = _0020[_0020_0020] | ((ulong)_0020[_0020_0020 + 1] << 8) | ((ulong)_0020[_0020_0020 + 2] << 16) | ((ulong)_0020[_0020_0020 + 3] << 24) | ((ulong)_0020[_0020_0020 + 4] << 32) | ((ulong)_0020[_0020_0020 + 5] << 40) | ((ulong)_0020[_0020_0020 + 6] << 48) | ((ulong)_0020[_0020_0020 + 7] << 56);
			return num ^ num2;
		}

		private static bool _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(byte[] _0020, int _0020_000A, int _0020_0020)
		{
			if (_0020[_0020_000A] != _0020[_0020_0020])
			{
				return false;
			}
			return _0020[_0020_000A + 1] == _0020[_0020_0020 + 1];
		}

		private static bool _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(byte[] _0020, int _0020_000A, int _0020_0020)
		{
			if (_0020[_0020_000A] != _0020[_0020_0020])
			{
				return false;
			}
			if (_0020[_0020_000A + 1] != _0020[_0020_0020 + 1])
			{
				return false;
			}
			if (_0020[_0020_000A + 2] != _0020[_0020_0020 + 2])
			{
				return false;
			}
			return _0020[_0020_000A + 3] == _0020[_0020_0020 + 3];
		}

		private static void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A(byte[] _0020, int _0020_000A, int _0020_0020)
		{
			_0020[_0020_0020 + 3] = _0020[_0020_000A + 3];
			_0020[_0020_0020 + 2] = _0020[_0020_000A + 2];
			_0020[_0020_0020 + 1] = _0020[_0020_000A + 1];
			_0020[_0020_0020] = _0020[_0020_000A];
		}

		private static void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020(byte[] _0020, int _0020_000A, int _0020_0020)
		{
			_0020[_0020_0020 + 7] = _0020[_0020_000A + 7];
			_0020[_0020_0020 + 6] = _0020[_0020_000A + 6];
			_0020[_0020_0020 + 5] = _0020[_0020_000A + 5];
			_0020[_0020_0020 + 4] = _0020[_0020_000A + 4];
			_0020[_0020_0020 + 3] = _0020[_0020_000A + 3];
			_0020[_0020_0020 + 2] = _0020[_0020_000A + 2];
			_0020[_0020_0020 + 1] = _0020[_0020_000A + 1];
			_0020[_0020_0020] = _0020[_0020_000A];
		}

		private static void _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(byte[] _0020, int _0020_000A, byte[] _0020_0020, int _0020_000A_000A, int _0020_000A_0020)
		{
			if (_0020_000A_0020 >= 16)
			{
				Buffer.BlockCopy(_0020, _0020_000A, _0020_0020, _0020_000A_000A, _0020_000A_0020);
				return;
			}
			while (_0020_000A_0020 >= 8)
			{
				_0020_0020[_0020_000A_000A] = _0020[_0020_000A];
				_0020_0020[_0020_000A_000A + 1] = _0020[_0020_000A + 1];
				_0020_0020[_0020_000A_000A + 2] = _0020[_0020_000A + 2];
				_0020_0020[_0020_000A_000A + 3] = _0020[_0020_000A + 3];
				_0020_0020[_0020_000A_000A + 4] = _0020[_0020_000A + 4];
				_0020_0020[_0020_000A_000A + 5] = _0020[_0020_000A + 5];
				_0020_0020[_0020_000A_000A + 6] = _0020[_0020_000A + 6];
				_0020_0020[_0020_000A_000A + 7] = _0020[_0020_000A + 7];
				_0020_000A_0020 -= 8;
				_0020_000A += 8;
				_0020_000A_000A += 8;
			}
			while (_0020_000A_0020 >= 4)
			{
				_0020_0020[_0020_000A_000A] = _0020[_0020_000A];
				_0020_0020[_0020_000A_000A + 1] = _0020[_0020_000A + 1];
				_0020_0020[_0020_000A_000A + 2] = _0020[_0020_000A + 2];
				_0020_0020[_0020_000A_000A + 3] = _0020[_0020_000A + 3];
				_0020_000A_0020 -= 4;
				_0020_000A += 4;
				_0020_000A_000A += 4;
			}
			while (_0020_000A_0020-- > 0)
			{
				_0020_0020[_0020_000A_000A++] = _0020[_0020_000A++];
			}
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A(byte[] _0020, int _0020_000A, byte[] _0020_0020, int _0020_000A_000A, int _0020_000A_0020)
		{
			int num = _0020_000A_0020 - _0020_000A_000A;
			if (num >= 16)
			{
				Buffer.BlockCopy(_0020, _0020_000A, _0020_0020, _0020_000A_000A, num);
			}
			else
			{
				while (num >= 4)
				{
					_0020_0020[_0020_000A_000A] = _0020[_0020_000A];
					_0020_0020[_0020_000A_000A + 1] = _0020[_0020_000A + 1];
					_0020_0020[_0020_000A_000A + 2] = _0020[_0020_000A + 2];
					_0020_0020[_0020_000A_000A + 3] = _0020[_0020_000A + 3];
					num -= 4;
					_0020_000A += 4;
					_0020_000A_000A += 4;
				}
				while (num-- > 0)
				{
					_0020_0020[_0020_000A_000A++] = _0020[_0020_000A++];
				}
			}
			return num;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020(byte[] _0020, int _0020_000A, int _0020_0020, int _0020_000A_000A)
		{
			int num = _0020_0020 - _0020_000A;
			int num2 = _0020_000A_000A - _0020_0020;
			int num3 = num2;
			if (num >= 16)
			{
				if (num >= num2)
				{
					Buffer.BlockCopy(_0020, _0020_000A, _0020, _0020_0020, num2);
					return num2;
				}
				do
				{
					Buffer.BlockCopy(_0020, _0020_000A, _0020, _0020_0020, num);
					_0020_000A += num;
					_0020_0020 += num;
					num3 -= num;
				}
				while (num3 >= num);
			}
			while (num3 >= 4)
			{
				_0020[_0020_0020] = _0020[_0020_000A];
				_0020[_0020_0020 + 1] = _0020[_0020_000A + 1];
				_0020[_0020_0020 + 2] = _0020[_0020_000A + 2];
				_0020[_0020_0020 + 3] = _0020[_0020_000A + 3];
				_0020_0020 += 4;
				_0020_000A += 4;
				num3 -= 4;
			}
			while (num3-- > 0)
			{
				_0020[_0020_0020++] = _0020[_0020_000A++];
			}
			return num2;
		}

		public static int Encode32(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(input, inputOffset, ref inputLength, output, outputOffset, ref outputLength);
			if (outputLength == 0)
			{
				return 0;
			}
			if (inputLength < 65547)
			{
				return _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020(new ushort[8192], input, output, inputOffset, outputOffset, inputLength, outputLength);
			}
			return _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A(new int[4096], input, output, inputOffset, outputOffset, inputLength, outputLength);
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

		public static int Encode64(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(input, inputOffset, ref inputLength, output, outputOffset, ref outputLength);
			if (outputLength == 0)
			{
				return 0;
			}
			if (inputLength < 65547)
			{
				return _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020(new ushort[8192], input, output, inputOffset, outputOffset, inputLength, outputLength);
			}
			return _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A(new int[4096], input, output, inputOffset, outputOffset, inputLength, outputLength);
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

		public static int Decode32(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength, bool knownOutputLength)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(input, inputOffset, ref inputLength, output, outputOffset, ref outputLength);
			if (outputLength == 0)
			{
				return 0;
			}
			if (knownOutputLength)
			{
				if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A(input, output, inputOffset, outputOffset, outputLength) != inputLength)
				{
					throw new ArgumentException("LZ4 block is corrupted, or invalid length has been given.");
				}
				return outputLength;
			}
			int num = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020(input, output, inputOffset, outputOffset, inputLength, outputLength);
			if (num < 0)
			{
				throw new ArgumentException("LZ4 block is corrupted, or invalid length has been given.");
			}
			return num;
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

		public static int Decode64(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength, bool knownOutputLength)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(input, inputOffset, ref inputLength, output, outputOffset, ref outputLength);
			if (outputLength == 0)
			{
				return 0;
			}
			if (knownOutputLength)
			{
				if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A(input, output, inputOffset, outputOffset, outputLength) != inputLength)
				{
					throw new ArgumentException("LZ4 block is corrupted, or invalid length has been given.");
				}
				return outputLength;
			}
			int num = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020(input, output, inputOffset, outputOffset, inputLength, outputLength);
			if (num < 0)
			{
				throw new ArgumentException("LZ4 block is corrupted, or invalid length has been given.");
			}
			return num;
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

		private static _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020(byte[] _0020, int _0020_000A, int _0020_0020, byte[] _0020_000A_000A, int _0020_000A_0020, int _0020_0020_000A)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A
			{
				src = _0020,
				src_base = _0020_000A,
				src_end = _0020_000A + _0020_0020,
				src_LASTLITERALS = _0020_000A + _0020_0020 - 5,
				dst = _0020_000A_000A,
				dst_base = _0020_000A_0020,
				dst_len = _0020_0020_000A,
				dst_end = _0020_000A_0020 + _0020_0020_000A,
				hashTable = new int[32768],
				chainTable = new ushort[65536],
				nextToUpdate = _0020_000A + 1
			};
			ushort[] chainTable = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A.chainTable;
			for (int num = chainTable.Length - 1; num >= 0; num--)
			{
				chainTable[num] = ushort.MaxValue;
			}
			return _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A(byte[] _0020, int _0020_000A, int _0020_0020, byte[] _0020_000A_000A, int _0020_000A_0020, int _0020_0020_000A)
		{
			return _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020(_0020, _0020_000A, _0020_0020, _0020_000A_000A, _0020_000A_0020, _0020_0020_000A));
		}

		public static int Encode32HC(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			if (inputLength == 0)
			{
				return 0;
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(input, inputOffset, ref inputLength, output, outputOffset, ref outputLength);
			int num = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A(input, inputOffset, inputLength, output, outputOffset, outputLength);
			if (num > 0)
			{
				return num;
			}
			return -1;
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

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020(byte[] _0020, int _0020_000A, int _0020_0020, byte[] _0020_000A_000A, int _0020_000A_0020, int _0020_0020_000A)
		{
			return _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020(_0020, _0020_000A, _0020_0020, _0020_000A_000A, _0020_000A_0020, _0020_0020_000A));
		}

		public static int Encode64HC(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			if (inputLength == 0)
			{
				return 0;
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(input, inputOffset, ref inputLength, output, outputOffset, ref outputLength);
			int num = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020(input, inputOffset, inputLength, output, outputOffset, outputLength);
			if (num > 0)
			{
				return num;
			}
			return -1;
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

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A(int[] _0020, byte[] _0020_000A, byte[] _0020_0020, int _0020_000A_000A, int _0020_000A_0020, int _0020_0020_000A, int _0020_0020_0020)
		{
			int[] array = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A;
			int num = _0020_000A_000A;
			int num2 = _0020_000A_000A + _0020_0020_000A;
			int num3 = num2 - 12;
			int num4 = _0020_000A_0020;
			int num5 = num4 + _0020_0020_0020;
			int num6 = num2 - 5;
			int num7 = num6 - 1;
			int num8 = num6 - 3;
			int num9 = num5 - 6;
			int num10 = num5 - 8;
			if (_0020_0020_000A >= 13)
			{
				_0020[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, _0020_000A_000A) * -1640531535) >> 20] = _0020_000A_000A - _0020_000A_000A;
				int num11 = _0020_000A_000A + 1;
				uint num12 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num11) * -1640531535) >> 20;
				while (true)
				{
					int num13 = 67;
					int num14 = num11;
					int num18;
					while (true)
					{
						uint num15 = num12;
						int num17 = num13++ >> 6;
						num11 = num14;
						num14 = num11 + num17;
						if (num14 > num3)
						{
							break;
						}
						num12 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num14) * -1640531535) >> 20;
						num18 = _0020_000A_000A + _0020[num15];
						_0020[num15] = num11 - _0020_000A_000A;
						if (num18 < num11 - 65535 || !_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(_0020_000A, num18, num11))
						{
							continue;
						}
						goto IL_00e3;
					}
					break;
					IL_0340:
					num = num11++;
					num12 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num11) * -1640531535) >> 20;
					continue;
					IL_00e3:
					while (num11 > num && num18 > _0020_000A_000A && _0020_000A[num11 - 1] == _0020_000A[num18 - 1])
					{
						num11--;
						num18--;
					}
					int num20 = num11 - num;
					int num22 = num4++;
					if (num4 + num20 + (num20 >> 8) > num10)
					{
						return 0;
					}
					if (num20 >= 15)
					{
						int num23 = num20 - 15;
						_0020_0020[num22] = 240;
						if (num23 > 254)
						{
							do
							{
								_0020_0020[num4++] = byte.MaxValue;
								num23 -= 255;
							}
							while (num23 > 254);
							_0020_0020[num4++] = (byte)num23;
							_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(_0020_000A, num, _0020_0020, num4, num20);
							num4 += num20;
							goto IL_01ad;
						}
						_0020_0020[num4++] = (byte)num23;
					}
					else
					{
						_0020_0020[num22] = (byte)(num20 << 4);
					}
					if (num20 > 0)
					{
						int num27 = num4 + num20;
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A(_0020_000A, num, _0020_0020, num4, num27);
						num4 = num27;
					}
					goto IL_01ad;
					IL_01ad:
					while (true)
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A(_0020_0020, num4, (ushort)(num11 - num18));
						num4 += 2;
						num11 += 4;
						num18 += 4;
						num = num11;
						while (true)
						{
							if (num11 < num8)
							{
								int num28 = (int)_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A(_0020_000A, num18, num11);
								if (num28 == 0)
								{
									num11 += 4;
									num18 += 4;
									continue;
								}
								num11 += array[(uint)((num28 & -num28) * 125613361) >> 27];
								break;
							}
							if (num11 < num7 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(_0020_000A, num18, num11))
							{
								num11 += 2;
								num18 += 2;
							}
							if (num11 < num6 && _0020_000A[num18] == _0020_000A[num11])
							{
								num11++;
							}
							break;
						}
						num20 = num11 - num;
						if (num4 + (num20 >> 8) > num9)
						{
							return 0;
						}
						if (num20 >= 15)
						{
							_0020_0020[num22] += 15;
							for (num20 -= 15; num20 > 509; num20 -= 510)
							{
								_0020_0020[num4++] = byte.MaxValue;
								_0020_0020[num4++] = byte.MaxValue;
							}
							if (num20 > 254)
							{
								num20 -= 255;
								_0020_0020[num4++] = byte.MaxValue;
							}
							_0020_0020[num4++] = (byte)num20;
						}
						else
						{
							_0020_0020[num22] += (byte)num20;
						}
						if (num11 > num3)
						{
							break;
						}
						_0020[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num11 - 2) * -1640531535) >> 20] = num11 - 2 - _0020_000A_000A;
						uint num15 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num11) * -1640531535) >> 20;
						num18 = _0020_000A_000A + _0020[num15];
						_0020[num15] = num11 - _0020_000A_000A;
						if (num18 > num11 - 65536 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(_0020_000A, num18, num11))
						{
							num22 = num4++;
							_0020_0020[num22] = 0;
							continue;
						}
						goto IL_0340;
					}
					num = num11;
					break;
				}
			}
			int num34 = num2 - num;
			if (num4 + num34 + 1 + (num34 + 255 - 15) / 255 > num5)
			{
				return 0;
			}
			if (num34 >= 15)
			{
				_0020_0020[num4++] = 240;
				for (num34 -= 15; num34 > 254; num34 -= 255)
				{
					_0020_0020[num4++] = byte.MaxValue;
				}
				_0020_0020[num4++] = (byte)num34;
			}
			else
			{
				_0020_0020[num4++] = (byte)(num34 << 4);
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(_0020_000A, num, _0020_0020, num4, num2 - num);
			num4 += num2 - num;
			return num4 - _0020_000A_0020;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020(ushort[] _0020, byte[] _0020_000A, byte[] _0020_0020, int _0020_000A_000A, int _0020_000A_0020, int _0020_0020_000A, int _0020_0020_0020)
		{
			int[] array = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A;
			int num = _0020_000A_000A;
			int num2 = _0020_000A_000A + _0020_0020_000A;
			int num3 = num2 - 12;
			int num4 = _0020_000A_0020;
			int num5 = num4 + _0020_0020_0020;
			int num6 = num2 - 5;
			int num7 = num6 - 1;
			int num8 = num6 - 3;
			int num9 = num5 - 6;
			int num10 = num5 - 8;
			if (_0020_0020_000A >= 13)
			{
				int num11 = _0020_000A_000A + 1;
				uint num12 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num11) * -1640531535) >> 19;
				while (true)
				{
					int num13 = 67;
					int num14 = num11;
					int num18;
					while (true)
					{
						uint num15 = num12;
						int num17 = num13++ >> 6;
						num11 = num14;
						num14 = num11 + num17;
						if (num14 > num3)
						{
							break;
						}
						num12 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num14) * -1640531535) >> 19;
						num18 = _0020_000A_000A + _0020[num15];
						_0020[num15] = (ushort)(num11 - _0020_000A_000A);
						if (!_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(_0020_000A, num18, num11))
						{
							continue;
						}
						goto IL_00c6;
					}
					break;
					IL_0313:
					num = num11++;
					num12 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num11) * -1640531535) >> 19;
					continue;
					IL_00c6:
					while (num11 > num && num18 > _0020_000A_000A && _0020_000A[num11 - 1] == _0020_000A[num18 - 1])
					{
						num11--;
						num18--;
					}
					int num20 = num11 - num;
					int num22 = num4++;
					if (num4 + num20 + (num20 >> 8) > num10)
					{
						return 0;
					}
					if (num20 >= 15)
					{
						int num23 = num20 - 15;
						_0020_0020[num22] = 240;
						if (num23 > 254)
						{
							do
							{
								_0020_0020[num4++] = byte.MaxValue;
								num23 -= 255;
							}
							while (num23 > 254);
							_0020_0020[num4++] = (byte)num23;
							_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(_0020_000A, num, _0020_0020, num4, num20);
							num4 += num20;
							goto IL_018c;
						}
						_0020_0020[num4++] = (byte)num23;
					}
					else
					{
						_0020_0020[num22] = (byte)(num20 << 4);
					}
					if (num20 > 0)
					{
						int num27 = num4 + num20;
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A(_0020_000A, num, _0020_0020, num4, num27);
						num4 = num27;
					}
					goto IL_018c;
					IL_018c:
					while (true)
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A(_0020_0020, num4, (ushort)(num11 - num18));
						num4 += 2;
						num11 += 4;
						num18 += 4;
						num = num11;
						while (true)
						{
							if (num11 < num8)
							{
								int num28 = (int)_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A(_0020_000A, num18, num11);
								if (num28 == 0)
								{
									num11 += 4;
									num18 += 4;
									continue;
								}
								num11 += array[(uint)((num28 & -num28) * 125613361) >> 27];
								break;
							}
							if (num11 < num7 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(_0020_000A, num18, num11))
							{
								num11 += 2;
								num18 += 2;
							}
							if (num11 < num6 && _0020_000A[num18] == _0020_000A[num11])
							{
								num11++;
							}
							break;
						}
						int num23 = num11 - num;
						if (num4 + (num23 >> 8) > num9)
						{
							return 0;
						}
						if (num23 >= 15)
						{
							_0020_0020[num22] += 15;
							for (num23 -= 15; num23 > 509; num23 -= 510)
							{
								_0020_0020[num4++] = byte.MaxValue;
								_0020_0020[num4++] = byte.MaxValue;
							}
							if (num23 > 254)
							{
								num23 -= 255;
								_0020_0020[num4++] = byte.MaxValue;
							}
							_0020_0020[num4++] = (byte)num23;
						}
						else
						{
							_0020_0020[num22] += (byte)num23;
						}
						if (num11 > num3)
						{
							break;
						}
						_0020[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num11 - 2) * -1640531535) >> 19] = (ushort)(num11 - 2 - _0020_000A_000A);
						uint num15 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num11) * -1640531535) >> 19;
						num18 = _0020_000A_000A + _0020[num15];
						_0020[num15] = (ushort)(num11 - _0020_000A_000A);
						if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(_0020_000A, num18, num11))
						{
							num22 = num4++;
							_0020_0020[num22] = 0;
							continue;
						}
						goto IL_0313;
					}
					num = num11;
					break;
				}
			}
			int num34 = num2 - num;
			if (num4 + num34 + 1 + (num34 - 15 + 255) / 255 > num5)
			{
				return 0;
			}
			if (num34 >= 15)
			{
				_0020_0020[num4++] = 240;
				for (num34 -= 15; num34 > 254; num34 -= 255)
				{
					_0020_0020[num4++] = byte.MaxValue;
				}
				_0020_0020[num4++] = (byte)num34;
			}
			else
			{
				_0020_0020[num4++] = (byte)(num34 << 4);
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(_0020_000A, num, _0020_0020, num4, num2 - num);
			num4 += num2 - num;
			return num4 - _0020_000A_0020;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A(byte[] _0020, byte[] _0020_000A, int _0020_0020, int _0020_000A_000A, int _0020_000A_0020)
		{
			int[] array = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A;
			int num = _0020_0020;
			int num2 = _0020_000A_000A;
			int num3 = num2 + _0020_000A_0020;
			int num4 = num3 - 5;
			int num5 = num3 - 8;
			int num6 = num3 - 8;
			while (true)
			{
				byte b = _0020[num++];
				int num8;
				if ((num8 = b >> 4) == 15)
				{
					int num10;
					while ((num10 = _0020[num++]) == 255)
					{
						num8 += 255;
					}
					num8 += num10;
				}
				int num11 = num2 + num8;
				if (num11 > num5)
				{
					if (num11 != num3)
					{
						break;
					}
					_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(_0020, num, _0020_000A, num2, num8);
					num += num8;
					return num - _0020_0020;
				}
				if (num2 < num11)
				{
					int num12 = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A(_0020, num, _0020_000A, num2, num11);
					num += num12;
					num2 += num12;
				}
				num -= num2 - num11;
				num2 = num11;
				int num13 = num11 - _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020(_0020, num);
				num += 2;
				if (num13 < _0020_000A_000A)
				{
					break;
				}
				if ((num8 = (b & 0xF)) == 15)
				{
					while (_0020[num] == byte.MaxValue)
					{
						num++;
						num8 += 255;
					}
					num8 += _0020[num++];
				}
				if (num2 - num13 < 4)
				{
					_0020_000A[num2] = _0020_000A[num13];
					_0020_000A[num2 + 1] = _0020_000A[num13 + 1];
					_0020_000A[num2 + 2] = _0020_000A[num13 + 2];
					_0020_000A[num2 + 3] = _0020_000A[num13 + 3];
					num2 += 4;
					num13 += 4;
					num13 -= array[num2 - num13];
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A(_0020_000A, num13, num2);
					num2 = num2;
					num13 = num13;
				}
				else
				{
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A(_0020_000A, num13, num2);
					num2 += 4;
					num13 += 4;
				}
				num11 = num2 + num8;
				if (num11 > num6)
				{
					if (num11 > num4)
					{
						break;
					}
					if (num2 < num5)
					{
						int num12 = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020(_0020_000A, num13, num2, num5);
						num13 += num12;
						num2 += num12;
					}
					while (num2 < num11)
					{
						_0020_000A[num2++] = _0020_000A[num13++];
					}
					num2 = num11;
				}
				else
				{
					if (num2 < num11)
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020(_0020_000A, num13, num2, num11);
					}
					num2 = num11;
				}
			}
			return -(num - _0020_0020);
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020(byte[] _0020, byte[] _0020_000A, int _0020_0020, int _0020_000A_000A, int _0020_000A_0020, int _0020_0020_000A)
		{
			int[] array = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A;
			int num = _0020_0020;
			int num2 = num + _0020_000A_0020;
			int num3 = _0020_000A_000A;
			int num4 = num3 + _0020_0020_000A;
			int num5 = num2 - 8;
			int num6 = num2 - 6;
			int num7 = num4 - 8;
			int num8 = num4 - 8;
			int num9 = num4 - 5;
			int num10 = num4 - 12;
			if (num != num2)
			{
				while (true)
				{
					byte b = _0020[num++];
					int num12;
					if ((num12 = b >> 4) == 15)
					{
						int num13 = 255;
						while (num < num2 && num13 == 255)
						{
							num12 += (num13 = _0020[num++]);
						}
					}
					int num15 = num3 + num12;
					if (num15 > num10 || num + num12 > num5)
					{
						if (num15 > num4 || num + num12 != num2)
						{
							break;
						}
						_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(_0020, num, _0020_000A, num3, num12);
						num3 += num12;
						return num3 - _0020_000A_000A;
					}
					if (num3 < num15)
					{
						int num16 = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A(_0020, num, _0020_000A, num3, num15);
						num += num16;
						num3 += num16;
					}
					num -= num3 - num15;
					num3 = num15;
					int num17 = num15 - _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020(_0020, num);
					num += 2;
					if (num17 < _0020_000A_000A)
					{
						break;
					}
					if ((num12 = (b & 0xF)) == 15)
					{
						while (num < num6)
						{
							int num19 = _0020[num++];
							num12 += num19;
							if (num19 != 255)
							{
								break;
							}
						}
					}
					if (num3 - num17 < 4)
					{
						_0020_000A[num3] = _0020_000A[num17];
						_0020_000A[num3 + 1] = _0020_000A[num17 + 1];
						_0020_000A[num3 + 2] = _0020_000A[num17 + 2];
						_0020_000A[num3 + 3] = _0020_000A[num17 + 3];
						num3 += 4;
						num17 += 4;
						num17 -= array[num3 - num17];
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A(_0020_000A, num17, num3);
						num3 = num3;
						num17 = num17;
					}
					else
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A(_0020_000A, num17, num3);
						num3 += 4;
						num17 += 4;
					}
					num15 = num3 + num12;
					if (num15 > num8)
					{
						if (num15 > num9)
						{
							break;
						}
						if (num3 < num7)
						{
							int num16 = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020(_0020_000A, num17, num3, num7);
							num17 += num16;
							num3 += num16;
						}
						while (num3 < num15)
						{
							_0020_000A[num3++] = _0020_000A[num17++];
						}
						num3 = num15;
					}
					else
					{
						if (num3 < num15)
						{
							_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020(_0020_000A, num17, num3, num15);
						}
						num3 = num15;
					}
				}
			}
			return -(num - _0020_0020);
		}

		private static void _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A _0020, int _0020_000A)
		{
			ushort[] chainTable = _0020.chainTable;
			int[] hashTable = _0020.hashTable;
			int i = _0020.nextToUpdate;
			byte[] src = _0020.src;
			int src_base = _0020.src_base;
			for (; i < _0020_000A; i++)
			{
				int num = i;
				int num2 = num - (hashTable[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(src, num) * -1640531535) >> 17] + src_base);
				if (num2 > 65535)
				{
					num2 = 65535;
				}
				chainTable[num & 0xFFFF] = (ushort)num2;
				hashTable[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(src, num) * -1640531535) >> 17] = num - src_base;
			}
			_0020.nextToUpdate = i;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A _0020, int _0020_000A, int _0020_0020)
		{
			int[] array = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A;
			byte[] src = _0020.src;
			int src_LASTLITERALS = _0020.src_LASTLITERALS;
			int num = _0020_000A;
			while (num < src_LASTLITERALS - 3)
			{
				int num2 = (int)_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A(src, _0020_0020, num);
				if (num2 == 0)
				{
					num += 4;
					_0020_0020 += 4;
					continue;
				}
				num += array[(uint)((num2 & -num2) * 125613361) >> 27];
				return num - _0020_000A;
			}
			if (num < src_LASTLITERALS - 1 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(src, _0020_0020, num))
			{
				num += 2;
				_0020_0020 += 2;
			}
			if (num < src_LASTLITERALS && src[_0020_0020] == src[num])
			{
				num++;
			}
			return num - _0020_000A;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A _0020, int _0020_000A, ref int _0020_0020)
		{
			ushort[] chainTable = _0020.chainTable;
			int[] hashTable = _0020.hashTable;
			byte[] src = _0020.src;
			int src_base = _0020.src_base;
			int num = 256;
			int num2 = 0;
			int num3 = 0;
			ushort num4 = 0;
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A(_0020, _0020_000A);
			int num5 = hashTable[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(src, _0020_000A) * -1640531535) >> 17] + src_base;
			if (num5 >= _0020_000A - 4)
			{
				if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(src, num5, _0020_000A))
				{
					num4 = (ushort)(_0020_000A - num5);
					num2 = (num3 = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020(_0020, _0020_000A + 4, num5 + 4) + 4);
					_0020_0020 = num5;
				}
				num5 -= chainTable[num5 & 0xFFFF];
			}
			while (num5 >= _0020_000A - 65535 && num != 0)
			{
				num--;
				if (src[num5 + num3] == src[_0020_000A + num3] && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(src, num5, _0020_000A))
				{
					int num6 = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020(_0020, _0020_000A + 4, num5 + 4) + 4;
					if (num6 > num3)
					{
						num3 = num6;
						_0020_0020 = num5;
					}
				}
				num5 -= chainTable[num5 & 0xFFFF];
			}
			if (num2 != 0)
			{
				int i = _0020_000A;
				int num7;
				for (num7 = _0020_000A + num2 - 3; i < num7 - num4; i++)
				{
					chainTable[i & 0xFFFF] = num4;
				}
				do
				{
					chainTable[i & 0xFFFF] = num4;
					hashTable[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(src, i) * -1640531535) >> 17] = i - src_base;
					i++;
				}
				while (i < num7);
				_0020.nextToUpdate = num7;
			}
			return num3;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A _0020, int _0020_000A, int _0020_0020, int _0020_000A_000A, ref int _0020_000A_0020, ref int _0020_0020_000A)
		{
			ushort[] chainTable = _0020.chainTable;
			int[] hashTable = _0020.hashTable;
			byte[] src = _0020.src;
			int src_base = _0020.src_base;
			int src_LASTLITERALS = _0020.src_LASTLITERALS;
			int[] array = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A;
			int num = 256;
			int num2 = _0020_000A - _0020_0020;
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A(_0020, _0020_000A);
			int num3 = hashTable[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(src, _0020_000A) * -1640531535) >> 17] + src_base;
			while (num3 >= _0020_000A - 65535 && num != 0)
			{
				num--;
				if (src[_0020_0020 + _0020_000A_000A] == src[num3 - num2 + _0020_000A_000A] && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(src, num3, _0020_000A))
				{
					int num4 = num3 + 4;
					int num5 = _0020_000A + 4;
					int num6 = _0020_000A;
					while (true)
					{
						if (num5 < src_LASTLITERALS - 3)
						{
							int num7 = (int)_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A(src, num4, num5);
							if (num7 == 0)
							{
								num5 += 4;
								num4 += 4;
								continue;
							}
							num5 += array[(uint)((num7 & -num7) * 125613361) >> 27];
							break;
						}
						if (num5 < src_LASTLITERALS - 1 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(src, num4, num5))
						{
							num5 += 2;
							num4 += 2;
						}
						if (num5 < src_LASTLITERALS && src[num4] == src[num5])
						{
							num5++;
						}
						break;
					}
					num4 = num3;
					while (num6 > _0020_0020 && num4 > src_base && src[num6 - 1] == src[num4 - 1])
					{
						num6--;
						num4--;
					}
					if (num5 - num6 > _0020_000A_000A)
					{
						_0020_000A_000A = num5 - num6;
						_0020_000A_0020 = num4;
						_0020_0020_000A = num6;
					}
				}
				num3 -= chainTable[num3 & 0xFFFF];
			}
			return _0020_000A_000A;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A _0020, ref int _0020_000A, ref int _0020_0020, ref int _0020_000A_000A, int _0020_000A_0020, int _0020_0020_000A, int _0020_0020_0020)
		{
			byte[] src = _0020.src;
			byte[] dst = _0020.dst;
			int num = _0020_000A - _0020_000A_000A;
			int num2 = _0020_0020++;
			if (_0020_0020 + num + 8 + (num >> 8) > _0020_0020_0020)
			{
				return 1;
			}
			int num3;
			if (num >= 15)
			{
				dst[num2] = 240;
				for (num3 = num - 15; num3 > 254; num3 -= 255)
				{
					dst[_0020_0020++] = byte.MaxValue;
				}
				dst[_0020_0020++] = (byte)num3;
			}
			else
			{
				dst[num2] = (byte)(num << 4);
			}
			if (num > 0)
			{
				int num4 = _0020_0020 + num;
				_0020_000A_000A += _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A(src, _0020_000A_000A, dst, _0020_0020, num4);
				_0020_0020 = num4;
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A(dst, _0020_0020, (ushort)(_0020_000A - _0020_0020_000A));
			_0020_0020 += 2;
			num3 = _0020_000A_0020 - 4;
			if (_0020_0020 + 6 + (num >> 8) > _0020_0020_0020)
			{
				return 1;
			}
			if (num3 >= 15)
			{
				dst[num2] += 15;
				for (num3 -= 15; num3 > 509; num3 -= 510)
				{
					dst[_0020_0020++] = byte.MaxValue;
					dst[_0020_0020++] = byte.MaxValue;
				}
				if (num3 > 254)
				{
					num3 -= 255;
					dst[_0020_0020++] = byte.MaxValue;
				}
				dst[_0020_0020++] = (byte)num3;
			}
			else
			{
				dst[num2] += (byte)num3;
			}
			_0020_000A += _0020_000A_0020;
			_0020_000A_000A = _0020_000A;
			return 0;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A _0020)
		{
			byte[] src = _0020.src;
			byte[] dst = _0020.dst;
			int src_base = _0020.src_base;
			int src_end = _0020.src_end;
			int dst_base = _0020.dst_base;
			int dst_len = _0020.dst_len;
			int dst_end = _0020.dst_end;
			int num = src_base;
			int num2 = num;
			int num3 = src_end - 12;
			int num4 = dst_base;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			num++;
			while (num < num3)
			{
				int num10 = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A(_0020, num, ref num5);
				if (num10 == 0)
				{
					num++;
					continue;
				}
				int num11 = num;
				int num12 = num5;
				int num13 = num10;
				while (true)
				{
					int num14 = (num + num10 < num3) ? _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020(_0020, num + num10 - 2, num + 1, num10, ref num7, ref num6) : num10;
					if (num14 == num10)
					{
						if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(_0020, ref num, ref num4, ref num2, num10, num5, dst_end) == 0)
						{
							break;
						}
						return 0;
					}
					if (num11 < num && num6 < num + num13)
					{
						num = num11;
						num5 = num12;
						num10 = num13;
					}
					if (num6 - num < 3)
					{
						num10 = num14;
						num = num6;
						num5 = num7;
						continue;
					}
					int num17;
					while (true)
					{
						if (num6 - num < 18)
						{
							int num15 = num10;
							if (num15 > 18)
							{
								num15 = 18;
							}
							if (num + num15 > num6 + num14 - 4)
							{
								num15 = num6 - num + num14 - 4;
							}
							int num16 = num15 - (num6 - num);
							if (num16 > 0)
							{
								num6 += num16;
								num7 += num16;
								num14 -= num16;
							}
						}
						num17 = ((num6 + num14 < num3) ? _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020(_0020, num6 + num14 - 3, num6, num14, ref num9, ref num8) : num14);
						if (num17 == num14)
						{
							break;
						}
						if (num8 < num + num10 + 3)
						{
							if (num8 < num + num10)
							{
								num6 = num8;
								num7 = num9;
								num14 = num17;
								continue;
							}
							goto IL_01d1;
						}
						if (num6 < num + num10)
						{
							if (num6 - num < 15)
							{
								if (num10 > 18)
								{
									num10 = 18;
								}
								if (num + num10 > num6 + num14 - 4)
								{
									num10 = num6 - num + num14 - 4;
								}
								int num18 = num10 - (num6 - num);
								if (num18 > 0)
								{
									num6 += num18;
									num7 += num18;
									num14 -= num18;
								}
							}
							else
							{
								num10 = num6 - num;
							}
						}
						if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(_0020, ref num, ref num4, ref num2, num10, num5, dst_end) != 0)
						{
							return 0;
						}
						num = num6;
						num5 = num7;
						num10 = num14;
						num6 = num8;
						num7 = num9;
						num14 = num17;
					}
					if (num6 < num + num10)
					{
						num10 = num6 - num;
					}
					if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(_0020, ref num, ref num4, ref num2, num10, num5, dst_end) != 0)
					{
						return 0;
					}
					num = num6;
					if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(_0020, ref num, ref num4, ref num2, num14, num7, dst_end) == 0)
					{
						break;
					}
					return 0;
					IL_01d1:
					if (num6 < num + num10)
					{
						int num19 = num + num10 - num6;
						num6 += num19;
						num7 += num19;
						num14 -= num19;
						if (num14 < 4)
						{
							num6 = num8;
							num7 = num9;
							num14 = num17;
						}
					}
					if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(_0020, ref num, ref num4, ref num2, num10, num5, dst_end) != 0)
					{
						return 0;
					}
					num = num8;
					num5 = num9;
					num10 = num17;
					num11 = num6;
					num12 = num7;
					num13 = num14;
				}
			}
			int num20 = src_end - num2;
			if (num4 - dst_base + num20 + 1 + (num20 + 255 - 15) / 255 > (uint)dst_len)
			{
				return 0;
			}
			if (num20 >= 15)
			{
				dst[num4++] = 240;
				for (num20 -= 15; num20 > 254; num20 -= 255)
				{
					dst[num4++] = byte.MaxValue;
				}
				dst[num4++] = (byte)num20;
			}
			else
			{
				dst[num4++] = (byte)(num20 << 4);
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(src, num2, dst, num4, src_end - num2);
			num4 += src_end - num2;
			return num4 - dst_base;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A(int[] _0020, byte[] _0020_000A, byte[] _0020_0020, int _0020_000A_000A, int _0020_000A_0020, int _0020_0020_000A, int _0020_0020_0020)
		{
			int[] array = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020;
			int num = _0020_000A_000A;
			int num2 = _0020_000A_000A + _0020_0020_000A;
			int num3 = num2 - 12;
			int num4 = _0020_000A_0020;
			int num5 = num4 + _0020_0020_0020;
			int num6 = num2 - 5;
			int num7 = num6 - 1;
			int num8 = num6 - 3;
			int num9 = num6 - 7;
			int num10 = num5 - 6;
			int num11 = num5 - 8;
			if (_0020_0020_000A >= 13)
			{
				_0020[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, _0020_000A_000A) * -1640531535) >> 20] = _0020_000A_000A - _0020_000A_000A;
				int num12 = _0020_000A_000A + 1;
				uint num13 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num12) * -1640531535) >> 20;
				while (true)
				{
					int num14 = 67;
					int num15 = num12;
					int num19;
					while (true)
					{
						uint num16 = num13;
						int num18 = num14++ >> 6;
						num12 = num15;
						num15 = num12 + num18;
						if (num15 > num3)
						{
							break;
						}
						num13 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num15) * -1640531535) >> 20;
						num19 = _0020_000A_000A + _0020[num16];
						_0020[num16] = num12 - _0020_000A_000A;
						if (num19 < num12 - 65535 || !_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(_0020_000A, num19, num12))
						{
							continue;
						}
						goto IL_00e9;
					}
					break;
					IL_0365:
					num = num12++;
					num13 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num12) * -1640531535) >> 20;
					continue;
					IL_00e9:
					while (num12 > num && num19 > _0020_000A_000A && _0020_000A[num12 - 1] == _0020_000A[num19 - 1])
					{
						num12--;
						num19--;
					}
					int num21 = num12 - num;
					int num23 = num4++;
					if (num4 + num21 + (num21 >> 8) > num11)
					{
						return 0;
					}
					if (num21 >= 15)
					{
						int num24 = num21 - 15;
						_0020_0020[num23] = 240;
						if (num24 > 254)
						{
							do
							{
								_0020_0020[num4++] = byte.MaxValue;
								num24 -= 255;
							}
							while (num24 > 254);
							_0020_0020[num4++] = (byte)num24;
							_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(_0020_000A, num, _0020_0020, num4, num21);
							num4 += num21;
							goto IL_01b3;
						}
						_0020_0020[num4++] = (byte)num24;
					}
					else
					{
						_0020_0020[num23] = (byte)(num21 << 4);
					}
					if (num21 > 0)
					{
						int num28 = num4 + num21;
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A(_0020_000A, num, _0020_0020, num4, num28);
						num4 = num28;
					}
					goto IL_01b3;
					IL_01b3:
					while (true)
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A(_0020_0020, num4, (ushort)(num12 - num19));
						num4 += 2;
						num12 += 4;
						num19 += 4;
						num = num12;
						while (true)
						{
							if (num12 < num9)
							{
								long num29 = (long)_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020(_0020_000A, num19, num12);
								if (num29 == 0L)
								{
									num12 += 8;
									num19 += 8;
									continue;
								}
								num12 += array[(ulong)((num29 & -num29) * 151050438428048703L) >> 58];
								break;
							}
							if (num12 < num8 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(_0020_000A, num19, num12))
							{
								num12 += 4;
								num19 += 4;
							}
							if (num12 < num7 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(_0020_000A, num19, num12))
							{
								num12 += 2;
								num19 += 2;
							}
							if (num12 < num6 && _0020_000A[num19] == _0020_000A[num12])
							{
								num12++;
							}
							break;
						}
						num21 = num12 - num;
						if (num4 + (num21 >> 8) > num10)
						{
							return 0;
						}
						if (num21 >= 15)
						{
							_0020_0020[num23] += 15;
							for (num21 -= 15; num21 > 509; num21 -= 510)
							{
								_0020_0020[num4++] = byte.MaxValue;
								_0020_0020[num4++] = byte.MaxValue;
							}
							if (num21 > 254)
							{
								num21 -= 255;
								_0020_0020[num4++] = byte.MaxValue;
							}
							_0020_0020[num4++] = (byte)num21;
						}
						else
						{
							_0020_0020[num23] += (byte)num21;
						}
						if (num12 > num3)
						{
							break;
						}
						_0020[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num12 - 2) * -1640531535) >> 20] = num12 - 2 - _0020_000A_000A;
						uint num16 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num12) * -1640531535) >> 20;
						num19 = _0020_000A_000A + _0020[num16];
						_0020[num16] = num12 - _0020_000A_000A;
						if (num19 > num12 - 65536 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(_0020_000A, num19, num12))
						{
							num23 = num4++;
							_0020_0020[num23] = 0;
							continue;
						}
						goto IL_0365;
					}
					num = num12;
					break;
				}
			}
			int num35 = num2 - num;
			if (num4 + num35 + 1 + (num35 + 255 - 15) / 255 > num5)
			{
				return 0;
			}
			if (num35 >= 15)
			{
				_0020_0020[num4++] = 240;
				for (num35 -= 15; num35 > 254; num35 -= 255)
				{
					_0020_0020[num4++] = byte.MaxValue;
				}
				_0020_0020[num4++] = (byte)num35;
			}
			else
			{
				_0020_0020[num4++] = (byte)(num35 << 4);
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(_0020_000A, num, _0020_0020, num4, num2 - num);
			num4 += num2 - num;
			return num4 - _0020_000A_0020;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020(ushort[] _0020, byte[] _0020_000A, byte[] _0020_0020, int _0020_000A_000A, int _0020_000A_0020, int _0020_0020_000A, int _0020_0020_0020)
		{
			int[] array = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020;
			int num = _0020_000A_000A;
			int num2 = _0020_000A_000A + _0020_0020_000A;
			int num3 = num2 - 12;
			int num4 = _0020_000A_0020;
			int num5 = num4 + _0020_0020_0020;
			int num6 = num2 - 5;
			int num7 = num6 - 1;
			int num8 = num6 - 3;
			int num9 = num6 - 7;
			int num10 = num5 - 6;
			int num11 = num5 - 8;
			if (_0020_0020_000A >= 13)
			{
				int num12 = _0020_000A_000A + 1;
				uint num13 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num12) * -1640531535) >> 19;
				while (true)
				{
					int num14 = 67;
					int num15 = num12;
					int num19;
					while (true)
					{
						uint num16 = num13;
						int num18 = num14++ >> 6;
						num12 = num15;
						num15 = num12 + num18;
						if (num15 > num3)
						{
							break;
						}
						num13 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num15) * -1640531535) >> 19;
						num19 = _0020_000A_000A + _0020[num16];
						_0020[num16] = (ushort)(num12 - _0020_000A_000A);
						if (!_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(_0020_000A, num19, num12))
						{
							continue;
						}
						goto IL_00cc;
					}
					break;
					IL_0338:
					num = num12++;
					num13 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num12) * -1640531535) >> 19;
					continue;
					IL_00cc:
					while (num12 > num && num19 > _0020_000A_000A && _0020_000A[num12 - 1] == _0020_000A[num19 - 1])
					{
						num12--;
						num19--;
					}
					int num21 = num12 - num;
					int num23 = num4++;
					if (num4 + num21 + (num21 >> 8) > num11)
					{
						return 0;
					}
					if (num21 >= 15)
					{
						int num24 = num21 - 15;
						_0020_0020[num23] = 240;
						if (num24 > 254)
						{
							do
							{
								_0020_0020[num4++] = byte.MaxValue;
								num24 -= 255;
							}
							while (num24 > 254);
							_0020_0020[num4++] = (byte)num24;
							_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(_0020_000A, num, _0020_0020, num4, num21);
							num4 += num21;
							goto IL_0192;
						}
						_0020_0020[num4++] = (byte)num24;
					}
					else
					{
						_0020_0020[num23] = (byte)(num21 << 4);
					}
					if (num21 > 0)
					{
						int num28 = num4 + num21;
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A(_0020_000A, num, _0020_0020, num4, num28);
						num4 = num28;
					}
					goto IL_0192;
					IL_0192:
					while (true)
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A(_0020_0020, num4, (ushort)(num12 - num19));
						num4 += 2;
						num12 += 4;
						num19 += 4;
						num = num12;
						while (true)
						{
							if (num12 < num9)
							{
								long num29 = (long)_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020(_0020_000A, num19, num12);
								if (num29 == 0L)
								{
									num12 += 8;
									num19 += 8;
									continue;
								}
								num12 += array[(ulong)((num29 & -num29) * 151050438428048703L) >> 58];
								break;
							}
							if (num12 < num8 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(_0020_000A, num19, num12))
							{
								num12 += 4;
								num19 += 4;
							}
							if (num12 < num7 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(_0020_000A, num19, num12))
							{
								num12 += 2;
								num19 += 2;
							}
							if (num12 < num6 && _0020_000A[num19] == _0020_000A[num12])
							{
								num12++;
							}
							break;
						}
						int num24 = num12 - num;
						if (num4 + (num24 >> 8) > num10)
						{
							return 0;
						}
						if (num24 >= 15)
						{
							_0020_0020[num23] += 15;
							for (num24 -= 15; num24 > 509; num24 -= 510)
							{
								_0020_0020[num4++] = byte.MaxValue;
								_0020_0020[num4++] = byte.MaxValue;
							}
							if (num24 > 254)
							{
								num24 -= 255;
								_0020_0020[num4++] = byte.MaxValue;
							}
							_0020_0020[num4++] = (byte)num24;
						}
						else
						{
							_0020_0020[num23] += (byte)num24;
						}
						if (num12 > num3)
						{
							break;
						}
						_0020[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num12 - 2) * -1640531535) >> 19] = (ushort)(num12 - 2 - _0020_000A_000A);
						uint num16 = (uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A, num12) * -1640531535) >> 19;
						num19 = _0020_000A_000A + _0020[num16];
						_0020[num16] = (ushort)(num12 - _0020_000A_000A);
						if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(_0020_000A, num19, num12))
						{
							num23 = num4++;
							_0020_0020[num23] = 0;
							continue;
						}
						goto IL_0338;
					}
					num = num12;
					break;
				}
			}
			int num35 = num2 - num;
			if (num4 + num35 + 1 + (num35 - 15 + 255) / 255 > num5)
			{
				return 0;
			}
			if (num35 >= 15)
			{
				_0020_0020[num4++] = 240;
				for (num35 -= 15; num35 > 254; num35 -= 255)
				{
					_0020_0020[num4++] = byte.MaxValue;
				}
				_0020_0020[num4++] = (byte)num35;
			}
			else
			{
				_0020_0020[num4++] = (byte)(num35 << 4);
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(_0020_000A, num, _0020_0020, num4, num2 - num);
			num4 += num2 - num;
			return num4 - _0020_000A_0020;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A(byte[] _0020, byte[] _0020_000A, int _0020_0020, int _0020_000A_000A, int _0020_000A_0020)
		{
			int[] array = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A;
			int[] array2 = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020;
			int num = _0020_0020;
			int num2 = _0020_000A_000A;
			int num3 = num2 + _0020_000A_0020;
			int num4 = num3 - 5;
			int num5 = num3 - 8;
			int num6 = num3 - 8 - 4;
			while (true)
			{
				uint num8 = _0020[num++];
				int num9;
				if ((num9 = (byte)(num8 >> 4)) == 15)
				{
					int num11;
					while ((num11 = _0020[num++]) == 255)
					{
						num9 += 255;
					}
					num9 += num11;
				}
				int num12 = num2 + num9;
				if (num12 > num5)
				{
					if (num12 != num3)
					{
						break;
					}
					_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(_0020, num, _0020_000A, num2, num9);
					num += num9;
					return num - _0020_0020;
				}
				if (num2 < num12)
				{
					int num13 = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A(_0020, num, _0020_000A, num2, num12);
					num += num13;
					num2 += num13;
				}
				num -= num2 - num12;
				num2 = num12;
				int num14 = num12 - _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020(_0020, num);
				num += 2;
				if (num14 < _0020_000A_000A)
				{
					break;
				}
				if ((num9 = (byte)(num8 & 0xF)) == 15)
				{
					while (_0020[num] == byte.MaxValue)
					{
						num++;
						num9 += 255;
					}
					num9 += _0020[num++];
				}
				if (num2 - num14 < 8)
				{
					int num16 = array2[num2 - num14];
					_0020_000A[num2] = _0020_000A[num14];
					_0020_000A[num2 + 1] = _0020_000A[num14 + 1];
					_0020_000A[num2 + 2] = _0020_000A[num14 + 2];
					_0020_000A[num2 + 3] = _0020_000A[num14 + 3];
					num2 += 4;
					num14 += 4;
					num14 -= array[num2 - num14];
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A(_0020_000A, num14, num2);
					num2 += 4;
					num14 -= num16;
				}
				else
				{
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020(_0020_000A, num14, num2);
					num2 += 8;
					num14 += 8;
				}
				num12 = num2 + num9 - 4;
				if (num12 > num6)
				{
					if (num12 > num4)
					{
						break;
					}
					if (num2 < num5)
					{
						int num13 = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020(_0020_000A, num14, num2, num5);
						num14 += num13;
						num2 += num13;
					}
					while (num2 < num12)
					{
						_0020_000A[num2++] = _0020_000A[num14++];
					}
					num2 = num12;
				}
				else
				{
					if (num2 < num12)
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020(_0020_000A, num14, num2, num12);
					}
					num2 = num12;
				}
			}
			return -(num - _0020_0020);
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020(byte[] _0020, byte[] _0020_000A, int _0020_0020, int _0020_000A_000A, int _0020_000A_0020, int _0020_0020_000A)
		{
			int[] array = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A;
			int[] array2 = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020;
			int num = _0020_0020;
			int num2 = num + _0020_000A_0020;
			int num3 = _0020_000A_000A;
			int num4 = num3 + _0020_0020_000A;
			int num5 = num2 - 8;
			int num6 = num2 - 6;
			int num7 = num4 - 8;
			int num8 = num4 - 12;
			int num9 = num4 - 5;
			int num10 = num4 - 12;
			if (num != num2)
			{
				while (true)
				{
					byte b = _0020[num++];
					int num12;
					if ((num12 = b >> 4) == 15)
					{
						int num13 = 255;
						while (num < num2 && num13 == 255)
						{
							num12 += (num13 = _0020[num++]);
						}
					}
					int num15 = num3 + num12;
					if (num15 > num10 || num + num12 > num5)
					{
						if (num15 > num4 || num + num12 != num2)
						{
							break;
						}
						_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(_0020, num, _0020_000A, num3, num12);
						num3 += num12;
						return num3 - _0020_000A_000A;
					}
					if (num3 < num15)
					{
						int num16 = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A(_0020, num, _0020_000A, num3, num15);
						num += num16;
						num3 += num16;
					}
					num -= num3 - num15;
					num3 = num15;
					int num17 = num15 - _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020(_0020, num);
					num += 2;
					if (num17 < _0020_000A_000A)
					{
						break;
					}
					if ((num12 = (b & 0xF)) == 15)
					{
						while (num < num6)
						{
							int num19 = _0020[num++];
							num12 += num19;
							if (num19 != 255)
							{
								break;
							}
						}
					}
					if (num3 - num17 < 8)
					{
						int num20 = array2[num3 - num17];
						_0020_000A[num3] = _0020_000A[num17];
						_0020_000A[num3 + 1] = _0020_000A[num17 + 1];
						_0020_000A[num3 + 2] = _0020_000A[num17 + 2];
						_0020_000A[num3 + 3] = _0020_000A[num17 + 3];
						num3 += 4;
						num17 += 4;
						num17 -= array[num3 - num17];
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A(_0020_000A, num17, num3);
						num3 += 4;
						num17 -= num20;
					}
					else
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020(_0020_000A, num17, num3);
						num3 += 8;
						num17 += 8;
					}
					num15 = num3 + num12 - 4;
					if (num15 > num8)
					{
						if (num15 > num9)
						{
							break;
						}
						if (num3 < num7)
						{
							int num16 = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020(_0020_000A, num17, num3, num7);
							num17 += num16;
							num3 += num16;
						}
						while (num3 < num15)
						{
							_0020_000A[num3++] = _0020_000A[num17++];
						}
						num3 = num15;
					}
					else
					{
						if (num3 < num15)
						{
							_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020(_0020_000A, num17, num3, num15);
						}
						num3 = num15;
					}
				}
			}
			return -(num - _0020_0020);
		}

		private static void _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A _0020, int _0020_000A)
		{
			ushort[] chainTable = _0020.chainTable;
			int[] hashTable = _0020.hashTable;
			byte[] src = _0020.src;
			int src_base = _0020.src_base;
			int i;
			for (i = _0020.nextToUpdate; i < _0020_000A; i++)
			{
				int num = i;
				int num2 = num - (hashTable[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(src, num) * -1640531535) >> 17] + src_base);
				if (num2 > 65535)
				{
					num2 = 65535;
				}
				chainTable[num & 0xFFFF] = (ushort)num2;
				hashTable[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(src, num) * -1640531535) >> 17] = num - src_base;
			}
			_0020.nextToUpdate = i;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A _0020, int _0020_000A, int _0020_0020)
		{
			int[] array = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020;
			byte[] src = _0020.src;
			int src_LASTLITERALS = _0020.src_LASTLITERALS;
			int num = _0020_000A;
			while (num < src_LASTLITERALS - 7)
			{
				long num2 = (long)_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020(src, _0020_0020, num);
				if (num2 == 0L)
				{
					num += 8;
					_0020_0020 += 8;
					continue;
				}
				num += array[(ulong)((num2 & -num2) * 151050438428048703L) >> 58];
				return num - _0020_000A;
			}
			if (num < src_LASTLITERALS - 3 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(src, _0020_0020, num))
			{
				num += 4;
				_0020_0020 += 4;
			}
			if (num < src_LASTLITERALS - 1 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(src, _0020_0020, num))
			{
				num += 2;
				_0020_0020 += 2;
			}
			if (num < src_LASTLITERALS && src[_0020_0020] == src[num])
			{
				num++;
			}
			return num - _0020_000A;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A _0020, int _0020_000A, ref int _0020_0020)
		{
			ushort[] chainTable = _0020.chainTable;
			int[] hashTable = _0020.hashTable;
			byte[] src = _0020.src;
			int src_base = _0020.src_base;
			int num = 256;
			int num2 = 0;
			int num3 = 0;
			ushort num4 = 0;
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A(_0020, _0020_000A);
			int num5 = hashTable[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(src, _0020_000A) * -1640531535) >> 17] + src_base;
			if (num5 >= _0020_000A - 4)
			{
				if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(src, num5, _0020_000A))
				{
					num4 = (ushort)(_0020_000A - num5);
					num2 = (num3 = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020(_0020, _0020_000A + 4, num5 + 4) + 4);
					_0020_0020 = num5;
				}
				num5 -= chainTable[num5 & 0xFFFF];
			}
			while (num5 >= _0020_000A - 65535 && num != 0)
			{
				num--;
				if (src[num5 + num3] == src[_0020_000A + num3] && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(src, num5, _0020_000A))
				{
					int num6 = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020(_0020, _0020_000A + 4, num5 + 4) + 4;
					if (num6 > num3)
					{
						num3 = num6;
						_0020_0020 = num5;
					}
				}
				num5 -= chainTable[num5 & 0xFFFF];
			}
			if (num2 != 0)
			{
				int i = _0020_000A;
				int num7;
				for (num7 = _0020_000A + num2 - 3; i < num7 - num4; i++)
				{
					chainTable[i & 0xFFFF] = num4;
				}
				do
				{
					chainTable[i & 0xFFFF] = num4;
					hashTable[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(src, i) * -1640531535) >> 17] = i - src_base;
					i++;
				}
				while (i < num7);
				_0020.nextToUpdate = num7;
			}
			return num3;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A _0020, int _0020_000A, int _0020_0020, int _0020_000A_000A, ref int _0020_000A_0020, ref int _0020_0020_000A)
		{
			int[] array = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020;
			ushort[] chainTable = _0020.chainTable;
			int[] hashTable = _0020.hashTable;
			byte[] src = _0020.src;
			int src_base = _0020.src_base;
			int src_LASTLITERALS = _0020.src_LASTLITERALS;
			int num = 256;
			int num2 = _0020_000A - _0020_0020;
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A(_0020, _0020_000A);
			int num3 = hashTable[(uint)((int)_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(src, _0020_000A) * -1640531535) >> 17] + src_base;
			while (num3 >= _0020_000A - 65535 && num != 0)
			{
				num--;
				if (src[_0020_0020 + _0020_000A_000A] == src[num3 - num2 + _0020_000A_000A] && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(src, num3, _0020_000A))
				{
					int num4 = num3 + 4;
					int num5 = _0020_000A + 4;
					int num6 = _0020_000A;
					while (true)
					{
						if (num5 < src_LASTLITERALS - 7)
						{
							long num7 = (long)_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020(src, num4, num5);
							if (num7 == 0L)
							{
								num5 += 8;
								num4 += 8;
								continue;
							}
							num5 += array[(ulong)((num7 & -num7) * 151050438428048703L) >> 58];
							break;
						}
						if (num5 < src_LASTLITERALS - 3 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(src, num4, num5))
						{
							num5 += 4;
							num4 += 4;
						}
						if (num5 < src_LASTLITERALS - 1 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(src, num4, num5))
						{
							num5 += 2;
							num4 += 2;
						}
						if (num5 < src_LASTLITERALS && src[num4] == src[num5])
						{
							num5++;
						}
						break;
					}
					num4 = num3;
					while (num6 > _0020_0020 && num4 > src_base && src[num6 - 1] == src[num4 - 1])
					{
						num6--;
						num4--;
					}
					if (num5 - num6 > _0020_000A_000A)
					{
						_0020_000A_000A = num5 - num6;
						_0020_000A_0020 = num4;
						_0020_0020_000A = num6;
					}
				}
				num3 -= chainTable[num3 & 0xFFFF];
			}
			return _0020_000A_000A;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A _0020, ref int _0020_000A, ref int _0020_0020, ref int _0020_000A_000A, int _0020_000A_0020, int _0020_0020_000A)
		{
			byte[] src = _0020.src;
			byte[] dst = _0020.dst;
			int dst_end = _0020.dst_end;
			int num = _0020_000A - _0020_000A_000A;
			int num2 = _0020_0020++;
			if (_0020_0020 + num + 8 + (num >> 8) > dst_end)
			{
				return 1;
			}
			int num3;
			if (num >= 15)
			{
				dst[num2] = 240;
				for (num3 = num - 15; num3 > 254; num3 -= 255)
				{
					dst[_0020_0020++] = byte.MaxValue;
				}
				dst[_0020_0020++] = (byte)num3;
			}
			else
			{
				dst[num2] = (byte)(num << 4);
			}
			if (num > 0)
			{
				int num4 = _0020_0020 + num;
				_0020_000A_000A += _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A(src, _0020_000A_000A, dst, _0020_0020, num4);
				_0020_0020 = num4;
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A(dst, _0020_0020, (ushort)(_0020_000A - _0020_0020_000A));
			_0020_0020 += 2;
			num3 = _0020_000A_0020 - 4;
			if (_0020_0020 + 6 + (num >> 8) > dst_end)
			{
				return 1;
			}
			if (num3 >= 15)
			{
				dst[num2] += 15;
				for (num3 -= 15; num3 > 509; num3 -= 510)
				{
					dst[_0020_0020++] = byte.MaxValue;
					dst[_0020_0020++] = byte.MaxValue;
				}
				if (num3 > 254)
				{
					num3 -= 255;
					dst[_0020_0020++] = byte.MaxValue;
				}
				dst[_0020_0020++] = (byte)num3;
			}
			else
			{
				dst[num2] += (byte)num3;
			}
			_0020_000A += _0020_000A_0020;
			_0020_000A_000A = _0020_000A;
			return 0;
		}

		private static int _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A _0020)
		{
			byte[] src = _0020.src;
			int src_base = _0020.src_base;
			int src_end = _0020.src_end;
			int dst_base = _0020.dst_base;
			int num = src_base;
			int num2 = src_end - 12;
			byte[] dst = _0020.dst;
			int dst_len = _0020.dst_len;
			int num3 = _0020.dst_base;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			src_base++;
			while (src_base < num2)
			{
				int num9 = _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A(_0020, src_base, ref num4);
				if (num9 == 0)
				{
					src_base++;
					continue;
				}
				int num10 = src_base;
				int num11 = num4;
				int num12 = num9;
				while (true)
				{
					int num13 = (src_base + num9 < num2) ? _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020(_0020, src_base + num9 - 2, src_base + 1, num9, ref num6, ref num5) : num9;
					if (num13 == num9)
					{
						if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(_0020, ref src_base, ref num3, ref num, num9, num4) == 0)
						{
							break;
						}
						return 0;
					}
					if (num10 < src_base && num5 < src_base + num12)
					{
						src_base = num10;
						num4 = num11;
						num9 = num12;
					}
					if (num5 - src_base < 3)
					{
						num9 = num13;
						src_base = num5;
						num4 = num6;
						continue;
					}
					int num16;
					while (true)
					{
						if (num5 - src_base < 18)
						{
							int num14 = num9;
							if (num14 > 18)
							{
								num14 = 18;
							}
							if (src_base + num14 > num5 + num13 - 4)
							{
								num14 = num5 - src_base + num13 - 4;
							}
							int num15 = num14 - (num5 - src_base);
							if (num15 > 0)
							{
								num5 += num15;
								num6 += num15;
								num13 -= num15;
							}
						}
						num16 = ((num5 + num13 < num2) ? _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020(_0020, num5 + num13 - 3, num5, num13, ref num8, ref num7) : num13);
						if (num16 == num13)
						{
							break;
						}
						if (num7 < src_base + num9 + 3)
						{
							if (num7 < src_base + num9)
							{
								num5 = num7;
								num6 = num8;
								num13 = num16;
								continue;
							}
							goto IL_01b0;
						}
						if (num5 < src_base + num9)
						{
							if (num5 - src_base < 15)
							{
								if (num9 > 18)
								{
									num9 = 18;
								}
								if (src_base + num9 > num5 + num13 - 4)
								{
									num9 = num5 - src_base + num13 - 4;
								}
								int num17 = num9 - (num5 - src_base);
								if (num17 > 0)
								{
									num5 += num17;
									num6 += num17;
									num13 -= num17;
								}
							}
							else
							{
								num9 = num5 - src_base;
							}
						}
						if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(_0020, ref src_base, ref num3, ref num, num9, num4) != 0)
						{
							return 0;
						}
						src_base = num5;
						num4 = num6;
						num9 = num13;
						num5 = num7;
						num6 = num8;
						num13 = num16;
					}
					if (num5 < src_base + num9)
					{
						num9 = num5 - src_base;
					}
					if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(_0020, ref src_base, ref num3, ref num, num9, num4) != 0)
					{
						return 0;
					}
					src_base = num5;
					if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(_0020, ref src_base, ref num3, ref num, num13, num6) == 0)
					{
						break;
					}
					return 0;
					IL_01b0:
					if (num5 < src_base + num9)
					{
						int num18 = src_base + num9 - num5;
						num5 += num18;
						num6 += num18;
						num13 -= num18;
						if (num13 < 4)
						{
							num5 = num7;
							num6 = num8;
							num13 = num16;
						}
					}
					if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(_0020, ref src_base, ref num3, ref num, num9, num4) != 0)
					{
						return 0;
					}
					src_base = num7;
					num4 = num8;
					num9 = num16;
					num10 = num5;
					num11 = num6;
					num12 = num13;
				}
			}
			int num19 = src_end - num;
			if (num3 - dst_base + num19 + 1 + (num19 + 255 - 15) / 255 > (uint)dst_len)
			{
				return 0;
			}
			if (num19 >= 15)
			{
				dst[num3++] = 240;
				for (num19 -= 15; num19 > 254; num19 -= 255)
				{
					dst[num3++] = byte.MaxValue;
				}
				dst[num3++] = (byte)num19;
			}
			else
			{
				dst[num3++] = (byte)(num19 << 4);
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(src, num, dst, num3, src_end - num);
			num3 += src_end - num;
			return num3 - dst_base;
		}
	}
}
