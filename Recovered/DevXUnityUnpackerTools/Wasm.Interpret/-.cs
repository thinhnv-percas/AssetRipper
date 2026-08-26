using @as;
using STL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Unity.IO.Compression;
using Wasm.Binary;

namespace Wasm.Interpret
{
	internal sealed class _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020 : FunctionDefinition
	{
		internal IList<WasmValueType> _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A;

		internal IList<WasmValueType> _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020;

		[CompilerGenerated]
		internal string _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020;

		[CompilerGenerated]
		internal TextWriter _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A;

		public string PrintSuffix
		{
			get;
			internal set;
		}

		public TextWriter PrintWriter
		{
			get;
			internal set;
		}

		public override IList<WasmValueType> ParameterTypes => _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A;

		public override IList<WasmValueType> ReturnTypes => _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020;

		public _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020(IList<WasmValueType> parameterTypes, IList<WasmValueType> returnTypes, string printSuffix, TextWriter printWriter)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A = parameterTypes;
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020 = returnTypes;
			PrintSuffix = printSuffix;
			PrintWriter = printWriter;
		}

		public override IList<object> Invoke(IList<object> arguments, uint callStackDepth = 0u)
		{
			for (int i = 0; i < arguments.Count; i++)
			{
				if (i > 0)
				{
					PrintWriter.Write(" ");
				}
				PrintWriter.Write(arguments[i]);
			}
			PrintWriter.Write(PrintSuffix);
			object[] array = new object[ReturnTypes.Count];
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = Variable.GetDefaultValue(ReturnTypes[j]);
			}
			return array;
		}
	}
	internal class _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A
	{
		internal static readonly int _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A = int.MinValue;

		internal static readonly long _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020 = long.MinValue;

		internal static Type _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020(WasmValueType _0020)
		{
			switch (_0020)
			{
			case WasmValueType.Float32:
				return typeof(float);
			case WasmValueType.Float64:
				return typeof(double);
			case WasmValueType.Int32:
				return typeof(int);
			case WasmValueType.Int64:
				return typeof(long);
			default:
				throw new WasmException($"Cannot convert unknown WebAssembly type '{_0020}' to a CLR type.");
			}
		}

		internal static WasmValueType _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A(Type _0020)
		{
			if (_0020 == typeof(int))
			{
				return WasmValueType.Int32;
			}
			if (_0020 == typeof(long))
			{
				return WasmValueType.Int64;
			}
			if (_0020 == typeof(float))
			{
				return WasmValueType.Float32;
			}
			if (_0020 == typeof(double))
			{
				return WasmValueType.Float64;
			}
			throw new WasmException($"Type '{_0020}' does not map to a WebAssembly type.");
		}

		internal static WasmValueType _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A<_0020>()
		{
			return _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A(typeof(_0020));
		}

		internal unsafe static float _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020(int _0020)
		{
			return *(float*)(&_0020);
		}

		internal unsafe static int _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A(float _0020)
		{
			return *(int*)(&_0020);
		}

		internal static double _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020(long _0020)
		{
			return BitConverter.Int64BitsToDouble(_0020);
		}

		internal static long _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A(double _0020)
		{
			return BitConverter.DoubleToInt64Bits(_0020);
		}

		internal static int _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020(int _0020, int _0020_000A)
		{
			return (_0020 << _0020_000A) | (int)((uint)_0020 >> 32 - _0020_000A);
		}

		internal static int _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A(int _0020, int _0020_000A)
		{
			return (int)((uint)_0020 >> _0020_000A) | (_0020 << 32 - _0020_000A);
		}

		internal static int _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020(int _0020)
		{
			uint num = (uint)_0020;
			int num2 = 32;
			while (num != 0)
			{
				num2--;
				num >>= 1;
			}
			return num2;
		}

		internal static int _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A(int _0020)
		{
			uint num = (uint)_0020;
			if (num == 0)
			{
				return 32;
			}
			int num2 = 0;
			while ((num & 1) == 0)
			{
				num2++;
				num >>= 1;
			}
			return num2;
		}

		internal static int _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020(int _0020)
		{
			uint num = (uint)_0020;
			int num2 = 0;
			while (num != 0)
			{
				num2 += (int)(num & 1);
				num >>= 1;
			}
			return num2;
		}

		internal static long _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020(long _0020, long _0020_000A)
		{
			int num = (int)_0020_000A;
			return (_0020 << num) | (long)((ulong)_0020 >> 64 - num);
		}

		internal static long _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A(long _0020, long _0020_000A)
		{
			int num = (int)_0020_000A;
			return (long)((ulong)_0020 >> num) | (_0020 << 64 - num);
		}

		internal static int _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020(long _0020)
		{
			ulong num = (ulong)_0020;
			int num2 = 64;
			while (num != 0L)
			{
				num2--;
				num >>= 1;
			}
			return num2;
		}

		internal static int _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A(long _0020)
		{
			ulong num = (ulong)_0020;
			if (num == 0L)
			{
				return 64;
			}
			int num2 = 0;
			while ((num & 1) == 0L)
			{
				num2++;
				num >>= 1;
			}
			return num2;
		}

		internal static int _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020(long _0020)
		{
			ulong num = (ulong)_0020;
			int num2 = 0;
			while (num != 0L)
			{
				num2 += (int)(num & 1);
				num >>= 1;
			}
			return num2;
		}

		internal static bool _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A(float _0020)
		{
			return (_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A(_0020) & _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A) == _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A;
		}

		internal static float _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020(float _0020, float _0020_000A)
		{
			int num = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A(_0020);
			int num2 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A(_0020_000A);
			return _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020((num & ~_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A) | (num2 & _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A));
		}

		internal static bool _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A(double _0020)
		{
			return (_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A(_0020) & _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020) == _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020;
		}

		internal static double _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020(double _0020, double _0020_000A)
		{
			long num = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A(_0020);
			long num2 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A(_0020_000A);
			return _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020((num & ~_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020) | (num2 & _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020));
		}

		internal static float _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A(float _0020, bool _0020_000A)
		{
			return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020(_0020, _0020_000A ? (-1f) : 1f);
		}

		internal static double _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A(double _0020, bool _0020_000A)
		{
			return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020(_0020, _0020_000A ? (-1.0) : 1.0);
		}

		internal static int _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020(float _0020)
		{
			if (float.IsInfinity(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_00601<int>();
			}
			if (float.IsNaN(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_00601<int>();
			}
			return checked((int)_0020);
		}

		internal static uint _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A(float _0020)
		{
			if (float.IsInfinity(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_00601<uint>();
			}
			if (float.IsNaN(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_00601<uint>();
			}
			return checked((uint)_0020);
		}

		internal static int _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020(double _0020)
		{
			if (double.IsInfinity(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_00601<int>();
			}
			if (double.IsNaN(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_00601<int>();
			}
			return checked((int)_0020);
		}

		internal static uint _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A(double _0020)
		{
			if (double.IsInfinity(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_00601<uint>();
			}
			if (double.IsNaN(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_00601<uint>();
			}
			return checked((uint)_0020);
		}

		internal static long _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020(float _0020)
		{
			if (float.IsInfinity(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_00601<long>();
			}
			if (float.IsNaN(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_00601<long>();
			}
			return checked((long)_0020);
		}

		internal static ulong _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A(float _0020)
		{
			if (float.IsInfinity(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_00601<ulong>();
			}
			if (float.IsNaN(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_00601<ulong>();
			}
			return checked((ulong)_0020);
		}

		internal static long _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020(double _0020)
		{
			if (double.IsInfinity(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_00601<long>();
			}
			if (double.IsNaN(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_00601<long>();
			}
			return checked((long)_0020);
		}

		internal static ulong _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A(double _0020)
		{
			if (double.IsInfinity(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_00601<ulong>();
			}
			if (double.IsNaN(_0020))
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_00601<ulong>();
			}
			return checked((ulong)_0020);
		}

		internal static int _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020(int _0020, int _0020_000A)
		{
			if (_0020 == int.MinValue && _0020_000A == -1)
			{
				return 0;
			}
			return _0020 % _0020_000A;
		}

		internal static long _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020(long _0020, long _0020_000A)
		{
			if (_0020 == long.MinValue && _0020_000A == -1)
			{
				return 0L;
			}
			return _0020 % _0020_000A;
		}

		internal static _0020 _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_00601<_0020>()
		{
			throw new TrapException("Cannot convert infinity to an integer.", "integer overflow");
		}

		internal static _0020 _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_00601<_0020>()
		{
			throw new TrapException("Cannot convert NaN to an integer.", "invalid conversion to integer");
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020(string _0020, object[] _0020_000A)
		{
			((_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A)null).RemoveField((string)null);
			FileManager.Write((string)null, (string)null);
			((MainForm)null)._0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A((string)null, (object)null);
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020(int _0020)
		{
			int num = ((_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A)null)._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020;
			return 1431271066;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020(string _0020, int _0020_000A)
		{
			((string)null).Interpolate((object[])null);
			((_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A)null)._0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020();
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020(uint _0020)
		{
			((BinaryWasmReader)null).ReadVarUInt1();
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020()
		{
			return 1263732896;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(string _0020)
		{
			int num = ((_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020)null)._0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020;
			((BinaryWasmWriter)null).WriteSection((Section)null);
		}
	}
}
