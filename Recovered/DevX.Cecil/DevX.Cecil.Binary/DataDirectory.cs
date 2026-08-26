namespace DevX.Cecil.Binary
{
	public struct DataDirectory
	{
		public static readonly DataDirectory Zero = new DataDirectory(RVA.Zero, 0u);

		private RVA m_virtualAddress;

		private uint m_size;

		public RVA VirtualAddress
		{
			get
			{
				return m_virtualAddress;
			}
			set
			{
				m_virtualAddress = value;
			}
		}

		public uint Size
		{
			get
			{
				return m_size;
			}
			set
			{
				m_size = value;
			}
		}

		public DataDirectory(RVA virtualAddress, uint size)
		{
			m_virtualAddress = virtualAddress;
			m_size = size;
		}

		public override int GetHashCode()
		{
			return m_virtualAddress.GetHashCode() ^ (int)(m_size << 1);
		}

		public override bool Equals(object other)
		{
			if (other is DataDirectory)
			{
				DataDirectory dataDirectory = (DataDirectory)other;
				return m_virtualAddress == dataDirectory.m_virtualAddress && m_size == dataDirectory.m_size;
			}
			return false;
		}

		public override string ToString()
		{
			return string.Format("{0} [{1}]", m_virtualAddress, m_size.ToString("X"));
		}

		public static bool operator ==(DataDirectory one, DataDirectory other)
		{
			return one.m_virtualAddress == other.m_virtualAddress && one.m_size == other.m_size;
		}

		public static bool operator !=(DataDirectory one, DataDirectory other)
		{
			return one.m_virtualAddress != other.m_virtualAddress || one.m_size != other.m_size;
		}
	}
}
