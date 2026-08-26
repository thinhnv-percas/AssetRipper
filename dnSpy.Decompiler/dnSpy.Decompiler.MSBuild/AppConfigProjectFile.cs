using System.IO;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class AppConfigProjectFile : ProjectFile
{
	private readonly string existingName;

	public override string Description => string.Format(dnSpy_Decompiler_Resources.MSBuild_CopyAppConfig, existingName);

	public override BuildAction BuildAction => BuildAction.None;

	public override string Filename { get; }

	public AppConfigProjectFile(string filename, string existingName)
	{
		Filename = filename;
		this.existingName = existingName;
	}

	public override void Create(DecompileContext ctx)
	{
		File.Copy(existingName, Filename, overwrite: true);
	}
}
