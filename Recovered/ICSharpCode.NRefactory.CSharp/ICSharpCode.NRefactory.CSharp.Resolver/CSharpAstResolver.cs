using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Threading;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	public class CSharpAstResolver
	{
		private readonly CSharpResolver initialResolverState;

		private readonly AstNode rootNode;

		private readonly CSharpUnresolvedFile unresolvedFile;

		private readonly ResolveVisitor resolveVisitor;

		private bool resolverInitialized;

		public CSharpTypeResolveContext TypeResolveContext => initialResolverState.CurrentTypeResolveContext;

		public ICompilation Compilation => initialResolverState.Compilation;

		public AstNode RootNode => rootNode;

		public CSharpUnresolvedFile UnresolvedFile => unresolvedFile;

		public CSharpAstResolver(ICompilation compilation, SyntaxTree syntaxTree, CSharpUnresolvedFile unresolvedFile = null)
		{
			if (compilation == null)
			{
				throw new ArgumentNullException("compilation");
			}
			if (syntaxTree == null)
			{
				throw new ArgumentNullException("syntaxTree");
			}
			initialResolverState = new CSharpResolver(compilation);
			rootNode = syntaxTree;
			this.unresolvedFile = unresolvedFile;
			resolveVisitor = new ResolveVisitor(initialResolverState, unresolvedFile);
		}

		public CSharpAstResolver(CSharpResolver resolver, AstNode rootNode, CSharpUnresolvedFile unresolvedFile = null)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			if (rootNode == null)
			{
				throw new ArgumentNullException("rootNode");
			}
			initialResolverState = resolver;
			this.rootNode = rootNode;
			this.unresolvedFile = unresolvedFile;
			resolveVisitor = new ResolveVisitor(initialResolverState, unresolvedFile);
		}

		public void ApplyNavigator(IResolveVisitorNavigator navigator, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (navigator == null)
			{
				throw new ArgumentNullException("navigator");
			}
			lock (resolveVisitor)
			{
				if (resolverInitialized)
				{
					throw new InvalidOperationException("Applying a navigator is only valid as the first operation on the CSharpAstResolver.");
				}
				resolverInitialized = true;
				resolveVisitor.cancellationToken = cancellationToken;
				resolveVisitor.SetNavigator(navigator);
				try
				{
					resolveVisitor.Scan(rootNode);
				}
				finally
				{
					resolveVisitor.SetNavigator(null);
					resolveVisitor.cancellationToken = CancellationToken.None;
				}
			}
		}

		public ResolveResult Resolve(AstNode node, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (node == null || node.IsNull || IsUnresolvableNode(node))
			{
				return ErrorResolveResult.UnknownError;
			}
			lock (resolveVisitor)
			{
				InitResolver();
				resolveVisitor.cancellationToken = cancellationToken;
				try
				{
					return resolveVisitor.GetResolveResult(node);
				}
				finally
				{
					resolveVisitor.cancellationToken = CancellationToken.None;
				}
			}
		}

		private void InitResolver()
		{
			if (!resolverInitialized)
			{
				resolverInitialized = true;
				resolveVisitor.Scan(rootNode);
			}
		}

		public CSharpResolver GetResolverStateBefore(AstNode node, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (node == null || node.IsNull)
			{
				throw new ArgumentNullException("node");
			}
			lock (resolveVisitor)
			{
				InitResolver();
				resolveVisitor.cancellationToken = cancellationToken;
				try
				{
					return resolveVisitor.GetResolverStateBefore(node);
				}
				finally
				{
					resolveVisitor.cancellationToken = CancellationToken.None;
				}
			}
		}

		public CSharpResolver GetResolverStateAfter(AstNode node, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (node == null || node.IsNull)
			{
				throw new ArgumentNullException("node");
			}
			while (node != null && IsUnresolvableNode(node))
			{
				node = node.Parent;
			}
			if (node == null)
			{
				return initialResolverState;
			}
			lock (resolveVisitor)
			{
				InitResolver();
				resolveVisitor.cancellationToken = cancellationToken;
				try
				{
					return resolveVisitor.GetResolverStateAfter(node);
				}
				finally
				{
					resolveVisitor.cancellationToken = CancellationToken.None;
				}
			}
		}

		private ResolveVisitor.ConversionWithTargetType GetConversionWithTargetType(Expression expr, CancellationToken cancellationToken)
		{
			if (expr == null || expr.IsNull)
			{
				return new ResolveVisitor.ConversionWithTargetType(Conversion.None, SpecialType.UnknownType);
			}
			lock (resolveVisitor)
			{
				InitResolver();
				resolveVisitor.cancellationToken = cancellationToken;
				try
				{
					return resolveVisitor.GetConversionWithTargetType(expr);
				}
				finally
				{
					resolveVisitor.cancellationToken = CancellationToken.None;
				}
			}
		}

		public IType GetExpectedType(Expression expr, CancellationToken cancellationToken = default(CancellationToken))
		{
			return GetConversionWithTargetType(expr, cancellationToken).TargetType;
		}

		public Conversion GetConversion(Expression expr, CancellationToken cancellationToken = default(CancellationToken))
		{
			return GetConversionWithTargetType(expr, cancellationToken).Conversion;
		}

		public static bool IsUnresolvableNode(AstNode node)
		{
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			if (node.NodeType == NodeType.Token)
			{
				if (node.Parent is QueryClause && node is Identifier)
				{
					return false;
				}
				if (node.Role == Roles.Identifier)
				{
					if (!(node.Parent is ForeachStatement))
					{
						return !(node.Parent is CatchClause);
					}
					return false;
				}
				return true;
			}
			if (node.NodeType != NodeType.Whitespace)
			{
				return node is ArraySpecifier;
			}
			return true;
		}
	}
}
