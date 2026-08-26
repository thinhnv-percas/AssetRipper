using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class GroupByQueryOperator : QueryOperator
{
	public static readonly Role<VariableInitializer> GroupExpressionRole = new Role<VariableInitializer>("GroupExpression");

	public static readonly Role<VariableInitializer> ByExpressionRole = new Role<VariableInitializer>("ByExpression");

	public static readonly Role<VariableInitializer> IntoExpressionRole = new Role<VariableInitializer>("IntoExpression");

	public AstNodeCollection<VariableInitializer> GroupExpressions => GetChildrenByRole(GroupExpressionRole);

	public AstNodeCollection<VariableInitializer> ByExpressions => GetChildrenByRole(ByExpressionRole);

	public AstNodeCollection<VariableInitializer> IntoExpressions => GetChildrenByRole(IntoExpressionRole);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitGroupByQueryOperator(this, data);
	}
}
