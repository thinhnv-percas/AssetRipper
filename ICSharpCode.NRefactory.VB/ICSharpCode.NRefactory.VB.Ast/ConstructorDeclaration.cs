using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ConstructorDeclaration : MemberDeclaration
{
	public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

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

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ConstructorDeclaration constructorDeclaration && MatchAttributesAndModifiers(constructorDeclaration, match) && Parameters.DoMatch(constructorDeclaration.Parameters, match))
		{
			return Body.DoMatch(constructorDeclaration.Body, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitConstructorDeclaration(this, data);
	}
}
