namespace System.Security.Cryptography
{
	internal class SHA1Managed
	{
		private SHA1Internal sha;

		public SHA1Managed()
		{
			sha = new SHA1Internal();
		}

		public byte[] ComputeHash(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return ComputeHash(buffer, 0, buffer.Length);
		}

		public byte[] ComputeHash(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "< 0");
			}
			if (count < 0)
			{
				throw new ArgumentException("count", "< 0");
			}
			if (offset > buffer.Length - count)
			{
				throw new ArgumentException("offset + count", "Overflow");
			}
			HashCore(buffer, offset, count);
			byte[] result = HashFinal();
			Initialize();
			return result;
		}

		protected void HashCore(byte[] rgb, int ibStart, int cbSize)
		{
			sha.HashCore(rgb, ibStart, cbSize);
		}

		protected byte[] HashFinal()
		{
			return sha.HashFinal();
		}

		protected void Initialize()
		{
			sha.Initialize();
		}
	}
}
