using System.Collections.Generic;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class CompilationUnit : AstNode
{
	public static readonly Role<AstNode> MemberRole = new Role<AstNode>("Member", AstNode.Null);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is CompilationUnit compilationUnit)
		{
			return GetChildrenByRole(MemberRole).DoMatch(compilationUnit.GetChildrenByRole(MemberRole), match);
		}
		return false;
	}

	public AstNode GetNodeAt(int line, int column)
	{
		return GetNodeAt(new TextLocation(line, column));
	}

	public AstNode GetNodeAt(TextLocation location)
	{
		AstNode astNode = this;
		while (astNode.FirstChild != null)
		{
			AstNode astNode2;
			for (astNode2 = astNode.FirstChild; astNode2 != null; astNode2 = astNode2.NextSibling)
			{
				if (astNode2.StartLocation <= location && location < astNode2.EndLocation)
				{
					astNode = astNode2;
					break;
				}
			}
			if (astNode2 == null)
			{
				break;
			}
		}
		return astNode;
	}

	public IEnumerable<AstNode> GetNodesBetween(int startLine, int startColumn, int endLine, int endColumn)
	{
		return GetNodesBetween(new TextLocation(startLine, startColumn), new TextLocation(endLine, endColumn));
	}

	public IEnumerable<AstNode> GetNodesBetween(TextLocation start, TextLocation end)
	{
		AstNode astNode = this;
		while (astNode != null)
		{
			AstNode next;
			if (!(start <= astNode.StartLocation) || !(astNode.EndLocation <= end))
			{
				next = ((!(astNode.EndLocation < start)) ? astNode.FirstChild : astNode.NextSibling);
			}
			else
			{
				next = astNode.NextSibling;
				yield return astNode;
			}
			if (next != null && next.StartLocation > end)
			{
				break;
			}
			astNode = next;
		}
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitCompilationUnit(this, data);
	}
}
