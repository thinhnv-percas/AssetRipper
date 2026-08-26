using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class DirectionExpression : Expression
{
	public static readonly TokenRole RefKeywordRole = new TokenRole("ref");

	public static readonly TokenRole OutKeywordRole = new TokenRole("out");

	public static readonly TokenRole InKeywordRole = new TokenRole("in");

	public FieldDirection FieldDirection { get; set; }

	public CSharpTokenNode FieldDirectionToken => FieldDirection switch
	{
		FieldDirection.Ref => GetChildByRole(RefKeywordRole), 
		FieldDirection.In => GetChildByRole(InKeywordRole), 
		_ => GetChildByRole(OutKeywordRole), 
	};

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
		return other is DirectionExpression directionExpression && FieldDirection == directionExpression.FieldDirection && Expression.DoMatch(directionExpression.Expression, match);
	}
}
