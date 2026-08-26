using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class TypeOfExpression : Expression
{
	public static readonly TokenRole TypeofKeywordRole = new TokenRole("typeof");

	public CSharpTokenNode TypeOfToken => GetChildByRole(TypeofKeywordRole);

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

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

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public TypeOfExpression()
	{
	}

	public TypeOfExpression(AstType type)
	{
		AddChild(type, Roles.Type);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitTypeOfExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitTypeOfExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitTypeOfExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is TypeOfExpression typeOfExpression && Type.DoMatch(typeOfExpression.Type, match);
	}
}
