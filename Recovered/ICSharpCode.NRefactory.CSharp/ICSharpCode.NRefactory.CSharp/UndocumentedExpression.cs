using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class UndocumentedExpression : Expression
	{
		public static readonly TokenRole ArglistKeywordRole = new TokenRole("__arglist");

		public static readonly TokenRole RefvalueKeywordRole = new TokenRole("__refvalue");

		public static readonly TokenRole ReftypeKeywordRole = new TokenRole("__reftype");

		public static readonly TokenRole MakerefKeywordRole = new TokenRole("__makeref");

		public UndocumentedExpressionType UndocumentedExpressionType
		{
			get;
			set;
		}

		public CSharpTokenNode UndocumentedToken
		{
			get
			{
				switch (UndocumentedExpressionType)
				{
				case UndocumentedExpressionType.ArgListAccess:
				case UndocumentedExpressionType.ArgList:
					return GetChildByRole(ArglistKeywordRole);
				case UndocumentedExpressionType.RefValue:
					return GetChildByRole(RefvalueKeywordRole);
				case UndocumentedExpressionType.RefType:
					return GetChildByRole(ReftypeKeywordRole);
				case UndocumentedExpressionType.MakeRef:
					return GetChildByRole(MakerefKeywordRole);
				default:
					return CSharpTokenNode.Null;
				}
			}
		}

		public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

		public AstNodeCollection<Expression> Arguments => GetChildrenByRole(Roles.Argument);

		public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitUndocumentedExpression(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitUndocumentedExpression(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitUndocumentedExpression(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			UndocumentedExpression undocumentedExpression = other as UndocumentedExpression;
			if (undocumentedExpression != null && UndocumentedExpressionType == undocumentedExpression.UndocumentedExpressionType)
			{
				return Arguments.DoMatch(undocumentedExpression.Arguments, match);
			}
			return false;
		}
	}
}
