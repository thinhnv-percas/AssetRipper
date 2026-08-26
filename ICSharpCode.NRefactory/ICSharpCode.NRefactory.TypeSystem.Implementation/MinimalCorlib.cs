using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

public sealed class MinimalCorlib : DefaultUnresolvedAssembly
{
	private static readonly Lazy<MinimalCorlib> instance = new Lazy<MinimalCorlib>(() => new MinimalCorlib());

	public static MinimalCorlib Instance => instance.Value;

	public ICompilation CreateCompilation()
	{
		return new SimpleCompilation(new DefaultSolutionSnapshot(), this);
	}

	private MinimalCorlib()
		: base("corlib")
	{
		DefaultUnresolvedTypeDefinition[] array = new DefaultUnresolvedTypeDefinition[46];
		for (int i = 0; i < array.Length; i++)
		{
			KnownTypeReference knownTypeReference = KnownTypeReference.Get((KnownTypeCode)i);
			if (knownTypeReference != null)
			{
				array[i] = new DefaultUnresolvedTypeDefinition(knownTypeReference.Namespace, knownTypeReference.Name);
				for (int j = 0; j < knownTypeReference.TypeParameterCount; j++)
				{
					array[i].TypeParameters.Add(new DefaultUnresolvedTypeParameter(SymbolKind.TypeDefinition, j));
				}
				AddTypeDefinition(array[i]);
			}
		}
		for (int k = 0; k < array.Length; k++)
		{
			KnownTypeReference knownTypeReference2 = KnownTypeReference.Get((KnownTypeCode)k);
			if (knownTypeReference2 != null && knownTypeReference2.baseType != KnownTypeCode.None)
			{
				array[k].BaseTypes.Add(array[(int)knownTypeReference2.baseType]);
				if (knownTypeReference2.baseType == KnownTypeCode.ValueType && k != 24)
				{
					array[k].Kind = TypeKind.Struct;
				}
			}
		}
		Freeze();
	}
}
