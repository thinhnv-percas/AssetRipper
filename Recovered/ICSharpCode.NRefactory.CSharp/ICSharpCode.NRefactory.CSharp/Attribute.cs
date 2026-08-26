using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class Attribute : AstNode
	{
		public override NodeType NodeType => NodeType.Unknown;

		public AstType Type
		{
			get
			{
				return GetChildByRole(Roles.Type);
			}
			set
			{
				SetChildByRole(Roles.Type, value);
			}
		}

		public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

		public AstNodeCollection<Expression> Arguments => GetChildrenByRole(Roles.Argument);

		public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

		public bool HasArgumentList
		{
			get;
			set;
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitAttribute(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitAttribute(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitAttribute(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			Attribute attribute = other as Attribute;
			if (attribute != null && Type.DoMatch(attribute.Type, match))
			{
				return Arguments.DoMatch(attribute.Arguments, match);
			}
			return false;
		}

		public override string ToString(CSharpFormattingOptions formattingOptions)
		{
			if (IsNull)
			{
				return "Null";
			}
			return base.ToString(formattingOptions);
		}
	}
}
