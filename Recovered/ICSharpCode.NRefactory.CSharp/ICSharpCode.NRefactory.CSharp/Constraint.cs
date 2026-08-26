using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class Constraint : AstNode
	{
		public override NodeType NodeType => NodeType.Unknown;

		public CSharpTokenNode WhereKeyword => GetChildByRole(Roles.WhereKeyword);

		public SimpleType TypeParameter
		{
			get
			{
				return GetChildByRole(Roles.ConstraintTypeParameter);
			}
			set
			{
				SetChildByRole(Roles.ConstraintTypeParameter, value);
			}
		}

		public AstNodeCollection<AstType> BaseTypes => GetChildrenByRole(Roles.BaseType);

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitConstraint(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitConstraint(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitConstraint(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			Constraint constraint = other as Constraint;
			if (constraint != null && TypeParameter.DoMatch(constraint.TypeParameter, match))
			{
				return BaseTypes.DoMatch(constraint.BaseTypes, match);
			}
			return false;
		}
	}
}
