using AssetRipper.Il2CppRestore.Binary;

namespace AssetRipper.Il2CppRestore.Lift.Registration;

/// <summary>
/// What the top 3 bits of an as-yet-uninitialized <c>metadataUsages</c> slot say it will resolve to at
/// runtime, straight from <c>il2cpp-metadata.h</c>'s <c>GetEncodedIndexType</c>.
/// </summary>
public enum UsageKind
{
	Invalid = 0,
	TypeInfo = 1,
	Il2CppType = 2,
	MethodDef = 3,
	FieldInfo = 4,
	StringLiteral = 5,
	MethodRef = 6,
	FieldRva = 7,
}

public readonly record struct Usage(UsageKind Kind, uint Index);

/// <summary>
/// Decodes every <c>metadataUsages[]</c> slot directly from the binary's initial (not-yet-patched)
/// values — the only method that still works from metadata v29 onward, once <c>metadataUsageLists</c>/
/// <c>metadataUsagePairs</c> were removed from the metadata file itself (guide §8.2). Works for v19+ in
/// general; it is simply the *only* option from v29 on, rather than an alternative to something else.
/// </summary>
public static class UsageMap
{
	private const uint TypeMask = 0xE0000000u;
	private const int TypeShift = 29;
	private const uint IndexMask = 0x1FFFFFFEu;

	/// <summary>
	/// Maps each slot's virtual address to what it resolves to. Keyed by VA (not by index into the
	/// table) because that is how the lifter looks it up: an <c>ADRP</c>+<c>LDR</c> pair computes an
	/// address, and the lifter needs to know what that specific address means.
	/// </summary>
	public static Dictionary<ulong, Usage> Build(IBinaryImage image, Il2CppMetadataRegistration registration)
	{
		Dictionary<ulong, Usage> map = [];

		long arrayOffset = image.MapVaToOffset(registration.MetadataUsagesVa);
		if (arrayOffset < 0 || registration.MetadataUsagesCount <= 0)
		{
			return map;
		}

		int pointerSize = image.Is32Bit ? 4 : 8;
		for (int i = 0; i < registration.MetadataUsagesCount; i++)
		{
			ulong slotVa = image.ReadPointer(arrayOffset + (long)i * pointerSize);
			long slotOffset = image.MapVaToOffset(slotVa);
			if (slotOffset < 0 || slotOffset + 4 > image.Data.Length)
			{
				continue;
			}

			uint encoded = BitConverter.ToUInt32(image.Data.Span.Slice((int)slotOffset, 4));
			UsageKind kind = (UsageKind)((encoded & TypeMask) >> TypeShift);
			uint index = (encoded & IndexMask) >> 1;
			if (kind != UsageKind.Invalid)
			{
				map[slotVa] = new Usage(kind, index);
			}
		}

		return map;
	}
}
