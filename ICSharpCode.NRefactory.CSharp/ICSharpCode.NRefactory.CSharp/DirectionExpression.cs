using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class DirectionExpression : Expression
{
	public static readonly TokenRole RefKeywordRole = new TokenRole("ref");

	public static readonly TokenRole OutKeywordRole = new TokenRole("out");

	public FieldDirection FieldDirection { get; set; }

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

	public DirectionExpression()
	{
	}

	public DirectionExpression(FieldDirection direction, Expression expression)
	{
		FieldDirection = direction;
		AddChild(expression, Roles.Expression);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitDirectionExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitDirectionExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitDirectionExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is DirectionExpression directionExpression && FieldDirection == directionExpression.FieldDirection)
		{
			return Expression.DoMatch(directionExpression.Expression, match);
		}
		return false;
	}
}
