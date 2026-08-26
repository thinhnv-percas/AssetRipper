using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

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

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitTypeReferenceExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitTypeReferenceExpression(this);
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
		AddChild(type, Roles.Type);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is TypeReferenceExpression typeReferenceExpression && Type.DoMatch(typeReferenceExpression.Type, match);
	}
}
