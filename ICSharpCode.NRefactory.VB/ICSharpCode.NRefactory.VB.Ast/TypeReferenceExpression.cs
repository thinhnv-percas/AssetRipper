using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class TypeReferenceExpression : Expression
{
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

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitTypeReferenceExpression(this, data);
	}

	public TypeReferenceExpression()
	{
	}

	public TypeReferenceExpression(AstType type)
	{
		SetChildByRole(Roles.Type, type);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is TypeReferenceExpression typeReferenceExpression)
		{
			return Type.DoMatch(typeReferenceExpression.Type, match);
		}
		return false;
	}
}
