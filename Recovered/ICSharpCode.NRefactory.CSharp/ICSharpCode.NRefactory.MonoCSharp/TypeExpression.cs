namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class TypeExpression : TypeExpr
	{
		public TypeExpression(TypeSpec t, Location l)
		{
			base.Type = t;
			eclass = ExprClass.Type;
			loc = l;
		}

		public sealed override TypeSpec ResolveAsType(IMemberContext mc, bool allowUnboundTypeArguments = false)
		{
			return type;
		}

		public override object Accept(StructuralVisitor visitor)
		{
			return visitor.Visit(this);
		}
	}
}
