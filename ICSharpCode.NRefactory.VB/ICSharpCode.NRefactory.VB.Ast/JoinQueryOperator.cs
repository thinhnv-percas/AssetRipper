using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class JoinQueryOperator : QueryOperator
{
	private sealed class NullJoinQueryOperator : JoinQueryOperator
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

	public new static readonly JoinQueryOperator Null = new NullJoinQueryOperator();

	public static readonly Role<JoinQueryOperator> JoinQueryOperatorRole = new Role<JoinQueryOperator>("JoinQueryOperator", Null);

	public CollectionRangeVariableDeclaration JoinVariable
	{
		get
		{
			return GetChildByRole(CollectionRangeVariableDeclaration.CollectionRangeVariableDeclarationRole);
		}
		set
		{
			SetChildByRole(CollectionRangeVariableDeclaration.CollectionRangeVariableDeclarationRole, value);
		}
	}

	public JoinQueryOperator SubJoinQuery
	{
		get
		{
			return GetChildByRole(JoinQueryOperatorRole);
		}
		set
		{
			SetChildByRole(JoinQueryOperatorRole, value);
		}
	}

	public AstNodeCollection<JoinCondition> JoinConditions => GetChildrenByRole(JoinCondition.JoinConditionRole);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitJoinQueryOperator(this, data);
	}
}
