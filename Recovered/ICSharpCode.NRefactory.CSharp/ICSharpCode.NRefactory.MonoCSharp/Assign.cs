using System.Linq.Expressions;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public abstract class Assign : ExpressionStatement
	{
		protected Expression target;

		protected Expression source;

		public Expression Target => target;

		public Expression Source => source;

		public override Location StartLocation => target.StartLocation;

		protected Assign(Expression target, Expression source, Location loc)
		{
			this.target = target;
			this.source = source;
			base.loc = loc;
		}

		public override bool ContainsEmitWithAwait()
		{
			if (!target.ContainsEmitWithAwait())
			{
				return source.ContainsEmitWithAwait();
			}
			return true;
		}

		public override Expression CreateExpressionTree(ResolveContext ec)
		{
			ec.Report.Error(832, loc, "An expression tree cannot contain an assignment operator");
			return null;
		}

		protected override Expression DoResolve(ResolveContext ec)
		{
			bool flag = true;
			source = source.Resolve(ec);
			if (source == null)
			{
				flag = false;
				source = ErrorExpression.Instance;
			}
			target = target.ResolveLValue(ec, source);
			if (target == null || !flag)
			{
				return null;
			}
			TypeSpec type = target.Type;
			TypeSpec type2 = source.Type;
			eclass = ExprClass.Value;
			base.type = type;
			if (!(target is IAssignMethod))
			{
				target.Error_ValueAssignment(ec, source);
				return null;
			}
			if (type != type2)
			{
				Expression expression = ResolveConversions(ec);
				if (expression != this)
				{
					return expression;
				}
			}
			return this;
		}

		public override System.Linq.Expressions.Expression MakeExpression(BuilderContext ctx)
		{
			IDynamicAssign obj = target as IDynamicAssign;
			if (obj == null)
			{
				throw new InternalErrorException(target.GetType() + " does not support dynamic assignment");
			}
			System.Linq.Expressions.Expression expression = obj.MakeAssignExpression(ctx, source);
			if (expression.NodeType == ExpressionType.Block)
			{
				return expression;
			}
			UnaryExpression right = (!ctx.HasSet(BuilderContext.Options.CheckedScope)) ? System.Linq.Expressions.Expression.Convert(source.MakeExpression(ctx), expression.Type) : System.Linq.Expressions.Expression.ConvertChecked(source.MakeExpression(ctx), expression.Type);
			return System.Linq.Expressions.Expression.Assign(expression, right);
		}

		protected virtual Expression ResolveConversions(ResolveContext ec)
		{
			source = Convert.ImplicitConversionRequired(ec, source, target.Type, source.Location);
			if (source == null)
			{
				return null;
			}
			return this;
		}

		private void Emit(EmitContext ec, bool is_statement)
		{
			((IAssignMethod)target).EmitAssign(ec, source, !is_statement, this is CompoundAssign);
		}

		public override void Emit(EmitContext ec)
		{
			Emit(ec, is_statement: false);
		}

		public override void EmitStatement(EmitContext ec)
		{
			Emit(ec, is_statement: true);
		}

		public override void FlowAnalysis(FlowAnalysisContext fc)
		{
			source.FlowAnalysis(fc);
			if (target is ArrayAccess || target is IndexerExpr)
			{
				target.FlowAnalysis(fc);
				return;
			}
			PropertyExpr propertyExpr = target as PropertyExpr;
			if (propertyExpr != null && !propertyExpr.IsAutoPropertyAccess)
			{
				target.FlowAnalysis(fc);
			}
		}

		protected override void CloneTo(CloneContext clonectx, Expression t)
		{
			Assign obj = (Assign)t;
			obj.target = target.Clone(clonectx);
			obj.source = source.Clone(clonectx);
		}

		public override object Accept(StructuralVisitor visitor)
		{
			return visitor.Visit(this);
		}
	}
}
