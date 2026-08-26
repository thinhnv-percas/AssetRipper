using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace ImageMagick;

public class MagickSettings
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
			public static extern IntPtr MagickSettings_Create();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickSettings_BackgroundColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_BackgroundColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickSettings_ColorSpace_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_ColorSpace_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickSettings_ColorType_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_ColorType_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickSettings_CompressionMethod_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_CompressionMethod_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickSettings_Debug_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Debug_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickSettings_Density_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Density_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickSettings_Endian_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Endian_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickSettings_Extract_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Extract_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickSettings_Format_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Format_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickSettings_Font_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Font_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickSettings_FontPointsize_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_FontPointsize_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickSettings_Monochrome_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Monochrome_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickSettings_Interlace_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Interlace_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickSettings_Verbose_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Verbose_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetColorFuzz(IntPtr Instance, double value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetFileName(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetNumberScenes(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetOption(IntPtr Instance, IntPtr key, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetPage(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetPing(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetQuality(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetScenes(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetScene(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetSize(IntPtr Instance, IntPtr value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickSettings_Create();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickSettings_BackgroundColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_BackgroundColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickSettings_ColorSpace_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_ColorSpace_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickSettings_ColorType_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_ColorType_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickSettings_CompressionMethod_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_CompressionMethod_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickSettings_Debug_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Debug_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickSettings_Density_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Density_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickSettings_Endian_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Endian_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickSettings_Extract_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Extract_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickSettings_Format_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Format_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickSettings_Font_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Font_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickSettings_FontPointsize_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_FontPointsize_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickSettings_Monochrome_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Monochrome_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickSettings_Interlace_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Interlace_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickSettings_Verbose_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_Verbose_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetColorFuzz(IntPtr Instance, double value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetFileName(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetNumberScenes(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetOption(IntPtr Instance, IntPtr key, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetPage(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetPing(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetQuality(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetScenes(IntPtr Instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetScene(IntPtr Instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickSettings_SetSize(IntPtr Instance, IntPtr value);
		}
	}

	private sealed class NativeMagickSettings : NativeInstance
	{
		protected override string TypeName => "MagickSettings";

		public MagickColor BackgroundColor
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickSettings_BackgroundColor_Get(base.Instance) : NativeMethods.X64.MagickSettings_BackgroundColor_Get(base.Instance));
				return MagickColor.CreateInstance(instance);
			}
			set
			{
				using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickSettings_BackgroundColor_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickSettings_BackgroundColor_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public ColorSpace ColorSpace
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickSettings_ColorSpace_Get(base.Instance) : NativeMethods.X64.MagickSettings_ColorSpace_Get(base.Instance));
				return (ColorSpace)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickSettings_ColorSpace_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickSettings_ColorSpace_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public ColorType ColorType
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickSettings_ColorType_Get(base.Instance) : NativeMethods.X64.MagickSettings_ColorType_Get(base.Instance));
				return (ColorType)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickSettings_ColorType_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickSettings_ColorType_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public CompressionMethod CompressionMethod
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickSettings_CompressionMethod_Get(base.Instance) : NativeMethods.X64.MagickSettings_CompressionMethod_Get(base.Instance));
				return (CompressionMethod)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickSettings_CompressionMethod_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickSettings_CompressionMethod_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public bool Debug
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickSettings_Debug_Get(base.Instance);
				}
				return NativeMethods.X86.MagickSettings_Debug_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickSettings_Debug_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.MagickSettings_Debug_Set(base.Instance, value);
				}
			}
		}

		public string Density
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickSettings_Density_Get(base.Instance) : NativeMethods.X64.MagickSettings_Density_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
			set
			{
				using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickSettings_Density_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickSettings_Density_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public Endian Endian
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickSettings_Endian_Get(base.Instance) : NativeMethods.X64.MagickSettings_Endian_Get(base.Instance));
				return (Endian)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickSettings_Endian_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickSettings_Endian_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public string Extract
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickSettings_Extract_Get(base.Instance) : NativeMethods.X64.MagickSettings_Extract_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
			set
			{
				using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickSettings_Extract_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickSettings_Extract_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public string Format
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickSettings_Format_Get(base.Instance) : NativeMethods.X64.MagickSettings_Format_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
			set
			{
				using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickSettings_Format_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickSettings_Format_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public string Font
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickSettings_Font_Get(base.Instance) : NativeMethods.X64.MagickSettings_Font_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
			set
			{
				using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickSettings_Font_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickSettings_Font_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public double FontPointsize
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickSettings_FontPointsize_Get(base.Instance);
				}
				return NativeMethods.X86.MagickSettings_FontPointsize_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickSettings_FontPointsize_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.MagickSettings_FontPointsize_Set(base.Instance, value);
				}
			}
		}

		public bool Monochrome
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickSettings_Monochrome_Get(base.Instance);
				}
				return NativeMethods.X86.MagickSettings_Monochrome_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickSettings_Monochrome_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.MagickSettings_Monochrome_Set(base.Instance, value);
				}
			}
		}

		public Interlace Interlace
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickSettings_Interlace_Get(base.Instance) : NativeMethods.X64.MagickSettings_Interlace_Get(base.Instance));
				return (Interlace)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickSettings_Interlace_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickSettings_Interlace_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public bool Verbose
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickSettings_Verbose_Get(base.Instance);
				}
				return NativeMethods.X86.MagickSettings_Verbose_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickSettings_Verbose_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.MagickSettings_Verbose_Set(base.Instance, value);
				}
			}
		}

		static NativeMagickSettings()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickSettings_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.MagickSettings_Dispose(instance);
			}
		}

		public NativeMagickSettings()
		{
			if (NativeLibrary.Is64Bit)
			{
				base.Instance = NativeMethods.X64.MagickSettings_Create();
			}
			else
			{
				base.Instance = NativeMethods.X86.MagickSettings_Create();
			}
			if (base.Instance == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
		}

		public void SetColorFuzz(double value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickSettings_SetColorFuzz(base.Instance, value);
			}
			else
			{
				NativeMethods.X86.MagickSettings_SetColorFuzz(base.Instance, value);
			}
		}

		public void SetFileName(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickSettings_SetFileName(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MagickSettings_SetFileName(base.Instance, nativeInstance.Instance);
			}
		}

		public void SetNumberScenes(int value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickSettings_SetNumberScenes(base.Instance, (UIntPtr)(ulong)value);
			}
			else
			{
				NativeMethods.X86.MagickSettings_SetNumberScenes(base.Instance, (UIntPtr)(ulong)value);
			}
		}

		public void SetOption(string key, string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(key);
			using INativeInstance nativeInstance2 = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickSettings_SetOption(base.Instance, nativeInstance.Instance, nativeInstance2.Instance);
			}
			else
			{
				NativeMethods.X86.MagickSettings_SetOption(base.Instance, nativeInstance.Instance, nativeInstance2.Instance);
			}
		}

		public void SetPage(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickSettings_SetPage(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MagickSettings_SetPage(base.Instance, nativeInstance.Instance);
			}
		}

		public void SetPing(bool value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickSettings_SetPing(base.Instance, value);
			}
			else
			{
				NativeMethods.X86.MagickSettings_SetPing(base.Instance, value);
			}
		}

		public void SetQuality(int value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickSettings_SetQuality(base.Instance, (UIntPtr)(ulong)value);
			}
			else
			{
				NativeMethods.X86.MagickSettings_SetQuality(base.Instance, (UIntPtr)(ulong)value);
			}
		}

		public void SetScenes(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickSettings_SetScenes(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MagickSettings_SetScenes(base.Instance, nativeInstance.Instance);
			}
		}

		public void SetScene(int value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickSettings_SetScene(base.Instance, (UIntPtr)(ulong)value);
			}
			else
			{
				NativeMethods.X86.MagickSettings_SetScene(base.Instance, (UIntPtr)(ulong)value);
			}
		}

		public void SetSize(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickSettings_SetSize(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MagickSettings_SetSize(base.Instance, nativeInstance.Instance);
			}
		}
	}

	private readonly Dictionary<string, string> _options = new Dictionary<string, string>();

	private string _font;

	private double _fontPointsize;

	public DrawableAffine Affine
	{
		get
		{
			return Drawing.Affine;
		}
		set
		{
			Drawing.Affine = value;
		}
	}

	public MagickColor BackgroundColor { get; set; }

	public MagickColor BorderColor
	{
		get
		{
			return Drawing.BorderColor;
		}
		set
		{
			Drawing.BorderColor = value;
		}
	}

	public ColorSpace ColorSpace { get; set; }

	public ColorType ColorType { get; set; }

	public CompressionMethod CompressionMethod { get; set; }

	public bool Debug { get; set; }

	public Density Density { get; set; }

	public Endian Endian { get; set; }

	public MagickColor FillColor
	{
		get
		{
			return Drawing.FillColor;
		}
		set
		{
			SetOptionAndArtifact("fill", MagickColor.ToString(value));
			Drawing.FillColor = value;
		}
	}

	public IMagickImage FillPattern
	{
		get
		{
			return Drawing.FillPattern;
		}
		set
		{
			Drawing.FillPattern = value;
		}
	}

	public FillRule FillRule
	{
		get
		{
			return Drawing.FillRule;
		}
		set
		{
			Drawing.FillRule = value;
		}
	}

	public string Font
	{
		get
		{
			return _font;
		}
		set
		{
			_font = value;
			Drawing.Font = value;
		}
	}

	public string FontFamily
	{
		get
		{
			return GetOption("family");
		}
		set
		{
			SetOptionAndArtifact("family", value);
			Drawing.FontFamily = value;
		}
	}

	public double FontPointsize
	{
		get
		{
			return _fontPointsize;
		}
		set
		{
			_fontPointsize = value;
			Drawing.FontPointsize = value;
		}
	}

	public FontStyleType FontStyle
	{
		get
		{
			return EnumHelper.Parse(GetOption("style"), FontStyleType.Undefined);
		}
		set
		{
			SetOptionAndArtifact("style", EnumHelper.GetName(value));
			Drawing.FontStyle = value;
		}
	}

	public FontWeight FontWeight
	{
		get
		{
			string option = GetOption("weight");
			if (string.IsNullOrEmpty(option))
			{
				return FontWeight.Undefined;
			}
			if (!int.TryParse(option, NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
			{
				return FontWeight.Undefined;
			}
			return EnumHelper.Parse(result, FontWeight.Undefined);
		}
		set
		{
			int num = (int)value;
			SetOptionAndArtifact("weight", num.ToString(CultureInfo.InvariantCulture));
			Drawing.FontWeight = value;
		}
	}

	public MagickFormat Format { get; set; }

	public MagickGeometry Page { get; set; }

	public bool StrokeAntiAlias
	{
		get
		{
			return Drawing.StrokeAntiAlias;
		}
		set
		{
			Drawing.StrokeAntiAlias = value;
		}
	}

	public MagickColor StrokeColor
	{
		get
		{
			return Drawing.StrokeColor;
		}
		set
		{
			SetOptionAndArtifact("stroke", MagickColor.ToString(value));
			Drawing.StrokeColor = value;
		}
	}

	public IEnumerable<double> StrokeDashArray
	{
		get
		{
			return Drawing.StrokeDashArray;
		}
		set
		{
			Drawing.StrokeDashArray = value;
		}
	}

	public double StrokeDashOffset
	{
		get
		{
			return Drawing.StrokeDashOffset;
		}
		set
		{
			Drawing.StrokeDashOffset = value;
		}
	}

	public LineCap StrokeLineCap
	{
		get
		{
			return Drawing.StrokeLineCap;
		}
		set
		{
			Drawing.StrokeLineCap = value;
		}
	}

	public LineJoin StrokeLineJoin
	{
		get
		{
			return Drawing.StrokeLineJoin;
		}
		set
		{
			Drawing.StrokeLineJoin = value;
		}
	}

	public int StrokeMiterLimit
	{
		get
		{
			return Drawing.StrokeMiterLimit;
		}
		set
		{
			Drawing.StrokeMiterLimit = value;
		}
	}

	public IMagickImage StrokePattern
	{
		get
		{
			return Drawing.StrokePattern;
		}
		set
		{
			Drawing.StrokePattern = value;
		}
	}

	public double StrokeWidth
	{
		get
		{
			return Drawing.StrokeWidth;
		}
		set
		{
			SetOptionAndArtifact("strokewidth", value);
			Drawing.StrokeWidth = value;
		}
	}

	public bool TextAntiAlias
	{
		get
		{
			return Drawing.TextAntiAlias;
		}
		set
		{
			Drawing.TextAntiAlias = value;
		}
	}

	public TextDirection TextDirection
	{
		get
		{
			return Drawing.TextDirection;
		}
		set
		{
			Drawing.TextDirection = value;
		}
	}

	public Encoding TextEncoding
	{
		get
		{
			return Drawing.TextEncoding;
		}
		set
		{
			Drawing.TextEncoding = value;
		}
	}

	public Gravity TextGravity
	{
		get
		{
			return Drawing.TextGravity;
		}
		set
		{
			SetOptionAndArtifact("gravity", EnumHelper.GetName(value));
			Drawing.TextGravity = value;
		}
	}

	public double TextInterlineSpacing
	{
		get
		{
			return Drawing.TextInterlineSpacing;
		}
		set
		{
			SetOptionAndArtifact("interline-spacing", value);
			Drawing.TextInterlineSpacing = value;
		}
	}

	public double TextInterwordSpacing
	{
		get
		{
			return Drawing.TextInterwordSpacing;
		}
		set
		{
			SetOptionAndArtifact("interword-spacing", value);
			Drawing.TextInterwordSpacing = value;
		}
	}

	public double TextKerning
	{
		get
		{
			return Drawing.TextKerning;
		}
		set
		{
			SetOptionAndArtifact("kerning", value);
			Drawing.TextKerning = value;
		}
	}

	public MagickColor TextUnderColor
	{
		get
		{
			return Drawing.TextUnderColor;
		}
		set
		{
			SetOptionAndArtifact("undercolor", MagickColor.ToString(value));
			Drawing.TextUnderColor = value;
		}
	}

	public bool Verbose { get; set; }

	internal DrawingSettings Drawing { get; private set; }

	internal double ColorFuzz { get; set; }

	internal string FileName { get; set; }

	internal Interlace Interlace { get; set; }

	internal bool Ping { get; set; }

	internal int Quality { get; set; }

	protected MagickGeometry Extract { get; set; }

	protected int NumberScenes { get; set; }

	protected bool Monochrome { get; set; }

	protected string Size { get; set; }

	protected int Scene { get; set; }

	protected string Scenes { get; set; }

	internal event EventHandler<ArtifactEventArgs> Artifact;

	internal static INativeInstance CreateInstance(MagickSettings instance)
	{
		if (instance == null)
		{
			return NativeInstance.Zero;
		}
		return instance.CreateNativeInstance();
	}

	internal MagickSettings()
	{
		using (NativeMagickSettings nativeMagickSettings = new NativeMagickSettings())
		{
			BackgroundColor = nativeMagickSettings.BackgroundColor;
			ColorSpace = nativeMagickSettings.ColorSpace;
			ColorType = nativeMagickSettings.ColorType;
			CompressionMethod = nativeMagickSettings.CompressionMethod;
			Debug = nativeMagickSettings.Debug;
			Density = Density.Create(nativeMagickSettings.Density);
			Endian = nativeMagickSettings.Endian;
			Extract = MagickGeometry.FromString(nativeMagickSettings.Extract);
			_font = nativeMagickSettings.Font;
			_fontPointsize = nativeMagickSettings.FontPointsize;
			Format = EnumHelper.Parse(nativeMagickSettings.Format, MagickFormat.Unknown);
			Interlace = nativeMagickSettings.Interlace;
			Monochrome = nativeMagickSettings.Monochrome;
			Verbose = nativeMagickSettings.Verbose;
		}
		Drawing = new DrawingSettings();
	}

	public string GetDefine(MagickFormat format, string name)
	{
		Throw.IfNullOrEmpty("name", name);
		return GetOption(ParseDefine(format, name));
	}

	public string GetDefine(string name)
	{
		Throw.IfNullOrEmpty("name", name);
		return GetOption(name);
	}

	public void RemoveDefine(MagickFormat format, string name)
	{
		Throw.IfNullOrEmpty("name", name);
		string key = ParseDefine(format, name);
		if (_options.ContainsKey(key))
		{
			_options.Remove(key);
		}
	}

	public void RemoveDefine(string name)
	{
		Throw.IfNullOrEmpty("name", name);
		if (_options.ContainsKey(name))
		{
			_options.Remove(name);
		}
	}

	public void SetDefine(MagickFormat format, string name, bool flag)
	{
		SetDefine(format, name, flag ? "true" : "false");
	}

	public void SetDefine(MagickFormat format, string name, string value)
	{
		Throw.IfNullOrEmpty("name", name);
		Throw.IfNull("value", value);
		SetOption(ParseDefine(format, name), value);
	}

	public void SetDefine(string name, string value)
	{
		Throw.IfNullOrEmpty("name", name);
		Throw.IfNull("value", value);
		SetOption(name, value);
	}

	public void SetDefines([ValidatedNotNull] IDefines defines)
	{
		Throw.IfNull("defines", defines);
		foreach (IDefine define in defines.Defines)
		{
			if (define != null)
			{
				SetDefine(define.Format, define.Name, define.Value);
			}
		}
	}

	internal MagickSettings Clone()
	{
		MagickSettings magickSettings = new MagickSettings();
		magickSettings.Copy(this);
		return magickSettings;
	}

	internal string GetOption(string key)
	{
		Throw.IfNullOrEmpty("key", key);
		if (_options.TryGetValue(key, out var value))
		{
			return value;
		}
		return null;
	}

	internal void SetOption(string key, string value)
	{
		_options[key] = value;
	}

	protected static string ParseDefine(MagickFormat format, string name)
	{
		if (format == MagickFormat.Unknown)
		{
			return name;
		}
		return EnumHelper.GetName(GetModule(format)) + ":" + name;
	}

	protected void Copy(MagickSettings settings)
	{
		if (settings == null)
		{
			return;
		}
		BackgroundColor = MagickColor.Clone(settings.BackgroundColor);
		ColorSpace = settings.ColorSpace;
		ColorType = settings.ColorType;
		CompressionMethod = settings.CompressionMethod;
		Debug = settings.Debug;
		Density = Density.Clone(settings.Density);
		Endian = settings.Endian;
		Extract = MagickGeometry.Clone(settings.Extract);
		_font = settings._font;
		_fontPointsize = settings._fontPointsize;
		Format = settings.Format;
		Monochrome = settings.Monochrome;
		Page = MagickGeometry.Clone(settings.Page);
		Verbose = settings.Verbose;
		ColorFuzz = settings.ColorFuzz;
		Interlace = settings.Interlace;
		Ping = settings.Ping;
		Quality = settings.Quality;
		Size = settings.Size;
		foreach (string key in settings._options.Keys)
		{
			_options[key] = settings._options[key];
		}
		Drawing = settings.Drawing.Clone();
	}

	private static MagickFormat GetModule(MagickFormat format)
	{
		MagickFormatInfo formatInformation = MagickNET.GetFormatInformation(format);
		if (formatInformation == null)
		{
			return format;
		}
		return formatInformation.Module;
	}

	private INativeInstance CreateNativeInstance()
	{
		string format = GetFormat();
		string text = FileName;
		if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(format))
		{
			text = format + ":" + text;
		}
		NativeMagickSettings nativeMagickSettings = new NativeMagickSettings();
		nativeMagickSettings.BackgroundColor = BackgroundColor;
		nativeMagickSettings.ColorSpace = ColorSpace;
		nativeMagickSettings.ColorType = ColorType;
		nativeMagickSettings.CompressionMethod = CompressionMethod;
		nativeMagickSettings.Debug = Debug;
		nativeMagickSettings.Density = Density?.ToString(DensityUnit.Undefined);
		nativeMagickSettings.Endian = Endian;
		nativeMagickSettings.Extract = MagickGeometry.ToString(Extract);
		nativeMagickSettings.Font = _font;
		nativeMagickSettings.FontPointsize = _fontPointsize;
		nativeMagickSettings.Format = format;
		nativeMagickSettings.Interlace = Interlace;
		nativeMagickSettings.Monochrome = Monochrome;
		nativeMagickSettings.Verbose = Verbose;
		nativeMagickSettings.SetColorFuzz(ColorFuzz);
		nativeMagickSettings.SetFileName(text);
		nativeMagickSettings.SetNumberScenes(NumberScenes);
		nativeMagickSettings.SetPage(MagickGeometry.ToString(Page));
		nativeMagickSettings.SetPing(Ping);
		nativeMagickSettings.SetQuality(Quality);
		nativeMagickSettings.SetScene(Scene);
		nativeMagickSettings.SetScenes(Scenes);
		nativeMagickSettings.SetSize(Size);
		foreach (string key in _options.Keys)
		{
			nativeMagickSettings.SetOption(key, _options[key]);
		}
		return nativeMagickSettings;
	}

	private string GetFormat()
	{
		return Format switch
		{
			MagickFormat.Unknown => null, 
			MagickFormat.ThreeFr => "3FR", 
			MagickFormat.ThreeG2 => "3G2", 
			MagickFormat.ThreeGp => "3GP", 
			_ => EnumHelper.GetName(Format).ToUpperInvariant(), 
		};
	}

	private void SetOptionAndArtifact(string key, double value)
	{
		SetOptionAndArtifact(key, value.ToString(CultureInfo.InvariantCulture));
	}

	private void SetOptionAndArtifact(string key, string value)
	{
		SetOption(key, value);
		Artifact?.Invoke(this, new ArtifactEventArgs(key, value));
	}
}
