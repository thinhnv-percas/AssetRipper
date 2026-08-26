using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

internal class PointInfo
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
			public static extern double PointInfo_X_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double PointInfo_Y_Get(IntPtr instance);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double PointInfo_X_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double PointInfo_Y_Get(IntPtr instance);
		}
	}

	private sealed class NativePointInfo : ConstNativeInstance
	{
		protected override string TypeName => "PointInfo";

		public double X
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.PointInfo_X_Get(base.Instance);
				}
				return NativeMethods.X86.PointInfo_X_Get(base.Instance);
			}
		}

		public double Y
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.PointInfo_Y_Get(base.Instance);
				}
				return NativeMethods.X86.PointInfo_Y_Get(base.Instance);
			}
		}

		static NativePointInfo()
		{
			Environment.Initialize();
		}

		public NativePointInfo(IntPtr instance)
		{
			base.Instance = instance;
		}
	}

	public double X { get; private set; }

	public double Y { get; private set; }

	private PointInfo(IntPtr instance)
	{
		NativePointInfo nativePointInfo = new NativePointInfo(instance);
		X = nativePointInfo.X;
		Y = nativePointInfo.Y;
	}

	public static PointInfo CreateInstance(IntPtr instance)
	{
		return new PointInfo(instance);
	}
}
