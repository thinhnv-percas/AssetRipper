using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class AggregateQueryOperator : QueryOperator
{
	public CollectionRangeVariableDeclaration Variable
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

	public AstNodeCollection<QueryOperator> SubQueryOperators => GetChildrenByRole(QueryOperator.QueryOperatorRole);

	public AstNodeCollection<VariableInitializer> IntoExpressions => GetChildrenByRole(VariableInitializer.VariableInitializerRole);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitAggregateQueryOperator(this, data);
	}
}
