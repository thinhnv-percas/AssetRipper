using System;
using System.Collections.Generic;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public abstract class Expression : AstNode
{
	private sealed class NullExpression : Expression
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

	private sealed class PatternPlaceholder : Expression, INode
	{
		private readonly Pattern child;

		public override NodeType NodeType => NodeType.Pattern;

		public PatternPlaceholder(Pattern child)
		{
			this.child = child;
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitPatternPlaceholder(this, child);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitPatternPlaceholder(this, child);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitPatternPlaceholder(this, child, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return child.DoMatch(other, match);
		}

		bool INode.DoMatchCollection(Role role, INode pos, Match match, BacktrackingInfo backtrackingInfo)
		{
			return child.DoMatchCollection(role, pos, match, backtrackingInfo);
		}
	}

	public new static readonly Expression Null = new NullExpression();

	public override NodeType NodeType => NodeType.Expression;

	public static implicit operator Expression(Pattern pattern)
	{
		if (pattern == null)
		{
			return null;
		}
		return new PatternPlaceholder(pattern);
	}

	public new Expression Clone()
	{
		return (Expression)base.Clone();
	}

	public Expression ReplaceWith(Func<Expression, Expression> replaceFunction)
	{
		if (replaceFunction == null)
		{
			throw new ArgumentNullException("replaceFunction");
		}
		return (Expression)ReplaceWith((AstNode node) => replaceFunction((Expression)node));
	}

	public virtual MemberReferenceExpression Member(string memberName, object memberAnnotation)
	{
		Identifier identifier = Identifier.Create(memberName);
		if (memberAnnotation != null)
		{
			identifier.AddAnnotation(memberAnnotation);
		}
		return new MemberReferenceExpression
		{
			Target = this,
			MemberNameToken = identifier
		};
	}

	public virtual IndexerExpression Indexer(IEnumerable<Expression> arguments)
	{
		IndexerExpression indexerExpression = new IndexerExpression();
		indexerExpression.Target = this;
		indexerExpression.Arguments.AddRange(arguments);
		return indexerExpression;
	}

	public virtual IndexerExpression Indexer(params Expression[] arguments)
	{
		IndexerExpression indexerExpression = new IndexerExpression();
		indexerExpression.Target = this;
		indexerExpression.Arguments.AddRange(arguments);
		return indexerExpression;
	}

	public virtual InvocationExpression Invoke(object annotation, string methodName, IEnumerable<Expression> arguments)
	{
		return Invoke(annotation, methodName, null, arguments);
	}

	public virtual InvocationExpression Invoke(string methodName, params Expression[] arguments)
	{
		return Invoke(null, methodName, null, arguments);
	}

	public virtual InvocationExpression Invoke2(object annotations, string methodName, params Expression[] arguments)
	{
		return Invoke(annotations, methodName, null, arguments);
	}

	public virtual InvocationExpression Invoke(object annotation, string methodName, IEnumerable<AstType> typeArguments, IEnumerable<Expression> arguments)
	{
		InvocationExpression invocationExpression = new InvocationExpression();
		MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression();
		memberReferenceExpression.Target = this;
		memberReferenceExpression.MemberName = methodName;
		memberReferenceExpression.MemberNameToken.AddAnnotation(annotation ?? BoxedTextColor.InstanceMethod);
		memberReferenceExpression.TypeArguments.AddRange(typeArguments);
		invocationExpression.Target = memberReferenceExpression;
		invocationExpression.Arguments.AddRange(arguments);
		return invocationExpression;
	}

	public virtual InvocationExpression Invoke(IEnumerable<Expression> arguments)
	{
		InvocationExpression invocationExpression = new InvocationExpression();
		invocationExpression.Target = this;
		invocationExpression.Arguments.AddRange(arguments);
		return invocationExpression;
	}

	public virtual InvocationExpression Invoke(params Expression[] arguments)
	{
		InvocationExpression invocationExpression = new InvocationExpression();
		invocationExpression.Target = this;
		invocationExpression.Arguments.AddRange(arguments);
		return invocationExpression;
	}

	public virtual CastExpression CastTo(AstType type)
	{
		return new CastExpression
		{
			Type = type,
			Expression = this
		};
	}

	public virtual AsExpression CastAs(AstType type)
	{
		return new AsExpression
		{
			Type = type,
			Expression = this
		};
	}

	public virtual IsExpression IsType(AstType type)
	{
		return new IsExpression
		{
			Type = type,
			Expression = this
		};
	}
}
