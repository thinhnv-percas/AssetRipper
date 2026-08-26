using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ImageMagick;

internal sealed class DrawingWand : IDisposable
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
			public static extern IntPtr DrawingWand_Create(IntPtr image, IntPtr settings);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Affine(IntPtr Instance, double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Alpha(IntPtr Instance, double x, double y, UIntPtr paintMethod, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Arc(IntPtr Instance, double startX, double startY, double endX, double endY, double startDegrees, double endDegrees, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Bezier(IntPtr Instance, IntPtr coordinates, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_BorderColor(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Circle(IntPtr Instance, double originX, double originY, double perimeterX, double perimeterY, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_ClipPath(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_ClipRule(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_ClipUnits(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Color(IntPtr Instance, double x, double y, UIntPtr paintMethod, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Composite(IntPtr Instance, double x, double y, double width, double height, UIntPtr compositeOperator, IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Density(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Ellipse(IntPtr Instance, double originX, double originY, double radiusX, double radiusY, double startDegrees, double endDegrees, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_FillColor(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_FillOpacity(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_FillPatternUrl(IntPtr Instance, IntPtr url, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_FillRule(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Font(IntPtr Instance, IntPtr fontName, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_FontFamily(IntPtr Instance, IntPtr family, UIntPtr style, UIntPtr weight, UIntPtr stretch, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_FontPointSize(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Gravity(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Line(IntPtr Instance, double startX, double startY, double endX, double endY, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathArcAbs(IntPtr Instance, double x, double y, double radiusX, double radiusY, double rotationX, [MarshalAs(UnmanagedType.Bool)] bool useLargeArc, [MarshalAs(UnmanagedType.Bool)] bool useSweep, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathArcRel(IntPtr Instance, double x, double y, double radiusX, double radiusY, double rotationX, [MarshalAs(UnmanagedType.Bool)] bool useLargeArc, [MarshalAs(UnmanagedType.Bool)] bool useSweep, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Render(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Text(IntPtr Instance, double x, double y, IntPtr text, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathClose(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathCurveToAbs(IntPtr Instance, double x1, double y1, double x2, double y2, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathCurveToRel(IntPtr Instance, double x1, double y1, double x2, double y2, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathFinish(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathLineToAbs(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathLineToRel(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathLineToHorizontalAbs(IntPtr Instance, double x, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathLineToHorizontalRel(IntPtr Instance, double x, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathLineToVerticalAbs(IntPtr Instance, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathLineToVerticalRel(IntPtr Instance, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathMoveToAbs(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathMoveToRel(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathQuadraticCurveToAbs(IntPtr Instance, double x1, double y1, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathQuadraticCurveToRel(IntPtr Instance, double x1, double y1, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathSmoothCurveToAbs(IntPtr Instance, double x2, double y2, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathSmoothCurveToRel(IntPtr Instance, double x2, double y2, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathSmoothQuadraticCurveToAbs(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathSmoothQuadraticCurveToRel(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathStart(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Point(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Polygon(IntPtr Instance, IntPtr coordinates, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Polyline(IntPtr Instance, IntPtr coordinates, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PopClipPath(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PopGraphicContext(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PopPattern(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PushClipPath(IntPtr Instance, IntPtr clipPath, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PushGraphicContext(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PushPattern(IntPtr Instance, IntPtr id, double x, double y, double width, double height, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Rectangle(IntPtr Instance, double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Rotation(IntPtr Instance, double angle, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_RoundRectangle(IntPtr Instance, double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY, double cornerWidth, double cornerHeight, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Scaling(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_SkewX(IntPtr Instance, double angle, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_SkewY(IntPtr Instance, double angle, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeAntialias(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool isEnabled, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeColor(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeDashArray(IntPtr Instance, double[] dash, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeDashOffset(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeLineCap(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeLineJoin(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeMiterLimit(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeOpacity(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokePatternUrl(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeWidth(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextAlignment(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextAntialias(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool isEnabled, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextDecoration(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextDirection(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextEncoding(IntPtr Instance, IntPtr encoding, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextInterlineSpacing(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextInterwordSpacing(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextKerning(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextUnderColor(IntPtr Instance, IntPtr color, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Translation(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Viewbox(IntPtr Instance, double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY, out IntPtr exception);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DrawingWand_Create(IntPtr image, IntPtr settings);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Affine(IntPtr Instance, double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Alpha(IntPtr Instance, double x, double y, UIntPtr paintMethod, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Arc(IntPtr Instance, double startX, double startY, double endX, double endY, double startDegrees, double endDegrees, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Bezier(IntPtr Instance, IntPtr coordinates, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_BorderColor(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Circle(IntPtr Instance, double originX, double originY, double perimeterX, double perimeterY, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_ClipPath(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_ClipRule(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_ClipUnits(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Color(IntPtr Instance, double x, double y, UIntPtr paintMethod, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Composite(IntPtr Instance, double x, double y, double width, double height, UIntPtr compositeOperator, IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Density(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Ellipse(IntPtr Instance, double originX, double originY, double radiusX, double radiusY, double startDegrees, double endDegrees, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_FillColor(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_FillOpacity(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_FillPatternUrl(IntPtr Instance, IntPtr url, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_FillRule(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Font(IntPtr Instance, IntPtr fontName, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_FontFamily(IntPtr Instance, IntPtr family, UIntPtr style, UIntPtr weight, UIntPtr stretch, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_FontPointSize(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Gravity(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Line(IntPtr Instance, double startX, double startY, double endX, double endY, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathArcAbs(IntPtr Instance, double x, double y, double radiusX, double radiusY, double rotationX, [MarshalAs(UnmanagedType.Bool)] bool useLargeArc, [MarshalAs(UnmanagedType.Bool)] bool useSweep, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathArcRel(IntPtr Instance, double x, double y, double radiusX, double radiusY, double rotationX, [MarshalAs(UnmanagedType.Bool)] bool useLargeArc, [MarshalAs(UnmanagedType.Bool)] bool useSweep, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Render(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Text(IntPtr Instance, double x, double y, IntPtr text, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathClose(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathCurveToAbs(IntPtr Instance, double x1, double y1, double x2, double y2, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathCurveToRel(IntPtr Instance, double x1, double y1, double x2, double y2, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathFinish(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathLineToAbs(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathLineToRel(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathLineToHorizontalAbs(IntPtr Instance, double x, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathLineToHorizontalRel(IntPtr Instance, double x, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathLineToVerticalAbs(IntPtr Instance, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathLineToVerticalRel(IntPtr Instance, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathMoveToAbs(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathMoveToRel(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathQuadraticCurveToAbs(IntPtr Instance, double x1, double y1, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathQuadraticCurveToRel(IntPtr Instance, double x1, double y1, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathSmoothCurveToAbs(IntPtr Instance, double x2, double y2, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathSmoothCurveToRel(IntPtr Instance, double x2, double y2, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathSmoothQuadraticCurveToAbs(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathSmoothQuadraticCurveToRel(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PathStart(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Point(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Polygon(IntPtr Instance, IntPtr coordinates, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Polyline(IntPtr Instance, IntPtr coordinates, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PopClipPath(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PopGraphicContext(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PopPattern(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PushClipPath(IntPtr Instance, IntPtr clipPath, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PushGraphicContext(IntPtr Instance, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_PushPattern(IntPtr Instance, IntPtr id, double x, double y, double width, double height, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Rectangle(IntPtr Instance, double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Rotation(IntPtr Instance, double angle, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_RoundRectangle(IntPtr Instance, double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY, double cornerWidth, double cornerHeight, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Scaling(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_SkewX(IntPtr Instance, double angle, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_SkewY(IntPtr Instance, double angle, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeAntialias(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool isEnabled, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeColor(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeDashArray(IntPtr Instance, double[] dash, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeDashOffset(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeLineCap(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeLineJoin(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeMiterLimit(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeOpacity(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokePatternUrl(IntPtr Instance, IntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_StrokeWidth(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextAlignment(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextAntialias(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool isEnabled, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextDecoration(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextDirection(IntPtr Instance, UIntPtr value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextEncoding(IntPtr Instance, IntPtr encoding, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextInterlineSpacing(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextInterwordSpacing(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextKerning(IntPtr Instance, double value, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_TextUnderColor(IntPtr Instance, IntPtr color, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Translation(IntPtr Instance, double x, double y, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DrawingWand_Viewbox(IntPtr Instance, double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY, out IntPtr exception);
		}
	}

	private sealed class NativeDrawingWand : NativeInstance
	{
		protected override string TypeName => "DrawingWand";

		static NativeDrawingWand()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Dispose(instance);
			}
		}

		public NativeDrawingWand(IMagickImage image, DrawingSettings settings)
		{
			using INativeInstance nativeInstance = DrawingSettings.CreateInstance(settings);
			if (NativeLibrary.Is64Bit)
			{
				base.Instance = NativeMethods.X64.DrawingWand_Create(image.GetInstance(), nativeInstance.Instance);
			}
			else
			{
				base.Instance = NativeMethods.X86.DrawingWand_Create(image.GetInstance(), nativeInstance.Instance);
			}
			if (base.Instance == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
		}

		public void Affine(double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Affine(base.Instance, scaleX, scaleY, shearX, shearY, translateX, translateY, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Affine(base.Instance, scaleX, scaleY, shearX, shearY, translateX, translateY, out exception);
			}
			CheckException(exception);
		}

		public void Alpha(double x, double y, PaintMethod paintMethod)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Alpha(base.Instance, x, y, (UIntPtr)(ulong)paintMethod, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Alpha(base.Instance, x, y, (UIntPtr)(ulong)paintMethod, out exception);
			}
			CheckException(exception);
		}

		public void Arc(double startX, double startY, double endX, double endY, double startDegrees, double endDegrees)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Arc(base.Instance, startX, startY, endX, endY, startDegrees, endDegrees, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Arc(base.Instance, startX, startY, endX, endY, startDegrees, endDegrees, out exception);
			}
			CheckException(exception);
		}

		public void Bezier(PointInfoCollection coordinates, int length)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Bezier(base.Instance, coordinates.GetInstance(), (UIntPtr)(ulong)length, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Bezier(base.Instance, coordinates.GetInstance(), (UIntPtr)(ulong)length, out exception);
			}
			CheckException(exception);
		}

		public void BorderColor(MagickColor value)
		{
			using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_BorderColor(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_BorderColor(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void Circle(double originX, double originY, double perimeterX, double perimeterY)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Circle(base.Instance, originX, originY, perimeterX, perimeterY, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Circle(base.Instance, originX, originY, perimeterX, perimeterY, out exception);
			}
			CheckException(exception);
		}

		public void ClipPath(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_ClipPath(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_ClipPath(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void ClipRule(FillRule value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_ClipRule(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_ClipRule(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			CheckException(exception);
		}

		public void ClipUnits(ClipPathUnit value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_ClipUnits(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_ClipUnits(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			CheckException(exception);
		}

		public void Color(double x, double y, PaintMethod paintMethod)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Color(base.Instance, x, y, (UIntPtr)(ulong)paintMethod, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Color(base.Instance, x, y, (UIntPtr)(ulong)paintMethod, out exception);
			}
			CheckException(exception);
		}

		public void Composite(double x, double y, double width, double height, CompositeOperator compositeOperator, IMagickImage image)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Composite(base.Instance, x, y, width, height, (UIntPtr)(ulong)compositeOperator, image.GetInstance(), out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Composite(base.Instance, x, y, width, height, (UIntPtr)(ulong)compositeOperator, image.GetInstance(), out exception);
			}
			CheckException(exception);
		}

		public void Density(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Density(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Density(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void Ellipse(double originX, double originY, double radiusX, double radiusY, double startDegrees, double endDegrees)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Ellipse(base.Instance, originX, originY, radiusX, radiusY, startDegrees, endDegrees, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Ellipse(base.Instance, originX, originY, radiusX, radiusY, startDegrees, endDegrees, out exception);
			}
			CheckException(exception);
		}

		public void FillColor(MagickColor value)
		{
			using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_FillColor(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_FillColor(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void FillOpacity(double value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_FillOpacity(base.Instance, value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_FillOpacity(base.Instance, value, out exception);
			}
			CheckException(exception);
		}

		public void FillPatternUrl(string url)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(url);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_FillPatternUrl(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_FillPatternUrl(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void FillRule(FillRule value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_FillRule(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_FillRule(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			CheckException(exception);
		}

		public void Font(string fontName)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(fontName);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Font(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Font(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void FontFamily(string family, FontStyleType style, FontWeight weight, FontStretch stretch)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(family);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_FontFamily(base.Instance, nativeInstance.Instance, (UIntPtr)(ulong)style, (UIntPtr)(ulong)weight, (UIntPtr)(ulong)stretch, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_FontFamily(base.Instance, nativeInstance.Instance, (UIntPtr)(ulong)style, (UIntPtr)(ulong)weight, (UIntPtr)(ulong)stretch, out exception);
			}
			CheckException(exception);
		}

		public void FontPointSize(double value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_FontPointSize(base.Instance, value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_FontPointSize(base.Instance, value, out exception);
			}
			CheckException(exception);
		}

		public void Gravity(Gravity value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Gravity(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Gravity(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			CheckException(exception);
		}

		public void Line(double startX, double startY, double endX, double endY)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Line(base.Instance, startX, startY, endX, endY, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Line(base.Instance, startX, startY, endX, endY, out exception);
			}
			CheckException(exception);
		}

		public void PathArcAbs(double x, double y, double radiusX, double radiusY, double rotationX, bool useLargeArc, bool useSweep)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathArcAbs(base.Instance, x, y, radiusX, radiusY, rotationX, useLargeArc, useSweep, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathArcAbs(base.Instance, x, y, radiusX, radiusY, rotationX, useLargeArc, useSweep, out exception);
			}
			CheckException(exception);
		}

		public void PathArcRel(double x, double y, double radiusX, double radiusY, double rotationX, bool useLargeArc, bool useSweep)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathArcRel(base.Instance, x, y, radiusX, radiusY, rotationX, useLargeArc, useSweep, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathArcRel(base.Instance, x, y, radiusX, radiusY, rotationX, useLargeArc, useSweep, out exception);
			}
			CheckException(exception);
		}

		public void Render()
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Render(base.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Render(base.Instance, out exception);
			}
			CheckException(exception);
		}

		public void Text(double x, double y, string text)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(text);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Text(base.Instance, x, y, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Text(base.Instance, x, y, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void PathClose()
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathClose(base.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathClose(base.Instance, out exception);
			}
			CheckException(exception);
		}

		public void PathCurveToAbs(double x1, double y1, double x2, double y2, double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathCurveToAbs(base.Instance, x1, y1, x2, y2, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathCurveToAbs(base.Instance, x1, y1, x2, y2, x, y, out exception);
			}
			CheckException(exception);
		}

		public void PathCurveToRel(double x1, double y1, double x2, double y2, double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathCurveToRel(base.Instance, x1, y1, x2, y2, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathCurveToRel(base.Instance, x1, y1, x2, y2, x, y, out exception);
			}
			CheckException(exception);
		}

		public void PathFinish()
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathFinish(base.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathFinish(base.Instance, out exception);
			}
			CheckException(exception);
		}

		public void PathLineToAbs(double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathLineToAbs(base.Instance, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathLineToAbs(base.Instance, x, y, out exception);
			}
			CheckException(exception);
		}

		public void PathLineToRel(double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathLineToRel(base.Instance, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathLineToRel(base.Instance, x, y, out exception);
			}
			CheckException(exception);
		}

		public void PathLineToHorizontalAbs(double x)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathLineToHorizontalAbs(base.Instance, x, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathLineToHorizontalAbs(base.Instance, x, out exception);
			}
			CheckException(exception);
		}

		public void PathLineToHorizontalRel(double x)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathLineToHorizontalRel(base.Instance, x, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathLineToHorizontalRel(base.Instance, x, out exception);
			}
			CheckException(exception);
		}

		public void PathLineToVerticalAbs(double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathLineToVerticalAbs(base.Instance, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathLineToVerticalAbs(base.Instance, y, out exception);
			}
			CheckException(exception);
		}

		public void PathLineToVerticalRel(double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathLineToVerticalRel(base.Instance, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathLineToVerticalRel(base.Instance, y, out exception);
			}
			CheckException(exception);
		}

		public void PathMoveToAbs(double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathMoveToAbs(base.Instance, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathMoveToAbs(base.Instance, x, y, out exception);
			}
			CheckException(exception);
		}

		public void PathMoveToRel(double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathMoveToRel(base.Instance, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathMoveToRel(base.Instance, x, y, out exception);
			}
			CheckException(exception);
		}

		public void PathQuadraticCurveToAbs(double x1, double y1, double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathQuadraticCurveToAbs(base.Instance, x1, y1, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathQuadraticCurveToAbs(base.Instance, x1, y1, x, y, out exception);
			}
			CheckException(exception);
		}

		public void PathQuadraticCurveToRel(double x1, double y1, double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathQuadraticCurveToRel(base.Instance, x1, y1, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathQuadraticCurveToRel(base.Instance, x1, y1, x, y, out exception);
			}
			CheckException(exception);
		}

		public void PathSmoothCurveToAbs(double x2, double y2, double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathSmoothCurveToAbs(base.Instance, x2, y2, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathSmoothCurveToAbs(base.Instance, x2, y2, x, y, out exception);
			}
			CheckException(exception);
		}

		public void PathSmoothCurveToRel(double x2, double y2, double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathSmoothCurveToRel(base.Instance, x2, y2, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathSmoothCurveToRel(base.Instance, x2, y2, x, y, out exception);
			}
			CheckException(exception);
		}

		public void PathSmoothQuadraticCurveToAbs(double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathSmoothQuadraticCurveToAbs(base.Instance, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathSmoothQuadraticCurveToAbs(base.Instance, x, y, out exception);
			}
			CheckException(exception);
		}

		public void PathSmoothQuadraticCurveToRel(double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathSmoothQuadraticCurveToRel(base.Instance, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathSmoothQuadraticCurveToRel(base.Instance, x, y, out exception);
			}
			CheckException(exception);
		}

		public void PathStart()
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PathStart(base.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PathStart(base.Instance, out exception);
			}
			CheckException(exception);
		}

		public void Point(double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Point(base.Instance, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Point(base.Instance, x, y, out exception);
			}
			CheckException(exception);
		}

		public void Polygon(PointInfoCollection coordinates, int length)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Polygon(base.Instance, coordinates.GetInstance(), (UIntPtr)(ulong)length, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Polygon(base.Instance, coordinates.GetInstance(), (UIntPtr)(ulong)length, out exception);
			}
			CheckException(exception);
		}

		public void Polyline(PointInfoCollection coordinates, int length)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Polyline(base.Instance, coordinates.GetInstance(), (UIntPtr)(ulong)length, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Polyline(base.Instance, coordinates.GetInstance(), (UIntPtr)(ulong)length, out exception);
			}
			CheckException(exception);
		}

		public void PopClipPath()
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PopClipPath(base.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PopClipPath(base.Instance, out exception);
			}
			CheckException(exception);
		}

		public void PopGraphicContext()
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PopGraphicContext(base.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PopGraphicContext(base.Instance, out exception);
			}
			CheckException(exception);
		}

		public void PopPattern()
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PopPattern(base.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PopPattern(base.Instance, out exception);
			}
			CheckException(exception);
		}

		public void PushClipPath(string clipPath)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(clipPath);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PushClipPath(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PushClipPath(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void PushGraphicContext()
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PushGraphicContext(base.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PushGraphicContext(base.Instance, out exception);
			}
			CheckException(exception);
		}

		public void PushPattern(string id, double x, double y, double width, double height)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(id);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_PushPattern(base.Instance, nativeInstance.Instance, x, y, width, height, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_PushPattern(base.Instance, nativeInstance.Instance, x, y, width, height, out exception);
			}
			CheckException(exception);
		}

		public void Rectangle(double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Rectangle(base.Instance, upperLeftX, upperLeftY, lowerRightX, lowerRightY, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Rectangle(base.Instance, upperLeftX, upperLeftY, lowerRightX, lowerRightY, out exception);
			}
			CheckException(exception);
		}

		public void Rotation(double angle)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Rotation(base.Instance, angle, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Rotation(base.Instance, angle, out exception);
			}
			CheckException(exception);
		}

		public void RoundRectangle(double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY, double cornerWidth, double cornerHeight)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_RoundRectangle(base.Instance, upperLeftX, upperLeftY, lowerRightX, lowerRightY, cornerWidth, cornerHeight, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_RoundRectangle(base.Instance, upperLeftX, upperLeftY, lowerRightX, lowerRightY, cornerWidth, cornerHeight, out exception);
			}
			CheckException(exception);
		}

		public void Scaling(double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Scaling(base.Instance, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Scaling(base.Instance, x, y, out exception);
			}
			CheckException(exception);
		}

		public void SkewX(double angle)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_SkewX(base.Instance, angle, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_SkewX(base.Instance, angle, out exception);
			}
			CheckException(exception);
		}

		public void SkewY(double angle)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_SkewY(base.Instance, angle, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_SkewY(base.Instance, angle, out exception);
			}
			CheckException(exception);
		}

		public void StrokeAntialias(bool isEnabled)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_StrokeAntialias(base.Instance, isEnabled, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_StrokeAntialias(base.Instance, isEnabled, out exception);
			}
			CheckException(exception);
		}

		public void StrokeColor(MagickColor value)
		{
			using INativeInstance nativeInstance = MagickColor.CreateInstance(value);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_StrokeColor(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_StrokeColor(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void StrokeDashArray(double[] dash, int length)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_StrokeDashArray(base.Instance, dash, (UIntPtr)(ulong)length, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_StrokeDashArray(base.Instance, dash, (UIntPtr)(ulong)length, out exception);
			}
			CheckException(exception);
		}

		public void StrokeDashOffset(double value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_StrokeDashOffset(base.Instance, value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_StrokeDashOffset(base.Instance, value, out exception);
			}
			CheckException(exception);
		}

		public void StrokeLineCap(LineCap value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_StrokeLineCap(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_StrokeLineCap(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			CheckException(exception);
		}

		public void StrokeLineJoin(LineJoin value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_StrokeLineJoin(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_StrokeLineJoin(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			CheckException(exception);
		}

		public void StrokeMiterLimit(int value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_StrokeMiterLimit(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_StrokeMiterLimit(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			CheckException(exception);
		}

		public void StrokeOpacity(double value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_StrokeOpacity(base.Instance, value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_StrokeOpacity(base.Instance, value, out exception);
			}
			CheckException(exception);
		}

		public void StrokePatternUrl(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_StrokePatternUrl(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_StrokePatternUrl(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void StrokeWidth(double value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_StrokeWidth(base.Instance, value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_StrokeWidth(base.Instance, value, out exception);
			}
			CheckException(exception);
		}

		public void TextAlignment(TextAlignment value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_TextAlignment(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_TextAlignment(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			CheckException(exception);
		}

		public void TextAntialias(bool isEnabled)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_TextAntialias(base.Instance, isEnabled, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_TextAntialias(base.Instance, isEnabled, out exception);
			}
			CheckException(exception);
		}

		public void TextDecoration(TextDecoration value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_TextDecoration(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_TextDecoration(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			CheckException(exception);
		}

		public void TextDirection(TextDirection value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_TextDirection(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_TextDirection(base.Instance, (UIntPtr)(ulong)value, out exception);
			}
			CheckException(exception);
		}

		public void TextEncoding(string encoding)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(encoding);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_TextEncoding(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_TextEncoding(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void TextInterlineSpacing(double value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_TextInterlineSpacing(base.Instance, value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_TextInterlineSpacing(base.Instance, value, out exception);
			}
			CheckException(exception);
		}

		public void TextInterwordSpacing(double value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_TextInterwordSpacing(base.Instance, value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_TextInterwordSpacing(base.Instance, value, out exception);
			}
			CheckException(exception);
		}

		public void TextKerning(double value)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_TextKerning(base.Instance, value, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_TextKerning(base.Instance, value, out exception);
			}
			CheckException(exception);
		}

		public void TextUnderColor(MagickColor color)
		{
			using INativeInstance nativeInstance = MagickColor.CreateInstance(color);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_TextUnderColor(base.Instance, nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_TextUnderColor(base.Instance, nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public void Translation(double x, double y)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Translation(base.Instance, x, y, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Translation(base.Instance, x, y, out exception);
			}
			CheckException(exception);
		}

		public void Viewbox(double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DrawingWand_Viewbox(base.Instance, upperLeftX, upperLeftY, lowerRightX, lowerRightY, out exception);
			}
			else
			{
				NativeMethods.X86.DrawingWand_Viewbox(base.Instance, upperLeftX, upperLeftY, lowerRightX, lowerRightY, out exception);
			}
			CheckException(exception);
		}
	}

	private NativeDrawingWand _nativeInstance;

	public DrawingWand(MagickImage image)
	{
		_nativeInstance = new NativeDrawingWand(image, image.Settings.Drawing);
	}

	public void Draw(IEnumerable<IDrawable> drawables)
	{
		foreach (IDrawingWand drawable in drawables)
		{
			drawable.Draw(this);
		}
		_nativeInstance.Render();
	}

	public void Affine(double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY)
	{
		_nativeInstance.Affine(scaleX, scaleY, shearX, shearY, translateX, translateY);
	}

	public void Alpha(double x, double y, PaintMethod paintMethod)
	{
		_nativeInstance.Alpha(x, y, paintMethod);
	}

	public void Arc(double startX, double startY, double endX, double endY, double startDegrees, double endDegrees)
	{
		_nativeInstance.Arc(startX, startY, endX, endY, startDegrees, endDegrees);
	}

	public void Bezier(IList<PointD> coordinates)
	{
		using PointInfoCollection pointInfoCollection = new PointInfoCollection(coordinates);
		_nativeInstance.Bezier(pointInfoCollection, pointInfoCollection.Count);
	}

	public void BorderColor(MagickColor color)
	{
		_nativeInstance.BorderColor(color);
	}

	public void Circle(double originX, double originY, double perimeterX, double perimeterY)
	{
		_nativeInstance.Circle(originX, originY, perimeterX, perimeterY);
	}

	public void ClipPath(string value)
	{
		_nativeInstance.ClipPath(value);
	}

	public void ClipRule(FillRule value)
	{
		_nativeInstance.ClipRule(value);
	}

	public void ClipUnits(ClipPathUnit value)
	{
		_nativeInstance.ClipUnits(value);
	}

	public void Color(double x, double y, PaintMethod paintMethod)
	{
		_nativeInstance.Color(x, y, paintMethod);
	}

	public void Composite(double x, double y, double width, double height, CompositeOperator compositeOperator, IMagickImage image)
	{
		_nativeInstance.Composite(x, y, width, height, compositeOperator, image);
	}

	public void Density(PointD value)
	{
		_nativeInstance.Density(value.ToString());
	}

	public void Dispose()
	{
		_nativeInstance.Dispose();
	}

	public void Ellipse(double originX, double originY, double radiusX, double radiusY, double startDegrees, double endDegrees)
	{
		_nativeInstance.Ellipse(originX, originY, radiusX, radiusY, startDegrees, endDegrees);
	}

	public void FillColor(MagickColor color)
	{
		_nativeInstance.FillColor(color);
	}

	public void FillOpacity(double value)
	{
		_nativeInstance.FillOpacity(value);
	}

	public void FillPatternUrl(string url)
	{
		_nativeInstance.FillPatternUrl(url);
	}

	public void FillRule(FillRule value)
	{
		_nativeInstance.FillRule(value);
	}

	public void Font(string fontName)
	{
		_nativeInstance.Font(fontName);
	}

	public void FontFamily(string family, FontStyleType style, FontWeight weight, FontStretch stretch)
	{
		_nativeInstance.FontFamily(family, style, weight, stretch);
	}

	public void FontPointSize(double value)
	{
		_nativeInstance.FontPointSize(value);
	}

	public void Gravity(Gravity value)
	{
		_nativeInstance.Gravity(value);
	}

	public void Line(double startX, double startY, double endX, double endY)
	{
		_nativeInstance.Line(startX, startY, endX, endY);
	}

	public void PathArcAbs(IEnumerable<PathArc> pathArcs)
	{
		foreach (PathArc pathArc in pathArcs)
		{
			_nativeInstance.PathArcAbs(pathArc.X, pathArc.Y, pathArc.RadiusX, pathArc.RadiusY, pathArc.RotationX, pathArc.UseLargeArc, pathArc.UseSweep);
		}
	}

	public void PathArcRel(IEnumerable<PathArc> pathArcs)
	{
		foreach (PathArc pathArc in pathArcs)
		{
			_nativeInstance.PathArcRel(pathArc.X, pathArc.Y, pathArc.RadiusX, pathArc.RadiusY, pathArc.RotationX, pathArc.UseLargeArc, pathArc.UseSweep);
		}
	}

	public void PathClose()
	{
		_nativeInstance.PathClose();
	}

	public void PathCurveToAbs(PointD controlPointStart, PointD controlPointEnd, PointD endPoint)
	{
		_nativeInstance.PathCurveToAbs(controlPointStart.X, controlPointStart.Y, controlPointEnd.X, controlPointEnd.Y, endPoint.X, endPoint.Y);
	}

	public void PathCurveToRel(PointD controlPointStart, PointD controlPointEnd, PointD endPoint)
	{
		_nativeInstance.PathCurveToRel(controlPointStart.X, controlPointStart.Y, controlPointEnd.X, controlPointEnd.Y, endPoint.X, endPoint.Y);
	}

	public void PathFinish()
	{
		_nativeInstance.PathFinish();
	}

	public void PathLineToAbs(IEnumerable<PointD> coordinates)
	{
		foreach (PointD coordinate in coordinates)
		{
			_nativeInstance.PathLineToAbs(coordinate.X, coordinate.Y);
		}
	}

	public void PathLineToHorizontalAbs(double x)
	{
		_nativeInstance.PathLineToHorizontalAbs(x);
	}

	public void PathLineToVerticalRel(double y)
	{
		_nativeInstance.PathLineToVerticalRel(y);
	}

	public void PathLineToHorizontalRel(double x)
	{
		_nativeInstance.PathLineToHorizontalRel(x);
	}

	public void PathLineToVerticalAbs(double y)
	{
		_nativeInstance.PathLineToVerticalAbs(y);
	}

	public void PathLineToRel(IEnumerable<PointD> coordinates)
	{
		foreach (PointD coordinate in coordinates)
		{
			_nativeInstance.PathLineToRel(coordinate.X, coordinate.Y);
		}
	}

	public void PathMoveToAbs(double x, double y)
	{
		_nativeInstance.PathMoveToAbs(x, y);
	}

	public void PathMoveToRel(double x, double y)
	{
		_nativeInstance.PathMoveToRel(x, y);
	}

	public void PathQuadraticCurveToAbs(PointD controlPoint, PointD endPoint)
	{
		_nativeInstance.PathQuadraticCurveToAbs(controlPoint.X, controlPoint.Y, endPoint.X, endPoint.Y);
	}

	public void PathQuadraticCurveToRel(PointD controlPoint, PointD endPoint)
	{
		_nativeInstance.PathQuadraticCurveToRel(controlPoint.X, controlPoint.Y, endPoint.X, endPoint.Y);
	}

	public void PathSmoothCurveToAbs(PointD controlPoint, PointD endPoint)
	{
		_nativeInstance.PathSmoothCurveToAbs(controlPoint.X, controlPoint.Y, endPoint.X, endPoint.Y);
	}

	public void PathSmoothCurveToRel(PointD controlPoint, PointD endPoint)
	{
		_nativeInstance.PathSmoothCurveToRel(controlPoint.X, controlPoint.Y, endPoint.X, endPoint.Y);
	}

	public void PathSmoothQuadraticCurveToAbs(PointD endPoint)
	{
		_nativeInstance.PathSmoothQuadraticCurveToAbs(endPoint.X, endPoint.Y);
	}

	public void PathSmoothQuadraticCurveToRel(PointD endPoint)
	{
		_nativeInstance.PathSmoothQuadraticCurveToRel(endPoint.X, endPoint.Y);
	}

	public void PathStart()
	{
		_nativeInstance.PathStart();
	}

	public void Point(double x, double y)
	{
		_nativeInstance.Point(x, y);
	}

	public void Polygon(IList<PointD> coordinates)
	{
		using PointInfoCollection pointInfoCollection = new PointInfoCollection(coordinates);
		_nativeInstance.Polygon(pointInfoCollection, pointInfoCollection.Count);
	}

	public void Polyline(IList<PointD> coordinates)
	{
		using PointInfoCollection pointInfoCollection = new PointInfoCollection(coordinates);
		_nativeInstance.Polyline(pointInfoCollection, pointInfoCollection.Count);
	}

	public void PopClipPath()
	{
		_nativeInstance.PopClipPath();
	}

	public void PopGraphicContext()
	{
		_nativeInstance.PopGraphicContext();
	}

	public void PopPattern()
	{
		_nativeInstance.PopPattern();
	}

	public void PushClipPath(string clipPath)
	{
		_nativeInstance.PushClipPath(clipPath);
	}

	public void PushGraphicContext()
	{
		_nativeInstance.PushGraphicContext();
	}

	public void PushPattern(string id, double x, double y, double width, double height)
	{
		_nativeInstance.PushPattern(id, x, y, width, height);
	}

	public void Rectangle(double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY)
	{
		_nativeInstance.Rectangle(upperLeftX, upperLeftY, lowerRightX, lowerRightY);
	}

	public void Rotation(double angle)
	{
		_nativeInstance.Rotation(angle);
	}

	public void RoundRectangle(double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY, double cornerWidth, double cornerHeight)
	{
		_nativeInstance.RoundRectangle(upperLeftX, upperLeftY, lowerRightX, lowerRightY, cornerWidth, cornerHeight);
	}

	public void Scaling(double x, double y)
	{
		_nativeInstance.Scaling(x, y);
	}

	public void SkewX(double angle)
	{
		_nativeInstance.SkewX(angle);
	}

	public void SkewY(double angle)
	{
		_nativeInstance.SkewY(angle);
	}

	public void StrokeAntialias(bool isEnabled)
	{
		_nativeInstance.StrokeAntialias(isEnabled);
	}

	public void StrokeColor(MagickColor color)
	{
		_nativeInstance.StrokeColor(color);
	}

	public void StrokeDashArray(double[] dash)
	{
		_nativeInstance.StrokeDashArray(dash, dash.Length);
	}

	public void StrokeDashOffset(double value)
	{
		_nativeInstance.StrokeDashOffset(value);
	}

	public void StrokeLineCap(LineCap value)
	{
		_nativeInstance.StrokeLineCap(value);
	}

	public void StrokeLineJoin(LineJoin value)
	{
		_nativeInstance.StrokeLineJoin(value);
	}

	public void StrokeMiterLimit(int value)
	{
		_nativeInstance.StrokeMiterLimit(value);
	}

	public void StrokeOpacity(double value)
	{
		_nativeInstance.StrokeOpacity(value);
	}

	public void StrokePatternUrl(string url)
	{
		_nativeInstance.StrokePatternUrl(url);
	}

	public void StrokeWidth(double value)
	{
		_nativeInstance.StrokeWidth(value);
	}

	public void Text(double x, double y, string value)
	{
		_nativeInstance.Text(x, y, value);
	}

	public void TextAlignment(TextAlignment value)
	{
		_nativeInstance.TextAlignment(value);
	}

	public void TextAntialias(bool isEnabled)
	{
		_nativeInstance.TextAntialias(isEnabled);
	}

	public void TextDecoration(TextDecoration value)
	{
		_nativeInstance.TextDecoration(value);
	}

	public void TextDirection(TextDirection value)
	{
		_nativeInstance.TextDirection(value);
	}

	public void TextEncoding(Encoding value)
	{
		if (value != null)
		{
			_nativeInstance.TextEncoding(value.WebName);
		}
	}

	public void TextInterlineSpacing(double spacing)
	{
		_nativeInstance.TextInterlineSpacing(spacing);
	}

	public void TextInterwordSpacing(double spacing)
	{
		_nativeInstance.TextInterwordSpacing(spacing);
	}

	public void TextKerning(double value)
	{
		_nativeInstance.TextKerning(value);
	}

	public void TextUnderColor(MagickColor color)
	{
		_nativeInstance.TextUnderColor(color);
	}

	public void Translation(double x, double y)
	{
		_nativeInstance.Translation(x, y);
	}

	public void Viewbox(double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY)
	{
		_nativeInstance.Viewbox(upperLeftX, upperLeftY, lowerRightX, lowerRightY);
	}
}
