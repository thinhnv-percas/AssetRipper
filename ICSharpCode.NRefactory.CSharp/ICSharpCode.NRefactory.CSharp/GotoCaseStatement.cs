using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class GotoCaseStatement : Statement
{
	public static readonly TokenRole GotoKeywordRole = new TokenRole("goto");

	public static readonly TokenRole CaseKeywordRole = new TokenRole("case");

	public CSharpTokenNode GotoToken => GetChildByRole(GotoKeywordRole);

	public CSharpTokenNode CaseToken => GetChildByRole(CaseKeywordRole);

	public Expression LabelExpression
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

	public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitGotoCaseStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitGotoCaseStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitGotoCaseStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is GotoCaseStatement gotoCaseStatement)
		{
			return LabelExpression.DoMatch(gotoCaseStatement.LabelExpression, match);
		}
		return false;
	}
}
