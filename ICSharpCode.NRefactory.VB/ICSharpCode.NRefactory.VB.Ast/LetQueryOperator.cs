using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class LetQueryOperator : QueryOperator
{
	public AstNodeCollection<VariableInitializer> Variables => GetChildrenByRole(VariableInitializer.VariableInitializerRole);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitLetQueryOperator(this, data);
	}
}
