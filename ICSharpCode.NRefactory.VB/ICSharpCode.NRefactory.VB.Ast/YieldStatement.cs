using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class YieldStatement : Statement
{
	public VBTokenNode YieldToken => GetChildByRole(Roles.Keyword);

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

	public YieldStatement()
	{
	}

	public YieldStatement(Expression expression)
	{
		AddChild(expression, Roles.Expression);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitYieldStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is YieldStatement yieldStatement)
		{
			return Expression.DoMatch(yieldStatement.Expression, match);
		}
		return false;
	}
}
