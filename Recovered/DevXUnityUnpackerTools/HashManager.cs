using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

internal class HashManager
{
	internal class _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020 : HashAlgorithm
	{
		internal const uint _0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A = 3988292384u;

		internal const uint _0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020 = uint.MaxValue;

		internal uint _0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020;

		internal uint _0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A;

		internal uint[] _0020_000A_000A_000A_000A_0020_0020_0020;

		internal static uint[] _0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020;

		public override int HashSize => 32;

		internal _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020()
		{
			_0020_000A_000A_000A_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020(3988292384u);
			_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A = uint.MaxValue;
			Initialize();
		}

		internal _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020(uint polynomial, uint seed)
		{
			_0020_000A_000A_000A_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020(polynomial);
			_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A = seed;
			Initialize();
		}

		public override void Initialize()
		{
			_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020 = _0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A;
		}

		protected override void HashCore(byte[] buffer, int start, int length)
		{
			_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(_0020_000A_000A_000A_000A_0020_0020_0020, _0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020, buffer, start, length);
		}

		protected override byte[] HashFinal()
		{
			return HashValue = _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020(~_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020);
		}

		internal static uint _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(byte[] _0020)
		{
			return ~_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020(3988292384u), uint.MaxValue, _0020, 0, _0020.Length);
		}

		internal static uint _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(uint[] _0020)
		{
			MemoryStream memoryStream = new MemoryStream();
			foreach (uint value in _0020)
			{
				memoryStream.Write(BitConverter.GetBytes(value), 0, 4);
			}
			byte[] array = memoryStream.ToArray();
			return ~_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020(3988292384u), uint.MaxValue, array, 0, array.Length);
		}

		internal static uint _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(string _0020)
		{
			if (_0020 == null || string.IsNullOrEmpty(_0020))
			{
				return 0u;
			}
			return _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(Encoding.UTF8.GetBytes(_0020));
		}

		internal static uint _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(uint _0020, byte[] _0020_000A)
		{
			return ~_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020(3988292384u), _0020, _0020_000A, 0, _0020_000A.Length);
		}

		internal static uint _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(uint _0020, uint _0020_000A, byte[] _0020_0020)
		{
			return ~_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020(_0020), _0020_000A, _0020_0020, 0, _0020_0020.Length);
		}

		internal static uint[] _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020(uint _0020)
		{
			if (_0020 == 3988292384u && _0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020 != null)
			{
				return _0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020;
			}
			uint[] array = new uint[256];
			for (int i = 0; i < 256; i++)
			{
				uint num = (uint)i;
				for (int j = 0; j < 8; j++)
				{
					num = (((num & 1) != 1) ? (num >> 1) : ((num >> 1) ^ _0020));
				}
				array[i] = num;
			}
			if (_0020 == 3988292384u)
			{
				_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020 = array;
			}
			return array;
		}

		internal static uint _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(uint[] _0020, uint _0020_000A, byte[] _0020_0020, int _0020_000A_000A, int _0020_000A_0020)
		{
			uint num = _0020_000A;
			for (int i = _0020_000A_000A; i < _0020_000A_0020; i++)
			{
				num = ((num >> 8) ^ _0020[_0020_0020[i] ^ (num & 0xFF)]);
			}
			return num;
		}

		internal byte[] _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020(uint _0020)
		{
			return new byte[4]
			{
				(byte)((_0020 >> 24) & 0xFF),
				(byte)((_0020 >> 16) & 0xFF),
				(byte)((_0020 >> 8) & 0xFF),
				(byte)(_0020 & 0xFF)
			};
		}
	}

	internal class _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020 : HashAlgorithm
	{
		public const ulong DefaultSeed = 0uL;

		internal readonly ulong[] _0020_000A_000A_000A_000A_0020_0020_0020;

		internal readonly ulong _0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A;

		internal ulong _0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020;

		public override int HashSize => 64;

		public _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020(ulong polynomial)
			: this(polynomial, 0uL)
		{
		}

		public _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020(ulong polynomial, ulong seed)
		{
			_0020_000A_000A_000A_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020(polynomial);
			_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A = (_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020 = seed);
		}

		public override void Initialize()
		{
			_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020 = _0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A;
		}

		protected override void HashCore(byte[] array, int ibStart, int cbSize)
		{
			_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020 = CalculateHash(_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020, _0020_000A_000A_000A_000A_0020_0020_0020, array, ibStart, cbSize);
		}

		protected override byte[] HashFinal()
		{
			return HashValue = _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A(_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020);
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

		internal static byte[] _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A(ulong _0020)
		{
			byte[] bytes = BitConverter.GetBytes(_0020);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			return bytes;
		}

		internal static ulong[] _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020(ulong _0020)
		{
			if (_0020 == 15564440312192434176uL && _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A._0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A != null)
			{
				return _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A._0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A;
			}
			ulong[] array = CreateTable(_0020);
			if (_0020 == 15564440312192434176uL)
			{
				_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A._0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A = array;
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

	internal class _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A : _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020
	{
		internal static ulong[] _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A;

		public const ulong Iso3309Polynomial = 15564440312192434176uL;

		public _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A()
			: base(15564440312192434176uL)
		{
		}

		public _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A(ulong seed)
			: base(15564440312192434176uL, seed)
		{
		}

		public static ulong Compute(byte[] buffer)
		{
			return Compute(0uL, buffer);
		}

		internal static ulong _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(string _0020)
		{
			if (_0020 == null || string.IsNullOrEmpty(_0020))
			{
				return 0uL;
			}
			return Compute(Encoding.UTF8.GetBytes(_0020));
		}

		public static ulong Compute(ulong seed, byte[] buffer)
		{
			if (_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A == null)
			{
				_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A = _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020.CreateTable(15564440312192434176uL);
			}
			return _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020.CalculateHash(seed, _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A, buffer, 0, buffer.Length);
		}
	}

	internal static bool _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A(string _0020)
	{
		return true;
	}

	internal static string _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020()
	{
		return CultureInfo.CurrentCulture.Name.Split('-')[0];
	}

	internal static bool _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020(string _0020)
	{
		return false;
	}

	internal static int _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_000A(string _0020)
	{
		return 0;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020(int _0020)
	{
		return string.Concat(_0020);
	}

	internal static string[] _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_000A()
	{
		return new string[0];
	}

	internal static string _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A_0020(string _0020)
	{
		return _0020;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(string _0020)
	{
		return _0020;
	}

	internal static uint _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(string _0020)
	{
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(_0020);
	}

	internal static string Calc(string _0020)
	{
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(_0020).ToString();
	}

	internal static ulong _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020(string _0020)
	{
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(_0020);
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A(string _0020)
	{
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(_0020).ToString();
	}

	internal static string DoNothing(string _0020)
	{
		return _0020;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A(string _0020)
	{
		return _0020;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020(string _0020)
	{
		return _0020;
	}

	internal static object _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A(string _0020, params object[] args)
	{
		return CallMethod(null, null, null, _0020, args);
	}

	internal static object _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020(object _0020, string _0020_000A, params object[] args)
	{
		return CallMethod(null, _0020, null, _0020_000A, args);
	}

	internal static object CallMethod(Type _0020, object _0020_000A, string _0020_0020, string _0020_000A_000A, params object[] args)
	{
		_0020 = null;
		if (_0020 == null)
		{
			if (_0020_000A != null)
			{
				_0020 = _0020_000A.GetType();
			}
			if (_0020_0020 != null)
			{
				_0020 = Type.GetType(_0020_0020, throwOnError: false);
			}
			if (_0020 == null)
			{
				MethodBase method = new StackTrace().GetFrames()[1].GetMethod();
				string name = method.Name;
				_0020 = method.DeclaringType;
				if (_0020 == null)
				{
					return null;
				}
			}
		}
		MethodInfo method2 = _0020.GetMethod(_0020_000A_000A, (BindingFlags)(((_0020_000A == null) ? 8 : 12) | 0x10 | 0x20));
		if (method2 == null)
		{
			return null;
		}
		return method2.Invoke(method2.IsStatic ? null : _0020_000A, args);
	}

	internal static object _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020(Type _0020, object _0020_000A, string _0020_0020, string _0020_000A_000A)
	{
		_0020 = null;
		if (_0020 == null)
		{
			if (_0020_000A != null)
			{
				_0020 = _0020_000A.GetType();
			}
			if (_0020_0020 != null)
			{
				_0020 = Type.GetType(_0020_0020, throwOnError: false);
			}
			if (_0020 == null)
			{
				MethodBase method = new StackTrace().GetFrames()[1].GetMethod();
				string name = method.Name;
				_0020 = method.DeclaringType;
				if (_0020 == null)
				{
					return null;
				}
			}
		}
		FieldInfo field = _0020.GetField(_0020_000A_000A, (BindingFlags)(((_0020_000A == null) ? 8 : 12) | 0x10 | 0x20));
		if (field == null)
		{
			return null;
		}
		return field.GetValue(field.IsStatic ? null : _0020_000A);
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A(Type _0020, object _0020_000A, string _0020_0020, string _0020_000A_000A, object _0020_000A_0020)
	{
		_0020 = null;
		if (_0020 == null)
		{
			if (_0020_000A != null)
			{
				_0020 = _0020_000A.GetType();
			}
			if (_0020_0020 != null)
			{
				_0020 = Type.GetType(_0020_0020, throwOnError: false);
			}
			if (_0020 == null)
			{
				MethodBase method = new StackTrace().GetFrames()[1].GetMethod();
				string name = method.Name;
				_0020 = method.DeclaringType;
				if (_0020 == null)
				{
					return false;
				}
			}
		}
		FieldInfo field = _0020.GetField(_0020_000A_000A, (BindingFlags)(((_0020_000A == null) ? 8 : 12) | 0x10 | 0x20));
		if (field == null)
		{
			return false;
		}
		field.SetValue(field.IsStatic ? null : _0020_000A, _0020_000A_0020);
		return true;
	}

	internal static object _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020(Type _0020, object _0020_000A, string _0020_0020, string _0020_000A_000A)
	{
		_0020 = null;
		if (_0020 == null)
		{
			if (_0020_000A != null)
			{
				_0020 = _0020_000A.GetType();
			}
			if (_0020_0020 != null)
			{
				_0020 = Type.GetType(_0020_0020, throwOnError: false);
			}
			if (_0020 == null)
			{
				MethodBase method = new StackTrace().GetFrames()[1].GetMethod();
				string name = method.Name;
				_0020 = method.DeclaringType;
				if (_0020 == null)
				{
					return null;
				}
			}
		}
		PropertyInfo property = _0020.GetProperty(_0020_000A_000A, (BindingFlags)(((_0020_000A == null) ? 8 : 12) | 0x10 | 0x20));
		if (property == null)
		{
			return null;
		}
		return property.GetValue((property.GetGetMethod() != null && property.GetGetMethod().IsStatic) ? null : _0020_000A, null);
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A(Type _0020, object _0020_000A, string _0020_0020, string _0020_000A_000A, object _0020_000A_0020)
	{
		_0020 = null;
		if (_0020 == null)
		{
			if (_0020_000A != null)
			{
				_0020 = _0020_000A.GetType();
			}
			if (_0020_0020 != null)
			{
				_0020 = Type.GetType(_0020_0020, throwOnError: false);
			}
			if (_0020 == null)
			{
				MethodBase method = new StackTrace().GetFrames()[1].GetMethod();
				string name = method.Name;
				_0020 = method.DeclaringType;
				if (_0020 == null)
				{
					return false;
				}
			}
		}
		PropertyInfo property = _0020.GetProperty(_0020_000A_000A, (BindingFlags)(((_0020_000A == null) ? 8 : 12) | 0x10 | 0x20));
		if (property == null)
		{
			return false;
		}
		property.SetValue((property.GetSetMethod() != null && property.GetSetMethod().IsStatic) ? null : _0020_000A, _0020_000A_0020, new object[0]);
		return true;
	}
}
