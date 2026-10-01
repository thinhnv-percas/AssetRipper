using AsmResolver.PE.DotNet.Metadata.Tables;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>Whether Unity's serializer reads and writes a field.</summary>
public enum FieldSerialization
{
	/// <summary>Part of the serialized layout: a public instance field, or one marked <c>[SerializeField]</c>.</summary>
	Serialized,

	/// <summary>Excluded by the field itself: <c>[NonSerialized]</c>, static, const or readonly.</summary>
	NonSerialized,

	/// <summary>Not public and not <c>[SerializeField]</c>: exists only at run time.</summary>
	RuntimeOnly,
}

/// <summary>Why a field is visible where it is.</summary>
public enum FieldVisibilityOrigin
{
	/// <summary>The source declared it at this accessibility.</summary>
	SourceVisible,

	/// <summary>This export widened it, because a recovered body reaches it from outside its declared scope.</summary>
	GeneratedVisible,
}

/// <summary>The facts about a field that decide whether Unity serializes it, independent of its accessibility.</summary>
public readonly record struct SerializedFieldFacts(
	bool IsStatic,
	bool IsLiteral,
	bool IsInitOnly,
	bool HasSerializeField,
	bool HasNonSerialized,
	bool IsCompilerGenerated);

/// <summary>What widening one field does, and the attribute that keeps its serialization unchanged.</summary>
public readonly record struct SerializedFieldDecision(
	FieldAttributes Access,
	bool AddNotSerialized,
	FieldSerialization Before,
	FieldSerialization After,
	FieldVisibilityOrigin Origin);

/// <summary>
/// AssetRipper: iteration 064. The one rule every field widening goes through: widening changes who can
/// name a field and never whether Unity serializes it.
/// </summary>
/// <remarks>
/// <para>
/// Iteration 063 found the defect this exists for. A recovered body reaches a private field from outside
/// its type, the export widens it to public so the body compiles, and Unity - which serializes a public
/// instance field without being asked - adds it to the type's serialized layout. Every serialized object of
/// that type is then read against a layout its data was not written with: 81 MonoBehaviours failed to read
/// and every UI Image lost its sprite. The fix was a line in <c>WidenField</c>; this is that line made a
/// decision that can be stated, tested and reported.
/// </para>
/// <para>
/// Unity's rule, as it bears on accessibility: an instance field is serialized when it is public or carries
/// <c>[SerializeField]</c>, and not when it is static, const, readonly or <c>[NonSerialized]</c>. Whether the
/// field's <em>type</em> is serializable does not depend on accessibility, so it is the same before and after
/// and is left out; marking a field Unity would not have serialized anyway costs nothing.
/// </para>
/// </remarks>
public static class SerializedFieldPolicy
{
	/// <summary>Whether Unity serializes a field with these facts at <paramref name="access"/>.</summary>
	public static FieldSerialization SerializationAt(FieldAttributes access, SerializedFieldFacts facts)
	{
		if (facts.IsStatic || facts.IsLiteral || facts.IsInitOnly || facts.HasNonSerialized)
		{
			return FieldSerialization.NonSerialized;
		}

		return (access & FieldAttributes.FieldAccessMask) == FieldAttributes.Public || facts.HasSerializeField
			? FieldSerialization.Serialized
			: FieldSerialization.RuntimeOnly;
	}

	/// <summary>
	/// The decision for widening a field from <paramref name="current"/> to <paramref name="wanted"/>.
	/// </summary>
	/// <remarks>
	/// <c>AddNotSerialized</c> is set exactly when the widening would make Unity start serializing a field it
	/// did not, so <c>After</c> always equals <c>Before</c> once the attribute is applied. A field already
	/// serialized stays serialized: widening a <c>[SerializeField] private</c> field to public changes
	/// nothing about its layout and must not hide it.
	/// </remarks>
	public static SerializedFieldDecision Decide(FieldAttributes current, FieldAttributes wanted, SerializedFieldFacts facts)
	{
		FieldSerialization before = SerializationAt(current, facts);
		FieldSerialization widened = SerializationAt(wanted, facts);
		bool addNotSerialized = before != FieldSerialization.Serialized && widened == FieldSerialization.Serialized;
		FieldSerialization after = addNotSerialized
			? SerializationAt(wanted, facts with { HasNonSerialized = true })
			: widened;

		return new SerializedFieldDecision(
			wanted & FieldAttributes.FieldAccessMask,
			addNotSerialized,
			before,
			after,
			(wanted & FieldAttributes.FieldAccessMask) == (current & FieldAttributes.FieldAccessMask)
				? FieldVisibilityOrigin.SourceVisible
				: FieldVisibilityOrigin.GeneratedVisible);
	}

	/// <summary>
	/// The serialized layout of a set of fields: the names Unity reads, in declaration order. Two layouts
	/// that differ are two different on-disk formats.
	/// </summary>
	public static IReadOnlyList<string> Fingerprint(IEnumerable<(string Name, FieldAttributes Access, SerializedFieldFacts Facts)> fields)
		=> fields.Where(field => SerializationAt(field.Access, field.Facts) == FieldSerialization.Serialized)
			.Select(field => field.Name)
			.ToList();
}
