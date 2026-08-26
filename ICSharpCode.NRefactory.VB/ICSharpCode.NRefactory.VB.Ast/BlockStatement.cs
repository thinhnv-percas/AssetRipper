using System.Collections;
using System.Collections.Generic;
using dnSpy.Contracts.Decompiler;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class BlockStatement : Statement, IEnumerable<Statement>, IEnumerable
{
	private sealed class NullBlockStatement : BlockStatement
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

	private sealed class PatternPlaceholder : BlockStatement, INode
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

	public static readonly Role<Statement> StatementRole = new Role<Statement>("Statement", Statement.Null);

	public new static readonly BlockStatement Null = new NullBlockStatement();

	public AstNodeCollection<Statement> Statements => GetChildrenByRole(StatementRole);

	public IList<ILSpan> HiddenStart { get; set; }

	public IList<ILSpan> HiddenEnd { get; set; }

	public static implicit operator BlockStatement(Pattern pattern)
	{
		if (pattern == null)
		{
			return null;
		}
		return new PatternPlaceholder(pattern);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitBlockStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is BlockStatement blockStatement && !(blockStatement is CatchBlock) && !blockStatement.IsNull)
		{
			return Statements.DoMatch(blockStatement.Statements, match);
		}
		return false;
	}

	public void Add(Statement statement)
	{
		AddChild(statement, StatementRole);
	}

	public void Add(Expression expression)
	{
		AddChild(new ExpressionStatement
		{
			Expression = expression
		}, StatementRole);
	}

	public void AddRange(IEnumerable<Statement> statements)
	{
		foreach (Statement statement in statements)
		{
			AddChild(statement, StatementRole);
		}
	}

	public void AddAssignment(Expression left, Expression right)
	{
		Add(new AssignmentExpression(left, AssignmentOperatorType.Assign, right));
	}

	public void AddReturnStatement(Expression expression)
	{
		Add(new ReturnStatement
		{
			Expression = expression
		});
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
