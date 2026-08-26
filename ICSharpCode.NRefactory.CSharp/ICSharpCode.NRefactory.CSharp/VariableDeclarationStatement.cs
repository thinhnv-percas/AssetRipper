using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class VariableDeclarationStatement : Statement
{
	public static readonly Role<CSharpModifierToken> ModifierRole = EntityDeclaration.ModifierRole;

	public Modifiers Modifiers
	{
		get
		{
			return EntityDeclaration.GetModifiers(this);
		}
		set
		{
			EntityDeclaration.SetModifiers(this, value);
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

	public AstNodeCollection<VariableInitializer> Variables => GetChildrenByRole(Roles.Variable);

	public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

	public VariableDeclarationStatement()
	{
	}

	public VariableDeclarationStatement(object annotations, AstType type, string name, Expression initializer = null)
	{
		Type = type;
		Variables.Add(new VariableInitializer(annotations, name, initializer));
	}

	public VariableInitializer GetVariable(string name)
	{
		return Variables.FirstOrNullObject((VariableInitializer vi) => vi.Name == name);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitVariableDeclarationStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitVariableDeclarationStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitVariableDeclarationStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is VariableDeclarationStatement variableDeclarationStatement && Modifiers == variableDeclarationStatement.Modifiers && Type.DoMatch(variableDeclarationStatement.Type, match))
		{
			return Variables.DoMatch(variableDeclarationStatement.Variables, match);
		}
		return false;
	}
}
