using System.Text.Json.Serialization;

namespace AssetRipper.Il2CppRestore.StructDb;

/// <summary>
/// One field of a native IL2CPP runtime struct (<c>Il2CppObject</c>, <c>Il2CppString</c>, …), as
/// measured by clang for a specific Unity version and target triple.
/// </summary>
public sealed class StructField
{
	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	[JsonPropertyName("type")]
	public string Type { get; set; } = "";

	[JsonPropertyName("offset")]
	public int Offset { get; set; }

	[JsonPropertyName("size")]
	public int Size { get; set; }

	/// <summary>-1 outside a bitfield. When set, <see cref="Offset"/>/<see cref="Size"/> describe the byte the bitfield lives in.</summary>
	[JsonIgnore]
	public int BitStart { get; set; } = -1;

	[JsonIgnore]
	public int BitEnd { get; set; } = -1;
}

public sealed class StructInfo
{
	[JsonIgnore]
	public string Name { get; set; } = "";

	[JsonPropertyName("size")]
	public int Size { get; set; }

	[JsonPropertyName("align")]
	public int Align { get; set; }

	[JsonPropertyName("fields")]
	public List<StructField> Fields { get; set; } = [];
}

/// <summary>
/// The on-disk JSON shape — see the integration guide §10.1. Deliberately plain JSON with no
/// compression or encoding, so <c>git diff</c> between two Unity versions' struct DBs is readable and
/// is itself the changelog for what to update in <c>[Version(...)]</c> attributes elsewhere.
/// </summary>
public sealed class StructDbFile
{
	[JsonPropertyName("schema")]
	public int Schema { get; set; } = 1;

	[JsonPropertyName("unityVersion")]
	public string UnityVersion { get; set; } = "";

	[JsonPropertyName("metadataVersion")]
	public int MetadataVersion { get; set; }

	[JsonPropertyName("target")]
	public string Target { get; set; } = "";

	[JsonPropertyName("pointerSize")]
	public int PointerSize { get; set; } = 8;

	[JsonPropertyName("generatedUtc")]
	public DateTime GeneratedUtc { get; set; }

	[JsonPropertyName("structs")]
	public Dictionary<string, StructInfo> Structs { get; set; } = [];
}
