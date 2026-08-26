using System.Collections.Generic;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class QueryExpression : Expression
{
	private sealed class NullQueryExpression : QueryExpression
	{
		public override bool IsNull => true;

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitNullNode(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitNullNode(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitNullNode(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}
	}

	public static readonly Role<QueryClause> ClauseRole = new Role<QueryClause>("Clause");

	public new static readonly QueryExpression Null = new NullQueryExpression();

	public AstNodeCollection<QueryClause> Clauses => GetChildrenByRole(ClauseRole);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitQueryExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitQueryExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitQueryExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is QueryExpression { IsNull: false } queryExpression)
		{
			return Clauses.DoMatch(queryExpression.Clauses, match);
		}
		return false;
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
