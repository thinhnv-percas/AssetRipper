using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ParameterDeclaration : AttributedNode
{
	public Identifier Name
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

	public Expression OptionalValue
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

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ParameterDeclaration parameterDeclaration && MatchAttributesAndModifiers(parameterDeclaration, match) && Name.DoMatch(parameterDeclaration.Name, match) && OptionalValue.DoMatch(parameterDeclaration.OptionalValue, match))
		{
			return Type.DoMatch(parameterDeclaration.Type, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitParameterDeclaration(this, data);
	}
}
