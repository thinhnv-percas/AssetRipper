using AssetRipper.Import.Structure.Assembly;
using AssetRipper.Import.Structure.Platforms;
using AssetRipper.IO.Files;

namespace AssetRipper.Import.Platforms;

internal sealed class iOSGameStructure : PlatformGameStructure
{
	public iOSGameStructure(string rootPath, FileSystem fileSystem) : base(rootPath, fileSystem)
	{
		if (!GetDataiOSDirectory(rootPath, FileSystem, out string? dataPath, out string? appPath, out string? name))
		{
			throw new DirectoryNotFoundException($"Data directory wasn't found");
		}

		Name = name;
		GameDataPath = dataPath;
		StreamingAssetsPath = FileSystem.Path.Join(dataPath, iOSStreamingName);
		ResourcesPath = FileSystem.Path.Join(dataPath, ResourcesName);
		ManagedPath = FileSystem.Path.Join(dataPath, ManagedName);
		UnityPlayerPath = null;
		Version = GetUnityVersionFromDataDirectory(GameDataPath);
		Il2CppGameAssemblyPath = GetIl2CppGameAssemblyPath(appPath, name);
		Il2CppMetaDataPath = FileSystem.Path.Join(ManagedPath, MetadataName, DefaultGlobalMetadataName);

		if (HasIl2CppFiles())
		{
			Backend = ScriptingBackend.IL2Cpp;
		}
		else if (HasMonoAssemblies(ManagedPath))
		{
			Backend = ScriptingBackend.Mono;
		}
		else
		{
			Backend = ScriptingBackend.Unknown;
		}

		DataPaths = [GameDataPath];
	}

	/// <summary>
	/// The Mach-O holding the il2cpp code, or null when neither candidate is present.
	/// </summary>
	/// <remarks>
	/// Unity 2019.3 moved the player — and with it every generated method body — out of the app's own
	/// executable and into <c>Frameworks/UnityFramework.framework/UnityFramework</c>. What is left at
	/// <c>&lt;App&gt;.app/&lt;App&gt;</c> is a launcher of a few tens of kilobytes that contains no
	/// il2cpp code at all, so taking it is not a worse recovery but no recovery: LibCpp2IL finds no
	/// code registration in it, initialisation throws, and the whole import falls back to the
	/// <c>Unknown</c> scripting backend with no scripts exported. Older builds have no framework and
	/// the executable really is the binary, hence the two candidates.
	/// </remarks>
	private string? GetIl2CppGameAssemblyPath(string appPath, string appName)
	{
		string framework = FileSystem.Path.Join(appPath, FrameworksName, UnityFrameworkName + FrameworkExtension, UnityFrameworkName);
		if (FileSystem.File.Exists(framework))
		{
			return framework;
		}

		string executable = FileSystem.Path.Join(appPath, appName);
		return FileSystem.File.Exists(executable) ? executable : null;
	}

	public static bool Exists(string path, FileSystem fileSystem)
	{
		if (!fileSystem.Directory.Exists(path))
		{
			return false;
		}

		return GetDataiOSDirectory(path, fileSystem, out _, out _, out _);
	}

	private static bool GetDataiOSDirectory(string rootDirectory, FileSystem fileSystem, [NotNullWhen(true)] out string? dataPath, [NotNullWhen(true)] out string? appPath, [NotNullWhen(true)] out string? appName)
	{
		string payloadPath = fileSystem.Path.Join(rootDirectory, PayloadName);
		if (!fileSystem.Directory.Exists(payloadPath))
		{
			dataPath = null;
			appPath = null;
			appName = null;
			return false;
		}

		foreach (string directory in fileSystem.Directory.EnumerateDirectories(payloadPath))
		{
			string name = fileSystem.Path.GetFileName(directory);
			if (name.EndsWith(AppExtension, StringComparison.Ordinal))
			{
				appPath = directory;
				appName = name[..^AppExtension.Length];
				dataPath = fileSystem.Path.Join(directory, DataFolderName);
				if (fileSystem.Directory.Exists(dataPath))
				{
					return true;
				}
			}
		}

		dataPath = null;
		appPath = null;
		appName = null;
		return false;
	}

	private const string iOSStreamingName = "Raw";

	private const string PayloadName = "Payload";
	private const string AppExtension = ".app";
	private const string FrameworksName = "Frameworks";
	private const string FrameworkExtension = ".framework";
	private const string UnityFrameworkName = "UnityFramework";
}
