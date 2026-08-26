#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;

namespace DecompTools.Decompiler.CSharp.OutputVisitor;

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
		if (node.NodeType != NodeType.Whitespace)
		{
			currentList.Add(node);
			nodes.Push(currentList);
			currentList = new List<AstNode>();
		}
		base.StartNode(node);
	}

	public override void EndNode(AstNode node)
	{
		if (node.NodeType != NodeType.Whitespace)
		{
			Debug.Assert(currentList != null);
			foreach (AstNode item in Enumerable.Where<AstNode>(node.Children, (Func<AstNode, bool>)((AstNode n) => n is CSharpTokenNode)))
			{
				item.Remove();
			}
			foreach (AstNode current in currentList)
			{
				Debug.Assert(current.Parent == null || node == current.Parent);
				current.Remove();
				node.AddChildWithExistingRole(current);
			}
			currentList = nodes.Pop();
		}
		base.EndNode(node);
	}

	public override void WriteToken(Role role, string token)
	{
		AstNode astNode = Enumerable.LastOrDefault<AstNode>((IEnumerable<AstNode>)nodes.Peek());
		AstNode astNode2 = astNode;
		if (astNode2 == null)
		{
			goto IL_0069;
		}
		if (!(astNode2 is EmptyStatement emptyStatement))
		{
			if (!(astNode2 is ErrorExpression errorExpression))
			{
				goto IL_0069;
			}
			ErrorExpression errorExpression2 = errorExpression;
			errorExpression2.Location = locationProvider.Location;
		}
		else
		{
			EmptyStatement emptyStatement2 = emptyStatement;
			emptyStatement2.Location = locationProvider.Location;
		}
		goto IL_0097;
		IL_0097:
		base.WriteToken(role, token);
		return;
		IL_0069:
		CSharpTokenNode cSharpTokenNode = new CSharpTokenNode(locationProvider.Location, (TokenRole)role);
		cSharpTokenNode.Role = role;
		currentList.Add(cSharpTokenNode);
		goto IL_0097;
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
			if (Enumerable.LastOrDefault<AstNode>((IEnumerable<AstNode>)nodes.Peek()) is ThisReferenceExpression thisReferenceExpression)
			{
				thisReferenceExpression.Location = location;
			}
		}
		else if (keyword == "base" && Enumerable.LastOrDefault<AstNode>((IEnumerable<AstNode>)nodes.Peek()) is BaseReferenceExpression baseReferenceExpression)
		{
			baseReferenceExpression.Location = location;
		}
		if (cSharpTokenNode != null)
		{
			currentList.Add(cSharpTokenNode);
			cSharpTokenNode.Role = role;
		}
		base.WriteKeyword(role, keyword);
	}

	public override void WriteIdentifier(Identifier identifier)
	{
		if (!identifier.IsNull)
		{
			identifier.SetStartLocation(locationProvider.Location);
		}
		currentList.Add(identifier);
		base.WriteIdentifier(identifier);
	}

	public override void WritePrimitiveValue(object value, string literalValue = null)
	{
		Expression expression = Enumerable.LastOrDefault<AstNode>((IEnumerable<AstNode>)nodes.Peek()) as Expression;
		TextLocation location = locationProvider.Location;
		base.WritePrimitiveValue(value, literalValue);
		if (expression is PrimitiveExpression)
		{
			((PrimitiveExpression)expression).SetLocation(location, locationProvider.Location);
		}
		if (expression is NullReferenceExpression)
		{
			((NullReferenceExpression)expression).SetStartLocation(location);
		}
	}

	public override void WritePrimitiveType(string type)
	{
		if (Enumerable.LastOrDefault<AstNode>((IEnumerable<AstNode>)nodes.Peek()) is PrimitiveType primitiveType)
		{
			primitiveType.SetStartLocation(locationProvider.Location);
		}
		base.WritePrimitiveType(type);
	}
}
