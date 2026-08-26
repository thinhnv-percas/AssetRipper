using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	public interface IResolveVisitorNavigator
	{
		ResolveVisitorNavigationMode Scan(AstNode node);

		void Resolved(AstNode node, ResolveResult result);

		void ProcessConversion(Expression expression, ResolveResult result, Conversion conversion, IType targetType);
	}
}
