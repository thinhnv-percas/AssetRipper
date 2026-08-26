namespace DevX.Cecil
{
	public sealed class EmbeddedResource : Resource
	{
		private byte[] m_data;

		public byte[] Data
		{
			get
			{
				return m_data;
			}
			set
			{
				m_data = value;
			}
		}

		public EmbeddedResource(string name, ManifestResourceAttributes flags)
			: base(name, flags)
		{
		}

		public EmbeddedResource(string name, ManifestResourceAttributes flags, byte[] data)
			: base(name, flags)
		{
			m_data = data;
		}

		public override void Accept(IReflectionStructureVisitor visitor)
		{
			visitor.VisitEmbeddedResource(this);
		}
	}
}
