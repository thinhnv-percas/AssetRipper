using AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// Answers the <c>Il2CppClass</c> offset questions Cpp2IL analysis asks, from measured per-version
/// layouts instead of a hardcoded table. Falls back to the caller's own constants when no layout is loaded.
/// </summary>
public sealed class StructDbClassOffsets(RuntimeStructDb db)
{
	private const string ClassStruct = "Il2CppClass";

	/// <summary>Offset of <c>Il2CppClass::vtable</c>, or -1 when unknown.</summary>
	public int VTableOffset => OffsetOf("vtable");

	public int StaticFieldsOffset => OffsetOf("static_fields");

	public int InterfaceOffsetsOffset => OffsetOf("interfaceOffsets");

	public int InterfaceOffsetsCountOffset => OffsetOf("interface_offsets_count");

	public int RgctxDataOffset => OffsetOf("rgctx_data");

	public int ElementClassOffset => OffsetOf("element_class");

	/// <summary>Size of one <c>VirtualInvokeData</c>, the stride of the vtable. -1 when unknown.</summary>
	public int VTableSlotSize => db.GetSize("VirtualInvokeData");

	/// <summary>The vtable slot an offset lands in, or -1 when the offset is not inside the vtable.</summary>
	public int GetVTableSlot(long offset)
	{
		int vtable = VTableOffset;
		int stride = VTableSlotSize;

		if (vtable < 0 || stride <= 0 || offset < vtable)
		{
			return -1;
		}

		return (int)((offset - vtable) / stride);
	}

	/// <summary>The name of the <c>Il2CppClass</c> field at an offset, or null.</summary>
	public string? GetFieldName(long offset)
		=> db.TryResolveField(ClassStruct, offset, out RuntimeFieldAccess access) ? access.Path : null;

	private int OffsetOf(string fieldName)
	{
		if (!db.TryGetStruct(ClassStruct, out StructDbStruct? layout))
		{
			return -1;
		}

		foreach (StructDbField field in layout.Fields)
		{
			if (field.Name == fieldName)
			{
				return field.Offset;
			}
		}

		return -1;
	}
}
