using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

internal class StringInfo
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
			public static extern IntPtr StringInfo_Datum_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr StringInfo_Length_Get(IntPtr instance);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr StringInfo_Datum_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr StringInfo_Length_Get(IntPtr instance);
		}
	}

	private sealed class NativeStringInfo : ConstNativeInstance
	{
		protected override string TypeName => "StringInfo";

		public IntPtr Datum
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.StringInfo_Datum_Get(base.Instance);
				}
				return NativeMethods.X86.StringInfo_Datum_Get(base.Instance);
			}
		}

		public int Length
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.StringInfo_Length_Get(base.Instance) : NativeMethods.X64.StringInfo_Length_Get(base.Instance));
				return (int)(uint)uIntPtr;
			}
		}

		static NativeStringInfo()
		{
			Environment.Initialize();
		}

		public NativeStringInfo(IntPtr instance)
		{
			base.Instance = instance;
		}
	}

	public byte[] Datum { get; private set; }

	public static StringInfo CreateInstance(IntPtr instance)
	{
		if (instance == IntPtr.Zero)
		{
			return null;
		}
		NativeStringInfo nativeStringInfo = new NativeStringInfo(instance);
		return new StringInfo
		{
			Datum = ByteConverter.ToArray(nativeStringInfo.Datum, nativeStringInfo.Length)
		};
	}
}
