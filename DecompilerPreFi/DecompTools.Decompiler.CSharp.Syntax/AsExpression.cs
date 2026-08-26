using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class AsExpression : Expression
{
	public static readonly TokenRole AsKeywordRole = new TokenRole("as");

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

	public CSharpTokenNode AsToken => GetChildByRole(AsKeywordRole);

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

	public AsExpression()
	{
	}

	public AsExpression(Expression expression, AstType type)
	{
		AddChild(expression, Roles.Expression);
		AddChild(type, Roles.Type);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitAsExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitAsExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitAsExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is AsExpression asExpression && Expression.DoMatch(asExpression.Expression, match) && Type.DoMatch(asExpression.Type, match);
	}
}
