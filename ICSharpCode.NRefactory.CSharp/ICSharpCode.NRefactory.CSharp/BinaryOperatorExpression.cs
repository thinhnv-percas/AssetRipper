using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class BinaryOperatorExpression : Expression
{
	public static readonly TokenRole BitwiseAndRole = new TokenRole("&");

	public static readonly TokenRole BitwiseOrRole = new TokenRole("|");

	public static readonly TokenRole ConditionalAndRole = new TokenRole("&&");

	public static readonly TokenRole ConditionalOrRole = new TokenRole("||");

	public static readonly TokenRole ExclusiveOrRole = new TokenRole("^");

	public static readonly TokenRole GreaterThanRole = new TokenRole(">");

	public static readonly TokenRole GreaterThanOrEqualRole = new TokenRole(">=");

	public static readonly TokenRole EqualityRole = new TokenRole("==");

	public static readonly TokenRole InEqualityRole = new TokenRole("!=");

	public static readonly TokenRole LessThanRole = new TokenRole("<");

	public static readonly TokenRole LessThanOrEqualRole = new TokenRole("<=");

	public static readonly TokenRole AddRole = new TokenRole("+");

	public static readonly TokenRole SubtractRole = new TokenRole("-");

	public static readonly TokenRole MultiplyRole = new TokenRole("*");

	public static readonly TokenRole DivideRole = new TokenRole("/");

	public static readonly TokenRole ModulusRole = new TokenRole("%");

	public static readonly TokenRole ShiftLeftRole = new TokenRole("<<");

	public static readonly TokenRole ShiftRightRole = new TokenRole(">>");

	public static readonly TokenRole NullCoalescingRole = new TokenRole("??");

	public static readonly Role<Expression> LeftRole = new Role<Expression>("Left", Expression.Null);

	public static readonly Role<Expression> RightRole = new Role<Expression>("Right", Expression.Null);

	public BinaryOperatorType Operator { get; set; }

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

	public BinaryOperatorExpression()
	{
	}

	public BinaryOperatorExpression(Expression left, BinaryOperatorType op, Expression right)
	{
		Left = left;
		Operator = op;
		Right = right;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitBinaryOperatorExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitBinaryOperatorExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitBinaryOperatorExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is BinaryOperatorExpression binaryOperatorExpression && (Operator == BinaryOperatorType.Any || Operator == binaryOperatorExpression.Operator) && Left.DoMatch(binaryOperatorExpression.Left, match))
		{
			return Right.DoMatch(binaryOperatorExpression.Right, match);
		}
		return false;
	}

	public static TokenRole GetOperatorRole(BinaryOperatorType op)
	{
		return op switch
		{
			BinaryOperatorType.BitwiseAnd => BitwiseAndRole, 
			BinaryOperatorType.BitwiseOr => BitwiseOrRole, 
			BinaryOperatorType.ConditionalAnd => ConditionalAndRole, 
			BinaryOperatorType.ConditionalOr => ConditionalOrRole, 
			BinaryOperatorType.ExclusiveOr => ExclusiveOrRole, 
			BinaryOperatorType.GreaterThan => GreaterThanRole, 
			BinaryOperatorType.GreaterThanOrEqual => GreaterThanOrEqualRole, 
			BinaryOperatorType.Equality => EqualityRole, 
			BinaryOperatorType.InEquality => InEqualityRole, 
			BinaryOperatorType.LessThan => LessThanRole, 
			BinaryOperatorType.LessThanOrEqual => LessThanOrEqualRole, 
			BinaryOperatorType.Add => AddRole, 
			BinaryOperatorType.Subtract => SubtractRole, 
			BinaryOperatorType.Multiply => MultiplyRole, 
			BinaryOperatorType.Divide => DivideRole, 
			BinaryOperatorType.Modulus => ModulusRole, 
			BinaryOperatorType.ShiftLeft => ShiftLeftRole, 
			BinaryOperatorType.ShiftRight => ShiftRightRole, 
			BinaryOperatorType.NullCoalescing => NullCoalescingRole, 
			_ => throw new NotSupportedException("Invalid value for BinaryOperatorType"), 
		};
	}

	public static ExpressionType GetLinqNodeType(BinaryOperatorType op, bool checkForOverflow)
	{
		switch (op)
		{
		case BinaryOperatorType.BitwiseAnd:
			return ExpressionType.And;
		case BinaryOperatorType.BitwiseOr:
			return ExpressionType.Or;
		case BinaryOperatorType.ConditionalAnd:
			return ExpressionType.AndAlso;
		case BinaryOperatorType.ConditionalOr:
			return ExpressionType.OrElse;
		case BinaryOperatorType.ExclusiveOr:
			return ExpressionType.ExclusiveOr;
		case BinaryOperatorType.GreaterThan:
			return ExpressionType.GreaterThan;
		case BinaryOperatorType.GreaterThanOrEqual:
			return ExpressionType.GreaterThanOrEqual;
		case BinaryOperatorType.Equality:
			return ExpressionType.Equal;
		case BinaryOperatorType.InEquality:
			return ExpressionType.NotEqual;
		case BinaryOperatorType.LessThan:
			return ExpressionType.LessThan;
		case BinaryOperatorType.LessThanOrEqual:
			return ExpressionType.LessThanOrEqual;
		case BinaryOperatorType.Add:
			if (!checkForOverflow)
			{
				return ExpressionType.Add;
			}
			return ExpressionType.AddChecked;
		case BinaryOperatorType.Subtract:
			if (!checkForOverflow)
			{
				return ExpressionType.Subtract;
			}
			return ExpressionType.SubtractChecked;
		case BinaryOperatorType.Multiply:
			if (!checkForOverflow)
			{
				return ExpressionType.Multiply;
			}
			return ExpressionType.MultiplyChecked;
		case BinaryOperatorType.Divide:
			return ExpressionType.Divide;
		case BinaryOperatorType.Modulus:
			return ExpressionType.Modulo;
		case BinaryOperatorType.ShiftLeft:
			return ExpressionType.LeftShift;
		case BinaryOperatorType.ShiftRight:
			return ExpressionType.RightShift;
		case BinaryOperatorType.NullCoalescing:
			return ExpressionType.Coalesce;
		default:
			throw new NotSupportedException("Invalid value for BinaryOperatorType");
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
