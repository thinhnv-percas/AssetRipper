using @as;
using DSMCaps.Arm;
using DSMCaps.X86;
using Microsoft.Win32.SafeHandles;
using SpirV;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Wasm;
using Wasm.Interpret;

namespace DSMCaps
{
	internal class _0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020
	{
		internal static void _0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A(byte[] _0020)
		{
			using (CapstoneArmDisassembler capstoneArmDisassembler = CapstoneDisassembler.CreateArmDisassembler(ArmDisassembleMode.Arm))
			{
				capstoneArmDisassembler.EnableInstructionDetails = true;
				capstoneArmDisassembler.DisassembleSyntax = DisassembleSyntax.Masm;
				ConsoleManager.WriteInfo(BitConverter.ToString(_0020).Replace("-", " "));
				ArmInstruction[] array = capstoneArmDisassembler.Disassemble(_0020);
				foreach (ArmInstruction armInstruction in array)
				{
					long address = armInstruction.Address;
					ArmInstructionId id = armInstruction.Id;
					if (!armInstruction.IsDietModeEnabled)
					{
						string mnemonic = armInstruction.Mnemonic;
						string operand = armInstruction.Operand;
						ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A("{0:X}: \t {1} \t {2}", address, mnemonic, operand);
					}
					else
					{
						ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A("{0:X}:", address);
						ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A("\t Id = {0}", id);
					}
				}
			}
		}
	}
	internal class _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020
	{
		internal static IntPtr _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020_00601<_0020>()
		{
			return Marshal.AllocHGlobal(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_00601<_0020>());
		}

		internal static IntPtr _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020_00601<_0020_000A>(int _0020)
		{
			return Marshal.AllocHGlobal(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_00601<_0020_000A>() * _0020);
		}

		internal static _0020_000A _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_00601<_0020_000A>(IntPtr _0020)
		{
			object obj = Marshal.PtrToStructure(_0020, typeof(_0020_000A));
			Marshal.FreeHGlobal(_0020);
			return (_0020_000A)obj;
		}

		internal static _0020_000A _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_00601<_0020_000A>(IntPtr _0020)
		{
			return (_0020_000A)Marshal.PtrToStructure(_0020, typeof(_0020_000A));
		}

		internal static _0020_0020[] _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_00601<_0020_0020>(IntPtr _0020, int _0020_000A)
		{
			_0020_0020[] array = new _0020_0020[_0020_000A];
			IntPtr intPtr = _0020;
			for (int i = 0; i < _0020_000A; i++)
			{
				_0020_0020 val = array[i] = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_00601<_0020_0020>(intPtr);
				intPtr += Marshal.SizeOf(typeof(_0020_0020));
			}
			return array;
		}

		internal static int _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_00601<_0020>()
		{
			return Marshal.SizeOf(typeof(_0020));
		}
	}
	internal class _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A : IDisposable
	{
		internal string _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A;

		internal static _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A Create()
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A result = new _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A
			{
				_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A = Directory.GetCurrentDirectory()
			};
			Directory.SetCurrentDirectory(Path.Combine(DevXSystemInfo.StreamingAssets, "ArmCP", Environment.Is64BitProcess ? "x64" : "x86"));
			return result;
		}

		public void Dispose()
		{
			Directory.SetCurrentDirectory(_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A);
		}
	}
	internal class _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate IntPtr _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020(IntPtr pBinaryCode, IntPtr binaryCodeSize, IntPtr dataOffset, IntPtr pState);

		internal const int _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020 = 80;

		static _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020()
		{
		}

		internal static _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A(DisassembleArchitecture _0020, NativeDisassembleMode _0020_000A)
		{
			IntPtr zero = IntPtr.Zero;
			switch (_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.CreateDisassembler(_0020, _0020_000A, ref zero))
			{
			case NativeCapstoneResultCode.UninitializedMemoryManagement:
				throw new CapstoneException("Memory Management is uninitialized.");
			case NativeCapstoneResultCode.UnsupportedDisassembleArchitecture:
				throw new ArgumentException($"A disassemble architecture ({_0020}) is invalid.", "disassembleArchitecture");
			case NativeCapstoneResultCode.UnsupportedDisassembleMode:
				throw new ArgumentException($"A disassemble mode ({_0020_000A}) is invalid.", "disassembleMode");
			case NativeCapstoneResultCode.OutOfMemory:
				throw new OutOfMemoryException("Sufficient memory could not be allocated.");
			default:
				throw new CapstoneException("A disassembler could not be created.");
			case NativeCapstoneResultCode.Ok:
				return new _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020(zero);
			}
		}

		internal static _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020)
		{
			return new _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.CreateInstruction(_0020));
		}

		internal static Tuple<short[], short[]> _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A _0020_000A)
		{
			short[] array = new short[64];
			byte b = 0;
			short[] array2 = new short[64];
			byte b2 = 0;
			switch (_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.GetAccessedRegisters(_0020, _0020_000A, array, ref b, array2, ref b2))
			{
			case (NativeCapstoneResultCode)(-1):
				throw new ArgumentException("A disassembler handle (hDisassembler) is invalid.", "hDisassembler");
			case NativeCapstoneResultCode.UnsupportedDisassembleArchitecture:
				throw new NotSupportedException("A disassembler's hardware architecture is not supported.");
			case NativeCapstoneResultCode.UnSupportedDietModeOperation:
				throw new NotSupportedException("An operation is not supported when diet mode is enabled.");
			case NativeCapstoneResultCode.UnsupportedInstructionDetail:
				throw new InvalidOperationException("An operation is not supported when instruction details are disabled.");
			case NativeCapstoneResultCode.UnsupportedSkipDataModeOperation:
				throw new InvalidOperationException("An operation is not supported when skip-data mode is enabled.");
			default:
				throw new CapstoneException("An instruction's accessed registers could not be retrieved.");
			case NativeCapstoneResultCode.Ok:
			{
				short[] array3 = new short[b];
				short[] array4 = new short[b2];
				Array.Copy(array, array3, array3.Length);
				Array.Copy(array2, array4, array4.Length);
				return Tuple.Create(array3, array4);
			}
			}
		}

		internal static _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A _0020)
		{
			IntPtr _00202 = _0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A();
			try
			{
				return _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_00601<_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A>(_00202);
			}
			finally
			{
				_0020.DangerousRelease();
			}
		}

		internal static _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020? _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A _0020)
		{
			IntPtr value = _0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A();
			try
			{
				IntPtr value2 = Marshal.OffsetOf(typeof(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A), "Details");
				IntPtr intPtr = Marshal.ReadIntPtr((IntPtr)((long)value + (long)value2));
				_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020? result = null;
				if (intPtr != IntPtr.Zero)
				{
					result = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_00601<_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020>(intPtr);
				}
				return result;
			}
			finally
			{
				_0020.DangerousRelease();
			}
		}

		internal static _0020_000A? _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A<_0020_000A>(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A _0020) where _0020_000A : struct
		{
			IntPtr value = _0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A();
			try
			{
				IntPtr value2 = Marshal.OffsetOf(typeof(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A), "Details");
				IntPtr intPtr = Marshal.ReadIntPtr((IntPtr)((long)value + (long)value2));
				_0020_000A? result = null;
				if (intPtr != IntPtr.Zero)
				{
					IntPtr ptr = intPtr + 80;
					result = (_0020_000A)Marshal.PtrToStructure(ptr, typeof(_0020_000A));
				}
				return result;
			}
			finally
			{
				_0020.DangerousRelease();
			}
		}

		internal static _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020? _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A(ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A _0020)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020? result = null;
			if (_0020.Details != IntPtr.Zero)
			{
				IntPtr details = _0020.Details;
				result = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_00601<_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020>(details);
			}
			return result;
		}

		internal static _0020_000A? _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A<_0020_000A>(ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A _0020) where _0020_000A : struct
		{
			_0020_000A? result = null;
			if (_0020.Details != IntPtr.Zero)
			{
				IntPtr _00202 = _0020.Details + 80;
				result = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_00601<_0020_000A>(_00202);
			}
			return result;
		}

		internal unsafe static string _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020, int _0020_000A)
		{
			string result = null;
			IntPtr instructionGroupName = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.GetInstructionGroupName(_0020, _0020_000A);
			if (instructionGroupName != IntPtr.Zero)
			{
				result = new string((sbyte*)(void*)instructionGroupName);
			}
			return result;
		}

		internal unsafe static string _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020, int _0020_000A)
		{
			string result = null;
			IntPtr registerName = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.GetRegisterName(_0020, _0020_000A);
			if (registerName != IntPtr.Zero)
			{
				result = new string((sbyte*)(void*)registerName);
			}
			return result;
		}

		internal static Version _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020()
		{
			int major = 0;
			int minor = 0;
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.GetVersion(ref major, ref minor);
			return new Version(major, minor);
		}

		internal static bool _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020, byte[] _0020_000A, ref int _0020_0020, ref long _0020_000A_000A, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A _0020_000A_0020)
		{
			GCHandle gCHandle = GCHandle.Alloc(_0020_000A, GCHandleType.Pinned);
			try
			{
				IntPtr intPtr = gCHandle.AddrOfPinnedObject() + _0020_0020;
				IntPtr intPtr2 = (IntPtr)_0020_000A.Length - _0020_0020;
				IntPtr value = intPtr;
				bool num = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.Iterate(_0020, ref intPtr, ref intPtr2, ref _0020_000A_000A, _0020_000A_0020);
				if (num)
				{
					_0020_0020 += (int)((long)intPtr - (long)value);
				}
				return num;
			}
			finally
			{
				if (gCHandle.IsAllocated)
				{
					gCHandle.Free();
				}
			}
		}

		[Conditional("NET45")]
		[Conditional("NET40")]
		internal static void _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020()
		{
			try
			{
				_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.LoadLibrary(Path.Combine(DevXSystemInfo.StreamingAssets, "ArmCP", Environment.Is64BitProcess ? "x64" : "x86", "arm_cp.dll"));
			}
			catch
			{
			}
		}

		internal static bool _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption _0020)
		{
			return _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.Query(_0020);
		}

		internal static void _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020, NativeDisassembleMode _0020_000A)
		{
			switch (_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.SetDisassemblerOption(_0020, NativeDisassemblerOptionType.SetDisassembleMode, (IntPtr)(int)_0020_000A))
			{
			case NativeCapstoneResultCode.Ok:
				break;
			case NativeCapstoneResultCode.InvalidOption:
				throw new ArgumentException("An option (optionType) is invalid.", "optionType");
			default:
				throw new CapstoneException($"A disassembler option ({NativeDisassemblerOptionType.SetDisassembleMode}) could not be set.");
			}
		}

		internal static void _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020, NativeDisassemblerOptionType _0020_000A, NativeDisassemblerOptionValue _0020_0020)
		{
			if (_0020_000A == NativeDisassemblerOptionType.SetSkipDataConfig)
			{
				throw new NotSupportedException($"A disassembler option ({_0020_000A}) is unsupported.");
			}
			switch (_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.SetDisassemblerOption(_0020, _0020_000A, (IntPtr)(int)_0020_0020))
			{
			case NativeCapstoneResultCode.Ok:
				break;
			case NativeCapstoneResultCode.InvalidHandle2:
				throw new ArgumentException("A disassembler handle (hDisassembler) is invalid.", "hDisassembler");
			case NativeCapstoneResultCode.InvalidOption:
				throw new ArgumentException("An option (optionType) is invalid.", "optionType");
			default:
				throw new CapstoneException($"A disassembler option ({_0020_000A}) could not be set.");
			}
		}

		internal static void _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020 _0020_000A)
		{
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				intPtr = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020_00601<_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020>();
				Marshal.StructureToPtr((object)_0020_000A, intPtr, fDeleteOld: false);
				switch (_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.SetDisassemblerOption(_0020, NativeDisassemblerOptionType.SetMnemonic, intPtr))
				{
				case NativeCapstoneResultCode.Ok:
					break;
				case NativeCapstoneResultCode.InvalidHandle2:
					throw new ArgumentException("A disassembler handle (hDisassembler) is invalid.", "hDisassembler");
				default:
					throw new CapstoneException($"A disassembler option ({NativeDisassemblerOptionType.SetMnemonic}) could not be set.");
				}
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}

		internal static void _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A _0020_000A)
		{
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				intPtr = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020_00601<_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A>();
				Marshal.StructureToPtr((object)_0020_000A, intPtr, fDeleteOld: false);
				_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.SetDisassemblerOption(_0020, NativeDisassemblerOptionType.SetSkipDataConfig, intPtr);
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}
	}
	internal class _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A
	{
		[DllImport("arm_cp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_close")]
		internal static extern NativeCapstoneResultCode CloseDisassembler(ref IntPtr _0020);

		[DllImport("arm_cp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_open")]
		internal static extern NativeCapstoneResultCode CreateDisassembler(DisassembleArchitecture _0020, NativeDisassembleMode _0020_000A, ref IntPtr _0020_0020);

		[DllImport("arm_cp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_malloc")]
		internal static extern IntPtr CreateInstruction(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020);

		[DllImport("arm_cp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_disasm")]
		internal static extern IntPtr Disassemble(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020, IntPtr _0020_000A, IntPtr _0020_0020, long _0020_000A_000A, IntPtr _0020_000A_0020, ref IntPtr _0020_0020_000A);

		[DllImport("arm_cp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_free")]
		internal static extern void FreeInstructions(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("arm_cp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_regs_access")]
		internal static extern NativeCapstoneResultCode GetAccessedRegisters(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A _0020_000A, short[] _0020_0020, ref byte _0020_000A_000A, short[] _0020_000A_0020, ref byte _0020_0020_000A);

		[DllImport("arm_cp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_group_name")]
		internal static extern IntPtr GetInstructionGroupName(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020, int _0020_000A);

		[DllImport("arm_cp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_errno")]
		internal static extern NativeCapstoneResultCode GetLastErrorCode(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020);

		[DllImport("arm_cp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_reg_name")]
		internal static extern IntPtr GetRegisterName(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020, int _0020_000A);

		[DllImport("arm_cp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_version")]
		internal static extern int GetVersion(ref int _0020, ref int _0020_000A);

		[DllImport("arm_cp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_disasm_iter")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool Iterate(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020, ref IntPtr _0020_000A, ref IntPtr _0020_0020, ref long _0020_000A_000A, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A _0020_000A_0020);

		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "LoadLibraryA", SetLastError = true)]
		internal static extern IntPtr LoadLibrary(string _0020);

		[DllImport("arm_cp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_support")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool Query(NativeQueryOption _0020);

		[DllImport("arm_cp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_option")]
		internal static extern NativeCapstoneResultCode SetDisassemblerOption(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _0020, NativeDisassemblerOptionType _0020_000A, IntPtr _0020_0020);
	}
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 : SafeHandleZeroOrMinusOneIsInvalid
	{
		internal _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020(IntPtr pDisassembler)
			: base(ownsHandle: true)
		{
			handle = pDisassembler;
		}

		protected override bool ReleaseHandle()
		{
			return _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.CloseDisassembler(ref handle) == NativeCapstoneResultCode.Ok;
		}
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A
	{
		public int Id;

		public long Address;

		public short Size;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] Bytes;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string Mnemonic;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 160)]
		public string Operand;

		public IntPtr Details;
	}
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		public short[] ImplicitlyReadRegisters;

		public byte ImplicitlyReadRegisterCount;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public short[] ImplicitlyWrittenRegisters;

		public byte ImplicitlyWrittenRegisterCount;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public byte[] Groups;

		public byte GroupCount;
	}
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A : SafeHandleZeroOrMinusOneIsInvalid
	{
		internal _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A(IntPtr pInstruction)
			: base(ownsHandle: true)
		{
			handle = pInstruction;
		}

		protected override bool ReleaseHandle()
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A.FreeInstructions(handle, (IntPtr)1);
			handle = IntPtr.Zero;
			return true;
		}
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020
	{
		public int InstructionId;

		[MarshalAs(UnmanagedType.LPStr)]
		public string InstructionMnemonic;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A
	{
		[MarshalAs(UnmanagedType.LPStr)]
		public string InstructionMnemonic;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020 Callback;

		public IntPtr State;
	}
	internal static class _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020
	{
		internal static IntPtr _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A(this SafeHandle _0020)
		{
			bool success = false;
			_0020.DangerousAddRef(ref success);
			if (!success)
			{
				throw new InvalidOperationException("Unable to add a reference to a handle.");
			}
			return _0020.DangerousGetHandle();
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020(object _0020, bool _0020_000A, float _0020_0020)
		{
			((Section)null).DumpNameAndPayload((TextWriter)null);
			return 629228769;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020(decimal _0020, short _0020_000A, int _0020_0020)
		{
			OperatorImpls.Int64Rotl(null, null);
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020(int _0020)
		{
			_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A._0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020((VerFormat)null);
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020()
		{
			((_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020)null).EqualsInternal((object)null);
			((PointerType)null).ResolveForwardReference((SpirV.Type)null);
			ModuleInstance module = ((InterpreterContext)null).Module;
			return 1510035795;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020()
		{
			X86Instruction.Create(null, null);
			((MainForm)null)._0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020((string)null);
			OperatorImpls.Int32Eqz(null, null);
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020(decimal _0020)
		{
			return "21517226";
		}
	}
}
