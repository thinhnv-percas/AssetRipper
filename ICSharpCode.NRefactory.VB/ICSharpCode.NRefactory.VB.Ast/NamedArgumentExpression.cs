using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class NamedArgumentExpression : Expression
{
	public Identifier Identifier
	{
		get
		{
			return GetChildByRole(Roles.Identifier);
		}
		set
		{
			SetChildByRole(Roles.Identifier, value);
		}
	}

	public VBTokenNode AssignToken => GetChildByRole(Roles.Assign);

	public Expression Expression
	{
		get
		{
			return GetChildByRole(Roles.Expression);
		}
		set
		{
			SetChildByRole(Roles.Expression, value);
		}
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitNamedArgumentExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is NamedArgumentExpression namedArgumentExpression && Identifier.DoMatch(namedArgumentExpression.Identifier, match))
		{
			return Expression.DoMatch(namedArgumentExpression.Expression, match);
		}
		return false;
	}
}
