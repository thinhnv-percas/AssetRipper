using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public abstract class Statement : AstNode
{
	private sealed class NullStatement : Statement
	{
		public override bool IsNull => true;

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return default(S);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}
	}

	private sealed class PatternPlaceholder : Statement, INode
	{
		private readonly Pattern child;

		public PatternPlaceholder(Pattern child)
		{
			this.child = child;
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitPatternPlaceholder(this, child, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return child.DoMatch(other, match);
		}

		bool INode.DoMatchCollection(Role role, INode pos, Match match, BacktrackingInfo backtrackingInfo)
		{
			return child.DoMatchCollection(role, pos, match, backtrackingInfo);
		}
	}

	public new static readonly Statement Null = new NullStatement();

	public Statement PreviousStatement
	{
		get
		{
			AstNode astNode = this;
			while ((astNode = astNode.PrevSibling) != null)
			{
				if (astNode is Statement result)
				{
					return result;
				}
			}
			return null;
		}
	}

	public Statement NextStatement
	{
		get
		{
			AstNode astNode = this;
			while ((astNode = astNode.NextSibling) != null)
			{
				if (astNode is Statement result)
				{
					return result;
				}
			}
			return null;
		}
	}

	public static implicit operator Statement(Pattern pattern)
	{
		if (pattern == null)
		{
			return null;
		}
		return new PatternPlaceholder(pattern);
	}

	public new Statement Clone()
	{
		return (Statement)base.Clone();
	}

	public Statement ReplaceWith(Func<Statement, Statement> replaceFunction)
	{
		if (replaceFunction == null)
		{
			throw new ArgumentNullException("replaceFunction");
		}
		return (Statement)ReplaceWith((AstNode node) => replaceFunction((Statement)node));
	}
}
