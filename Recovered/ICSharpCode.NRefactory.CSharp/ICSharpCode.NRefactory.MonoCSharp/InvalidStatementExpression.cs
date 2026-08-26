namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class InvalidStatementExpression : Statement
	{
		public Expression Expression
		{
			get;
			private set;
		}

		public InvalidStatementExpression(Expression expr)
		{
			Expression = expr;
		}

		public override void Emit(EmitContext ec)
		{
		}

		protected override void DoEmit(EmitContext ec)
		{
		}

		protected override void CloneTo(CloneContext clonectx, Statement target)
		{
		}

		public override Expression CreateExpressionTree(ResolveContext ec)
		{
			return null;
		}

		public override object Accept(StructuralVisitor visitor)
		{
			return visitor.Visit(this);
		}

		protected override bool DoFlowAnalysis(FlowAnalysisContext fc)
		{
			return false;
		}
	}
}
