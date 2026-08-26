using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class FromQueryOperator : QueryOperator
{
	public AstNodeCollection<CollectionRangeVariableDeclaration> Variables => GetChildrenByRole(CollectionRangeVariableDeclaration.CollectionRangeVariableDeclarationRole);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitFromQueryOperator(this, data);
	}
}
