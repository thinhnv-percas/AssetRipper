using Cpp2IL.Core.Model.Contexts;
using LibCpp2IL.BinaryStructures;
using System.Reflection;

namespace AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

/// <summary>
/// Works out where a type's fields sit by running the layout the Il2Cpp runtime itself runs, rather
/// than by reading the offsets the metadata happens to carry.
/// </summary>
/// <remarks>
/// The runtime does not store a layout for every type. A generic instance has none at all: it inflates
/// its definition's fields with the type arguments and lays them out on the spot. Reproducing that
/// calculation is therefore the only way to describe such a type, and it is worth reproducing exactly,
/// because a layout that is merely plausible is the one thing that must not be handed to a decompiler.
/// <para>
/// Exactness is checkable. Every non generic type does have a stored size and stored offsets, and the
/// runtime computes those as well and asserts they agree, so the same comparison run over a whole game
/// says whether this implementation is faithful before anything relies on it.
/// </para>
/// </remarks>
public sealed class Il2CppFieldLayout
{
	/// <summary>
	/// How much space a type takes as a field, and what it has to be aligned to.
	/// </summary>
	public readonly record struct SizeAndAlignment(int Size, int Alignment);

	/// <summary>
	/// The result of laying out one type.
	/// </summary>
	/// <param name="InstanceSize">
	/// The size the calculation produced, counted from the start of the object and so including the
	/// header. This is the value the metadata records for a non generic type.
	/// </param>
	/// <param name="ActualSize">
	/// How far the fields actually reach, which is the size before trailing padding. A derived class
	/// begins where this ends, so a base class's padding can be reused, which is what the Itanium ABI
	/// does and the Microsoft one does not.
	/// </param>
	/// <param name="InstanceFieldOffsets">
	/// One offset per instance field, in declaration order, counted from the start of the object.
	/// </param>
	/// <param name="StaticFieldsSize">The size of the type's static storage.</param>
	public readonly record struct TypeLayout(
		int InstanceSize,
		int ActualSize,
		int MinimumAlignment,
		bool HasReferences,
		IReadOnlyList<int> InstanceFieldOffsets,
		int StaticFieldsSize,
		IReadOnlyList<int> StaticFieldOffsets);

	private readonly int pointerSize;
	private readonly int objectHeaderSize;
	private readonly bool microsoftAbi;
	private readonly Dictionary<TypeAnalysisContext, TypeLayout?> cache = [];
	private readonly HashSet<TypeAnalysisContext> inProgress = [];

	/// <param name="microsoftAbi">
	/// Whether the binary was built by the Microsoft compiler, which does not let a derived class use a
	/// base class's trailing padding. Il2Cpp compiles with clang everywhere except Windows.
	/// </param>
	public Il2CppFieldLayout(int pointerSize, bool microsoftAbi)
	{
		this.pointerSize = pointerSize;
		// An Il2Cpp object header is a class pointer and a monitor pointer.
		objectHeaderSize = pointerSize * 2;
		this.microsoftAbi = microsoftAbi;
	}

	public Il2CppFieldLayout(ApplicationAnalysisContext context)
		: this((int)context.Binary.PointerSize, context.Binary is LibCpp2IL.PE.PE)
	{
	}

	/// <summary>
	/// The header every reference type starts with, and the amount a value type's own offsets are short
	/// of the ones this calculates.
	/// </summary>
	public int ObjectHeaderSize => objectHeaderSize;

	/// <summary>
	/// Lays a type out, or fails when something it contains cannot be sized.
	/// </summary>
	/// <remarks>
	/// Failure is not rare and is not an error. A field whose type is a constructed generic value type
	/// cannot be sized until generic layout is implemented, and a type containing one is refused rather
	/// than described with a hole in it.
	/// </remarks>
	public bool TryGetLayout(TypeAnalysisContext? type, out TypeLayout layout)
	{
		layout = default;

		if (type is null)
		{
			return false;
		}

		if (cache.TryGetValue(type, out TypeLayout? cached))
		{
			if (cached is null)
			{
				return false;
			}

			layout = cached.Value;
			return true;
		}

		// A type cannot contain itself, so this only fires on metadata that disagrees with that. It has
		// to be caught rather than trusted, since the alternative is unbounded recursion.
		if (!inProgress.Add(type))
		{
			return false;
		}

		try
		{
			bool success = TryCompute(type, out layout);
			cache[type] = success ? layout : null;
			return success;
		}
		finally
		{
			inProgress.Remove(type);
		}
	}

	private bool TryCompute(TypeAnalysisContext type, out TypeLayout layout)
	{
		layout = default;

		int instanceSize;
		int actualSize;
		int minimumAlignment;
		bool hasReferences = false;

		if (type.BaseType is TypeAnalysisContext baseType)
		{
			if (!TryGetLayout(baseType, out TypeLayout parent))
			{
				return false;
			}

			hasReferences = parent.HasReferences;
			instanceSize = EffectiveInstanceSize(baseType, parent);
			actualSize = parent.ActualSize;
			// A boxed value type is laid out inside an object header like anything else, but the value
			// itself is not required to be aligned the way an object is.
			minimumAlignment = type.IsValueType ? 1 : parent.MinimumAlignment;
		}
		else
		{
			actualSize = instanceSize = objectHeaderSize;
			minimumAlignment = pointerSize;
		}

		List<FieldAnalysisContext> instanceFields = [];
		List<FieldAnalysisContext> staticFields = [];
		foreach (FieldAnalysisContext field in type.Fields)
		{
			if (IsInstance(field))
			{
				instanceFields.Add(field);
			}
			else if (IsNormalStatic(field))
			{
				staticFields.Add(field);
			}
		}

		foreach (FieldAnalysisContext field in instanceFields)
		{
			if (!TryHasReferences(field.FieldType, out bool fieldHasReferences))
			{
				return false;
			}

			hasReferences |= fieldHasReferences;
		}

		// A type holding a reference is not blittable, so nothing depends on its exact layout and
		// Il2Cpp ignores any packing rather than risk misaligning a pointer.
		int packing = hasReferences ? 0 : GetPackingSize(type);
		bool explicitLayout = (type.Attributes & TypeAttributes.ExplicitLayout) != 0;

		if (!TryLayoutFields(type, instanceFields, actualSize, minimumAlignment, packing, explicitLayout, out FieldLayoutData instance))
		{
			return false;
		}

		int[] instanceOffsets = instance.Offsets;
		instanceSize = instance.ClassSize;
		minimumAlignment = instance.MinimumAlignment;

		// A type given an explicit size by its declaration keeps that size, padding included, so its
		// derived classes start after the padding rather than inside it.
		actualSize = StructLayoutSizeIsDefault(type)
			? instance.ActualClassSize
			: MetadataInstanceSize(type);

		if (instanceOffsets.Length == 0)
		{
			// With no fields to lay out there is nothing to compute, so whatever the definition records
			// stands. That is how the runtime treats such a type, and it is the only thing that can be
			// right for the handful whose size comes from the C++ side rather than from managed fields:
			// System.Array carries an array's bounds and length, and the shared generic placeholders are
			// whatever Il2Cpp made them.
			int declared = MetadataInstanceSize(type);
			if (declared > 0)
			{
				instanceSize = declared;
			}
			else if (type.IsValueType)
			{
				// A value type still has to occupy something, or two of them would share an address.
				instanceSize = EmptyValueTypeSize + objectHeaderSize;
			}
		}

		// A declaration that states its own size keeps it, however little the fields add up to. A fixed
		// buffer is the common case: it declares one element and a size covering the rest.
		if (!StructLayoutSizeIsDefault(type))
		{
			instanceSize = Math.Max(instanceSize, MetadataInstanceSize(type));
		}

		// The instance layout is published before the static one is worked out, exactly as the runtime
		// marks the type sized between the two. A type with a static field of its own type, which
		// System.Guid and System.DateTime both have, would otherwise be waiting on itself.
		layout = new TypeLayout(instanceSize, actualSize, minimumAlignment, hasReferences, instanceOffsets, StaticSizeUnknown, []);
		cache[type] = layout;

		if (TryLayoutFields(type, staticFields, 0, 1, 0, isExplicitLayout: false, out FieldLayoutData statics))
		{
			layout = layout with { StaticFieldsSize = statics.ClassSize, StaticFieldOffsets = statics.Offsets };
		}

		return true;
	}

	/// <summary>
	/// What <see cref="TypeLayout.StaticFieldsSize"/> reports when a static field could not be sized.
	/// </summary>
	/// <remarks>
	/// Static storage is laid out separately from the instance and nothing about the instance depends on
	/// it, so a static that cannot be sized is not a reason to refuse the type.
	/// </remarks>
	public const int StaticSizeUnknown = -1;

	/// <summary>
	/// The size a compiler gives a value type with no fields.
	/// </summary>
	private const int EmptyValueTypeSize = 1;

	/// <summary>
	/// What laying a set of fields out produced.
	/// </summary>
	/// <param name="ClassSize">The size of the type, trailing padding included.</param>
	/// <param name="ActualClassSize">How far the fields reach, before that padding.</param>
	public readonly record struct FieldLayoutData(int[] Offsets, int ClassSize, int ActualClassSize, int MinimumAlignment);

	private bool TryLayoutFields(
		TypeAnalysisContext type,
		List<FieldAnalysisContext> fields,
		int actualParentSize,
		int parentAlignment,
		int packing,
		bool isExplicitLayout,
		out FieldLayoutData data)
	{
		data = default;

		SizeAndAlignment[] sizes = new SizeAndAlignment[fields.Count];
		int[]? explicitOffsets = isExplicitLayout ? new int[fields.Count] : null;

		for (int i = 0; i < fields.Count; i++)
		{
			if (!TryGetSizeAndAlignment(fields[i].FieldType, out sizes[i]))
			{
				return false;
			}

			if (explicitOffsets is not null)
			{
				explicitOffsets[i] = RuntimeFieldOffset(type, fields[i]);
			}
		}

		data = LayoutFields(sizes, actualParentSize, parentAlignment, packing, explicitOffsets, microsoftAbi);
		return true;
	}

	/// <summary>
	/// Places a set of fields one after another, which is the whole of the layout rule.
	/// </summary>
	/// <remarks>
	/// A field is placed at the running end of the type, rounded up to its own alignment, and the type
	/// ends up as large as its furthest field rounded up to the strictest alignment any of them wanted.
	/// An explicit layout supplies the offsets instead of accumulating them, but everything else is the
	/// same, which is why a union still reports a size and an alignment.
	/// </remarks>
	/// <param name="actualParentSize">
	/// Where the fields start, which is where the base class's fields stopped rather than where the base
	/// class ended. The difference is its trailing padding, and reusing it is what the Itanium ABI does.
	/// </param>
	/// <param name="packing">A cap on every field's alignment, or zero for none.</param>
	/// <param name="explicitOffsets">Offsets from the declaration, or null to accumulate them.</param>
	public static FieldLayoutData LayoutFields(
		IReadOnlyList<SizeAndAlignment> fields,
		int actualParentSize,
		int parentAlignment,
		int packing,
		IReadOnlyList<int>? explicitOffsets,
		bool microsoftAbi)
	{
		int[] offsets = new int[fields.Count];
		int actualClassSize = actualParentSize;
		int minimumAlignment = parentAlignment;

		for (int i = 0; i < fields.Count; i++)
		{
			int alignment = packing > 0 ? Math.Min(fields[i].Alignment, packing) : fields[i].Alignment;
			int offset = explicitOffsets is null ? actualClassSize : explicitOffsets[i];
			offset = AlignTo(offset, alignment);

			offsets[i] = offset;
			// A field of no size still moves the end of the type along, so that the next one does not
			// land on top of it.
			actualClassSize = Math.Max(actualClassSize, offset + Math.Max(fields[i].Size, 1));
			minimumAlignment = Math.Max(minimumAlignment, alignment);
		}

		int classSize = AlignTo(actualClassSize, minimumAlignment);

		// The Microsoft compiler does not place a derived class's fields in a base class's trailing
		// padding, so for it the two sizes are the same thing.
		return new FieldLayoutData(offsets, classSize, microsoftAbi ? classSize : actualClassSize, minimumAlignment);
	}

	/// <summary>
	/// How much space a type takes when it is a field of another, and what it must be aligned to.
	/// </summary>
	/// <remarks>
	/// Everything that is a reference is a pointer, whatever it refers to, and an enum is whatever it is
	/// stored as. Only a value type has to be laid out to be measured, which is where the recursion is.
	/// </remarks>
	public bool TryGetSizeAndAlignment(TypeAnalysisContext? type, out SizeAndAlignment sizeAndAlignment)
	{
		sizeAndAlignment = default;

		if (type is null)
		{
			return false;
		}

		switch (type.Type)
		{
			case Il2CppTypeEnum.IL2CPP_TYPE_BOOLEAN:
			case Il2CppTypeEnum.IL2CPP_TYPE_I1:
			case Il2CppTypeEnum.IL2CPP_TYPE_U1:
				sizeAndAlignment = new SizeAndAlignment(1, 1);
				return true;
			case Il2CppTypeEnum.IL2CPP_TYPE_CHAR:
			case Il2CppTypeEnum.IL2CPP_TYPE_I2:
			case Il2CppTypeEnum.IL2CPP_TYPE_U2:
				sizeAndAlignment = new SizeAndAlignment(2, 2);
				return true;
			case Il2CppTypeEnum.IL2CPP_TYPE_I4:
			case Il2CppTypeEnum.IL2CPP_TYPE_U4:
			case Il2CppTypeEnum.IL2CPP_TYPE_R4:
				sizeAndAlignment = new SizeAndAlignment(4, 4);
				return true;
			case Il2CppTypeEnum.IL2CPP_TYPE_I8:
			case Il2CppTypeEnum.IL2CPP_TYPE_U8:
			case Il2CppTypeEnum.IL2CPP_TYPE_R8:
				// Every platform Il2Cpp targets aligns an eight byte scalar to eight bytes, including the
				// thirty two bit ones, so this does not follow the pointer size.
				sizeAndAlignment = new SizeAndAlignment(8, 8);
				return true;
			case Il2CppTypeEnum.IL2CPP_TYPE_I:
			case Il2CppTypeEnum.IL2CPP_TYPE_U:
			case Il2CppTypeEnum.IL2CPP_TYPE_PTR:
			case Il2CppTypeEnum.IL2CPP_TYPE_FNPTR:
			case Il2CppTypeEnum.IL2CPP_TYPE_BYREF:
			case Il2CppTypeEnum.IL2CPP_TYPE_STRING:
			case Il2CppTypeEnum.IL2CPP_TYPE_SZARRAY:
			case Il2CppTypeEnum.IL2CPP_TYPE_ARRAY:
			case Il2CppTypeEnum.IL2CPP_TYPE_CLASS:
			case Il2CppTypeEnum.IL2CPP_TYPE_OBJECT:
				sizeAndAlignment = new SizeAndAlignment(pointerSize, pointerSize);
				return true;
			case Il2CppTypeEnum.IL2CPP_TYPE_VALUETYPE:
			case Il2CppTypeEnum.IL2CPP_TYPE_ENUM:
			case Il2CppTypeEnum.IL2CPP_TYPE_GENERICINST:
				break;
			// A type parameter has no size of its own. Reaching one means an uninflated generic is being
			// laid out, and the runtime never does that.
			default:
				return false;
		}

		// A constructed generic that is not a value type is a reference like any other.
		if (type.Type is Il2CppTypeEnum.IL2CPP_TYPE_GENERICINST)
		{
			if (!type.IsValueType)
			{
				sizeAndAlignment = new SizeAndAlignment(pointerSize, pointerSize);
				return true;
			}

			// A constructed generic value type is laid out from its arguments rather than stored, and
			// inflating it is not implemented, so it is refused rather than measured as its definition.
			return false;
		}

		if (type.IsEnumType)
		{
			return TryGetSizeAndAlignment(type.EnumUnderlyingType, out sizeAndAlignment);
		}

		if (!TryGetLayout(type, out TypeLayout layout))
		{
			return false;
		}

		sizeAndAlignment = new SizeAndAlignment(EffectiveInstanceSize(type, layout) - objectHeaderSize, layout.MinimumAlignment);
		return true;
	}

	/// <summary>
	/// Whether a field makes the type holding it interesting to the collector, which is what suppresses
	/// packing.
	/// </summary>
	private bool TryHasReferences(TypeAnalysisContext? type, out bool hasReferences)
	{
		hasReferences = false;

		if (type is null)
		{
			return false;
		}

		switch (type.Type)
		{
			case Il2CppTypeEnum.IL2CPP_TYPE_STRING:
			case Il2CppTypeEnum.IL2CPP_TYPE_SZARRAY:
			case Il2CppTypeEnum.IL2CPP_TYPE_ARRAY:
			case Il2CppTypeEnum.IL2CPP_TYPE_CLASS:
			case Il2CppTypeEnum.IL2CPP_TYPE_OBJECT:
				hasReferences = true;
				return true;
			case Il2CppTypeEnum.IL2CPP_TYPE_GENERICINST when !type.IsValueType:
				hasReferences = true;
				return true;
		}

		// An enum is its underlying primitive, and a primitive holds nothing.
		if (type.IsEnumType || !type.IsValueType)
		{
			return true;
		}

		if (type.Type is not (Il2CppTypeEnum.IL2CPP_TYPE_VALUETYPE or Il2CppTypeEnum.IL2CPP_TYPE_ENUM or Il2CppTypeEnum.IL2CPP_TYPE_GENERICINST))
		{
			return true;
		}

		if (!TryGetLayout(type, out TypeLayout layout))
		{
			return false;
		}

		hasReferences = layout.HasReferences;
		return true;
	}

	/// <summary>
	/// The size the rest of the runtime sees for a type, which for a non generic one is what the
	/// metadata says rather than what was just calculated.
	/// </summary>
	/// <remarks>
	/// The two agree, and this implementation exists in order to check that they do. Where they cannot,
	/// because the declaration gave the type an explicit size, the metadata is what everything else was
	/// compiled against, so it is the one to build on.
	/// </remarks>
	private int EffectiveInstanceSize(TypeAnalysisContext type, TypeLayout layout)
	{
		int declared = MetadataInstanceSize(type);
		return declared > 0 ? declared : layout.InstanceSize;
	}

	private static int MetadataInstanceSize(TypeAnalysisContext type)
	{
		return type.Definition is null ? 0 : (int)type.Definition.RawSizes.instance_size;
	}

	/// <summary>
	/// A field's offset counted from the start of the object.
	/// </summary>
	/// <remarks>
	/// The offsets read back from the metadata are relative to the value for a value type, since that is
	/// what a caller wants, while the runtime works in offsets from the start of the boxed object. The
	/// header is added back here so that one calculation covers both kinds of type.
	/// </remarks>
	public int RuntimeFieldOffset(TypeAnalysisContext type, FieldAnalysisContext field)
	{
		return type.IsValueType ? field.Offset + objectHeaderSize : field.Offset;
	}

	private static bool IsInstance(FieldAnalysisContext field) => !field.IsStatic;

	/// <summary>
	/// Whether a field occupies the type's static storage, as opposed to being a constant with no
	/// storage at all or living in thread local storage.
	/// </summary>
	private static bool IsNormalStatic(FieldAnalysisContext field)
	{
		// A thread static's recorded offset is an index into thread local storage rather than an offset
		// into the type, and it is written as a large negative number to say so.
		return field.IsStatic
			&& (field.Attributes & FieldAttributes.Literal) == 0
			&& field.Offset >= 0;
	}

	/// <summary>
	/// The packing a declaration asked for, which the metadata stores as a four bit exponent.
	/// </summary>
	private static int GetPackingSize(TypeAnalysisContext type)
	{
		if (type.Definition is null)
		{
			return 0;
		}

		return (type.Definition.Bitfield >> (PackingSizeBit - 1) & 0xF) switch
		{
			0 => 0,
			1 => 1,
			2 => 2,
			3 => 4,
			4 => 8,
			5 => 16,
			6 => 32,
			7 => 64,
			8 => 128,
			_ => 0,
		};
	}

	private static bool StructLayoutSizeIsDefault(TypeAnalysisContext type)
	{
		return type.Definition is null || (type.Definition.Bitfield >> (ClassSizeIsDefaultBit - 1) & 1) != 0;
	}

	// Bit positions inside Il2CppTypeDefinition.bitfield, counted from one.
	private const int PackingSizeBit = 7;
	private const int ClassSizeIsDefaultBit = 12;

	private static int AlignTo(int size, int alignment)
	{
		return alignment <= 1 ? size : (size + alignment - 1) & ~(alignment - 1);
	}
}
