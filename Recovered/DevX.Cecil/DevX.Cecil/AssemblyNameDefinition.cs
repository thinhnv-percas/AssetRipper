using System;

namespace DevX.Cecil
{
	public sealed class AssemblyNameDefinition : AssemblyNameReference
	{
		public override byte[] Hash => new byte[0];

		public AssemblyNameDefinition()
		{
		}

		public AssemblyNameDefinition(string name, string culture, Version version)
			: base(name, culture, version)
		{
		}

		public override void Accept(IReflectionStructureVisitor visitor)
		{
			visitor.VisitAssemblyNameDefinition(this);
		}
	}
}
