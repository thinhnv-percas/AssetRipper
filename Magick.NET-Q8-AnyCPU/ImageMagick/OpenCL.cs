using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace ImageMagick;

public static class OpenCL
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
			public static extern IntPtr OpenCL_GetDevices(out UIntPtr length);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr OpenCL_GetDevice(IntPtr list, UIntPtr index);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool OpenCL_SetEnabled([MarshalAs(UnmanagedType.Bool)] bool value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr OpenCL_GetDevices(out UIntPtr length);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr OpenCL_GetDevice(IntPtr list, UIntPtr index);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool OpenCL_SetEnabled([MarshalAs(UnmanagedType.Bool)] bool value);
		}
	}

	private static class NativeOpenCL
	{
		static NativeOpenCL()
		{
			Environment.Initialize();
		}

		public static IntPtr GetDevices(out UIntPtr length)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.OpenCL_GetDevices(out length);
			}
			return NativeMethods.X86.OpenCL_GetDevices(out length);
		}

		public static IntPtr GetDevice(IntPtr list, int index)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.OpenCL_GetDevice(list, (UIntPtr)(ulong)index);
			}
			return NativeMethods.X86.OpenCL_GetDevice(list, (UIntPtr)(ulong)index);
		}

		public static bool SetEnabled(bool value)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.OpenCL_SetEnabled(value);
			}
			return NativeMethods.X86.OpenCL_SetEnabled(value);
		}
	}

	private static bool? _isEnabled;

	public static bool IsEnabled
	{
		get
		{
			if (!_isEnabled.HasValue)
			{
				_isEnabled = NativeOpenCL.SetEnabled(value: true);
			}
			return _isEnabled.Value;
		}
		set
		{
			_isEnabled = NativeOpenCL.SetEnabled(value);
		}
	}

	public static IEnumerable<OpenCLDevice> Devices
	{
		get
		{
			IntPtr devices = NativeOpenCL.GetDevices(out var length);
			Collection<OpenCLDevice> collection = new Collection<OpenCLDevice>();
			if (devices == IntPtr.Zero)
			{
				return collection;
			}
			for (int i = 0; i < (int)(uint)length; i++)
			{
				OpenCLDevice openCLDevice = OpenCLDevice.CreateInstance(NativeOpenCL.GetDevice(devices, i));
				if (openCLDevice != null)
				{
					collection.Add(openCLDevice);
				}
			}
			return collection;
		}
	}

	public static void SetCacheDirectory(string path)
	{
		Environment.SetEnv("MAGICK_OPENCL_CACHE_DIR", FileHelper.GetFullPath(path));
	}
}
