using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class LocalDeclarationStatement : Statement
{
	public AstNodeCollection<VariableDeclarator> Variables => GetChildrenByRole(VariableDeclarator.VariableDeclaratorRole);

	public Modifiers Modifiers
	{
		get
		{
			return AttributedNode.GetModifiers(this);
		}
		set
		{
			AttributedNode.SetModifiers(this, value);
		}
	}

	public VBModifierToken ModifierToken => GetChildByRole(AttributedNode.ModifierRole);

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitLocalDeclarationStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}
}
