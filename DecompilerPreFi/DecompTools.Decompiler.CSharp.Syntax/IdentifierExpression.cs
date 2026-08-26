using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class IdentifierExpression : Expression
{
	public string Identifier
	{
		get
		{
			return GetChildByRole(Roles.Identifier).Name;
		}
		set
		{
			SetChildByRole(Roles.Identifier, DecompTools.Decompiler.CSharp.Syntax.Identifier.Create(value));
		}
	}

	public Identifier IdentifierToken
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

	public AstNodeCollection<AstType> TypeArguments => GetChildrenByRole(Roles.TypeArgument);

	public IdentifierExpression()
	{
	}

	public IdentifierExpression(string identifier)
	{
		Identifier = identifier;
	}

	public IdentifierExpression(string identifier, TextLocation location)
	{
		SetChildByRole(Roles.Identifier, DecompTools.Decompiler.CSharp.Syntax.Identifier.Create(identifier, location));
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitIdentifierExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitIdentifierExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitIdentifierExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is IdentifierExpression identifierExpression && AstNode.MatchString(Identifier, identifierExpression.Identifier) && TypeArguments.DoMatch(identifierExpression.TypeArguments, match);
	}
}
