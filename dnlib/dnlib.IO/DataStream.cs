using System;
using System.Text;

namespace dnlib.IO;

public abstract class DataStream
{
	public unsafe abstract void ReadBytes(uint offset, void* destination, int length);

	public abstract void ReadBytes(uint offset, byte[] destination, int destinationIndex, int length);

	public abstract byte ReadByte(uint offset);

	public abstract ushort ReadUInt16(uint offset);

	public abstract uint ReadUInt32(uint offset);

	public abstract ulong ReadUInt64(uint offset);

	public abstract float ReadSingle(uint offset);

	public abstract double ReadDouble(uint offset);

	public virtual Guid ReadGuid(uint offset)
	{
		return new Guid(ReadUInt32(offset), ReadUInt16(offset + 4), ReadUInt16(offset + 6), ReadByte(offset + 8), ReadByte(offset + 9), ReadByte(offset + 10), ReadByte(offset + 11), ReadByte(offset + 12), ReadByte(offset + 13), ReadByte(offset + 14), ReadByte(offset + 15));
	}

	public abstract string ReadUtf16String(uint offset, int chars);

	public abstract string ReadString(uint offset, int length, Encoding encoding);

	public abstract bool TryGetOffsetOf(uint offset, uint endOffset, byte value, out uint valueOffset);
}
