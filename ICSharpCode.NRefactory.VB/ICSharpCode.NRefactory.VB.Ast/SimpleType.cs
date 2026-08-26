using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class SimpleType : AstType
{
	public string Identifier => GetChildByRole(Roles.Identifier).Name;

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

	public static SimpleType CreateWithColor(object color, string identifier)
	{
		return new SimpleType(identifier, color);
	}

	public static SimpleType CreateWithColor(object color, string identifier, TextLocation location)
	{
		return new SimpleType(identifier, color, location);
	}

	public SimpleType(Identifier identifier)
	{
		IdentifierToken = identifier;
	}

	public SimpleType(IEnumerable<object> annotations, string identifier)
	{
		IdentifierToken = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(annotations, identifier);
	}

	private SimpleType(string identifier, object data)
	{
		IdentifierToken = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(data, identifier);
	}

	private SimpleType(string identifier, object data, TextLocation location)
	{
		SetChildByRole(Roles.Identifier, new Identifier(data, identifier, location));
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitSimpleType(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is SimpleType simpleType && AstNode.MatchString(Identifier, simpleType.Identifier))
		{
			return TypeArguments.DoMatch(simpleType.TypeArguments, match);
		}
		return false;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(Identifier);
		if (TypeArguments.Any())
		{
			stringBuilder.Append('(');
			stringBuilder.Append("Of ");
			stringBuilder.Append(string.Join(", ", TypeArguments));
			stringBuilder.Append(')');
		}
		return stringBuilder.ToString();
	}
}
