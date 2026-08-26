using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

public static class Quantum
{
	private static class NativeMethods
	{
		public static class X64
		{
			static X64()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr Quantum_Depth_Get();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern byte Quantum_Max_Get();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern byte Quantum_ScaleToByte(byte value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr Quantum_Depth_Get();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern byte Quantum_Max_Get();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern byte Quantum_ScaleToByte(byte value);
		}
	}

	private static class NativeQuantum
	{
		public static int Depth
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.Quantum_Depth_Get() : NativeMethods.X64.Quantum_Depth_Get());
				return (int)(uint)uIntPtr;
			}
		}

		public static byte Max
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.Quantum_Max_Get();
				}
				return NativeMethods.X86.Quantum_Max_Get();
			}
		}

		static NativeQuantum()
		{
			Environment.Initialize();
		}

		public static byte ScaleToByte(byte value)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.Quantum_ScaleToByte(value);
			}
			return NativeMethods.X86.Quantum_ScaleToByte(value);
		}
	}

	public static int Depth => NativeQuantum.Depth;

	public static byte Max => NativeQuantum.Max;

	internal static byte Convert(byte value)
	{
		return value;
	}

	internal static byte Convert(double value)
	{
		if (value < 0.0)
		{
			return 0;
		}
		if (value > (double)(int)Max)
		{
			return Max;
		}
		return (byte)value;
	}

	internal static byte Convert(int value)
	{
		if (value < 0)
		{
			return 0;
		}
		if (value > Max)
		{
			return Max;
		}
		return (byte)value;
	}

	internal static byte Convert(ushort value)
	{
		return (byte)((uint)(value + 128) / 257u);
	}

	internal static byte ScaleToQuantum(double value)
	{
		return (byte)Math.Min(Math.Max(0.0, value * (double)(int)Max), (int)Max);
	}

	internal static byte ScaleToByte(byte value)
	{
		return NativeQuantum.ScaleToByte(value);
	}

	internal static double ScaleToDouble(byte value)
	{
		return 1.0 / (double)(int)Max * (double)(int)value;
	}
}
