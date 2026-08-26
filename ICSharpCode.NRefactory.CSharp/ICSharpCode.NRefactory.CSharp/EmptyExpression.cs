using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

[Obsolete("This class is obsolete. Remove all referencing code.")]
public class EmptyExpression : AstNode
{
	public override NodeType NodeType
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		throw new NotImplementedException();
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		throw new NotImplementedException();
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}
}
