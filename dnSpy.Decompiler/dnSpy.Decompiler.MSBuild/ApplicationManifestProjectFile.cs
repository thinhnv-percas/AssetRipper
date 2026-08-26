using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class ApplicationManifestProjectFile : ProjectFile
{
	public override BuildAction BuildAction => BuildAction.None;

	public override string Description => dnSpy_Decompiler_Resources.MSBuild_CreateAppManifest;

	public override string Filename { get; }

	public ApplicationManifestProjectFile(string filename)
	{
		Filename = filename;
	}

	public override void Create(DecompileContext ctx)
	{
	}
}
