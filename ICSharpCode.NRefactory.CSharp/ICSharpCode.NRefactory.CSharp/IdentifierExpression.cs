using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

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
			SetChildByRole(Roles.Identifier, ICSharpCode.NRefactory.CSharp.Identifier.Create(value));
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

	public IdentifierExpression(Identifier identifier)
	{
		IdentifierToken = identifier;
	}

	public IdentifierExpression(string identifier)
	{
		Identifier = identifier;
	}

	public IdentifierExpression(string identifier, TextLocation location)
	{
		SetChildByRole(Roles.Identifier, ICSharpCode.NRefactory.CSharp.Identifier.Create(identifier, location));
	}

	public static IdentifierExpression Create(string identifier, object annotation, bool addAnnotationToExpr = false)
	{
		IdentifierExpression identifierExpression = new IdentifierExpression(identifier);
		if (annotation != null)
		{
			if (addAnnotationToExpr)
			{
				identifierExpression.AddAnnotation(annotation);
			}
			identifierExpression.IdentifierToken.AddAnnotation(annotation);
		}
		return identifierExpression;
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
		if (other is IdentifierExpression identifierExpression && AstNode.MatchString(Identifier, identifierExpression.Identifier))
		{
			return TypeArguments.DoMatch(identifierExpression.TypeArguments, match);
		}
		return false;
	}
}
