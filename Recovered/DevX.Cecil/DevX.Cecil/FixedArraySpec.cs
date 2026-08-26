namespace DevX.Cecil
{
	public sealed class FixedArraySpec : MarshalSpec
	{
		private int m_numElem;

		private NativeType m_elemType;

		public int NumElem
		{
			get
			{
				return m_numElem;
			}
			set
			{
				m_numElem = value;
			}
		}

		public NativeType ElemType
		{
			get
			{
				return m_elemType;
			}
			set
			{
				m_elemType = value;
			}
		}

		public FixedArraySpec(IHasMarshalSpec container)
			: base(NativeType.FIXEDARRAY, container)
		{
		}

		public override MarshalSpec CloneInto(IHasMarshalSpec container)
		{
			FixedArraySpec fixedArraySpec = new FixedArraySpec(container);
			fixedArraySpec.m_numElem = m_numElem;
			fixedArraySpec.m_elemType = m_elemType;
			return fixedArraySpec;
		}
	}
}
