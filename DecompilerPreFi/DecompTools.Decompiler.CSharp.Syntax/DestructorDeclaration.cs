using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class DestructorDeclaration : EntityDeclaration
{
	public static readonly TokenRole TildeRole = new TokenRole("~");

	public CSharpTokenNode TildeToken => GetChildByRole(TildeRole);

	public override SymbolKind SymbolKind => SymbolKind.Destructor;

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public BlockStatement Body
	{
		get
		{
			return GetChildByRole(Roles.Body);
		}
		set
		{
			SetChildByRole(Roles.Body, value);
		}
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitDestructorDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitDestructorDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitDestructorDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is DestructorDeclaration destructorDeclaration && MatchAttributesAndModifiers(destructorDeclaration, match) && Body.DoMatch(destructorDeclaration.Body, match);
	}
}
