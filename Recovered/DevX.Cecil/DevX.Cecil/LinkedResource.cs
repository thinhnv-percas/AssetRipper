namespace DevX.Cecil
{
	public sealed class LinkedResource : Resource
	{
		private byte[] m_hash;

		private string m_file;

		public byte[] Hash
		{
			get
			{
				return m_hash;
			}
			set
			{
				m_hash = value;
			}
		}

		public string File
		{
			get
			{
				return m_file;
			}
			set
			{
				m_file = value;
			}
		}

		public LinkedResource(string name, ManifestResourceAttributes flags, string file)
			: base(name, flags)
		{
			m_file = file;
		}

		public override void Accept(IReflectionStructureVisitor visitor)
		{
			visitor.VisitLinkedResource(this);
		}
	}
}
