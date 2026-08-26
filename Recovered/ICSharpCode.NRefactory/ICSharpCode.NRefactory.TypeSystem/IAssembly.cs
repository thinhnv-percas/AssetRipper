using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IAssembly : ICompilationProvider
	{
		IUnresolvedAssembly UnresolvedAssembly
		{
			get;
		}

		bool IsMainAssembly
		{
			get;
		}

		string AssemblyName
		{
			get;
		}

		string FullAssemblyName
		{
			get;
		}

		IList<IAttribute> AssemblyAttributes
		{
			get;
		}

		IList<IAttribute> ModuleAttributes
		{
			get;
		}

		INamespace RootNamespace
		{
			get;
		}

		IEnumerable<ITypeDefinition> TopLevelTypeDefinitions
		{
			get;
		}

		bool InternalsVisibleTo(IAssembly assembly);

		ITypeDefinition GetTypeDefinition(TopLevelTypeName topLevelTypeName);
	}
}
