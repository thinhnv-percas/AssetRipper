using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class LockStatement : Statement
{
	public static readonly TokenRole LockKeywordRole = new TokenRole("lock");

	public CSharpTokenNode LockToken => GetChildByRole(LockKeywordRole);

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

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
		visitor.VisitLockStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitLockStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitLockStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is LockStatement lockStatement && Expression.DoMatch(lockStatement.Expression, match))
		{
			return EmbeddedStatement.DoMatch(lockStatement.EmbeddedStatement, match);
		}
		return false;
	}
}
