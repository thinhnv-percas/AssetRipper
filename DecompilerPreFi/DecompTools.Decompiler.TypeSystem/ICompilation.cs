using System;
using System.Collections.Generic;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem;

public interface ICompilation
{
	IModule MainModule { get; }

	IReadOnlyList<IModule> Modules { get; }

	IReadOnlyList<IModule> ReferencedModules { get; }

	INamespace RootNamespace { get; }

	StringComparer NameComparer { get; }

	CacheManager CacheManager { get; }

	INamespace GetNamespaceForExternAlias(string alias);

	IType FindType(KnownTypeCode typeCode);
}
