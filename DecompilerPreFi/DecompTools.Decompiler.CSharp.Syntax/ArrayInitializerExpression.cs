using System.Collections.Generic;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class ArrayInitializerExpression : Expression
{
	private sealed class NullArrayInitializerExpression : ArrayInitializerExpression
	{
		public override bool IsNull => true;

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitNullNode(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitNullNode(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitNullNode(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}
	}

	private class SingleArrayInitializerExpression : ArrayInitializerExpression
	{
		public override bool IsSingleElement => true;
	}

	private sealed class PatternPlaceholder : ArrayInitializerExpression, INode
	{
		private readonly Pattern child;

		public override NodeType NodeType => NodeType.Pattern;

		public PatternPlaceholder(Pattern child)
		{
			this.child = child;
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitPatternPlaceholder(this, child);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitPatternPlaceholder(this, child);
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

	public new static readonly ArrayInitializerExpression Null = new NullArrayInitializerExpression();

	public virtual bool IsSingleElement => false;

	public CSharpTokenNode LBraceToken => GetChildByRole(Roles.LBrace);

	public AstNodeCollection<Expression> Elements => GetChildrenByRole(Roles.Expression);

	public CSharpTokenNode RBraceToken => GetChildByRole(Roles.RBrace);

	public ArrayInitializerExpression()
	{
	}

	public ArrayInitializerExpression(IEnumerable<Expression> elements)
	{
		Elements.AddRange(elements);
	}

	public ArrayInitializerExpression(params Expression[] elements)
	{
		Elements.AddRange(elements);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitArrayInitializerExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitArrayInitializerExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitArrayInitializerExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is ArrayInitializerExpression arrayInitializerExpression && Elements.DoMatch(arrayInitializerExpression.Elements, match);
	}

	public static ArrayInitializerExpression CreateSingleElementInitializer()
	{
		return new SingleArrayInitializerExpression();
	}

	public static implicit operator ArrayInitializerExpression(Pattern pattern)
	{
		return (pattern != null) ? new PatternPlaceholder(pattern) : null;
	}
}
