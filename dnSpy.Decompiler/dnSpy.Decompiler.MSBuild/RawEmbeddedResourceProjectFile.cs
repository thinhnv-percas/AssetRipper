using System.IO;
using dnlib.DotNet;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class RawEmbeddedResourceProjectFile : ProjectFile
{
	private readonly string filename;

	private readonly EmbeddedResource embeddedResource;

	public override string Description => string.Format(dnSpy_Decompiler_Resources.MSBuild_CreateEmbeddedResource, embeddedResource.Name);

	public override BuildAction BuildAction => BuildAction.EmbeddedResource;

	public override string Filename => filename;

	public RawEmbeddedResourceProjectFile(string filename, EmbeddedResource er)
	{
		this.filename = filename;
		embeddedResource = er;
	}

	public override void Create(DecompileContext ctx)
	{
		using FileStream destination = File.Create(Filename);
		embeddedResource.CreateReader().CopyTo(destination);
	}
}
