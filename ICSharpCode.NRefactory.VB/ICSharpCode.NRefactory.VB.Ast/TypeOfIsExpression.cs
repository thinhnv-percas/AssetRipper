using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class TypeOfIsExpression : Expression
{
	public Expression TypeOfExpression
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

	public AstType Type
	{
		get
		{
			return GetChildByRole(Roles.Type);
		}
		set
		{
			SetChildByRole(Roles.Type, value);
		}
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is TypeOfIsExpression typeOfIsExpression && TypeOfExpression.DoMatch(typeOfIsExpression.TypeOfExpression, match))
		{
			return Type.DoMatch(typeOfIsExpression.Type, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitTypeOfIsExpression(this, data);
	}
}
