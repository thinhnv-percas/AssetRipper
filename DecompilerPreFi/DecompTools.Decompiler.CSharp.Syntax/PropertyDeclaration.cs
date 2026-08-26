using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class PropertyDeclaration : EntityDeclaration
{
	public static readonly TokenRole GetKeywordRole = new TokenRole("get");

	public static readonly TokenRole SetKeywordRole = new TokenRole("set");

	public static readonly Role<Accessor> GetterRole = new Role<Accessor>("Getter", Accessor.Null);

	public static readonly Role<Accessor> SetterRole = new Role<Accessor>("Setter", Accessor.Null);

	public static readonly Role<Expression> ExpressionBodyRole = new Role<Expression>("ExpressionBody", Expression.Null);

	public override SymbolKind SymbolKind => SymbolKind.Property;

	public AstType PrivateImplementationType
	{
		get
		{
			return GetChildByRole(EntityDeclaration.PrivateImplementationTypeRole);
		}
		set
		{
			SetChildByRole(EntityDeclaration.PrivateImplementationTypeRole, value);
		}
	}

	public CSharpTokenNode LBraceToken => GetChildByRole(Roles.LBrace);

	public Accessor Getter
	{
		get
		{
			return GetChildByRole(GetterRole);
		}
		set
		{
			SetChildByRole(GetterRole, value);
		}
	}

	public Accessor Setter
	{
		get
		{
			return GetChildByRole(SetterRole);
		}
		set
		{
			SetChildByRole(SetterRole, value);
		}
	}

	public CSharpTokenNode RBraceToken => GetChildByRole(Roles.RBrace);

	public CSharpTokenNode AssignToken => GetChildByRole(Roles.Assign);

	public Expression Initializer
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

	public Expression ExpressionBody
	{
		get
		{
			return GetChildByRole(ExpressionBodyRole);
		}
		set
		{
			SetChildByRole(ExpressionBodyRole, value);
		}
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitPropertyDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitPropertyDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitPropertyDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is PropertyDeclaration propertyDeclaration && AstNode.MatchString(Name, propertyDeclaration.Name) && MatchAttributesAndModifiers(propertyDeclaration, match) && ReturnType.DoMatch(propertyDeclaration.ReturnType, match) && PrivateImplementationType.DoMatch(propertyDeclaration.PrivateImplementationType, match) && Getter.DoMatch(propertyDeclaration.Getter, match) && Setter.DoMatch(propertyDeclaration.Setter, match) && Initializer.DoMatch(propertyDeclaration.Initializer, match) && ExpressionBody.DoMatch(propertyDeclaration.ExpressionBody, match);
	}
}
