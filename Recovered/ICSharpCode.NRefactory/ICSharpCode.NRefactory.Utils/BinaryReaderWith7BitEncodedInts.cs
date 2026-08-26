using System;
using System.IO;

namespace ICSharpCode.NRefactory.Utils
{
	public sealed class BinaryReaderWith7BitEncodedInts : BinaryReader
	{
		public BinaryReaderWith7BitEncodedInts(Stream stream)
			: base(stream)
		{
		}

		public override short ReadInt16()
		{
			return (short)(ushort)Read7BitEncodedInt();
		}

		[CLSCompliant(false)]
		public override ushort ReadUInt16()
		{
			return (ushort)Read7BitEncodedInt();
		}

		public override int ReadInt32()
		{
			return Read7BitEncodedInt();
		}

		[CLSCompliant(false)]
		public override uint ReadUInt32()
		{
			return (uint)Read7BitEncodedInt();
		}

		public override long ReadInt64()
		{
			return (long)ReadUInt64();
		}

		[CLSCompliant(false)]
		public override ulong ReadUInt64()
		{
			ulong num = 0uL;
			int num2 = 0;
			while (num2 < 64)
			{
				byte b = ReadByte();
				num = (ulong)((long)num | ((long)(b & 0x7F) << num2));
				num2 += 7;
				if ((b & 0x80) == 0)
				{
					return num;
				}
			}
			throw new FormatException("Invalid 7-bit int64");
		}
	}
}
