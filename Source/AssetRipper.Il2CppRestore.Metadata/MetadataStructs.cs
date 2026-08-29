namespace AssetRipper.Il2CppRestore.Metadata;

/// <summary>
/// One type in a game — a class, struct, interface, or enum. Written by hand from the diff between
/// Unity 2022.3.62f2 (metadata v31) and 6000.3.18f1 (metadata v39): see the guide's §4.2 for exactly
/// which fields moved. Verify against <c>GlobalMetadataFileInternals.h</c> of your own target Unity
/// version before trusting an offset — this is the single most version-sensitive struct in the format.
/// </summary>
public class Il2CppTypeDefinition
{
	public int nameIndex;
	public int namespaceIndex;
	public int byvalTypeIndex;

	// Present through v24.1; gone from v24.2 onward — check your target's header.
	[Version(Max = 24.1)] public int byrefTypeIndex;

	public int declaringTypeIndex;
	public int parentIndex;

	// Present through v31, removed by v39 (confirmed against 2022.3.62f2 vs 6000.3.18f1).
	[Version(Max = 31)] public int elementTypeIndex;

	[Version(Max = 24.1)] public int rgctxStartIndex;
	[Version(Max = 24.1)] public int rgctxCount;

	public int genericContainerIndex;
	public uint flags;

	public int fieldStart;
	public int methodStart;
	public int eventStart;
	public int propertyStart;
	public int nestedTypesStart;
	public int interfacesStart;
	public int vtableStart;
	public int interfaceOffsetsStart;

	public ushort method_count;
	public ushort property_count;
	public ushort field_count;
	public ushort event_count;
	public ushort nested_type_count;
	public ushort vtable_count;
	public ushort interfaces_count;
	public ushort interface_offsets_count;

	public uint bitfield;
	public uint token;

	// Bit layout per Unity's own header comment for Il2CppTypeDefinition.bitfield.
	public bool IsValueType => (bitfield & 1) != 0;
	public bool IsEnumType => (bitfield & 2) != 0;
	public bool HasFinalize => (bitfield & 4) != 0;
	public bool HasCctor => (bitfield & 8) != 0;
	public bool IsBlittable => (bitfield & 16) != 0;
	public bool IsImportOrWindowsRuntime => (bitfield & 32) != 0;
}

/// <summary>
/// A method's metadata: not its code (that lives in the binary, see <c>RegistrationSearch</c>), just
/// what a game's IL/managed side knows about it — name, signature shape, and the token used to look its
/// native address up in a <c>Il2CppCodeGenModule</c>.
/// </summary>
/// <remarks>
/// Field-for-field layout is not given verbatim by any Unity header excerpt in the guide (unlike
/// <see cref="Il2CppTypeDefinition"/>), so this is written from the format's well-documented public
/// shape. Confirm against your target version's <c>il2cpp-class-internals.h</c> before trusting an
/// offset for a version this hasn't been checked against.
/// </remarks>
public class Il2CppMethodDefinition
{
	public int nameIndex;
	public int declaringType;
	public int returnType;
	public int parameterStart;

	[Version(Max = 24.1)] public int customAttributeIndex;

	public int genericContainerIndex;

	// Legacy dispatch index, superseded by token-based lookup from v24.2 onward (see the guide's §7).
	[Version(Max = 24.1)] public int methodIndex;
	[Version(Max = 24.1)] public int invokerIndex;
	[Version(Max = 24.1)] public int delegateWrapperIndex;
	[Version(Max = 24.1)] public int rgctxStartIndex;
	[Version(Max = 24.1)] public int rgctxCount;

	public uint token;
	public ushort flags;
	public ushort iflags;
	public ushort slot;
	public ushort parameterCount;

	public bool IsStatic => (flags & 0x0010) != 0;
	public bool IsAbstract => (flags & 0x0400) != 0;
	public bool IsPInvokeImpl => (iflags & 0x2000) != 0;
}

public class Il2CppFieldDefinition
{
	public int nameIndex;
	public int typeIndex;
	public uint token;
}

public class Il2CppParameterDefinition
{
	public int nameIndex;
	public uint token;
	public int typeIndex;
}

/// <summary>
/// A default value attached to a field or parameter — <c>Il2CppFieldDefaultValue</c> and
/// <c>Il2CppParameterDefaultValue</c> share this exact shape in the real format, so one struct covers
/// both arrays.
/// </summary>
public class Il2CppDefaultValue
{
	public int fieldOrParameterIndex;
	public int typeIndex;
	/// <summary>Offset into the default-value data blob, or -1 for no default value.</summary>
	public int dataIndex;
}

/// <summary>
/// One assembly's worth of types. <c>typeStart</c>/<c>typeCount</c> is what the dummy assembly builder
/// (§9) walks to know which <see cref="Il2CppTypeDefinition"/> entries belong to which output DLL.
/// </summary>
public class Il2CppImageDefinition
{
	public int nameIndex;
	public int assemblyIndex;
	public int typeStart;
	public int typeCount;
	public int exportedTypeStart;
	public int exportedTypeCount;
	public int entryPointIndex;
	public uint token;
	public int customAttributeStart;
	public int customAttributeCount;
}

/// <summary>
/// The two-int32 record every string literal is looked up through: not the string itself, just where
/// to find it. See <see cref="Il2CppMetadata.GetStringLiteral"/>.
/// </summary>
public class Il2CppStringLiteral
{
	public int length;
	public int dataIndex;
}

/// <summary>
/// A type reference as used everywhere a field/parameter/return type is described. This intentionally
/// covers the common cases the pipeline actually needs (primitives, class/valuetype references, generic
/// instances collapsed to their open definition, single-rank SZARRAY) rather than the complete
/// <c>Il2CppTypeEnum</c> union — full generic-argument and multi-dimensional-array reconstruction is
/// call out as a follow-up in the integration notes, not attempted here.
/// </summary>
public enum Il2CppTypeEnum : byte
{
	End = 0x00,
	Void = 0x01,
	Boolean = 0x02,
	Char = 0x03,
	I1 = 0x04,
	U1 = 0x05,
	I2 = 0x06,
	U2 = 0x07,
	I4 = 0x08,
	U4 = 0x09,
	I8 = 0x0a,
	U8 = 0x0b,
	R4 = 0x0c,
	R8 = 0x0d,
	String = 0x0e,
	Ptr = 0x0f,
	ByRef = 0x10,
	ValueType = 0x11,
	Class = 0x12,
	Var = 0x13,
	Array = 0x14,
	GenericInst = 0x15,
	TypedByRef = 0x16,
	I = 0x18,
	U = 0x19,
	FnPtr = 0x1b,
	Object = 0x1c,
	SzArray = 0x1d,
	MVar = 0x1e,
	CModReqD = 0x1f,
	CModOpt = 0x20,
	Internal = 0x21,
	Modifier = 0x22,
	Sentinel = 0x23,
	Pinned = 0x45,
	Enum = 0x55,
}

public sealed class Il2CppType
{
	/// <summary>
	/// Meaning depends on <see cref="Type"/>: a <see cref="Il2CppTypeDefinition"/> index for
	/// Class/ValueType, a generic parameter index for Var/MVar, an element-type index for
	/// Array/SzArray, or unused for primitives.
	/// </summary>
	public int datapoint;
	/// <summary>Field/parameter attribute bits, valid only when this <see cref="Il2CppType"/> describes a field.</summary>
	public ushort attrs;
	public Il2CppTypeEnum type;
	public byte byrefPinned;

	public bool IsByRef => (byrefPinned & 1) != 0;
}
