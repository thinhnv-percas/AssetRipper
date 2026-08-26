namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface ISolutionSnapshot
	{
		IProjectContent GetProjectContent(string projectFileName);

		ICompilation GetCompilation(IProjectContent project);
	}
}
