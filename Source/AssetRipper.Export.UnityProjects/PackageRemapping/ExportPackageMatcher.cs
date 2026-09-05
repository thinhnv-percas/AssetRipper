using AssetRipper.IO.Files;
using System.Text.RegularExpressions;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// One ripped file an official package replaces.
/// </summary>
/// <param name="RippedPath">Where it is in the export.</param>
/// <param name="Kind">How it was recognised, for the report.</param>
public readonly record struct ExportMatch(string RippedPath, string OldGuid, string NewGuid, string Kind);

/// <summary>
/// Pairs an export's assets with the official package's, using what an export actually looks like.
/// </summary>
/// <remarks>
/// An export does not reproduce a package's folder structure. Assets are written into folders named
/// after their type, so a package's <c>Shaders/TMP_SDF.shader</c> comes out as
/// <c>Assets/Shader/TextMeshPro_Distance Field.shader</c>, named after the shader rather than the file.
/// Nothing about the path says which package an asset came from, so paths cannot be matched at all.
/// <para>
/// What can be matched is identity. A shader declares its name inside the file, and that name is the
/// same on both sides. An assembly keeps its file name. Everything else falls back to the file name
/// when it is unique on both sides.
/// </para>
/// </remarks>
public static partial class ExportPackageMatcher
{
	/// <summary>
	/// The name a shader announces itself by, which is what a material refers to it as.
	/// </summary>
	[GeneratedRegex(@"^\s*Shader\s+""(?<name>[^""]+)""", RegexOptions.Multiline | RegexOptions.CultureInvariant)]
	private static partial Regex ShaderNameRegex { get; }

	private const string MetaExtension = ".meta";

	/// <summary>
	/// Finds everything in the export that the official package replaces.
	/// </summary>
	/// <param name="assetsPath">The export's Assets folder.</param>
	/// <param name="packagePath">The official package.</param>
	public static List<ExportMatch> Match(string assetsPath, string packagePath, FileSystem fileSystem)
	{
		List<ExportMatch> matches = [];

		Dictionary<string, string> rippedByPath = ScanGuidsByPath(assetsPath, fileSystem);
		if (rippedByPath.Count == 0)
		{
			return matches;
		}

		Dictionary<string, string> officialByPath = ScanGuidsByPath(packagePath, LocalFileSystem.Instance);

		MatchAssemblies(matches, rippedByPath, officialByPath);
		MatchShaders(matches, assetsPath, packagePath, rippedByPath, officialByPath, fileSystem);
		MatchByFileName(matches, rippedByPath, officialByPath);

		return matches;
	}

	/// <summary>
	/// Every asset that has a meta file, by its path, with the guid the meta gives it.
	/// </summary>
	private static Dictionary<string, string> ScanGuidsByPath(string root, FileSystem fileSystem)
	{
		Dictionary<string, string> byPath = new(StringComparer.OrdinalIgnoreCase);

		if (!fileSystem.Directory.Exists(root))
		{
			return byPath;
		}

		foreach (string metaPath in fileSystem.Directory.EnumerateFiles(root, $"*{MetaExtension}", SearchOption.AllDirectories))
		{
			try
			{
				using StringReader reader = new(fileSystem.File.ReadAllText(metaPath));
				if (MetaGuidScanner.TryReadGuid(reader, out string? guid))
				{
					byPath[metaPath[..^MetaExtension.Length]] = guid;
				}
			}
			catch (IOException)
			{
			}
		}

		return byPath;
	}

	/// <summary>
	/// An assembly keeps its file name, so the ripped copy of it is the one named the same.
	/// </summary>
	/// <remarks>
	/// This is the match that matters most. In the default export mode a package's code is saved as an
	/// assembly rather than decompiled, and every script reference into it already carries the fileID
	/// Unity computes from the namespace and class name. So one guid, the assembly's, repoints every
	/// reference to every type in the package at once, and the fileIDs do not move.
	/// </remarks>
	private static void MatchAssemblies(List<ExportMatch> matches, Dictionary<string, string> ripped, Dictionary<string, string> official)
	{
		Dictionary<string, string> officialAssemblies = IndexByFileName(official, static path => path.EndsWith(".dll", StringComparison.OrdinalIgnoreCase));

		foreach ((string path, string oldGuid) in ripped)
		{
			if (!path.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}

			if (officialAssemblies.TryGetValue(GetFileName(path), out string? newGuid))
			{
				matches.Add(new ExportMatch(path, oldGuid, newGuid, "assembly"));
			}
		}
	}

	/// <summary>
	/// A shader is matched by the name it declares, since neither side keeps the other's file name.
	/// </summary>
	private static void MatchShaders(
		List<ExportMatch> matches,
		string assetsPath,
		string packagePath,
		Dictionary<string, string> ripped,
		Dictionary<string, string> official,
		FileSystem fileSystem)
	{
		Dictionary<string, string> officialByShaderName = new(StringComparer.Ordinal);
		foreach ((string path, string guid) in official)
		{
			if (path.EndsWith(".shader", StringComparison.OrdinalIgnoreCase) && TryReadShaderName(path, LocalFileSystem.Instance, out string? name))
			{
				// A name declared twice in one package cannot identify either of them.
				if (!officialByShaderName.TryAdd(name, guid))
				{
					officialByShaderName[name] = "";
				}
			}
		}

		foreach ((string path, string oldGuid) in ripped)
		{
			if (!path.EndsWith(".shader", StringComparison.OrdinalIgnoreCase) || !TryReadShaderName(path, fileSystem, out string? name))
			{
				continue;
			}

			if (officialByShaderName.TryGetValue(name, out string? newGuid) && newGuid.Length > 0)
			{
				matches.Add(new ExportMatch(path, oldGuid, newGuid, "shader name"));
			}
		}
	}

	private static bool TryReadShaderName(string path, FileSystem fileSystem, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out string? name)
	{
		try
		{
			// The declaration is the first thing in the file, so there is no need to read all of it.
			string text = fileSystem.File.ReadAllText(path);
			Match match = ShaderNameRegex.Match(text.Length > 4096 ? text[..4096] : text);
			name = match.Success ? match.Groups["name"].Value : null;
			return name is not null;
		}
		catch (IOException)
		{
			name = null;
			return false;
		}
	}

	/// <summary>
	/// Everything else, when the file name is unique on both sides.
	/// </summary>
	/// <remarks>
	/// Uniqueness is what makes this safe. A name that occurs twice on either side identifies nothing,
	/// and pairing the wrong two assets would repoint references at something unrelated.
	/// <para>
	/// Code is excluded rather than left to that rule. A script belongs to an assembly, and which
	/// assembly is what decides whether a package replaces it, so matching one by name across the whole
	/// project could repoint a script of the game's own at a package file that merely shares its name.
	/// <see cref="SourcePackageScriptMapping"/> does that half, knowing both the assembly and the two
	/// shapes a script reference can take.
	/// </para>
	/// </remarks>
	private static void MatchByFileName(List<ExportMatch> matches, Dictionary<string, string> ripped, Dictionary<string, string> official)
	{
		HashSet<string> alreadyMatched = [.. matches.Select(static match => match.RippedPath)];

		Dictionary<string, string> officialByName = IndexByFileName(official, IsMatchableByName);
		Dictionary<string, string> rippedByName = IndexByFileName(ripped, IsMatchableByName);

		foreach ((string path, string oldGuid) in ripped)
		{
			if (alreadyMatched.Contains(path) || !IsMatchableByName(path))
			{
				continue;
			}

			string fileName = GetFileName(path);
			if (rippedByName.ContainsKey(fileName) && officialByName.TryGetValue(fileName, out string? newGuid))
			{
				matches.Add(new ExportMatch(path, oldGuid, newGuid, "file name"));
			}
		}
	}

	/// <summary>
	/// Indexes by file name, dropping the names that occur more than once.
	/// </summary>
	private static Dictionary<string, string> IndexByFileName(Dictionary<string, string> byPath, Func<string, bool> filter)
	{
		Dictionary<string, string> index = new(StringComparer.OrdinalIgnoreCase);
		HashSet<string> duplicates = new(StringComparer.OrdinalIgnoreCase);

		foreach ((string path, string guid) in byPath)
		{
			if (!filter(path))
			{
				continue;
			}

			string fileName = GetFileName(path);
			if (!index.TryAdd(fileName, guid))
			{
				duplicates.Add(fileName);
			}
		}

		foreach (string duplicate in duplicates)
		{
			index.Remove(duplicate);
		}

		return index;
	}

	/// <summary>
	/// Whether a file is one this rule may pair. Assemblies and code are matched by other means.
	/// </summary>
	private static bool IsMatchableByName(string path)
	{
		return !path.EndsWith(".dll", StringComparison.OrdinalIgnoreCase)
			&& !path.EndsWith(".cs", StringComparison.OrdinalIgnoreCase)
			&& !path.EndsWith(".asmdef", StringComparison.OrdinalIgnoreCase)
			&& !path.EndsWith(".asmref", StringComparison.OrdinalIgnoreCase);
	}

	private static string GetFileName(string path)
	{
		int separator = path.AsSpan().LastIndexOfAny('/', '\\');
		return separator < 0 ? path : path[(separator + 1)..];
	}
}
