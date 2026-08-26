using System;
using System.Collections.Generic;

namespace DecompTools.Decompiler.TypeSystem;

public interface ITypeDefinition : IType, INamedElement, IEquatable<IType>, IEntity, ISymbol, ICompilationProvider
{
	IReadOnlyList<ITypeDefinition> NestedTypes { get; }

	IReadOnlyList<IMember> Members { get; }

	IEnumerable<IField> Fields { get; }

	IEnumerable<IMethod> Methods { get; }

	IEnumerable<IProperty> Properties { get; }

	IEnumerable<IEvent> Events { get; }

	KnownTypeCode KnownTypeCode { get; }

	IType EnumUnderlyingType { get; }

	bool IsReadOnly { get; }

	FullTypeName FullTypeName { get; }

	new IType DeclaringType { get; }

	bool HasExtensionMethods { get; }
}
