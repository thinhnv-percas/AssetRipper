using System;
using System.IO;

namespace Microsoft.DiaSymReader.Tools;

internal static class StreamUtilities
{
	public static void ValidateStream(Stream stream, string parameterName, bool readRequired = false, bool writeRequired = false, bool seekRequired = false)
	{
		if (stream == null)
		{
			throw new ArgumentNullException(parameterName);
		}
		if (readRequired && !stream.CanRead)
		{
			throw new ArgumentException(ConverterResources.StreamMustBeReadable, parameterName);
		}
		if (writeRequired && !stream.CanWrite)
		{
			throw new ArgumentException(ConverterResources.StreamMustBeWritable, parameterName);
		}
		if (seekRequired && !stream.CanSeek)
		{
			throw new ArgumentException(ConverterResources.StreamMustBeSeakable, parameterName);
		}
	}
}
