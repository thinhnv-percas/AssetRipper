using System;

namespace Mon3.Cecil;

public interface IAssemblyResolver : IDisposable
{
	AssemblyDefinition Resolve(AssemblyNameReference name);

	AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters);
}
