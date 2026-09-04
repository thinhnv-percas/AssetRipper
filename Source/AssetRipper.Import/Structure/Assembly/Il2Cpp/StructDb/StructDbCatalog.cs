using AssetRipper.Import.Logging;
using AssetRipper.Primitives;
using System.IO.Compression;
using System.Text.Json;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;

/// <summary>
/// Indexes a directory of IL2CPP runtime struct layout files and hands out the best match for a
/// given Unity version and pointer size.
/// </summary>
public sealed class StructDbCatalog
{
	private const string X32Suffix = "-x32";
	private const string X64Suffix = "-x64";

	private readonly string directory;
	private readonly Dictionary<UnityVersion, string> versions = [];

	private StructDbCatalog(string directory)
	{
		this.directory = directory;
	}

	/// <summary>Every Unity version the catalog can serve, ascending.</summary>
	public IEnumerable<UnityVersion> AvailableVersions => versions.Keys.Order();

	public int Count => versions.Count;

	/// <summary>
	/// Index <paramref name="directory"/>. Returns null when the directory does not exist or holds no
	/// usable pair of files: the struct database is optional and a missing one is not an error.
	/// </summary>
	/// <param name="directory">The directory to index.</param>
	/// <param name="log">
	/// False to index without writing to the log, for callers that only want to report coverage and
	/// would otherwise repeat the same line on every render.
	/// </param>
	public static StructDbCatalog? TryCreate(string? directory, bool log = true)
	{
		if (string.IsNullOrEmpty(directory) || !Directory.Exists(directory))
		{
			return null;
		}

		StructDbCatalog catalog = new(directory);

		foreach (string path in Directory.EnumerateFiles(directory))
		{
			string name = StripKnownExtensions(Path.GetFileName(path));
			if (!name.EndsWith(X64Suffix, StringComparison.Ordinal))
			{
				continue;
			}

			string versionText = name[..^X64Suffix.Length];
			if (!UnityVersion.TryParse(versionText, out UnityVersion version, out _))
			{
				continue;
			}

			// Only accept a version that has both widths: a 32-bit game must not silently
			// get 64-bit offsets.
			if (FindFile(directory, versionText, is32Bit: true) is null)
			{
				continue;
			}

			catalog.versions.TryAdd(version, versionText);
		}

		if (catalog.versions.Count == 0)
		{
			return null;
		}

		if (log)
		{
			Logger.Info(LogCategory.Import, $"IL2CPP struct database: {catalog.versions.Count} Unity versions indexed from {directory}");
		}

		return catalog;
	}

	/// <summary>
	/// Load the layout for <paramref name="requested"/>, or the newest layout at or below it.
	/// </summary>
	/// <param name="requested">The game's Unity version.</param>
	/// <param name="is32Bit">True for a 32-bit binary (armeabi-v7a, x86).</param>
	/// <returns>Null when nothing in the catalog can serve the request.</returns>
	public RuntimeStructDb? Load(UnityVersion requested, bool is32Bit)
	{
		if (!TrySelect(requested, out UnityVersion selected, out string? versionText))
		{
			return null;
		}

		string? path = FindFile(directory, versionText, is32Bit);
		if (path is null)
		{
			return null;
		}

		StructDbFile? file;
		try
		{
			using Stream stream = OpenPossiblyCompressed(path);
			file = JsonSerializer.Deserialize(stream, StructDbSerializerContext.Default.StructDbFile);
		}
		catch (Exception ex)
		{
			Logger.Error(LogCategory.Import, $"IL2CPP struct database: failed to read {path}", ex);
			return null;
		}

		if (file is null || file.Structs.Count == 0)
		{
			Logger.Warning(LogCategory.Import, $"IL2CPP struct database: {path} contains no struct layouts");
			return null;
		}

		bool exact = selected == requested;
		if (!exact)
		{
			// Never fall back silently. A wrong layout produces confidently wrong field names,
			// which is worse than no field names at all.
			Logger.Warning(LogCategory.Import,
				$"IL2CPP struct database has no layout for Unity {requested}; using {selected} instead. " +
				"Runtime field names in recovered method bodies may be wrong if the layout changed between these versions.");
		}

		return new RuntimeStructDb(file, selected, exact);
	}

	private bool TrySelect(UnityVersion requested, out UnityVersion selected, out string versionText)
	{
		if (versions.TryGetValue(requested, out string? exact))
		{
			selected = requested;
			versionText = exact;
			return true;
		}

		UnityVersion? bestBelow = null;
		UnityVersion? oldest = null;

		foreach (UnityVersion candidate in versions.Keys)
		{
			if (oldest is null || candidate < oldest.Value)
			{
				oldest = candidate;
			}

			// Layouts only change going forward, so the newest version at or below the request
			// is the safest approximation.
			if (candidate <= requested && (bestBelow is null || candidate > bestBelow.Value))
			{
				bestBelow = candidate;
			}
		}

		UnityVersion? chosen = bestBelow ?? oldest;
		if (chosen is null)
		{
			selected = default;
			versionText = "";
			return false;
		}

		selected = chosen.Value;
		versionText = versions[selected];
		return true;
	}

	private static string? FindFile(string directory, string versionText, bool is32Bit)
	{
		string stem = versionText + (is32Bit ? X32Suffix : X64Suffix);
		foreach (string extension in (string[])[".json", ".json.gz"])
		{
			string path = Path.Join(directory, stem + extension);
			if (File.Exists(path))
			{
				return path;
			}
		}
		return null;
	}

	private static Stream OpenPossiblyCompressed(string path)
	{
		FileStream stream = File.OpenRead(path);

		// Sniff the gzip magic rather than trusting the extension: both layouts are valid on disk.
		int first = stream.ReadByte();
		int second = stream.ReadByte();
		stream.Position = 0;

		return first == 0x1F && second == 0x8B
			? new GZipStream(stream, CompressionMode.Decompress)
			: stream;
	}

	private static string StripKnownExtensions(string fileName)
	{
		if (fileName.EndsWith(".json.gz", StringComparison.OrdinalIgnoreCase))
		{
			return fileName[..^".json.gz".Length];
		}
		if (fileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
		{
			return fileName[..^".json".Length];
		}
		return fileName;
	}
}
