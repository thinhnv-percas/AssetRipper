using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class StackAllocExpression : Expression
{
	public static readonly TokenRole StackallocKeywordRole = new TokenRole("stackalloc");

	public static readonly Role<ArrayInitializerExpression> InitializerRole = new Role<ArrayInitializerExpression>("Initializer", ArrayInitializerExpression.Null);

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

	public ArrayInitializerExpression Initializer
	{
		get
		{
			return GetChildByRole(InitializerRole);
		}
		set
		{
			SetChildByRole(InitializerRole, value);
		}
	}

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
		return other is StackAllocExpression stackAllocExpression && Type.DoMatch(stackAllocExpression.Type, match) && CountExpression.DoMatch(stackAllocExpression.CountExpression, match) && Initializer.DoMatch(stackAllocExpression.Initializer, match);
	}
}
