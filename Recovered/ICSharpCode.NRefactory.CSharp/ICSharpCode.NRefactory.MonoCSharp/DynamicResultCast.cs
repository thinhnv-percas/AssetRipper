using System.Linq.Expressions;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class DynamicResultCast : ShimExpression
	{
		public DynamicResultCast(TypeSpec type, Expression expr)
			: base(expr)
		{
			base.type = type;
		}

		protected override Expression DoResolve(ResolveContext ec)
		{
			expr = expr.Resolve(ec);
			eclass = ExprClass.Value;
			return this;
		}

		public override System.Linq.Expressions.Expression MakeExpression(BuilderContext ctx)
		{
			return System.Linq.Expressions.Expression.Block(expr.MakeExpression(ctx), System.Linq.Expressions.Expression.Default(type.GetMetaInfo()));
		}
	}
}
