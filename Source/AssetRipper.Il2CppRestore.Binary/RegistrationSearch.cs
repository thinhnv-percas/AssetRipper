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
	public static ulong FindCodeRegistration(IBinaryImage image, int imageCount, Action<string>? log = null)
	{
		if (image.SymbolsByVa.Count > 0)
		{
			foreach ((ulong va, string name) in image.SymbolsByVa)
			{
				if (name is "g_CodeRegistration" or "_g_CodeRegistration")
				{
					log?.Invoke($"CodeRegistration: found by symbol table at 0x{va:X}.");
					return va;
				}
			}
		}

		log?.Invoke($"CodeRegistration: no symbol table match, scanning for a (count={imageCount}, pointer) pair {CodeRegistrationSlotsBeforeCodeGenModules} pointer-slots into the struct.");
		return ScanForCountedPointer(image, imageCount, CodeRegistrationSlotsBeforeCodeGenModules, log);
	}

	/// <summary>
	/// Finds <c>g_MetadataRegistration</c>, the same way as <see cref="FindCodeRegistration"/>.
	/// </summary>
	public static ulong FindMetadataRegistration(IBinaryImage image, int typeDefinitionCount, Action<string>? log = null)
	{
		if (image.SymbolsByVa.Count > 0)
		{
			foreach ((ulong va, string name) in image.SymbolsByVa)
			{
				if (name is "g_MetadataRegistration" or "_g_MetadataRegistration")
				{
					log?.Invoke($"MetadataRegistration: found by symbol table at 0x{va:X}.");
					return va;
				}
			}
		}

		log?.Invoke($"MetadataRegistration: no symbol table match, scanning for a (count={typeDefinitionCount}, pointer) pair {MetadataRegistrationSlotsBeforeTypeDefinitionsSizes} pointer-slots into the struct.");
		return ScanForCountedPointer(image, typeDefinitionCount, MetadataRegistrationSlotsBeforeTypeDefinitionsSizes, log);
	}

	/// <summary>
	/// Scans every pointer-aligned position in the binary's non-executable sections (registration lives
	/// in <c>.data</c>/<c>.data.rel.ro</c>, never in code) for a <c>(count, pointer-to-array-of-count-valid-pointers)</c>
	/// pair, then backs up to where the struct itself must start.
	/// </summary>
	private static ulong ScanForCountedPointer(IBinaryImage image, int expectedCount, int slotsBeforePair, Action<string>? log)
	{
		if (expectedCount <= 0)
		{
			log?.Invoke($"Scan aborted: expected count is {expectedCount} (<= 0), which cannot come from a real registration struct — the metadata array this count was read from is probably empty or misread.");
			return 0;
		}

		int pointerSize = image.Is32Bit ? 4 : 8;

		const int MaxRejectionLogs = 20;

		ulong expected = (ulong)expectedCount;

		int sectionsScanned = 0;
		long positionsScanned = 0;
		int countMatchesSeen = 0;
		int rejectionsLogged = 0;
		ulong closestCountSeen = 0;
		ulong closestCountDistance = ulong.MaxValue;

		foreach (BinarySection section in image.Sections)
		{
			if (section.Executable || section.Size < pointerSize * 2L)
			{
				continue;
			}
			sectionsScanned++;

			for (long offset = section.Offset; offset + pointerSize * 2L <= section.Offset + section.Size; offset += pointerSize)
			{
				positionsScanned++;
				ulong count = image.ReadPointer(offset);

				// Plain ulong subtraction, never a (long) cast or Math.Abs: count comes from
				// reinterpreting arbitrary binary bytes as a number, so it can legitimately be larger
				// than long.MaxValue - Math.Abs(long.MinValue) throws OverflowException unconditionally,
				// and that combination turned up reliably within a couple of megabytes of real scanning.
				ulong distance = count > expected ? count - expected : expected - count;
				if (distance < closestCountDistance)
				{
					closestCountDistance = distance;
					closestCountSeen = count;
				}

				if (count != expected)
				{
					continue;
				}
				countMatchesSeen++;

				ulong arrayPtr = image.ReadPointer(offset + pointerSize);
				long arrayOffset = image.MapVaToOffset(arrayPtr);
				if (arrayOffset < 0)
				{
					if (rejectionsLogged++ < MaxRejectionLogs)
					{
						log?.Invoke($"  count matched at file offset 0x{offset:X}, but the pointer that follows (0x{arrayPtr:X}) does not map into any loaded section — rejected.");
					}
					continue;
				}

				if (!EveryElementIsAValidPointer(image, arrayOffset, expectedCount, pointerSize))
				{
					if (rejectionsLogged++ < MaxRejectionLogs)
					{
						log?.Invoke($"  count matched at file offset 0x{offset:X}, but not every one of the {expectedCount} array entries at 0x{arrayPtr:X} is a valid pointer — rejected.");
					}
					continue;
				}

				long structOffset = offset - (long)slotsBeforePair * pointerSize;
				if (structOffset < section.Offset)
				{
					if (rejectionsLogged++ < MaxRejectionLogs)
					{
						log?.Invoke($"  count matched at file offset 0x{offset:X} and its array validated, but backing up {slotsBeforePair} slots lands before this section starts — rejected.");
					}
					continue;
				}

				ulong resultVa = image.MapOffsetToVa(structOffset);
				log?.Invoke($"Scan succeeded: struct starts at file offset 0x{structOffset:X} (VA 0x{resultVa:X}), found in section '{section.Name}'.");
				return resultVa;
			}
		}

		log?.Invoke(
			$"Scan failed: {sectionsScanned} non-executable section(s), {positionsScanned} pointer-aligned position(s) checked, " +
			$"{countMatchesSeen} position(s) had the right count but failed array validation (first {Math.Min(rejectionsLogged, MaxRejectionLogs)} logged above). " +
			$"Closest count actually seen was {closestCountSeen} (target {expectedCount}, off by {closestCountDistance}).");
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
