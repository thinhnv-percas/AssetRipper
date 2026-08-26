using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
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
			foreach (AstNode item in from n in node.Children
				where n is CSharpTokenNode
				select n)
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

		public override void WriteToken(Role role, string token)
		{
			CSharpTokenNode cSharpTokenNode = new CSharpTokenNode(locationProvider.Location, (TokenRole)role);
			cSharpTokenNode.Role = role;
			EmptyStatement emptyStatement = nodes.Peek().LastOrDefault() as EmptyStatement;
			if (emptyStatement == null)
			{
				currentList.Add(cSharpTokenNode);
			}
			else
			{
				emptyStatement.Location = locationProvider.Location;
			}
			base.WriteToken(role, token);
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
				ThisReferenceExpression thisReferenceExpression = nodes.Peek().LastOrDefault() as ThisReferenceExpression;
				if (thisReferenceExpression != null)
				{
					thisReferenceExpression.Location = location;
				}
			}
			else if (keyword == "base")
			{
				BaseReferenceExpression baseReferenceExpression = nodes.Peek().LastOrDefault() as BaseReferenceExpression;
				if (baseReferenceExpression != null)
				{
					baseReferenceExpression.Location = location;
				}
			}
			if (cSharpTokenNode != null)
			{
				currentList.Add(cSharpTokenNode);
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
			Expression expression = nodes.Peek().LastOrDefault() as Expression;
			if (expression is PrimitiveExpression)
			{
				((PrimitiveExpression)expression).SetStartLocation(locationProvider.Location);
			}
			if (expression is NullReferenceExpression)
			{
				((NullReferenceExpression)expression).SetStartLocation(locationProvider.Location);
			}
			base.WritePrimitiveValue(value, literalValue);
		}

		public override void WritePrimitiveType(string type)
		{
			(nodes.Peek().LastOrDefault() as PrimitiveType)?.SetStartLocation(locationProvider.Location);
			base.WritePrimitiveType(type);
		}
	}
}
