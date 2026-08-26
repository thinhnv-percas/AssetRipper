using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface ITypeParameter : IType, INamedElement, IEquatable<IType>, ISymbol
{
	SymbolKind OwnerType { get; }

	IEntity Owner { get; }

	int Index { get; }

	new string Name { get; }

	IList<IAttribute> Attributes { get; }

	VarianceModifier Variance { get; }

	DomRegion Region { get; }

	IType EffectiveBaseClass { get; }

	ICollection<IType> EffectiveInterfaceSet { get; }

	bool HasDefaultConstructorConstraint { get; }

	bool HasReferenceTypeConstraint { get; }

	bool HasValueTypeConstraint { get; }
}
