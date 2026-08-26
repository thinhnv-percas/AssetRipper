using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

internal class OffsetInfo
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
			public static extern IntPtr OffsetInfo_Create();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void OffsetInfo_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void OffsetInfo_SetX(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void OffsetInfo_SetY(IntPtr Instance, UIntPtr value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr OffsetInfo_Create();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void OffsetInfo_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void OffsetInfo_SetX(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void OffsetInfo_SetY(IntPtr Instance, UIntPtr value);
		}
	}

	private sealed class NativeOffsetInfo : NativeInstance
	{
		protected override string TypeName => "OffsetInfo";

		static NativeOffsetInfo()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.OffsetInfo_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.OffsetInfo_Dispose(instance);
			}
		}

		public NativeOffsetInfo()
		{
			if (NativeLibrary.Is64Bit)
			{
				base.Instance = NativeMethods.X64.OffsetInfo_Create();
			}
			else
			{
				base.Instance = NativeMethods.X86.OffsetInfo_Create();
			}
			if (base.Instance == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
		}

		public void SetX(int value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.OffsetInfo_SetX(base.Instance, (UIntPtr)(ulong)value);
			}
			else
			{
				NativeMethods.X86.OffsetInfo_SetX(base.Instance, (UIntPtr)(ulong)value);
			}
		}

		public void SetY(int value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.OffsetInfo_SetY(base.Instance, (UIntPtr)(ulong)value);
			}
			else
			{
				NativeMethods.X86.OffsetInfo_SetY(base.Instance, (UIntPtr)(ulong)value);
			}
		}
	}

	public int X { get; private set; }

	public int Y { get; private set; }

	internal static INativeInstance CreateInstance(OffsetInfo instance)
	{
		if (instance == null)
		{
			return NativeInstance.Zero;
		}
		return instance.CreateNativeInstance();
	}

	public OffsetInfo(int x, int y)
	{
		X = x;
		Y = y;
	}

	public INativeInstance CreateNativeInstance()
	{
		NativeOffsetInfo nativeOffsetInfo = new NativeOffsetInfo();
		nativeOffsetInfo.SetX(X);
		nativeOffsetInfo.SetY(Y);
		return nativeOffsetInfo;
	}
}
