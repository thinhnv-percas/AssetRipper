using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class StackAllocExpression : Expression
{
	public static readonly TokenRole StackallocKeywordRole = new TokenRole("stackalloc");

	public CSharpTokenNode StackAllocToken => GetChildByRole(StackallocKeywordRole);

	public AstType Type
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

	public CSharpTokenNode LBracketToken => GetChildByRole(Roles.LBracket);

	public Expression CountExpression
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

	public CSharpTokenNode RBracketToken => GetChildByRole(Roles.RBracket);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitStackAllocExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitStackAllocExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitStackAllocExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is StackAllocExpression stackAllocExpression && Type.DoMatch(stackAllocExpression.Type, match))
		{
			return CountExpression.DoMatch(stackAllocExpression.CountExpression, match);
		}
		return false;
	}
}
