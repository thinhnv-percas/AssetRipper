using System;

namespace ImageMagick;

internal static class NativeLibrary
{
	public const string X86Name = "Magick.NET-Q8-x86.Native.dll";

	public const string X64Name = "Magick.NET-Q8-x64.Native.dll";

	public static bool Is64Bit => IntPtr.Size == 8;
}
