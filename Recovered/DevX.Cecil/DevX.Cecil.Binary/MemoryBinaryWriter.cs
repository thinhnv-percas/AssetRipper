using System.IO;
using System.Text;

namespace DevX.Cecil.Binary
{
	internal sealed class MemoryBinaryWriter : BinaryWriter
	{
		public MemoryStream MemoryStream => (MemoryStream)BaseStream;

		public MemoryBinaryWriter()
			: base(new MemoryStream())
		{
		}

		public MemoryBinaryWriter(Encoding enc)
			: base(new MemoryStream(), enc)
		{
		}

		public void Empty()
		{
			BaseStream.Position = 0L;
			BaseStream.SetLength(0L);
		}

		public void Write(MemoryBinaryWriter writer)
		{
			writer.MemoryStream.WriteTo(BaseStream);
		}

		public byte[] ToArray()
		{
			return MemoryStream.ToArray();
		}

		public void QuadAlign()
		{
			BaseStream.Position += 3L;
			BaseStream.Position &= -4L;
			if (BaseStream.Position > BaseStream.Length)
			{
				BaseStream.SetLength(BaseStream.Position);
			}
		}
	}
}
