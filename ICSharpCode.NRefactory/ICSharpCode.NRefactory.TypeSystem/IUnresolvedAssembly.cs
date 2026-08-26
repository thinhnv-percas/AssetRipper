using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface IUnresolvedAssembly : IAssemblyReference
{
	string AssemblyName { get; }

	string FullAssemblyName { get; }

	string Location { get; }

	IEnumerable<IUnresolvedAttribute> AssemblyAttributes { get; }

	IEnumerable<IUnresolvedAttribute> ModuleAttributes { get; }

	IEnumerable<IUnresolvedTypeDefinition> TopLevelTypeDefinitions { get; }
}
