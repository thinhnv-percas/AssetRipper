using System.IO;
using System.Reflection.PortableExecutable;

namespace DecompTools.Decompiler.Metadata;

internal sealed class ResourceMemoryStream : UnmanagedMemoryStream
{
	private readonly PEReader peReader;

	public unsafe ResourceMemoryStream(PEReader peReader, byte* data, long length)
		: base(data, length, length, FileAccess.Read)
	{
		this.peReader = peReader;
	}
}
