using System;
using dnlib.IO;
using dnlib.PE;

namespace dnlib.DotNet.Writer;

public sealed class ByteArrayChunk : IReuseChunk, IChunk
{
	private readonly byte[] array;

	private FileOffset offset;

	private RVA rva;

	public FileOffset FileOffset => offset;

	public RVA RVA => rva;

	public byte[] Data => array;

	public ByteArrayChunk(byte[] array)
	{
		this.array = array ?? Array2.Empty<byte>();
	}

	bool IReuseChunk.CanReuse(RVA origRva, uint origSize)
	{
		return (uint)array.Length <= origSize;
	}

	public void SetOffset(FileOffset offset, RVA rva)
	{
		this.offset = offset;
		this.rva = rva;
	}

	public uint GetFileLength()
	{
		return (uint)array.Length;
	}

	public uint GetVirtualSize()
	{
		return GetFileLength();
	}

	public void WriteTo(DataWriter writer)
	{
		writer.WriteBytes(array);
	}

	public override int GetHashCode()
	{
		return Utils.GetHashCode(array);
	}

	public override bool Equals(object obj)
	{
		return obj is ByteArrayChunk byteArrayChunk && Utils.Equals(array, byteArrayChunk.array);
	}
}
