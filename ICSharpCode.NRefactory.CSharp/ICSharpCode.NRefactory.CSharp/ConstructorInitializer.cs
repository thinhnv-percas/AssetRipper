using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class ConstructorInitializer : AstNode
{
	private class NullConstructorInitializer : ConstructorInitializer
	{
		public override NodeType NodeType => NodeType.Unknown;

		public override bool IsNull => true;

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitNullNode(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitNullNode(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitNullNode(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}
	}

	public static readonly TokenRole BaseKeywordRole = new TokenRole("base");

	public static readonly TokenRole ThisKeywordRole = new TokenRole("this");

	public new static readonly ConstructorInitializer Null = new NullConstructorInitializer();

	public override NodeType NodeType => NodeType.Unknown;

	public ConstructorInitializerType ConstructorInitializerType { get; set; }

	public CSharpTokenNode Keyword
	{
		get
		{
			if (ConstructorInitializerType == ConstructorInitializerType.Base)
			{
				return GetChildByRole(BaseKeywordRole);
			}
			return GetChildByRole(ThisKeywordRole);
		}
	}

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstNodeCollection<Expression> Arguments => GetChildrenByRole(Roles.Argument);

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitConstructorInitializer(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitConstructorInitializer(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitConstructorInitializer(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ConstructorInitializer { IsNull: false } constructorInitializer && (ConstructorInitializerType == ConstructorInitializerType.Any || ConstructorInitializerType == constructorInitializer.ConstructorInitializerType))
		{
			return Arguments.DoMatch(constructorInitializer.Arguments, match);
		}
		return false;
	}
}
