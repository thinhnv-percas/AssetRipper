using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal class StandardAssemblyLoader : IAssemblyLoader
{
	private readonly Dictionary<AssemblyName, Assembly> loadedAssemblies = new Dictionary<AssemblyName, Assembly>(ByValueEquality.AssemblyName);

	public Assembly LoadAssembly(AssemblyName assemblyName)
	{
		Assembly value;
		lock (loadedAssemblies)
		{
			loadedAssemblies.TryGetValue(assemblyName, out value);
		}
		if (value == null)
		{
			value = Assembly.Load(assemblyName);
			lock (loadedAssemblies)
			{
				loadedAssemblies[assemblyName] = value;
			}
		}
		return value;
	}

	public Assembly LoadAssembly(string assemblyFullName, string codeBasePath)
	{
		Requires.NotNullOrEmpty(assemblyFullName, "assemblyFullName");
		AssemblyName assemblyName = new AssemblyName(assemblyFullName);
		if (!string.IsNullOrEmpty(codeBasePath))
		{
			assemblyName.CodeBase = codeBasePath;
		}
		return LoadAssembly(assemblyName);
	}
}
