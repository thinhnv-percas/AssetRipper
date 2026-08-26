using System.Collections.Generic;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class AnonymousTypeCreateExpression : Expression
{
	public static readonly TokenRole NewKeywordRole = new TokenRole("new");

	public CSharpTokenNode NewToken => GetChildByRole(NewKeywordRole);

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstNodeCollection<Expression> Initializers => GetChildrenByRole(Roles.Expression);

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public AnonymousTypeCreateExpression()
	{
	}

	public AnonymousTypeCreateExpression(IEnumerable<Expression> initializers)
	{
		foreach (Expression initializer in initializers)
		{
			AddChild(initializer, Roles.Expression);
		}
	}

	public AnonymousTypeCreateExpression(params Expression[] initializer)
		: this((IEnumerable<Expression>)initializer)
	{
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitAnonymousTypeCreateExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitAnonymousTypeCreateExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitAnonymousTypeCreateExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is AnonymousTypeCreateExpression anonymousTypeCreateExpression && Initializers.DoMatch(anonymousTypeCreateExpression.Initializers, match);
	}
}
