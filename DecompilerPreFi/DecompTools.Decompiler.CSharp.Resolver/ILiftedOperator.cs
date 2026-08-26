using System.Collections.Generic;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Resolver;

public interface ILiftedOperator : IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	IType NonLiftedReturnType { get; }

	IReadOnlyList<IParameter> NonLiftedParameters { get; }
}
