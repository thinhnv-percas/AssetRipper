using ICSharpCode.NRefactory.TypeSystem;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.Analysis
{
	public sealed class TypeGraphNode
	{
		private readonly ITypeDefinition typeDef;

		private readonly List<TypeGraphNode> baseTypes = new List<TypeGraphNode>();

		private readonly List<TypeGraphNode> derivedTypes = new List<TypeGraphNode>();

		public ITypeDefinition TypeDefinition => typeDef;

		public IList<TypeGraphNode> DerivedTypes => derivedTypes;

		public IList<TypeGraphNode> BaseTypes => baseTypes;

		public TypeGraphNode(ITypeDefinition typeDef)
		{
			this.typeDef = typeDef;
		}
	}
}
