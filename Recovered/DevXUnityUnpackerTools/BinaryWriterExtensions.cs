using System;
using System.IO;

public static class BinaryWriterExtensions
{
	public static void EncodeInt32(BinaryWriter writer, int value)
	{
		if (writer == null)
		{
			throw new ArgumentNullException("writer");
		}
		if (value < 0)
		{
			throw new ArgumentOutOfRangeException("value", value, "value must be 0 or greater");
		}
		bool flag = true;
		while (flag || value > 0)
		{
			flag = false;
			byte b = (byte)(value & 0x7F);
			value >>= 7;
			if (value > 0)
			{
				b = (byte)(b | 0x80);
			}
			writer.Write(b);
		}
	}

	public static int DecodeInt32(BinaryReader reader)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		bool flag = true;
		int num = 0;
		int num2 = 0;
		while (flag)
		{
			byte b = reader.ReadByte();
			flag = ((b & 0x80) != 0);
			num |= (b & 0x7F) << num2;
			num2 += 7;
		}
		return num;
	}
}
