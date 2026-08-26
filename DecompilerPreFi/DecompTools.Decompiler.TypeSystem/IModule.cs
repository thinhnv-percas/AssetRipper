using System.Collections.Generic;
using DecompTools.Decompiler.Metadata;

namespace DecompTools.Decompiler.TypeSystem;

public interface IModule : ISymbol, ICompilationProvider
{
	PEFile PEFile { get; }

	bool IsMainModule { get; }

	string AssemblyName { get; }

	string FullAssemblyName { get; }

	INamespace RootNamespace { get; }

	IEnumerable<ITypeDefinition> TopLevelTypeDefinitions { get; }

	IEnumerable<ITypeDefinition> TypeDefinitions { get; }

	IEnumerable<IAttribute> GetAssemblyAttributes();

	IEnumerable<IAttribute> GetModuleAttributes();

	bool InternalsVisibleTo(IModule module);

	ITypeDefinition GetTypeDefinition(TopLevelTypeName topLevelTypeName);
}
