using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class MethodDeclaration : EntityDeclaration
{
	public override SymbolKind SymbolKind => SymbolKind.Method;

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

	public AstNodeCollection<TypeParameterDeclaration> TypeParameters => GetChildrenByRole(Roles.TypeParameter);

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public AstNodeCollection<Constraint> Constraints => GetChildrenByRole(Roles.Constraint);

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

	public bool IsExtensionMethod
	{
		get
		{
			ParameterDeclaration childByRole = GetChildByRole(Roles.Parameter);
			return childByRole != null && childByRole.ParameterModifier == ParameterModifier.This;
		}
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitMethodDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitMethodDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitMethodDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is MethodDeclaration methodDeclaration && AstNode.MatchString(Name, methodDeclaration.Name) && MatchAttributesAndModifiers(methodDeclaration, match) && ReturnType.DoMatch(methodDeclaration.ReturnType, match) && PrivateImplementationType.DoMatch(methodDeclaration.PrivateImplementationType, match) && TypeParameters.DoMatch(methodDeclaration.TypeParameters, match) && Parameters.DoMatch(methodDeclaration.Parameters, match) && Constraints.DoMatch(methodDeclaration.Constraints, match) && Body.DoMatch(methodDeclaration.Body, match);
	}
}
