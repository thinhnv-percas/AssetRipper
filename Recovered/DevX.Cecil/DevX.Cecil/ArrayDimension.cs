namespace DevX.Cecil
{
	public sealed class ArrayDimension
	{
		private int m_lowerBound;

		private int m_upperBound;

		public int LowerBound
		{
			get
			{
				return m_lowerBound;
			}
			set
			{
				m_lowerBound = value;
			}
		}

		public int UpperBound
		{
			get
			{
				return m_upperBound;
			}
			set
			{
				m_upperBound = value;
			}
		}

		public ArrayDimension(int lb, int ub)
		{
			m_lowerBound = lb;
			m_upperBound = ub;
		}

		public override string ToString()
		{
			if (m_upperBound == 0)
			{
				return string.Empty;
			}
			return m_lowerBound + "..." + m_upperBound;
		}
	}
}
