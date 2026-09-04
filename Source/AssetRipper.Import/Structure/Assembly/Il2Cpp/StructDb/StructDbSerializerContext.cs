using System.Text.Json;
using System.Text.Json.Serialization;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;

/// <summary>
/// Source generated metadata for <see cref="StructDbFile"/>. AssetRipper builds AOT compatible, so
/// reflection based serialisation is not available here.
/// </summary>
[JsonSourceGenerationOptions(
	PropertyNameCaseInsensitive = false,
	ReadCommentHandling = JsonCommentHandling.Skip,
	AllowTrailingCommas = true)]
[JsonSerializable(typeof(StructDbFile))]
[JsonSerializable(typeof(StructDbIndexFile))]
internal sealed partial class StructDbSerializerContext : JsonSerializerContext
{
}

/// <summary><c>structdb/index.json</c>: the coverage list, so callers need not open 740 files to enumerate versions.</summary>
public sealed class StructDbIndexFile
{
	[JsonPropertyName("schema")]
	public int Schema { get; set; }

	[JsonPropertyName("count")]
	public int Count { get; set; }

	[JsonPropertyName("note")]
	public string? Note { get; set; }

	[JsonPropertyName("versions")]
	public List<StructDbIndexEntry> Versions { get; set; } = [];
}

public sealed class StructDbIndexEntry
{
	[JsonPropertyName("unityVersion")]
	public string UnityVersion { get; set; } = "";

	/// <summary>Keys are <c>x32</c> and <c>x64</c>; values are file names relative to the database directory.</summary>
	[JsonPropertyName("files")]
	public Dictionary<string, string> Files { get; set; } = [];

	[JsonPropertyName("structCount")]
	public int StructCount { get; set; }

	/// <summary><c>dvxil2c</c> for a layout recovered from the original tool, <c>clang</c> for one generated from Unity headers.</summary>
	[JsonPropertyName("source")]
	public string? Source { get; set; }
}
