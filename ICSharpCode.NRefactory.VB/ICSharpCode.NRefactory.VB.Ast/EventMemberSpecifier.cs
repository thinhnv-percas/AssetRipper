using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class EventMemberSpecifier : AstNode
{
	public static readonly Role<EventMemberSpecifier> EventMemberSpecifierRole = new Role<EventMemberSpecifier>("EventMemberSpecifier");

	public Expression Target
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

	public Identifier Member
	{
		get
		{
			return GetChildByRole(Roles.Identifier);
		}
		set
		{
			SetChildByRole(Roles.Identifier, value);
		}
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is EventMemberSpecifier eventMemberSpecifier && Target.DoMatch(eventMemberSpecifier.Target, match))
		{
			return Member.DoMatch(eventMemberSpecifier.Member, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitEventMemberSpecifier(this, data);
	}
}
