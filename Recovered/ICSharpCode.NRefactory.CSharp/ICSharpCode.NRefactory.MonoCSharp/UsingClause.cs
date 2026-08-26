namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class UsingClause
	{
		private readonly ATypeNameExpression expr;

		private readonly Location loc;

		protected FullNamedExpression resolved;

		public virtual SimpleMemberName Alias => null;

		public Location Location => loc;

		public ATypeNameExpression NamespaceExpression => expr;

		public FullNamedExpression ResolvedExpression => resolved;

		public UsingClause(ATypeNameExpression expr, Location loc)
		{
			this.expr = expr;
			this.loc = loc;
		}

		public string GetSignatureForError()
		{
			return expr.GetSignatureForError();
		}

		public virtual void Define(NamespaceContainer ctx)
		{
			resolved = expr.ResolveAsTypeOrNamespace(ctx, allowUnboundTypeArguments: false);
		}

		public virtual void Accept(StructuralVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override string ToString()
		{
			return resolved.ToString();
		}
	}
}
