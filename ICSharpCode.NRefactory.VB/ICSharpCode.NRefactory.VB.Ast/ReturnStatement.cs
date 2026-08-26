using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ReturnStatement : Statement
{
	public VBTokenNode ReturnToken => GetChildByRole(Roles.Keyword);

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

	public ReturnStatement()
	{
	}

	public ReturnStatement(Expression expression)
	{
		AddChild(expression, Roles.Expression);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitReturnStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ReturnStatement returnStatement)
		{
			return Expression.DoMatch(returnStatement.Expression, match);
		}
		return false;
	}
}
