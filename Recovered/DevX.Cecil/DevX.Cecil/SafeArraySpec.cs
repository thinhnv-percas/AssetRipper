namespace DevX.Cecil
{
	public sealed class SafeArraySpec : MarshalSpec
	{
		private VariantType m_elemType;

		public VariantType ElemType
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

		public SafeArraySpec(IHasMarshalSpec container)
			: base(NativeType.SAFEARRAY, container)
		{
		}

		public override MarshalSpec CloneInto(IHasMarshalSpec container)
		{
			SafeArraySpec safeArraySpec = new SafeArraySpec(container);
			safeArraySpec.m_elemType = m_elemType;
			return safeArraySpec;
		}
	}
}
