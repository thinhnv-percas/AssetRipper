using AsmResolver.DotNet;
using AssetRipper.Export.UnityProjects.Scripts;
using AssetRipper.IO.Files;
using System.Text.Json;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// What a package that ships source rather than an assembly replaces in an export.
/// </summary>
/// <param name="AssemblyNames">The assemblies its assembly definitions declare.</param>
/// <param name="RippedAssemblyPaths">Ripped assemblies the package replaces, which are files rather than folders.</param>
public readonly record struct SourcePackageScripts(List<string> AssemblyNames, List<ScriptRemap> Remaps, List<string> RippedAssemblyPaths);

/// <summary>
/// Maps script references onto a package that ships its code as source files.
/// </summary>
/// <remarks>
/// Most Unity packages ship source, not an assembly: <c>com.unity.textmeshpro</c> is 109 <c>.cs</c>
/// files and an assembly definition, with no dll anywhere. Unity compiles them itself, and a reference
/// to one of those types is written the way a reference to any source file is, as
/// <c>{fileID: 11500000, guid: the .cs file's own guid}</c>.
/// <para>
/// The ripped side is neither of those. Depending on the export mode it is one assembly holding every
/// type, or one decompiled file per type, and both carry guids AssetRipper derived. So the mapping is
/// per type, and the type's name is what pairs the two sides: Unity requires a serialisable class to
/// live in a file named after it, which is what makes the package's file names usable as class names.
/// </para>
/// </remarks>
public static class SourcePackageScriptMapping
{
	private const string MetaExtension = ".meta";

	/// <summary>
	/// Builds the mapping for one package against one export.
	/// </summary>
	/// <param name="assetsPath">The export's Assets folder.</param>
	public static SourcePackageScripts Build(string assetsPath, string packagePath, FileSystem fileSystem)
	{
		List<string> assemblyNames = ReadAssemblyNames(packagePath);
		Dictionary<string, string> byClassName = IndexSourceFiles(packagePath);

		List<ScriptRemap> remaps = [];
		List<string> rippedAssemblies = [];

		if (assemblyNames.Count == 0 || byClassName.Count == 0)
		{
			return new SourcePackageScripts(assemblyNames, remaps, rippedAssemblies);
		}

		foreach (string assemblyName in assemblyNames)
		{
			AddFromSavedAssembly(assetsPath, assemblyName, byClassName, fileSystem, remaps, rippedAssemblies);
			AddFromDecompiledSources(assetsPath, assemblyName, byClassName, fileSystem, remaps);
		}

		return new SourcePackageScripts(assemblyNames, remaps, rippedAssemblies);
	}

	/// <summary>
	/// The Hybrid export mode saves the assembly under Plugins, so the old reference is the fileID Unity
	/// computes from the namespace and class name paired with the assembly's guid.
	/// </summary>
	private static void AddFromSavedAssembly(
		string assetsPath,
		string assemblyName,
		Dictionary<string, string> byClassName,
		FileSystem fileSystem,
		List<ScriptRemap> remaps,
		List<string> rippedAssemblies)
	{
		string path = fileSystem.Path.Join(assetsPath, "Plugins", assemblyName + ".dll");
		if (!fileSystem.File.Exists(path) || !TryReadMetaGuid(fileSystem, path + MetaExtension, out string? assemblyGuid))
		{
			return;
		}

		ModuleDefinition module;
		try
		{
			module = ModuleDefinition.FromBytes(fileSystem.File.ReadAllBytes(path));
		}
		catch (Exception)
		{
			return;
		}

		rippedAssemblies.Add(path);

		foreach (TypeDefinition type in module.TopLevelTypes)
		{
			string name = type.Name ?? "";
			if (!byClassName.TryGetValue(StripGenericArity(name), out string? sourceGuid))
			{
				continue;
			}

			string @namespace = type.Namespace ?? "";
			remaps.Add(new ScriptRemap(
				@namespace.Length == 0 ? name : $"{@namespace}.{name}",
				new AssetReference(ScriptHashing.CalculateScriptFileID(@namespace, name), assemblyGuid),
				new AssetReference(ScriptReferenceMapping.DecompiledScriptFileId, sourceGuid)));
		}
	}

	/// <summary>
	/// The Decompiled export mode writes one file per type, each with a guid of its own, so only the
	/// guid moves.
	/// </summary>
	private static void AddFromDecompiledSources(
		string assetsPath,
		string assemblyName,
		Dictionary<string, string> byClassName,
		FileSystem fileSystem,
		List<ScriptRemap> remaps)
	{
		string folder = fileSystem.Path.Join(assetsPath, "Scripts", assemblyName);
		if (!fileSystem.Directory.Exists(folder))
		{
			return;
		}

		foreach (string path in fileSystem.Directory.EnumerateFiles(folder, "*.cs", SearchOption.AllDirectories))
		{
			string className = Path.GetFileNameWithoutExtension(path);
			if (!byClassName.TryGetValue(className, out string? sourceGuid)
				|| !TryReadMetaGuid(fileSystem, path + MetaExtension, out string? rippedGuid))
			{
				continue;
			}

			remaps.Add(new ScriptRemap(
				className,
				new AssetReference(ScriptReferenceMapping.DecompiledScriptFileId, rippedGuid),
				new AssetReference(ScriptReferenceMapping.DecompiledScriptFileId, sourceGuid)));
		}
	}

	/// <summary>
	/// The assemblies a package declares, which is how its source is grouped once Unity compiles it.
	/// </summary>
	private static List<string> ReadAssemblyNames(string packagePath)
	{
		List<string> names = [];

		if (!Directory.Exists(packagePath))
		{
			return names;
		}

		foreach (string path in Directory.EnumerateFiles(packagePath, "*.asmdef", SearchOption.AllDirectories))
		{
			try
			{
				using JsonDocument document = JsonDocument.Parse(File.ReadAllText(path));
				if (document.RootElement.TryGetProperty("name", out JsonElement name) && name.GetString() is string value && value.Length > 0)
				{
					names.Add(value);
				}
			}
			catch (Exception)
			{
			}
		}

		return names;
	}

	/// <summary>
	/// The package's source files by the class each one holds, which Unity requires to be its file name.
	/// </summary>
	/// <remarks>
	/// A name that occurs twice identifies neither of them, so it is dropped rather than guessed at.
	/// </remarks>
	private static Dictionary<string, string> IndexSourceFiles(string packagePath)
	{
		Dictionary<string, string> byClassName = new(StringComparer.Ordinal);
		HashSet<string> duplicates = new(StringComparer.Ordinal);

		if (!Directory.Exists(packagePath))
		{
			return byClassName;
		}

		foreach (string path in Directory.EnumerateFiles(packagePath, "*.cs", SearchOption.AllDirectories))
		{
			// Tests and editor only code are compiled into their own assemblies, and a game never refers
			// to either, so pairing against them would only add ways to be wrong.
			if (IsExcluded(packagePath, path) || !TryReadMetaGuid(LocalFileSystem.Instance, path + MetaExtension, out string? guid))
			{
				continue;
			}

			string className = Path.GetFileNameWithoutExtension(path);
			if (!byClassName.TryAdd(className, guid))
			{
				duplicates.Add(className);
			}
		}

		foreach (string duplicate in duplicates)
		{
			byClassName.Remove(duplicate);
		}

		return byClassName;
	}

	private static bool IsExcluded(string packagePath, string path)
	{
		string relative = MetaGuidScanner.GetRelativePath(packagePath, path);
		return relative.StartsWith("Tests/", StringComparison.OrdinalIgnoreCase)
			|| relative.Contains("/Tests/", StringComparison.OrdinalIgnoreCase);
	}

	/// <summary>
	/// AsmResolver spells a generic type's name with its arity, which no file name carries.
	/// </summary>
	private static string StripGenericArity(string name)
	{
		int backtick = name.IndexOf('`');
		return backtick < 0 ? name : name[..backtick];
	}

	private static bool TryReadMetaGuid(FileSystem fileSystem, string metaPath, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out string? guid)
	{
		guid = null;

		try
		{
			if (!fileSystem.File.Exists(metaPath))
			{
				return false;
			}

			using StringReader reader = new(fileSystem.File.ReadAllText(metaPath));
			return MetaGuidScanner.TryReadGuid(reader, out guid);
		}
		catch (IOException)
		{
			return false;
		}
	}
}
