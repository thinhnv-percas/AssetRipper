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
		StreamingAssetsPath = FileSystem.Path.Join(rootPath, iOSStreamingName);
		ResourcesPath = FileSystem.Path.Join(dataPath, ResourcesName);
		ManagedPath = FileSystem.Path.Join(dataPath, ManagedName);
		UnityPlayerPath = null;
		Version = GetUnityVersionFromDataDirectory(GameDataPath);
		Il2CppGameAssemblyPath = GetIl2CppBinaryPath(appPath, name);
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

	/// <summary>
	/// AssetRipper: il2cpp code lives in UnityFramework.framework, not in the app executable.
	/// </summary>
	/// <remarks>
	/// Unity 2019.3 moved the player into an embedded framework, so the Mach-O named after the
	/// bundle is a launcher of a few tens of kilobytes with no managed code in it at all - on the
	/// test fixture, 70 KB against UnityFramework's 51 MB. Handing that one to LibCpp2IL fails with
	/// "No codegen modules found for mscorlib", which reads like a metadata problem and is not one:
	/// the metadata had already loaded, and the binary simply was not the game. Older builds do keep
	/// il2cpp in the app executable, so that stays the fallback.
	/// </remarks>
	private string GetIl2CppBinaryPath(string appPath, string name)
	{
		string frameworkPath = FileSystem.Path.Join(appPath, FrameworksName, UnityFrameworkName + FrameworkExtension, UnityFrameworkName);

		return FileSystem.File.Exists(frameworkPath)
			? frameworkPath
			: FileSystem.Path.Join(appPath, name);
	}

	private const string iOSStreamingName = "Raw";

	private const string PayloadName = "Payload";
	private const string AppExtension = ".app";
	private const string FrameworksName = "Frameworks";
	private const string UnityFrameworkName = "UnityFramework";
	private const string FrameworkExtension = ".framework";
}
