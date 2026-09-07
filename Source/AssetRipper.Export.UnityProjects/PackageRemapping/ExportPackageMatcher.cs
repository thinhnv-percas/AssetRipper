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
/// same on both sides; where it does not declare one, its file name is what is left to go on. An
/// assembly keeps its file name. Everything else falls back to the file name when it is unique on both
/// sides.
/// </para>
/// </remarks>
public static partial class ExportPackageMatcher
{
	/// <summary>
	/// The name a shader announces itself by, which is what a material refers to it as.
	/// </summary>
	[GeneratedRegex(@"^\s*Shader\s+""(?<name>[^""]+)""", RegexOptions.Multiline | RegexOptions.CultureInvariant)]
	private static partial Regex ShaderNameRegex { get; }

	/// <summary>
	/// The document header of a yaml asset holding a shader. 48 is the shader class id.
	/// </summary>
	[GeneratedRegex(@"^---\s*!u!48[\s&]", RegexOptions.Multiline | RegexOptions.CultureInvariant)]
	private static partial Regex YamlShaderHeaderRegex { get; }

	/// <summary>
	/// A name in a yaml document, with the indentation that says whose name it is.
	/// </summary>
	[GeneratedRegex(@"^(?<indent>[ ]*)m_Name:[ ]*(?<name>.*)$", RegexOptions.Multiline | RegexOptions.CultureInvariant)]
	private static partial Regex YamlNameRegex { get; }

	private const string MetaExtension = ".meta";
	private const string YamlAssetExtension = ".asset";

	/// <summary>
	/// How the report names the two ways a shader is paired.
	/// </summary>
	public const string ShaderNameKind = "shader name";
	public const string ShaderFileNameKind = "shader file name";

	/// <summary>
	/// The extensions a shader arrives under.
	/// </summary>
	/// <remarks>
	/// A shader graph and a compute shader are here because a package ships them and the export has a
	/// counterpart for each. An include file is not: it is a fragment of a shader rather than one, and
	/// nothing refers to it by guid.
	/// </remarks>
	private static readonly string[] ShaderExtensions = [".shader", ".shadergraph", ".shadersubgraph", ".compute", ".raytrace"];

	/// <summary>
	/// How much of a file is read to find a declaration or a name.
	/// </summary>
	private const int HeadCharacterCount = 8192;

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
		HashSet<string> shaderPaths = MatchShaders(matches, rippedByPath, officialByPath, fileSystem);
		MatchByFileName(matches, rippedByPath, officialByPath, shaderPaths);

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
	/// One shader on either side, with the two things it can be paired by.
	/// </summary>
	/// <param name="DeclaredName">
	/// The name the file announces, or null when the file does not carry one. A shader graph is the
	/// case that does not: it is compiled into a shader rather than being one.
	/// </param>
	private readonly record struct ShaderFile(string Path, string Guid, string? DeclaredName);

	/// <summary>
	/// Pairs the export's shaders with the package's, and says which ripped files were shaders.
	/// </summary>
	/// <remarks>
	/// Two things can pair a shader and they do not agree, so the order matters. The name a shader
	/// declares is what a material asks for and it is the same on both sides whatever either file is
	/// called, so it decides first. The file name is the weaker of the two — a package renames a file
	/// between versions, and the export names the file after the shader rather than after the package's
	/// file — so it only settles what a declared name could not: a shader graph, which declares nothing
	/// of its own, and a shader the export wrote in a form with no declaration to read.
	/// <para>
	/// The returned set is every ripped path recognised as a shader, paired or not. Those belong to this
	/// stage, so <see cref="MatchByFileName"/> leaves them alone: otherwise the weaker rule would pair
	/// what the stronger one deliberately did not, and a shader would be counted in the report as some
	/// other kind of asset.
	/// </para>
	/// </remarks>
	private static HashSet<string> MatchShaders(
		List<ExportMatch> matches,
		Dictionary<string, string> ripped,
		Dictionary<string, string> official,
		FileSystem fileSystem)
	{
		List<ShaderFile> rippedShaders = CollectShaders(ripped, fileSystem);
		HashSet<string> rippedShaderPaths = new(rippedShaders.Select(static shader => shader.Path), StringComparer.OrdinalIgnoreCase);

		List<ShaderFile> officialShaders = CollectShaders(official, LocalFileSystem.Instance);
		if (rippedShaders.Count == 0 || officialShaders.Count == 0)
		{
			return rippedShaderPaths;
		}

		Dictionary<string, string> officialByShaderName = IndexShaders(officialShaders, DeclaredNameKeys, StringComparer.Ordinal);
		Dictionary<string, string> officialByFileName = IndexShaders(officialShaders, FileNameKeys, StringComparer.OrdinalIgnoreCase);
		Dictionary<string, string> rippedByFileName = IndexShaders(rippedShaders, FileNameKeys, StringComparer.OrdinalIgnoreCase);

		foreach (ShaderFile shader in rippedShaders)
		{
			if (shader.DeclaredName is not null && officialByShaderName.TryGetValue(shader.DeclaredName, out string? newGuid))
			{
				matches.Add(new ExportMatch(shader.Path, shader.Guid, newGuid, ShaderNameKind));
				continue;
			}

			foreach (string key in FileNameKeys(shader))
			{
				// The same uniqueness rule the general file name match has, and for the same reason: a
				// name that occurs twice on either side identifies neither of the two.
				if (rippedByFileName.ContainsKey(key) && officialByFileName.TryGetValue(key, out newGuid))
				{
					matches.Add(new ExportMatch(shader.Path, shader.Guid, newGuid, ShaderFileNameKind));
					break;
				}
			}
		}

		return rippedShaderPaths;
	}

	/// <summary>
	/// Every file on one side that is a shader, with the name it declares when it has one.
	/// </summary>
	/// <remarks>
	/// A package ships a shader as source and its extension says so. An export does not always: the yaml
	/// shader exporter writes the shader as a <c>.asset</c>, which nothing but the class id in its
	/// document header distinguishes from any other asset. Reading that header is what makes those
	/// shaders visible to this at all; before it they were left to the file name match, where a
	/// <c>.asset</c> can never pair with a <c>.shader</c>.
	/// </remarks>
	private static List<ShaderFile> CollectShaders(Dictionary<string, string> byPath, FileSystem fileSystem)
	{
		List<ShaderFile> shaders = [];

		foreach ((string path, string guid) in byPath)
		{
			if (HasShaderExtension(path))
			{
				TryReadDeclaredShaderName(path, fileSystem, out string? declared);
				shaders.Add(new ShaderFile(path, guid, declared));
			}
			else if (path.EndsWith(YamlAssetExtension, StringComparison.OrdinalIgnoreCase)
				&& TryReadYamlShader(path, fileSystem, out string? yamlName))
			{
				shaders.Add(new ShaderFile(path, guid, yamlName));
			}
		}

		return shaders;
	}

	/// <summary>
	/// The declared name, as the one key it is, so that a shader without one indexes nothing.
	/// </summary>
	private static List<string> DeclaredNameKeys(ShaderFile shader)
	{
		return shader.DeclaredName is null ? [] : [shader.DeclaredName];
	}

	/// <summary>
	/// The names a shader may be paired by once its declared name has failed to settle it.
	/// </summary>
	/// <remarks>
	/// The file's own name is the first of them, which is the case where both sides kept it. The second
	/// is the last segment of the declared name, for the shader graph: the package ships
	/// <c>Foo.shadergraph</c> and the export writes the shader it compiles into, declared as
	/// <c>Shader Graphs/Foo</c>, so the segment is the only thing the two files have in common.
	/// </remarks>
	private static List<string> FileNameKeys(ShaderFile shader)
	{
		List<string> keys = [GetFileNameWithoutExtension(shader.Path)];

		if (shader.DeclaredName is not null)
		{
			int separator = shader.DeclaredName.LastIndexOf('/');
			string segment = separator < 0 ? shader.DeclaredName : shader.DeclaredName[(separator + 1)..];
			if (segment.Length > 0 && !keys.Contains(segment, StringComparer.OrdinalIgnoreCase))
			{
				keys.Add(segment);
			}
		}

		return keys;
	}

	/// <summary>
	/// Indexes shaders by the keys they offer, dropping every key more than one of them offers.
	/// </summary>
	private static Dictionary<string, string> IndexShaders(List<ShaderFile> shaders, Func<ShaderFile, List<string>> keys, StringComparer comparer)
	{
		Dictionary<string, string> index = new(comparer);
		HashSet<string> duplicates = new(comparer);

		foreach (ShaderFile shader in shaders)
		{
			foreach (string key in keys(shader))
			{
				if (!index.TryAdd(key, shader.Guid))
				{
					duplicates.Add(key);
				}
			}
		}

		foreach (string duplicate in duplicates)
		{
			index.Remove(duplicate);
		}

		return index;
	}

	private static bool HasShaderExtension(string path)
	{
		foreach (string extension in ShaderExtensions)
		{
			if (path.EndsWith(extension, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}

		return false;
	}

	/// <summary>
	/// The name a shader source file announces itself by.
	/// </summary>
	private static bool TryReadDeclaredShaderName(string path, FileSystem fileSystem, out string? name)
	{
		Match match = ShaderNameRegex.Match(ReadHead(path, fileSystem));
		name = match.Success ? match.Groups["name"].Value : null;
		return name is not null;
	}

	/// <summary>
	/// Whether a yaml asset holds a shader, and the name of it when one can be read.
	/// </summary>
	private static bool TryReadYamlShader(string path, FileSystem fileSystem, out string? name)
	{
		name = null;

		string head = ReadHead(path, fileSystem);
		if (!YamlShaderHeaderRegex.IsMatch(head))
		{
			return false;
		}

		// The shallowest name is the shader's own. A deeper one belongs to something inside it, such as
		// a pass or a property, and pairing a shader by the name of one of its passes would repoint
		// every material using it at something unrelated.
		int depth = int.MaxValue;
		foreach (Match match in YamlNameRegex.Matches(head))
		{
			if (match.Groups["indent"].Length < depth)
			{
				depth = match.Groups["indent"].Length;
				name = CleanYamlScalar(match.Groups["name"].Value);
			}
		}

		return true;
	}

	/// <summary>
	/// A yaml scalar as the string it stands for, or null when it stands for nothing.
	/// </summary>
	private static string? CleanYamlScalar(string value)
	{
		string trimmed = value.Trim();

		if (trimmed.Length >= 2 && (trimmed[0] is '"' or '\'') && trimmed[^1] == trimmed[0])
		{
			trimmed = trimmed[1..^1];
		}

		return trimmed.Length > 0 ? trimmed : null;
	}

	/// <summary>
	/// The start of a file, which is where everything read here is.
	/// </summary>
	/// <remarks>
	/// A shader is routinely megabytes of program text and a yaml shader more, while the declaration and
	/// the asset's name are both within the first few lines, so only the start is read.
	/// </remarks>
	private static string ReadHead(string path, FileSystem fileSystem)
	{
		try
		{
			using Stream stream = fileSystem.File.OpenRead(path);
			using StreamReader reader = new(stream);
			char[] buffer = new char[HeadCharacterCount];
			int read = reader.ReadBlock(buffer, 0, HeadCharacterCount);
			return new string(buffer, 0, read);
		}
		catch (IOException)
		{
			return "";
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
	private static void MatchByFileName(
		List<ExportMatch> matches,
		Dictionary<string, string> ripped,
		Dictionary<string, string> official,
		HashSet<string> shaderPaths)
	{
		HashSet<string> alreadyMatched = new(matches.Select(static match => match.RippedPath), StringComparer.OrdinalIgnoreCase);

		Dictionary<string, string> officialByName = IndexByFileName(official, IsMatchableByName);
		Dictionary<string, string> rippedByName = IndexByFileName(ripped, IsMatchableByName);

		foreach ((string path, string oldGuid) in ripped)
		{
			if (alreadyMatched.Contains(path) || shaderPaths.Contains(path) || !IsMatchableByName(path))
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

	private static string GetFileNameWithoutExtension(string path)
	{
		string fileName = GetFileName(path);
		int dot = fileName.LastIndexOf('.');
		return dot <= 0 ? fileName : fileName[..dot];
	}
}
