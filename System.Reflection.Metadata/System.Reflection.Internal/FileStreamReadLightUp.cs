using System.IO;
using System.Runtime.InteropServices;

namespace System.Reflection.Internal;

internal static class FileStreamReadLightUp
{
	internal static bool readFileNotAvailable = Path.DirectorySeparatorChar != '\\';

	internal static bool safeFileHandleNotAvailable = false;

	internal static bool IsFileStream(Stream stream)
	{
		return stream is FileStream;
	}

	internal static SafeHandle GetSafeFileHandle(Stream stream)
	{
		SafeHandle safeFileHandle;
		try
		{
			safeFileHandle = ((FileStream)stream).SafeFileHandle;
		}
		catch
		{
			return null;
		}
		if (safeFileHandle != null && safeFileHandle.IsInvalid)
		{
			return null;
		}
		return safeFileHandle;
	}

	internal unsafe static bool TryReadFile(Stream stream, byte* buffer, long start, int size)
	{
		if (readFileNotAvailable)
		{
			return false;
		}
		SafeHandle safeFileHandle = GetSafeFileHandle(stream);
		if (safeFileHandle == null)
		{
			return false;
		}
		bool flag = false;
		int bytesRead = 0;
		try
		{
			flag = ReadFile(safeFileHandle, buffer, size, out bytesRead, IntPtr.Zero);
		}
		catch
		{
			readFileNotAvailable = true;
			return false;
		}
		if (!flag || bytesRead != size)
		{
			return false;
		}
		return true;
	}

	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal unsafe static extern bool ReadFile(SafeHandle fileHandle, byte* buffer, int byteCount, out int bytesRead, IntPtr overlapped);
}
