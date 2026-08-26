using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class GroupJoinQueryOperator : JoinQueryOperator
{
	public static readonly Role<VariableInitializer> IntoExpressionRole = GroupByQueryOperator.IntoExpressionRole;

	public AstNodeCollection<VariableInitializer> IntoExpressions => GetChildrenByRole(IntoExpressionRole);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitGroupJoinQueryOperator(this, data);
	}
}
