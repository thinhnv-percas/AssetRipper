namespace DevX.Cecil
{
	public sealed class ArrayMarshalSpec : MarshalSpec
	{
		private NativeType m_elemType;

		private int m_paramNum;

		private int m_elemMult;

		private int m_numElem;

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

		public int ParamNum
		{
			get
			{
				return m_paramNum;
			}
			set
			{
				m_paramNum = value;
			}
		}

		public int ElemMult
		{
			get
			{
				return m_elemMult;
			}
			set
			{
				m_elemMult = value;
			}
		}

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

		public ArrayMarshalSpec(IHasMarshalSpec container)
			: base(NativeType.ARRAY, container)
		{
		}

		public override MarshalSpec CloneInto(IHasMarshalSpec container)
		{
			ArrayMarshalSpec arrayMarshalSpec = new ArrayMarshalSpec(container);
			arrayMarshalSpec.m_elemType = m_elemType;
			arrayMarshalSpec.m_paramNum = m_paramNum;
			arrayMarshalSpec.m_elemMult = m_elemMult;
			arrayMarshalSpec.m_numElem = m_numElem;
			return arrayMarshalSpec;
		}
	}
}
