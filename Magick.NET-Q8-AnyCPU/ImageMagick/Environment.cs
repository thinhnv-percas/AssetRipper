using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

internal static class Environment
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
			public static extern void Environment_Initialize();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void Environment_SetEnv(IntPtr name, IntPtr value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void Environment_Initialize();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void Environment_SetEnv(IntPtr name, IntPtr value);
		}
	}

	private static class NativeEnvironment
	{
		public static void Initialize()
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.Environment_Initialize();
			}
			else
			{
				NativeMethods.X86.Environment_Initialize();
			}
		}

		public static void SetEnv(string name, string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(name);
			using INativeInstance nativeInstance2 = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.Environment_SetEnv(nativeInstance.Instance, nativeInstance2.Instance);
			}
			else
			{
				NativeMethods.X86.Environment_SetEnv(nativeInstance.Instance, nativeInstance2.Instance);
			}
		}
	}

	private static readonly object _lock = new object();

	private static bool _initialized;

	public static void Initialize()
	{
		lock (_lock)
		{
			if (!_initialized)
			{
				NativeEnvironment.Initialize();
				_initialized = true;
			}
		}
	}

	public static void SetEnv(string name, string value)
	{
		NativeEnvironment.SetEnv(name, value);
	}
}
