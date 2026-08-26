using System;

namespace ICSharpCode.NRefactory.MonoCSharp.Linq
{
	public class QueryExpression : AQueryClause
	{
		protected override string MethodName
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public QueryExpression(AQueryClause start)
			: base(null, null, start.Location)
		{
			next = start;
		}

		public override Expression BuildQueryClause(ResolveContext ec, Expression lSide, Parameter parentParameter)
		{
			return next.BuildQueryClause(ec, lSide, parentParameter);
		}

		protected override Expression DoResolve(ResolveContext ec)
		{
			int counter = QueryBlock.TransparentParameter.Counter;
			Expression expression = BuildQueryClause(ec, null, null);
			if (expression != null)
			{
				expression = expression.Resolve(ec);
			}
			if (ec.IsInProbingMode)
			{
				QueryBlock.TransparentParameter.Counter = counter;
			}
			return expression;
		}

		public override object Accept(StructuralVisitor visitor)
		{
			return visitor.Visit(this);
		}
	}
}
