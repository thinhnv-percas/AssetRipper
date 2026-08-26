namespace DevX.Cecil
{
	public sealed class AssemblyLinkedResource : Resource
	{
		private AssemblyNameReference m_asmRef;

		public AssemblyNameReference Assembly
		{
			get
			{
				return m_asmRef;
			}
			set
			{
				m_asmRef = value;
			}
		}

		public AssemblyLinkedResource(string name, ManifestResourceAttributes flags, AssemblyNameReference asmRef)
			: base(name, flags)
		{
			m_asmRef = asmRef;
		}

		public override void Accept(IReflectionStructureVisitor visitor)
		{
			visitor.VisitAssemblyLinkedResource(this);
		}
	}
}
