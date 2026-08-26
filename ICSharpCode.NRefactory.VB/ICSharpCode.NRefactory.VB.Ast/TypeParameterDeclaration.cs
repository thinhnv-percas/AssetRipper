using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.VB.Ast;

public class TypeParameterDeclaration : AstNode
{
	public static readonly Role<AstType> TypeConstraintRole = TypeDeclaration.InheritsTypeRole;

	public static readonly Role<VBTokenNode> VarianceRole = new Role<VBTokenNode>("Variance");

	public VarianceModifier Variance { get; set; }

	public string Name => GetChildByRole(Roles.Identifier).Name;

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

	public AstNodeCollection<AstType> Constraints => GetChildrenByRole(TypeConstraintRole);

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitTypeParameterDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is TypeParameterDeclaration typeParameterDeclaration && Variance == typeParameterDeclaration.Variance && AstNode.MatchString(Name, typeParameterDeclaration.Name))
		{
			return Constraints.DoMatch(typeParameterDeclaration.Constraints, match);
		}
		return false;
	}
}
