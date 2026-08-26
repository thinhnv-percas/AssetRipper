using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface IProjectContent : IUnresolvedAssembly, IAssemblyReference
{
	string ProjectFileName { get; }

	IEnumerable<IUnresolvedFile> Files { get; }

	IEnumerable<IAssemblyReference> AssemblyReferences { get; }

	object CompilerSettings { get; }

	IUnresolvedFile GetFile(string fileName);

	ICompilation CreateCompilation();

	ICompilation CreateCompilation(ISolutionSnapshot solutionSnapshot);

	IProjectContent SetAssemblyName(string newAssemblyName);

	IProjectContent SetProjectFileName(string newProjectFileName);

	IProjectContent SetLocation(string newLocation);

	IProjectContent AddAssemblyReferences(IEnumerable<IAssemblyReference> references);

	IProjectContent AddAssemblyReferences(params IAssemblyReference[] references);

	IProjectContent RemoveAssemblyReferences(IEnumerable<IAssemblyReference> references);

	IProjectContent RemoveAssemblyReferences(params IAssemblyReference[] references);

	IProjectContent AddOrUpdateFiles(IEnumerable<IUnresolvedFile> newFiles);

	IProjectContent AddOrUpdateFiles(params IUnresolvedFile[] newFiles);

	IProjectContent RemoveFiles(IEnumerable<string> fileNames);

	IProjectContent RemoveFiles(params string[] fileNames);

	[Obsolete("Use RemoveFiles()/AddOrUpdateFiles() instead")]
	IProjectContent UpdateProjectContent(IUnresolvedFile oldFile, IUnresolvedFile newFile);

	[Obsolete("Use RemoveFiles()/AddOrUpdateFiles() instead")]
	IProjectContent UpdateProjectContent(IEnumerable<IUnresolvedFile> oldFiles, IEnumerable<IUnresolvedFile> newFiles);

	IProjectContent SetCompilerSettings(object compilerSettings);
}
