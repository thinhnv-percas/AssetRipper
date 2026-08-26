using ICSharpCode.NRefactory.Semantics;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public class ReferenceResult
	{
		public AstNode Node
		{
			get;
			private set;
		}

		public LocalResolveResult ResolveResult
		{
			get;
			private set;
		}

		public ReferenceResult(AstNode node, LocalResolveResult resolveResult)
		{
			Node = node;
			ResolveResult = resolveResult;
		}
	}
}
