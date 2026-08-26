namespace DevX.Cecil
{
	public sealed class FixedSysStringSpec : MarshalSpec
	{
		private int m_size;

		public int Size
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

		public FixedSysStringSpec(IHasMarshalSpec container)
			: base(NativeType.FIXEDSYSSTRING, container)
		{
		}

		public override MarshalSpec CloneInto(IHasMarshalSpec container)
		{
			FixedSysStringSpec fixedSysStringSpec = new FixedSysStringSpec(container);
			fixedSysStringSpec.m_size = m_size;
			return fixedSysStringSpec;
		}
	}
}
