using System.Linq.Expressions;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	internal interface IDynamicAssign : IAssignMethod
	{
		System.Linq.Expressions.Expression MakeAssignExpression(BuilderContext ctx, Expression source);
	}
}
