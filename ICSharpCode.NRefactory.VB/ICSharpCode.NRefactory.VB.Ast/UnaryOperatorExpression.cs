using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class UnaryOperatorExpression : Expression
{
	public static readonly Role<VBTokenNode> OperatorRole = BinaryOperatorExpression.OperatorRole;

	public UnaryOperatorType Operator { get; set; }

	public VBTokenNode OperatorToken => GetChildByRole(OperatorRole);

	public Expression Expression
	{
		get
		{
			return GetChildByRole(Roles.Expression);
		}
		set
		{
			SetChildByRole(Roles.Expression, value);
		}
	}

	public UnaryOperatorExpression()
	{
	}

	public UnaryOperatorExpression(UnaryOperatorType op, Expression expression)
	{
		Operator = op;
		Expression = expression;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitUnaryOperatorExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is UnaryOperatorExpression unaryOperatorExpression && Operator == unaryOperatorExpression.Operator)
		{
			return Expression.DoMatch(unaryOperatorExpression.Expression, match);
		}
		return false;
	}

	public static string GetOperatorSymbol(UnaryOperatorType op)
	{
		return op switch
		{
			UnaryOperatorType.Not => "Not", 
			UnaryOperatorType.Minus => "-", 
			UnaryOperatorType.Plus => "+", 
			_ => throw new NotSupportedException("Invalid value for UnaryOperatorType"), 
		};
	}
}
