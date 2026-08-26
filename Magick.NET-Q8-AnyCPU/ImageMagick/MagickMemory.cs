using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

internal static class MagickMemory
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
			public static extern void MagickMemory_Relinquish(IntPtr value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickMemory_Relinquish(IntPtr value);
		}
	}

	private static class NativeMagickMemory
	{
		static NativeMagickMemory()
		{
			Environment.Initialize();
		}

		public static void Relinquish(IntPtr value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickMemory_Relinquish(value);
			}
			else
			{
				NativeMethods.X86.MagickMemory_Relinquish(value);
			}
		}
	}

	public static void Relinquish(IntPtr value)
	{
		NativeMagickMemory.Relinquish(value);
	}
}
