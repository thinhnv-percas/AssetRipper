using System;
using System.Collections.Generic;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public sealed class NullabilityAnnotatedTypeParameter : NullabilityAnnotatedType, ITypeParameter, IType, INamedElement, IEquatable<IType>, ISymbol
{
	private new readonly ITypeParameter baseType;

	SymbolKind ITypeParameter.OwnerType => baseType.OwnerType;

	IEntity ITypeParameter.Owner => baseType.Owner;

	int ITypeParameter.Index => baseType.Index;

	string ITypeParameter.Name => baseType.Name;

	string ISymbol.Name => baseType.Name;

	VarianceModifier ITypeParameter.Variance => baseType.Variance;

	IType ITypeParameter.EffectiveBaseClass => baseType.EffectiveBaseClass;

	IReadOnlyCollection<IType> ITypeParameter.EffectiveInterfaceSet => baseType.EffectiveInterfaceSet;

	bool ITypeParameter.HasDefaultConstructorConstraint => baseType.HasDefaultConstructorConstraint;

	bool ITypeParameter.HasReferenceTypeConstraint => baseType.HasReferenceTypeConstraint;

	bool ITypeParameter.HasValueTypeConstraint => baseType.HasValueTypeConstraint;

	bool ITypeParameter.HasUnmanagedConstraint => baseType.HasUnmanagedConstraint;

	Nullability ITypeParameter.NullabilityConstraint => baseType.NullabilityConstraint;

	SymbolKind ISymbol.SymbolKind => SymbolKind.TypeParameter;

	internal NullabilityAnnotatedTypeParameter(ITypeParameter type, Nullability nullability)
		: base(type, nullability)
	{
		baseType = type;
	}

	IEnumerable<IAttribute> ITypeParameter.GetAttributes()
	{
		return baseType.GetAttributes();
	}
}
