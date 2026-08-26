using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Threading;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	public static class ResolveAtLocation
	{
		public static ResolveResult Resolve(ICompilation compilation, CSharpUnresolvedFile unresolvedFile, SyntaxTree syntaxTree, TextLocation location, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Resolve(new Lazy<ICompilation>(() => compilation), unresolvedFile, syntaxTree, location, cancellationToken);
		}

		public static ResolveResult Resolve(Lazy<ICompilation> compilation, CSharpUnresolvedFile unresolvedFile, SyntaxTree syntaxTree, TextLocation location, CancellationToken cancellationToken = default(CancellationToken))
		{
			AstNode node;
			return Resolve(compilation, unresolvedFile, syntaxTree, location, out node, cancellationToken);
		}

		public static ResolveResult Resolve(ICompilation compilation, CSharpUnresolvedFile unresolvedFile, SyntaxTree syntaxTree, TextLocation location, out AstNode node, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Resolve(new Lazy<ICompilation>(() => compilation), unresolvedFile, syntaxTree, location, out node, cancellationToken);
		}

		public static ResolveResult Resolve(Lazy<ICompilation> compilation, CSharpUnresolvedFile unresolvedFile, SyntaxTree syntaxTree, TextLocation location, out AstNode node, CancellationToken cancellationToken = default(CancellationToken))
		{
			node = syntaxTree.GetNodeAt(location);
			if (node == null || node is ArrayInitializerExpression)
			{
				return null;
			}
			if (node.Parent is UsingAliasDeclaration && node.Role == UsingAliasDeclaration.AliasRole)
			{
				return new CSharpAstResolver(compilation.Value, syntaxTree, unresolvedFile).Resolve(((UsingAliasDeclaration)node.Parent).Import, cancellationToken);
			}
			if (CSharpAstResolver.IsUnresolvableNode(node))
			{
				if (node is Identifier)
				{
					node = node.Parent;
				}
				else
				{
					if (node.NodeType != NodeType.Token)
					{
						return null;
					}
					if (node.Parent is IndexerExpression || node.Parent is ConstructorInitializer || node.Role == IndexerDeclaration.ThisKeywordRole)
					{
						node = node.Parent;
					}
					else
					{
						if (!(node.Parent is BinaryOperatorExpression) && !(node.Parent is UnaryOperatorExpression))
						{
							return null;
						}
						node = node.Parent;
					}
				}
			}
			else if (!node.GetChildByRole(Roles.Identifier).IsNull)
			{
				return null;
			}
			if (node == null)
			{
				return null;
			}
			if (node.Parent is ObjectCreateExpression && node.Role == Roles.Type)
			{
				node = node.Parent;
			}
			else if (node is ThisReferenceExpression && node.Parent is IndexerExpression)
			{
				node = node.Parent;
			}
			InvocationExpression invocationExpression = null;
			if ((node is IdentifierExpression || node is MemberReferenceExpression || node is PointerReferenceExpression) && node.Role != Roles.Argument)
			{
				invocationExpression = (node.Parent as InvocationExpression);
			}
			CSharpAstResolver cSharpAstResolver = new CSharpAstResolver(compilation.Value, syntaxTree, unresolvedFile);
			ResolveResult resolveResult = cSharpAstResolver.Resolve(node, cancellationToken);
			MethodGroupResolveResult methodGroupResolveResult = resolveResult as MethodGroupResolveResult;
			if (methodGroupResolveResult != null)
			{
				if (invocationExpression != null)
				{
					return cSharpAstResolver.Resolve(invocationExpression);
				}
				if (node is Expression)
				{
					Conversion conversion = cSharpAstResolver.GetConversion((Expression)node, cancellationToken);
					if (conversion.IsMethodGroupConversion)
					{
						return new MemberResolveResult(methodGroupResolveResult.TargetResult, conversion.Method);
					}
				}
			}
			return resolveResult;
		}
	}
}
