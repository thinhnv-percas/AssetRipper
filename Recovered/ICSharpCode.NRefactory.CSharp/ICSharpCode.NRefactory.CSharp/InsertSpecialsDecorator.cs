using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class InsertSpecialsDecorator : DecoratingTokenWriter
	{
		private readonly Stack<AstNode> positionStack = new Stack<AstNode>();

		private int visitorWroteNewLine;

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
			AstNode start = positionStack.Pop();
			WriteSpecials(start, null);
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
			visitorWroteNewLine++;
		}

		private void WriteSpecials(AstNode start, AstNode end)
		{
			for (AstNode astNode = start; astNode != end; astNode = astNode.NextSibling)
			{
				if (astNode.Role == Roles.Comment)
				{
					Comment comment = (Comment)astNode;
					WriteComment(comment.CommentType, comment.Content);
				}
				if (astNode.Role == Roles.PreProcessorDirective)
				{
					PreProcessorDirective preProcessorDirective = (PreProcessorDirective)astNode;
					WritePreProcessorDirective(preProcessorDirective.Type, preProcessorDirective.Argument);
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
			while (true)
			{
				if (astNode != null && astNode != nextNode)
				{
					if (astNode.Role == role)
					{
						break;
					}
					astNode = astNode.NextSibling;
					continue;
				}
				return;
			}
			WriteSpecials(positionStack.Pop(), astNode);
			positionStack.Push(astNode.NextSibling);
		}

		private void WriteSpecialsUpToNode(AstNode node)
		{
			if (positionStack.Count == 0)
			{
				return;
			}
			AstNode astNode = positionStack.Peek();
			while (true)
			{
				if (astNode != null)
				{
					if (astNode == node)
					{
						break;
					}
					astNode = astNode.NextSibling;
					continue;
				}
				return;
			}
			WriteSpecials(positionStack.Pop(), astNode);
			positionStack.Push(astNode.NextSibling);
		}
	}
}
