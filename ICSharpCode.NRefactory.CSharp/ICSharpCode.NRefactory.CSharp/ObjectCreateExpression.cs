using System.Collections.Generic;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class ObjectCreateExpression : Expression
{
	public static readonly TokenRole NewKeywordRole = new TokenRole("new");

	public static readonly Role<ArrayInitializerExpression> InitializerRole = ArrayCreateExpression.InitializerRole;

	public CSharpTokenNode NewToken => GetChildByRole(NewKeywordRole);

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

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstNodeCollection<Expression> Arguments => GetChildrenByRole(Roles.Argument);

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

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

	public ObjectCreateExpression()
	{
	}

	public ObjectCreateExpression(AstType type, IEnumerable<Expression> arguments = null)
	{
		AddChild(type, Roles.Type);
		if (arguments == null)
		{
			return;
		}
		foreach (Expression argument in arguments)
		{
			AddChild(argument, Roles.Argument);
		}
	}

	public ObjectCreateExpression(AstType type, params Expression[] arguments)
		: this(type, (IEnumerable<Expression>)arguments)
	{
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitObjectCreateExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitObjectCreateExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitObjectCreateExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ObjectCreateExpression objectCreateExpression && Type.DoMatch(objectCreateExpression.Type, match) && Arguments.DoMatch(objectCreateExpression.Arguments, match))
		{
			return Initializer.DoMatch(objectCreateExpression.Initializer, match);
		}
		return false;
	}
}
