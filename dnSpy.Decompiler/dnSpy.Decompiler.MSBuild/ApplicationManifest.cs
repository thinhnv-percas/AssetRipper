using System.IO;
using dnlib.IO;
using dnlib.W32Resources;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class ApplicationManifest : IFileJob, IJob
{
	private const int RT_MANIFEST = 24;

	private DataReader reader;

	public string Description => dnSpy_Decompiler_Resources.MSBuild_CreateAppManifest;

	public string Filename { get; }

	private ApplicationManifest(string filename, ref DataReader reader)
	{
		Filename = filename;
		this.reader = reader;
	}

	public static ApplicationManifest TryCreate(Win32Resources resources, FilenameCreator filenameCreator)
	{
		if (resources == null)
		{
			return null;
		}
		ResourceDirectory resourceDirectory = resources.Find(new ResourceName(24));
		if (resourceDirectory == null || resourceDirectory.Directories.Count == 0)
		{
			return null;
		}
		resourceDirectory = resourceDirectory.Directories[0];
		if (resourceDirectory.Data.Count == 0)
		{
			return null;
		}
		DataReader dataReader = resourceDirectory.Data[0].CreateReader();
		return new ApplicationManifest(filenameCreator.CreateName("app.manifest"), ref dataReader);
	}

	public void Create(DecompileContext ctx)
	{
		using FileStream destination = File.Create(Filename);
		reader.CopyTo(destination);
	}
}
