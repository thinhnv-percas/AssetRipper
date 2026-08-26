using System.Collections.Generic;

namespace DecompTools.Decompiler.TypeSystem;

public interface IParameterizedMember : IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	IReadOnlyList<IParameter> Parameters { get; }
}
