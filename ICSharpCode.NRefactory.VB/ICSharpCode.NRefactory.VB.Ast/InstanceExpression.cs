using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class InstanceExpression : Expression
{
	private TextLocation location;

	public override TextLocation StartLocation => location;

	public override TextLocation EndLocation => Type switch
	{
		InstanceExpressionType.Me => new TextLocation(location.Line, location.Column + "Me".Length), 
		InstanceExpressionType.MyBase => new TextLocation(location.Line, location.Column + "MyBase".Length), 
		InstanceExpressionType.MyClass => new TextLocation(location.Line, location.Column + "MyClass".Length), 
		_ => throw new Exception("Invalid value for InstanceExpressionType"), 
	};

	public InstanceExpressionType Type { get; set; }

	public InstanceExpression(InstanceExpressionType type, TextLocation location)
	{
		Type = type;
		this.location = location;
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is InstanceExpression instanceExpression)
		{
			return Type == instanceExpression.Type;
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitInstanceExpression(this, data);
	}
}
