using System;
using System.Collections.Generic;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues;

[Serializable]
public sealed class ConstantArrayCreation : ConstantExpression
{
	private readonly ITypeReference elementType;

	private readonly IList<ConstantExpression> arrayElements;

	public ConstantArrayCreation(ITypeReference type, IList<ConstantExpression> arrayElements)
	{
		if (arrayElements == null)
		{
			throw new ArgumentNullException("arrayElements");
		}
		elementType = type;
		this.arrayElements = arrayElements;
	}

	public override ResolveResult Resolve(CSharpResolver resolver)
	{
		ResolveResult[] array = new ResolveResult[arrayElements.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = arrayElements[i].Resolve(resolver);
		}
		int[] sizeArguments = new int[1] { array.Length };
		if (elementType != null)
		{
			return resolver.ResolveArrayCreation(elementType.Resolve(resolver.CurrentTypeResolveContext), sizeArguments, array);
		}
		return resolver.ResolveArrayCreation(null, sizeArguments, array);
	}
}
