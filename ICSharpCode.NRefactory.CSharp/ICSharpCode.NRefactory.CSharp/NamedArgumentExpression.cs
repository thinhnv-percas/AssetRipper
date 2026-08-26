using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class NamedArgumentExpression : Expression
{
	public string Name
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

	public Identifier NameToken
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

	public CSharpTokenNode ColonToken => GetChildByRole(Roles.Colon);

	public Expression Expression
	{
		get
		{
			return GetChildByRole(Roles.Expression);
		}
		set
		{
			SetChildByRole(Roles.Expression, value);
		}
	}

	public NamedArgumentExpression()
	{
	}

	public NamedArgumentExpression(string name, Expression expression)
	{
		Name = name;
		Expression = expression;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitNamedArgumentExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitNamedArgumentExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitNamedArgumentExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is NamedArgumentExpression namedArgumentExpression && AstNode.MatchString(Name, namedArgumentExpression.Name))
		{
			return Expression.DoMatch(namedArgumentExpression.Expression, match);
		}
		return false;
	}
}
