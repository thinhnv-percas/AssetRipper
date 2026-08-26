using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace System.Reflection.Internal;

internal static class MemoryMapLightUp
{
	internal static bool IsAvailable => true;

	internal static IDisposable CreateMemoryMap(Stream stream)
	{
		return (IDisposable)MemoryMappedFile.CreateFromFile((FileStream)stream, (string)null, 0L, (MemoryMappedFileAccess)1, (HandleInheritability)0, true);
	}

	internal static IDisposable CreateViewAccessor(object memoryMap, long start, int size)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			return (IDisposable)((MemoryMappedFile)memoryMap).CreateViewAccessor(start, (long)size, (MemoryMappedFileAccess)1);
		}
		catch (UnauthorizedAccessException ex)
		{
			throw new IOException(ex.Message, ex);
		}
	}

	internal static bool TryGetSafeBufferAndPointerOffset(object accessor, out SafeBuffer safeBuffer, out long offset)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		MemoryMappedViewAccessor val = (MemoryMappedViewAccessor)accessor;
		safeBuffer = (SafeBuffer)(object)val.SafeMemoryMappedViewHandle;
		offset = val.PointerOffset;
		return true;
	}
}
