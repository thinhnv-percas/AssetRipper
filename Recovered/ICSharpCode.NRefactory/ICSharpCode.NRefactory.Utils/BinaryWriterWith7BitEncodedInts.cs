using System;
using System.IO;

namespace ICSharpCode.NRefactory.Utils
{
	public sealed class BinaryWriterWith7BitEncodedInts : BinaryWriter
	{
		public BinaryWriterWith7BitEncodedInts(Stream stream)
			: base(stream)
		{
		}

		public override void Write(short value)
		{
			Write7BitEncodedInt((ushort)value);
		}

		[CLSCompliant(false)]
		public override void Write(ushort value)
		{
			Write7BitEncodedInt(value);
		}

		public override void Write(int value)
		{
			Write7BitEncodedInt(value);
		}

		[CLSCompliant(false)]
		public override void Write(uint value)
		{
			Write7BitEncodedInt((int)value);
		}

		public override void Write(long value)
		{
			Write((ulong)value);
		}

		[CLSCompliant(false)]
		public override void Write(ulong value)
		{
			while (value >= 128)
			{
				Write((byte)(value | 0x80));
				value >>= 7;
			}
			Write((byte)value);
		}
	}
}
