using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageMagick;

public sealed class MagickImage : IDisposable, IMagickImage, IEquatable<IMagickImage>, IComparable<IMagickImage>, INativeInstance
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate bool ProgressDelegate(IntPtr origin, long offset, ulong extent, IntPtr userData);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate int ReadWriteStreamDelegate(IntPtr data, UIntPtr length, IntPtr user_data);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate long SeekStreamDelegate(long offset, IntPtr whence, IntPtr user_data);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate long TellStreamDelegate(IntPtr user_data);

	private static class NativeMethods
	{
		public static class X64
		{
			static X64()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Create(IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_AnimationDelay_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_AnimationDelay_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_AnimationIterations_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_AnimationIterations_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_BackgroundColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_BackgroundColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_BaseHeight_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_BaseWidth_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_BlackPointCompensation_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_BlackPointCompensation_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_BorderColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_BorderColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_BoundingBox_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_ChannelCount_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ChromaBluePrimary_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ChromaBluePrimary_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ChromaGreenPrimary_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ChromaGreenPrimary_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ChromaRedPrimary_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ChromaRedPrimary_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ChromaWhitePoint_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ChromaWhitePoint_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_ClassType_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ClassType_Set(IntPtr instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_ColorFuzz_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ColorFuzz_Set(IntPtr instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ColormapSize_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ColormapSize_Set(IntPtr instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_ColorSpace_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ColorSpace_Set(IntPtr instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_ColorType_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ColorType_Set(IntPtr instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Compose_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Compose_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_CompressionMethod_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_CompressionMethod_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Depth_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Depth_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Endian_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Endian_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_EncodingGeometry_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_FileName_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_FileName_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern long MagickImage_FileSize_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_FilterType_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_FilterType_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Format_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Format_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_Gamma_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_GifDisposeMethod_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_GifDisposeMethod_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Height_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_HasAlpha_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_HasAlpha_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Interlace_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Interlace_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Interpolate_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Interpolate_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_IsOpaque_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_MatteColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_MatteColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_MeanErrorPerPixel_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_NormalizedMaximumError_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_NormalizedMeanError_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Orientation_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Orientation_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Page_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Page_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Quality_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Quality_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ReadMask_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ReadMask_Set(IntPtr instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_RenderingIntent_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_RenderingIntent_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_ResolutionUnits_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ResolutionUnits_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_ResolutionX_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ResolutionX_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_ResolutionY_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ResolutionY_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Signature_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_TotalColors_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_VirtualPixelMethod_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_VirtualPixelMethod_Set(IntPtr instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Width_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_WriteMask_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_WriteMask_Set(IntPtr instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_AdaptiveBlur(IntPtr Instance, double radius, double sigma, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_AdaptiveResize(IntPtr Instance, UIntPtr width, UIntPtr height, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_AdaptiveSharpen(IntPtr Instance, double radius, double sigma, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_AdaptiveThreshold(IntPtr Instance, UIntPtr width, UIntPtr height, double bias, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_AddNoise(IntPtr Instance, UIntPtr noiseType, double attenuate, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_AddProfile(IntPtr Instance, IntPtr name, byte[] datum, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_AffineTransform(IntPtr Instance, double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Annotate(IntPtr Instance, IntPtr settings, IntPtr text, IntPtr boundingArea, UIntPtr gravity, double degrees, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_AnnotateGravity(IntPtr Instance, IntPtr settings, IntPtr text, UIntPtr gravity, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_AutoGamma(IntPtr Instance, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_AutoLevel(IntPtr Instance, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_AutoOrient(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_AutoThreshold(IntPtr Instance, UIntPtr method, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_BlackThreshold(IntPtr Instance, IntPtr threshold, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_BlueShift(IntPtr Instance, double factor, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Blur(IntPtr Instance, double radius, double sigma, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Border(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_BrightnessContrast(IntPtr Instance, double brightness, double contrast, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_CannyEdge(IntPtr Instance, double radius, double sigma, double lower, double upper, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_ChannelOffset(IntPtr Instance, UIntPtr channel);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Charcoal(IntPtr Instance, double radius, double sigma, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Chop(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Clamp(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ClampChannel(IntPtr Instance, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Clip(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ClipPath(IntPtr Instance, IntPtr pathName, [MarshalAs(UnmanagedType.Bool)] bool inside, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Clone(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_CloneArea(IntPtr Instance, UIntPtr width, UIntPtr height, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Clut(IntPtr Instance, IntPtr image, UIntPtr method, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ColorDecisionList(IntPtr Instance, IntPtr fileName, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Colorize(IntPtr Instance, IntPtr color, IntPtr blend, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Compare(IntPtr Instance, IntPtr image, UIntPtr metric, UIntPtr channels, out double distortion, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Contrast(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool enhance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ContrastStretch(IntPtr Instance, double blackPoint, double whitePoint, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ColorMatrix(IntPtr Instance, IntPtr matrix, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_CompareDistortion(IntPtr Instance, IntPtr image, UIntPtr metric, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Composite(IntPtr Instance, IntPtr image, IntPtr x, IntPtr y, UIntPtr compose, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_CompositeGravity(IntPtr Instance, IntPtr image, UIntPtr gravity, UIntPtr compose, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ConnectedComponents(IntPtr Instance, UIntPtr connectivity, out IntPtr objects, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Convolve(IntPtr Instance, IntPtr matrix, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_CopyPixels(IntPtr Instance, IntPtr image, IntPtr geometry, IntPtr offset, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Crop(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_CropToTiles(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_CycleColormap(IntPtr Instance, IntPtr amount, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Decipher(IntPtr Instance, IntPtr passphrase, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Deskew(IntPtr Instance, double threshold, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Despeckle(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_DetermineColorType(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Distort(IntPtr Instance, UIntPtr method, [MarshalAs(UnmanagedType.Bool)] bool bestfit, double[] arguments, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Edge(IntPtr Instance, double radius, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Emboss(IntPtr Instance, double radius, double sigma, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Encipher(IntPtr Instance, IntPtr passphrase, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Enhance(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Equalize(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_Equals(IntPtr Instance, IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_EvaluateFunction(IntPtr Instance, UIntPtr channels, UIntPtr evaluateFunction, double[] values, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_EvaluateGeometry(IntPtr Instance, UIntPtr channels, IntPtr geometry, UIntPtr evaluateOperator, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_EvaluateOperator(IntPtr Instance, UIntPtr channels, UIntPtr evaluateOperator, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Extent(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ExtentGravity(IntPtr Instance, IntPtr geometry, UIntPtr gravity, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Flip(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_FloodFill(IntPtr Instance, IntPtr settings, IntPtr x, IntPtr y, IntPtr target, [MarshalAs(UnmanagedType.Bool)] bool invert, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Flop(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_FontTypeMetrics(IntPtr Instance, IntPtr settings, [MarshalAs(UnmanagedType.Bool)] bool ignoreNewLines, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_FormatExpression(IntPtr Instance, IntPtr settings, IntPtr expression, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Frame(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Fx(IntPtr Instance, IntPtr expression, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_GammaCorrect(IntPtr Instance, double gamma, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GaussianBlur(IntPtr Instance, double radius, double sigma, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetArtifact(IntPtr Instance, IntPtr name);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetAttribute(IntPtr Instance, IntPtr name, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_GetBitDepth(IntPtr Instance, UIntPtr channels);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetColormap(IntPtr Instance, UIntPtr index);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetNext(IntPtr image);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetNextArtifactName(IntPtr Instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetNextAttributeName(IntPtr Instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetNextProfileName(IntPtr Instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetProfile(IntPtr Instance, IntPtr name, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Grayscale(IntPtr Instance, UIntPtr method, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_HaldClut(IntPtr Instance, IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_HasChannel(IntPtr Instance, UIntPtr channel);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_HasProfile(IntPtr Instance, IntPtr name);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Histogram(IntPtr Instance, out UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_HoughLine(IntPtr Instance, UIntPtr width, UIntPtr height, UIntPtr threshold, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Implode(IntPtr Instance, double amount, UIntPtr method, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Kuwahara(IntPtr Instance, double radius, double sigma, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Level(IntPtr Instance, double blackPoint, double whitePoint, double gamma, UIntPtr channels);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_LevelColors(IntPtr Instance, IntPtr blackColor, IntPtr whiteColor, UIntPtr channels, [MarshalAs(UnmanagedType.Bool)] bool invert, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Levelize(IntPtr Instance, double blackPoint, double whitePoint, double gamma, UIntPtr channels);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_LinearStretch(IntPtr Instance, double blackPoint, double whitePoint, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_LiquidRescale(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_LocalContrast(IntPtr Instance, double radius, double strength, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Magnify(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_Map(IntPtr Instance, IntPtr image, IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_MeanShift(IntPtr Instance, UIntPtr width, UIntPtr height, double colorDistance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Minify(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Moments(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Modulate(IntPtr Instance, IntPtr modulate, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Morphology(IntPtr Instance, UIntPtr method, IntPtr kernel, UIntPtr channels, UIntPtr iterations, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_MotionBlur(IntPtr Instance, double radius, double sigma, double angle, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Negate(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool onlyGrayscale, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Normalize(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_OilPaint(IntPtr Instance, double radius, double sigma, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Opaque(IntPtr Instance, IntPtr target, IntPtr fill, [MarshalAs(UnmanagedType.Bool)] bool invert, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_OrderedDither(IntPtr Instance, IntPtr thresholdMap, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Perceptible(IntPtr Instance, double epsilon, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_PerceptualHash(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Polaroid(IntPtr Instance, IntPtr settings, IntPtr caption, double angle, UIntPtr method, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Posterize(IntPtr Instance, UIntPtr levels, UIntPtr method, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Quantize(IntPtr Instance, IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_RaiseOrLower(IntPtr Instance, UIntPtr size, [MarshalAs(UnmanagedType.Bool)] bool raise, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_RandomThreshold(IntPtr Instance, double low, double high, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ReadBlob(IntPtr settings, byte[] data, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ReadFile(IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ReadPixels(UIntPtr width, UIntPtr height, IntPtr map, UIntPtr storageType, byte[] data, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ReadStream(IntPtr settings, ReadWriteStreamDelegate reader, SeekStreamDelegate seeker, TellStreamDelegate teller, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_RegionMask(IntPtr Instance, IntPtr region, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_RemoveArtifact(IntPtr Instance, IntPtr name);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_RemoveAttribute(IntPtr Instance, IntPtr name);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_RemoveProfile(IntPtr Instance, IntPtr name);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ResetArtifactIterator(IntPtr Instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ResetAttributeIterator(IntPtr Instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ResetProfileIterator(IntPtr Instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Resample(IntPtr Instance, double resolutionX, double resolutionY, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Resize(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Roll(IntPtr Instance, IntPtr x, IntPtr y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Rotate(IntPtr Instance, double degrees, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_RotationalBlur(IntPtr Instance, double angle, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Sample(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Scale(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Segment(IntPtr Instance, UIntPtr colorSpace, double clusterThreshold, double smoothingThreshold, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_SelectiveBlur(IntPtr Instance, double radius, double sigma, double threshold, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Separate(IntPtr Instance, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_SepiaTone(IntPtr Instance, double threshold, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SetAlpha(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SetArtifact(IntPtr Instance, IntPtr name, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SetAttribute(IntPtr Instance, IntPtr name, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SetBitDepth(IntPtr Instance, UIntPtr channels, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SetColormap(IntPtr Instance, UIntPtr index, IntPtr color, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_SetColorMetric(IntPtr Instance, IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SetNext(IntPtr Instance, IntPtr image);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SetProgressDelegate(IntPtr Instance, ProgressDelegate method);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Shade(IntPtr Instance, double azimuth, double elevation, [MarshalAs(UnmanagedType.Bool)] bool colorShading, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Shadow(IntPtr Instance, IntPtr x, IntPtr y, double sigma, double alphaPercentage, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Sharpen(IntPtr Instance, double radius, double sigma, UIntPtr channel, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Shave(IntPtr Instance, UIntPtr leftRight, UIntPtr topBottom, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Shear(IntPtr Instance, double xAngle, double yAngle, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SigmoidalContrast(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool sharpen, double contrast, double midpoint, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_SparseColor(IntPtr Instance, UIntPtr channel, UIntPtr method, double[] values, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Sketch(IntPtr Instance, double radius, double sigma, double angle, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Solarize(IntPtr Instance, double factor, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Splice(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Spread(IntPtr Instance, UIntPtr method, double radius, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Statistic(IntPtr Instance, UIntPtr type, UIntPtr width, UIntPtr height, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Statistics(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Stegano(IntPtr Instance, IntPtr watermark, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Stereo(IntPtr Instance, IntPtr rightImage, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Strip(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_SubImageSearch(IntPtr Instance, IntPtr reference, UIntPtr metric, double similarityThreshold, IntPtr offset, out double similarityMetric, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Swirl(IntPtr Instance, UIntPtr method, double degrees, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Texture(IntPtr Instance, IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Threshold(IntPtr Instance, double threshold, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Thumbnail(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Tint(IntPtr Instance, IntPtr opacity, IntPtr tint, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Transparent(IntPtr Instance, IntPtr color, [MarshalAs(UnmanagedType.Bool)] bool invert, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_TransparentChroma(IntPtr Instance, IntPtr colorLow, IntPtr colorHigh, [MarshalAs(UnmanagedType.Bool)] bool invert, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Transpose(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Transverse(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Trim(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_UniqueColors(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_UnsharpMask(IntPtr Instance, double radius, double sigma, double amount, double threshold, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Vignette(IntPtr Instance, double radius, double sigma, IntPtr x, IntPtr y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Wave(IntPtr Instance, UIntPtr method, double amplitude, double length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_WaveletDenoise(IntPtr Instance, double threshold, double softness, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_WhiteThreshold(IntPtr Instance, IntPtr threshold, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_WriteFile(IntPtr Instance, IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_WriteStream(IntPtr Instance, IntPtr settings, ReadWriteStreamDelegate writer, SeekStreamDelegate seeker, TellStreamDelegate teller, out IntPtr exception);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Create(IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_AnimationDelay_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_AnimationDelay_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_AnimationIterations_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_AnimationIterations_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_BackgroundColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_BackgroundColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_BaseHeight_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_BaseWidth_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_BlackPointCompensation_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_BlackPointCompensation_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_BorderColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_BorderColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_BoundingBox_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_ChannelCount_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ChromaBluePrimary_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ChromaBluePrimary_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ChromaGreenPrimary_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ChromaGreenPrimary_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ChromaRedPrimary_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ChromaRedPrimary_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ChromaWhitePoint_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ChromaWhitePoint_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_ClassType_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ClassType_Set(IntPtr instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_ColorFuzz_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ColorFuzz_Set(IntPtr instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ColormapSize_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ColormapSize_Set(IntPtr instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_ColorSpace_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ColorSpace_Set(IntPtr instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_ColorType_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ColorType_Set(IntPtr instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Compose_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Compose_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_CompressionMethod_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_CompressionMethod_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Depth_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Depth_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Endian_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Endian_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_EncodingGeometry_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_FileName_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_FileName_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern long MagickImage_FileSize_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_FilterType_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_FilterType_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Format_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Format_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_Gamma_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_GifDisposeMethod_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_GifDisposeMethod_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Height_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_HasAlpha_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_HasAlpha_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Interlace_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Interlace_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Interpolate_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Interpolate_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_IsOpaque_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_MatteColor_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_MatteColor_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_MeanErrorPerPixel_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_NormalizedMaximumError_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_NormalizedMeanError_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Orientation_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Orientation_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Page_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Page_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Quality_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Quality_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ReadMask_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ReadMask_Set(IntPtr instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_RenderingIntent_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_RenderingIntent_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_ResolutionUnits_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ResolutionUnits_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_ResolutionX_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ResolutionX_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_ResolutionY_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ResolutionY_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Signature_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_TotalColors_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_VirtualPixelMethod_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_VirtualPixelMethod_Set(IntPtr instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_Width_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_WriteMask_Get(IntPtr instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_WriteMask_Set(IntPtr instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_AdaptiveBlur(IntPtr Instance, double radius, double sigma, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_AdaptiveResize(IntPtr Instance, UIntPtr width, UIntPtr height, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_AdaptiveSharpen(IntPtr Instance, double radius, double sigma, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_AdaptiveThreshold(IntPtr Instance, UIntPtr width, UIntPtr height, double bias, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_AddNoise(IntPtr Instance, UIntPtr noiseType, double attenuate, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_AddProfile(IntPtr Instance, IntPtr name, byte[] datum, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_AffineTransform(IntPtr Instance, double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Annotate(IntPtr Instance, IntPtr settings, IntPtr text, IntPtr boundingArea, UIntPtr gravity, double degrees, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_AnnotateGravity(IntPtr Instance, IntPtr settings, IntPtr text, UIntPtr gravity, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_AutoGamma(IntPtr Instance, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_AutoLevel(IntPtr Instance, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_AutoOrient(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_AutoThreshold(IntPtr Instance, UIntPtr method, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_BlackThreshold(IntPtr Instance, IntPtr threshold, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_BlueShift(IntPtr Instance, double factor, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Blur(IntPtr Instance, double radius, double sigma, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Border(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_BrightnessContrast(IntPtr Instance, double brightness, double contrast, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_CannyEdge(IntPtr Instance, double radius, double sigma, double lower, double upper, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_ChannelOffset(IntPtr Instance, UIntPtr channel);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Charcoal(IntPtr Instance, double radius, double sigma, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Chop(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Clamp(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ClampChannel(IntPtr Instance, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Clip(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ClipPath(IntPtr Instance, IntPtr pathName, [MarshalAs(UnmanagedType.Bool)] bool inside, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Clone(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_CloneArea(IntPtr Instance, UIntPtr width, UIntPtr height, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Clut(IntPtr Instance, IntPtr image, UIntPtr method, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ColorDecisionList(IntPtr Instance, IntPtr fileName, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Colorize(IntPtr Instance, IntPtr color, IntPtr blend, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Compare(IntPtr Instance, IntPtr image, UIntPtr metric, UIntPtr channels, out double distortion, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Contrast(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool enhance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ContrastStretch(IntPtr Instance, double blackPoint, double whitePoint, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ColorMatrix(IntPtr Instance, IntPtr matrix, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickImage_CompareDistortion(IntPtr Instance, IntPtr image, UIntPtr metric, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Composite(IntPtr Instance, IntPtr image, IntPtr x, IntPtr y, UIntPtr compose, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_CompositeGravity(IntPtr Instance, IntPtr image, UIntPtr gravity, UIntPtr compose, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ConnectedComponents(IntPtr Instance, UIntPtr connectivity, out IntPtr objects, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Convolve(IntPtr Instance, IntPtr matrix, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_CopyPixels(IntPtr Instance, IntPtr image, IntPtr geometry, IntPtr offset, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Crop(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_CropToTiles(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_CycleColormap(IntPtr Instance, IntPtr amount, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Decipher(IntPtr Instance, IntPtr passphrase, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Deskew(IntPtr Instance, double threshold, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Despeckle(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_DetermineColorType(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Distort(IntPtr Instance, UIntPtr method, [MarshalAs(UnmanagedType.Bool)] bool bestfit, double[] arguments, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Edge(IntPtr Instance, double radius, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Emboss(IntPtr Instance, double radius, double sigma, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Encipher(IntPtr Instance, IntPtr passphrase, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Enhance(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Equalize(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_Equals(IntPtr Instance, IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_EvaluateFunction(IntPtr Instance, UIntPtr channels, UIntPtr evaluateFunction, double[] values, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_EvaluateGeometry(IntPtr Instance, UIntPtr channels, IntPtr geometry, UIntPtr evaluateOperator, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_EvaluateOperator(IntPtr Instance, UIntPtr channels, UIntPtr evaluateOperator, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Extent(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ExtentGravity(IntPtr Instance, IntPtr geometry, UIntPtr gravity, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Flip(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_FloodFill(IntPtr Instance, IntPtr settings, IntPtr x, IntPtr y, IntPtr target, [MarshalAs(UnmanagedType.Bool)] bool invert, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Flop(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_FontTypeMetrics(IntPtr Instance, IntPtr settings, [MarshalAs(UnmanagedType.Bool)] bool ignoreNewLines, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_FormatExpression(IntPtr Instance, IntPtr settings, IntPtr expression, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Frame(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Fx(IntPtr Instance, IntPtr expression, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_GammaCorrect(IntPtr Instance, double gamma, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GaussianBlur(IntPtr Instance, double radius, double sigma, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetArtifact(IntPtr Instance, IntPtr name);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetAttribute(IntPtr Instance, IntPtr name, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickImage_GetBitDepth(IntPtr Instance, UIntPtr channels);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetColormap(IntPtr Instance, UIntPtr index);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetNext(IntPtr image);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetNextArtifactName(IntPtr Instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetNextAttributeName(IntPtr Instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetNextProfileName(IntPtr Instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_GetProfile(IntPtr Instance, IntPtr name, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Grayscale(IntPtr Instance, UIntPtr method, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_HaldClut(IntPtr Instance, IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_HasChannel(IntPtr Instance, UIntPtr channel);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_HasProfile(IntPtr Instance, IntPtr name);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Histogram(IntPtr Instance, out UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_HoughLine(IntPtr Instance, UIntPtr width, UIntPtr height, UIntPtr threshold, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Implode(IntPtr Instance, double amount, UIntPtr method, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Kuwahara(IntPtr Instance, double radius, double sigma, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Level(IntPtr Instance, double blackPoint, double whitePoint, double gamma, UIntPtr channels);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_LevelColors(IntPtr Instance, IntPtr blackColor, IntPtr whiteColor, UIntPtr channels, [MarshalAs(UnmanagedType.Bool)] bool invert, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Levelize(IntPtr Instance, double blackPoint, double whitePoint, double gamma, UIntPtr channels);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_LinearStretch(IntPtr Instance, double blackPoint, double whitePoint, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_LiquidRescale(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_LocalContrast(IntPtr Instance, double radius, double strength, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Magnify(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_Map(IntPtr Instance, IntPtr image, IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_MeanShift(IntPtr Instance, UIntPtr width, UIntPtr height, double colorDistance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Minify(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Moments(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Modulate(IntPtr Instance, IntPtr modulate, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Morphology(IntPtr Instance, UIntPtr method, IntPtr kernel, UIntPtr channels, UIntPtr iterations, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_MotionBlur(IntPtr Instance, double radius, double sigma, double angle, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Negate(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool onlyGrayscale, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Normalize(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_OilPaint(IntPtr Instance, double radius, double sigma, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Opaque(IntPtr Instance, IntPtr target, IntPtr fill, [MarshalAs(UnmanagedType.Bool)] bool invert, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_OrderedDither(IntPtr Instance, IntPtr thresholdMap, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Perceptible(IntPtr Instance, double epsilon, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_PerceptualHash(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Polaroid(IntPtr Instance, IntPtr settings, IntPtr caption, double angle, UIntPtr method, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Posterize(IntPtr Instance, UIntPtr levels, UIntPtr method, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Quantize(IntPtr Instance, IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_RaiseOrLower(IntPtr Instance, UIntPtr size, [MarshalAs(UnmanagedType.Bool)] bool raise, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_RandomThreshold(IntPtr Instance, double low, double high, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ReadBlob(IntPtr settings, byte[] data, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ReadFile(IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ReadPixels(UIntPtr width, UIntPtr height, IntPtr map, UIntPtr storageType, byte[] data, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_ReadStream(IntPtr settings, ReadWriteStreamDelegate reader, SeekStreamDelegate seeker, TellStreamDelegate teller, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_RegionMask(IntPtr Instance, IntPtr region, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_RemoveArtifact(IntPtr Instance, IntPtr name);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_RemoveAttribute(IntPtr Instance, IntPtr name);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_RemoveProfile(IntPtr Instance, IntPtr name);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ResetArtifactIterator(IntPtr Instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ResetAttributeIterator(IntPtr Instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_ResetProfileIterator(IntPtr Instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Resample(IntPtr Instance, double resolutionX, double resolutionY, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Resize(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Roll(IntPtr Instance, IntPtr x, IntPtr y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Rotate(IntPtr Instance, double degrees, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_RotationalBlur(IntPtr Instance, double angle, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Sample(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Scale(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Segment(IntPtr Instance, UIntPtr colorSpace, double clusterThreshold, double smoothingThreshold, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_SelectiveBlur(IntPtr Instance, double radius, double sigma, double threshold, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Separate(IntPtr Instance, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_SepiaTone(IntPtr Instance, double threshold, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SetAlpha(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SetArtifact(IntPtr Instance, IntPtr name, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SetAttribute(IntPtr Instance, IntPtr name, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SetBitDepth(IntPtr Instance, UIntPtr channels, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SetColormap(IntPtr Instance, UIntPtr index, IntPtr color, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickImage_SetColorMetric(IntPtr Instance, IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SetNext(IntPtr Instance, IntPtr image);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SetProgressDelegate(IntPtr Instance, ProgressDelegate method);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Shade(IntPtr Instance, double azimuth, double elevation, [MarshalAs(UnmanagedType.Bool)] bool colorShading, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Shadow(IntPtr Instance, IntPtr x, IntPtr y, double sigma, double alphaPercentage, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Sharpen(IntPtr Instance, double radius, double sigma, UIntPtr channel, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Shave(IntPtr Instance, UIntPtr leftRight, UIntPtr topBottom, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Shear(IntPtr Instance, double xAngle, double yAngle, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_SigmoidalContrast(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool sharpen, double contrast, double midpoint, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_SparseColor(IntPtr Instance, UIntPtr channel, UIntPtr method, double[] values, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Sketch(IntPtr Instance, double radius, double sigma, double angle, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Solarize(IntPtr Instance, double factor, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Splice(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Spread(IntPtr Instance, UIntPtr method, double radius, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Statistic(IntPtr Instance, UIntPtr type, UIntPtr width, UIntPtr height, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Statistics(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Stegano(IntPtr Instance, IntPtr watermark, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Stereo(IntPtr Instance, IntPtr rightImage, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Strip(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_SubImageSearch(IntPtr Instance, IntPtr reference, UIntPtr metric, double similarityThreshold, IntPtr offset, out double similarityMetric, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Swirl(IntPtr Instance, UIntPtr method, double degrees, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Texture(IntPtr Instance, IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Threshold(IntPtr Instance, double threshold, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Thumbnail(IntPtr Instance, IntPtr geometry, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Tint(IntPtr Instance, IntPtr opacity, IntPtr tint, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_Transparent(IntPtr Instance, IntPtr color, [MarshalAs(UnmanagedType.Bool)] bool invert, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_TransparentChroma(IntPtr Instance, IntPtr colorLow, IntPtr colorHigh, [MarshalAs(UnmanagedType.Bool)] bool invert, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Transpose(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Transverse(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Trim(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_UniqueColors(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_UnsharpMask(IntPtr Instance, double radius, double sigma, double amount, double threshold, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Vignette(IntPtr Instance, double radius, double sigma, IntPtr x, IntPtr y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_Wave(IntPtr Instance, UIntPtr method, double amplitude, double length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImage_WaveletDenoise(IntPtr Instance, double threshold, double softness, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_WhiteThreshold(IntPtr Instance, IntPtr threshold, UIntPtr channels, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_WriteFile(IntPtr Instance, IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImage_WriteStream(IntPtr Instance, IntPtr settings, ReadWriteStreamDelegate writer, SeekStreamDelegate seeker, TellStreamDelegate teller, out IntPtr exception);
		}
	}

	private sealed class NativeMagickImage : NativeInstance
	{
		protected override string TypeName => "MagickImage";

		public int AnimationDelay
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_AnimationDelay_Get(base.Instance) : NativeMethods.X64.MagickImage_AnimationDelay_Get(base.Instance));
				return (int)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_AnimationDelay_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickImage_AnimationDelay_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public int AnimationIterations
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_AnimationIterations_Get(base.Instance) : NativeMethods.X64.MagickImage_AnimationIterations_Get(base.Instance));
				return (int)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_AnimationIterations_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickImage_AnimationIterations_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public MagickColor BackgroundColor
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_BackgroundColor_Get(base.Instance) : NativeMethods.X64.MagickImage_BackgroundColor_Get(base.Instance));
				return MagickColor.CreateInstance(instance);
			}
			set
			{
				using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_BackgroundColor_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickImage_BackgroundColor_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public int BaseHeight
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_BaseHeight_Get(base.Instance) : NativeMethods.X64.MagickImage_BaseHeight_Get(base.Instance));
				return (int)(uint)uIntPtr;
			}
		}

		public int BaseWidth
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_BaseWidth_Get(base.Instance) : NativeMethods.X64.MagickImage_BaseWidth_Get(base.Instance));
				return (int)(uint)uIntPtr;
			}
		}

		public bool BlackPointCompensation
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickImage_BlackPointCompensation_Get(base.Instance);
				}
				return NativeMethods.X86.MagickImage_BlackPointCompensation_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_BlackPointCompensation_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.MagickImage_BlackPointCompensation_Set(base.Instance, value);
				}
			}
		}

		public MagickColor BorderColor
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_BorderColor_Get(base.Instance) : NativeMethods.X64.MagickImage_BorderColor_Get(base.Instance));
				return MagickColor.CreateInstance(instance);
			}
			set
			{
				using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_BorderColor_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickImage_BorderColor_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public MagickRectangle BoundingBox
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_BoundingBox_Get(base.Instance) : NativeMethods.X64.MagickImage_BoundingBox_Get(base.Instance));
				return MagickRectangle.CreateInstance(instance);
			}
		}

		public int ChannelCount
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ChannelCount_Get(base.Instance) : NativeMethods.X64.MagickImage_ChannelCount_Get(base.Instance));
				return (int)(uint)uIntPtr;
			}
		}

		public PrimaryInfo ChromaBluePrimary
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ChromaBluePrimary_Get(base.Instance) : NativeMethods.X64.MagickImage_ChromaBluePrimary_Get(base.Instance));
				return PrimaryInfo.CreateInstance(instance);
			}
			set
			{
				using INativeInstance nativeInstance = PrimaryInfo.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_ChromaBluePrimary_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickImage_ChromaBluePrimary_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public PrimaryInfo ChromaGreenPrimary
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ChromaGreenPrimary_Get(base.Instance) : NativeMethods.X64.MagickImage_ChromaGreenPrimary_Get(base.Instance));
				return PrimaryInfo.CreateInstance(instance);
			}
			set
			{
				using INativeInstance nativeInstance = PrimaryInfo.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_ChromaGreenPrimary_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickImage_ChromaGreenPrimary_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public PrimaryInfo ChromaRedPrimary
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ChromaRedPrimary_Get(base.Instance) : NativeMethods.X64.MagickImage_ChromaRedPrimary_Get(base.Instance));
				return PrimaryInfo.CreateInstance(instance);
			}
			set
			{
				using INativeInstance nativeInstance = PrimaryInfo.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_ChromaRedPrimary_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickImage_ChromaRedPrimary_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public PrimaryInfo ChromaWhitePoint
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ChromaWhitePoint_Get(base.Instance) : NativeMethods.X64.MagickImage_ChromaWhitePoint_Get(base.Instance));
				return PrimaryInfo.CreateInstance(instance);
			}
			set
			{
				using INativeInstance nativeInstance = PrimaryInfo.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_ChromaWhitePoint_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickImage_ChromaWhitePoint_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public ClassType ClassType
		{
			get
			{
				IntPtr exception = IntPtr.Zero;
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ClassType_Get(base.Instance, out exception) : NativeMethods.X64.MagickImage_ClassType_Get(base.Instance, out exception));
				CheckException(exception);
				return (ClassType)(uint)uIntPtr;
			}
			set
			{
				IntPtr exception = IntPtr.Zero;
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_ClassType_Set(base.Instance, (UIntPtr)(ulong)value, out exception);
				}
				else
				{
					NativeMethods.X86.MagickImage_ClassType_Set(base.Instance, (UIntPtr)(ulong)value, out exception);
				}
				CheckException(exception);
			}
		}

		public double ColorFuzz
		{
			get
			{
				IntPtr exception = IntPtr.Zero;
				double result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ColorFuzz_Get(base.Instance, out exception) : NativeMethods.X64.MagickImage_ColorFuzz_Get(base.Instance, out exception));
				CheckException(exception);
				return result;
			}
			set
			{
				IntPtr exception = IntPtr.Zero;
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_ColorFuzz_Set(base.Instance, value, out exception);
				}
				else
				{
					NativeMethods.X86.MagickImage_ColorFuzz_Set(base.Instance, value, out exception);
				}
				CheckException(exception);
			}
		}

		public int ColormapSize
		{
			get
			{
				IntPtr exception = IntPtr.Zero;
				IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ColormapSize_Get(base.Instance, out exception) : NativeMethods.X64.MagickImage_ColormapSize_Get(base.Instance, out exception));
				CheckException(exception);
				return (int)intPtr;
			}
			set
			{
				IntPtr exception = IntPtr.Zero;
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_ColormapSize_Set(base.Instance, (IntPtr)value, out exception);
				}
				else
				{
					NativeMethods.X86.MagickImage_ColormapSize_Set(base.Instance, (IntPtr)value, out exception);
				}
				CheckException(exception);
			}
		}

		public ColorSpace ColorSpace
		{
			get
			{
				IntPtr exception = IntPtr.Zero;
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ColorSpace_Get(base.Instance, out exception) : NativeMethods.X64.MagickImage_ColorSpace_Get(base.Instance, out exception));
				CheckException(exception);
				return (ColorSpace)(uint)uIntPtr;
			}
			set
			{
				IntPtr exception = IntPtr.Zero;
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_ColorSpace_Set(base.Instance, (UIntPtr)(ulong)value, out exception);
				}
				else
				{
					NativeMethods.X86.MagickImage_ColorSpace_Set(base.Instance, (UIntPtr)(ulong)value, out exception);
				}
				CheckException(exception);
			}
		}

		public ColorType ColorType
		{
			get
			{
				IntPtr exception = IntPtr.Zero;
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ColorType_Get(base.Instance, out exception) : NativeMethods.X64.MagickImage_ColorType_Get(base.Instance, out exception));
				CheckException(exception);
				return (ColorType)(uint)uIntPtr;
			}
			set
			{
				IntPtr exception = IntPtr.Zero;
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_ColorType_Set(base.Instance, (UIntPtr)(ulong)value, out exception);
				}
				else
				{
					NativeMethods.X86.MagickImage_ColorType_Set(base.Instance, (UIntPtr)(ulong)value, out exception);
				}
				CheckException(exception);
			}
		}

		public CompositeOperator Compose
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Compose_Get(base.Instance) : NativeMethods.X64.MagickImage_Compose_Get(base.Instance));
				return (CompositeOperator)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_Compose_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickImage_Compose_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public CompressionMethod CompressionMethod
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_CompressionMethod_Get(base.Instance) : NativeMethods.X64.MagickImage_CompressionMethod_Get(base.Instance));
				return (CompressionMethod)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_CompressionMethod_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickImage_CompressionMethod_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public int Depth
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Depth_Get(base.Instance) : NativeMethods.X64.MagickImage_Depth_Get(base.Instance));
				return (int)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_Depth_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickImage_Depth_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public Endian Endian
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Endian_Get(base.Instance) : NativeMethods.X64.MagickImage_Endian_Get(base.Instance));
				return (Endian)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_Endian_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickImage_Endian_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public string EncodingGeometry
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_EncodingGeometry_Get(base.Instance) : NativeMethods.X64.MagickImage_EncodingGeometry_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
		}

		public string FileName
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_FileName_Get(base.Instance) : NativeMethods.X64.MagickImage_FileName_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
			set
			{
				using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_FileName_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickImage_FileName_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public long FileSize
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickImage_FileSize_Get(base.Instance);
				}
				return NativeMethods.X86.MagickImage_FileSize_Get(base.Instance);
			}
		}

		public FilterType FilterType
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_FilterType_Get(base.Instance) : NativeMethods.X64.MagickImage_FilterType_Get(base.Instance));
				return (FilterType)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_FilterType_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickImage_FilterType_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public string Format
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Format_Get(base.Instance) : NativeMethods.X64.MagickImage_Format_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
			set
			{
				using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_Format_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickImage_Format_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public double Gamma
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickImage_Gamma_Get(base.Instance);
				}
				return NativeMethods.X86.MagickImage_Gamma_Get(base.Instance);
			}
		}

		public GifDisposeMethod GifDisposeMethod
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_GifDisposeMethod_Get(base.Instance) : NativeMethods.X64.MagickImage_GifDisposeMethod_Get(base.Instance));
				return (GifDisposeMethod)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_GifDisposeMethod_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickImage_GifDisposeMethod_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public int Height
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Height_Get(base.Instance) : NativeMethods.X64.MagickImage_Height_Get(base.Instance));
				return (int)(uint)uIntPtr;
			}
		}

		public bool HasAlpha
		{
			get
			{
				IntPtr exception = IntPtr.Zero;
				bool result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_HasAlpha_Get(base.Instance, out exception) : NativeMethods.X64.MagickImage_HasAlpha_Get(base.Instance, out exception));
				CheckException(exception);
				return result;
			}
			set
			{
				IntPtr exception = IntPtr.Zero;
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_HasAlpha_Set(base.Instance, value, out exception);
				}
				else
				{
					NativeMethods.X86.MagickImage_HasAlpha_Set(base.Instance, value, out exception);
				}
				CheckException(exception);
			}
		}

		public Interlace Interlace
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Interlace_Get(base.Instance) : NativeMethods.X64.MagickImage_Interlace_Get(base.Instance));
				return (Interlace)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_Interlace_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickImage_Interlace_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public PixelInterpolateMethod Interpolate
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Interpolate_Get(base.Instance) : NativeMethods.X64.MagickImage_Interpolate_Get(base.Instance));
				return (PixelInterpolateMethod)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_Interpolate_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickImage_Interpolate_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public bool IsOpaque
		{
			get
			{
				IntPtr exception = IntPtr.Zero;
				bool result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_IsOpaque_Get(base.Instance, out exception) : NativeMethods.X64.MagickImage_IsOpaque_Get(base.Instance, out exception));
				CheckException(exception);
				return result;
			}
		}

		public MagickColor MatteColor
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_MatteColor_Get(base.Instance) : NativeMethods.X64.MagickImage_MatteColor_Get(base.Instance));
				return MagickColor.CreateInstance(instance);
			}
			set
			{
				using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_MatteColor_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickImage_MatteColor_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public double MeanErrorPerPixel
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickImage_MeanErrorPerPixel_Get(base.Instance);
				}
				return NativeMethods.X86.MagickImage_MeanErrorPerPixel_Get(base.Instance);
			}
		}

		public double NormalizedMaximumError
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickImage_NormalizedMaximumError_Get(base.Instance);
				}
				return NativeMethods.X86.MagickImage_NormalizedMaximumError_Get(base.Instance);
			}
		}

		public double NormalizedMeanError
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickImage_NormalizedMeanError_Get(base.Instance);
				}
				return NativeMethods.X86.MagickImage_NormalizedMeanError_Get(base.Instance);
			}
		}

		public OrientationType Orientation
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Orientation_Get(base.Instance) : NativeMethods.X64.MagickImage_Orientation_Get(base.Instance));
				return (OrientationType)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_Orientation_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickImage_Orientation_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public MagickRectangle Page
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Page_Get(base.Instance) : NativeMethods.X64.MagickImage_Page_Get(base.Instance));
				return MagickRectangle.CreateInstance(instance);
			}
			set
			{
				using INativeInstance nativeInstance = MagickRectangle.CreateInstance(value);
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_Page_Set(base.Instance, nativeInstance.Instance);
				}
				else
				{
					NativeMethods.X86.MagickImage_Page_Set(base.Instance, nativeInstance.Instance);
				}
			}
		}

		public int Quality
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Quality_Get(base.Instance) : NativeMethods.X64.MagickImage_Quality_Get(base.Instance));
				return (int)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_Quality_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickImage_Quality_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public IMagickImage ReadMask
		{
			get
			{
				IntPtr exception = IntPtr.Zero;
				IntPtr self = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ReadMask_Get(base.Instance, out exception) : NativeMethods.X64.MagickImage_ReadMask_Get(base.Instance, out exception));
				CheckException(exception);
				return self.CreateIMagickImage();
			}
			set
			{
				IntPtr exception = IntPtr.Zero;
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_ReadMask_Set(base.Instance, value.GetInstance(), out exception);
				}
				else
				{
					NativeMethods.X86.MagickImage_ReadMask_Set(base.Instance, value.GetInstance(), out exception);
				}
				CheckException(exception);
			}
		}

		public RenderingIntent RenderingIntent
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_RenderingIntent_Get(base.Instance) : NativeMethods.X64.MagickImage_RenderingIntent_Get(base.Instance));
				return (RenderingIntent)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_RenderingIntent_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickImage_RenderingIntent_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public DensityUnit ResolutionUnits
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ResolutionUnits_Get(base.Instance) : NativeMethods.X64.MagickImage_ResolutionUnits_Get(base.Instance));
				return (DensityUnit)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_ResolutionUnits_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickImage_ResolutionUnits_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public double ResolutionX
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickImage_ResolutionX_Get(base.Instance);
				}
				return NativeMethods.X86.MagickImage_ResolutionX_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_ResolutionX_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.MagickImage_ResolutionX_Set(base.Instance, value);
				}
			}
		}

		public double ResolutionY
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickImage_ResolutionY_Get(base.Instance);
				}
				return NativeMethods.X86.MagickImage_ResolutionY_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_ResolutionY_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.MagickImage_ResolutionY_Set(base.Instance, value);
				}
			}
		}

		public string Signature
		{
			get
			{
				IntPtr exception = IntPtr.Zero;
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Signature_Get(base.Instance, out exception) : NativeMethods.X64.MagickImage_Signature_Get(base.Instance, out exception));
				CheckException(exception);
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
		}

		public int TotalColors
		{
			get
			{
				IntPtr exception = IntPtr.Zero;
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_TotalColors_Get(base.Instance, out exception) : NativeMethods.X64.MagickImage_TotalColors_Get(base.Instance, out exception));
				CheckException(exception);
				return (int)(uint)uIntPtr;
			}
		}

		public VirtualPixelMethod VirtualPixelMethod
		{
			get
			{
				IntPtr exception = IntPtr.Zero;
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_VirtualPixelMethod_Get(base.Instance, out exception) : NativeMethods.X64.MagickImage_VirtualPixelMethod_Get(base.Instance, out exception));
				CheckException(exception);
				return (VirtualPixelMethod)(uint)uIntPtr;
			}
			set
			{
				IntPtr exception = IntPtr.Zero;
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_VirtualPixelMethod_Set(base.Instance, (UIntPtr)(ulong)value, out exception);
				}
				else
				{
					NativeMethods.X86.MagickImage_VirtualPixelMethod_Set(base.Instance, (UIntPtr)(ulong)value, out exception);
				}
				CheckException(exception);
			}
		}

		public int Width
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Width_Get(base.Instance) : NativeMethods.X64.MagickImage_Width_Get(base.Instance));
				return (int)(uint)uIntPtr;
			}
		}

		public IMagickImage WriteMask
		{
			get
			{
				IntPtr exception = IntPtr.Zero;
				IntPtr self = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_WriteMask_Get(base.Instance, out exception) : NativeMethods.X64.MagickImage_WriteMask_Get(base.Instance, out exception));
				CheckException(exception);
				return self.CreateIMagickImage();
			}
			set
			{
				IntPtr exception = IntPtr.Zero;
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickImage_WriteMask_Set(base.Instance, value.GetInstance(), out exception);
				}
				else
				{
					NativeMethods.X86.MagickImage_WriteMask_Set(base.Instance, value.GetInstance(), out exception);
				}
				CheckException(exception);
			}
		}

		static NativeMagickImage()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.MagickImage_Dispose(instance);
			}
		}

		public NativeMagickImage(MagickSettings settings)
		{
			using INativeInstance nativeInstance = MagickSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				base.Instance = NativeMethods.X64.MagickImage_Create(nativeInstance.Instance, out exception);
			}
			else
			{
				base.Instance = NativeMethods.X86.MagickImage_Create(nativeInstance.Instance, out exception);
			}
			CheckException(exception, base.Instance);
			if (base.Instance == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
		}

		public NativeMagickImage(IntPtr instance)
		{
			base.Instance = instance;
		}

		public void AdaptiveBlur(double radius, double sigma)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_AdaptiveBlur(base.Instance, radius, sigma, out exception) : NativeMethods.X64.MagickImage_AdaptiveBlur(base.Instance, radius, sigma, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void AdaptiveResize(int width, int height)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_AdaptiveResize(base.Instance, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, out exception) : NativeMethods.X64.MagickImage_AdaptiveResize(base.Instance, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void AdaptiveSharpen(double radius, double sigma, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_AdaptiveSharpen(base.Instance, radius, sigma, (UIntPtr)(ulong)channels, out exception) : NativeMethods.X64.MagickImage_AdaptiveSharpen(base.Instance, radius, sigma, (UIntPtr)(ulong)channels, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void AdaptiveThreshold(int width, int height, double bias)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_AdaptiveThreshold(base.Instance, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, bias, out exception) : NativeMethods.X64.MagickImage_AdaptiveThreshold(base.Instance, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, bias, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void AddNoise(NoiseType noiseType, double attenuate, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_AddNoise(base.Instance, (UIntPtr)(ulong)noiseType, attenuate, (UIntPtr)(ulong)channels, out exception) : NativeMethods.X64.MagickImage_AddNoise(base.Instance, (UIntPtr)(ulong)noiseType, attenuate, (UIntPtr)(ulong)channels, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void AddProfile(string name, byte[] datum, int length)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(name);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_AddProfile(base.Instance, nativeInstance.Instance, datum, (UIntPtr)(ulong)length, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_AddProfile(base.Instance, nativeInstance.Instance, datum, (UIntPtr)(ulong)length, out exception);
			}
			CheckException(exception);
		}

		public void AffineTransform(double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_AffineTransform(base.Instance, scaleX, scaleY, shearX, shearY, translateX, translateY, out exception) : NativeMethods.X64.MagickImage_AffineTransform(base.Instance, scaleX, scaleY, shearX, shearY, translateX, translateY, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Annotate(DrawingSettings settings, string text, string boundingArea, Gravity gravity, double degrees)
		{
			using INativeInstance nativeInstance = DrawingSettings.CreateInstance(settings);
			using INativeInstance nativeInstance2 = UTF8Marshaler.CreateInstance(text);
			using INativeInstance nativeInstance3 = UTF8Marshaler.CreateInstance(boundingArea);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Annotate(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, nativeInstance3.Instance, (UIntPtr)(ulong)gravity, degrees, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Annotate(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, nativeInstance3.Instance, (UIntPtr)(ulong)gravity, degrees, out exception);
			}
			CheckException(exception);
		}

		public void AnnotateGravity(DrawingSettings settings, string text, Gravity gravity)
		{
			using INativeInstance nativeInstance = DrawingSettings.CreateInstance(settings);
			using INativeInstance nativeInstance2 = UTF8Marshaler.CreateInstance(text);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_AnnotateGravity(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, (UIntPtr)(ulong)gravity, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_AnnotateGravity(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, (UIntPtr)(ulong)gravity, out exception);
			}
			CheckException(exception);
		}

		public void AutoGamma(Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_AutoGamma(base.Instance, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_AutoGamma(base.Instance, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public void AutoLevel(Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_AutoLevel(base.Instance, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_AutoLevel(base.Instance, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public void AutoOrient()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_AutoOrient(base.Instance, out exception) : NativeMethods.X64.MagickImage_AutoOrient(base.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void AutoThreshold(AutoThresholdMethod method)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_AutoThreshold(base.Instance, (UIntPtr)(ulong)method, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_AutoThreshold(base.Instance, (UIntPtr)(ulong)method, out exception);
			}
			CheckException(exception);
		}

		public void BlackThreshold(string threshold, Channels channels)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(threshold);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_BlackThreshold(base.Instance, nativeInstance.Instance, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_BlackThreshold(base.Instance, nativeInstance.Instance, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public void BlueShift(double factor)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_BlueShift(base.Instance, factor, out exception) : NativeMethods.X64.MagickImage_BlueShift(base.Instance, factor, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Blur(double radius, double sigma, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Blur(base.Instance, radius, sigma, (UIntPtr)(ulong)channels, out exception) : NativeMethods.X64.MagickImage_Blur(base.Instance, radius, sigma, (UIntPtr)(ulong)channels, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Border(MagickRectangle value)
		{
			using INativeInstance nativeInstance = MagickRectangle.CreateInstance(value);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Border(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_Border(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void BrightnessContrast(double brightness, double contrast, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_BrightnessContrast(base.Instance, brightness, contrast, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_BrightnessContrast(base.Instance, brightness, contrast, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public void CannyEdge(double radius, double sigma, double lower, double upper)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_CannyEdge(base.Instance, radius, sigma, lower, upper, out exception) : NativeMethods.X64.MagickImage_CannyEdge(base.Instance, radius, sigma, lower, upper, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public int ChannelOffset(PixelChannel channel)
		{
			if (NativeLibrary.Is64Bit)
			{
				return (int)(uint)NativeMethods.X64.MagickImage_ChannelOffset(base.Instance, (UIntPtr)(ulong)channel);
			}
			return (int)(uint)NativeMethods.X86.MagickImage_ChannelOffset(base.Instance, (UIntPtr)(ulong)channel);
		}

		public void Charcoal(double radius, double sigma)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Charcoal(base.Instance, radius, sigma, out exception) : NativeMethods.X64.MagickImage_Charcoal(base.Instance, radius, sigma, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Chop(MagickRectangle geometry)
		{
			using INativeInstance nativeInstance = MagickRectangle.CreateInstance(geometry);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Chop(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_Chop(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Clamp()
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Clamp(base.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Clamp(base.Instance, out exception);
			}
			CheckException(exception);
		}

		public void ClampChannel(Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_ClampChannel(base.Instance, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_ClampChannel(base.Instance, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public void Clip()
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Clip(base.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Clip(base.Instance, out exception);
			}
			CheckException(exception);
		}

		public void ClipPath(string pathName, bool inside)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(pathName);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_ClipPath(base.Instance, nativeInstance.Instance, inside, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_ClipPath(base.Instance, nativeInstance.Instance, inside, out exception);
			}
			CheckException(exception);
		}

		public IntPtr Clone()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Clone(base.Instance, out exception) : NativeMethods.X64.MagickImage_Clone(base.Instance, out exception));
			CheckException(exception, result);
			return result;
		}

		public IntPtr CloneArea(int width, int height)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_CloneArea(base.Instance, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, out exception) : NativeMethods.X64.MagickImage_CloneArea(base.Instance, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, out exception));
			CheckException(exception, result);
			return result;
		}

		public void Clut(IMagickImage image, PixelInterpolateMethod method, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Clut(base.Instance, image.GetInstance(), (UIntPtr)(ulong)method, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Clut(base.Instance, image.GetInstance(), (UIntPtr)(ulong)method, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public void ColorDecisionList(string fileName)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(fileName);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_ColorDecisionList(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_ColorDecisionList(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void Colorize(MagickColor color, string blend)
		{
			using INativeInstance nativeInstance = MagickColor.CreateInstance(color);
			using INativeInstance nativeInstance2 = UTF8Marshaler.CreateInstance(blend);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Colorize(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, out exception) : NativeMethods.X64.MagickImage_Colorize(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public IntPtr Compare(IMagickImage image, ErrorMetric metric, Channels channels, out double distortion)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Compare(base.Instance, image.GetInstance(), (UIntPtr)(ulong)metric, (UIntPtr)(ulong)channels, out distortion, out exception) : NativeMethods.X64.MagickImage_Compare(base.Instance, image.GetInstance(), (UIntPtr)(ulong)metric, (UIntPtr)(ulong)channels, out distortion, out exception));
			CheckException(exception, result);
			return result;
		}

		public void Contrast(bool enhance)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Contrast(base.Instance, enhance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Contrast(base.Instance, enhance, out exception);
			}
			CheckException(exception);
		}

		public void ContrastStretch(double blackPoint, double whitePoint, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_ContrastStretch(base.Instance, blackPoint, whitePoint, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_ContrastStretch(base.Instance, blackPoint, whitePoint, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public void ColorMatrix(DoubleMatrix matrix)
		{
			using INativeInstance nativeInstance = DoubleMatrix.CreateInstance(matrix);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ColorMatrix(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_ColorMatrix(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public double CompareDistortion(IMagickImage image, ErrorMetric metric, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			double result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_CompareDistortion(base.Instance, image.GetInstance(), (UIntPtr)(ulong)metric, (UIntPtr)(ulong)channels, out exception) : NativeMethods.X64.MagickImage_CompareDistortion(base.Instance, image.GetInstance(), (UIntPtr)(ulong)metric, (UIntPtr)(ulong)channels, out exception));
			CheckException(exception);
			return result;
		}

		public void Composite(IMagickImage image, int x, int y, CompositeOperator compose)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Composite(base.Instance, image.GetInstance(), (IntPtr)x, (IntPtr)y, (UIntPtr)(ulong)compose, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Composite(base.Instance, image.GetInstance(), (IntPtr)x, (IntPtr)y, (UIntPtr)(ulong)compose, out exception);
			}
			CheckException(exception);
		}

		public void CompositeGravity(IMagickImage image, Gravity gravity, CompositeOperator compose)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_CompositeGravity(base.Instance, image.GetInstance(), (UIntPtr)(ulong)gravity, (UIntPtr)(ulong)compose, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_CompositeGravity(base.Instance, image.GetInstance(), (UIntPtr)(ulong)gravity, (UIntPtr)(ulong)compose, out exception);
			}
			CheckException(exception);
		}

		public void ConnectedComponents(int connectivity, out IntPtr objects)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ConnectedComponents(base.Instance, (UIntPtr)(ulong)connectivity, out objects, out exception) : NativeMethods.X64.MagickImage_ConnectedComponents(base.Instance, (UIntPtr)(ulong)connectivity, out objects, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Convolve(DoubleMatrix matrix)
		{
			using INativeInstance nativeInstance = DoubleMatrix.CreateInstance(matrix);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Convolve(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_Convolve(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void CopyPixels(IMagickImage image, MagickRectangle geometry, OffsetInfo offset, Channels channels)
		{
			using INativeInstance nativeInstance = MagickRectangle.CreateInstance(geometry);
			using INativeInstance nativeInstance2 = OffsetInfo.CreateInstance(offset);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_CopyPixels(base.Instance, image.GetInstance(), nativeInstance.Instance, nativeInstance2.Instance, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_CopyPixels(base.Instance, image.GetInstance(), nativeInstance.Instance, nativeInstance2.Instance, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public void Crop(MagickRectangle geometry)
		{
			using INativeInstance nativeInstance = MagickRectangle.CreateInstance(geometry);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Crop(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_Crop(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public IntPtr CropToTiles(string geometry)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(geometry);
			IntPtr exception = IntPtr.Zero;
			IntPtr result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_CropToTiles(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_CropToTiles(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception);
			return result;
		}

		public void CycleColormap(int amount)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_CycleColormap(base.Instance, (IntPtr)amount, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_CycleColormap(base.Instance, (IntPtr)amount, out exception);
			}
			CheckException(exception);
		}

		public void Decipher(string passphrase)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(passphrase);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Decipher(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Decipher(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void Deskew(double threshold)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Deskew(base.Instance, threshold, out exception) : NativeMethods.X64.MagickImage_Deskew(base.Instance, threshold, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Despeckle()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Despeckle(base.Instance, out exception) : NativeMethods.X64.MagickImage_Despeckle(base.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public ColorType DetermineColorType()
		{
			IntPtr exception = IntPtr.Zero;
			UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_DetermineColorType(base.Instance, out exception) : NativeMethods.X64.MagickImage_DetermineColorType(base.Instance, out exception));
			CheckException(exception);
			return (ColorType)(uint)uIntPtr;
		}

		public void Distort(DistortMethod method, bool bestfit, double[] arguments, int length)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Distort(base.Instance, (UIntPtr)(ulong)method, bestfit, arguments, (UIntPtr)(ulong)length, out exception) : NativeMethods.X64.MagickImage_Distort(base.Instance, (UIntPtr)(ulong)method, bestfit, arguments, (UIntPtr)(ulong)length, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Edge(double radius)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Edge(base.Instance, radius, out exception) : NativeMethods.X64.MagickImage_Edge(base.Instance, radius, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Emboss(double radius, double sigma)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Emboss(base.Instance, radius, sigma, out exception) : NativeMethods.X64.MagickImage_Emboss(base.Instance, radius, sigma, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Encipher(string passphrase)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(passphrase);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Encipher(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Encipher(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void Enhance()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Enhance(base.Instance, out exception) : NativeMethods.X64.MagickImage_Enhance(base.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Equalize()
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Equalize(base.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Equalize(base.Instance, out exception);
			}
			CheckException(exception);
		}

		public bool Equals(IMagickImage image)
		{
			IntPtr exception = IntPtr.Zero;
			bool result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Equals(base.Instance, image.GetInstance(), out exception) : NativeMethods.X64.MagickImage_Equals(base.Instance, image.GetInstance(), out exception));
			CheckException(exception);
			return result;
		}

		public void EvaluateFunction(Channels channels, EvaluateFunction evaluateFunction, double[] values, int length)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_EvaluateFunction(base.Instance, (UIntPtr)(ulong)channels, (UIntPtr)(ulong)evaluateFunction, values, (UIntPtr)(ulong)length, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_EvaluateFunction(base.Instance, (UIntPtr)(ulong)channels, (UIntPtr)(ulong)evaluateFunction, values, (UIntPtr)(ulong)length, out exception);
			}
			CheckException(exception);
		}

		public void EvaluateGeometry(Channels channels, MagickRectangle geometry, EvaluateOperator evaluateOperator, double value)
		{
			using INativeInstance nativeInstance = MagickRectangle.CreateInstance(geometry);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_EvaluateGeometry(base.Instance, (UIntPtr)(ulong)channels, nativeInstance.Instance, (UIntPtr)(ulong)evaluateOperator, value, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_EvaluateGeometry(base.Instance, (UIntPtr)(ulong)channels, nativeInstance.Instance, (UIntPtr)(ulong)evaluateOperator, value, out exception);
			}
			CheckException(exception);
		}

		public void EvaluateOperator(Channels channels, EvaluateOperator evaluateOperator, double value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_EvaluateOperator(base.Instance, (UIntPtr)(ulong)channels, (UIntPtr)(ulong)evaluateOperator, value, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_EvaluateOperator(base.Instance, (UIntPtr)(ulong)channels, (UIntPtr)(ulong)evaluateOperator, value, out exception);
			}
			CheckException(exception);
		}

		public void Extent(string geometry)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(geometry);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Extent(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_Extent(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void ExtentGravity(string geometry, Gravity gravity)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(geometry);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ExtentGravity(base.Instance, nativeInstance.Instance, (UIntPtr)(ulong)gravity, out exception) : NativeMethods.X64.MagickImage_ExtentGravity(base.Instance, nativeInstance.Instance, (UIntPtr)(ulong)gravity, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Flip()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Flip(base.Instance, out exception) : NativeMethods.X64.MagickImage_Flip(base.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void FloodFill(DrawingSettings settings, int x, int y, MagickColor target, bool invert)
		{
			using INativeInstance nativeInstance = DrawingSettings.CreateInstance(settings);
			using INativeInstance nativeInstance2 = MagickColor.CreateInstance(target);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_FloodFill(base.Instance, nativeInstance.Instance, (IntPtr)x, (IntPtr)y, nativeInstance2.Instance, invert, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_FloodFill(base.Instance, nativeInstance.Instance, (IntPtr)x, (IntPtr)y, nativeInstance2.Instance, invert, out exception);
			}
			CheckException(exception);
		}

		public void Flop()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Flop(base.Instance, out exception) : NativeMethods.X64.MagickImage_Flop(base.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public IntPtr FontTypeMetrics(DrawingSettings settings, bool ignoreNewLines)
		{
			using INativeInstance nativeInstance = DrawingSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_FontTypeMetrics(base.Instance, nativeInstance.Instance, ignoreNewLines, out exception) : NativeMethods.X64.MagickImage_FontTypeMetrics(base.Instance, nativeInstance.Instance, ignoreNewLines, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					TypeMetric.Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public string FormatExpression(MagickSettings settings, string expression)
		{
			using INativeInstance nativeInstance = MagickSettings.CreateInstance(settings);
			using INativeInstance nativeInstance2 = UTF8Marshaler.CreateInstance(expression);
			IntPtr exception = IntPtr.Zero;
			IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_FormatExpression(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, out exception) : NativeMethods.X64.MagickImage_FormatExpression(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, out exception));
			CheckException(exception);
			return UTF8Marshaler.NativeToManagedAndRelinquish(nativeData);
		}

		public void Frame(MagickRectangle geometry)
		{
			using INativeInstance nativeInstance = MagickRectangle.CreateInstance(geometry);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Frame(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_Frame(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Fx(string expression, Channels channels)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(expression);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Fx(base.Instance, nativeInstance.Instance, (UIntPtr)(ulong)channels, out exception) : NativeMethods.X64.MagickImage_Fx(base.Instance, nativeInstance.Instance, (UIntPtr)(ulong)channels, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void GammaCorrect(double gamma, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_GammaCorrect(base.Instance, gamma, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_GammaCorrect(base.Instance, gamma, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public void GaussianBlur(double radius, double sigma, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_GaussianBlur(base.Instance, radius, sigma, (UIntPtr)(ulong)channels, out exception) : NativeMethods.X64.MagickImage_GaussianBlur(base.Instance, radius, sigma, (UIntPtr)(ulong)channels, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public string GetArtifact(string name)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(name);
			if (NativeLibrary.Is64Bit)
			{
				return UTF8Marshaler.NativeToManaged(NativeMethods.X64.MagickImage_GetArtifact(base.Instance, nativeInstance.Instance));
			}
			return UTF8Marshaler.NativeToManaged(NativeMethods.X86.MagickImage_GetArtifact(base.Instance, nativeInstance.Instance));
		}

		public string GetAttribute(string name)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(name);
			IntPtr exception = IntPtr.Zero;
			IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_GetAttribute(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_GetAttribute(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception);
			return UTF8Marshaler.NativeToManaged(nativeData);
		}

		public int GetBitDepth(Channels channels)
		{
			if (NativeLibrary.Is64Bit)
			{
				return (int)(uint)NativeMethods.X64.MagickImage_GetBitDepth(base.Instance, (UIntPtr)(ulong)channels);
			}
			return (int)(uint)NativeMethods.X86.MagickImage_GetBitDepth(base.Instance, (UIntPtr)(ulong)channels);
		}

		public MagickColor GetColormap(int index)
		{
			IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_GetColormap(base.Instance, (UIntPtr)(ulong)index) : NativeMethods.X64.MagickImage_GetColormap(base.Instance, (UIntPtr)(ulong)index));
			return MagickColor.CreateInstance(instance);
		}

		public static IntPtr GetNext(IntPtr image)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.MagickImage_GetNext(image);
			}
			return NativeMethods.X86.MagickImage_GetNext(image);
		}

		public string GetNextArtifactName()
		{
			if (NativeLibrary.Is64Bit)
			{
				return UTF8Marshaler.NativeToManaged(NativeMethods.X64.MagickImage_GetNextArtifactName(base.Instance));
			}
			return UTF8Marshaler.NativeToManaged(NativeMethods.X86.MagickImage_GetNextArtifactName(base.Instance));
		}

		public string GetNextAttributeName()
		{
			if (NativeLibrary.Is64Bit)
			{
				return UTF8Marshaler.NativeToManaged(NativeMethods.X64.MagickImage_GetNextAttributeName(base.Instance));
			}
			return UTF8Marshaler.NativeToManaged(NativeMethods.X86.MagickImage_GetNextAttributeName(base.Instance));
		}

		public string GetNextProfileName()
		{
			if (NativeLibrary.Is64Bit)
			{
				return UTF8Marshaler.NativeToManaged(NativeMethods.X64.MagickImage_GetNextProfileName(base.Instance));
			}
			return UTF8Marshaler.NativeToManaged(NativeMethods.X86.MagickImage_GetNextProfileName(base.Instance));
		}

		public StringInfo GetProfile(string name)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(name);
			IntPtr exception = IntPtr.Zero;
			IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_GetProfile(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_GetProfile(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception);
			return StringInfo.CreateInstance(instance);
		}

		public void Grayscale(PixelIntensityMethod method)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Grayscale(base.Instance, (UIntPtr)(ulong)method, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Grayscale(base.Instance, (UIntPtr)(ulong)method, out exception);
			}
			CheckException(exception);
		}

		public void HaldClut(IMagickImage image)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_HaldClut(base.Instance, image.GetInstance(), out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_HaldClut(base.Instance, image.GetInstance(), out exception);
			}
			CheckException(exception);
		}

		public bool HasChannel(PixelChannel channel)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.MagickImage_HasChannel(base.Instance, (UIntPtr)(ulong)channel);
			}
			return NativeMethods.X86.MagickImage_HasChannel(base.Instance, (UIntPtr)(ulong)channel);
		}

		public bool HasProfile(string name)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(name);
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.MagickImage_HasProfile(base.Instance, nativeInstance.Instance);
			}
			return NativeMethods.X86.MagickImage_HasProfile(base.Instance, nativeInstance.Instance);
		}

		public IntPtr Histogram(out UIntPtr length)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Histogram(base.Instance, out length, out exception) : NativeMethods.X64.MagickImage_Histogram(base.Instance, out length, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					MagickColorCollection.DisposeList(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public void HoughLine(int width, int height, int threshold)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_HoughLine(base.Instance, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, (UIntPtr)(ulong)threshold, out exception) : NativeMethods.X64.MagickImage_HoughLine(base.Instance, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, (UIntPtr)(ulong)threshold, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Implode(double amount, PixelInterpolateMethod method)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Implode(base.Instance, amount, (UIntPtr)(ulong)method, out exception) : NativeMethods.X64.MagickImage_Implode(base.Instance, amount, (UIntPtr)(ulong)method, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Kuwahara(double radius, double sigma)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Kuwahara(base.Instance, radius, sigma, out exception) : NativeMethods.X64.MagickImage_Kuwahara(base.Instance, radius, sigma, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Level(double blackPoint, double whitePoint, double gamma, Channels channels)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Level(base.Instance, blackPoint, whitePoint, gamma, (UIntPtr)(ulong)channels);
			}
			else
			{
				NativeMethods.X86.MagickImage_Level(base.Instance, blackPoint, whitePoint, gamma, (UIntPtr)(ulong)channels);
			}
		}

		public void LevelColors(MagickColor blackColor, MagickColor whiteColor, Channels channels, bool invert)
		{
			using INativeInstance nativeInstance = MagickColor.CreateInstance(blackColor);
			using INativeInstance nativeInstance2 = MagickColor.CreateInstance(whiteColor);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_LevelColors(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, (UIntPtr)(ulong)channels, invert, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_LevelColors(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, (UIntPtr)(ulong)channels, invert, out exception);
			}
			CheckException(exception);
		}

		public void Levelize(double blackPoint, double whitePoint, double gamma, Channels channels)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Levelize(base.Instance, blackPoint, whitePoint, gamma, (UIntPtr)(ulong)channels);
			}
			else
			{
				NativeMethods.X86.MagickImage_Levelize(base.Instance, blackPoint, whitePoint, gamma, (UIntPtr)(ulong)channels);
			}
		}

		public void LinearStretch(double blackPoint, double whitePoint)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_LinearStretch(base.Instance, blackPoint, whitePoint, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_LinearStretch(base.Instance, blackPoint, whitePoint, out exception);
			}
			CheckException(exception);
		}

		public void LiquidRescale(string geometry)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(geometry);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_LiquidRescale(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_LiquidRescale(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void LocalContrast(double radius, double strength)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_LocalContrast(base.Instance, radius, strength, out exception) : NativeMethods.X64.MagickImage_LocalContrast(base.Instance, radius, strength, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Magnify()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Magnify(base.Instance, out exception) : NativeMethods.X64.MagickImage_Magnify(base.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public bool Map(IMagickImage image, QuantizeSettings settings)
		{
			using INativeInstance nativeInstance = QuantizeSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			bool result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Map(base.Instance, image.GetInstance(), nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_Map(base.Instance, image.GetInstance(), nativeInstance.Instance, out exception));
			CheckException(exception);
			return result;
		}

		public void MeanShift(int width, int height, double colorDistance)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_MeanShift(base.Instance, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, colorDistance, out exception) : NativeMethods.X64.MagickImage_MeanShift(base.Instance, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, colorDistance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Minify()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Minify(base.Instance, out exception) : NativeMethods.X64.MagickImage_Minify(base.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public IntPtr Moments()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Moments(base.Instance, out exception) : NativeMethods.X64.MagickImage_Moments(base.Instance, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					ImageMagick.Moments.DisposeList(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public void Modulate(string modulate)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(modulate);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Modulate(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Modulate(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void Morphology(MorphologyMethod method, string kernel, Channels channels, int iterations)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(kernel);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Morphology(base.Instance, (UIntPtr)(ulong)method, nativeInstance.Instance, (UIntPtr)(ulong)channels, (UIntPtr)(ulong)iterations, out exception) : NativeMethods.X64.MagickImage_Morphology(base.Instance, (UIntPtr)(ulong)method, nativeInstance.Instance, (UIntPtr)(ulong)channels, (UIntPtr)(ulong)iterations, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void MotionBlur(double radius, double sigma, double angle)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_MotionBlur(base.Instance, radius, sigma, angle, out exception) : NativeMethods.X64.MagickImage_MotionBlur(base.Instance, radius, sigma, angle, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Negate(bool onlyGrayscale, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Negate(base.Instance, onlyGrayscale, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Negate(base.Instance, onlyGrayscale, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public void Normalize()
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Normalize(base.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Normalize(base.Instance, out exception);
			}
			CheckException(exception);
		}

		public void OilPaint(double radius, double sigma)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_OilPaint(base.Instance, radius, sigma, out exception) : NativeMethods.X64.MagickImage_OilPaint(base.Instance, radius, sigma, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Opaque(MagickColor target, MagickColor fill, bool invert)
		{
			using INativeInstance nativeInstance = MagickColor.CreateInstance(target);
			using INativeInstance nativeInstance2 = MagickColor.CreateInstance(fill);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Opaque(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, invert, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Opaque(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, invert, out exception);
			}
			CheckException(exception);
		}

		public void OrderedDither(string thresholdMap, Channels channels)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(thresholdMap);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_OrderedDither(base.Instance, nativeInstance.Instance, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_OrderedDither(base.Instance, nativeInstance.Instance, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public void Perceptible(double epsilon, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Perceptible(base.Instance, epsilon, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Perceptible(base.Instance, epsilon, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public IntPtr PerceptualHash()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_PerceptualHash(base.Instance, out exception) : NativeMethods.X64.MagickImage_PerceptualHash(base.Instance, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					ImageMagick.PerceptualHash.DisposeList(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public void Polaroid(DrawingSettings settings, string caption, double angle, PixelInterpolateMethod method)
		{
			using INativeInstance nativeInstance = DrawingSettings.CreateInstance(settings);
			using INativeInstance nativeInstance2 = UTF8Marshaler.CreateInstance(caption);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Polaroid(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, angle, (UIntPtr)(ulong)method, out exception) : NativeMethods.X64.MagickImage_Polaroid(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, angle, (UIntPtr)(ulong)method, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Posterize(int levels, DitherMethod method, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Posterize(base.Instance, (UIntPtr)(ulong)levels, (UIntPtr)(ulong)method, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Posterize(base.Instance, (UIntPtr)(ulong)levels, (UIntPtr)(ulong)method, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public void Quantize(QuantizeSettings settings)
		{
			using INativeInstance nativeInstance = QuantizeSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Quantize(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Quantize(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void RaiseOrLower(int size, bool raise)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_RaiseOrLower(base.Instance, (UIntPtr)(ulong)size, raise, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_RaiseOrLower(base.Instance, (UIntPtr)(ulong)size, raise, out exception);
			}
			CheckException(exception);
		}

		public void RandomThreshold(double low, double high, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_RandomThreshold(base.Instance, low, high, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_RandomThreshold(base.Instance, low, high, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public void ReadBlob(MagickSettings settings, byte[] data, int length)
		{
			using INativeInstance nativeInstance = MagickSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ReadBlob(nativeInstance.Instance, data, (UIntPtr)(ulong)length, out exception) : NativeMethods.X64.MagickImage_ReadBlob(nativeInstance.Instance, data, (UIntPtr)(ulong)length, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void ReadFile(MagickSettings settings)
		{
			using INativeInstance nativeInstance = MagickSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ReadFile(nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_ReadFile(nativeInstance.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void ReadPixels(int width, int height, string map, StorageType storageType, byte[] data)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(map);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ReadPixels((UIntPtr)(ulong)width, (UIntPtr)(ulong)height, nativeInstance.Instance, (UIntPtr)(ulong)storageType, data, out exception) : NativeMethods.X64.MagickImage_ReadPixels((UIntPtr)(ulong)width, (UIntPtr)(ulong)height, nativeInstance.Instance, (UIntPtr)(ulong)storageType, data, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void ReadStream(MagickSettings settings, ReadWriteStreamDelegate reader, SeekStreamDelegate seeker, TellStreamDelegate teller)
		{
			using INativeInstance nativeInstance = MagickSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_ReadStream(nativeInstance.Instance, reader, seeker, teller, out exception) : NativeMethods.X64.MagickImage_ReadStream(nativeInstance.Instance, reader, seeker, teller, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void RegionMask(MagickRectangle region)
		{
			using INativeInstance nativeInstance = MagickRectangle.CreateInstance(region);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_RegionMask(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_RegionMask(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void RemoveArtifact(string name)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(name);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_RemoveArtifact(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MagickImage_RemoveArtifact(base.Instance, nativeInstance.Instance);
			}
		}

		public void RemoveAttribute(string name)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(name);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_RemoveAttribute(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MagickImage_RemoveAttribute(base.Instance, nativeInstance.Instance);
			}
		}

		public void RemoveProfile(string name)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(name);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_RemoveProfile(base.Instance, nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MagickImage_RemoveProfile(base.Instance, nativeInstance.Instance);
			}
		}

		public void ResetArtifactIterator()
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_ResetArtifactIterator(base.Instance);
			}
			else
			{
				NativeMethods.X86.MagickImage_ResetArtifactIterator(base.Instance);
			}
		}

		public void ResetAttributeIterator()
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_ResetAttributeIterator(base.Instance);
			}
			else
			{
				NativeMethods.X86.MagickImage_ResetAttributeIterator(base.Instance);
			}
		}

		public void ResetProfileIterator()
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_ResetProfileIterator(base.Instance);
			}
			else
			{
				NativeMethods.X86.MagickImage_ResetProfileIterator(base.Instance);
			}
		}

		public void Resample(double resolutionX, double resolutionY)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Resample(base.Instance, resolutionX, resolutionY, out exception) : NativeMethods.X64.MagickImage_Resample(base.Instance, resolutionX, resolutionY, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Resize(string geometry)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(geometry);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Resize(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_Resize(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Roll(int x, int y)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Roll(base.Instance, (IntPtr)x, (IntPtr)y, out exception) : NativeMethods.X64.MagickImage_Roll(base.Instance, (IntPtr)x, (IntPtr)y, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Rotate(double degrees)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Rotate(base.Instance, degrees, out exception) : NativeMethods.X64.MagickImage_Rotate(base.Instance, degrees, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void RotationalBlur(double angle, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_RotationalBlur(base.Instance, angle, (UIntPtr)(ulong)channels, out exception) : NativeMethods.X64.MagickImage_RotationalBlur(base.Instance, angle, (UIntPtr)(ulong)channels, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Sample(string geometry)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(geometry);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Sample(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_Sample(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Scale(string geometry)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(geometry);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Scale(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_Scale(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Segment(ColorSpace colorSpace, double clusterThreshold, double smoothingThreshold)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Segment(base.Instance, (UIntPtr)(ulong)colorSpace, clusterThreshold, smoothingThreshold, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Segment(base.Instance, (UIntPtr)(ulong)colorSpace, clusterThreshold, smoothingThreshold, out exception);
			}
			CheckException(exception);
		}

		public void SelectiveBlur(double radius, double sigma, double threshold, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_SelectiveBlur(base.Instance, radius, sigma, threshold, (UIntPtr)(ulong)channels, out exception) : NativeMethods.X64.MagickImage_SelectiveBlur(base.Instance, radius, sigma, threshold, (UIntPtr)(ulong)channels, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public IntPtr Separate(Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Separate(base.Instance, (UIntPtr)(ulong)channels, out exception) : NativeMethods.X64.MagickImage_Separate(base.Instance, (UIntPtr)(ulong)channels, out exception));
			CheckException(exception, result);
			return result;
		}

		public void SepiaTone(double threshold)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_SepiaTone(base.Instance, threshold, out exception) : NativeMethods.X64.MagickImage_SepiaTone(base.Instance, threshold, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void SetAlpha(AlphaOption value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_SetAlpha(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_SetAlpha(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			CheckException(exception);
		}

		public void SetArtifact(string name, string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(name);
			using INativeInstance nativeInstance2 = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_SetArtifact(base.Instance, nativeInstance.Instance, nativeInstance2.Instance);
			}
			else
			{
				NativeMethods.X86.MagickImage_SetArtifact(base.Instance, nativeInstance.Instance, nativeInstance2.Instance);
			}
		}

		public void SetAttribute(string name, string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(name);
			using INativeInstance nativeInstance2 = UTF8Marshaler.CreateInstance(value);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_SetAttribute(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_SetAttribute(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, out exception);
			}
			CheckException(exception);
		}

		public void SetBitDepth(Channels channels, int value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_SetBitDepth(base.Instance, (UIntPtr)(ulong)channels, (UIntPtr)(ulong)value);
			}
			else
			{
				NativeMethods.X86.MagickImage_SetBitDepth(base.Instance, (UIntPtr)(ulong)channels, (UIntPtr)(ulong)value);
			}
		}

		public void SetColormap(int index, MagickColor color)
		{
			using INativeInstance nativeInstance = MagickColor.CreateInstance(color);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_SetColormap(base.Instance, (UIntPtr)(ulong)index, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_SetColormap(base.Instance, (UIntPtr)(ulong)index, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public bool SetColorMetric(IMagickImage image)
		{
			IntPtr exception = IntPtr.Zero;
			bool result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_SetColorMetric(base.Instance, image.GetInstance(), out exception) : NativeMethods.X64.MagickImage_SetColorMetric(base.Instance, image.GetInstance(), out exception));
			CheckException(exception);
			return result;
		}

		public void SetNext(IntPtr image)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_SetNext(base.Instance, image);
			}
			else
			{
				NativeMethods.X86.MagickImage_SetNext(base.Instance, image);
			}
		}

		public void SetProgressDelegate(ProgressDelegate method)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_SetProgressDelegate(base.Instance, method);
			}
			else
			{
				NativeMethods.X86.MagickImage_SetProgressDelegate(base.Instance, method);
			}
		}

		public void Shade(double azimuth, double elevation, bool colorShading, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Shade(base.Instance, azimuth, elevation, colorShading, (UIntPtr)(ulong)channels, out exception) : NativeMethods.X64.MagickImage_Shade(base.Instance, azimuth, elevation, colorShading, (UIntPtr)(ulong)channels, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Shadow(int x, int y, double sigma, double alphaPercentage)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Shadow(base.Instance, (IntPtr)x, (IntPtr)y, sigma, alphaPercentage, out exception) : NativeMethods.X64.MagickImage_Shadow(base.Instance, (IntPtr)x, (IntPtr)y, sigma, alphaPercentage, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Sharpen(double radius, double sigma, Channels channel)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Sharpen(base.Instance, radius, sigma, (UIntPtr)(ulong)channel, out exception) : NativeMethods.X64.MagickImage_Sharpen(base.Instance, radius, sigma, (UIntPtr)(ulong)channel, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Shave(int leftRight, int topBottom)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Shave(base.Instance, (UIntPtr)(ulong)leftRight, (UIntPtr)(ulong)topBottom, out exception) : NativeMethods.X64.MagickImage_Shave(base.Instance, (UIntPtr)(ulong)leftRight, (UIntPtr)(ulong)topBottom, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Shear(double xAngle, double yAngle)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Shear(base.Instance, xAngle, yAngle, out exception) : NativeMethods.X64.MagickImage_Shear(base.Instance, xAngle, yAngle, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void SigmoidalContrast(bool sharpen, double contrast, double midpoint)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_SigmoidalContrast(base.Instance, sharpen, contrast, midpoint, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_SigmoidalContrast(base.Instance, sharpen, contrast, midpoint, out exception);
			}
			CheckException(exception);
		}

		public void SparseColor(Channels channel, SparseColorMethod method, double[] values, int length)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_SparseColor(base.Instance, (UIntPtr)(ulong)channel, (UIntPtr)(ulong)method, values, (UIntPtr)(ulong)length, out exception) : NativeMethods.X64.MagickImage_SparseColor(base.Instance, (UIntPtr)(ulong)channel, (UIntPtr)(ulong)method, values, (UIntPtr)(ulong)length, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Sketch(double radius, double sigma, double angle)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Sketch(base.Instance, radius, sigma, angle, out exception) : NativeMethods.X64.MagickImage_Sketch(base.Instance, radius, sigma, angle, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Solarize(double factor)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Solarize(base.Instance, factor, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Solarize(base.Instance, factor, out exception);
			}
			CheckException(exception);
		}

		public void Splice(MagickRectangle geometry)
		{
			using INativeInstance nativeInstance = MagickRectangle.CreateInstance(geometry);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Splice(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_Splice(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Spread(PixelInterpolateMethod method, double radius)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Spread(base.Instance, (UIntPtr)(ulong)method, radius, out exception) : NativeMethods.X64.MagickImage_Spread(base.Instance, (UIntPtr)(ulong)method, radius, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Statistic(StatisticType type, int width, int height)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Statistic(base.Instance, (UIntPtr)(ulong)type, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, out exception) : NativeMethods.X64.MagickImage_Statistic(base.Instance, (UIntPtr)(ulong)type, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public IntPtr Statistics()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Statistics(base.Instance, out exception) : NativeMethods.X64.MagickImage_Statistics(base.Instance, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					ImageMagick.Statistics.DisposeList(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public void Stegano(IMagickImage watermark)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Stegano(base.Instance, watermark.GetInstance(), out exception) : NativeMethods.X64.MagickImage_Stegano(base.Instance, watermark.GetInstance(), out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Stereo(IMagickImage rightImage)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Stereo(base.Instance, rightImage.GetInstance(), out exception) : NativeMethods.X64.MagickImage_Stereo(base.Instance, rightImage.GetInstance(), out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Strip()
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Strip(base.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Strip(base.Instance, out exception);
			}
			CheckException(exception);
		}

		public IntPtr SubImageSearch(IMagickImage reference, ErrorMetric metric, double similarityThreshold, out MagickRectangle offset, out double similarityMetric)
		{
			using INativeInstance nativeInstance = MagickRectangle.CreateInstance();
			IntPtr instance = nativeInstance.Instance;
			IntPtr exception = IntPtr.Zero;
			IntPtr result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_SubImageSearch(base.Instance, reference.GetInstance(), (UIntPtr)(ulong)metric, similarityThreshold, instance, out similarityMetric, out exception) : NativeMethods.X64.MagickImage_SubImageSearch(base.Instance, reference.GetInstance(), (UIntPtr)(ulong)metric, similarityThreshold, instance, out similarityMetric, out exception));
			offset = MagickRectangle.CreateInstance(nativeInstance);
			CheckException(exception, result);
			return result;
		}

		public void Swirl(PixelInterpolateMethod method, double degrees)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Swirl(base.Instance, (UIntPtr)(ulong)method, degrees, out exception) : NativeMethods.X64.MagickImage_Swirl(base.Instance, (UIntPtr)(ulong)method, degrees, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Texture(IMagickImage image)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Texture(base.Instance, image.GetInstance(), out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Texture(base.Instance, image.GetInstance(), out exception);
			}
			CheckException(exception);
		}

		public void Threshold(double threshold)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Threshold(base.Instance, threshold, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Threshold(base.Instance, threshold, out exception);
			}
			CheckException(exception);
		}

		public void Thumbnail(string geometry)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(geometry);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Thumbnail(base.Instance, nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImage_Thumbnail(base.Instance, nativeInstance.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Tint(string opacity, MagickColor tint)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(opacity);
			using INativeInstance nativeInstance2 = MagickColor.CreateInstance(tint);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Tint(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, out exception) : NativeMethods.X64.MagickImage_Tint(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Transparent(MagickColor color, bool invert)
		{
			using INativeInstance nativeInstance = MagickColor.CreateInstance(color);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_Transparent(base.Instance, nativeInstance.Instance, invert, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_Transparent(base.Instance, nativeInstance.Instance, invert, out exception);
			}
			CheckException(exception);
		}

		public void TransparentChroma(MagickColor colorLow, MagickColor colorHigh, bool invert)
		{
			using INativeInstance nativeInstance = MagickColor.CreateInstance(colorLow);
			using INativeInstance nativeInstance2 = MagickColor.CreateInstance(colorHigh);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_TransparentChroma(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, invert, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_TransparentChroma(base.Instance, nativeInstance.Instance, nativeInstance2.Instance, invert, out exception);
			}
			CheckException(exception);
		}

		public void Transpose()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Transpose(base.Instance, out exception) : NativeMethods.X64.MagickImage_Transpose(base.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Transverse()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Transverse(base.Instance, out exception) : NativeMethods.X64.MagickImage_Transverse(base.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Trim()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Trim(base.Instance, out exception) : NativeMethods.X64.MagickImage_Trim(base.Instance, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public IntPtr UniqueColors()
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_UniqueColors(base.Instance, out exception) : NativeMethods.X64.MagickImage_UniqueColors(base.Instance, out exception));
			CheckException(exception, result);
			return result;
		}

		public void UnsharpMask(double radius, double sigma, double amount, double threshold, Channels channels)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_UnsharpMask(base.Instance, radius, sigma, amount, threshold, (UIntPtr)(ulong)channels, out exception) : NativeMethods.X64.MagickImage_UnsharpMask(base.Instance, radius, sigma, amount, threshold, (UIntPtr)(ulong)channels, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Vignette(double radius, double sigma, int x, int y)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Vignette(base.Instance, radius, sigma, (IntPtr)x, (IntPtr)y, out exception) : NativeMethods.X64.MagickImage_Vignette(base.Instance, radius, sigma, (IntPtr)x, (IntPtr)y, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void Wave(PixelInterpolateMethod method, double amplitude, double length)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_Wave(base.Instance, (UIntPtr)(ulong)method, amplitude, length, out exception) : NativeMethods.X64.MagickImage_Wave(base.Instance, (UIntPtr)(ulong)method, amplitude, length, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void WaveletDenoise(double threshold, double softness)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImage_WaveletDenoise(base.Instance, threshold, softness, out exception) : NativeMethods.X64.MagickImage_WaveletDenoise(base.Instance, threshold, softness, out exception));
			CheckException(exception, intPtr);
			base.Instance = intPtr;
		}

		public void WhiteThreshold(string threshold, Channels channels)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(threshold);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_WhiteThreshold(base.Instance, nativeInstance.Instance, (UIntPtr)(ulong)channels, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_WhiteThreshold(base.Instance, nativeInstance.Instance, (UIntPtr)(ulong)channels, out exception);
			}
			CheckException(exception);
		}

		public void WriteFile(MagickSettings settings)
		{
			using INativeInstance nativeInstance = MagickSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_WriteFile(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_WriteFile(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void WriteStream(MagickSettings settings, ReadWriteStreamDelegate writer, SeekStreamDelegate seeker, TellStreamDelegate teller)
		{
			using INativeInstance nativeInstance = MagickSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImage_WriteStream(base.Instance, nativeInstance.Instance, writer, seeker, teller, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImage_WriteStream(base.Instance, nativeInstance.Instance, writer, seeker, teller, out exception);
			}
			CheckException(exception);
		}
	}

	private NativeMagickImage _nativeInstance;

	private ProgressDelegate _nativeProgress;

	private EventHandler<ProgressEventArgs> _progress;

	private EventHandler<WarningEventArgs> _warning;

	IntPtr INativeInstance.Instance => _nativeInstance.Instance;

	public int AnimationDelay
	{
		get
		{
			return _nativeInstance.AnimationDelay;
		}
		set
		{
			if (value >= 0)
			{
				_nativeInstance.AnimationDelay = value;
			}
		}
	}

	public int AnimationIterations
	{
		get
		{
			return _nativeInstance.AnimationIterations;
		}
		set
		{
			if (value >= 0)
			{
				_nativeInstance.AnimationIterations = value;
			}
		}
	}

	public IEnumerable<string> ArtifactNames
	{
		get
		{
			_nativeInstance.ResetArtifactIterator();
			for (string nextArtifactName = _nativeInstance.GetNextArtifactName(); nextArtifactName != null; nextArtifactName = _nativeInstance.GetNextArtifactName())
			{
				yield return nextArtifactName;
			}
		}
	}

	public IEnumerable<string> AttributeNames
	{
		get
		{
			_nativeInstance.ResetAttributeIterator();
			for (string nextAttributeName = _nativeInstance.GetNextAttributeName(); nextAttributeName != null; nextAttributeName = _nativeInstance.GetNextAttributeName())
			{
				yield return nextAttributeName;
			}
		}
	}

	public MagickColor BackgroundColor
	{
		get
		{
			return _nativeInstance.BackgroundColor;
		}
		set
		{
			_nativeInstance.BackgroundColor = value;
			Settings.BackgroundColor = value;
		}
	}

	public int BaseHeight => _nativeInstance.BaseHeight;

	public int BaseWidth => _nativeInstance.BaseWidth;

	public bool BlackPointCompensation
	{
		get
		{
			return _nativeInstance.BlackPointCompensation;
		}
		set
		{
			_nativeInstance.BlackPointCompensation = value;
		}
	}

	public MagickColor BorderColor
	{
		get
		{
			return _nativeInstance.BorderColor;
		}
		set
		{
			_nativeInstance.BorderColor = value;
		}
	}

	public MagickGeometry BoundingBox => MagickGeometry.FromRectangle(_nativeInstance.BoundingBox);

	public int ChannelCount => _nativeInstance.ChannelCount;

	public IEnumerable<PixelChannel> Channels
	{
		get
		{
			if (_nativeInstance.HasChannel(PixelChannel.Red))
			{
				yield return PixelChannel.Red;
			}
			if (_nativeInstance.HasChannel(PixelChannel.Green))
			{
				yield return PixelChannel.Green;
			}
			if (_nativeInstance.HasChannel(PixelChannel.Blue))
			{
				yield return PixelChannel.Blue;
			}
			if (_nativeInstance.HasChannel(PixelChannel.Black))
			{
				yield return PixelChannel.Black;
			}
			if (_nativeInstance.HasChannel(PixelChannel.Alpha))
			{
				yield return PixelChannel.Alpha;
			}
		}
	}

	public PrimaryInfo ChromaBluePrimary
	{
		get
		{
			return _nativeInstance.ChromaBluePrimary;
		}
		set
		{
			_nativeInstance.ChromaBluePrimary = value;
		}
	}

	public PrimaryInfo ChromaGreenPrimary
	{
		get
		{
			return _nativeInstance.ChromaGreenPrimary;
		}
		set
		{
			_nativeInstance.ChromaGreenPrimary = value;
		}
	}

	public PrimaryInfo ChromaRedPrimary
	{
		get
		{
			return _nativeInstance.ChromaRedPrimary;
		}
		set
		{
			_nativeInstance.ChromaRedPrimary = value;
		}
	}

	public PrimaryInfo ChromaWhitePoint
	{
		get
		{
			return _nativeInstance.ChromaWhitePoint;
		}
		set
		{
			_nativeInstance.ChromaWhitePoint = value;
		}
	}

	public ClassType ClassType
	{
		get
		{
			return _nativeInstance.ClassType;
		}
		set
		{
			_nativeInstance.ClassType = value;
		}
	}

	public Percentage ColorFuzz
	{
		get
		{
			return Percentage.FromQuantum(_nativeInstance.ColorFuzz);
		}
		set
		{
			double colorFuzz = value.ToQuantum();
			_nativeInstance.ColorFuzz = colorFuzz;
			Settings.ColorFuzz = colorFuzz;
		}
	}

	public int ColormapSize
	{
		get
		{
			return _nativeInstance.ColormapSize;
		}
		set
		{
			_nativeInstance.ColormapSize = value;
		}
	}

	public ColorSpace ColorSpace
	{
		get
		{
			return _nativeInstance.ColorSpace;
		}
		set
		{
			_nativeInstance.ColorSpace = value;
		}
	}

	public ColorType ColorType
	{
		get
		{
			if (Settings.ColorType != ColorType.Undefined)
			{
				return Settings.ColorType;
			}
			return _nativeInstance.ColorType;
		}
		set
		{
			_nativeInstance.ColorType = value;
			Settings.ColorType = value;
		}
	}

	public string Comment
	{
		get
		{
			return Settings.GetOption("Comment");
		}
		set
		{
			Settings.SetOption("Comment", value);
		}
	}

	public CompositeOperator Compose
	{
		get
		{
			return _nativeInstance.Compose;
		}
		set
		{
			_nativeInstance.Compose = value;
		}
	}

	public CompressionMethod CompressionMethod
	{
		get
		{
			return _nativeInstance.CompressionMethod;
		}
		set
		{
			_nativeInstance.CompressionMethod = value;
		}
	}

	public Density Density
	{
		get
		{
			return new Density(_nativeInstance.ResolutionX, _nativeInstance.ResolutionY, _nativeInstance.ResolutionUnits);
		}
		set
		{
			if (!(value == null))
			{
				_nativeInstance.ResolutionX = value.X;
				_nativeInstance.ResolutionY = value.Y;
				_nativeInstance.ResolutionUnits = value.Units;
			}
		}
	}

	public int Depth
	{
		get
		{
			return _nativeInstance.Depth;
		}
		set
		{
			_nativeInstance.Depth = value;
		}
	}

	public MagickGeometry EncodingGeometry => MagickGeometry.FromString(_nativeInstance.EncodingGeometry);

	public Endian Endian
	{
		get
		{
			return _nativeInstance.Endian;
		}
		set
		{
			_nativeInstance.Endian = value;
		}
	}

	public string FileName => _nativeInstance.FileName;

	public long FileSize => _nativeInstance.FileSize;

	public FilterType FilterType
	{
		get
		{
			return _nativeInstance.FilterType;
		}
		set
		{
			_nativeInstance.FilterType = value;
		}
	}

	public MagickFormat Format
	{
		get
		{
			return EnumHelper.Parse(_nativeInstance.Format, MagickFormat.Unknown);
		}
		set
		{
			_nativeInstance.Format = EnumHelper.GetName(value);
			Settings.Format = value;
		}
	}

	public MagickFormatInfo FormatInfo => MagickNET.GetFormatInformation(Format);

	public double Gamma => _nativeInstance.Gamma;

	public GifDisposeMethod GifDisposeMethod
	{
		get
		{
			return _nativeInstance.GifDisposeMethod;
		}
		set
		{
			_nativeInstance.GifDisposeMethod = value;
		}
	}

	public bool HasClippingPath => !string.IsNullOrEmpty(GetClippingPath());

	public bool HasAlpha
	{
		get
		{
			return _nativeInstance.HasAlpha;
		}
		set
		{
			if (_nativeInstance.HasAlpha != value)
			{
				if (value)
				{
					Alpha(AlphaOption.Opaque);
				}
				_nativeInstance.HasAlpha = value;
			}
		}
	}

	public int Height => _nativeInstance.Height;

	public Interlace Interlace
	{
		get
		{
			return _nativeInstance.Interlace;
		}
		set
		{
			_nativeInstance.Interlace = value;
			Settings.Interlace = value;
		}
	}

	public PixelInterpolateMethod Interpolate
	{
		get
		{
			return _nativeInstance.Interpolate;
		}
		set
		{
			_nativeInstance.Interpolate = value;
		}
	}

	public bool IsOpaque => _nativeInstance.IsOpaque;

	public string Label
	{
		get
		{
			return GetAttribute("Label");
		}
		set
		{
			if (value == null)
			{
				RemoveAttribute("Label");
			}
			else
			{
				SetAttribute("Label", value);
			}
		}
	}

	public MagickColor MatteColor
	{
		get
		{
			return _nativeInstance.MatteColor;
		}
		set
		{
			_nativeInstance.MatteColor = value;
		}
	}

	public OrientationType Orientation
	{
		get
		{
			return _nativeInstance.Orientation;
		}
		set
		{
			_nativeInstance.Orientation = value;
		}
	}

	public MagickGeometry Page
	{
		get
		{
			return MagickGeometry.FromRectangle(_nativeInstance.Page);
		}
		set
		{
			if (!(value == null))
			{
				_nativeInstance.Page = MagickRectangle.FromGeometry(value, this);
			}
		}
	}

	public IEnumerable<string> ProfileNames
	{
		get
		{
			_nativeInstance.ResetProfileIterator();
			for (string nextProfileName = _nativeInstance.GetNextProfileName(); nextProfileName != null; nextProfileName = _nativeInstance.GetNextProfileName())
			{
				yield return nextProfileName;
			}
		}
	}

	public int Quality
	{
		get
		{
			return _nativeInstance.Quality;
		}
		set
		{
			int num = ((value < 1) ? 1 : value);
			num = ((num > 100) ? 100 : num);
			_nativeInstance.Quality = num;
			Settings.Quality = num;
		}
	}

	public IMagickImage ReadMask
	{
		get
		{
			return _nativeInstance.ReadMask;
		}
		set
		{
			_nativeInstance.ReadMask = value;
		}
	}

	public RenderingIntent RenderingIntent
	{
		get
		{
			return _nativeInstance.RenderingIntent;
		}
		set
		{
			_nativeInstance.RenderingIntent = value;
		}
	}

	public MagickSettings Settings { get; private set; }

	public string Signature => _nativeInstance.Signature;

	public int TotalColors => _nativeInstance.TotalColors;

	public VirtualPixelMethod VirtualPixelMethod
	{
		get
		{
			return _nativeInstance.VirtualPixelMethod;
		}
		set
		{
			_nativeInstance.VirtualPixelMethod = value;
		}
	}

	public int Width => _nativeInstance.Width;

	public IMagickImage WriteMask
	{
		get
		{
			return _nativeInstance.WriteMask;
		}
		set
		{
			_nativeInstance.WriteMask = value;
		}
	}

	public event EventHandler<ProgressEventArgs> Progress
	{
		add
		{
			if (_progress == null)
			{
				_nativeProgress = OnProgress;
				_nativeInstance.SetProgressDelegate(_nativeProgress);
			}
			_progress = (EventHandler<ProgressEventArgs>)Delegate.Combine(_progress, value);
		}
		remove
		{
			_progress = (EventHandler<ProgressEventArgs>)Delegate.Remove(_progress, value);
			if (_progress == null)
			{
				_nativeInstance.SetProgressDelegate(null);
				_nativeProgress = null;
			}
		}
	}

	public event EventHandler<WarningEventArgs> Warning
	{
		add
		{
			_warning = (EventHandler<WarningEventArgs>)Delegate.Combine(_warning, value);
		}
		remove
		{
			_warning = (EventHandler<WarningEventArgs>)Delegate.Remove(_warning, value);
		}
	}

	public MagickImage(Bitmap bitmap)
		: this()
	{
		Read(bitmap);
	}

	public void Read(Bitmap bitmap)
	{
		Throw.IfNull("bitmap", bitmap);
		using MemoryStream memoryStream = new MemoryStream();
		if (IsSupportedImageFormat(bitmap.RawFormat))
		{
			bitmap.Save(memoryStream, bitmap.RawFormat);
		}
		else
		{
			bitmap.Save(memoryStream, ImageFormat.Bmp);
		}
		memoryStream.Position = 0L;
		Read(memoryStream);
	}

	public Bitmap ToBitmap()
	{
		if (ColorSpace == ColorSpace.CMYK)
		{
			ColorSpace = ColorSpace.sRGB;
		}
		string mapping = "BGR";
		System.Drawing.Imaging.PixelFormat format = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
		if (HasAlpha)
		{
			mapping = "BGRA";
			format = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
		}
		using PixelCollection pixelCollection = GetPixels();
		Bitmap bitmap = new Bitmap(Width, Height, format);
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, format);
		IntPtr destination = bitmapData.Scan0;
		for (int i = 0; i < Height; i++)
		{
			byte[] array = pixelCollection.ToByteArray(0, i, Width, 1, mapping);
			Marshal.Copy(array, 0, destination, array.Length);
			destination = new IntPtr(destination.ToInt64() + bitmapData.Stride);
		}
		bitmap.UnlockBits(bitmapData);
		return bitmap;
	}

	public Bitmap ToBitmap(ImageFormat imageFormat)
	{
		Format = MagickFormatInfo.GetFormat(imageFormat);
		MemoryStream memoryStream = new MemoryStream();
		Write(memoryStream);
		memoryStream.Position = 0L;
		return new Bitmap(memoryStream);
	}

	public BitmapSource ToBitmapSource()
	{
		string mapping = "RGB";
		System.Windows.Media.PixelFormat pixelFormat = PixelFormats.Rgb24;
		if (HasAlpha)
		{
			mapping = "BGRA";
			pixelFormat = PixelFormats.Bgra32;
		}
		if (ColorSpace == ColorSpace.CMYK)
		{
			mapping = "CMYK";
			pixelFormat = PixelFormats.Cmyk32;
		}
		int num = pixelFormat.BitsPerPixel / 8;
		int stride = Width * num;
		using PixelCollection pixelCollection = GetPixels();
		byte[] pixels = pixelCollection.ToByteArray(mapping);
		return BitmapSource.Create(Width, Height, 96.0, 96.0, pixelFormat, null, pixels, stride);
	}

	private static bool IsSupportedImageFormat(ImageFormat format)
	{
		if (!format.Guid.Equals(ImageFormat.Bmp.Guid) && !format.Guid.Equals(ImageFormat.Gif.Guid) && !format.Guid.Equals(ImageFormat.Icon.Guid) && !format.Guid.Equals(ImageFormat.Jpeg.Guid) && !format.Guid.Equals(ImageFormat.Png.Guid))
		{
			return format.Guid.Equals(ImageFormat.Tiff.Guid);
		}
		return true;
	}

	public MagickImage()
	{
		SetSettings(new MagickSettings());
		SetInstance(new NativeMagickImage(Settings));
	}

	public MagickImage(byte[] data)
		: this()
	{
		Read(data);
	}

	public MagickImage(byte[] data, MagickReadSettings readSettings)
		: this()
	{
		Read(data, readSettings);
	}

	public MagickImage(FileInfo file)
		: this()
	{
		Read(file);
	}

	public MagickImage(FileInfo file, MagickReadSettings readSettings)
		: this()
	{
		Read(file, readSettings);
	}

	public MagickImage(MagickColor color, int width, int height)
		: this()
	{
		Read(color, width, height);
		BackgroundColor = color;
	}

	public MagickImage(IMagickImage image)
	{
		Throw.IfNull("image", image);
		MagickImage magickImage = image as MagickImage;
		if (magickImage == null)
		{
			throw new NotSupportedException();
		}
		SetSettings(magickImage.Settings.Clone());
		SetInstance(new NativeMagickImage(magickImage._nativeInstance.Clone()));
	}

	public MagickImage(Stream stream)
		: this()
	{
		Read(stream);
	}

	public MagickImage(Stream stream, MagickReadSettings readSettings)
		: this()
	{
		Read(stream, readSettings);
	}

	public MagickImage(string fileName)
		: this()
	{
		Read(fileName);
	}

	public MagickImage(string fileName, int width, int height)
		: this()
	{
		Read(fileName, width, height);
	}

	public MagickImage(string fileName, MagickReadSettings readSettings)
		: this()
	{
		Read(fileName, readSettings);
	}

	private MagickImage(NativeMagickImage instance, MagickSettings settings)
	{
		SetSettings(settings);
		SetInstance(instance);
	}

	~MagickImage()
	{
		Dispose(disposing: false);
	}

	public static explicit operator byte[](MagickImage image)
	{
		Throw.IfNull("image", image);
		return image.ToByteArray();
	}

	public static bool operator ==(MagickImage left, MagickImage right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(MagickImage left, MagickImage right)
	{
		return !object.Equals(left, right);
	}

	public static bool operator >(MagickImage left, MagickImage right)
	{
		if ((object)left == null)
		{
			return (object)right == null;
		}
		return left.CompareTo(right) == 1;
	}

	public static bool operator <(MagickImage left, MagickImage right)
	{
		if ((object)left == null)
		{
			return (object)right != null;
		}
		return left.CompareTo(right) == -1;
	}

	public static bool operator >=(MagickImage left, MagickImage right)
	{
		if ((object)left == null)
		{
			return (object)right == null;
		}
		return left.CompareTo(right) >= 0;
	}

	public static bool operator <=(MagickImage left, MagickImage right)
	{
		if ((object)left == null)
		{
			return (object)right != null;
		}
		return left.CompareTo(right) <= 0;
	}

	public static IMagickImage FromBase64(string value)
	{
		return new MagickImage(Convert.FromBase64String(value));
	}

	public void AdaptiveBlur()
	{
		AdaptiveBlur(0.0, 1.0);
	}

	public void AdaptiveBlur(double radius)
	{
		AdaptiveBlur(radius, 1.0);
	}

	public void AdaptiveBlur(double radius, double sigma)
	{
		_nativeInstance.AdaptiveBlur(radius, sigma);
	}

	public void AdaptiveResize(int width, int height)
	{
		_nativeInstance.AdaptiveResize(width, height);
	}

	public void AdaptiveResize(MagickGeometry geometry)
	{
		Throw.IfNull("geometry", geometry);
		AdaptiveResize(geometry.Width, geometry.Height);
	}

	public void AdaptiveSharpen()
	{
		AdaptiveSharpen(0.0, 1.0);
	}

	public void AdaptiveSharpen(Channels channels)
	{
		AdaptiveSharpen(0.0, 1.0, channels);
	}

	public void AdaptiveSharpen(double radius, double sigma)
	{
		AdaptiveSharpen(radius, sigma, ImageMagick.Channels.All);
	}

	public void AdaptiveSharpen(double radius, double sigma, Channels channels)
	{
		_nativeInstance.AdaptiveSharpen(radius, sigma, channels);
	}

	public void AdaptiveThreshold(int width, int height)
	{
		AdaptiveThreshold(width, height, 0.0);
	}

	public void AdaptiveThreshold(int width, int height, double bias)
	{
		_nativeInstance.AdaptiveThreshold(width, height, bias);
	}

	public void AdaptiveThreshold(int width, int height, Percentage biasPercentage)
	{
		AdaptiveThreshold(width, height, biasPercentage.ToQuantum());
	}

	public void AddNoise(NoiseType noiseType)
	{
		AddNoise(noiseType, ImageMagick.Channels.Composite);
	}

	public void AddNoise(NoiseType noiseType, Channels channels)
	{
		AddNoise(noiseType, 1.0, channels);
	}

	public void AddNoise(NoiseType noiseType, double attenuate)
	{
		AddNoise(noiseType, attenuate, ImageMagick.Channels.Composite);
	}

	public void AddNoise(NoiseType noiseType, double attenuate, Channels channels)
	{
		_nativeInstance.AddNoise(noiseType, attenuate, channels);
	}

	public void AddProfile(ImageProfile profile)
	{
		AddProfile(profile, overwriteExisting: true);
	}

	public void AddProfile(ImageProfile profile, bool overwriteExisting)
	{
		Throw.IfNull("profile", profile);
		if (overwriteExisting || !_nativeInstance.HasProfile(profile.Name))
		{
			byte[] array = profile.ToByteArray();
			if (array != null && array.Length != 0)
			{
				_nativeInstance.AddProfile(profile.Name, array, array.Length);
			}
		}
	}

	public void AffineTransform(DrawableAffine affineMatrix)
	{
		Throw.IfNull("affineMatrix", affineMatrix);
		_nativeInstance.AffineTransform(affineMatrix.ScaleX, affineMatrix.ScaleY, affineMatrix.ShearX, affineMatrix.ShearY, affineMatrix.TranslateX, affineMatrix.TranslateY);
	}

	public void Alpha(AlphaOption value)
	{
		_nativeInstance.SetAlpha(value);
	}

	public void Annotate(string text, MagickGeometry boundingArea)
	{
		Annotate(text, boundingArea, Gravity.Northwest, 0.0);
	}

	public void Annotate(string text, MagickGeometry boundingArea, Gravity gravity)
	{
		Annotate(text, boundingArea, gravity, 0.0);
	}

	public void Annotate(string text, MagickGeometry boundingArea, Gravity gravity, double angle)
	{
		Throw.IfNullOrEmpty("text", text);
		Throw.IfNull("boundingArea", boundingArea);
		_nativeInstance.Annotate(Settings.Drawing, text, MagickGeometry.ToString(boundingArea), gravity, angle);
	}

	public void Annotate(string text, Gravity gravity)
	{
		Throw.IfNullOrEmpty("text", text);
		_nativeInstance.AnnotateGravity(Settings.Drawing, text, gravity);
	}

	public void AutoGamma()
	{
		AutoGamma(ImageMagick.Channels.Composite);
	}

	public void AutoGamma(Channels channels)
	{
		_nativeInstance.AutoGamma(channels);
	}

	public void AutoLevel()
	{
		AutoLevel(ImageMagick.Channels.All);
	}

	public void AutoLevel(Channels channels)
	{
		_nativeInstance.AutoLevel(channels);
	}

	public void AutoOrient()
	{
		_nativeInstance.AutoOrient();
	}

	public void AutoThreshold(AutoThresholdMethod method)
	{
		_nativeInstance.AutoThreshold(method);
	}

	public void BlackThreshold(Percentage threshold)
	{
		BlackThreshold(threshold, ImageMagick.Channels.Composite);
	}

	public void BlackThreshold(Percentage threshold, Channels channels)
	{
		Throw.IfNegative("threshold", threshold);
		_nativeInstance.BlackThreshold(threshold.ToString(), channels);
	}

	public void BlueShift()
	{
		BlueShift(1.5);
	}

	public void BlueShift(double factor)
	{
		_nativeInstance.BlueShift(factor);
	}

	public int BitDepth()
	{
		return BitDepth(ImageMagick.Channels.Composite);
	}

	public int BitDepth(Channels channels)
	{
		return _nativeInstance.GetBitDepth(channels);
	}

	public void BitDepth(Channels channels, int value)
	{
		_nativeInstance.SetBitDepth(channels, value);
	}

	public void BitDepth(int value)
	{
		BitDepth(ImageMagick.Channels.Composite, value);
	}

	public void Blur()
	{
		Blur(0.0, 1.0);
	}

	public void Blur(Channels channels)
	{
		Blur(0.0, 1.0, channels);
	}

	public void Blur(double radius, double sigma)
	{
		Blur(radius, sigma, ImageMagick.Channels.Composite);
	}

	public void Blur(double radius, double sigma, Channels channels)
	{
		_nativeInstance.Blur(radius, sigma, channels);
	}

	public void Border(int size)
	{
		Border(size, size);
	}

	public void Border(int width, int height)
	{
		MagickRectangle value = new MagickRectangle(0, 0, width, height);
		_nativeInstance.Border(value);
	}

	public void BrightnessContrast(Percentage brightness, Percentage contrast)
	{
		BrightnessContrast(brightness, contrast, ImageMagick.Channels.Composite);
	}

	public void BrightnessContrast(Percentage brightness, Percentage contrast, Channels channels)
	{
		_nativeInstance.BrightnessContrast(brightness.ToDouble(), contrast.ToDouble(), channels);
	}

	public void CannyEdge()
	{
		CannyEdge(0.0, 1.0, new Percentage(10), new Percentage(30));
	}

	public void CannyEdge(double radius, double sigma, Percentage lower, Percentage upper)
	{
		_nativeInstance.CannyEdge(radius, sigma, lower.ToDouble() / 100.0, upper.ToDouble() / 100.0);
	}

	public void Charcoal()
	{
		Charcoal(0.0, 1.0);
	}

	public void Charcoal(double radius, double sigma)
	{
		_nativeInstance.Charcoal(radius, sigma);
	}

	public void Chop(int xOffset, int width, int yOffset, int height)
	{
		MagickGeometry geometry = new MagickGeometry(xOffset, yOffset, width, height);
		Chop(geometry);
	}

	public void Chop(MagickGeometry geometry)
	{
		Throw.IfNull("geometry", geometry);
		_nativeInstance.Chop(MagickRectangle.FromGeometry(geometry, this));
	}

	public void ChopHorizontal(int offset, int width)
	{
		MagickGeometry geometry = new MagickGeometry(offset, 0, width, 0);
		Chop(geometry);
	}

	public void ChopVertical(int offset, int height)
	{
		MagickGeometry geometry = new MagickGeometry(0, offset, 0, height);
		Chop(geometry);
	}

	public void Clamp()
	{
		_nativeInstance.Clamp();
	}

	public void Clamp(Channels channels)
	{
		_nativeInstance.ClampChannel(channels);
	}

	public void Clip()
	{
		_nativeInstance.Clip();
	}

	public void Clip(string pathName, bool inside)
	{
		Throw.IfNullOrEmpty("pathName", pathName);
		_nativeInstance.ClipPath(pathName, !inside);
	}

	public IMagickImage Clone()
	{
		return new MagickImage(this);
	}

	public IMagickImage Clone(MagickGeometry geometry)
	{
		Throw.IfNull("geometry", geometry);
		MagickImage magickImage = new MagickImage();
		magickImage.SetInstance(new NativeMagickImage(_nativeInstance.CloneArea(geometry.Width, geometry.Height)));
		magickImage.SetSettings(Settings);
		magickImage.CopyPixels(this, geometry, 0, 0);
		return magickImage;
	}

	public IMagickImage Clone(int width, int height)
	{
		return Clone(new MagickGeometry(width, height));
	}

	public IMagickImage Clone(int x, int y, int width, int height)
	{
		return Clone(new MagickGeometry(x, y, width, height));
	}

	public void Clut(IMagickImage image)
	{
		Clut(image, PixelInterpolateMethod.Undefined);
	}

	public void Clut(IMagickImage image, PixelInterpolateMethod method)
	{
		Clut(image, method, ImageMagick.Channels.Composite);
	}

	public void Clut(IMagickImage image, PixelInterpolateMethod method, Channels channels)
	{
		Throw.IfNull("image", image);
		_nativeInstance.Clut(image, method, channels);
	}

	public void ColorAlpha(MagickColor color)
	{
		Throw.IfNull("color", color);
		if (!HasAlpha)
		{
			return;
		}
		using MagickImage magickImage = new MagickImage(color, Width, Height);
		magickImage.Composite(this, 0, 0, CompositeOperator.SrcOver);
		SetInstance(new NativeMagickImage(magickImage._nativeInstance.Clone()));
	}

	public void ColorDecisionList(string fileName)
	{
		Throw.IfNullOrEmpty("fileName", fileName);
		string fileName2 = FileHelper.CheckForBaseDirectory(fileName);
		_nativeInstance.ColorDecisionList(fileName2);
	}

	public void Colorize(MagickColor color, Percentage alpha)
	{
		Throw.IfNegative("alpha", alpha);
		Colorize(color, alpha, alpha, alpha);
	}

	public void Colorize(MagickColor color, Percentage alphaRed, Percentage alphaGreen, Percentage alphaBlue)
	{
		Throw.IfNull("color", color);
		Throw.IfNegative("alphaRed", alphaRed);
		Throw.IfNegative("alphaGreen", alphaGreen);
		Throw.IfNegative("alphaBlue", alphaBlue);
		string blend = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}", new object[3]
		{
			alphaRed.ToInt32(),
			alphaGreen.ToInt32(),
			alphaBlue.ToInt32()
		});
		_nativeInstance.Colorize(color, blend);
	}

	public void ColorMatrix(MagickColorMatrix matrix)
	{
		Throw.IfNull("matrix", matrix);
		_nativeInstance.ColorMatrix(matrix);
	}

	public MagickErrorInfo Compare(IMagickImage image)
	{
		Throw.IfNull("image", image);
		if (_nativeInstance.SetColorMetric(image))
		{
			return new MagickErrorInfo();
		}
		return CreateErrorInfo(this);
	}

	public double Compare(IMagickImage image, ErrorMetric metric)
	{
		return Compare(image, metric, ImageMagick.Channels.Composite);
	}

	public double Compare(IMagickImage image, ErrorMetric metric, Channels channels)
	{
		Throw.IfNull("image", image);
		return _nativeInstance.CompareDistortion(image, metric, channels);
	}

	public double Compare(IMagickImage image, ErrorMetric metric, IMagickImage difference)
	{
		return Compare(image, metric, difference, ImageMagick.Channels.Composite);
	}

	public double Compare(IMagickImage image, ErrorMetric metric, IMagickImage difference, Channels channels)
	{
		Throw.IfNull("image", image);
		Throw.IfNull("difference", difference);
		MagickImage magickImage = difference as MagickImage;
		if (magickImage == null)
		{
			throw new NotSupportedException();
		}
		IntPtr intPtr = _nativeInstance.Compare(image, metric, channels, out var distortion);
		if (intPtr != IntPtr.Zero)
		{
			magickImage._nativeInstance.Instance = intPtr;
		}
		return distortion;
	}

	public int CompareTo(IMagickImage other)
	{
		if (other == null)
		{
			return 1;
		}
		int num = Width * Height;
		int num2 = other.Width * other.Height;
		if (num == num2)
		{
			return 0;
		}
		if (num >= num2)
		{
			return 1;
		}
		return -1;
	}

	public void Composite(IMagickImage image)
	{
		Composite(image, CompositeOperator.In);
	}

	public void Composite(IMagickImage image, CompositeOperator compose)
	{
		Composite(image, 0, 0, compose);
	}

	public void Composite(IMagickImage image, CompositeOperator compose, string args)
	{
		Composite(image, 0, 0, compose, args);
	}

	public void Composite(IMagickImage image, int x, int y)
	{
		Composite(image, x, y, CompositeOperator.In);
	}

	public void Composite(IMagickImage image, int x, int y, CompositeOperator compose)
	{
		Composite(image, x, y, compose, null);
	}

	public void Composite(IMagickImage image, int x, int y, CompositeOperator compose, string args)
	{
		Throw.IfNull("image", image);
		_nativeInstance.SetArtifact("compose:args", args);
		_nativeInstance.Composite(image, x, y, compose);
	}

	public void Composite(IMagickImage image, PointD offset)
	{
		Composite(image, offset, CompositeOperator.In);
	}

	public void Composite(IMagickImage image, PointD offset, CompositeOperator compose)
	{
		Composite(image, offset, compose, null);
	}

	public void Composite(IMagickImage image, PointD offset, CompositeOperator compose, string args)
	{
		Composite(image, (int)offset.X, (int)offset.Y, compose, args);
	}

	public void Composite(IMagickImage image, Gravity gravity)
	{
		Composite(image, gravity, CompositeOperator.In);
	}

	public void Composite(IMagickImage image, Gravity gravity, CompositeOperator compose)
	{
		_nativeInstance.SetArtifact("compose:args", null);
		_nativeInstance.CompositeGravity(image, gravity, compose);
	}

	public void Composite(IMagickImage image, Gravity gravity, CompositeOperator compose, string args)
	{
		Throw.IfNull("image", image);
		_nativeInstance.SetArtifact("compose:args", args);
		_nativeInstance.CompositeGravity(image, gravity, compose);
	}

	public IEnumerable<ConnectedComponent> ConnectedComponents(int connectivity)
	{
		ConnectedComponentsSettings connectedComponentsSettings = new ConnectedComponentsSettings();
		connectedComponentsSettings.Connectivity = connectivity;
		return ConnectedComponents(connectedComponentsSettings);
	}

	public IEnumerable<ConnectedComponent> ConnectedComponents(ConnectedComponentsSettings settings)
	{
		Throw.IfNull("settings", settings);
		if (settings.AreaThreshold.HasValue)
		{
			SetArtifact("connected-components:area-threshold", settings.AreaThreshold.Value.ToString(CultureInfo.InvariantCulture));
		}
		if (settings.MeanColor)
		{
			SetArtifact("connected-components:mean-color", "true");
		}
		IntPtr objects = IntPtr.Zero;
		try
		{
			_nativeInstance.ConnectedComponents(settings.Connectivity, out objects);
			return ConnectedComponent.Create(objects, ColormapSize);
		}
		finally
		{
			ConnectedComponent.DisposeList(objects);
		}
	}

	public void Contrast()
	{
		Contrast(enhance: true);
	}

	public void Contrast(bool enhance)
	{
		_nativeInstance.Contrast(enhance);
	}

	public void ContrastStretch(Percentage blackPoint)
	{
		ContrastStretch(blackPoint, blackPoint);
	}

	public void ContrastStretch(Percentage blackPoint, Percentage whitePoint)
	{
		ContrastStretch(blackPoint, whitePoint, ImageMagick.Channels.All);
	}

	public void ContrastStretch(Percentage blackPoint, Percentage whitePoint, Channels channels)
	{
		Throw.IfNegative("blackPoint", blackPoint);
		Throw.IfNegative("whitePoint", whitePoint);
		PointD pointD = CalculateContrastStretch(blackPoint, whitePoint);
		_nativeInstance.ContrastStretch(pointD.X, pointD.Y, channels);
	}

	public void Convolve(ConvolveMatrix convolveMatrix)
	{
		Throw.IfNull("convolveMatrix", convolveMatrix);
		_nativeInstance.Convolve(convolveMatrix);
	}

	public void CopyPixels(IMagickImage source)
	{
		CopyPixels(source, ImageMagick.Channels.All);
	}

	public void CopyPixels(IMagickImage source, Channels channels)
	{
		Throw.IfNull("source", source);
		MagickGeometry geometry = new MagickGeometry(0, 0, Math.Min(source.Width, Width), Math.Min(source.Height, Height));
		CopyPixels(source, geometry, 0, 0, channels);
	}

	public void CopyPixels(IMagickImage source, MagickGeometry geometry)
	{
		CopyPixels(source, geometry, ImageMagick.Channels.All);
	}

	public void CopyPixels(IMagickImage source, MagickGeometry geometry, Channels channels)
	{
		CopyPixels(source, geometry, 0, 0, channels);
	}

	public void CopyPixels(IMagickImage source, MagickGeometry geometry, PointD offset)
	{
		CopyPixels(source, geometry, offset, ImageMagick.Channels.All);
	}

	public void CopyPixels(IMagickImage source, MagickGeometry geometry, PointD offset, Channels channels)
	{
		CopyPixels(source, geometry, (int)offset.X, (int)offset.Y, channels);
	}

	public void CopyPixels(IMagickImage source, MagickGeometry geometry, int x, int y)
	{
		CopyPixels(source, geometry, x, y, ImageMagick.Channels.All);
	}

	public void CopyPixels(IMagickImage source, MagickGeometry geometry, int x, int y, Channels channels)
	{
		Throw.IfNull("source", source);
		Throw.IfNull("geometry", geometry);
		_nativeInstance.CopyPixels(source, MagickRectangle.FromGeometry(geometry, this), new OffsetInfo(x, y), channels);
	}

	public void Crop(int width, int height)
	{
		Crop(width, height, Gravity.Center);
	}

	public void Crop(int x, int y, int width, int height)
	{
		Crop(new MagickGeometry(x, y, width, height));
	}

	public void Crop(int width, int height, Gravity gravity)
	{
		int width2 = Width;
		int height2 = Height;
		int num = ((width > width2) ? width2 : width);
		int num2 = ((height > height2) ? height2 : height);
		if (num != width2 || num2 != height2)
		{
			MagickGeometry magickGeometry = new MagickGeometry(num, num2);
			switch (gravity)
			{
			case Gravity.North:
				magickGeometry.X = (width2 - num) / 2;
				break;
			case Gravity.Northeast:
				magickGeometry.X = width2 - num;
				break;
			case Gravity.East:
				magickGeometry.X = width2 - num;
				magickGeometry.Y = (height2 - num2) / 2;
				break;
			case Gravity.Southeast:
				magickGeometry.X = width2 - num;
				magickGeometry.Y = height2 - num2;
				break;
			case Gravity.South:
				magickGeometry.X = (width2 - num) / 2;
				magickGeometry.Y = height2 - num2;
				break;
			case Gravity.Southwest:
				magickGeometry.Y = height2 - num2;
				break;
			case Gravity.West:
				magickGeometry.Y = (height2 - num2) / 2;
				break;
			case Gravity.Center:
				magickGeometry.X = (width2 - num) / 2;
				magickGeometry.Y = (height2 - num2) / 2;
				break;
			}
			Crop(magickGeometry);
		}
	}

	public void Crop(MagickGeometry geometry)
	{
		Throw.IfNull("geometry", geometry);
		_nativeInstance.Crop(MagickRectangle.FromGeometry(geometry, this));
	}

	public void Crop(MagickGeometry geometry, Gravity gravity)
	{
		Throw.IfNull("geometry", geometry);
		Crop(geometry.Width, geometry.Height, gravity);
	}

	public IEnumerable<IMagickImage> CropToTiles(int width, int height)
	{
		return CropToTiles(new MagickGeometry(width, height));
	}

	public IEnumerable<IMagickImage> CropToTiles(MagickGeometry geometry)
	{
		Throw.IfNull("geometry", geometry);
		IntPtr images = _nativeInstance.CropToTiles(MagickGeometry.ToString(geometry));
		return CreateList(images);
	}

	public void CycleColormap(int amount)
	{
		_nativeInstance.CycleColormap(amount);
	}

	public void Decipher(string passphrase)
	{
		Throw.IfNullOrEmpty("passphrase", passphrase);
		_nativeInstance.Decipher(passphrase);
	}

	public void Deskew(Percentage threshold)
	{
		Throw.IfNegative("threshold", threshold);
		_nativeInstance.Deskew(threshold.ToQuantum());
	}

	public void Despeckle()
	{
		_nativeInstance.Despeckle();
	}

	public ColorType DetermineColorType()
	{
		return _nativeInstance.DetermineColorType();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Distort(DistortMethod method, params double[] arguments)
	{
		Distort(method, bestfit: false, arguments);
	}

	public void Distort(DistortMethod method, bool bestfit, params double[] arguments)
	{
		Throw.IfNullOrEmpty("arguments", arguments);
		_nativeInstance.Distort(method, bestfit, arguments, arguments.Length);
	}

	public void Draw(Drawables drawables)
	{
		Draw((IEnumerable<IDrawable>)drawables);
	}

	public void Draw(params IDrawable[] drawables)
	{
		Draw((IEnumerable<IDrawable>)drawables);
	}

	public void Draw(IEnumerable<IDrawable> drawables)
	{
		Throw.IfNull("drawables", drawables);
		using DrawingWand drawingWand = new DrawingWand(this);
		drawingWand.Draw(drawables);
	}

	public void Edge(double radius)
	{
		_nativeInstance.Edge(radius);
	}

	public void Emboss()
	{
		Emboss(0.0, 1.0);
	}

	public void Emboss(double radius, double sigma)
	{
		_nativeInstance.Emboss(radius, sigma);
	}

	public void Encipher(string passphrase)
	{
		Throw.IfNullOrEmpty("passphrase", passphrase);
		_nativeInstance.Encipher(passphrase);
	}

	public void Enhance()
	{
		_nativeInstance.Enhance();
	}

	public void Equalize()
	{
		_nativeInstance.Equalize();
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		return Equals(obj as MagickImage);
	}

	public bool Equals(IMagickImage other)
	{
		if (other == null)
		{
			return false;
		}
		if (Width != other.Width || Height != other.Height)
		{
			return false;
		}
		return _nativeInstance.Equals(other);
	}

	public void Evaluate(Channels channels, EvaluateFunction evaluateFunction, params double[] arguments)
	{
		Throw.IfNullOrEmpty("arguments", arguments);
		_nativeInstance.EvaluateFunction(channels, evaluateFunction, arguments, arguments.Length);
	}

	public void Evaluate(Channels channels, EvaluateOperator evaluateOperator, double value)
	{
		_nativeInstance.EvaluateOperator(channels, evaluateOperator, value);
	}

	public void Evaluate(Channels channels, EvaluateOperator evaluateOperator, Percentage percentage)
	{
		Evaluate(channels, evaluateOperator, percentage.ToQuantum());
	}

	public void Evaluate(Channels channels, MagickGeometry geometry, EvaluateOperator evaluateOperator, double value)
	{
		Throw.IfNull("geometry", geometry);
		Throw.IfTrue("geometry", geometry.IsPercentage, "Percentage is not supported.");
		_nativeInstance.EvaluateGeometry(channels, MagickRectangle.FromGeometry(geometry, this), evaluateOperator, value);
	}

	public void Evaluate(Channels channels, MagickGeometry geometry, EvaluateOperator evaluateOperator, Percentage percentage)
	{
		Evaluate(channels, geometry, evaluateOperator, percentage.ToQuantum());
	}

	public void Extent(int width, int height)
	{
		Extent(new MagickGeometry(width, height));
	}

	public void Extent(int x, int y, int width, int height)
	{
		Extent(new MagickGeometry(x, y, width, height));
	}

	public void Extent(int width, int height, MagickColor backgroundColor)
	{
		MagickGeometry geometry = new MagickGeometry(width, height);
		Extent(geometry, backgroundColor);
	}

	public void Extent(int width, int height, Gravity gravity)
	{
		MagickGeometry geometry = new MagickGeometry(width, height);
		Extent(geometry, gravity);
	}

	public void Extent(int width, int height, Gravity gravity, MagickColor backgroundColor)
	{
		MagickGeometry geometry = new MagickGeometry(width, height);
		Extent(geometry, gravity, backgroundColor);
	}

	public void Extent(MagickGeometry geometry)
	{
		Throw.IfNull("geometry", geometry);
		geometry.IgnoreAspectRatio = true;
		_nativeInstance.Extent(MagickGeometry.ToString(geometry));
	}

	public void Extent(MagickGeometry geometry, MagickColor backgroundColor)
	{
		Throw.IfNull("backgroundColor", backgroundColor);
		BackgroundColor = backgroundColor;
		Extent(geometry);
	}

	public void Extent(MagickGeometry geometry, Gravity gravity)
	{
		Throw.IfNull("geometry", geometry);
		geometry.IgnoreAspectRatio = true;
		_nativeInstance.ExtentGravity(MagickGeometry.ToString(geometry), gravity);
	}

	public void Extent(MagickGeometry geometry, Gravity gravity, MagickColor backgroundColor)
	{
		Throw.IfNull("backgroundColor", backgroundColor);
		BackgroundColor = backgroundColor;
		Extent(geometry, gravity);
	}

	public void Flip()
	{
		_nativeInstance.Flip();
	}

	public void FloodFill(byte alpha, int x, int y)
	{
		FloodFill(alpha, x, y, invert: false);
	}

	public void FloodFill(MagickColor color, int x, int y)
	{
		FloodFill(color, x, y, invert: false);
	}

	public void FloodFill(MagickColor color, int x, int y, MagickColor target)
	{
		FloodFill(color, x, y, target, invert: false);
	}

	public void FloodFill(MagickColor color, PointD coordinate)
	{
		FloodFill(color, (int)coordinate.X, (int)coordinate.Y, invert: false);
	}

	public void FloodFill(MagickColor color, PointD coordinate, MagickColor target)
	{
		FloodFill(color, (int)coordinate.X, (int)coordinate.Y, target, invert: false);
	}

	public void FloodFill(IMagickImage image, int x, int y)
	{
		FloodFill(image, x, y, invert: false);
	}

	public void FloodFill(IMagickImage image, int x, int y, MagickColor target)
	{
		FloodFill(image, x, y, target, invert: false);
	}

	public void FloodFill(IMagickImage image, PointD coordinate)
	{
		FloodFill(image, (int)coordinate.X, (int)coordinate.Y, invert: false);
	}

	public void FloodFill(IMagickImage image, PointD coordinate, MagickColor target)
	{
		FloodFill(image, (int)coordinate.X, (int)coordinate.Y, target, invert: false);
	}

	public void Flop()
	{
		_nativeInstance.Flop();
	}

	public TypeMetric FontTypeMetrics(string text)
	{
		return FontTypeMetrics(text, ignoreNewLines: false);
	}

	public TypeMetric FontTypeMetrics(string text, bool ignoreNewLines)
	{
		Throw.IfNullOrEmpty("text", text);
		DrawingSettings drawing = Settings.Drawing;
		drawing.Text = text;
		IntPtr instance = _nativeInstance.FontTypeMetrics(drawing, ignoreNewLines);
		drawing.Text = null;
		return TypeMetric.CreateInstance(instance);
	}

	public string FormatExpression(string expression)
	{
		Throw.IfNullOrEmpty("expression", expression);
		return _nativeInstance.FormatExpression(Settings, expression);
	}

	public void Frame()
	{
		Frame(new MagickGeometry(6, 6, 25, 25));
	}

	public void Frame(MagickGeometry geometry)
	{
		Throw.IfNull("geometry", geometry);
		_nativeInstance.Frame(MagickRectangle.FromGeometry(geometry, this));
	}

	public void Frame(int width, int height)
	{
		Frame(new MagickGeometry(6, 6, width, height));
	}

	public void Frame(int width, int height, int innerBevel, int outerBevel)
	{
		Frame(new MagickGeometry(innerBevel, outerBevel, width, height));
	}

	public void Fx(string expression)
	{
		Fx(expression, ImageMagick.Channels.Composite);
	}

	public void Fx(string expression, Channels channels)
	{
		Throw.IfNullOrEmpty("expression", expression);
		_nativeInstance.Fx(expression, channels);
	}

	public void GammaCorrect(double gamma)
	{
		GammaCorrect(gamma, ImageMagick.Channels.All);
	}

	public void GammaCorrect(double gamma, Channels channels)
	{
		_nativeInstance.GammaCorrect(gamma, channels);
	}

	public void GaussianBlur(double radius, double sigma)
	{
		GaussianBlur(radius, sigma, ImageMagick.Channels.Composite);
	}

	public void GaussianBlur(double radius, double sigma, Channels channels)
	{
		_nativeInstance.GaussianBlur(radius, sigma, channels);
	}

	public EightBimProfile Get8BimProfile()
	{
		StringInfo profile = _nativeInstance.GetProfile("8bim");
		if (profile == null || profile.Datum == null)
		{
			return null;
		}
		return new EightBimProfile(this, profile.Datum);
	}

	public string GetAttribute(string name)
	{
		Throw.IfNullOrEmpty("name", name);
		return _nativeInstance.GetAttribute(name);
	}

	public string GetClippingPath()
	{
		return GetClippingPath("#1");
	}

	public string GetClippingPath(string pathName)
	{
		return GetAttribute("8BIM:1999,2998:" + pathName);
	}

	public MagickColor GetColormap(int index)
	{
		return _nativeInstance.GetColormap(index);
	}

	public ColorProfile GetColorProfile()
	{
		ColorProfile colorProfile = GetColorProfile("icc");
		if (colorProfile != null)
		{
			return colorProfile;
		}
		return GetColorProfile("icm");
	}

	public string GetArtifact(string name)
	{
		Throw.IfNullOrEmpty("name", name);
		return _nativeInstance.GetArtifact(name);
	}

	public ExifProfile GetExifProfile()
	{
		StringInfo profile = _nativeInstance.GetProfile("exif");
		if (profile == null || profile.Datum == null)
		{
			return null;
		}
		return new ExifProfile(profile.Datum);
	}

	public override int GetHashCode()
	{
		return Width.GetHashCode() ^ Height.GetHashCode() ^ Signature.GetHashCode();
	}

	public IptcProfile GetIptcProfile()
	{
		StringInfo profile = _nativeInstance.GetProfile("iptc");
		if (profile == null || profile.Datum == null)
		{
			return null;
		}
		return new IptcProfile(profile.Datum);
	}

	public PixelCollection GetPixels()
	{
		if (Settings.Ping)
		{
			throw new InvalidOperationException("Image contains no pixel data.");
		}
		return new PixelCollection(this);
	}

	public ImageProfile GetProfile(string name)
	{
		Throw.IfNullOrEmpty("name", name);
		StringInfo profile = _nativeInstance.GetProfile(name);
		if (profile == null || profile.Datum == null)
		{
			return null;
		}
		return new ImageProfile(name, profile.Datum);
	}

	public XmpProfile GetXmpProfile()
	{
		StringInfo profile = _nativeInstance.GetProfile("xmp");
		if (profile == null || profile.Datum == null)
		{
			return null;
		}
		return new XmpProfile(profile.Datum);
	}

	public void Grayscale(PixelIntensityMethod method)
	{
		_nativeInstance.Grayscale(method);
	}

	public void HaldClut(IMagickImage image)
	{
		Throw.IfNull("image", image);
		_nativeInstance.HaldClut(image);
	}

	public Dictionary<MagickColor, int> Histogram()
	{
		IntPtr list = IntPtr.Zero;
		try
		{
			list = _nativeInstance.Histogram(out var length);
			return MagickColorCollection.ToDictionary(list, (int)(uint)length);
		}
		finally
		{
			MagickColorCollection.DisposeList(list);
		}
	}

	public void HoughLine()
	{
		HoughLine(0, 0, 40);
	}

	public void HoughLine(int width, int height, int threshold)
	{
		_nativeInstance.HoughLine(width, height, threshold);
	}

	public void Implode(double amount, PixelInterpolateMethod method)
	{
		_nativeInstance.Implode(amount, method);
	}

	public void InverseFloodFill(byte alpha, int x, int y)
	{
		FloodFill(alpha, x, y, invert: true);
	}

	public void InverseFloodFill(MagickColor color, int x, int y)
	{
		FloodFill(color, x, y, invert: true);
	}

	public void InverseFloodFill(MagickColor color, int x, int y, MagickColor target)
	{
		FloodFill(color, x, y, target, invert: true);
	}

	public void InverseFloodFill(MagickColor color, PointD coordinate)
	{
		FloodFill(color, (int)coordinate.X, (int)coordinate.Y, invert: true);
	}

	public void InverseFloodFill(MagickColor color, PointD coordinate, MagickColor target)
	{
		FloodFill(color, (int)coordinate.X, (int)coordinate.Y, target, invert: true);
	}

	public void InverseFloodFill(IMagickImage image, int x, int y)
	{
		FloodFill(image, x, y, invert: true);
	}

	public void InverseFloodFill(IMagickImage image, int x, int y, MagickColor target)
	{
		FloodFill(image, x, y, target, invert: true);
	}

	public void InverseFloodFill(IMagickImage image, PointD coordinate)
	{
		FloodFill(image, (int)coordinate.X, (int)coordinate.Y, invert: true);
	}

	public void InverseFloodFill(IMagickImage image, PointD coordinate, MagickColor target)
	{
		FloodFill(image, (int)coordinate.X, (int)coordinate.Y, target, invert: true);
	}

	public void InverseLevel(byte blackPoint, byte whitePoint)
	{
		InverseLevel(blackPoint, whitePoint, 1.0);
	}

	public void InverseLevel(Percentage blackPointPercentage, Percentage whitePointPercentage)
	{
		InverseLevel(blackPointPercentage.ToQuantumType(), whitePointPercentage.ToQuantumType());
	}

	public void InverseLevel(byte blackPoint, byte whitePoint, Channels channels)
	{
		InverseLevel(blackPoint, whitePoint, 1.0, channels);
	}

	public void InverseLevel(Percentage blackPointPercentage, Percentage whitePointPercentage, Channels channels)
	{
		InverseLevel(blackPointPercentage.ToQuantumType(), whitePointPercentage.ToQuantumType(), channels);
	}

	public void InverseLevel(byte blackPoint, byte whitePoint, double midpoint)
	{
		_nativeInstance.Levelize((int)blackPoint, (int)whitePoint, midpoint, ImageMagick.Channels.Composite);
	}

	public void InverseLevel(Percentage blackPointPercentage, Percentage whitePointPercentage, double midpoint)
	{
		InverseLevel(blackPointPercentage.ToQuantumType(), whitePointPercentage.ToQuantumType(), midpoint);
	}

	public void InverseLevel(byte blackPoint, byte whitePoint, double midpoint, Channels channels)
	{
		_nativeInstance.Levelize((int)blackPoint, (int)whitePoint, midpoint, channels);
	}

	public void InverseLevel(Percentage blackPointPercentage, Percentage whitePointPercentage, double midpoint, Channels channels)
	{
		InverseLevel(blackPointPercentage.ToQuantumType(), whitePointPercentage.ToQuantumType(), midpoint, channels);
	}

	public void InverseLevelColors(MagickColor blackColor, MagickColor whiteColor)
	{
		LevelColors(blackColor, whiteColor, invert: true);
	}

	public void InverseLevelColors(MagickColor blackColor, MagickColor whiteColor, Channels channels)
	{
		LevelColors(blackColor, whiteColor, channels, invert: true);
	}

	public void InverseOpaque(MagickColor target, MagickColor fill)
	{
		Opaque(target, fill, invert: true);
	}

	public void InverseTransparent(MagickColor color)
	{
		Throw.IfNull("color", color);
		_nativeInstance.Transparent(color, invert: true);
	}

	public void InverseTransparentChroma(MagickColor colorLow, MagickColor colorHigh)
	{
		Throw.IfNull("colorLow", colorLow);
		Throw.IfNull("colorHigh", colorHigh);
		_nativeInstance.TransparentChroma(colorLow, colorHigh, invert: true);
	}

	public void Kuwahara()
	{
		Kuwahara(0.0, 1.0);
	}

	public void Kuwahara(double radius, double sigma)
	{
		_nativeInstance.Kuwahara(radius, sigma);
	}

	public void Level(byte blackPoint, byte whitePoint)
	{
		Level(blackPoint, whitePoint, 1.0);
	}

	public void Level(Percentage blackPointPercentage, Percentage whitePointPercentage)
	{
		Level(blackPointPercentage.ToQuantumType(), whitePointPercentage.ToQuantumType());
	}

	public void Level(byte blackPoint, byte whitePoint, Channels channels)
	{
		Level(blackPoint, whitePoint, 1.0, channels);
	}

	public void Level(Percentage blackPointPercentage, Percentage whitePointPercentage, Channels channels)
	{
		Level(blackPointPercentage.ToQuantumType(), whitePointPercentage.ToQuantumType(), channels);
	}

	public void Level(byte blackPoint, byte whitePoint, double gamma)
	{
		Level(blackPoint, whitePoint, gamma, ImageMagick.Channels.Composite);
	}

	public void Level(Percentage blackPointPercentage, Percentage whitePointPercentage, double gamma)
	{
		Level(blackPointPercentage.ToQuantumType(), whitePointPercentage.ToQuantumType(), gamma);
	}

	public void Level(byte blackPoint, byte whitePoint, double gamma, Channels channels)
	{
		_nativeInstance.Level((int)blackPoint, (int)whitePoint, gamma, channels);
	}

	public void Level(Percentage blackPointPercentage, Percentage whitePointPercentage, double gamma, Channels channels)
	{
		Level(blackPointPercentage.ToQuantumType(), whitePointPercentage.ToQuantumType(), gamma, channels);
	}

	public void LevelColors(MagickColor blackColor, MagickColor whiteColor)
	{
		LevelColors(blackColor, whiteColor, invert: false);
	}

	public void LevelColors(MagickColor blackColor, MagickColor whiteColor, Channels channels)
	{
		LevelColors(blackColor, whiteColor, channels, invert: false);
	}

	public void LinearStretch(Percentage blackPoint, Percentage whitePoint)
	{
		Throw.IfNegative("blackPoint", blackPoint);
		Throw.IfNegative("whitePoint", whitePoint);
		_nativeInstance.LinearStretch(blackPoint.ToQuantum(), whitePoint.ToQuantum());
	}

	public void LiquidRescale(int width, int height)
	{
		MagickGeometry geometry = new MagickGeometry(width, height);
		LiquidRescale(geometry);
	}

	public void LiquidRescale(MagickGeometry geometry)
	{
		Throw.IfNull("geometry", geometry);
		_nativeInstance.LiquidRescale(MagickGeometry.ToString(geometry));
	}

	public void LiquidRescale(Percentage percentage)
	{
		LiquidRescale(percentage, percentage);
	}

	public void LiquidRescale(Percentage percentageWidth, Percentage percentageHeight)
	{
		Throw.IfNegative("percentageWidth", percentageWidth);
		Throw.IfNegative("percentageHeight", percentageHeight);
		MagickGeometry geometry = new MagickGeometry(percentageWidth, percentageHeight);
		LiquidRescale(geometry);
	}

	public void LocalContrast(double radius, Percentage strength)
	{
		_nativeInstance.LocalContrast(radius, strength.ToDouble());
	}

	public void Lower(int size)
	{
		_nativeInstance.RaiseOrLower(size, raise: false);
	}

	public void Magnify()
	{
		_nativeInstance.Magnify();
	}

	public MagickErrorInfo Map(IEnumerable<MagickColor> colors)
	{
		Throw.IfNull("colors", colors);
		return Map(colors, new QuantizeSettings());
	}

	public MagickErrorInfo Map(IEnumerable<MagickColor> colors, QuantizeSettings settings)
	{
		Throw.IfNull("colors", colors);
		List<MagickColor> list = new List<MagickColor>(colors);
		if (list.Count == 0)
		{
			throw new ArgumentException("Value cannot be empty.", "colors");
		}
		using IMagickImageCollection magickImageCollection = new MagickImageCollection();
		foreach (MagickColor item in list)
		{
			magickImageCollection.Add(new MagickImage(item, 1, 1));
		}
		using IMagickImage image = magickImageCollection.AppendHorizontally();
		return Map(image, settings);
	}

	public MagickErrorInfo Map(IMagickImage image)
	{
		return Map(image, new QuantizeSettings());
	}

	public MagickErrorInfo Map(IMagickImage image, QuantizeSettings settings)
	{
		Throw.IfNull("image", image);
		Throw.IfNull("settings", settings);
		if (_nativeInstance.Map(image, settings))
		{
			return new MagickErrorInfo();
		}
		return CreateErrorInfo(this);
	}

	public void MeanShift(int size)
	{
		MeanShift(size, size);
	}

	public void MeanShift(int size, Percentage colorDistance)
	{
		MeanShift(size, size, colorDistance);
	}

	public void MeanShift(int width, int height)
	{
		MeanShift(width, height, new Percentage(10));
	}

	public void MeanShift(int width, int height, Percentage colorDistance)
	{
		_nativeInstance.MeanShift(width, height, colorDistance.ToQuantum());
	}

	public void MedianFilter()
	{
		MedianFilter(0);
	}

	public void MedianFilter(int radius)
	{
		Statistic(StatisticType.Median, radius, radius);
	}

	public void Minify()
	{
		_nativeInstance.Minify();
	}

	public void Modulate(Percentage brightness)
	{
		Modulate(brightness, new Percentage(100), new Percentage(100));
	}

	public void Modulate(Percentage brightness, Percentage saturation)
	{
		Modulate(brightness, saturation, new Percentage(100));
	}

	public void Modulate(Percentage brightness, Percentage saturation, Percentage hue)
	{
		Throw.IfNegative("brightness", brightness);
		Throw.IfNegative("saturation", saturation);
		Throw.IfNegative("hue", hue);
		string modulate = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}", new object[3]
		{
			brightness.ToDouble(),
			saturation.ToDouble(),
			hue.ToDouble()
		});
		_nativeInstance.Modulate(modulate);
	}

	public void Morphology(MorphologyMethod method, Kernel kernel)
	{
		Morphology(method, kernel, string.Empty);
	}

	public void Morphology(MorphologyMethod method, Kernel kernel, Channels channels)
	{
		Morphology(method, kernel, string.Empty, channels);
	}

	public void Morphology(MorphologyMethod method, Kernel kernel, Channels channels, int iterations)
	{
		Morphology(method, kernel, string.Empty, channels, iterations);
	}

	public void Morphology(MorphologyMethod method, Kernel kernel, int iterations)
	{
		Morphology(method, kernel, string.Empty, ImageMagick.Channels.Composite, iterations);
	}

	public void Morphology(MorphologyMethod method, Kernel kernel, string arguments)
	{
		Morphology(method, kernel, arguments, ImageMagick.Channels.Composite);
	}

	public void Morphology(MorphologyMethod method, Kernel kernel, string arguments, Channels channels)
	{
		Morphology(method, kernel, arguments, channels, 1);
	}

	public void Morphology(MorphologyMethod method, Kernel kernel, string arguments, Channels channels, int iterations)
	{
		string userKernel = EnumHelper.GetName(kernel) + ":" + arguments;
		Morphology(method, userKernel, channels, iterations);
	}

	public void Morphology(MorphologyMethod method, Kernel kernel, string arguments, int iterations)
	{
		Morphology(method, kernel, arguments, ImageMagick.Channels.Composite, iterations);
	}

	public void Morphology(MorphologyMethod method, string userKernel)
	{
		Morphology(method, userKernel, ImageMagick.Channels.Composite);
	}

	public void Morphology(MorphologyMethod method, string userKernel, Channels channels)
	{
		Morphology(method, userKernel, channels, 1);
	}

	public void Morphology(MorphologyMethod method, string userKernel, Channels channels, int iterations)
	{
		_nativeInstance.Morphology(method, userKernel, channels, iterations);
	}

	public void Morphology(MorphologyMethod method, string userKernel, int iterations)
	{
		Morphology(method, userKernel, ImageMagick.Channels.Composite, iterations);
	}

	public void Morphology(MorphologySettings settings)
	{
		Throw.IfNull("settings", settings);
		if (settings.ConvolveBias.HasValue)
		{
			SetArtifact("convolve:bias", settings.ConvolveBias.ToString());
		}
		if (settings.ConvolveScale != null)
		{
			SetArtifact("convolve:scale", settings.ConvolveScale.ToString());
		}
		if (!string.IsNullOrEmpty(settings.UserKernel))
		{
			Morphology(settings.Method, settings.UserKernel, settings.Channels, settings.Iterations);
		}
		else
		{
			Morphology(settings.Method, settings.Kernel, settings.KernelArguments, settings.Channels, settings.Iterations);
		}
	}

	public Moments Moments()
	{
		IntPtr list = _nativeInstance.Moments();
		try
		{
			return new Moments(this, list);
		}
		finally
		{
			ImageMagick.Moments.DisposeList(list);
		}
	}

	public void MotionBlur(double radius, double sigma, double angle)
	{
		_nativeInstance.MotionBlur(radius, sigma, angle);
	}

	public void Negate()
	{
		Negate(onlyGrayscale: false);
	}

	public void Negate(bool onlyGrayscale)
	{
		Negate(onlyGrayscale, ImageMagick.Channels.Composite);
	}

	public void Negate(bool onlyGrayscale, Channels channels)
	{
		_nativeInstance.Negate(onlyGrayscale, channels);
	}

	public void Negate(Channels channels)
	{
		Negate(onlyGrayscale: false, channels);
	}

	public void Normalize()
	{
		_nativeInstance.Normalize();
	}

	public void OilPaint()
	{
		OilPaint(3.0, 1.0);
	}

	public void OilPaint(double radius, double sigma)
	{
		_nativeInstance.OilPaint(radius, sigma);
	}

	public void Opaque(MagickColor target, MagickColor fill)
	{
		Opaque(target, fill, invert: false);
	}

	public void OrderedDither(string thresholdMap)
	{
		Throw.IfNullOrEmpty("thresholdMap", thresholdMap);
		OrderedDither(thresholdMap, ImageMagick.Channels.Composite);
	}

	public void OrderedDither(string thresholdMap, Channels channels)
	{
		Throw.IfNullOrEmpty("thresholdMap", thresholdMap);
		_nativeInstance.OrderedDither(thresholdMap, channels);
	}

	public void Perceptible(double epsilon)
	{
		Perceptible(epsilon, ImageMagick.Channels.Composite);
	}

	public void Perceptible(double epsilon, Channels channels)
	{
		_nativeInstance.Perceptible(epsilon, channels);
	}

	public PerceptualHash PerceptualHash()
	{
		IntPtr list = _nativeInstance.PerceptualHash();
		try
		{
			PerceptualHash perceptualHash = new PerceptualHash(this, list);
			if (!perceptualHash.Isvalid)
			{
				return null;
			}
			return perceptualHash;
		}
		finally
		{
			ImageMagick.PerceptualHash.DisposeList(list);
		}
	}

	public void Ping(byte[] data)
	{
		Ping(data, null);
	}

	public void Ping(byte[] data, MagickReadSettings readSettings)
	{
		Throw.IfNullOrEmpty("data", data);
		Read(data, data.Length, readSettings, ping: true);
	}

	public void Ping(FileInfo file)
	{
		Throw.IfNull("file", file);
		Read(file.FullName, null, ping: true);
	}

	public void Ping(FileInfo file, MagickReadSettings readSettings)
	{
		Throw.IfNull("file", file);
		Read(file.FullName, readSettings, ping: true);
	}

	public void Ping(Stream stream)
	{
		Read(stream, null);
	}

	public void Ping(Stream stream, MagickReadSettings readSettings)
	{
		Read(stream, readSettings, ping: true);
	}

	public void Ping(string fileName)
	{
		Read(fileName, null, ping: true);
	}

	public void Ping(string fileName, MagickReadSettings readSettings)
	{
		Read(fileName, readSettings, ping: true);
	}

	public void Polaroid(string caption, double angle, PixelInterpolateMethod method)
	{
		Throw.IfNull("caption", caption);
		_nativeInstance.Polaroid(Settings.Drawing, caption, angle, method);
	}

	public void Posterize(int levels)
	{
		Posterize(levels, DitherMethod.No);
	}

	public void Posterize(int levels, DitherMethod method)
	{
		Posterize(levels, method, ImageMagick.Channels.Composite);
	}

	public void Posterize(int levels, DitherMethod method, Channels channels)
	{
		_nativeInstance.Posterize(levels, method, channels);
	}

	public void Posterize(int levels, Channels channels)
	{
		Posterize(levels, DitherMethod.No, channels);
	}

	public void PreserveColorType()
	{
		ColorType = ColorType;
		SetAttribute("colorspace:auto-grayscale", "false");
	}

	public MagickErrorInfo Quantize(QuantizeSettings settings)
	{
		Throw.IfNull("settings", settings);
		_nativeInstance.Quantize(settings);
		if (settings.MeasureErrors)
		{
			return CreateErrorInfo(this);
		}
		return null;
	}

	public void Raise(int size)
	{
		_nativeInstance.RaiseOrLower(size, raise: true);
	}

	public void RandomThreshold(Percentage percentageLow, Percentage percentageHigh)
	{
		RandomThreshold(percentageLow, percentageHigh, ImageMagick.Channels.Composite);
	}

	public void RandomThreshold(Percentage percentageLow, Percentage percentageHigh, Channels channels)
	{
		Throw.IfNegative("percentageLow", percentageLow);
		Throw.IfNegative("percentageHigh", percentageHigh);
		RandomThreshold(percentageLow.ToQuantumType(), percentageHigh.ToQuantumType(), channels);
	}

	public void RandomThreshold(byte low, byte high)
	{
		RandomThreshold(low, high, ImageMagick.Channels.Composite);
	}

	public void RandomThreshold(byte low, byte high, Channels channels)
	{
		_nativeInstance.RandomThreshold((int)low, (int)high, channels);
	}

	public void Read(byte[] data)
	{
		Read(data, null);
	}

	public void Read(byte[] data, MagickReadSettings readSettings)
	{
		Throw.IfNullOrEmpty("data", data);
		Read(data, data.Length, readSettings, ping: false);
	}

	public void Read(FileInfo file)
	{
		Throw.IfNull("file", file);
		Read(file.FullName);
	}

	public void Read(FileInfo file, int width, int height)
	{
		Throw.IfNull("file", file);
		Read(file.FullName, width, height);
	}

	public void Read(FileInfo file, MagickReadSettings readSettings)
	{
		Throw.IfNull("file", file);
		Read(file.FullName, readSettings);
	}

	public void Read(MagickColor color, int width, int height)
	{
		Throw.IfNull("color", color);
		Read("xc:" + color.ToShortString(), width, height);
	}

	public void Read(Stream stream)
	{
		Read(stream, null);
	}

	public void Read(Stream stream, MagickReadSettings readSettings)
	{
		Read(stream, readSettings, ping: false);
	}

	public void Read(string fileName)
	{
		Read(fileName, null);
	}

	public void Read(string fileName, int width, int height)
	{
		MagickReadSettings magickReadSettings = new MagickReadSettings(Settings);
		magickReadSettings.Width = width;
		magickReadSettings.Height = height;
		Read(fileName, magickReadSettings);
	}

	public void Read(string fileName, MagickReadSettings readSettings)
	{
		Read(fileName, readSettings, ping: false);
	}

	public void ReduceNoise()
	{
		ReduceNoise(3);
	}

	public void ReduceNoise(int order)
	{
		Statistic(StatisticType.Nonpeak, order, order);
	}

	public void RegionMask(MagickGeometry region)
	{
		Throw.IfNull("region", region);
		MagickRectangle region2 = MagickRectangle.FromGeometry(region, this);
		_nativeInstance.RegionMask(region2);
	}

	public void RemoveArtifact(string name)
	{
		_nativeInstance.RemoveArtifact(name);
	}

	public void RemoveAttribute(string name)
	{
		_nativeInstance.RemoveAttribute(name);
	}

	public void RemoveRegionMask()
	{
		_nativeInstance.RegionMask(null);
	}

	public void RemoveProfile(string name)
	{
		Throw.IfNullOrEmpty("name", name);
		_nativeInstance.RemoveProfile(name);
	}

	public void RePage()
	{
		Page = new MagickGeometry(0, 0, 0, 0);
	}

	public void Resample(double resolutionX, double resolutionY)
	{
		PointD density = new PointD(resolutionX, resolutionY);
		Resample(density);
	}

	public void Resample(PointD density)
	{
		_nativeInstance.Resample(density.X, density.Y);
	}

	public void Resize(int width, int height)
	{
		MagickGeometry geometry = new MagickGeometry(width, height);
		Resize(geometry);
	}

	public void Resize(MagickGeometry geometry)
	{
		Throw.IfNull("geometry", geometry);
		_nativeInstance.Resize(geometry.ToString());
	}

	public void Resize(Percentage percentage)
	{
		Resize(percentage, percentage);
	}

	public void Resize(Percentage percentageWidth, Percentage percentageHeight)
	{
		Throw.IfNegative("percentageWidth", percentageWidth);
		Throw.IfNegative("percentageHeight", percentageHeight);
		MagickGeometry geometry = new MagickGeometry(percentageWidth, percentageHeight);
		Resize(geometry);
	}

	public void Roll(int x, int y)
	{
		_nativeInstance.Roll(x, y);
	}

	public void Rotate(double degrees)
	{
		_nativeInstance.Rotate(degrees);
	}

	public void RotationalBlur(double angle)
	{
		RotationalBlur(angle, ImageMagick.Channels.Composite);
	}

	public void RotationalBlur(double angle, Channels channels)
	{
		_nativeInstance.RotationalBlur(angle, channels);
	}

	public void Scale(int width, int height)
	{
		MagickGeometry geometry = new MagickGeometry(width, height);
		Scale(geometry);
	}

	public void Sample(int width, int height)
	{
		MagickGeometry geometry = new MagickGeometry(width, height);
		Sample(geometry);
	}

	public void Sample(MagickGeometry geometry)
	{
		Throw.IfNull("geometry", geometry);
		_nativeInstance.Sample(geometry.ToString());
	}

	public void Sample(Percentage percentage)
	{
		Sample(percentage, percentage);
	}

	public void Sample(Percentage percentageWidth, Percentage percentageHeight)
	{
		Throw.IfNegative("percentageWidth", percentageWidth);
		Throw.IfNegative("percentageHeight", percentageHeight);
		MagickGeometry geometry = new MagickGeometry(percentageWidth, percentageHeight);
		Sample(geometry);
	}

	public void Scale(MagickGeometry geometry)
	{
		Throw.IfNull("geometry", geometry);
		_nativeInstance.Scale(MagickGeometry.ToString(geometry));
	}

	public void Scale(Percentage percentage)
	{
		Scale(percentage, percentage);
	}

	public void Scale(Percentage percentageWidth, Percentage percentageHeight)
	{
		Throw.IfNegative("percentageWidth", percentageWidth);
		Throw.IfNegative("percentageHeight", percentageHeight);
		MagickGeometry geometry = new MagickGeometry(percentageWidth, percentageHeight);
		Scale(geometry);
	}

	public void Segment()
	{
		Segment(ColorSpace.Undefined, 1.0, 1.5);
	}

	public void Segment(ColorSpace quantizeColorSpace, double clusterThreshold, double smoothingThreshold)
	{
		_nativeInstance.Segment(quantizeColorSpace, clusterThreshold, smoothingThreshold);
	}

	public void SelectiveBlur(double radius, double sigma, double threshold)
	{
		SelectiveBlur(radius, sigma, threshold, ImageMagick.Channels.Composite);
	}

	public void SelectiveBlur(double radius, double sigma, double threshold, Channels channels)
	{
		_nativeInstance.SelectiveBlur(radius, sigma, threshold, channels);
	}

	public void SelectiveBlur(double radius, double sigma, Percentage thresholdPercentage)
	{
		SelectiveBlur(radius, sigma, thresholdPercentage, ImageMagick.Channels.Composite);
	}

	public void SelectiveBlur(double radius, double sigma, Percentage thresholdPercentage, Channels channels)
	{
		_nativeInstance.SelectiveBlur(radius, sigma, thresholdPercentage.ToQuantum(), channels);
	}

	public IEnumerable<IMagickImage> Separate()
	{
		return Separate(ImageMagick.Channels.All);
	}

	public IEnumerable<IMagickImage> Separate(Channels channels)
	{
		IntPtr images = _nativeInstance.Separate(channels);
		return CreateList(images);
	}

	public void SepiaTone()
	{
		SepiaTone(new Percentage(80));
	}

	public void SepiaTone(Percentage threshold)
	{
		_nativeInstance.SepiaTone(threshold.ToQuantum());
	}

	public void SetArtifact(string name, string value)
	{
		Throw.IfNullOrEmpty("name", name);
		Throw.IfNull("value", value);
		_nativeInstance.SetArtifact(name, value);
	}

	public void SetAttenuate(double attenuate)
	{
		SetArtifact("attenuate", attenuate.ToString(CultureInfo.InvariantCulture));
	}

	public void SetAttribute(string name, string value)
	{
		Throw.IfNullOrEmpty("name", name);
		Throw.IfNull("value", value);
		_nativeInstance.SetAttribute(name, value);
	}

	public void SetClippingPath(string value)
	{
		SetClippingPath(value, "#1");
	}

	public void SetClippingPath(string value, string pathName)
	{
		SetAttribute("8BIM:1999,2998:" + pathName, value);
	}

	public void SetColormap(int index, MagickColor color)
	{
		Throw.IfNull("color", color);
		_nativeInstance.SetColormap(index, color);
	}

	public void SetHighlightColor(MagickColor color)
	{
		Throw.IfNull("color", color);
		SetArtifact("highlight-color", color.ToString());
	}

	public void SetLowlightColor(MagickColor color)
	{
		Throw.IfNull("color", color);
		SetArtifact("lowlight-color", color.ToString());
	}

	public void Shade()
	{
		Shade(30.0, 30.0);
	}

	public void Shade(double azimuth, double elevation)
	{
		Shade(azimuth, elevation, colorShading: true);
	}

	public void Shade(double azimuth, double elevation, bool colorShading)
	{
		Shade(azimuth, elevation, colorShading, ImageMagick.Channels.RGB);
	}

	public void Shade(double azimuth, double elevation, bool colorShading, Channels channels)
	{
		_nativeInstance.Shade(azimuth, elevation, colorShading, channels);
	}

	public void Shadow()
	{
		Shadow(5, 5, 0.5, new Percentage(80));
	}

	public void Shadow(MagickColor color)
	{
		Shadow(5, 5, 0.5, new Percentage(80), color);
	}

	public void Shadow(int x, int y, double sigma, Percentage alpha)
	{
		_nativeInstance.Shadow(x, y, sigma, alpha.ToDouble());
	}

	public void Shadow(int x, int y, double sigma, Percentage alpha, MagickColor color)
	{
		Throw.IfNull("color", color);
		MagickColor backgroundColor = BackgroundColor;
		BackgroundColor = color;
		_nativeInstance.Shadow(x, y, sigma, alpha.ToDouble());
		BackgroundColor = backgroundColor;
	}

	public void Sharpen()
	{
		Sharpen(0.0, 1.0);
	}

	public void Sharpen(Channels channels)
	{
		Sharpen(0.0, 1.0, channels);
	}

	public void Sharpen(double radius, double sigma)
	{
		Sharpen(radius, sigma, ImageMagick.Channels.Composite);
	}

	public void Sharpen(double radius, double sigma, Channels channels)
	{
		_nativeInstance.Sharpen(radius, sigma, channels);
	}

	public void Shave(int leftRight, int topBottom)
	{
		_nativeInstance.Shave(leftRight, topBottom);
	}

	public void Shear(double xAngle, double yAngle)
	{
		_nativeInstance.Shear(xAngle, yAngle);
	}

	public void SigmoidalContrast(double contrast)
	{
		SigmoidalContrast(sharpen: true, contrast);
	}

	public void SigmoidalContrast(bool sharpen, double contrast)
	{
		SigmoidalContrast(sharpen, contrast, (double)(int)Quantum.Max * 0.5);
	}

	public void SigmoidalContrast(double contrast, double midpoint)
	{
		SigmoidalContrast(sharpen: true, contrast, midpoint);
	}

	public void SigmoidalContrast(bool sharpen, double contrast, double midpoint)
	{
		_nativeInstance.SigmoidalContrast(sharpen, contrast, midpoint);
	}

	public void SigmoidalContrast(double contrast, Percentage midpointPercentage)
	{
		SigmoidalContrast(sharpen: true, contrast, midpointPercentage);
	}

	public void SigmoidalContrast(bool sharpen, double contrast, Percentage midpointPercentage)
	{
		SigmoidalContrast(sharpen, contrast, midpointPercentage.ToQuantum());
	}

	public void SparseColor(SparseColorMethod method, IEnumerable<SparseColorArg> args)
	{
		SparseColor(ImageMagick.Channels.Composite, method, args);
	}

	public void SparseColor(SparseColorMethod method, params SparseColorArg[] args)
	{
		SparseColor(ImageMagick.Channels.Composite, method, (IEnumerable<SparseColorArg>)args);
	}

	public void SparseColor(Channels channels, SparseColorMethod method, IEnumerable<SparseColorArg> args)
	{
		Throw.IfNull("args", args);
		bool flag = EnumHelper.HasFlag(channels, ImageMagick.Channels.Red);
		bool flag2 = EnumHelper.HasFlag(channels, ImageMagick.Channels.Green);
		bool flag3 = EnumHelper.HasFlag(channels, ImageMagick.Channels.Blue);
		bool flag4 = HasAlpha && EnumHelper.HasFlag(channels, ImageMagick.Channels.Alpha);
		Throw.IfTrue("channels", !flag && !flag2 && !flag3 && !flag4, "Invalid channels specified.");
		List<double> list = new List<double>();
		foreach (SparseColorArg arg in args)
		{
			list.Add(arg.X);
			list.Add(arg.Y);
			if (flag)
			{
				list.Add(Quantum.ScaleToDouble(arg.Color.R));
			}
			if (flag2)
			{
				list.Add(Quantum.ScaleToDouble(arg.Color.G));
			}
			if (flag3)
			{
				list.Add(Quantum.ScaleToDouble(arg.Color.B));
			}
			if (flag4)
			{
				list.Add(Quantum.ScaleToDouble(arg.Color.A));
			}
		}
		Throw.IfTrue("args", list.Count == 0, "Value cannot be empty");
		_nativeInstance.SparseColor(channels, method, list.ToArray(), list.Count);
	}

	public void SparseColor(Channels channels, SparseColorMethod method, params SparseColorArg[] args)
	{
		SparseColor(channels, method, (IEnumerable<SparseColorArg>)args);
	}

	public void Sketch()
	{
		Sketch(0.0, 1.0, 0.0);
	}

	public void Sketch(double radius, double sigma, double angle)
	{
		_nativeInstance.Sketch(radius, sigma, angle);
	}

	public void Solarize()
	{
		Solarize(new Percentage(50.0));
	}

	public void Solarize(double factor)
	{
		_nativeInstance.Solarize(factor);
	}

	public void Solarize(Percentage factorPercentage)
	{
		_nativeInstance.Solarize(factorPercentage.ToQuantum());
	}

	public void Splice(MagickGeometry geometry)
	{
		Throw.IfNull("geometry", geometry);
		_nativeInstance.Splice(MagickRectangle.FromGeometry(geometry, this));
	}

	public void Spread()
	{
		Spread(Interpolate, 3.0);
	}

	public void Spread(double radius)
	{
		Spread(PixelInterpolateMethod.Undefined, radius);
	}

	public void Spread(PixelInterpolateMethod method, double radius)
	{
		_nativeInstance.Spread(method, radius);
	}

	public void Statistic(StatisticType type, int width, int height)
	{
		_nativeInstance.Statistic(type, width, height);
	}

	public Statistics Statistics()
	{
		IntPtr list = _nativeInstance.Statistics();
		try
		{
			return new Statistics(this, list);
		}
		finally
		{
			ImageMagick.Statistics.DisposeList(list);
		}
	}

	public void Stegano(IMagickImage watermark)
	{
		Throw.IfNull("watermark", watermark);
		_nativeInstance.Stegano(watermark);
	}

	public void Stereo(IMagickImage rightImage)
	{
		Throw.IfNull("rightImage", rightImage);
		_nativeInstance.Stereo(rightImage);
	}

	public void Strip()
	{
		_nativeInstance.Strip();
	}

	public void Swirl(double degrees)
	{
		Swirl(Interpolate, degrees);
	}

	public void Swirl(PixelInterpolateMethod method, double degrees)
	{
		_nativeInstance.Swirl(method, degrees);
	}

	public MagickSearchResult SubImageSearch(IMagickImage image)
	{
		return SubImageSearch(image, ErrorMetric.RootMeanSquared, -1.0);
	}

	public MagickSearchResult SubImageSearch(IMagickImage image, ErrorMetric metric)
	{
		return SubImageSearch(image, metric, -1.0);
	}

	public MagickSearchResult SubImageSearch(IMagickImage image, ErrorMetric metric, double similarityThreshold)
	{
		Throw.IfNull("image", image);
		MagickRectangle offset;
		double similarityMetric;
		return new MagickSearchResult(Create(_nativeInstance.SubImageSearch(image, metric, similarityThreshold, out offset, out similarityMetric), image.Settings), MagickGeometry.FromRectangle(offset), similarityMetric);
	}

	public void Texture(IMagickImage image)
	{
		Throw.IfNull("image", image);
		_nativeInstance.Texture(image);
	}

	public void Threshold(Percentage percentage)
	{
		_nativeInstance.Threshold(percentage.ToQuantum());
	}

	public void Thumbnail(int width, int height)
	{
		MagickGeometry geometry = new MagickGeometry(width, height);
		Thumbnail(geometry);
	}

	public void Thumbnail(MagickGeometry geometry)
	{
		Throw.IfNull("geometry", geometry);
		_nativeInstance.Thumbnail(MagickGeometry.ToString(geometry));
	}

	public void Thumbnail(Percentage percentage)
	{
		Thumbnail(percentage, percentage);
	}

	public void Thumbnail(Percentage percentageWidth, Percentage percentageHeight)
	{
		Throw.IfNegative("percentageWidth", percentageWidth);
		Throw.IfNegative("percentageHeight", percentageHeight);
		MagickGeometry geometry = new MagickGeometry(percentageWidth, percentageHeight);
		Thumbnail(geometry);
	}

	public void Tile(IMagickImage image, CompositeOperator compose)
	{
		Tile(image, compose, null);
	}

	public void Tile(IMagickImage image, CompositeOperator compose, string args)
	{
		Throw.IfNull("image", image);
		for (int i = 0; i < Height; i += image.Height)
		{
			for (int j = 0; j < Width; j += image.Width)
			{
				Composite(image, j, i, compose, args);
			}
		}
	}

	public void Tint(string opacity)
	{
		Tint(opacity, Settings.FillColor);
	}

	public void Tint(string opacity, MagickColor color)
	{
		Throw.IfNullOrEmpty("opacity", opacity);
		Throw.IfNull("color", color);
		_nativeInstance.Tint(opacity, color);
	}

	public string ToBase64()
	{
		byte[] array = ToByteArray();
		if (array == null)
		{
			return string.Empty;
		}
		return Convert.ToBase64String(array);
	}

	public string ToBase64(MagickFormat format)
	{
		byte[] array = ToByteArray(format);
		if (array == null)
		{
			return string.Empty;
		}
		return Convert.ToBase64String(array);
	}

	public byte[] ToByteArray()
	{
		using MemoryStream memoryStream = new MemoryStream();
		Write(memoryStream);
		return memoryStream.ToArray();
	}

	public byte[] ToByteArray(IWriteDefines defines)
	{
		Settings.SetDefines(defines);
		return ToByteArray(defines.Format);
	}

	public byte[] ToByteArray(MagickFormat format)
	{
		Format = format;
		return ToByteArray();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "{0} {1}x{2} {3}-bit {4} {5}", Format, Width, Height, Depth, ColorSpace, FormatedFileSize());
	}

	public void TransformColorSpace(ColorProfile source, ColorProfile target)
	{
		Throw.IfNull("source", source);
		Throw.IfNull("target", target);
		if (source.ColorSpace == ColorSpace)
		{
			AddProfile(source, overwriteExisting: false);
			AddProfile(target);
		}
	}

	public void Transparent(MagickColor color)
	{
		Throw.IfNull("color", color);
		_nativeInstance.Transparent(color, invert: false);
	}

	public void TransparentChroma(MagickColor colorLow, MagickColor colorHigh)
	{
		Throw.IfNull("colorLow", colorLow);
		Throw.IfNull("colorHigh", colorHigh);
		_nativeInstance.TransparentChroma(colorLow, colorHigh, invert: false);
	}

	public void Transpose()
	{
		_nativeInstance.Transpose();
	}

	public void Transverse()
	{
		_nativeInstance.Transverse();
	}

	public void Trim()
	{
		_nativeInstance.Trim();
	}

	public IMagickImage UniqueColors()
	{
		return Create(_nativeInstance.UniqueColors(), Settings);
	}

	public void UnsharpMask(double radius, double sigma)
	{
		UnsharpMask(radius, sigma, 1.0, 0.05);
	}

	public void UnsharpMask(double radius, double sigma, Channels channels)
	{
		UnsharpMask(radius, sigma, 1.0, 0.05, channels);
	}

	public void UnsharpMask(double radius, double sigma, double amount, double threshold)
	{
		UnsharpMask(radius, sigma, amount, threshold, ImageMagick.Channels.Composite);
	}

	public void UnsharpMask(double radius, double sigma, double amount, double threshold, Channels channels)
	{
		_nativeInstance.UnsharpMask(radius, sigma, amount, threshold, channels);
	}

	public void Vignette()
	{
		Vignette(0.0, 1.0, 0, 0);
	}

	public void Vignette(double radius, double sigma, int x, int y)
	{
		_nativeInstance.Vignette(radius, sigma, x, y);
	}

	public void Wave()
	{
		Wave(Interpolate, 25.0, 150.0);
	}

	public void Wave(PixelInterpolateMethod method, double amplitude, double length)
	{
		_nativeInstance.Wave(method, amplitude, length);
	}

	public void WaveletDenoise(byte threshold)
	{
		WaveletDenoise(threshold, 0.0);
	}

	public void WaveletDenoise(byte threshold, double softness)
	{
		_nativeInstance.WaveletDenoise((int)threshold, softness);
	}

	public void WaveletDenoise(Percentage thresholdPercentage)
	{
		WaveletDenoise(thresholdPercentage.ToQuantumType(), 0.0);
	}

	public void WaveletDenoise(Percentage thresholdPercentage, double softness)
	{
		WaveletDenoise(thresholdPercentage.ToQuantumType(), softness);
	}

	public void WhiteThreshold(Percentage threshold)
	{
		WhiteThreshold(threshold, ImageMagick.Channels.Composite);
	}

	public void WhiteThreshold(Percentage threshold, Channels channels)
	{
		Throw.IfNegative("threshold", threshold);
		_nativeInstance.WhiteThreshold(threshold.ToString(), channels);
	}

	public void Write(FileInfo file)
	{
		Throw.IfNull("file", file);
		Write(file.FullName);
		file.Refresh();
	}

	public void Write(FileInfo file, IWriteDefines defines)
	{
		Settings.SetDefines(defines);
		Write(file);
	}

	public void Write(Stream stream)
	{
		Throw.IfNull("stream", stream);
		Settings.FileName = null;
		using StreamWrapper streamWrapper = StreamWrapper.CreateForWriting(stream);
		ReadWriteStreamDelegate writer = streamWrapper.Write;
		SeekStreamDelegate seeker = null;
		TellStreamDelegate teller = null;
		if (stream.CanSeek)
		{
			seeker = streamWrapper.Seek;
			teller = streamWrapper.Tell;
		}
		_nativeInstance.WriteStream(Settings, writer, seeker, teller);
	}

	public void Write(Stream stream, IWriteDefines defines)
	{
		Settings.SetDefines(defines);
		Format = defines.Format;
		Write(stream);
	}

	public void Write(Stream stream, MagickFormat format)
	{
		Format = format;
		Write(stream);
	}

	public void Write(string fileName)
	{
		string text = FileHelper.CheckForBaseDirectory(fileName);
		Throw.IfNullOrEmpty("fileName", text);
		_nativeInstance.FileName = text;
		_nativeInstance.WriteFile(Settings);
	}

	public void Write(string fileName, IWriteDefines defines)
	{
		Settings.SetDefines(defines);
		Write(fileName);
	}

	internal static IMagickImage Clone(IMagickImage image)
	{
		return image?.Clone();
	}

	internal static MagickImage Create(IntPtr image)
	{
		if (image == IntPtr.Zero)
		{
			return null;
		}
		return new MagickImage(new NativeMagickImage(image), new MagickSettings());
	}

	internal static IMagickImage Create(IntPtr image, MagickSettings settings)
	{
		if (image == IntPtr.Zero)
		{
			return null;
		}
		return new MagickImage(new NativeMagickImage(image), settings.Clone());
	}

	internal static MagickErrorInfo CreateErrorInfo(MagickImage image)
	{
		if (image == null)
		{
			return null;
		}
		return new MagickErrorInfo(image._nativeInstance.MeanErrorPerPixel, image._nativeInstance.NormalizedMeanError, image._nativeInstance.NormalizedMaximumError);
	}

	internal static IEnumerable<IMagickImage> CreateList(IntPtr images, MagickSettings settings)
	{
		Collection<IMagickImage> collection = new Collection<IMagickImage>();
		IntPtr intPtr = images;
		while (intPtr != IntPtr.Zero)
		{
			IntPtr next = NativeMagickImage.GetNext(intPtr);
			NativeMagickImage nativeMagickImage = new NativeMagickImage(intPtr);
			nativeMagickImage.SetNext(IntPtr.Zero);
			collection.Add(new MagickImage(nativeMagickImage, settings.Clone()));
			intPtr = next;
		}
		return collection;
	}

	internal int ChannelOffset(PixelChannel pixelChannel)
	{
		if (!_nativeInstance.HasChannel(pixelChannel))
		{
			return -1;
		}
		return _nativeInstance.ChannelOffset(pixelChannel);
	}

	internal void SetNext(IMagickImage image)
	{
		_nativeInstance.SetNext(image.GetInstance());
	}

	private static int GetExpectedLength(MagickReadSettings settings)
	{
		int num = settings.Width.Value * settings.Height.Value * settings.PixelStorage.Mapping.Length;
		return settings.PixelStorage.StorageType switch
		{
			StorageType.Char => num, 
			StorageType.Double => num * 8, 
			StorageType.Float => num * 4, 
			StorageType.Long => num * 4, 
			StorageType.LongLong => num * 8, 
			StorageType.Quantum => num, 
			StorageType.Short => num * 2, 
			_ => throw new NotSupportedException(), 
		};
	}

	private PointD CalculateContrastStretch(Percentage blackPoint, Percentage whitePoint)
	{
		double num = blackPoint.ToDouble();
		double num2 = whitePoint.ToDouble();
		double num3 = Width * Height;
		double x = num * (num3 / 100.0);
		num2 *= num3 / 100.0;
		num2 = num3 - num2;
		return new PointD(x, num2);
	}

	private IEnumerable<IMagickImage> CreateList(IntPtr images)
	{
		return CreateList(images, Settings.Clone());
	}

	private MagickReadSettings CreateReadSettings(MagickReadSettings readSettings)
	{
		if (readSettings != null && readSettings.FrameCount.HasValue)
		{
			Throw.IfFalse("readSettings", readSettings.FrameCount.Value == 1, "The frame count can only be set to 1 when a single image is being read.");
		}
		MagickReadSettings magickReadSettings = null;
		magickReadSettings = ((readSettings != null) ? new MagickReadSettings(readSettings) : new MagickReadSettings(Settings));
		magickReadSettings.ForceSingleFrame();
		return magickReadSettings;
	}

	private void Dispose(bool disposing)
	{
		DisposeInstance();
		if (disposing && Settings != null)
		{
			Settings.Artifact -= OnArtifact;
		}
	}

	private void DisposeInstance()
	{
		if (_nativeInstance != null)
		{
			_nativeInstance.Warning -= OnWarning;
			_nativeInstance.Dispose();
		}
	}

	private string FormatedFileSize()
	{
		decimal num = FileSize;
		string text = string.Empty;
		if (num > 1073741824m)
		{
			num /= 1073741824m;
			text = "GB";
		}
		else if (num > 1048576m)
		{
			num /= 1048576m;
			text = "MB";
		}
		else if (num > 1024m)
		{
			num /= 1024m;
			text = "kB";
		}
		return string.Format(CultureInfo.InvariantCulture, "{0:N2}{1}", new object[2] { num, text });
	}

	private void FloodFill(byte alpha, int x, int y, bool invert)
	{
		MagickColor magickColor;
		using (PixelCollection pixelCollection = GetPixels())
		{
			magickColor = pixelCollection.GetPixel(x, y).ToColor();
			magickColor.A = alpha;
		}
		_nativeInstance.FloodFill(Settings.Drawing, x, y, magickColor, invert);
	}

	private void FloodFill(MagickColor color, int x, int y, bool invert)
	{
		Throw.IfNull("color", color);
		MagickColor target;
		using (PixelCollection pixelCollection = GetPixels())
		{
			target = pixelCollection.GetPixel(x, y).ToColor();
		}
		FloodFill(color, x, y, target, invert);
	}

	private void FloodFill(MagickColor color, int x, int y, MagickColor target, bool invert)
	{
		Throw.IfNull("color", color);
		Throw.IfNull("target", target);
		DrawingSettings drawing = Settings.Drawing;
		using IMagickImage fillPattern = drawing.FillPattern;
		MagickColor fillColor = drawing.FillColor;
		drawing.FillColor = color;
		drawing.FillPattern = null;
		_nativeInstance.FloodFill(drawing, x, y, target, invert);
		drawing.FillColor = fillColor;
		drawing.FillPattern = fillPattern;
	}

	private void FloodFill(IMagickImage image, int x, int y, bool invert)
	{
		Throw.IfNull("image", image);
		MagickColor target;
		using (PixelCollection pixelCollection = GetPixels())
		{
			target = pixelCollection.GetPixel(x, y).ToColor();
		}
		FloodFill(image, x, y, target, invert);
	}

	private void FloodFill(IMagickImage image, int x, int y, MagickColor target, bool invert)
	{
		Throw.IfNull("image", image);
		Throw.IfNull("target", target);
		DrawingSettings drawing = Settings.Drawing;
		using IMagickImage fillPattern = drawing.FillPattern;
		MagickColor fillColor = drawing.FillColor;
		drawing.FillColor = null;
		drawing.FillPattern = image;
		_nativeInstance.FloodFill(drawing, x, y, target, invert);
		drawing.FillColor = fillColor;
		drawing.FillPattern = fillPattern;
	}

	private void LevelColors(MagickColor blackColor, MagickColor whiteColor, bool invert)
	{
		LevelColors(blackColor, whiteColor, ImageMagick.Channels.RGB, invert);
	}

	private void LevelColors(MagickColor blackColor, MagickColor whiteColor, Channels channels, bool invert)
	{
		Throw.IfNull("blackColor", blackColor);
		Throw.IfNull("whiteColor", whiteColor);
		_nativeInstance.LevelColors(blackColor, whiteColor, channels, invert);
	}

	private void Opaque(MagickColor target, MagickColor fill, bool invert)
	{
		Throw.IfNull("target", target);
		Throw.IfNull("fill", fill);
		_nativeInstance.Opaque(target, fill, invert);
	}

	private ColorProfile GetColorProfile(string name)
	{
		StringInfo profile = _nativeInstance.GetProfile(name);
		if (profile == null || profile.Datum == null)
		{
			return null;
		}
		return new ColorProfile(name, profile.Datum);
	}

	private void OnArtifact(object sender, ArtifactEventArgs arguments)
	{
		if (arguments.Value == null)
		{
			RemoveArtifact(arguments.Key);
		}
		else
		{
			SetArtifact(arguments.Key, arguments.Value);
		}
	}

	private bool OnProgress(IntPtr origin, long offset, ulong extent, IntPtr userData)
	{
		if (_progress == null)
		{
			return true;
		}
		ProgressEventArgs e = new ProgressEventArgs(UTF8Marshaler.NativeToManaged(origin), (int)offset, (int)extent);
		_progress(this, e);
		if (!e.Cancel)
		{
			return true;
		}
		return false;
	}

	private void OnWarning(object sender, WarningEventArgs arguments)
	{
		_warning?.Invoke(this, arguments);
	}

	private void Read(byte[] data, int length, MagickReadSettings readSettings, bool ping)
	{
		MagickReadSettings magickReadSettings = CreateReadSettings(readSettings);
		SetSettings(magickReadSettings);
		if (magickReadSettings.PixelStorage != null)
		{
			ReadPixels(data, length, readSettings);
			return;
		}
		Settings.Ping = ping;
		_nativeInstance.ReadBlob(Settings, data, length);
	}

	private void Read(Stream stream, MagickReadSettings readSettings, bool ping)
	{
		Throw.IfNull("stream", stream);
		Bytes bytes = Bytes.FromStreamBuffer(stream);
		if (bytes != null)
		{
			Read(bytes.Data, bytes.Length, readSettings, ping);
			return;
		}
		MagickReadSettings magickReadSettings = CreateReadSettings(readSettings);
		SetSettings(magickReadSettings);
		if (magickReadSettings.PixelStorage != null)
		{
			bytes = new Bytes(stream);
			ReadPixels(bytes.Data, bytes.Length, readSettings);
			return;
		}
		Settings.Ping = ping;
		Settings.FileName = null;
		using StreamWrapper streamWrapper = StreamWrapper.CreateForReading(stream);
		ReadWriteStreamDelegate reader = streamWrapper.Read;
		SeekStreamDelegate seeker = null;
		TellStreamDelegate teller = null;
		if (stream.CanSeek)
		{
			seeker = streamWrapper.Seek;
			teller = streamWrapper.Tell;
		}
		_nativeInstance.ReadStream(Settings, reader, seeker, teller);
	}

	private void Read(string fileName, MagickReadSettings readSettings, bool ping)
	{
		string text = FileHelper.CheckForBaseDirectory(fileName);
		Throw.IfNullOrEmpty("fileName", text);
		MagickReadSettings magickReadSettings = CreateReadSettings(readSettings);
		SetSettings(magickReadSettings);
		if (magickReadSettings.PixelStorage != null)
		{
			byte[] array = File.ReadAllBytes(text);
			ReadPixels(array, array.Length, readSettings);
		}
		else
		{
			Settings.Ping = ping;
			Settings.FileName = text;
			_nativeInstance.ReadFile(Settings);
		}
	}

	private void ReadPixels(byte[] data, int length, MagickReadSettings readSettings)
	{
		Throw.IfTrue("readSettings", readSettings.PixelStorage.StorageType == StorageType.Undefined, "Storage type should not be undefined.");
		Throw.IfNull("readSettings", readSettings.Width, "Width should be defined when pixel storage is set.");
		Throw.IfNull("readSettings", readSettings.Height, "Height should be defined when pixel storage is set.");
		Throw.IfNullOrEmpty("readSettings", readSettings.PixelStorage.Mapping, "Pixel storage mapping should be defined.");
		int expectedLength = GetExpectedLength(readSettings);
		Throw.IfTrue("data", length < expectedLength, "The array length is " + length + " but should be at least " + expectedLength + ".");
		_nativeInstance.ReadPixels(readSettings.Width.Value, readSettings.Height.Value, readSettings.PixelStorage.Mapping, readSettings.PixelStorage.StorageType, data);
	}

	private void SetInstance(NativeMagickImage instance)
	{
		DisposeInstance();
		_nativeInstance = instance;
		_nativeInstance.Warning += OnWarning;
	}

	private void SetSettings(MagickSettings settings)
	{
		if (Settings != null)
		{
			Settings.Artifact -= OnArtifact;
		}
		Settings = settings;
		Settings.Artifact += OnArtifact;
	}
}
