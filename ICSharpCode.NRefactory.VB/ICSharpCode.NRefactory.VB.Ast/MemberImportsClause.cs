using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class MemberImportsClause : ImportsClause
{
	public AstType Member
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

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is MemberImportsClause memberImportsClause)
		{
			return Member.DoMatch(memberImportsClause.Member, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitMemberImportsClause(this, data);
	}

	public override string ToString()
	{
		return $"[MemberImportsClause Member={Member}]";
	}
}
