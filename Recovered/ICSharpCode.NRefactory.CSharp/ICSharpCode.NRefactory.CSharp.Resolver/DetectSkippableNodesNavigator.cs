using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	public sealed class DetectSkippableNodesNavigator : IResolveVisitorNavigator
	{
		private readonly Dictionary<AstNode, ResolveVisitorNavigationMode> dict = new Dictionary<AstNode, ResolveVisitorNavigationMode>();

		private IResolveVisitorNavigator navigator;

		public DetectSkippableNodesNavigator(IResolveVisitorNavigator navigator, AstNode root)
		{
			this.navigator = navigator;
			Init(root);
		}

		private bool Init(AstNode node)
		{
			ResolveVisitorNavigationMode resolveVisitorNavigationMode = navigator.Scan(node);
			if (resolveVisitorNavigationMode == ResolveVisitorNavigationMode.Skip)
			{
				return false;
			}
			bool flag = resolveVisitorNavigationMode != ResolveVisitorNavigationMode.Scan;
			for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
			{
				flag |= Init(astNode);
			}
			if (flag)
			{
				dict.Add(node, resolveVisitorNavigationMode);
			}
			return flag;
		}

		public ResolveVisitorNavigationMode Scan(AstNode node)
		{
			if (dict.TryGetValue(node, out ResolveVisitorNavigationMode value))
			{
				return value;
			}
			return ResolveVisitorNavigationMode.Skip;
		}

		public void Resolved(AstNode node, ResolveResult result)
		{
			navigator.Resolved(node, result);
		}

		public void ProcessConversion(Expression expression, ResolveResult result, Conversion conversion, IType targetType)
		{
			navigator.ProcessConversion(expression, result, conversion, targetType);
		}
	}
}
