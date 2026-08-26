using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class WhileStatement : Statement
{
	public static readonly TokenRole WhileKeywordRole = new TokenRole("while");

	public CSharpTokenNode WhileToken => GetChildByRole(WhileKeywordRole);

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public Expression Condition
	{
		get
		{
			return GetChildByRole(Roles.Condition);
		}
		set
		{
			SetChildByRole(Roles.Condition, value);
		}
	}

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public Statement EmbeddedStatement
	{
		get
		{
			return GetChildByRole(Roles.EmbeddedStatement);
		}
		set
		{
			SetChildByRole(Roles.EmbeddedStatement, value);
		}
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitWhileStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitWhileStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitWhileStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is WhileStatement whileStatement && Condition.DoMatch(whileStatement.Condition, match))
		{
			return EmbeddedStatement.DoMatch(whileStatement.EmbeddedStatement, match);
		}
		return false;
	}

	public WhileStatement()
	{
	}

	public WhileStatement(Expression condition, Statement embeddedStatement)
	{
		Condition = condition;
		EmbeddedStatement = embeddedStatement;
	}
}
