using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class UsingStatement : Statement
{
	public static readonly Role<AstNode> ResourceRole = new Role<AstNode>("Resource", AstNode.Null);

	public AstNodeCollection<AstNode> Resources => GetChildrenByRole(ResourceRole);

	public BlockStatement Body
	{
		get
		{
			return GetChildByRole(Roles.Body);
		}
		set
		{
			SetChildByRole(Roles.Body, value);
		}
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitUsingStatement(this, data);
	}
}
