using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ComparisonCaseClause : CaseClause
{
	public static readonly Role<VBTokenNode> OperatorRole = BinaryOperatorExpression.OperatorRole;

	public ComparisonOperator Operator { get; set; }

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitComparisonCaseClause(this, data);
	}
}
