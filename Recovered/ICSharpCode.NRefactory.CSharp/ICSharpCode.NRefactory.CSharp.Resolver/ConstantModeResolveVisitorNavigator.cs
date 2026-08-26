using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	internal sealed class ConstantModeResolveVisitorNavigator : IResolveVisitorNavigator
	{
		private readonly ResolveVisitorNavigationMode mode;

		private readonly IResolveVisitorNavigator targetForResolveCalls;

		public ConstantModeResolveVisitorNavigator(ResolveVisitorNavigationMode mode, IResolveVisitorNavigator targetForResolveCalls)
		{
			this.mode = mode;
			this.targetForResolveCalls = targetForResolveCalls;
		}

		ResolveVisitorNavigationMode IResolveVisitorNavigator.Scan(AstNode node)
		{
			return mode;
		}

		void IResolveVisitorNavigator.Resolved(AstNode node, ResolveResult result)
		{
			if (targetForResolveCalls != null)
			{
				targetForResolveCalls.Resolved(node, result);
			}
		}

		void IResolveVisitorNavigator.ProcessConversion(Expression expression, ResolveResult result, Conversion conversion, IType targetType)
		{
			if (targetForResolveCalls != null)
			{
				targetForResolveCalls.ProcessConversion(expression, result, conversion, targetType);
			}
		}
	}
}
