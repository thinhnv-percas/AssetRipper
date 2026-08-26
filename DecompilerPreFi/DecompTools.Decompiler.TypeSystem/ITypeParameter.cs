using System;
using System.Collections.Generic;

namespace DecompTools.Decompiler.TypeSystem;

public interface ITypeParameter : IType, INamedElement, IEquatable<IType>, ISymbol
{
	SymbolKind OwnerType { get; }

	IEntity Owner { get; }

	int Index { get; }

	new string Name { get; }

	VarianceModifier Variance { get; }

	IType EffectiveBaseClass { get; }

	IReadOnlyCollection<IType> EffectiveInterfaceSet { get; }

	bool HasDefaultConstructorConstraint { get; }

	bool HasReferenceTypeConstraint { get; }

	bool HasValueTypeConstraint { get; }

	bool HasUnmanagedConstraint { get; }

	Nullability NullabilityConstraint { get; }

	IEnumerable<IAttribute> GetAttributes();
}
