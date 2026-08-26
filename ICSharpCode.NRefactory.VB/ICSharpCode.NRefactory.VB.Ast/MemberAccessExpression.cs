using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class MemberAccessExpression : Expression
{
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

	public Identifier MemberName
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

	public AstNodeCollection<AstType> TypeArguments => GetChildrenByRole(Roles.TypeArgument);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is MemberAccessExpression memberAccessExpression && Target.DoMatch(memberAccessExpression.Target, match) && MemberName.DoMatch(memberAccessExpression.MemberName, match))
		{
			return TypeArguments.DoMatch(memberAccessExpression.TypeArguments, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitMemberAccessExpression(this, data);
	}
}
