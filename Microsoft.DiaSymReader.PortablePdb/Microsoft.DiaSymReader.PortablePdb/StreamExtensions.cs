using System.IO;

namespace Microsoft.DiaSymReader.PortablePdb;

internal static class StreamExtensions
{
	internal static int TryReadAll(this Stream stream, byte[] buffer, int offset, int count)
	{
		int num = 0;
		int i;
		for (i = 0; i < count; i += num)
		{
			num = stream.Read(buffer, offset + i, count - i);
			if (num == 0)
			{
				break;
			}
		}
		return i;
	}
}
