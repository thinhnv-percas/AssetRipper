using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ThrowStatement : Statement
{
	public VBTokenNode ThrowToken => GetChildByRole(Roles.Keyword);

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

	public ThrowStatement()
	{
	}

	public ThrowStatement(Expression expression)
	{
		AddChild(expression, Roles.Expression);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitThrowStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ThrowStatement throwStatement)
		{
			return Expression.DoMatch(throwStatement.Expression, match);
		}
		return false;
	}
}
