using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class VariableInitializer : AstNode
{
	public static readonly Role<VariableInitializer> VariableInitializerRole = new Role<VariableInitializer>("VariableInitializer");

	public VariableIdentifier Identifier
	{
		get
		{
			return GetChildByRole(VariableIdentifier.VariableIdentifierRole);
		}
		set
		{
			SetChildByRole(VariableIdentifier.VariableIdentifierRole, value);
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

	public VBTokenNode AssignToken => GetChildByRole(Roles.Assign);

	public Expression Expression
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

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitVariableInitializer(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is VariableInitializer variableInitializer && Identifier.DoMatch(variableInitializer.Identifier, match) && Type.DoMatch(variableInitializer.Type, match))
		{
			return Expression.DoMatch(variableInitializer.Expression, match);
		}
		return false;
	}
}
