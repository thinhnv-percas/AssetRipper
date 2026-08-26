namespace DevX.Cecil.Metadata
{
	public struct MetadataToken
	{
		private uint m_rid;

		private TokenType m_type;

		public static readonly MetadataToken Zero = new MetadataToken(TokenType.Module, 0u);

		public uint RID => m_rid;

		public TokenType TokenType => m_type;

		public MetadataToken(int token)
		{
			m_type = (TokenType)(token & 4278190080u);
			m_rid = (uint)(token & 0xFFFFFF);
		}

		public MetadataToken(TokenType table, uint rid)
		{
			m_type = table;
			m_rid = rid;
		}

		internal static MetadataToken FromMetadataRow(TokenType table, int rowIndex)
		{
			return new MetadataToken(table, (uint)(rowIndex + 1));
		}

		public uint ToUInt()
		{
			return (uint)((int)m_type | (int)m_rid);
		}

		public override int GetHashCode()
		{
			return (int)ToUInt();
		}

		public override bool Equals(object other)
		{
			if (other is MetadataToken)
			{
				return Equals((MetadataToken)other);
			}
			return false;
		}

		private bool Equals(MetadataToken other)
		{
			return other.m_rid == m_rid && other.m_type == m_type;
		}

		public override string ToString()
		{
			return string.Format("{0} [0x{1}]", m_type, m_rid.ToString("x4"));
		}

		public static bool operator ==(MetadataToken one, MetadataToken other)
		{
			return one.Equals(other);
		}

		public static bool operator !=(MetadataToken one, MetadataToken other)
		{
			return !one.Equals(other);
		}
	}
}
