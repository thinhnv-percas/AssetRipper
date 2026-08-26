using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public class Resolver
{
	public static readonly Resolver DefaultInstance = new Resolver(new StandardAssemblyLoader());

	internal readonly Dictionary<Type, WeakReference<TypeRef>> InstanceCache = new Dictionary<Type, WeakReference<TypeRef>>();

	internal IAssemblyLoader AssemblyLoader { get; }

	public Resolver(IAssemblyLoader assemblyLoader)
	{
		Requires.NotNull(assemblyLoader, "assemblyLoader");
		AssemblyLoader = assemblyLoader;
	}
}
