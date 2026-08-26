using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class TypeParameterDeclaration : AstNode
{
	public static readonly Role<AttributeSection> AttributeRole = EntityDeclaration.AttributeRole;

	public static readonly TokenRole OutVarianceKeywordRole = new TokenRole("out");

	public static readonly TokenRole InVarianceKeywordRole = new TokenRole("in");

	private VarianceModifier variance;

	public override NodeType NodeType => NodeType.Unknown;

	public AstNodeCollection<AttributeSection> Attributes => GetChildrenByRole(AttributeRole);

	public VarianceModifier Variance
	{
		get
		{
			return variance;
		}
		set
		{
			ThrowIfFrozen();
			variance = value;
		}
	}

	public CSharpTokenNode VarianceToken => Variance switch
	{
		VarianceModifier.Covariant => GetChildByRole(OutVarianceKeywordRole), 
		VarianceModifier.Contravariant => GetChildByRole(InVarianceKeywordRole), 
		_ => CSharpTokenNode.Null, 
	};

	public string Name
	{
		get
		{
			return GetChildByRole(Roles.Identifier).Name;
		}
		set
		{
			SetChildByRole(Roles.Identifier, Identifier.Create(value));
		}
	}

	public Identifier NameToken
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

	public TypeParameterDeclaration()
	{
	}

	public TypeParameterDeclaration(string name)
	{
		Name = name;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitTypeParameterDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitTypeParameterDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitTypeParameterDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is TypeParameterDeclaration typeParameterDeclaration && Variance == typeParameterDeclaration.Variance && AstNode.MatchString(Name, typeParameterDeclaration.Name) && Attributes.DoMatch(typeParameterDeclaration.Attributes, match);
	}
}
