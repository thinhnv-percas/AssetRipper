using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.Utils;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public class LocalReferenceFinder
	{
		private class LocalReferenceLocator : DepthFirstAstVisitor
		{
			private CSharpAstResolver resolver;

			private LocalReferenceFinder referenceFinder;

			private IList<IVariable> processedVariables = new List<IVariable>();

			public LocalReferenceLocator(CSharpAstResolver resolver, LocalReferenceFinder referenceFinder)
			{
				this.resolver = resolver;
				this.referenceFinder = referenceFinder;
			}

			public void ProccessRoot(AstNode rootNode)
			{
				rootNode.AcceptVisitor(this);
				referenceFinder.visitedRoots.Add(rootNode);
			}

			public override void VisitCSharpTokenNode(CSharpTokenNode token)
			{
			}

			protected override void VisitChildren(AstNode node)
			{
				if (!referenceFinder.visitedRoots.Contains(node))
				{
					LocalResolveResult localResolveResult = resolver.Resolve(node) as LocalResolveResult;
					if (localResolveResult != null && !processedVariables.Contains(localResolveResult.Variable))
					{
						referenceFinder.references.Add(localResolveResult.Variable, new ReferenceResult(node, localResolveResult));
						processedVariables.Add(localResolveResult.Variable);
						base.VisitChildren(node);
						processedVariables.Remove(localResolveResult.Variable);
					}
					else
					{
						base.VisitChildren(node);
					}
				}
			}
		}

		private LocalReferenceLocator locator;

		private MultiDictionary<IVariable, ReferenceResult> references = new MultiDictionary<IVariable, ReferenceResult>();

		private HashSet<AstNode> visitedRoots = new HashSet<AstNode>();

		public LocalReferenceFinder(CSharpAstResolver resolver)
		{
			locator = new LocalReferenceLocator(resolver, this);
		}

		public LocalReferenceFinder(BaseRefactoringContext context)
			: this(context.Resolver)
		{
		}

		private void VisitIfNeccessary(AstNode rootNode)
		{
			for (AstNode astNode = rootNode; astNode != null; astNode = astNode.Parent)
			{
				if (visitedRoots.Contains(astNode))
				{
					return;
				}
			}
			locator.ProccessRoot(rootNode);
		}

		public IList<ReferenceResult> FindReferences(AstNode rootNode, IVariable variable)
		{
			lock (locator)
			{
				VisitIfNeccessary(rootNode);
				if (!((ILookup<IVariable, ReferenceResult>)references).Contains(variable))
				{
					return new List<ReferenceResult>();
				}
				return references[variable].ToList();
			}
		}
	}
}
