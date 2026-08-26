using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

public interface IAssemblyLoader
{
	Assembly LoadAssembly(string assemblyFullName, string codeBasePath);

	Assembly LoadAssembly(AssemblyName assemblyName);
}
