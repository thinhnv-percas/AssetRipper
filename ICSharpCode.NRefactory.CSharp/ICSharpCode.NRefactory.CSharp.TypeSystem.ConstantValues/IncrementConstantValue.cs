using System;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues;

[Serializable]
public sealed class IncrementConstantValue : IConstantValue, ISupportsInterning
{
	private readonly IConstantValue baseValue;

	private readonly int incrementAmount;

	public IncrementConstantValue(IConstantValue baseValue, int incrementAmount = 1)
	{
		if (baseValue == null)
		{
			throw new ArgumentNullException("baseValue");
		}
		if (baseValue is IncrementConstantValue incrementConstantValue)
		{
			this.baseValue = incrementConstantValue.baseValue;
			this.incrementAmount = incrementConstantValue.incrementAmount + incrementAmount;
		}
		else
		{
			this.baseValue = baseValue;
			this.incrementAmount = incrementAmount;
		}
	}

	public ResolveResult Resolve(ITypeResolveContext context)
	{
		ResolveResult resolveResult = baseValue.Resolve(context);
		if (resolveResult.IsCompileTimeConstant && resolveResult.ConstantValue != null)
		{
			object constantValue = resolveResult.ConstantValue;
			TypeCode typeCode = ((constantValue != null) ? Type.GetTypeCode(constantValue.GetType()) : TypeCode.Empty);
			if (typeCode >= TypeCode.SByte && typeCode <= TypeCode.UInt64)
			{
				long num = (long)CSharpPrimitiveCast.Cast(TypeCode.Int64, constantValue, checkForOverflow: false);
				object constantValue2 = CSharpPrimitiveCast.Cast(typeCode, num + incrementAmount, checkForOverflow: false);
				return new ConstantResolveResult(resolveResult.Type, constantValue2);
			}
		}
		return new ErrorResolveResult(resolveResult.Type);
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		return (baseValue.GetHashCode() * 33) ^ incrementAmount;
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		if (other is IncrementConstantValue incrementConstantValue && baseValue == incrementConstantValue.baseValue)
		{
			return incrementAmount == incrementConstantValue.incrementAmount;
		}
		return false;
	}
}
