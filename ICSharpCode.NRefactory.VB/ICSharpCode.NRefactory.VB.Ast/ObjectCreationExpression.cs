using System.Collections.Generic;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ObjectCreationExpression : Expression
{
	public static readonly Role<ArrayInitializerExpression> InitializerRole = ArrayInitializerExpression.InitializerRole;

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

	public AstNodeCollection<Expression> Arguments => GetChildrenByRole(Roles.Argument);

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

	public ObjectCreationExpression()
	{
	}

	public ObjectCreationExpression(AstType type, IEnumerable<Expression> arguments = null)
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

	public ObjectCreationExpression(AstType type, params Expression[] arguments)
		: this(type, (IEnumerable<Expression>)arguments)
	{
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitObjectCreationExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ObjectCreationExpression objectCreationExpression && Type.DoMatch(objectCreationExpression.Type, match) && Arguments.DoMatch(objectCreationExpression.Arguments, match))
		{
			return Initializer.DoMatch(objectCreationExpression.Initializer, match);
		}
		return false;
	}
}
