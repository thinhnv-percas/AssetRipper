using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	public class NodeListResolveVisitorNavigator : IResolveVisitorNavigator
	{
		private readonly Dictionary<AstNode, ResolveVisitorNavigationMode> dict = new Dictionary<AstNode, ResolveVisitorNavigationMode>();

		public NodeListResolveVisitorNavigator(params AstNode[] nodes)
			: this(nodes, scanOnly: false)
		{
		}

		public NodeListResolveVisitorNavigator(IEnumerable<AstNode> nodes, bool scanOnly = false)
		{
			if (nodes == null)
			{
				throw new ArgumentNullException("nodes");
			}
			foreach (AstNode node in nodes)
			{
				dict[node] = ((!scanOnly) ? ResolveVisitorNavigationMode.Resolve : ResolveVisitorNavigationMode.Scan);
				AstNode parent = node.Parent;
				while (parent != null && !dict.ContainsKey(parent))
				{
					dict.Add(parent, ResolveVisitorNavigationMode.Scan);
					parent = parent.Parent;
				}
			}
		}

		public virtual ResolveVisitorNavigationMode Scan(AstNode node)
		{
			if (dict.TryGetValue(node, out ResolveVisitorNavigationMode value))
			{
				return value;
			}
			return ResolveVisitorNavigationMode.Skip;
		}

		public virtual void Resolved(AstNode node, ResolveResult result)
		{
		}

		public virtual void ProcessConversion(Expression expression, ResolveResult result, Conversion conversion, IType targetType)
		{
		}
	}
}
