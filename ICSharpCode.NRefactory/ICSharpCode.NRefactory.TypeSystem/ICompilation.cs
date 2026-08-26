using System;
using System.Collections.Generic;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface ICompilation
{
	IAssembly MainAssembly { get; }

	ITypeResolveContext TypeResolveContext { get; }

	IList<IAssembly> Assemblies { get; }

	IList<IAssembly> ReferencedAssemblies { get; }

	INamespace RootNamespace { get; }

	StringComparer NameComparer { get; }

	ISolutionSnapshot SolutionSnapshot { get; }

	CacheManager CacheManager { get; }

	INamespace GetNamespaceForExternAlias(string alias);

	IType FindType(KnownTypeCode typeCode);
}
