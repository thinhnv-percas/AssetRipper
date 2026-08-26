using System;

namespace ICSharpCode.NRefactory.TypeSystem;

[Serializable]
public class ProjectReference : IAssemblyReference
{
	private readonly string projectFileName;

	public ProjectReference(string projectFileName)
	{
		this.projectFileName = projectFileName;
	}

	public IAssembly Resolve(ITypeResolveContext context)
	{
		ISolutionSnapshot solutionSnapshot = context.Compilation.SolutionSnapshot;
		return solutionSnapshot.GetProjectContent(projectFileName)?.Resolve(context);
	}

	public override string ToString()
	{
		return $"[ProjectReference {projectFileName}]";
	}
}
