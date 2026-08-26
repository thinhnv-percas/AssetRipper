using System.Collections.Generic;

namespace DecompTools.Decompiler.TypeSystem;

public interface IMethod : IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	IReadOnlyList<ITypeParameter> TypeParameters { get; }

	IReadOnlyList<IType> TypeArguments { get; }

	bool IsExtensionMethod { get; }

	bool IsConstructor { get; }

	bool IsDestructor { get; }

	bool IsOperator { get; }

	bool HasBody { get; }

	bool IsAccessor { get; }

	IMember AccessorOwner { get; }

	IMethod ReducedFrom { get; }

	IEnumerable<IAttribute> GetReturnTypeAttributes();

	new IMethod Specialize(TypeParameterSubstitution substitution);
}
