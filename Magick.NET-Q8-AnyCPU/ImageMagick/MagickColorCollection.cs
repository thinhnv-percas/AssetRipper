using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ImageMagick;

internal static class MagickColorCollection
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
			public static extern void MagickColorCollection_DisposeList(IntPtr list);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickColorCollection_GetInstance(IntPtr list, UIntPtr index);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickColorCollection_DisposeList(IntPtr list);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickColorCollection_GetInstance(IntPtr list, UIntPtr index);
		}
	}

	private static class NativeMagickColorCollection
	{
		static NativeMagickColorCollection()
		{
			Environment.Initialize();
		}

		public static void DisposeList(IntPtr list)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickColorCollection_DisposeList(list);
			}
			else
			{
				NativeMethods.X86.MagickColorCollection_DisposeList(list);
			}
		}

		public static IntPtr GetInstance(IntPtr list, int index)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.MagickColorCollection_GetInstance(list, (UIntPtr)(ulong)index);
			}
			return NativeMethods.X86.MagickColorCollection_GetInstance(list, (UIntPtr)(ulong)index);
		}
	}

	public static void DisposeList(IntPtr list)
	{
		if (list != IntPtr.Zero)
		{
			NativeMagickColorCollection.DisposeList(list);
		}
	}

	public static Dictionary<MagickColor, int> ToDictionary(IntPtr list, int length)
	{
		Dictionary<MagickColor, int> dictionary = new Dictionary<MagickColor, int>();
		if (list == IntPtr.Zero)
		{
			return dictionary;
		}
		for (int i = 0; i < length; i++)
		{
			MagickColor magickColor = MagickColor.CreateInstance(NativeMagickColorCollection.GetInstance(list, i));
			dictionary[magickColor] = magickColor.Count;
		}
		return dictionary;
	}
}
