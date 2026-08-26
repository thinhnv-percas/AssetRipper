using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	[Serializable]
	public class CSharpProjectContent : IProjectContent, IUnresolvedAssembly, IAssemblyReference
	{
		private string assemblyName;

		private string fullAssemblyName;

		private string projectFileName;

		private string location;

		private Dictionary<string, IUnresolvedFile> unresolvedFiles;

		private List<IAssemblyReference> assemblyReferences;

		private CompilerSettings compilerSettings;

		public IEnumerable<IUnresolvedFile> Files => unresolvedFiles.Values;

		public IEnumerable<IAssemblyReference> AssemblyReferences => assemblyReferences;

		public string ProjectFileName => projectFileName;

		public string AssemblyName => assemblyName;

		public string FullAssemblyName => fullAssemblyName;

		public string Location => location;

		public CompilerSettings CompilerSettings => compilerSettings;

		object IProjectContent.CompilerSettings => compilerSettings;

		public IEnumerable<IUnresolvedAttribute> AssemblyAttributes => Files.SelectMany((IUnresolvedFile f) => f.AssemblyAttributes);

		public IEnumerable<IUnresolvedAttribute> ModuleAttributes => Files.SelectMany((IUnresolvedFile f) => f.ModuleAttributes);

		public IEnumerable<IUnresolvedTypeDefinition> TopLevelTypeDefinitions => Files.SelectMany((IUnresolvedFile f) => f.TopLevelTypeDefinitions);

		public CSharpProjectContent()
		{
			unresolvedFiles = new Dictionary<string, IUnresolvedFile>(Platform.FileNameComparer);
			assemblyReferences = new List<IAssemblyReference>();
			compilerSettings = new CompilerSettings();
			compilerSettings.Freeze();
		}

		protected CSharpProjectContent(CSharpProjectContent pc)
		{
			assemblyName = pc.assemblyName;
			fullAssemblyName = pc.fullAssemblyName;
			projectFileName = pc.projectFileName;
			location = pc.location;
			unresolvedFiles = new Dictionary<string, IUnresolvedFile>(pc.unresolvedFiles, Platform.FileNameComparer);
			assemblyReferences = new List<IAssemblyReference>(pc.assemblyReferences);
			compilerSettings = pc.compilerSettings;
		}

		public IUnresolvedFile GetFile(string fileName)
		{
			if (unresolvedFiles.TryGetValue(fileName, out IUnresolvedFile value))
			{
				return value;
			}
			return null;
		}

		public virtual ICompilation CreateCompilation()
		{
			DefaultSolutionSnapshot defaultSolutionSnapshot = new DefaultSolutionSnapshot();
			ICompilation compilation = new SimpleCompilation(defaultSolutionSnapshot, this, assemblyReferences);
			defaultSolutionSnapshot.AddCompilation(this, compilation);
			return compilation;
		}

		public virtual ICompilation CreateCompilation(ISolutionSnapshot solutionSnapshot)
		{
			return new SimpleCompilation(solutionSnapshot, this, assemblyReferences);
		}

		protected virtual CSharpProjectContent Clone()
		{
			return new CSharpProjectContent(this);
		}

		public IProjectContent SetAssemblyName(string newAssemblyName)
		{
			CSharpProjectContent cSharpProjectContent = Clone();
			cSharpProjectContent.fullAssemblyName = newAssemblyName;
			int num = newAssemblyName?.IndexOf(',') ?? (-1);
			cSharpProjectContent.assemblyName = ((num < 0) ? newAssemblyName : newAssemblyName.Substring(0, num));
			return cSharpProjectContent;
		}

		public IProjectContent SetProjectFileName(string newProjectFileName)
		{
			CSharpProjectContent cSharpProjectContent = Clone();
			cSharpProjectContent.projectFileName = newProjectFileName;
			return cSharpProjectContent;
		}

		public IProjectContent SetLocation(string newLocation)
		{
			CSharpProjectContent cSharpProjectContent = Clone();
			cSharpProjectContent.location = newLocation;
			return cSharpProjectContent;
		}

		public IProjectContent SetCompilerSettings(object compilerSettings)
		{
			if (!(compilerSettings is CompilerSettings))
			{
				throw new ArgumentException("Settings must be an instance of " + typeof(CompilerSettings).FullName, "compilerSettings");
			}
			CSharpProjectContent cSharpProjectContent = Clone();
			cSharpProjectContent.compilerSettings = (CompilerSettings)compilerSettings;
			cSharpProjectContent.compilerSettings.Freeze();
			return cSharpProjectContent;
		}

		public IProjectContent AddAssemblyReferences(IEnumerable<IAssemblyReference> references)
		{
			return AddAssemblyReferences(references.ToArray());
		}

		public IProjectContent AddAssemblyReferences(params IAssemblyReference[] references)
		{
			CSharpProjectContent cSharpProjectContent = Clone();
			cSharpProjectContent.assemblyReferences.AddRange(references);
			return cSharpProjectContent;
		}

		public IProjectContent RemoveAssemblyReferences(IEnumerable<IAssemblyReference> references)
		{
			return RemoveAssemblyReferences(references.ToArray());
		}

		public IProjectContent RemoveAssemblyReferences(params IAssemblyReference[] references)
		{
			CSharpProjectContent cSharpProjectContent = Clone();
			foreach (IAssemblyReference item in references)
			{
				cSharpProjectContent.assemblyReferences.Remove(item);
			}
			return cSharpProjectContent;
		}

		public IProjectContent AddOrUpdateFiles(IEnumerable<IUnresolvedFile> newFiles)
		{
			CSharpProjectContent cSharpProjectContent = Clone();
			foreach (IUnresolvedFile newFile in newFiles)
			{
				cSharpProjectContent.unresolvedFiles[newFile.FileName] = newFile;
			}
			return cSharpProjectContent;
		}

		public IProjectContent AddOrUpdateFiles(params IUnresolvedFile[] newFiles)
		{
			return AddOrUpdateFiles((IEnumerable<IUnresolvedFile>)newFiles);
		}

		public IProjectContent RemoveFiles(IEnumerable<string> fileNames)
		{
			CSharpProjectContent cSharpProjectContent = Clone();
			foreach (string fileName in fileNames)
			{
				cSharpProjectContent.unresolvedFiles.Remove(fileName);
			}
			return cSharpProjectContent;
		}

		public IProjectContent RemoveFiles(params string[] fileNames)
		{
			return RemoveFiles((IEnumerable<string>)fileNames);
		}

		[Obsolete("Use RemoveFiles/AddOrUpdateFiles instead")]
		public IProjectContent UpdateProjectContent(IUnresolvedFile oldFile, IUnresolvedFile newFile)
		{
			if (oldFile == null && newFile == null)
			{
				return this;
			}
			if (oldFile != null && newFile != null && !Platform.FileNameComparer.Equals(oldFile.FileName, newFile.FileName))
			{
				throw new ArgumentException("When both oldFile and newFile are specified, they must use the same file name.");
			}
			CSharpProjectContent cSharpProjectContent = Clone();
			if (newFile == null)
			{
				cSharpProjectContent.unresolvedFiles.Remove(oldFile.FileName);
			}
			else
			{
				cSharpProjectContent.unresolvedFiles[newFile.FileName] = newFile;
			}
			return cSharpProjectContent;
		}

		[Obsolete("Use RemoveFiles/AddOrUpdateFiles instead")]
		public IProjectContent UpdateProjectContent(IEnumerable<IUnresolvedFile> oldFiles, IEnumerable<IUnresolvedFile> newFiles)
		{
			CSharpProjectContent cSharpProjectContent = Clone();
			if (oldFiles != null)
			{
				foreach (IUnresolvedFile oldFile in oldFiles)
				{
					cSharpProjectContent.unresolvedFiles.Remove(oldFile.FileName);
				}
			}
			if (newFiles != null)
			{
				foreach (IUnresolvedFile newFile in newFiles)
				{
					cSharpProjectContent.unresolvedFiles.Add(newFile.FileName, newFile);
				}
				return cSharpProjectContent;
			}
			return cSharpProjectContent;
		}

		IAssembly IAssemblyReference.Resolve(ITypeResolveContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			CacheManager cacheManager = context.Compilation.CacheManager;
			IAssembly assembly = (IAssembly)cacheManager.GetShared(this);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = new CSharpAssembly(context.Compilation, this);
			return (IAssembly)cacheManager.GetOrAddShared(this, assembly);
		}
	}
}
