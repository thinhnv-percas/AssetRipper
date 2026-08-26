using System.Collections;
using System.Collections.Generic;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class BlockStatement : Statement, IEnumerable<Statement>, IEnumerable
{
	private sealed class NullBlockStatement : BlockStatement
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

	private sealed class PatternPlaceholder : BlockStatement, INode
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

	public static readonly Role<Statement> StatementRole = new Role<Statement>("Statement", Statement.Null);

	public new static readonly BlockStatement Null = new NullBlockStatement();

	public CSharpTokenNode LBraceToken => GetChildByRole(Roles.LBrace);

	public AstNodeCollection<Statement> Statements => GetChildrenByRole(StatementRole);

	public CSharpTokenNode RBraceToken => GetChildByRole(Roles.RBrace);

	public AstNode HiddenStart { get; set; }

	public AstNode HiddenEnd { get; set; }

	public static implicit operator BlockStatement(Pattern pattern)
	{
		if (pattern == null)
		{
			return null;
		}
		return new PatternPlaceholder(pattern);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitBlockStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitBlockStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitBlockStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is BlockStatement { IsNull: false } blockStatement)
		{
			return Statements.DoMatch(blockStatement.Statements, match);
		}
		return false;
	}

	public void Add(Statement statement)
	{
		AddChild(statement, StatementRole);
	}

	IEnumerator<Statement> IEnumerable<Statement>.GetEnumerator()
	{
		return Statements.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return Statements.GetEnumerator();
	}
}
