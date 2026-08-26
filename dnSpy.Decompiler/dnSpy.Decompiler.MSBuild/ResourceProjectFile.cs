using System.IO;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class ResourceProjectFile : ProjectFile
{
	private readonly string filename;

	private readonly byte[] data;

	private readonly string rsrcName;

	public override string Description => string.Format(dnSpy_Decompiler_Resources.MSBuild_CreateResource, rsrcName);

	public override BuildAction BuildAction => BuildAction.Resource;

	public override string Filename => filename;

	public ResourceProjectFile(string filename, byte[] data, string rsrcName)
	{
		this.filename = filename;
		this.data = data;
		this.rsrcName = rsrcName;
	}

	public override void Create(DecompileContext ctx)
	{
		using FileStream fileStream = File.Create(Filename);
		fileStream.Write(data, 0, data.Length);
	}
}
