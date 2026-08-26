using System.Collections.Generic;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public abstract class Expression : AstNode
{
	private sealed class NullExpression : Expression
	{
		public override bool IsNull => true;

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return default(S);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}
	}

	public new static readonly Expression Null = new NullExpression();

	public MemberAccessExpression Member(object annotation, string memberName)
	{
		return new MemberAccessExpression
		{
			Target = this,
			MemberName = Identifier.Create(annotation, memberName)
		};
	}

	public InvocationExpression Invoke2(object annotations, string methodName, IEnumerable<Expression> arguments)
	{
		return Invoke(annotations, methodName, null, arguments);
	}

	public InvocationExpression Invoke2(object annotations, string methodName, params Expression[] arguments)
	{
		return Invoke(annotations, methodName, null, arguments);
	}

	public InvocationExpression Invoke(object annotation, string methodName, IEnumerable<AstType> typeArguments, IEnumerable<Expression> arguments)
	{
		InvocationExpression invocationExpression = new InvocationExpression();
		MemberAccessExpression memberAccessExpression = new MemberAccessExpression();
		memberAccessExpression.Target = this;
		memberAccessExpression.MemberName = Identifier.Create(BoxedTextColor.InstanceMethod, methodName);
		memberAccessExpression.TypeArguments.AddRange(typeArguments);
		invocationExpression.Target = memberAccessExpression;
		invocationExpression.Arguments.AddRange(arguments);
		return invocationExpression;
	}

	public InvocationExpression Invoke(IEnumerable<Expression> arguments)
	{
		InvocationExpression invocationExpression = new InvocationExpression();
		invocationExpression.Target = this;
		invocationExpression.Arguments.AddRange(arguments);
		return invocationExpression;
	}

	public InvocationExpression Invoke(params Expression[] arguments)
	{
		InvocationExpression invocationExpression = new InvocationExpression();
		invocationExpression.Target = this;
		invocationExpression.Arguments.AddRange(arguments);
		return invocationExpression;
	}

	public CastExpression CastTo(AstType type)
	{
		return new CastExpression
		{
			CastType = CastType.CType,
			Type = type,
			Expression = this
		};
	}
}
