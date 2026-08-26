using System;
using System.Globalization;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

[Serializable]
public sealed class TypeParameterReference : ITypeReference, ISymbolReference
{
	private static readonly TypeParameterReference[] classTypeParameterReferences = new TypeParameterReference[8];

	private static readonly TypeParameterReference[] methodTypeParameterReferences = new TypeParameterReference[8];

	private readonly SymbolKind ownerType;

	private readonly int index;

	public int Index => index;

	public static TypeParameterReference Create(SymbolKind ownerType, int index)
	{
		if (index >= 0 && index < 8 && (ownerType == SymbolKind.TypeDefinition || ownerType == SymbolKind.Method))
		{
			TypeParameterReference[] array = ((ownerType == SymbolKind.TypeDefinition) ? classTypeParameterReferences : methodTypeParameterReferences);
			TypeParameterReference typeParameterReference = LazyInit.VolatileRead(ref array[index]);
			if (typeParameterReference == null)
			{
				typeParameterReference = LazyInit.GetOrSet(ref array[index], new TypeParameterReference(ownerType, index));
			}
			return typeParameterReference;
		}
		return new TypeParameterReference(ownerType, index);
	}

	public TypeParameterReference(SymbolKind ownerType, int index)
	{
		this.ownerType = ownerType;
		this.index = index;
	}

	public IType Resolve(ITypeResolveContext context)
	{
		if (ownerType == SymbolKind.Method)
		{
			if (context.CurrentMember is IMethod method && index < method.TypeParameters.Count)
			{
				return method.TypeParameters[index];
			}
			return DummyTypeParameter.GetMethodTypeParameter(index);
		}
		if (ownerType == SymbolKind.TypeDefinition)
		{
			ITypeDefinition currentTypeDefinition = context.CurrentTypeDefinition;
			if (currentTypeDefinition != null && index < currentTypeDefinition.TypeParameters.Count)
			{
				return currentTypeDefinition.TypeParameters[index];
			}
			return DummyTypeParameter.GetClassTypeParameter(index);
		}
		return SpecialType.UnknownType;
	}

	ISymbol ISymbolReference.Resolve(ITypeResolveContext context)
	{
		return Resolve(context) as ISymbol;
	}

	public override string ToString()
	{
		if (ownerType == SymbolKind.Method)
		{
			return "!!" + index.ToString(CultureInfo.InvariantCulture);
		}
		return "!" + index.ToString(CultureInfo.InvariantCulture);
	}
}
