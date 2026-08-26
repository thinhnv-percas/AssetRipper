namespace dnSpy.Decompiler.MSBuild;

internal abstract class ProjectFile : IFileJob, IJob
{
	public abstract string Description { get; }

	public abstract string Filename { get; }

	public abstract BuildAction BuildAction { get; }

	public ProjectFile DependentUpon { get; set; }

	public string SubType { get; set; }

	public string Generator { get; set; }

	public ProjectFile LastGenOutput { get; set; }

	public bool AutoGen { get; set; }

	public bool DesignTime { get; set; }

	public bool DesignTimeSharedInput { get; set; }

	public abstract void Create(DecompileContext ctx);
}
