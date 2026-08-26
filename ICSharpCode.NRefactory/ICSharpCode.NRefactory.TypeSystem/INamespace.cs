using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface INamespace : ISymbol, ICompilationProvider
{
	string ExternAlias { get; }

	string FullName { get; }

	new string Name { get; }

	INamespace ParentNamespace { get; }

	IEnumerable<INamespace> ChildNamespaces { get; }

	IEnumerable<ITypeDefinition> Types { get; }

	IEnumerable<IAssembly> ContributingAssemblies { get; }

	INamespace GetChildNamespace(string name);

	ITypeDefinition GetTypeDefinition(string name, int typeParameterCount);
}
