namespace DevX.Cecil.Binary
{
	public struct RVA
	{
		public static readonly RVA Zero = new RVA(0u);

		private uint m_rva;

		public uint Value
		{
			get
			{
				return m_rva;
			}
			set
			{
				m_rva = value;
			}
		}

		public RVA(uint rva)
		{
			m_rva = rva;
		}

		public override int GetHashCode()
		{
			return (int)m_rva;
		}

		public override bool Equals(object other)
		{
			if (other is RVA)
			{
				uint rva = m_rva;
				RVA rVA = (RVA)other;
				return rva == rVA.m_rva;
			}
			return false;
		}

		public override string ToString()
		{
			return string.Format("0x{0}", m_rva.ToString("X"));
		}

		public static bool operator ==(RVA one, RVA other)
		{
			return one.m_rva == other.m_rva;
		}

		public static bool operator !=(RVA one, RVA other)
		{
			return one.m_rva != other.m_rva;
		}

		public static bool operator <(RVA one, RVA other)
		{
			return one.m_rva < other.m_rva;
		}

		public static bool operator >(RVA one, RVA other)
		{
			return one.m_rva > other.m_rva;
		}

		public static bool operator <=(RVA one, RVA other)
		{
			return one.m_rva <= other.m_rva;
		}

		public static bool operator >=(RVA one, RVA other)
		{
			return one.m_rva >= other.m_rva;
		}

		public static RVA operator +(RVA rva, uint x)
		{
			return new RVA(rva.m_rva + x);
		}

		public static RVA operator -(RVA rva, uint x)
		{
			return new RVA(rva.m_rva - x);
		}

		public static implicit operator RVA(uint val)
		{
			return (val != 0) ? new RVA(val) : Zero;
		}

		public static implicit operator uint(RVA rva)
		{
			return rva.m_rva;
		}
	}
}
