using AssetRipper.Il2CppRestore.Binary;

namespace AssetRipper.Il2CppRestore.Lift.Registration;

/// <summary>
/// The parts of <c>Il2CppMetadataRegistration</c> the pipeline actually reads: the <c>types[]</c> table
/// (guide §11.2's "the real Il2CppType decoding needs the binary" note) and <c>metadataUsages[]</c>
/// (guide §8 — the only way to decode string/type/method usages from metadata v29 onward).
/// </summary>
/// <remarks>
/// Every field here is one pointer-sized slot, counts included — the guide's own registration-search
/// constant (12 slots before <c>typeDefinitionsSizesCount</c>) only makes sense if the compiler pads
/// each <c>int32</c> count out to pointer width ahead of the pointer that follows it, which is exactly
/// what x64/arm64 struct layout rules do for this field order. <c>metadataUsagesCount</c> is natively
/// <c>size_t</c> (already pointer-width), so nothing unusual there.
/// </remarks>
public sealed class Il2CppMetadataRegistration
{
	public required ulong TypesVa { get; init; }
	public required int TypesCount { get; init; }
	public required ulong MetadataUsagesVa { get; init; }
	public required int MetadataUsagesCount { get; init; }

	public static Il2CppMetadataRegistration Read(IBinaryImage image, ulong va)
	{
		long offset = image.MapVaToOffset(va);
		int slot = image.Is32Bit ? 4 : 8;

		// Field pairs, by slot index from the struct's own start (0-based, each pair = count then
		// pointer): 0 genericClasses, 2 genericInsts, 4 genericMethodTable, 6 types, 8 methodSpecs,
		// 10 fieldOffsets, 12 typeDefinitionsSizes (the pair RegistrationSearch itself locates this
		// struct by), 14 metadataUsages.
		const int TypesSlot = 6;
		const int MetadataUsagesSlot = 14;

		long typesCountSlot = offset + TypesSlot * (long)slot;
		int typesCount = (int)image.ReadPointer(typesCountSlot);
		ulong typesVa = image.ReadPointer(typesCountSlot + slot);

		long metadataUsagesCountSlot = offset + MetadataUsagesSlot * (long)slot;
		int metadataUsagesCount = (int)image.ReadPointer(metadataUsagesCountSlot);
		ulong metadataUsagesVa = image.ReadPointer(metadataUsagesCountSlot + slot);

		return new Il2CppMetadataRegistration
		{
			TypesVa = typesVa,
			TypesCount = typesCount,
			MetadataUsagesVa = metadataUsagesVa,
			MetadataUsagesCount = metadataUsagesCount,
		};
	}
}
