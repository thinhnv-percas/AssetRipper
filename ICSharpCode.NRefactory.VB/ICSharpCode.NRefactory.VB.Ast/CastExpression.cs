using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class CastExpression : Expression
{
	public CastType CastType { get; set; }

	public VBTokenNode CastTypeToken => GetChildByRole(Roles.Keyword);

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

	public CastExpression()
	{
	}

	public CastExpression(CastType castType, AstType castToType, Expression expression)
	{
		CastType = castType;
		AddChild(castToType, Roles.Type);
		AddChild(expression, Roles.Expression);
	}

	public CastExpression(CastType castType, Expression expression)
	{
		CastType = castType;
		AddChild(expression, Roles.Expression);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitCastExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is CastExpression castExpression && CastType == castExpression.CastType && Type.DoMatch(castExpression.Type, match))
		{
			return Expression.DoMatch(castExpression.Expression, match);
		}
		return false;
	}
}
