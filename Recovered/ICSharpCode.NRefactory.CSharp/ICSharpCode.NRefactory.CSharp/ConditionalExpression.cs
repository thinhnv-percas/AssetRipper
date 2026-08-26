using ICSharpCode.NRefactory.PatternMatching;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp
{
	public class ConditionalExpression : Expression
	{
		public static readonly Role<Expression> ConditionRole = Roles.Condition;

		public static readonly TokenRole QuestionMarkRole = new TokenRole("?");

		public static readonly Role<Expression> TrueRole = new Role<Expression>("True", Expression.Null);

		public static readonly TokenRole ColonRole = Roles.Colon;

		public static readonly Role<Expression> FalseRole = new Role<Expression>("False", Expression.Null);

		public Expression Condition
		{
			get
			{
				return GetChildByRole(ConditionRole);
			}
			set
			{
				SetChildByRole(ConditionRole, value);
			}
		}

		public CSharpTokenNode QuestionMarkToken => GetChildByRole(QuestionMarkRole);

		public Expression TrueExpression
		{
			get
			{
				return GetChildByRole(TrueRole);
			}
			set
			{
				SetChildByRole(TrueRole, value);
			}
		}

		public CSharpTokenNode ColonToken => GetChildByRole(ColonRole);

		public Expression FalseExpression
		{
			get
			{
				return GetChildByRole(FalseRole);
			}
			set
			{
				SetChildByRole(FalseRole, value);
			}
		}

		public ConditionalExpression()
		{
		}

		public ConditionalExpression(Expression condition, Expression trueExpression, Expression falseExpression)
		{
			AddChild(condition, ConditionRole);
			AddChild(trueExpression, TrueRole);
			AddChild(falseExpression, FalseRole);
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitConditionalExpression(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitConditionalExpression(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitConditionalExpression(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			ConditionalExpression conditionalExpression = other as ConditionalExpression;
			if (conditionalExpression != null && Condition.DoMatch(conditionalExpression.Condition, match) && TrueExpression.DoMatch(conditionalExpression.TrueExpression, match))
			{
				return FalseExpression.DoMatch(conditionalExpression.FalseExpression, match);
			}
			return false;
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
