using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class CaseLabel : AstNode
{
	public static readonly TokenRole CaseKeywordRole = new TokenRole("case");

	public static readonly TokenRole DefaultKeywordRole = new TokenRole("default");

	public override NodeType NodeType => NodeType.Unknown;

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

	public CSharpTokenNode ColonToken => GetChildByRole(Roles.Colon);

	public CaseLabel()
	{
	}

	public CaseLabel(Expression expression)
	{
		Expression = expression;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitCaseLabel(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitCaseLabel(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitCaseLabel(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is CaseLabel caseLabel)
		{
			return Expression.DoMatch(caseLabel.Expression, match);
		}
		return false;
	}
}
