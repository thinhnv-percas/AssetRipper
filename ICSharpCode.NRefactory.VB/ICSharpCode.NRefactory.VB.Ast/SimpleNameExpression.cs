using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class SimpleNameExpression : Expression
{
	public Identifier Identifier { get; set; }

	public AstNodeCollection<AstType> TypeArguments => GetChildrenByRole(Roles.TypeArgument);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is SimpleNameExpression simpleNameExpression && Identifier.DoMatch(simpleNameExpression.Identifier, match))
		{
			return TypeArguments.DoMatch(simpleNameExpression.TypeArguments, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitSimpleNameExpression(this, data);
	}
}
