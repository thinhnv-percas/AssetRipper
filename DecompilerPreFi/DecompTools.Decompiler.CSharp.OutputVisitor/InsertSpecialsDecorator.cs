#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using DecompTools.Decompiler.CSharp.Syntax;

namespace DecompTools.Decompiler.CSharp.OutputVisitor;

internal class InsertSpecialsDecorator : DecoratingTokenWriter
{
	private readonly Stack<AstNode> positionStack = new Stack<AstNode>();

	private int visitorWroteNewLine = 0;

	public InsertSpecialsDecorator(TokenWriter writer)
		: base(writer)
	{
	}

	public override void StartNode(AstNode node)
	{
		if (positionStack.Count > 0)
		{
			WriteSpecialsUpToNode(node);
		}
		positionStack.Push(node.FirstChild);
		base.StartNode(node);
	}

	public override void EndNode(AstNode node)
	{
		base.EndNode(node);
		AstNode astNode = positionStack.Pop();
		Debug.Assert(astNode == null || astNode.Parent == node);
		WriteSpecials(astNode, null);
	}

	public override void WriteKeyword(Role role, string keyword)
	{
		if (role != null)
		{
			WriteSpecialsUpToRole(role);
		}
		base.WriteKeyword(role, keyword);
	}

	public override void WriteIdentifier(Identifier identifier)
	{
		WriteSpecialsUpToRole(identifier.Role ?? Roles.Identifier);
		base.WriteIdentifier(identifier);
	}

	public override void WriteToken(Role role, string token)
	{
		WriteSpecialsUpToRole(role);
		base.WriteToken(role, token);
	}

	public override void NewLine()
	{
		if (visitorWroteNewLine >= 0)
		{
			base.NewLine();
		}
		checked
		{
			visitorWroteNewLine++;
		}
	}

	private void WriteSpecials(AstNode start, AstNode end)
	{
		for (AstNode astNode = start; astNode != end; astNode = astNode.NextSibling)
		{
			if (astNode.Role == Roles.Comment)
			{
				Comment comment = (Comment)astNode;
				base.StartNode((AstNode)comment);
				WriteComment(comment.CommentType, comment.Content);
				base.EndNode((AstNode)comment);
			}
			if (astNode.Role == Roles.PreProcessorDirective)
			{
				PreProcessorDirective preProcessorDirective = (PreProcessorDirective)astNode;
				base.StartNode((AstNode)preProcessorDirective);
				WritePreProcessorDirective(preProcessorDirective.Type, preProcessorDirective.Argument);
				base.EndNode((AstNode)preProcessorDirective);
			}
		}
	}

	private void WriteSpecialsUpToRole(Role role)
	{
		WriteSpecialsUpToRole(role, null);
	}

	private void WriteSpecialsUpToRole(Role role, AstNode nextNode)
	{
		if (positionStack.Count == 0)
		{
			return;
		}
		AstNode astNode = positionStack.Peek();
		while (astNode != null && astNode != nextNode)
		{
			if (astNode.Role == role)
			{
				WriteSpecials(positionStack.Pop(), astNode);
				positionStack.Push(astNode.NextSibling);
				break;
			}
			astNode = astNode.NextSibling;
		}
	}

	private void WriteSpecialsUpToNode(AstNode node)
	{
		if (positionStack.Count == 0)
		{
			return;
		}
		for (AstNode astNode = positionStack.Peek(); astNode != null; astNode = astNode.NextSibling)
		{
			if (astNode == node)
			{
				WriteSpecials(positionStack.Pop(), astNode);
				positionStack.Push(astNode.NextSibling);
				break;
			}
		}
	}
}
