using AssetRipper.Primitives;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;

/// <summary>
/// The IL2CPP runtime struct layout for one Unity version and pointer size, indexed for lookup by offset.
/// </summary>
public sealed class RuntimeStructDb
{
	/// <summary>Guards against a cyclic layout producing unbounded recursion. Real layouts nest three deep at most.</summary>
	private const int MaxNestingDepth = 8;

	private readonly StructDbFile file;
	private readonly Dictionary<string, StructDbStruct> byNormalizedName;

	internal RuntimeStructDb(StructDbFile file, UnityVersion version, bool isExactMatch)
	{
		this.file = file;
		Version = version;
		IsExactMatch = isExactMatch;

		byNormalizedName = new Dictionary<string, StructDbStruct>(file.Structs.Count, StringComparer.Ordinal);
		foreach ((string name, StructDbStruct layout) in file.Structs)
		{
			byNormalizedName[NormalizeTypeName(name)] = layout;
		}
	}

	/// <summary>The version whose layout this actually is, which is not necessarily the version asked for.</summary>
	public UnityVersion Version { get; }

	/// <summary>False when this layout was substituted for a version the database does not cover.</summary>
	public bool IsExactMatch { get; }

	public int PointerSize => file.PointerSize;

	public bool Is32Bit => file.PointerSize == 4;

	public IReadOnlyDictionary<string, string> Enums => file.Enums;

	public bool Contains(string structName) => byNormalizedName.ContainsKey(NormalizeTypeName(structName));

	public bool TryGetStruct(string structName, [NotNullWhen(true)] out StructDbStruct? layout)
		=> byNormalizedName.TryGetValue(NormalizeTypeName(structName), out layout);

	/// <summary><c>sizeof</c> of a struct, or -1 when it is not in this layout.</summary>
	public int GetSize(string structName) => TryGetStruct(structName, out StructDbStruct? layout) ? layout.Size : -1;

	/// <summary>
	/// Resolve a byte offset within a struct to a field path.
	/// </summary>
	/// <example>
	/// <c>TryResolveField("MethodInfo", 0x18, out var access)</c> gives <c>access.Path == "klass"</c>,
	/// and <c>access.PointeeStruct == "Il2CppClass"</c> so the caller can keep resolving through the pointer.
	/// </example>
	/// <param name="structName">A C struct name, with or without <c>struct</c>, <c>const</c> and trailing <c>*</c>.</param>
	/// <param name="offset">Byte offset from the start of the struct.</param>
	/// <param name="access">The resolved field path.</param>
	public bool TryResolveField(string structName, long offset, out RuntimeFieldAccess access)
		=> TryResolveField(structName, offset, 0, out access);

	private bool TryResolveField(string structName, long offset, int depth, out RuntimeFieldAccess access)
	{
		access = default;

		if (depth > MaxNestingDepth || offset < 0)
		{
			return false;
		}

		if (!TryGetStruct(structName, out StructDbStruct? layout))
		{
			return false;
		}

		// sizeof is the bound for everything except a trailing zero-length array, which by definition
		// starts at or past the end of the struct and runs as far as the runtime allocated it.
		if (offset >= layout.Size && TrailingFlexibleArray(layout) is null)
		{
			return false;
		}

		StructDbField? field = SelectField(layout, offset);
		if (field is null)
		{
			return false;
		}

		long inner = offset - field.Offset;

		if (field.IsFlexibleArray)
		{
			return TryResolveArrayElement(field, inner, depth, out access);
		}

		string? pointee = TryGetPointeeStructName(field);

		// Landed on the start of the field, or on something that is not a struct we can descend into.
		if (inner == 0 || field.IsBitField || !Contains(TypeWithoutPointer(field.Type)) || IsPointer(field.Type))
		{
			access = new RuntimeFieldAccess(
				field.Name,
				field.Type,
				pointee,
				field.Bits ?? 0,
				field.BitOffset ?? 0,
				inner);
			return true;
		}

		// Embedded struct: keep going with the remaining offset.
		if (TryResolveField(TypeWithoutPointer(field.Type), inner, depth + 1, out RuntimeFieldAccess nested))
		{
			access = nested with { Path = field.Name + "." + nested.Path };
			return true;
		}

		access = new RuntimeFieldAccess(field.Name, field.Type, pointee, 0, 0, inner);
		return true;
	}

	private static StructDbField? SelectField(StructDbStruct layout, long offset)
	{
		StructDbField? containing = null;

		foreach (StructDbField field in layout.Fields)
		{
			if (field.Offset == offset)
			{
				// Exact hits win over merely containing the offset. In a union several members
				// start here; the first declared is the one the source tool reported, and keeping
				// that makes output comparable against it.
				return field;
			}

			if (containing is null && offset > field.Offset && offset < field.Offset + Math.Max(1, field.SizeInBytes))
			{
				containing = field;
			}
		}

		// A trailing zero-length array has no width to fall inside, so it claims everything past its start.
		return containing ?? (TrailingFlexibleArray(layout) is { } flexible && offset >= flexible.Offset ? flexible : null);
	}

	/// <summary>The struct's trailing zero-length array, or null when it does not end in one.</summary>
	private static StructDbField? TrailingFlexibleArray(StructDbStruct layout)
	{
		// Only the last member can be one, and every layout in the database respects that.
		return layout.Fields.Count > 0 && layout.Fields[^1].IsFlexibleArray ? layout.Fields[^1] : null;
	}

	/// <summary>
	/// Names an offset inside a trailing array as an indexed element, descending into the element type
	/// when it is a struct the database knows.
	/// </summary>
	private bool TryResolveArrayElement(StructDbField field, long inner, int depth, out RuntimeFieldAccess access)
	{
		string element = NormalizeTypeName(field.ElementTypeName);

		// Without an element size there is no index to compute, so the byte remainder is the best answer.
		if (field.ArrayItemSize <= 0)
		{
			access = new RuntimeFieldAccess(field.Name, field.Type, null, 0, 0, inner);
			return true;
		}

		long index = inner / field.ArrayItemSize;
		long withinElement = inner % field.ArrayItemSize;
		string path = $"{field.Name}[{index}]";

		// vtable[2] + 8 reads VirtualInvokeData::method, and that is what the reader wants to see.
		if (!IsPointer(field.ElementTypeName)
			&& TryResolveField(element, withinElement, depth + 1, out RuntimeFieldAccess nested))
		{
			access = nested with { Path = path + "." + nested.Path };
			return true;
		}

		access = new RuntimeFieldAccess(
			path,
			field.ElementTypeName,
			IsPointer(field.ElementTypeName) && Contains(element) ? element : null,
			0,
			0,
			withinElement);
		return true;
	}

	/// <summary>The struct a pointer field points at, or null when the field is not a pointer to a known struct.</summary>
	public string? TryGetPointeeStructName(StructDbField field)
	{
		if (!IsPointer(field.Type))
		{
			return null;
		}

		string pointee = TypeWithoutPointer(field.Type);
		return Contains(pointee) ? NormalizeTypeName(pointee) : null;
	}

	public static bool IsPointer(string type) => type.EndsWith('*');

	/// <summary><c>const Il2CppClass**</c> becomes <c>Il2CppClass</c>.</summary>
	public static string TypeWithoutPointer(string type) => NormalizeTypeName(type);

	/// <summary>Strips C decorations so a type name can be used as a dictionary key.</summary>
	public static string NormalizeTypeName(string type)
	{
		ReadOnlySpan<char> span = type.AsSpan().Trim();

		while (true)
		{
			if (span.StartsWith("const ")) { span = span[6..].TrimStart(); continue; }
			if (span.StartsWith("struct ")) { span = span[7..].TrimStart(); continue; }
			if (span.StartsWith("volatile ")) { span = span[9..].TrimStart(); continue; }
			break;
		}

		span = span.TrimEnd();
		while (span.Length > 0 && (span[^1] == '*' || span[^1] == ' '))
		{
			span = span[..^1];
		}

		return span.ToString();
	}
}

/// <summary>One resolved access into a runtime struct.</summary>
/// <param name="Path">Dotted field path, for example <c>byval_arg.data</c>.</param>
/// <param name="Type">The C type of the field the path ends at.</param>
/// <param name="PointeeStruct">When the field is a pointer to a known struct, that struct's name, so the caller can keep resolving.</param>
/// <param name="Bits">Bit width, or 0 when the field is not a bitfield.</param>
/// <param name="BitOffset">Bit position within the storage unit, meaningful only when <paramref name="Bits"/> is non-zero.</param>
/// <param name="Remainder">Bytes between the start of the resolved field and the requested offset. Non-zero means a partial read.</param>
public readonly record struct RuntimeFieldAccess(
	string Path,
	string Type,
	string? PointeeStruct,
	int Bits,
	int BitOffset,
	long Remainder)
{
	public bool IsBitField => Bits > 0;

	public bool IsPartial => Remainder != 0;

	public override string ToString() => IsPartial ? $"{Path}+0x{Remainder:X}" : Path;
}
