using System.Text.Json.Serialization;

namespace AssetRipper.Il2CppRestore.StructDb;

/// <summary>
/// One field of a native IL2CPP runtime struct (<c>Il2CppObject</c>, <c>Il2CppString</c>, …), as
/// measured by clang for a specific Unity version and target triple (guide §10.1).
/// </summary>
public sealed class StructField
{
	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	/// <summary>The type with any typedef resolved away (e.g. <c>int32_t</c> rather than <c>TypeIndex</c>).</summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = "";

	/// <summary>The original spelling, present only when it differs from <see cref="Type"/> (an aliased scalar typedef).</summary>
	[JsonPropertyName("realType")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? RealType { get; set; }

	[JsonPropertyName("offset")]
	public int Offset { get; set; }

	/// <summary>Absent for a bitfield (<see cref="Bits"/> set instead) — a bitfield has no byte size of its own.</summary>
	[JsonPropertyName("size")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public int Size { get; set; }

	/// <summary>Bit width, for a bitfield member. 0 (and omitted) for an ordinary field.</summary>
	[JsonPropertyName("bits")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public int Bits { get; set; }

	/// <summary>
	/// The bitfield's real position within the storage unit at <see cref="Offset"/> — NOT clang's own
	/// per-line bit-start, which is relative to whichever byte clang happened to print for that specific
	/// line. Guide §10.2 trap #6: <c>bitOffset = offsetOfThisLine*8 + bitStartOfThisLine − offset*8</c>,
	/// where <c>offset</c> is the first byte of the whole contiguous bitfield cluster.
	/// </summary>
	[JsonPropertyName("bitOffset")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public int BitOffset { get; set; }

	/// <summary>Declaration order within the bitfield cluster — a trace aid only, never used to place a bit (guide §10.2 trap #6).</summary>
	[JsonPropertyName("bitOrdinal")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public int BitOrdinal { get; set; }

	/// <summary><c>sizeof</c> of the pointed-to/element type, for a pointer or array field.</summary>
	[JsonPropertyName("arrayItemSize")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public int ArrayItemSize { get; set; }

	/// <summary>True when this field shares its <see cref="Offset"/> with at least one sibling — a member of an anonymous or named union nested in the struct.</summary>
	[JsonPropertyName("union")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool Union { get; set; }

	public bool IsBitfield => Bits > 0;
}

public sealed class StructInfo
{
	[JsonIgnore]
	public string Name { get; set; } = "";

	[JsonPropertyName("size")]
	public int Size { get; set; }

	[JsonPropertyName("align")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public int Align { get; set; }

	/// <summary>True for a struct dumped as a C <c>union</c> rather than a <c>struct</c>/<c>class</c> — the whole record, not one field of it (see <see cref="StructField.Union"/> for that).</summary>
	[JsonPropertyName("union")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool Union { get; set; }

	[JsonPropertyName("fields")]
	public List<StructField> Fields { get; set; } = [];
}

/// <summary>Where a generated struct DB file came from — enough to reproduce it.</summary>
public sealed class StructDbSource
{
	[JsonPropertyName("origin")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public string? Origin { get; set; }

	[JsonPropertyName("target")]
	public string Target { get; set; } = "";

	[JsonPropertyName("tool")]
	public string Tool { get; set; } = "";

	[JsonPropertyName("generatedUtc")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public string? GeneratedUtc { get; set; }

	[JsonPropertyName("note")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public string? Note { get; set; }
}

/// <summary>
/// The on-disk JSON shape (guide §10.1). Deliberately plain JSON with no compression or encoding, so
/// <c>git diff</c> between two Unity versions' struct DBs is readable and is itself the changelog for
/// what changed in the runtime (guide §13.1 found two real layout changes exactly this way).
/// </summary>
public sealed class StructDbFile
{
	[JsonPropertyName("schema")]
	public int Schema { get; set; } = 1;

	[JsonPropertyName("unityVersion")]
	public string UnityVersion { get; set; } = "";

	[JsonPropertyName("pointerSize")]
	public int PointerSize { get; set; } = 8;

	[JsonPropertyName("metadataVersion")]
	public int MetadataVersion { get; set; }

	[JsonPropertyName("source")]
	public StructDbSource Source { get; set; } = new();

	[JsonPropertyName("structs")]
	public Dictionary<string, StructInfo> Structs { get; set; } = [];

	/// <summary>Name -&gt; comma-joined <c>NAME=value</c> pairs, straight out of an <c>-ast-dump</c> <c>EnumDecl</c>.</summary>
	[JsonPropertyName("enums")]
	public Dictionary<string, string> Enums { get; set; } = [];

	/// <summary>Macro name -&gt; raw replacement text, from a <c>-dM -E</c> pass.</summary>
	[JsonPropertyName("defines")]
	public Dictionary<string, string> Defines { get; set; } = [];

	/// <summary>Name -&gt; the literal <c>typedef ...;</c> text needed to reproduce it in a rebuilt header.</summary>
	[JsonPropertyName("typedefs")]
	public Dictionary<string, string> Typedefs { get; set; } = [];
}
