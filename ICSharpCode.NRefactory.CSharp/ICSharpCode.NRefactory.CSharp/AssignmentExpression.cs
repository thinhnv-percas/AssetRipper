using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class AssignmentExpression : Expression
{
	public static readonly Role<Expression> LeftRole = BinaryOperatorExpression.LeftRole;

	public static readonly Role<Expression> RightRole = BinaryOperatorExpression.RightRole;

	public static readonly TokenRole AssignRole = new TokenRole("=");

	public static readonly TokenRole AddRole = new TokenRole("+=");

	public static readonly TokenRole SubtractRole = new TokenRole("-=");

	public static readonly TokenRole MultiplyRole = new TokenRole("*=");

	public static readonly TokenRole DivideRole = new TokenRole("/=");

	public static readonly TokenRole ModulusRole = new TokenRole("%=");

	public static readonly TokenRole ShiftLeftRole = new TokenRole("<<=");

	public static readonly TokenRole ShiftRightRole = new TokenRole(">>=");

	public static readonly TokenRole BitwiseAndRole = new TokenRole("&=");

	public static readonly TokenRole BitwiseOrRole = new TokenRole("|=");

	public static readonly TokenRole ExclusiveOrRole = new TokenRole("^=");

	public AssignmentOperatorType Operator { get; set; }

	public Expression Left
	{
		get
		{
			return GetChildByRole(LeftRole);
		}
		set
		{
			SetChildByRole(LeftRole, value);
		}
	}

	public CSharpTokenNode OperatorToken => GetChildByRole(GetOperatorRole(Operator));

	public Expression Right
	{
		get
		{
			return GetChildByRole(RightRole);
		}
		set
		{
			SetChildByRole(RightRole, value);
		}
	}

	public AssignmentExpression()
	{
	}

	public AssignmentExpression(Expression left, Expression right)
	{
		Left = left;
		Right = right;
	}

	public AssignmentExpression(Expression left, AssignmentOperatorType op, Expression right)
	{
		Left = left;
		Operator = op;
		Right = right;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitAssignmentExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitAssignmentExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitAssignmentExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is AssignmentExpression assignmentExpression && (Operator == AssignmentOperatorType.Any || Operator == assignmentExpression.Operator) && Left.DoMatch(assignmentExpression.Left, match))
		{
			return Right.DoMatch(assignmentExpression.Right, match);
		}
		return false;
	}

	public static TokenRole GetOperatorRole(AssignmentOperatorType op)
	{
		return op switch
		{
			AssignmentOperatorType.Assign => AssignRole, 
			AssignmentOperatorType.Add => AddRole, 
			AssignmentOperatorType.Subtract => SubtractRole, 
			AssignmentOperatorType.Multiply => MultiplyRole, 
			AssignmentOperatorType.Divide => DivideRole, 
			AssignmentOperatorType.Modulus => ModulusRole, 
			AssignmentOperatorType.ShiftLeft => ShiftLeftRole, 
			AssignmentOperatorType.ShiftRight => ShiftRightRole, 
			AssignmentOperatorType.BitwiseAnd => BitwiseAndRole, 
			AssignmentOperatorType.BitwiseOr => BitwiseOrRole, 
			AssignmentOperatorType.ExclusiveOr => ExclusiveOrRole, 
			_ => throw new NotSupportedException("Invalid value for AssignmentOperatorType"), 
		};
	}

	public static BinaryOperatorType? GetCorrespondingBinaryOperator(AssignmentOperatorType op)
	{
		return op switch
		{
			AssignmentOperatorType.Assign => null, 
			AssignmentOperatorType.Add => BinaryOperatorType.Add, 
			AssignmentOperatorType.Subtract => BinaryOperatorType.Subtract, 
			AssignmentOperatorType.Multiply => BinaryOperatorType.Multiply, 
			AssignmentOperatorType.Divide => BinaryOperatorType.Divide, 
			AssignmentOperatorType.Modulus => BinaryOperatorType.Modulus, 
			AssignmentOperatorType.ShiftLeft => BinaryOperatorType.ShiftLeft, 
			AssignmentOperatorType.ShiftRight => BinaryOperatorType.ShiftRight, 
			AssignmentOperatorType.BitwiseAnd => BinaryOperatorType.BitwiseAnd, 
			AssignmentOperatorType.BitwiseOr => BinaryOperatorType.BitwiseOr, 
			AssignmentOperatorType.ExclusiveOr => BinaryOperatorType.ExclusiveOr, 
			_ => throw new NotSupportedException("Invalid value for AssignmentOperatorType"), 
		};
	}

	public static ExpressionType GetLinqNodeType(AssignmentOperatorType op, bool checkForOverflow)
	{
		switch (op)
		{
		case AssignmentOperatorType.Assign:
			return ExpressionType.Assign;
		case AssignmentOperatorType.Add:
			if (!checkForOverflow)
			{
				return ExpressionType.AddAssign;
			}
			return ExpressionType.AddAssignChecked;
		case AssignmentOperatorType.Subtract:
			if (!checkForOverflow)
			{
				return ExpressionType.SubtractAssign;
			}
			return ExpressionType.SubtractAssignChecked;
		case AssignmentOperatorType.Multiply:
			if (!checkForOverflow)
			{
				return ExpressionType.MultiplyAssign;
			}
			return ExpressionType.MultiplyAssignChecked;
		case AssignmentOperatorType.Divide:
			return ExpressionType.DivideAssign;
		case AssignmentOperatorType.Modulus:
			return ExpressionType.ModuloAssign;
		case AssignmentOperatorType.ShiftLeft:
			return ExpressionType.LeftShiftAssign;
		case AssignmentOperatorType.ShiftRight:
			return ExpressionType.RightShiftAssign;
		case AssignmentOperatorType.BitwiseAnd:
			return ExpressionType.AndAssign;
		case AssignmentOperatorType.BitwiseOr:
			return ExpressionType.OrAssign;
		case AssignmentOperatorType.ExclusiveOr:
			return ExpressionType.ExclusiveOrAssign;
		default:
			throw new NotSupportedException("Invalid value for AssignmentOperatorType");
		}
	}

	public override MemberReferenceExpression Member(string memberName, object memberAnnotation)
	{
		return new MemberReferenceExpression
		{
			Target = this,
			MemberName = memberName
		}.WithAnnotation(memberAnnotation);
	}

	public override IndexerExpression Indexer(IEnumerable<Expression> arguments)
	{
		IndexerExpression indexerExpression = new IndexerExpression();
		indexerExpression.Target = new ParenthesizedExpression(this);
		indexerExpression.Arguments.AddRange(arguments);
		return indexerExpression;
	}

	public override IndexerExpression Indexer(params Expression[] arguments)
	{
		IndexerExpression indexerExpression = new IndexerExpression();
		indexerExpression.Target = new ParenthesizedExpression(this);
		indexerExpression.Arguments.AddRange(arguments);
		return indexerExpression;
	}

	public override InvocationExpression Invoke(object annotation, string methodName, IEnumerable<AstType> typeArguments, IEnumerable<Expression> arguments)
	{
		InvocationExpression invocationExpression = new InvocationExpression();
		MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression();
		memberReferenceExpression.Target = new ParenthesizedExpression(this);
		memberReferenceExpression.MemberName = methodName;
		memberReferenceExpression.MemberNameToken.AddAnnotation(annotation ?? BoxedTextColor.InstanceMethod);
		memberReferenceExpression.TypeArguments.AddRange(typeArguments);
		invocationExpression.Target = memberReferenceExpression;
		invocationExpression.Arguments.AddRange(arguments);
		return invocationExpression;
	}

	public override InvocationExpression Invoke(IEnumerable<Expression> arguments)
	{
		InvocationExpression invocationExpression = new InvocationExpression();
		invocationExpression.Target = new ParenthesizedExpression(this);
		invocationExpression.Arguments.AddRange(arguments);
		return invocationExpression;
	}

	public override InvocationExpression Invoke(params Expression[] arguments)
	{
		InvocationExpression invocationExpression = new InvocationExpression();
		invocationExpression.Target = new ParenthesizedExpression(this);
		invocationExpression.Arguments.AddRange(arguments);
		return invocationExpression;
	}

	public override CastExpression CastTo(AstType type)
	{
		return new CastExpression
		{
			Type = type,
			Expression = new ParenthesizedExpression(this)
		};
	}

	public override AsExpression CastAs(AstType type)
	{
		return new AsExpression
		{
			Type = type,
			Expression = new ParenthesizedExpression(this)
		};
	}

	public override IsExpression IsType(AstType type)
	{
		return new IsExpression
		{
			Type = type,
			Expression = new ParenthesizedExpression(this)
		};
	}
}
