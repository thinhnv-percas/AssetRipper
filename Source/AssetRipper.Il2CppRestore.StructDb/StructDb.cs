using System.Text.Json;

namespace AssetRipper.Il2CppRestore.StructDb;

/// <summary>
/// Runtime lookups against a loaded struct DB: given a native struct name and a byte offset, name the
/// field there — recursing into nested structs so an offset inside <c>Il2CppString.object</c> resolves
/// all the way down to <c>object.klass</c> rather than stopping at the outer field.
/// </summary>
public sealed class StructDb
{
	private static readonly JsonSerializerOptions SerializerOptions = new() { WriteIndented = true };

	private readonly Dictionary<string, StructInfo> _structs;

	public StructDbFile File { get; }

	private StructDb(StructDbFile file)
	{
		File = file;
		_structs = new Dictionary<string, StructInfo>(StringComparer.Ordinal);
		foreach ((string name, StructInfo info) in file.Structs)
		{
			info.Name = name;
			_structs[Normalize(name)] = info;
		}
	}

	/// <summary>
	/// "Il2CppString", 16 -&gt; "length". "Il2CppString", 0 -&gt; "object.klass" (recurses into the nested
	/// <c>Il2CppObject</c> header every managed reference type embeds at offset 0).
	/// </summary>
	/// <remarks>
	/// Two schema details this leans on: a union's members (<see cref="StructField.Union"/>) share one
	/// <see cref="StructField.Offset"/>, and fields are matched in declaration order, so the first one
	/// listed wins — a reasonable default when the actual accessed member can't be told apart from the
	/// offset alone. A bitfield (<see cref="StructField.IsBitfield"/>) has no byte <see cref="StructField.Size"/>
	/// of its own, so it can never match this byte-range check and a load of its whole storage unit comes
	/// back unresolved rather than naming one arbitrary bit out of several packed into the same word —
	/// resolving an individual bitfield needs recognizing the AND/shift around the load, which nothing
	/// here attempts yet.
	/// </remarks>
	public bool TryResolveField(string structName, long offset, out string path)
	{
		path = "";
		if (!_structs.TryGetValue(Normalize(structName), out StructInfo? info))
		{
			return false;
		}
		if (offset < 0 || offset >= info.Size)
		{
			return false;
		}

		foreach (StructField field in info.Fields)
		{
			if (offset < field.Offset || offset >= field.Offset + field.Size)
			{
				continue;
			}

			long inner = offset - field.Offset;
			if (inner == 0 || !_structs.ContainsKey(Normalize(field.Type)))
			{
				path = field.Name;
				return true;
			}

			if (TryResolveField(field.Type, inner, out string? sub))
			{
				path = $"{field.Name}.{sub}";
				return true;
			}

			path = field.Name;
			return true;
		}

		return false;
	}

	private static string Normalize(string type) => type.Replace("const ", "").Replace("struct ", "").TrimEnd('*', ' ');

	public static StructDb Load(string path)
	{
		StructDbFile file = JsonSerializer.Deserialize<StructDbFile>(System.IO.File.ReadAllText(path))
			?? throw new InvalidDataException($"Struct DB at {path} is empty or malformed.");
		return new StructDb(file);
	}

	public void Save(string path)
	{
		System.IO.File.WriteAllText(path, JsonSerializer.Serialize(File, SerializerOptions));
	}

	/// <summary>
	/// Loads the exact (version, architecture) DB when one exists, otherwise the closest available one
	/// with a loud warning — silently falling back to the wrong version's field offsets, the way DevX
	/// does, is exactly the kind of failure that looks like success until opened in Unity.
	/// </summary>
	public static StructDb LoadNearest(string directory, string unityVersion, bool is32Bit)
	{
		string exactPath = Path.Combine(directory, $"{unityVersion}-{(is32Bit ? "x32" : "x64")}.json");
		if (System.IO.File.Exists(exactPath))
		{
			return Load(exactPath);
		}

		UnityVersionKey? target = UnityVersionKey.Parse(unityVersion);
		if (target is null || !Directory.Exists(directory))
		{
			throw new FileNotFoundException($"No struct DB found for {unityVersion} in {directory}, and its version string could not be parsed to look for the nearest one.");
		}

		(string Path, UnityVersionKey? Version) best = Directory.EnumerateFiles(directory, "*.json")
			.Select(p => (Path: p, Version: UnityVersionKey.ParseFromFileName(p)))
			.Where(x => x.Version is not null)
			.OrderBy(x => x.Version!.DistanceTo(target))
			.FirstOrDefault();

		if (best.Path is null)
		{
			throw new FileNotFoundException($"No struct DB files found in {directory}.");
		}

		Console.Error.WriteLine(
			$"WARNING: no struct DB for {unityVersion}; using {Path.GetFileName(best.Path)} instead. " +
			"Field offsets may be wrong if the runtime layout changed between these Unity versions.");
		return Load(best.Path);
	}
}
