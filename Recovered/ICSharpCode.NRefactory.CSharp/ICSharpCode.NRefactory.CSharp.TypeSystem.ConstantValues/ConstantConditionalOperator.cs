using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using System;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues
{
	[Serializable]
	public sealed class ConstantConditionalOperator : ConstantExpression
	{
		private readonly ConstantExpression condition;

		private readonly ConstantExpression trueExpr;

		private readonly ConstantExpression falseExpr;

		public ConstantConditionalOperator(ConstantExpression condition, ConstantExpression trueExpr, ConstantExpression falseExpr)
		{
			if (condition == null)
			{
				throw new ArgumentNullException("condition");
			}
			if (trueExpr == null)
			{
				throw new ArgumentNullException("trueExpr");
			}
			if (falseExpr == null)
			{
				throw new ArgumentNullException("falseExpr");
			}
			this.condition = condition;
			this.trueExpr = trueExpr;
			this.falseExpr = falseExpr;
		}

		public override ResolveResult Resolve(CSharpResolver resolver)
		{
			return resolver.ResolveConditional(condition.Resolve(resolver), trueExpr.Resolve(resolver), falseExpr.Resolve(resolver));
		}
	}
}
