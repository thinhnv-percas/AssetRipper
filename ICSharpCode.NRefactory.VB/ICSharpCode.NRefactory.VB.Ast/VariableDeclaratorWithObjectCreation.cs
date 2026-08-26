using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class VariableDeclaratorWithObjectCreation : VariableDeclarator
{
	public static readonly Role<ObjectCreationExpression> InitializerRole = new Role<ObjectCreationExpression>("InitializerRole");

	public ObjectCreationExpression Initializer
	{
		get
		{
			return GetChildByRole(InitializerRole);
		}
		set
		{
			SetChildByRole(InitializerRole, value);
		}
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitVariableDeclaratorWithObjectCreation(this, data);
	}
}
