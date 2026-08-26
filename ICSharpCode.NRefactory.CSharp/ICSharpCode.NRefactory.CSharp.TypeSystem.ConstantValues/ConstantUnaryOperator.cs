using System;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues;

[Serializable]
public sealed class ConstantUnaryOperator : ConstantExpression
{
	private readonly UnaryOperatorType operatorType;

	private readonly ConstantExpression expression;

	public ConstantUnaryOperator(UnaryOperatorType operatorType, ConstantExpression expression)
	{
		if (expression == null)
		{
			throw new ArgumentNullException("expression");
		}
		this.operatorType = operatorType;
		this.expression = expression;
	}

	public override ResolveResult Resolve(CSharpResolver resolver)
	{
		return resolver.ResolveUnaryOperator(operatorType, expression.Resolve(resolver));
	}
}
