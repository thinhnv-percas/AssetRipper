using System.Collections.Generic;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class AnonymousObjectCreationExpression : Expression
{
	public AstNodeCollection<Expression> Initializer => GetChildrenByRole(Roles.Expression);

	public AnonymousObjectCreationExpression()
	{
	}

	public AnonymousObjectCreationExpression(IEnumerable<Expression> initializer)
	{
		foreach (Expression item in initializer)
		{
			AddChild(item, Roles.Expression);
		}
	}

	public AnonymousObjectCreationExpression(params Expression[] initializer)
		: this((IEnumerable<Expression>)initializer)
	{
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitAnonymousObjectCreationExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is AnonymousObjectCreationExpression anonymousObjectCreationExpression)
		{
			return Initializer.DoMatch(anonymousObjectCreationExpression.Initializer, match);
		}
		return false;
	}
}
