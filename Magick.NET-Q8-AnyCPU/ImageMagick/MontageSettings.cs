using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class MontageSettings
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
			public static extern IntPtr MontageSettings_Create();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetBackgroundColor(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetBorderColor(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetBorderWidth(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetFillColor(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetFont(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetFontPointsize(IntPtr Instance, double value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetFrameGeometry(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetGeometry(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetGravity(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetShadow(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetStrokeColor(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetTextureFileName(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetTileGeometry(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetTitle(IntPtr Instance, IntPtr value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MontageSettings_Create();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetBackgroundColor(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetBorderColor(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetBorderWidth(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetFillColor(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetFont(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetFontPointsize(IntPtr Instance, double value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetFrameGeometry(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetGeometry(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetGravity(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetShadow(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetStrokeColor(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetTextureFileName(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetTileGeometry(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MontageSettings_SetTitle(IntPtr Instance, IntPtr value);
		}
	}

	private sealed class NativeMontageSettings : NativeInstance
	{
		protected override string TypeName => "MontageSettings";

		static NativeMontageSettings()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.MontageSettings_Dispose(instance);
			}
		}

		public NativeMontageSettings()
		{
			if (NativeLibrary.Is64Bit)
			{
				base.Instance = NativeMethods.X64.MontageSettings_Create();
			}
			else
			{
				base.Instance = NativeMethods.X86.MontageSettings_Create();
			}
			if (base.Instance == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
		}

		public void SetBackgroundColor(MagickColor value)
		{
			using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_SetBackgroundColor(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MontageSettings_SetBackgroundColor(base.Instance, nativeInstance.Instance);
			}
		}

		public void SetBorderColor(MagickColor value)
		{
			using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_SetBorderColor(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MontageSettings_SetBorderColor(base.Instance, nativeInstance.Instance);
			}
		}

		public void SetBorderWidth(int value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_SetBorderWidth(base.Instance, (UIntPtr)(ulong)value);
			}
			else
			{
				NativeMethods.X86.MontageSettings_SetBorderWidth(base.Instance, (UIntPtr)(ulong)value);
			}
		}

		public void SetFillColor(MagickColor value)
		{
			using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_SetFillColor(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MontageSettings_SetFillColor(base.Instance, nativeInstance.Instance);
			}
		}

		public void SetFont(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_SetFont(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MontageSettings_SetFont(base.Instance, nativeInstance.Instance);
			}
		}

		public void SetFontPointsize(double value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_SetFontPointsize(base.Instance, value);
			}
			else
			{
				NativeMethods.X86.MontageSettings_SetFontPointsize(base.Instance, value);
			}
		}

		public void SetFrameGeometry(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_SetFrameGeometry(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MontageSettings_SetFrameGeometry(base.Instance, nativeInstance.Instance);
			}
		}

		public void SetGeometry(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_SetGeometry(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MontageSettings_SetGeometry(base.Instance, nativeInstance.Instance);
			}
		}

		public void SetGravity(Gravity value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_SetGravity(base.Instance, (UIntPtr)(ulong)value);
			}
			else
			{
				NativeMethods.X86.MontageSettings_SetGravity(base.Instance, (UIntPtr)(ulong)value);
			}
		}

		public void SetShadow(bool value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_SetShadow(base.Instance, value);
			}
			else
			{
				NativeMethods.X86.MontageSettings_SetShadow(base.Instance, value);
			}
		}

		public void SetStrokeColor(MagickColor value)
		{
			using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_SetStrokeColor(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MontageSettings_SetStrokeColor(base.Instance, nativeInstance.Instance);
			}
		}

		public void SetTextureFileName(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_SetTextureFileName(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MontageSettings_SetTextureFileName(base.Instance, nativeInstance.Instance);
			}
		}

		public void SetTileGeometry(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_SetTileGeometry(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MontageSettings_SetTileGeometry(base.Instance, nativeInstance.Instance);
			}
		}

		public void SetTitle(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MontageSettings_SetTitle(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MontageSettings_SetTitle(base.Instance, nativeInstance.Instance);
			}
		}
	}

	public MagickColor BackgroundColor { get; set; }

	public MagickColor BorderColor { get; set; }

	public int BorderWidth { get; set; }

	public MagickColor FillColor { get; set; }

	public string Font { get; set; }

	public int FontPointsize { get; set; }

	public MagickGeometry FrameGeometry { get; set; }

	public MagickGeometry Geometry { get; set; }

	public Gravity Gravity { get; set; }

	public string Label { get; set; }

	public bool Shadow { get; set; }

	public MagickColor StrokeColor { get; set; }

	public string TextureFileName { get; set; }

	public MagickGeometry TileGeometry { get; set; }

	public string Title { get; set; }

	public MagickColor TransparentColor { get; set; }

	internal static INativeInstance CreateInstance(MontageSettings instance)
	{
		if (instance == null)
		{
			return NativeInstance.Zero;
		}
		return instance.CreateNativeInstance();
	}

	private static string Convert(MagickGeometry geometry)
	{
		if (geometry == null)
		{
			return null;
		}
		return geometry.ToString();
	}

	private INativeInstance CreateNativeInstance()
	{
		NativeMontageSettings nativeMontageSettings = new NativeMontageSettings();
		nativeMontageSettings.SetBackgroundColor(BackgroundColor);
		nativeMontageSettings.SetBorderColor(BorderColor);
		nativeMontageSettings.SetBorderWidth(BorderWidth);
		nativeMontageSettings.SetFillColor(FillColor);
		nativeMontageSettings.SetFont(Font);
		nativeMontageSettings.SetFontPointsize(FontPointsize);
		nativeMontageSettings.SetFrameGeometry(Convert(FrameGeometry));
		nativeMontageSettings.SetGeometry(Convert(Geometry));
		nativeMontageSettings.SetGravity(Gravity);
		nativeMontageSettings.SetShadow(Shadow);
		nativeMontageSettings.SetStrokeColor(StrokeColor);
		nativeMontageSettings.SetTextureFileName(TextureFileName);
		nativeMontageSettings.SetTileGeometry(Convert(TileGeometry));
		nativeMontageSettings.SetTitle(Title);
		return nativeMontageSettings;
	}
}
