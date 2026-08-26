namespace DevX.Cecil
{
	public class MarshalSpec
	{
		private NativeType m_natIntr;

		private IHasMarshalSpec m_container;

		public NativeType NativeIntrinsic
		{
			get
			{
				return m_natIntr;
			}
			set
			{
				m_natIntr = value;
			}
		}

		public IHasMarshalSpec Container
		{
			get
			{
				return m_container;
			}
			set
			{
				m_container = value;
			}
		}

		public MarshalSpec(NativeType natIntr, IHasMarshalSpec container)
		{
			m_natIntr = natIntr;
			m_container = container;
		}

		public virtual void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitMarshalSpec(this);
		}

		public virtual MarshalSpec CloneInto(IHasMarshalSpec container)
		{
			return new MarshalSpec(m_natIntr, container);
		}
	}
}
