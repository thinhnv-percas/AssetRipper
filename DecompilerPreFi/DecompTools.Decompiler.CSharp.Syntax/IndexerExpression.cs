using System.Collections.Generic;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class IndexerExpression : Expression
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

	public CSharpTokenNode LBracketToken => GetChildByRole(Roles.LBracket);

	public AstNodeCollection<Expression> Arguments => GetChildrenByRole(Roles.Argument);

	public CSharpTokenNode RBracketToken => GetChildByRole(Roles.RBracket);

	public IndexerExpression()
	{
	}

	public IndexerExpression(Expression target, IEnumerable<Expression> arguments)
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

	public IndexerExpression(Expression target, params Expression[] arguments)
		: this(target, (IEnumerable<Expression>)arguments)
	{
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitIndexerExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitIndexerExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitIndexerExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is IndexerExpression indexerExpression && Target.DoMatch(indexerExpression.Target, match) && Arguments.DoMatch(indexerExpression.Arguments, match);
	}
}
