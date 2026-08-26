using System;
using System.IO;

namespace Microsoft.VisualStudio.Composition;

internal static class CompressedUInt
{
	internal static void WriteCompressedUInt(BinaryWriter writer, uint value)
	{
		if (value <= 63)
		{
			writer.Write((byte)value);
		}
		else if (value <= 16383)
		{
			writer.Write((byte)((value >> 8) | 0x40));
			writer.Write((byte)value);
		}
		else if (value <= 4194303)
		{
			writer.Write((byte)((value >> 16) | 0x80));
			writer.Write((byte)(value >> 8));
			writer.Write((byte)value);
		}
		else
		{
			writer.Write((byte)192);
			writer.Write(value);
		}
	}

	internal static uint ReadCompressedUInt(BinaryReader reader)
	{
		byte b = reader.ReadByte();
		byte b2 = (byte)(b & 0xC0);
		byte b3 = (byte)(b & 0x3F);
		switch (b2)
		{
		case 0:
			return b;
		case 64:
		{
			byte b4 = reader.ReadByte();
			return (uint)((b3 << 8) | b4);
		}
		case 128:
		{
			uint num = (uint)(b3 << 16);
			num |= (uint)(reader.ReadByte() << 8);
			return num | reader.ReadByte();
		}
		case 192:
			return reader.ReadUInt32();
		default:
			throw new NotSupportedException();
		}
	}
}
