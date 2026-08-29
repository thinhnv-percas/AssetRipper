namespace AssetRipper.Il2CppRestore.Binary;

/// <summary>
/// Finds <c>Il2CppCodeRegistration</c> and <c>Il2CppMetadataRegistration</c> in a stripped binary.
/// </summary>
/// <remarks>
/// Neither struct has a symbol once stripped, so the reliable method is not "scan for something that
/// looks right" but a scan constrained by counts already known from the metadata: both structs end in a
/// <c>(count, pointer)</c> pair, and that count has to equal a size we already read out of
/// <c>global-metadata.dat</c>. Layout confirmed identical between Unity 2022.3 and 6000.3 (guide §6).
/// </remarks>
public static class RegistrationSearch
{
	/// <summary>
	/// <c>Il2CppCodeRegistration</c> ends with <c>codeGenModulesCount</c> then <c>codeGenModules</c>,
	/// the (count, pointer) pair this search looks for. 16 pointer-sized slots precede it in the struct.
	/// </summary>
	private const int CodeRegistrationSlotsBeforeCodeGenModules = 16;

	/// <summary>
	/// <c>Il2CppMetadataRegistration</c> ends with <c>typeDefinitionsSizesCount</c> then
	/// <c>typeDefinitionsSizes</c>. 12 pointer-sized slots precede it.
	/// </summary>
	private const int MetadataRegistrationSlotsBeforeTypeDefinitionsSizes = 12;

	/// <summary>
	/// Finds <c>g_CodeRegistration</c>. Tries the binary's own symbol table first (cheap, exact); falls
	/// back to the count-constrained scan only when the binary is stripped.
	/// </summary>
	public static ulong FindCodeRegistration(IBinaryImage image, int imageCount)
	{
		if (image.SymbolsByVa.Count > 0)
		{
			foreach ((ulong va, string name) in image.SymbolsByVa)
			{
				if (name is "g_CodeRegistration" or "_g_CodeRegistration")
				{
					return va;
				}
			}
		}

		return ScanForCountedPointer(image, imageCount, CodeRegistrationSlotsBeforeCodeGenModules);
	}

	/// <summary>
	/// Finds <c>g_MetadataRegistration</c>, the same way as <see cref="FindCodeRegistration"/>.
	/// </summary>
	public static ulong FindMetadataRegistration(IBinaryImage image, int typeDefinitionCount)
	{
		if (image.SymbolsByVa.Count > 0)
		{
			foreach ((ulong va, string name) in image.SymbolsByVa)
			{
				if (name is "g_MetadataRegistration" or "_g_MetadataRegistration")
				{
					return va;
				}
			}
		}

		return ScanForCountedPointer(image, typeDefinitionCount, MetadataRegistrationSlotsBeforeTypeDefinitionsSizes);
	}

	/// <summary>
	/// Scans every pointer-aligned position in the binary's non-executable sections (registration lives
	/// in <c>.data</c>/<c>.data.rel.ro</c>, never in code) for a <c>(count, pointer-to-array-of-count-valid-pointers)</c>
	/// pair, then backs up to where the struct itself must start.
	/// </summary>
	private static ulong ScanForCountedPointer(IBinaryImage image, int expectedCount, int slotsBeforePair)
	{
		if (expectedCount <= 0)
		{
			return 0;
		}

		int pointerSize = image.Is32Bit ? 4 : 8;

		foreach (BinarySection section in image.Sections)
		{
			if (section.Executable || section.Size < pointerSize * 2L)
			{
				continue;
			}

			for (long offset = section.Offset; offset + pointerSize * 2L <= section.Offset + section.Size; offset += pointerSize)
			{
				ulong count = image.ReadPointer(offset);
				if (count != (ulong)expectedCount)
				{
					continue;
				}

				ulong arrayPtr = image.ReadPointer(offset + pointerSize);
				long arrayOffset = image.MapVaToOffset(arrayPtr);
				if (arrayOffset < 0)
				{
					continue;
				}

				if (!EveryElementIsAValidPointer(image, arrayOffset, expectedCount, pointerSize))
				{
					continue;
				}

				long structOffset = offset - (long)slotsBeforePair * pointerSize;
				if (structOffset < section.Offset)
				{
					continue;
				}

				return image.MapOffsetToVa(structOffset);
			}
		}

		return 0;
	}

	private static bool EveryElementIsAValidPointer(IBinaryImage image, long arrayOffset, int count, int pointerSize)
	{
		// A cap keeps a pathological false-positive match (a huge "count" that happens to occur) from
		// turning into an unbounded scan; genuine registration arrays are a few hundred entries at most.
		int checkCount = Math.Min(count, 4096);
		for (int i = 0; i < checkCount; i++)
		{
			ulong pointer = image.ReadPointer(arrayOffset + (long)i * pointerSize);
			// A null entry is legitimate (an assembly with no code-gen module, or similar), only an
			// out-of-range one disqualifies the match.
			if (pointer != 0 && image.MapVaToOffset(pointer) < 0)
			{
				return false;
			}
		}
		return true;
	}
}
