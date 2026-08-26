using System;

namespace ICSharpCode.SharpZipLib.Checksum
{
	public sealed class Adler32 : IChecksum
	{
		private static readonly uint _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A = 65521u;

		private uint _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020;

		public long Value => _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020;

		public Adler32()
		{
			Reset();
		}

		public void Reset()
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020 = 1u;
		}

		public void Update(int bval)
		{
			uint num = _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020 & 0xFFFF;
			uint num2 = _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020 >> 16;
			num = (uint)((int)num + (bval & 0xFF)) % _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A;
			num2 = (num + num2) % _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A;
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020 = (num2 << 16) + num;
		}

		public void Update(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			Update(buffer, 0, buffer.Length);
		}

		public void Update(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "cannot be less than zero");
			}
			if (offset >= buffer.Length)
			{
				throw new ArgumentOutOfRangeException("offset", "not a valid index into buffer");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "cannot be less than zero");
			}
			if (offset + count > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("count", "exceeds buffer size");
			}
			uint num = _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020 & 0xFFFF;
			uint num2 = _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020 >> 16;
			while (count > 0)
			{
				int num3 = 3800;
				if (num3 > count)
				{
					num3 = count;
				}
				count -= num3;
				while (--num3 >= 0)
				{
					num = (uint)((int)num + (buffer[offset++] & 0xFF));
					num2 += num;
				}
				num %= _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A;
				num2 %= _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A;
			}
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020 = ((num2 << 16) | num);
		}
	}
}
