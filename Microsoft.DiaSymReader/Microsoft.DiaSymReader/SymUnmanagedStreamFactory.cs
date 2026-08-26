using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.DiaSymReader;

public static class SymUnmanagedStreamFactory
{
	public static IStream CreateStream(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (!stream.CanSeek)
		{
			throw new ArgumentException("Stream must support seek operation.", "stream");
		}
		return new ComStreamWrapper(stream);
	}
}
