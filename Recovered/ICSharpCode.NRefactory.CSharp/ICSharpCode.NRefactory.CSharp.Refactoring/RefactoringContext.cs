using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public abstract class RefactoringContext : BaseRefactoringContext
	{
		public abstract TextLocation Location
		{
			get;
		}

		public RefactoringContext(CSharpAstResolver resolver, CancellationToken cancellationToken)
			: base(resolver, cancellationToken)
		{
		}

		public TypeSystemAstBuilder CreateTypeSystemAstBuilder()
		{
			AstNode node = GetNode() ?? RootNode.GetNodeAt(Location) ?? RootNode;
			return new TypeSystemAstBuilder(base.Resolver.GetResolverStateBefore(node));
		}

		public virtual AstType CreateShortType(IType fullType)
		{
			return CreateTypeSystemAstBuilder().ConvertType(fullType);
		}

		public virtual AstType CreateShortType(string ns, string name, int typeParameterCount = 0)
		{
			return CreateTypeSystemAstBuilder().ConvertType(new TopLevelTypeName(ns, name, typeParameterCount));
		}

		public virtual IEnumerable<AstNode> GetSelectedNodes()
		{
			if (!IsSomethingSelected)
			{
				return Enumerable.Empty<AstNode>();
			}
			return RootNode.GetNodesBetween(SelectionStart, SelectionEnd);
		}

		public AstNode GetNode()
		{
			return RootNode.GetNodeAt(Location);
		}

		public AstNode GetNode(Predicate<AstNode> pred)
		{
			return RootNode.GetNodeAt(Location, pred);
		}

		public T GetNode<T>() where T : AstNode
		{
			return RootNode.GetNodeAt<T>(Location);
		}

		public CSharpTypeResolveContext GetTypeResolveContext()
		{
			if (UnresolvedFile != null)
			{
				return UnresolvedFile.GetTypeResolveContext(base.Compilation, Location);
			}
			return null;
		}

		public virtual string GetNameProposal(string name, bool camelCase = true)
		{
			return GetNameProposal(name, Location, camelCase);
		}
	}
}
