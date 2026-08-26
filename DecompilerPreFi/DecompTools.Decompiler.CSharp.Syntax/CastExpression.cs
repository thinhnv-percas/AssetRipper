using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class CastExpression : Expression
{
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

	public CastExpression(AstType castToType, Expression expression)
	{
		AddChild(castToType, Roles.Type);
		AddChild(expression, Roles.Expression);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitCastExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitCastExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitCastExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is CastExpression castExpression && Type.DoMatch(castExpression.Type, match) && Expression.DoMatch(castExpression.Expression, match);
	}
}
