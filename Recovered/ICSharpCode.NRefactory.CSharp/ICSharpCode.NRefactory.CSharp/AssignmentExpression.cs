using ICSharpCode.NRefactory.PatternMatching;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ICSharpCode.NRefactory.CSharp
{
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

		public AssignmentOperatorType Operator
		{
			get;
			set;
		}

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
			AssignmentExpression assignmentExpression = other as AssignmentExpression;
			if (assignmentExpression != null && (Operator == AssignmentOperatorType.Any || Operator == assignmentExpression.Operator) && Left.DoMatch(assignmentExpression.Left, match))
			{
				return Right.DoMatch(assignmentExpression.Right, match);
			}
			return false;
		}

		public static TokenRole GetOperatorRole(AssignmentOperatorType op)
		{
			switch (op)
			{
			case AssignmentOperatorType.Assign:
				return AssignRole;
			case AssignmentOperatorType.Add:
				return AddRole;
			case AssignmentOperatorType.Subtract:
				return SubtractRole;
			case AssignmentOperatorType.Multiply:
				return MultiplyRole;
			case AssignmentOperatorType.Divide:
				return DivideRole;
			case AssignmentOperatorType.Modulus:
				return ModulusRole;
			case AssignmentOperatorType.ShiftLeft:
				return ShiftLeftRole;
			case AssignmentOperatorType.ShiftRight:
				return ShiftRightRole;
			case AssignmentOperatorType.BitwiseAnd:
				return BitwiseAndRole;
			case AssignmentOperatorType.BitwiseOr:
				return BitwiseOrRole;
			case AssignmentOperatorType.ExclusiveOr:
				return ExclusiveOrRole;
			default:
				throw new NotSupportedException("Invalid value for AssignmentOperatorType");
			}
		}

		public static BinaryOperatorType? GetCorrespondingBinaryOperator(AssignmentOperatorType op)
		{
			switch (op)
			{
			case AssignmentOperatorType.Assign:
				return null;
			case AssignmentOperatorType.Add:
				return BinaryOperatorType.Add;
			case AssignmentOperatorType.Subtract:
				return BinaryOperatorType.Subtract;
			case AssignmentOperatorType.Multiply:
				return BinaryOperatorType.Multiply;
			case AssignmentOperatorType.Divide:
				return BinaryOperatorType.Divide;
			case AssignmentOperatorType.Modulus:
				return BinaryOperatorType.Modulus;
			case AssignmentOperatorType.ShiftLeft:
				return BinaryOperatorType.ShiftLeft;
			case AssignmentOperatorType.ShiftRight:
				return BinaryOperatorType.ShiftRight;
			case AssignmentOperatorType.BitwiseAnd:
				return BinaryOperatorType.BitwiseAnd;
			case AssignmentOperatorType.BitwiseOr:
				return BinaryOperatorType.BitwiseOr;
			case AssignmentOperatorType.ExclusiveOr:
				return BinaryOperatorType.ExclusiveOr;
			default:
				throw new NotSupportedException("Invalid value for AssignmentOperatorType");
			}
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

		public override MemberReferenceExpression Member(string memberName)
		{
			return new MemberReferenceExpression
			{
				Target = this,
				MemberName = memberName
			};
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

		public override InvocationExpression Invoke(string methodName, IEnumerable<AstType> typeArguments, IEnumerable<Expression> arguments)
		{
			InvocationExpression invocationExpression = new InvocationExpression();
			MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression();
			memberReferenceExpression.Target = new ParenthesizedExpression(this);
			memberReferenceExpression.MemberName = methodName;
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
}
