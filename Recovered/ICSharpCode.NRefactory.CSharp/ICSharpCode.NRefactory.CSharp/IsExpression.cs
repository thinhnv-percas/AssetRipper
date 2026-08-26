using ICSharpCode.NRefactory.PatternMatching;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp
{
	public class IsExpression : Expression
	{
		public static readonly TokenRole IsKeywordRole = new TokenRole("is");

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

		public CSharpTokenNode IsToken => GetChildByRole(IsKeywordRole);

		public AstType Type
		{
			get
			{
				return GetChildByRole(Roles.Type);
			}
			set
			{
				SetChildByRole(Roles.Type, value);
			}
		}

		public IsExpression()
		{
		}

		public IsExpression(Expression expression, AstType type)
		{
			AddChild(expression, Roles.Expression);
			AddChild(type, Roles.Type);
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitIsExpression(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitIsExpression(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitIsExpression(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			IsExpression isExpression = other as IsExpression;
			if (isExpression != null && Expression.DoMatch(isExpression.Expression, match))
			{
				return Type.DoMatch(isExpression.Type, match);
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
