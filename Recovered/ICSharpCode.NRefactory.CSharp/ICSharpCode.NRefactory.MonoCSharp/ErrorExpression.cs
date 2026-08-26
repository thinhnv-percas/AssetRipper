namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class ErrorExpression : EmptyExpression
	{
		public static readonly ErrorExpression Instance = new ErrorExpression();

		public readonly int ErrorCode;

		public readonly string Error;

		private ErrorExpression()
			: base(InternalType.ErrorType)
		{
		}

		private ErrorExpression(int errorCode, Location location, string error)
			: base(InternalType.ErrorType)
		{
			ErrorCode = errorCode;
			loc = location;
			Error = error;
		}

		public static ErrorExpression Create(int errorCode, Location location, string error)
		{
			return new ErrorExpression(errorCode, location, error);
		}

		public override Expression CreateExpressionTree(ResolveContext ec)
		{
			return this;
		}

		public override Expression DoResolveLValue(ResolveContext rc, Expression right_side)
		{
			return this;
		}

		public override void Error_ValueAssignment(ResolveContext rc, Expression rhs)
		{
		}

		public override void Error_UnexpectedKind(ResolveContext ec, ResolveFlags flags, Location loc)
		{
		}

		public override void Error_ValueCannotBeConverted(ResolveContext ec, TypeSpec target, bool expl)
		{
		}

		public override void Error_OperatorCannotBeApplied(ResolveContext rc, Location loc, string oper, TypeSpec t)
		{
		}

		public override object Accept(StructuralVisitor visitor)
		{
			return visitor.Visit(this);
		}
	}
}
