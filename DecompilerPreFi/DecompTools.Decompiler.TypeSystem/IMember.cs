using System.Collections.Generic;

namespace DecompTools.Decompiler.TypeSystem;

public interface IMember : IEntity, ISymbol, ICompilationProvider, INamedElement
{
	IMember MemberDefinition { get; }

	IType ReturnType { get; }

	IEnumerable<IMember> ExplicitlyImplementedInterfaceMembers { get; }

	bool IsExplicitInterfaceImplementation { get; }

	bool IsVirtual { get; }

	bool IsOverride { get; }

	bool IsOverridable { get; }

	TypeParameterSubstitution Substitution { get; }

	IMember Specialize(TypeParameterSubstitution substitution);

	bool Equals(IMember obj, TypeVisitor typeNormalization);
}
