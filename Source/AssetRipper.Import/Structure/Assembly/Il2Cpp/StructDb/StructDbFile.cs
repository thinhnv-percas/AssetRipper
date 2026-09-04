using System.Text.Json.Serialization;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;

/// <summary>
/// One <c>structdb/&lt;unityVersion&gt;-&lt;x32|x64&gt;.json</c> file: the layout of every C struct in
/// the IL2CPP runtime, for one Unity version and one pointer size.
/// </summary>
/// <remarks>
/// Layouts are read out of Unity's own <c>libil2cpp</c> headers, never guessed. See the
/// schema documentation shipped alongside the data.
/// </remarks>
public sealed class StructDbFile
{
	[JsonPropertyName("schema")]
	public int Schema { get; set; }

	[JsonPropertyName("unityVersion")]
	public string UnityVersion { get; set; } = "";

	/// <summary>4 for a 32-bit layout, 8 for 64-bit.</summary>
	[JsonPropertyName("pointerSize")]
	public int PointerSize { get; set; }

	/// <summary>The global-metadata version this Unity release emits. Only present on newer files.</summary>
	[JsonPropertyName("metadataVersion")]
	public int? MetadataVersion { get; set; }

	[JsonPropertyName("source")]
	public StructDbSource? Source { get; set; }

	[JsonPropertyName("structs")]
	public Dictionary<string, StructDbStruct> Structs { get; set; } = [];

	/// <summary>Enum name to a comma separated list of its members, as written in C.</summary>
	[JsonPropertyName("enums")]
	public Dictionary<string, string> Enums { get; set; } = [];

	[JsonPropertyName("defines")]
	public Dictionary<string, string> Defines { get; set; } = [];

	[JsonPropertyName("typedefs")]
	public Dictionary<string, string> Typedefs { get; set; } = [];
}

public sealed class StructDbSource
{
	[JsonPropertyName("origin")]
	public string? Origin { get; set; }

	/// <summary>The Unity Editor file or archive entry the layout was read from.</summary>
	[JsonPropertyName("file")]
	public string? File { get; set; }

	[JsonPropertyName("tool")]
	public string? Tool { get; set; }

	/// <summary>Compiler target triple, for layouts generated from headers.</summary>
	[JsonPropertyName("target")]
	public string? Target { get; set; }

	[JsonPropertyName("note")]
	public string? Note { get; set; }
}

public sealed class StructDbStruct
{
	/// <summary><c>sizeof</c>, in bytes.</summary>
	[JsonPropertyName("size")]
	public int Size { get; set; }

	/// <summary>Explicit packing, when the struct declares one. 0 means default.</summary>
	[JsonPropertyName("pack")]
	public int Pack { get; set; }

	/// <summary>True when the whole declaration is a union.</summary>
	[JsonPropertyName("union")]
	public bool Union { get; set; }

	[JsonPropertyName("fields")]
	public List<StructDbField> Fields { get; set; } = [];
}

public sealed class StructDbField
{
	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	/// <summary>The C type as declared, for example <c>Il2CppClass*</c> or <c>uint8_t</c>.</summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = "";

	/// <summary><see cref="Type"/> with typedefs resolved. Only written when it differs.</summary>
	[JsonPropertyName("realType")]
	public string? RealType { get; set; }

	/// <summary>Byte offset from the start of the containing struct.</summary>
	[JsonPropertyName("offset")]
	public int Offset { get; set; }

	/// <summary>Width in bytes. Zero for a bitfield, which uses <see cref="Bits"/> instead.</summary>
	[JsonPropertyName("size")]
	public int Size { get; set; }

	/// <summary>Width in bits. Non-null only for a bitfield.</summary>
	[JsonPropertyName("bits")]
	public int? Bits { get; set; }

	/// <summary>Bit position within the storage unit at <see cref="Offset"/>. Use this, not <see cref="BitOrdinal"/>.</summary>
	[JsonPropertyName("bitOffset")]
	public int? BitOffset { get; set; }

	/// <summary>
	/// Declaration index of the bitfield in the source tool's model. Retained for provenance only:
	/// it is an ordinal, not a bit position, and the two disagree whenever a bitfield is wider than one bit.
	/// </summary>
	[JsonPropertyName("bitOrdinal")]
	public int? BitOrdinal { get; set; }

	/// <summary><c>sizeof</c> of the pointee, for a pointer or array field. Lets a resolver step through a pointer without a second lookup.</summary>
	[JsonPropertyName("arrayItemSize")]
	public int ArrayItemSize { get; set; }

	/// <summary>True when this member overlaps its neighbours.</summary>
	[JsonPropertyName("union")]
	public bool Union { get; set; }

	[JsonIgnore]
	public bool IsBitField => Bits.HasValue;

	/// <summary>Width in bytes, derived for bitfields from their bit width.</summary>
	[JsonIgnore]
	public int SizeInBytes => Bits.HasValue ? Math.Max(1, (Bits.Value + 7) / 8) : Size;
}
