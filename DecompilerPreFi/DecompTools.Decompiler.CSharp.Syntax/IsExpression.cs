using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class IsExpression : Expression
{
	public static readonly TokenRole IsKeywordRole = new TokenRole("is");

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

	public CSharpTokenNode IsToken => GetChildByRole(IsKeywordRole);

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

	public IsExpression()
	{
	}

	public IsExpression(Expression expression, AstType type)
	{
		AddChild(expression, Roles.Expression);
		AddChild(type, Roles.Type);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitIsExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitIsExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitIsExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is IsExpression isExpression && Expression.DoMatch(isExpression.Expression, match) && Type.DoMatch(isExpression.Type, match);
	}
}
