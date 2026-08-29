using System.Text;

namespace AssetRipper.Il2CppRestore.Metadata;

/// <summary>
/// Everything read out of <c>global-metadata.dat</c> alone, with no binary. This is what makes the
/// "fields only" mode from the integration guide's startup checklist possible: type names, namespaces,
/// member lists, and simple field/parameter/return types (anything expressible as "the same type as
/// TypeDefinition #N") all come from here.
/// </summary>
/// <remarks>
/// What does NOT come from here: full <c>Il2CppType</c> decoding for generics, arrays, pointers, and
/// primitives. Those entries live in <c>Il2CppMetadataRegistration.types[]</c>, which is part of the
/// game binary, not the metadata file — see the integration guide §6 and §11.2. <see cref="Types"/> is
/// left as an extension point the binary-reading layer fills in once it has found that table; when it
/// hasn't (metadata-only mode), <see cref="ResolveType"/> falls back to <see cref="TypeDefIndexByTypeIndex"/>,
/// which only covers "this typeIndex denotes exactly TypeDefinition #N" — the common case for a plain
/// class or struct field, not generics/arrays/primitives.
/// </remarks>
public sealed class Il2CppMetadata
{
	public required MetadataHeader Header { get; init; }
	public required Il2CppTypeDefinition[] TypeDefs { get; init; }
	public required Il2CppMethodDefinition[] Methods { get; init; }
	public required Il2CppFieldDefinition[] Fields { get; init; }
	public required Il2CppParameterDefinition[] Parameters { get; init; }
	public required Il2CppImageDefinition[] Images { get; init; }
	public required Il2CppAssemblyDefinition[] Assemblies { get; init; }
	public required Il2CppStringLiteral[] StringLiterals { get; init; }
	public required Il2CppDefaultValue[] FieldDefaultValues { get; init; }
	public required Il2CppDefaultValue[] ParameterDefaultValues { get; init; }
	public required int[] InterfaceIndices { get; init; }
	public required int[] NestedTypeIndices { get; init; }

	private readonly byte[] _strings;
	private readonly byte[] _stringLiteralData;
	private readonly byte[] _fieldAndParameterDefaultValueData;

	/// <summary>
	/// <c>typeIndex -&gt; typeDefIndex</c>, for the common case where a typeIndex denotes "an instance of
	/// exactly this class/struct" — built from every <see cref="Il2CppTypeDefinition.byvalTypeIndex"/>,
	/// which is the metadata file's own record of that same mapping. Available without any binary.
	/// </summary>
	public IReadOnlyDictionary<int, int> TypeDefIndexByTypeIndex { get; }

	/// <summary>
	/// The full <c>Il2CppType</c> table, keyed by typeIndex. Null until the binary-reading layer supplies
	/// it (see the guide §6/§11); metadata-only ("fields only") mode never sets this.
	/// </summary>
	public IReadOnlyList<Il2CppType>? Types { get; set; }

	private Il2CppMetadata(byte[] strings, byte[] stringLiteralData, byte[] fieldAndParameterDefaultValueData)
	{
		_strings = strings;
		_stringLiteralData = stringLiteralData;
		_fieldAndParameterDefaultValueData = fieldAndParameterDefaultValueData;
		TypeDefIndexByTypeIndex = BuildTypeDefIndexByTypeIndex();
	}

	private Dictionary<int, int> BuildTypeDefIndexByTypeIndex()
	{
		// Assigned in the object initializer that follows the constructor in Load(), so TypeDefs is not
		// available yet here — see the second pass in Load() that actually populates this dictionary.
		return [];
	}

	public static Il2CppMetadata Load(Stream stream)
	{
		using VersionedReader reader = new(stream);
		MetadataHeader header = MetadataHeader.Read(reader);

		Il2CppTypeDefinition[] typeDefs = reader.ReadStructArray<Il2CppTypeDefinition>(header.TypeDefinitions.Offset, header.TypeDefinitions.Size);
		Il2CppMethodDefinition[] methods = reader.ReadStructArray<Il2CppMethodDefinition>(header.Methods.Offset, header.Methods.Size);
		Il2CppFieldDefinition[] fields = reader.ReadStructArray<Il2CppFieldDefinition>(header.Fields.Offset, header.Fields.Size);
		Il2CppParameterDefinition[] parameters = reader.ReadStructArray<Il2CppParameterDefinition>(header.Parameters.Offset, header.Parameters.Size);
		Il2CppImageDefinition[] images = reader.ReadStructArray<Il2CppImageDefinition>(header.Images.Offset, header.Images.Size);
		Il2CppAssemblyDefinition[] assemblies = reader.ReadStructArray<Il2CppAssemblyDefinition>(header.Assemblies.Offset, header.Assemblies.Size);
		Il2CppStringLiteral[] stringLiterals = reader.ReadStructArray<Il2CppStringLiteral>(header.StringLiterals.Offset, header.StringLiterals.Size);
		Il2CppDefaultValue[] fieldDefaults = reader.ReadStructArray<Il2CppDefaultValue>(header.FieldDefaultValues.Offset, header.FieldDefaultValues.Size);
		Il2CppDefaultValue[] parameterDefaults = reader.ReadStructArray<Il2CppDefaultValue>(header.ParameterDefaultValues.Offset, header.ParameterDefaultValues.Size);

		int[] interfaceIndices = ReadInt32Array(reader, header.Interfaces);
		int[] nestedTypeIndices = ReadInt32Array(reader, header.NestedTypes);

		byte[] strings = ReadBytes(reader, header.Strings);
		byte[] stringLiteralData = ReadBytes(reader, header.StringLiteralData);
		byte[] defaultValueData = ReadBytes(reader, header.FieldAndParameterDefaultValueData);

		Il2CppMetadata metadata = new(strings, stringLiteralData, defaultValueData)
		{
			Header = header,
			TypeDefs = typeDefs,
			Methods = methods,
			Fields = fields,
			Parameters = parameters,
			Images = images,
			Assemblies = assemblies,
			StringLiterals = stringLiterals,
			FieldDefaultValues = fieldDefaults,
			ParameterDefaultValues = parameterDefaults,
			InterfaceIndices = interfaceIndices,
			NestedTypeIndices = nestedTypeIndices,
		};

		Dictionary<int, int> reverse = (Dictionary<int, int>)metadata.TypeDefIndexByTypeIndex;
		for (int i = 0; i < typeDefs.Length; i++)
		{
			// byvalTypeIndex is -1 for the small number of definitions IL2CPP never boxes on their own
			// (some compiler-generated types); nothing meaningful to map for those.
			if (typeDefs[i].byvalTypeIndex >= 0)
			{
				reverse[typeDefs[i].byvalTypeIndex] = i;
			}
		}

		return metadata;
	}

	private static byte[] ReadBytes(VersionedReader reader, Section section)
	{
		if (section.Size <= 0)
		{
			return [];
		}
		reader.Position = section.Offset;
		return reader.ReadBytes(section.Size);
	}

	private static int[] ReadInt32Array(VersionedReader reader, Section section)
	{
		if (section.Size <= 0)
		{
			return [];
		}
		reader.Position = section.Offset;
		int[] result = new int[section.Size / sizeof(int)];
		for (int i = 0; i < result.Length; i++)
		{
			result[i] = reader.ReadInt32();
		}
		return result;
	}

	/// <summary>
	/// A null-terminated UTF-8 string starting at <paramref name="index"/> into the metadata's string
	/// blob — every <c>*nameIndex</c>/<c>*namespaceIndex</c> field is one of these.
	/// </summary>
	public string GetString(int index)
	{
		if (index < 0 || index >= _strings.Length)
		{
			return "";
		}
		int end = Array.IndexOf(_strings, (byte)0, index);
		if (end < 0)
		{
			end = _strings.Length;
		}
		return Encoding.UTF8.GetString(_strings, index, end - index);
	}

	/// <summary>The real string a <see cref="Il2CppStringLiteral"/> slot decodes to — for string constants baked into IL, not names.</summary>
	/// <remarks>
	/// From metadata v39 on, <see cref="Il2CppStringLiteral.length"/> no longer exists (guide §13.1) —
	/// a literal's length is instead however many bytes separate its <c>dataIndex</c> from the next
	/// literal's (or the end of the data blob, for the last one). Literals are written back-to-back with
	/// no gaps, which is what makes this safe.
	/// </remarks>
	public string GetStringLiteral(uint index)
	{
		if (index >= StringLiterals.Length)
		{
			return "";
		}
		Il2CppStringLiteral literal = StringLiterals[index];
		int length = Header.Version <= 31
			? literal.length
			: (int)(index + 1 < StringLiterals.Length ? StringLiterals[index + 1].dataIndex : _stringLiteralData.Length) - literal.dataIndex;

		if (literal.dataIndex < 0 || length < 0 || literal.dataIndex + length > _stringLiteralData.Length)
		{
			return "";
		}
		return Encoding.UTF8.GetString(_stringLiteralData, literal.dataIndex, length);
	}

	public string GetTypeDefName(int typeDefIndex, bool includeNamespace = true)
	{
		if ((uint)typeDefIndex >= TypeDefs.Length)
		{
			return $"<type#{typeDefIndex}>";
		}
		Il2CppTypeDefinition td = TypeDefs[typeDefIndex];
		string name = GetString(td.nameIndex);
		if (!includeNamespace)
		{
			return name;
		}
		string ns = GetString(td.namespaceIndex);
		return ns.Length == 0 ? name : $"{ns}.{name}";
	}

	/// <summary>The type name a <c>TypeInfo</c>-kind metadata usage slot resolves to (guide §11.2).</summary>
	public string GetTypeName(uint typeDefIndex) => GetTypeDefName((int)typeDefIndex);

	/// <summary>The method name (declaring type included) a <c>MethodDef</c>-kind metadata usage slot resolves to.</summary>
	public string GetMethodName(uint methodIndex)
	{
		if (methodIndex >= Methods.Length)
		{
			return $"<method#{methodIndex}>";
		}
		Il2CppMethodDefinition method = Methods[methodIndex];
		string name = GetString(method.nameIndex);
		string declaringType = TypeDefIndexByTypeIndex.TryGetValue(method.declaringType, out int typeDefIndex)
			? GetTypeDefName(typeDefIndex)
			: "?";
		return $"{declaringType}.{name}";
	}

	public int GetTypeDefIndexFromTypeIndex(int typeIndex) =>
		TypeDefIndexByTypeIndex.TryGetValue(typeIndex, out int typeDefIndex) ? typeDefIndex : -1;

	/// <summary>
	/// The <see cref="Il2CppType"/> a typeIndex denotes, falling back to a generic <c>object</c> when
	/// the true types table (<see cref="Types"/>) is not available — see the type-level remarks.
	/// </summary>
	public Il2CppType ResolveType(int typeIndex)
	{
		if (Types is { } types && (uint)typeIndex < types.Count)
		{
			return types[typeIndex];
		}
		if (TypeDefIndexByTypeIndex.TryGetValue(typeIndex, out int typeDefIndex))
		{
			bool isValueType = (uint)typeDefIndex < TypeDefs.Length && TypeDefs[typeDefIndex].IsValueType;
			return new Il2CppType { datapoint = typeDefIndex, type = isValueType ? Il2CppTypeEnum.ValueType : Il2CppTypeEnum.Class };
		}
		return new Il2CppType { type = Il2CppTypeEnum.Object };
	}

	/// <summary>
	/// Decodes a field or parameter's default value from the shared default-value data blob.
	/// </summary>
	/// <remarks>
	/// Handles the primitive constant kinds IL2CPP actually emits defaults for (booleans, integers,
	/// floats, strings, and null references). A <c>dataIndex</c> of -1 means "no default value", which
	/// is the overwhelming majority of fields — this returns false for those without it being an error.
	/// </remarks>
	public bool TryGetFieldDefaultValue(int fieldIndex, out object? value)
	{
		return TryGetDefaultValue(FieldDefaultValues, fieldIndex, out value);
	}

	public bool TryGetParameterDefaultValue(int parameterIndex, out object? value)
	{
		return TryGetDefaultValue(ParameterDefaultValues, parameterIndex, out value);
	}

	private bool TryGetDefaultValue(Il2CppDefaultValue[] table, int memberIndex, out object? value)
	{
		foreach (Il2CppDefaultValue entry in table)
		{
			if (entry.fieldOrParameterIndex != memberIndex)
			{
				continue;
			}
			if (entry.dataIndex < 0)
			{
				value = null;
				return false;
			}

			Il2CppType type = ResolveType(entry.typeIndex);
			value = DecodeDefaultValue(type.type, entry.dataIndex);
			return true;
		}

		value = null;
		return false;
	}

	private object? DecodeDefaultValue(Il2CppTypeEnum type, int dataIndex)
	{
		byte[] data = _fieldAndParameterDefaultValueData;
		if (dataIndex < 0 || dataIndex >= data.Length)
		{
			return null;
		}

		return type switch
		{
			Il2CppTypeEnum.Boolean => data[dataIndex] != 0,
			Il2CppTypeEnum.I1 => unchecked((sbyte)data[dataIndex]),
			Il2CppTypeEnum.U1 => data[dataIndex],
			Il2CppTypeEnum.Char => BitConverter.ToChar(data, dataIndex),
			Il2CppTypeEnum.I2 => BitConverter.ToInt16(data, dataIndex),
			Il2CppTypeEnum.U2 => BitConverter.ToUInt16(data, dataIndex),
			Il2CppTypeEnum.I4 or Il2CppTypeEnum.I => BitConverter.ToInt32(data, dataIndex),
			Il2CppTypeEnum.U4 or Il2CppTypeEnum.U => BitConverter.ToUInt32(data, dataIndex),
			Il2CppTypeEnum.I8 => BitConverter.ToInt64(data, dataIndex),
			Il2CppTypeEnum.U8 => BitConverter.ToUInt64(data, dataIndex),
			Il2CppTypeEnum.R4 => BitConverter.ToSingle(data, dataIndex),
			Il2CppTypeEnum.R8 => BitConverter.ToDouble(data, dataIndex),
			// A string default is length-prefixed (int32) UTF-8 in the same data blob.
			Il2CppTypeEnum.String => DecodeStringDefault(data, dataIndex),
			_ => null,
		};
	}

	private static string? DecodeStringDefault(byte[] data, int dataIndex)
	{
		if (dataIndex + 4 > data.Length)
		{
			return null;
		}
		int length = BitConverter.ToInt32(data, dataIndex);
		if (length < 0 || dataIndex + 4 + length > data.Length)
		{
			return null;
		}
		return Encoding.UTF8.GetString(data, dataIndex + 4, length);
	}

	/// <summary>
	/// One field discovered on a managed type by walking straight down from the metadata, used to give
	/// the lifter (guide §11.2) something to name an offset after when it is reading a managed object
	/// rather than a native runtime struct the StructDb already knows about.
	/// </summary>
	public readonly record struct ManagedFieldGuess(string Name, string Type, int ApproximateOffset);

	/// <summary>
	/// The size of the fixed <c>Il2CppObject</c> header every managed reference type starts with: a
	/// class pointer and a monitor slot, both pointer-sized. Matches the guide §10.1 struct DB sample.
	/// </summary>
	private const int ManagedObjectHeaderSize = 16;

	private readonly Dictionary<int, List<ManagedFieldGuess>> _managedFieldCache = [];

	/// <summary>
	/// Best-effort only: assumes fields are laid out in declaration order immediately after the object
	/// header, four bytes per reference-sized/int field (eight for 64-bit fields), with no repacking for
	/// inheritance or explicit layout. Real IL2CPP field layout can differ — this exists to make the
	/// lifted pseudocode readable, not to be trusted as ground truth. Prefer <c>StructDb</c> resolution
	/// (native runtime structs) wherever it applies; this is the fallback for managed types it does not
	/// cover.
	/// </summary>
	public bool TryResolveManagedField(int typeDefIndex, int offset, out ManagedFieldGuess field)
	{
		foreach (ManagedFieldGuess candidate in GetManagedFieldLayout(typeDefIndex))
		{
			if (candidate.ApproximateOffset == offset)
			{
				field = candidate;
				return true;
			}
		}
		field = default;
		return false;
	}

	private List<ManagedFieldGuess> GetManagedFieldLayout(int typeDefIndex)
	{
		if (_managedFieldCache.TryGetValue(typeDefIndex, out List<ManagedFieldGuess>? cached))
		{
			return cached;
		}

		List<ManagedFieldGuess> result = [];
		if ((uint)typeDefIndex < TypeDefs.Length)
		{
			Il2CppTypeDefinition td = TypeDefs[typeDefIndex];
			int offset = ManagedObjectHeaderSize;
			for (int i = 0; i < td.field_count; i++)
			{
				Il2CppFieldDefinition fd = Fields[td.fieldStart + i];
				Il2CppType fieldType = ResolveType(fd.typeIndex);
				int size = ApproximateSizeOf(fieldType);
				result.Add(new ManagedFieldGuess(GetString(fd.nameIndex), DescribeType(fieldType), offset));
				offset += size;
			}
		}

		_managedFieldCache[typeDefIndex] = result;
		return result;
	}

	private int ApproximateSizeOf(Il2CppType type) => type.type switch
	{
		Il2CppTypeEnum.Boolean or Il2CppTypeEnum.I1 or Il2CppTypeEnum.U1 => 1,
		Il2CppTypeEnum.Char or Il2CppTypeEnum.I2 or Il2CppTypeEnum.U2 => 2,
		Il2CppTypeEnum.I4 or Il2CppTypeEnum.U4 or Il2CppTypeEnum.R4 => 4,
		Il2CppTypeEnum.I8 or Il2CppTypeEnum.U8 or Il2CppTypeEnum.R8 => 8,
		_ => 8, // reference, pointer, or anything else: assume a 64-bit slot.
	};

	private string DescribeType(Il2CppType type) => type.type switch
	{
		Il2CppTypeEnum.Class or Il2CppTypeEnum.ValueType => GetTypeDefName(type.datapoint),
		Il2CppTypeEnum.Boolean => "bool",
		Il2CppTypeEnum.Char => "char",
		Il2CppTypeEnum.I1 => "sbyte",
		Il2CppTypeEnum.U1 => "byte",
		Il2CppTypeEnum.I2 => "short",
		Il2CppTypeEnum.U2 => "ushort",
		Il2CppTypeEnum.I4 => "int",
		Il2CppTypeEnum.U4 => "uint",
		Il2CppTypeEnum.I8 => "long",
		Il2CppTypeEnum.U8 => "ulong",
		Il2CppTypeEnum.R4 => "float",
		Il2CppTypeEnum.R8 => "double",
		Il2CppTypeEnum.String => "string",
		Il2CppTypeEnum.SzArray => "object[]",
		_ => "object",
	};
}
