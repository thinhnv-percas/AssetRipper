using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface IMember : IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
{
	IMember MemberDefinition { get; }

	IUnresolvedMember UnresolvedMember { get; }

	IType ReturnType { get; }

	IList<IMember> ImplementedInterfaceMembers { get; }

	bool IsExplicitInterfaceImplementation { get; }

	bool IsVirtual { get; }

	bool IsOverride { get; }

	bool IsOverridable { get; }

	TypeParameterSubstitution Substitution { get; }

	[Obsolete("Use the ToReference method instead.")]
	IMemberReference ToMemberReference();

	new IMemberReference ToReference();

	IMember Specialize(TypeParameterSubstitution substitution);
}
