using System;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues;

[Serializable]
public sealed class ConstantCast : ConstantExpression, ISupportsInterning
{
	private readonly ITypeReference targetType;

	private readonly ConstantExpression expression;

	private readonly bool allowNullableConstants;

	public ConstantCast(ITypeReference targetType, ConstantExpression expression, bool allowNullableConstants)
	{
		if (targetType == null)
		{
			throw new ArgumentNullException("targetType");
		}
		if (expression == null)
		{
			throw new ArgumentNullException("expression");
		}
		this.targetType = targetType;
		this.expression = expression;
		this.allowNullableConstants = allowNullableConstants;
	}

	public override ResolveResult Resolve(CSharpResolver resolver)
	{
		IType type = targetType.Resolve(resolver.CurrentTypeResolveContext);
		ResolveResult resolveResult = expression.Resolve(resolver);
		if (allowNullableConstants && NullableType.IsNullable(type))
		{
			resolveResult = resolver.ResolveCast(NullableType.GetUnderlyingType(type), resolveResult);
			if (resolveResult.IsCompileTimeConstant)
			{
				return new ConstantResolveResult(type, resolveResult.ConstantValue);
			}
		}
		return resolver.ResolveCast(type, resolveResult);
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		return targetType.GetHashCode() + expression.GetHashCode() * 1018829;
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		if (other is ConstantCast constantCast && targetType == constantCast.targetType && expression == constantCast.expression)
		{
			return allowNullableConstants == constantCast.allowNullableConstants;
		}
		return false;
	}
}
