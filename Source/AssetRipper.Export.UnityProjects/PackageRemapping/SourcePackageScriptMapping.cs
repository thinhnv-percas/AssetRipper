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
		Dictionary<string, Dictionary<string, string>> byAssembly = IndexSourceFilesByAssembly(packagePath);
		List<string> assemblyNames = [.. byAssembly.Keys];

		List<ScriptRemap> remaps = [];
		List<string> rippedAssemblies = [];

		foreach ((string assemblyName, Dictionary<string, string> byClassName) in byAssembly)
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
	/// The package's source files, grouped by the assembly each one is compiled into and keyed by the
	/// class it holds, which Unity requires to be its file name.
	/// </summary>
	/// <remarks>
	/// Grouping by assembly rather than pooling every file matters twice over. An editor only class can
	/// share a name with a runtime one, and pairing a ripped runtime type with the editor file would
	/// give a component a script that does not exist in a build. And a name that repeats across two
	/// assemblies is not ambiguous at all once the assembly is known, so pooling would throw away
	/// mappings that are perfectly well determined.
	/// <para>
	/// An assembly definition owns every file beneath it that a nearer one does not claim, which is the
	/// same rule Unity applies.
	/// </para>
	/// </remarks>
	private static Dictionary<string, Dictionary<string, string>> IndexSourceFilesByAssembly(string packagePath)
	{
		Dictionary<string, Dictionary<string, string>> byAssembly = new(StringComparer.Ordinal);
		Dictionary<string, HashSet<string>> duplicates = new(StringComparer.Ordinal);

		if (!Directory.Exists(packagePath))
		{
			return byAssembly;
		}

		List<(string Folder, string Name)> definitions = ReadAssemblyDefinitions(packagePath);
		if (definitions.Count == 0)
		{
			return byAssembly;
		}

		foreach (string path in Directory.EnumerateFiles(packagePath, "*.cs", SearchOption.AllDirectories))
		{
			if (FindOwningAssembly(definitions, path) is not string assemblyName
				|| !TryReadMetaGuid(LocalFileSystem.Instance, path + MetaExtension, out string? guid))
			{
				continue;
			}

			if (!byAssembly.TryGetValue(assemblyName, out Dictionary<string, string>? byClassName))
			{
				byClassName = new Dictionary<string, string>(StringComparer.Ordinal);
				byAssembly.Add(assemblyName, byClassName);
				duplicates.Add(assemblyName, new HashSet<string>(StringComparer.Ordinal));
			}

			string className = Path.GetFileNameWithoutExtension(path);
			if (!byClassName.TryAdd(className, guid))
			{
				duplicates[assemblyName].Add(className);
			}
		}

		// A name that occurs twice inside one assembly identifies neither of them.
		foreach ((string assemblyName, HashSet<string> names) in duplicates)
		{
			foreach (string name in names)
			{
				byAssembly[assemblyName].Remove(name);
			}
		}

		return byAssembly;
	}

	/// <summary>
	/// Every assembly definition in the package, with the folder it governs.
	/// </summary>
	private static List<(string Folder, string Name)> ReadAssemblyDefinitions(string packagePath)
	{
		List<(string Folder, string Name)> definitions = [];

		foreach (string path in Directory.EnumerateFiles(packagePath, "*.asmdef", SearchOption.AllDirectories))
		{
			try
			{
				using JsonDocument document = JsonDocument.Parse(File.ReadAllText(path));
				if (document.RootElement.TryGetProperty("name", out JsonElement name) && name.GetString() is string value && value.Length > 0)
				{
					definitions.Add((Path.GetDirectoryName(path)!.Replace('\\', '/'), value));
				}
			}
			catch (Exception)
			{
			}
		}

		return definitions;
	}

	/// <summary>
	/// The assembly a file belongs to, which is the nearest definition above it.
	/// </summary>
	private static string? FindOwningAssembly(List<(string Folder, string Name)> definitions, string path)
	{
		string normalised = path.Replace('\\', '/');
		string? owner = null;
		int depth = -1;

		foreach ((string folder, string name) in definitions)
		{
			if (normalised.StartsWith(folder + '/', StringComparison.OrdinalIgnoreCase) && folder.Length > depth)
			{
				owner = name;
				depth = folder.Length;
			}
		}

		return owner;
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
