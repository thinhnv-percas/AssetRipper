using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp;

public class ConstructorDeclaration : EntityDeclaration
{
	public static readonly Role<ConstructorInitializer> InitializerRole = new Role<ConstructorInitializer>("Initializer", ConstructorInitializer.Null);

	public override SymbolKind SymbolKind => SymbolKind.Constructor;

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public CSharpTokenNode ColonToken => GetChildByRole(Roles.Colon);

	public ConstructorInitializer Initializer
	{
		get
		{
			return GetChildByRole(InitializerRole);
		}
		set
		{
			SetChildByRole(InitializerRole, value);
		}
	}

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
		visitor.VisitConstructorDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitConstructorDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitConstructorDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ConstructorDeclaration constructorDeclaration && MatchAttributesAndModifiers(constructorDeclaration, match) && Parameters.DoMatch(constructorDeclaration.Parameters, match) && Initializer.DoMatch(constructorDeclaration.Initializer, match))
		{
			return Body.DoMatch(constructorDeclaration.Body, match);
		}
		return false;
	}
}
