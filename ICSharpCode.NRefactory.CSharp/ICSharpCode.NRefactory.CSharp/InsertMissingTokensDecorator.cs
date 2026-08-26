using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp;

internal class InsertMissingTokensDecorator : DecoratingTokenWriter
{
	private readonly Stack<List<AstNode>> nodes = new Stack<List<AstNode>>();

	private List<AstNode> currentList;

	private readonly ILocatable locationProvider;

	public InsertMissingTokensDecorator(TokenWriter writer, ILocatable locationProvider)
		: base(writer)
	{
		this.locationProvider = locationProvider;
		currentList = new List<AstNode>();
	}

	public override void StartNode(AstNode node)
	{
		currentList.Add(node);
		nodes.Push(currentList);
		currentList = new List<AstNode>();
		base.StartNode(node);
	}

	public override void EndNode(AstNode node)
	{
		foreach (AstNode item in node.Children.Where((AstNode n) => n is CSharpTokenNode))
		{
			item.Remove();
		}
		foreach (AstNode current in currentList)
		{
			current.Remove();
			node.AddChildWithExistingRole(current);
		}
		currentList = nodes.Pop();
		base.EndNode(node);
	}

	public override void WriteToken(Role role, string token, object data)
	{
		CSharpTokenNode cSharpTokenNode = new CSharpTokenNode(locationProvider.Location, (TokenRole)role);
		cSharpTokenNode.Role = role;
		if (!(nodes.Peek().LastOrDefault() is EmptyStatement emptyStatement))
		{
			currentList.Add(cSharpTokenNode);
		}
		else
		{
			emptyStatement.Location = locationProvider.Location;
		}
		base.WriteToken(role, token, data);
	}

	public override void WriteKeyword(Role role, string keyword)
	{
		TextLocation location = locationProvider.Location;
		CSharpTokenNode cSharpTokenNode = null;
		if (role is TokenRole)
		{
			cSharpTokenNode = new CSharpTokenNode(location, (TokenRole)role);
		}
		else if (role == EntityDeclaration.ModifierRole)
		{
			cSharpTokenNode = new CSharpModifierToken(location, CSharpModifierToken.GetModifierValue(keyword));
		}
		else if (keyword == "this")
		{
			if (nodes.Peek().LastOrDefault() is ThisReferenceExpression thisReferenceExpression)
			{
				thisReferenceExpression.Location = location;
			}
		}
		else if (keyword == "base" && nodes.Peek().LastOrDefault() is BaseReferenceExpression baseReferenceExpression)
		{
			baseReferenceExpression.Location = location;
		}
		if (cSharpTokenNode != null)
		{
			currentList.Add(cSharpTokenNode);
		}
		base.WriteKeyword(role, keyword);
	}

	public override void WriteIdentifier(Identifier identifier, object data)
	{
		if (!identifier.IsNull)
		{
			identifier.SetStartLocation(locationProvider.Location);
		}
		currentList.Add(identifier);
		base.WriteIdentifier(identifier, data);
	}

	public override void WritePrimitiveValue(object value, object data = null, string literalValue = null)
	{
		Expression expression = nodes.Peek().LastOrDefault() as Expression;
		if (expression is PrimitiveExpression)
		{
			((PrimitiveExpression)expression).SetStartLocation(locationProvider.Location);
		}
		if (expression is NullReferenceExpression)
		{
			((NullReferenceExpression)expression).SetStartLocation(locationProvider.Location);
		}
		base.WritePrimitiveValue(value, data, literalValue);
	}

	public override void WritePrimitiveType(string type)
	{
		if (nodes.Peek().LastOrDefault() is PrimitiveType primitiveType)
		{
			primitiveType.SetStartLocation(locationProvider.Location);
		}
		base.WritePrimitiveType(type);
	}
}
