using AssetRipper.Export.Configuration;
using AssetRipper.IO.Files;
using AssetRipper.Il2CppRestore.Cli;
using AssetRipper.Import.Configuration;
using AssetRipper.Import.Logging;
using AssetRipper.Import.Structure.Assembly.Managers;
using AssetRipper.Processing;

namespace AssetRipper.Export.UnityProjects.Il2CppRestore;

/// <summary>
/// At <see cref="ScriptContentLevel.Level4"/>, re-lifts IL2Cpp method bodies straight from the native
/// binary and overwrites the <c>.cs</c> files <see cref="Scripts.ScriptExportCollection"/> already wrote
/// during the main export, in place — same file, same guid, only richer content.
/// </summary>
/// <remarks>
/// This never regenerates a script's guid or touches its <c>.meta</c> file: scenes and prefabs already
/// reference the script by the guid <see cref="Scripts.ScriptExportCollectionBase"/> assigned it, and
/// changing that would break every one of those references.
/// <para>
/// <c>global-metadata.dat</c>, the native binary, and the Unity version all come from the
/// <see cref="IL2CppManager"/> that already loaded the game for the main export — nothing to ask the user
/// for beyond the struct DB folder (<see cref="ExportSettings.StructDbDirectoryPath"/>), which cannot be
/// inferred from the game itself.
/// </para>
/// </remarks>
public sealed class Il2CppRestorePostExporter : IPostExporter
{
	public void DoPostExport(GameData gameData, FullConfiguration settings, FileSystem fileSystem)
	{
		if (settings.ImportSettings.ScriptContentLevel != ScriptContentLevel.Level4)
		{
			return;
		}

		if (gameData.AssemblyManager is not IL2CppManager il2Cpp)
		{
			Logger.Warning(LogCategory.Export, "IL2Cpp restore skipped: this is not an IL2Cpp game.");
			return;
		}

		string? metadataPath = il2Cpp.MetaDataPath;
		string? binaryPath = il2Cpp.GameAssemblyPath;
		if (string.IsNullOrEmpty(metadataPath) || !File.Exists(metadataPath))
		{
			Logger.Warning(LogCategory.Export, "IL2Cpp restore skipped: global-metadata.dat was not found.");
			return;
		}
		if (string.IsNullOrEmpty(binaryPath) || !File.Exists(binaryPath))
		{
			Logger.Warning(LogCategory.Export, "IL2Cpp restore skipped: the native game binary was not found.");
			return;
		}

		string? structDbDirectory = settings.ExportSettings.StructDbDirectoryPath;
		if (string.IsNullOrWhiteSpace(structDbDirectory))
		{
			Logger.Warning(LogCategory.Export, "IL2Cpp restore: no struct DB folder configured. Lifted bodies will only resolve managed field offsets, never native runtime struct fields.");
			structDbDirectory = null;
		}

		Logger.Info(LogCategory.Export, "IL2Cpp restore: disassembling and lifting native methods...");

		RestorePipeline pipeline;
		try
		{
			pipeline = RestorePipeline.Build(metadataPath, binaryPath, structDbDirectory, il2Cpp.UnityVersion.ToString(), new LoggerTextWriter());
		}
		catch (Exception exception)
		{
			Logger.Error(LogCategory.Export, $"IL2Cpp restore failed while reading metadata/binary: {exception.Message}");
			return;
		}

		if (pipeline.Lift is null)
		{
			Logger.Warning(LogCategory.Export, "IL2Cpp restore skipped: could not locate the IL2Cpp registration structures in the native binary.");
			return;
		}

		string assetsPath = fileSystem.Path.Join(settings.ExportRootPath, "Assets");
		Dictionary<string, Dictionary<string, string>> filesByAssembly = new(StringComparer.Ordinal);

		int overwritten = 0;
		int missing = 0;
		foreach (LiftedType type in pipeline.EnumerateTopLevelTypes())
		{
			string assemblyFolderName = SpecialFileNames.RemoveAssemblyFileExtension(type.ModuleName);
			if (!filesByAssembly.TryGetValue(assemblyFolderName, out Dictionary<string, string>? byClassName))
			{
				byClassName = IndexDecompiledFiles(fileSystem, assetsPath, assemblyFolderName);
				filesByAssembly[assemblyFolderName] = byClassName;
			}

			if (!byClassName.TryGetValue(type.TypeName, out string? path))
			{
				missing++;
				continue;
			}

			try
			{
				fileSystem.File.WriteAllText(path, pipeline.RenderType(type));
				overwritten++;
			}
			catch (Exception exception)
			{
				Logger.Warning(LogCategory.Export, $"IL2Cpp restore: could not overwrite {path}: {exception.Message}");
			}
		}

		Logger.Info(LogCategory.Export, $"IL2Cpp restore: {overwritten} script(s) overwritten with lifted bodies, {missing} type(s) had no matching exported file.");
	}

	/// <summary>
	/// Every already-exported <c>.cs</c> file under one assembly's decompiled output folder, by the class
	/// name in its file name — the same name-matching precedent
	/// <see cref="PackageRemapping.SourcePackageScriptMapping"/> uses for source packages. A name that
	/// occurs twice (distinct types sharing a class name in different namespaces) identifies neither of
	/// them, so it is dropped rather than guessed at.
	/// </summary>
	private static Dictionary<string, string> IndexDecompiledFiles(FileSystem fileSystem, string assetsPath, string assemblyFolderName)
	{
		Dictionary<string, string> byClassName = new(StringComparer.Ordinal);
		HashSet<string> duplicates = new(StringComparer.Ordinal);

		foreach (string scriptsFolder in new[] { "Scripts", "Plugins" })
		{
			string folder = fileSystem.Path.Join(assetsPath, scriptsFolder, assemblyFolderName);
			if (!fileSystem.Directory.Exists(folder))
			{
				continue;
			}

			foreach (string path in fileSystem.Directory.EnumerateFiles(folder, "*.cs", SearchOption.AllDirectories))
			{
				string className = Path.GetFileNameWithoutExtension(path);
				if (!byClassName.TryAdd(className, path))
				{
					duplicates.Add(className);
				}
			}
		}

		foreach (string duplicate in duplicates)
		{
			byClassName.Remove(duplicate);
		}

		return byClassName;
	}

	/// <summary>Routes <see cref="RestorePipeline"/>'s progress lines into AssetRipper's own logger.</summary>
	private sealed class LoggerTextWriter : TextWriter
	{
		public override System.Text.Encoding Encoding => System.Text.Encoding.UTF8;

		public override void WriteLine(string? value) => Logger.Info(LogCategory.Export, $"IL2Cpp restore: {value}");

		public override void Write(char value)
		{
			// RestorePipeline only ever calls WriteLine; this is here solely to satisfy TextWriter's abstract member.
		}
	}
}
