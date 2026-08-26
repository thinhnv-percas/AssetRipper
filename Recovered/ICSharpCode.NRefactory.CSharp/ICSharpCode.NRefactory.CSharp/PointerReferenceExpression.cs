using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class PointerReferenceExpression : Expression
	{
		public static readonly TokenRole ArrowRole = new TokenRole("->");

		public Expression Target
		{
			get
			{
				return GetChildByRole(Roles.TargetExpression);
			}
			set
			{
				SetChildByRole(Roles.TargetExpression, value);
			}
		}

		public CSharpTokenNode ArrowToken => GetChildByRole(ArrowRole);

		public string MemberName
		{
			get
			{
				return GetChildByRole(Roles.Identifier).Name;
			}
			set
			{
				SetChildByRole(Roles.Identifier, Identifier.Create(value));
			}
		}

		public Identifier MemberNameToken
		{
			get
			{
				return GetChildByRole(Roles.Identifier);
			}
			set
			{
				SetChildByRole(Roles.Identifier, value);
			}
		}

		public AstNodeCollection<AstType> TypeArguments => GetChildrenByRole(Roles.TypeArgument);

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitPointerReferenceExpression(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitPointerReferenceExpression(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitPointerReferenceExpression(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			PointerReferenceExpression pointerReferenceExpression = other as PointerReferenceExpression;
			if (pointerReferenceExpression != null && AstNode.MatchString(MemberName, pointerReferenceExpression.MemberName))
			{
				return TypeArguments.DoMatch(pointerReferenceExpression.TypeArguments, match);
			}
			return false;
		}
	}
}
