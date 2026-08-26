using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ImageMagick;

internal sealed class DrawingSettings
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
			public static extern IntPtr DrawingSettings_Create();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_BorderColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_BorderColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_FillColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_FillColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_FillRule_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_FillRule_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_Font_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_Font_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_FontFamily_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_FontFamily_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double DrawingSettings_FontPointsize_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_FontPointsize_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_FontStyle_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_FontStyle_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_FontWeight_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_FontWeight_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool DrawingSettings_StrokeAntiAlias_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_StrokeAntiAlias_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_StrokeColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_StrokeColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double DrawingSettings_StrokeDashOffset_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_StrokeDashOffset_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_StrokeLineCap_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_StrokeLineCap_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_StrokeLineJoin_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_StrokeLineJoin_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_StrokeMiterLimit_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_StrokeMiterLimit_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double DrawingSettings_StrokeWidth_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_StrokeWidth_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool DrawingSettings_TextAntiAlias_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextAntiAlias_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_TextDirection_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextDirection_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_TextEncoding_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextEncoding_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_TextGravity_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextGravity_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double DrawingSettings_TextInterlineSpacing_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextInterlineSpacing_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double DrawingSettings_TextInterwordSpacing_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextInterwordSpacing_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double DrawingSettings_TextKerning_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextKerning_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_TextUnderColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextUnderColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_SetFillPattern(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_SetAffine(IntPtr Instance, double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_SetStrokeDashArray(IntPtr Instance, double[] dash, UIntPtr length);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_SetStrokePattern(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_SetText(IntPtr Instance, IntPtr value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_Create();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_BorderColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_BorderColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_FillColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_FillColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_FillRule_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_FillRule_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_Font_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_Font_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_FontFamily_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_FontFamily_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double DrawingSettings_FontPointsize_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_FontPointsize_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_FontStyle_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_FontStyle_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_FontWeight_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_FontWeight_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool DrawingSettings_StrokeAntiAlias_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_StrokeAntiAlias_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_StrokeColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_StrokeColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double DrawingSettings_StrokeDashOffset_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_StrokeDashOffset_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_StrokeLineCap_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_StrokeLineCap_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_StrokeLineJoin_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_StrokeLineJoin_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_StrokeMiterLimit_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_StrokeMiterLimit_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double DrawingSettings_StrokeWidth_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_StrokeWidth_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool DrawingSettings_TextAntiAlias_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextAntiAlias_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_TextDirection_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextDirection_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_TextEncoding_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextEncoding_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr DrawingSettings_TextGravity_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextGravity_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double DrawingSettings_TextInterlineSpacing_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextInterlineSpacing_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double DrawingSettings_TextInterwordSpacing_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextInterwordSpacing_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double DrawingSettings_TextKerning_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextKerning_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingSettings_TextUnderColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_TextUnderColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_SetFillPattern(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_SetAffine(IntPtr Instance, double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_SetStrokeDashArray(IntPtr Instance, double[] dash, UIntPtr length);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_SetStrokePattern(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingSettings_SetText(IntPtr Instance, IntPtr value);
		}
	}

	private sealed class NativeDrawingSettings : NativeInstance
	{
		protected override string TypeName => "DrawingSettings";

		public MagickColor BorderColor
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_BorderColor_Get(base.Instance) : NativeMethods.X64.DrawingSettings_BorderColor_Get(base.Instance));
				return MagickColor.CreateInstance(instance);
			}
			set
			{
				using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_BorderColor_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_BorderColor_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public MagickColor FillColor
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_FillColor_Get(base.Instance) : NativeMethods.X64.DrawingSettings_FillColor_Get(base.Instance));
				return MagickColor.CreateInstance(instance);
			}
			set
			{
				using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_FillColor_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_FillColor_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public FillRule FillRule
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_FillRule_Get(base.Instance) : NativeMethods.X64.DrawingSettings_FillRule_Get(base.Instance));
				return (FillRule)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_FillRule_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_FillRule_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public string Font
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_Font_Get(base.Instance) : NativeMethods.X64.DrawingSettings_Font_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
			set
			{
				using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_Font_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_Font_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public string FontFamily
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_FontFamily_Get(base.Instance) : NativeMethods.X64.DrawingSettings_FontFamily_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
			set
			{
				using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_FontFamily_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_FontFamily_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public double FontPointsize
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.DrawingSettings_FontPointsize_Get(base.Instance);
				}
				return NativeMethods.X86.DrawingSettings_FontPointsize_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_FontPointsize_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_FontPointsize_Set(base.Instance, value);
				}
			}
		}

		public FontStyleType FontStyle
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_FontStyle_Get(base.Instance) : NativeMethods.X64.DrawingSettings_FontStyle_Get(base.Instance));
				return (FontStyleType)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_FontStyle_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_FontStyle_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public FontWeight FontWeight
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_FontWeight_Get(base.Instance) : NativeMethods.X64.DrawingSettings_FontWeight_Get(base.Instance));
				return (FontWeight)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_FontWeight_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_FontWeight_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public bool StrokeAntiAlias
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.DrawingSettings_StrokeAntiAlias_Get(base.Instance);
				}
				return NativeMethods.X86.DrawingSettings_StrokeAntiAlias_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_StrokeAntiAlias_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_StrokeAntiAlias_Set(base.Instance, value);
				}
			}
		}

		public MagickColor StrokeColor
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_StrokeColor_Get(base.Instance) : NativeMethods.X64.DrawingSettings_StrokeColor_Get(base.Instance));
				return MagickColor.CreateInstance(instance);
			}
			set
			{
				using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_StrokeColor_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_StrokeColor_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public double StrokeDashOffset
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.DrawingSettings_StrokeDashOffset_Get(base.Instance);
				}
				return NativeMethods.X86.DrawingSettings_StrokeDashOffset_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_StrokeDashOffset_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_StrokeDashOffset_Set(base.Instance, value);
				}
			}
		}

		public LineCap StrokeLineCap
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_StrokeLineCap_Get(base.Instance) : NativeMethods.X64.DrawingSettings_StrokeLineCap_Get(base.Instance));
				return (LineCap)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_StrokeLineCap_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_StrokeLineCap_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public LineJoin StrokeLineJoin
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_StrokeLineJoin_Get(base.Instance) : NativeMethods.X64.DrawingSettings_StrokeLineJoin_Get(base.Instance));
				return (LineJoin)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_StrokeLineJoin_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_StrokeLineJoin_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public int StrokeMiterLimit
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_StrokeMiterLimit_Get(base.Instance) : NativeMethods.X64.DrawingSettings_StrokeMiterLimit_Get(base.Instance));
				return (int)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_StrokeMiterLimit_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_StrokeMiterLimit_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public double StrokeWidth
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.DrawingSettings_StrokeWidth_Get(base.Instance);
				}
				return NativeMethods.X86.DrawingSettings_StrokeWidth_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_StrokeWidth_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_StrokeWidth_Set(base.Instance, value);
				}
			}
		}

		public bool TextAntiAlias
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.DrawingSettings_TextAntiAlias_Get(base.Instance);
				}
				return NativeMethods.X86.DrawingSettings_TextAntiAlias_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_TextAntiAlias_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_TextAntiAlias_Set(base.Instance, value);
				}
			}
		}

		public TextDirection TextDirection
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_TextDirection_Get(base.Instance) : NativeMethods.X64.DrawingSettings_TextDirection_Get(base.Instance));
				return (TextDirection)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_TextDirection_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_TextDirection_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public string TextEncoding
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_TextEncoding_Get(base.Instance) : NativeMethods.X64.DrawingSettings_TextEncoding_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
			set
			{
				using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_TextEncoding_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_TextEncoding_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public Gravity TextGravity
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_TextGravity_Get(base.Instance) : NativeMethods.X64.DrawingSettings_TextGravity_Get(base.Instance));
				return (Gravity)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_TextGravity_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_TextGravity_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public double TextInterlineSpacing
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.DrawingSettings_TextInterlineSpacing_Get(base.Instance);
				}
				return NativeMethods.X86.DrawingSettings_TextInterlineSpacing_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_TextInterlineSpacing_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_TextInterlineSpacing_Set(base.Instance, value);
				}
			}
		}

		public double TextInterwordSpacing
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.DrawingSettings_TextInterwordSpacing_Get(base.Instance);
				}
				return NativeMethods.X86.DrawingSettings_TextInterwordSpacing_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_TextInterwordSpacing_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_TextInterwordSpacing_Set(base.Instance, value);
				}
			}
		}

		public double TextKerning
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.DrawingSettings_TextKerning_Get(base.Instance);
				}
				return NativeMethods.X86.DrawingSettings_TextKerning_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_TextKerning_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_TextKerning_Set(base.Instance, value);
				}
			}
		}

		public MagickColor TextUnderColor
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.DrawingSettings_TextUnderColor_Get(base.Instance) : NativeMethods.X64.DrawingSettings_TextUnderColor_Get(base.Instance));
				return MagickColor.CreateInstance(instance);
			}
			set
			{
				using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.DrawingSettings_TextUnderColor_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.DrawingSettings_TextUnderColor_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		static NativeDrawingSettings()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingSettings_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.DrawingSettings_Dispose(instance);
			}
		}

		public NativeDrawingSettings()
		{
			if (NativeLibrary.Is64Bit)
			{
				base.Instance = NativeMethods.X64.DrawingSettings_Create();
			}
			else
			{
				base.Instance = NativeMethods.X86.DrawingSettings_Create();
			}
			if (base.Instance == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
		}

		public void SetFillPattern(IMagickImage value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingSettings_SetFillPattern(base.Instance, value.GetInstance(), out exception);
			}
			else
			{
				NativeMethods.X86.DrawingSettings_SetFillPattern(base.Instance, value.GetInstance(), out exception);
			}
			CheckException(exception);
		}

		public void SetAffine(double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingSettings_SetAffine(base.Instance, scaleX, scaleY, shearX, shearY, translateX, translateY, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingSettings_SetAffine(base.Instance, scaleX, scaleY, shearX, shearY, translateX, translateY, out exception);
			}
			CheckException(exception);
		}

		public void SetStrokeDashArray(double[] dash, int length)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingSettings_SetStrokeDashArray(base.Instance, dash, (UIntPtr)(ulong)length);
			}
			else
			{
				NativeMethods.X86.DrawingSettings_SetStrokeDashArray(base.Instance, dash, (UIntPtr)(ulong)length);
			}
		}

		public void SetStrokePattern(IMagickImage value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingSettings_SetStrokePattern(base.Instance, value.GetInstance(), out exception);
			}
			else
			{
				NativeMethods.X86.DrawingSettings_SetStrokePattern(base.Instance, value.GetInstance(), out exception);
			}
			CheckException(exception);
		}

		public void SetText(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingSettings_SetText(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.DrawingSettings_SetText(base.Instance, nativeInstance.Instance);
			}
		}
	}

	private double[] _strokeDashArray;

	public DrawableAffine Affine { get; set; }

	public MagickColor BorderColor { get; set; }

	public MagickColor FillColor { get; set; }

	public IMagickImage FillPattern { get; set; }

	public FillRule FillRule { get; set; }

	public string Font { get; set; }

	public string FontFamily { get; set; }

	public double FontPointsize { get; set; }

	public FontStyleType FontStyle { get; set; }

	public FontWeight FontWeight { get; set; }

	public bool StrokeAntiAlias { get; set; }

	public MagickColor StrokeColor { get; set; }

	public IEnumerable<double> StrokeDashArray
	{
		get
		{
			return _strokeDashArray;
		}
		set
		{
			if (value != null)
			{
				_strokeDashArray = new List<double>(value).ToArray();
			}
		}
	}

	public double StrokeDashOffset { get; set; }

	public LineCap StrokeLineCap { get; set; }

	public LineJoin StrokeLineJoin { get; set; }

	public int StrokeMiterLimit { get; set; }

	public IMagickImage StrokePattern { get; set; }

	public double StrokeWidth { get; set; }

	public string Text { get; set; }

	public bool TextAntiAlias { get; set; }

	public TextDirection TextDirection { get; set; }

	public Encoding TextEncoding { get; set; }

	public Gravity TextGravity { get; set; }

	public double TextInterlineSpacing { get; set; }

	public double TextInterwordSpacing { get; set; }

	public double TextKerning { get; set; }

	public MagickColor TextUnderColor { get; set; }

	internal static INativeInstance CreateInstance(DrawingSettings instance)
	{
		if (instance == null)
		{
			return NativeInstance.Zero;
		}
		return instance.CreateNativeInstance();
	}

	internal DrawingSettings()
	{
		using NativeDrawingSettings nativeDrawingSettings = new NativeDrawingSettings();
		BorderColor = nativeDrawingSettings.BorderColor;
		FillColor = nativeDrawingSettings.FillColor;
		FillRule = nativeDrawingSettings.FillRule;
		Font = nativeDrawingSettings.Font;
		FontFamily = nativeDrawingSettings.FontFamily;
		FontPointsize = nativeDrawingSettings.FontPointsize;
		FontStyle = nativeDrawingSettings.FontStyle;
		FontWeight = nativeDrawingSettings.FontWeight;
		StrokeAntiAlias = nativeDrawingSettings.StrokeAntiAlias;
		StrokeColor = nativeDrawingSettings.StrokeColor;
		StrokeDashOffset = nativeDrawingSettings.StrokeDashOffset;
		StrokeLineCap = nativeDrawingSettings.StrokeLineCap;
		StrokeLineJoin = nativeDrawingSettings.StrokeLineJoin;
		StrokeMiterLimit = nativeDrawingSettings.StrokeMiterLimit;
		StrokeWidth = nativeDrawingSettings.StrokeWidth;
		TextAntiAlias = nativeDrawingSettings.TextAntiAlias;
		TextDirection = nativeDrawingSettings.TextDirection;
		TextEncoding = GetTextEncoding(nativeDrawingSettings);
		TextGravity = nativeDrawingSettings.TextGravity;
		TextInterlineSpacing = nativeDrawingSettings.TextInterlineSpacing;
		TextInterwordSpacing = nativeDrawingSettings.TextInterwordSpacing;
		TextKerning = nativeDrawingSettings.TextKerning;
		TextUnderColor = nativeDrawingSettings.TextUnderColor;
	}

	internal DrawingSettings Clone()
	{
		return new DrawingSettings
		{
			BorderColor = MagickColor.Clone(BorderColor),
			FillColor = MagickColor.Clone(FillColor),
			FillRule = FillRule,
			Font = Font,
			FontFamily = FontFamily,
			FontPointsize = FontPointsize,
			FontStyle = FontStyle,
			FontWeight = FontWeight,
			StrokeAntiAlias = StrokeAntiAlias,
			StrokeColor = MagickColor.Clone(StrokeColor),
			StrokeDashOffset = StrokeDashOffset,
			StrokeLineCap = StrokeLineCap,
			StrokeLineJoin = StrokeLineJoin,
			StrokeMiterLimit = StrokeMiterLimit,
			StrokeWidth = StrokeWidth,
			TextAntiAlias = TextAntiAlias,
			TextDirection = TextDirection,
			TextEncoding = TextEncoding,
			TextGravity = TextGravity,
			TextInterlineSpacing = TextInterlineSpacing,
			TextInterwordSpacing = TextInterwordSpacing,
			TextKerning = TextKerning,
			TextUnderColor = MagickColor.Clone(TextUnderColor),
			Affine = Affine,
			FillPattern = MagickImage.Clone(FillPattern),
			_strokeDashArray = ((_strokeDashArray != null) ? ((double[])_strokeDashArray.Clone()) : null),
			StrokePattern = MagickImage.Clone(StrokePattern),
			Text = Text
		};
	}

	private static Encoding GetTextEncoding(NativeDrawingSettings instance)
	{
		string textEncoding = instance.TextEncoding;
		if (string.IsNullOrEmpty(textEncoding))
		{
			return null;
		}
		try
		{
			return Encoding.GetEncoding(textEncoding);
		}
		catch (ArgumentException)
		{
			return null;
		}
	}

	private INativeInstance CreateNativeInstance()
	{
		NativeDrawingSettings nativeDrawingSettings = new NativeDrawingSettings();
		nativeDrawingSettings.BorderColor = BorderColor;
		nativeDrawingSettings.FillColor = FillColor;
		nativeDrawingSettings.FillRule = FillRule;
		nativeDrawingSettings.Font = Font;
		nativeDrawingSettings.FontFamily = FontFamily;
		nativeDrawingSettings.FontPointsize = FontPointsize;
		nativeDrawingSettings.FontStyle = FontStyle;
		nativeDrawingSettings.FontWeight = FontWeight;
		nativeDrawingSettings.StrokeAntiAlias = StrokeAntiAlias;
		nativeDrawingSettings.StrokeColor = StrokeColor;
		nativeDrawingSettings.StrokeDashOffset = StrokeDashOffset;
		nativeDrawingSettings.StrokeLineCap = StrokeLineCap;
		nativeDrawingSettings.StrokeLineJoin = StrokeLineJoin;
		nativeDrawingSettings.StrokeMiterLimit = StrokeMiterLimit;
		nativeDrawingSettings.StrokeWidth = StrokeWidth;
		nativeDrawingSettings.TextAntiAlias = TextAntiAlias;
		nativeDrawingSettings.TextDirection = TextDirection;
		if (TextEncoding != null)
		{
			nativeDrawingSettings.TextEncoding = TextEncoding.WebName;
		}
		nativeDrawingSettings.TextGravity = TextGravity;
		nativeDrawingSettings.TextInterlineSpacing = TextInterlineSpacing;
		nativeDrawingSettings.TextInterwordSpacing = TextInterwordSpacing;
		nativeDrawingSettings.TextKerning = TextKerning;
		nativeDrawingSettings.TextUnderColor = TextUnderColor;
		if (Affine != null)
		{
			nativeDrawingSettings.SetAffine(Affine.ScaleX, Affine.ScaleY, Affine.ShearX, Affine.ShearY, Affine.TranslateX, Affine.TranslateY);
		}
		if (FillPattern != null)
		{
			nativeDrawingSettings.SetFillPattern(FillPattern);
		}
		if (_strokeDashArray != null)
		{
			nativeDrawingSettings.SetStrokeDashArray(_strokeDashArray, _strokeDashArray.Length);
		}
		if (StrokePattern != null)
		{
			nativeDrawingSettings.SetStrokePattern(StrokePattern);
		}
		if (!string.IsNullOrEmpty(Text))
		{
			nativeDrawingSettings.SetText(Text);
		}
		return nativeDrawingSettings;
	}
}
