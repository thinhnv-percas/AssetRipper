using System.Collections.Generic;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class InvocationExpression : Expression
{
	public Expression Target
	{
		get
		{
			return GetChildByRole(Roles.TargetExpression);
		}
		set
		{
			SetChildByRole(Roles.TargetExpression, value);
		}
	}

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstNodeCollection<Expression> Arguments => GetChildrenByRole(Roles.Argument);

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitInvocationExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitInvocationExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitInvocationExpression(this, data);
	}

	public InvocationExpression()
	{
	}

	public InvocationExpression(Expression target, IEnumerable<Expression> arguments)
	{
		AddChild(target, Roles.TargetExpression);
		if (arguments == null)
		{
			return;
		}
		foreach (Expression argument in arguments)
		{
			AddChild(argument, Roles.Argument);
		}
	}

	public InvocationExpression(Expression target, params Expression[] arguments)
		: this(target, (IEnumerable<Expression>)arguments)
	{
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is InvocationExpression invocationExpression && Target.DoMatch(invocationExpression.Target, match))
		{
			return Arguments.DoMatch(invocationExpression.Arguments, match);
		}
		return false;
	}
}
