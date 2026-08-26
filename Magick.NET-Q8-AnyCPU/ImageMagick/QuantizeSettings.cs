using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class QuantizeSettings
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
			public static extern IntPtr QuantizeSettings_Create();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void QuantizeSettings_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void QuantizeSettings_SetColors(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void QuantizeSettings_SetColorSpace(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void QuantizeSettings_SetDitherMethod(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void QuantizeSettings_SetMeasureErrors(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void QuantizeSettings_SetTreeDepth(IntPtr Instance, UIntPtr value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr QuantizeSettings_Create();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void QuantizeSettings_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void QuantizeSettings_SetColors(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void QuantizeSettings_SetColorSpace(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void QuantizeSettings_SetDitherMethod(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void QuantizeSettings_SetMeasureErrors(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void QuantizeSettings_SetTreeDepth(IntPtr Instance, UIntPtr value);
		}
	}

	private sealed class NativeQuantizeSettings : NativeInstance
	{
		protected override string TypeName => "QuantizeSettings";

		static NativeQuantizeSettings()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.QuantizeSettings_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.QuantizeSettings_Dispose(instance);
			}
		}

		public NativeQuantizeSettings()
		{
			if (NativeLibrary.Is64Bit)
			{
				base.Instance = NativeMethods.X64.QuantizeSettings_Create();
			}
			else
			{
				base.Instance = NativeMethods.X86.QuantizeSettings_Create();
			}
			if (base.Instance == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
		}

		public void SetColors(int value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.QuantizeSettings_SetColors(base.Instance, (UIntPtr)(ulong)value);
			}
			else
			{
				NativeMethods.X86.QuantizeSettings_SetColors(base.Instance, (UIntPtr)(ulong)value);
			}
		}

		public void SetColorSpace(ColorSpace value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.QuantizeSettings_SetColorSpace(base.Instance, (UIntPtr)(ulong)value);
			}
			else
			{
				NativeMethods.X86.QuantizeSettings_SetColorSpace(base.Instance, (UIntPtr)(ulong)value);
			}
		}

		public void SetDitherMethod(DitherMethod value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.QuantizeSettings_SetDitherMethod(base.Instance, (UIntPtr)(ulong)value);
			}
			else
			{
				NativeMethods.X86.QuantizeSettings_SetDitherMethod(base.Instance, (UIntPtr)(ulong)value);
			}
		}

		public void SetMeasureErrors(bool value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.QuantizeSettings_SetMeasureErrors(base.Instance, value);
			}
			else
			{
				NativeMethods.X86.QuantizeSettings_SetMeasureErrors(base.Instance, value);
			}
		}

		public void SetTreeDepth(int value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.QuantizeSettings_SetTreeDepth(base.Instance, (UIntPtr)(ulong)value);
			}
			else
			{
				NativeMethods.X86.QuantizeSettings_SetTreeDepth(base.Instance, (UIntPtr)(ulong)value);
			}
		}
	}

	public int Colors { get; set; }

	public ColorSpace ColorSpace { get; set; }

	public DitherMethod? DitherMethod { get; set; }

	public bool MeasureErrors { get; set; }

	public int TreeDepth { get; set; }

	internal static INativeInstance CreateInstance(QuantizeSettings instance)
	{
		if (instance == null)
		{
			return NativeInstance.Zero;
		}
		return instance.CreateNativeInstance();
	}

	public QuantizeSettings()
	{
		Colors = 1;
		DitherMethod = ImageMagick.DitherMethod.Riemersma;
	}

	private INativeInstance CreateNativeInstance()
	{
		NativeQuantizeSettings nativeQuantizeSettings = new NativeQuantizeSettings();
		nativeQuantizeSettings.SetColors(Colors);
		nativeQuantizeSettings.SetColorSpace(ColorSpace);
		nativeQuantizeSettings.SetDitherMethod((!DitherMethod.HasValue) ? ImageMagick.DitherMethod.No : DitherMethod.Value);
		nativeQuantizeSettings.SetMeasureErrors(MeasureErrors);
		nativeQuantizeSettings.SetTreeDepth(TreeDepth);
		return nativeQuantizeSettings;
	}
}
