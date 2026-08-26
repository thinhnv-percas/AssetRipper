using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class TupleExpression : Expression
{
	public AstNodeCollection<Expression> Elements => GetChildrenByRole(Roles.Expression);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitTupleExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitTupleExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitTupleExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is TupleExpression tupleExpression && Elements.DoMatch(tupleExpression.Elements, match);
	}
}
