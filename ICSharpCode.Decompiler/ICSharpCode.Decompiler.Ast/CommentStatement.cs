using System;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.Decompiler.Ast;

internal class CommentStatement : Statement
{
	private string comment;

	public CommentStatement(string comment)
	{
		if (comment == null)
		{
			throw new ArgumentNullException("comment");
		}
		this.comment = comment;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return default(T);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return default(S);
	}

	public static void ReplaceAll(AstNode tree)
	{
		foreach (CommentStatement item in tree.Descendants.OfType<CommentStatement>())
		{
			item.Parent.InsertChildBefore(item, new Comment(item.comment), Roles.Comment);
			item.Remove();
		}
	}

	protected override bool DoMatch(AstNode other, Match match)
	{
		if (other is CommentStatement commentStatement)
		{
			return AstNode.MatchString(comment, commentStatement.comment);
		}
		return false;
	}
}
