using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class FixedVariableInitializer : AstNode
{
	public override NodeType NodeType => NodeType.Unknown;

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

	public CSharpTokenNode LBracketToken => GetChildByRole(Roles.LBracket);

	public Expression CountExpression
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

	public CSharpTokenNode RBracketToken => GetChildByRole(Roles.RBracket);

	public FixedVariableInitializer()
	{
	}

	public FixedVariableInitializer(string name, Expression initializer = null)
	{
		Name = name;
		CountExpression = initializer;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitFixedVariableInitializer(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitFixedVariableInitializer(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitFixedVariableInitializer(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is FixedVariableInitializer fixedVariableInitializer && AstNode.MatchString(Name, fixedVariableInitializer.Name) && CountExpression.DoMatch(fixedVariableInitializer.CountExpression, match);
	}
}
