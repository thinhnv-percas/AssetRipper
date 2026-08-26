using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class DefaultValueExpression : Expression
{
	public static readonly TokenRole DefaultKeywordRole = new TokenRole("default");

	public CSharpTokenNode DefaultToken => GetChildByRole(DefaultKeywordRole);

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

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

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public DefaultValueExpression()
	{
	}

	public DefaultValueExpression(AstType type)
	{
		AddChild(type, Roles.Type);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitDefaultValueExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitDefaultValueExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitDefaultValueExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is DefaultValueExpression defaultValueExpression)
		{
			return Type.DoMatch(defaultValueExpression.Type, match);
		}
		return false;
	}
}
