using LibCpp2IL.MachO;

namespace AssetRipper.Tests;

/// <summary>
/// Covers the Mach-O chained fixup walker and the encryption region predicate against synthetic
/// binaries, so each pointer format is stated as a fact about the format rather than as a
/// restatement of the code.
/// </summary>
/// <remarks>
/// The numbers asserted here come from Apple's <c>mach-o/fixup-chains.h</c>: a
/// <c>dyld_chained_ptr_64_rebase</c> is <c>target:36, high8:8, reserved:7, next:12, bind:1</c>, the
/// <c>next</c> field is a stride in four byte units, and the two 64-bit formats differ in exactly
/// one respect - <c>DYLD_CHAINED_PTR_64</c>'s target is an unslid virtual address while
/// <c>DYLD_CHAINED_PTR_64_OFFSET</c>'s is an offset from the image base. The difference is invisible
/// on a binary whose first segment sits at zero, which is why it has to be tested on one that does
/// not. See <c>reports/IOS_TYPE_DEFINITIONS_SIZES_ANALYSIS.md</c>.
/// </remarks>
internal sealed class MachOChainedFixupTests
{
	private const int PageSize = 0x4000;

	[Test]
	public void ChainedPtr64TreatsTargetAsAnAbsoluteAddress()
	{
		// __TEXT at 0x100000000, so an absolute target and an image-base-relative one differ by 4 GB.
		MachOFile file = Build(imageBase: 0x100000000, MachODyldChainedPtr.DYLD_CHAINED_PTR_64,
			[Rebase(target: 0x100001234, high8: 0, next: 0)]);

		Assert.That(ReadDataWord(file, 0), Is.EqualTo(0x100001234UL));
	}

	[Test]
	public void ChainedPtr64OffsetAddsTheImageBaseToTheTarget()
	{
		MachOFile file = Build(imageBase: 0x100000000, MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET,
			[Rebase(target: 0x1234, high8: 0, next: 0)]);

		Assert.That(ReadDataWord(file, 0), Is.EqualTo(0x100001234UL));
	}

	[Test]
	public void TheTwoFormatsAgreeWhenTheImageBaseIsZero()
	{
		// A dylib - which is what UnityFramework is - links at zero, so the formats coincide there.
		MachOFile absolute = Build(0, MachODyldChainedPtr.DYLD_CHAINED_PTR_64, [Rebase(0x1234, 0, 0)]);
		MachOFile relative = Build(0, MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET, [Rebase(0x1234, 0, 0)]);

		Assert.That(ReadDataWord(absolute, 0), Is.EqualTo(0x1234UL));
		Assert.That(ReadDataWord(relative, 0), Is.EqualTo(0x1234UL));
	}

	[Test]
	public void TheImageBaseIsAddedToTheComposedValue()
	{
		// The spec's formula is imageBase + ((high8 << 56) | target), with a target that carries out
		// of its own 36 bits once biased. Biasing the target field instead would give the same answer
		// here - bits 36 to 55 of an unpacked value are empty and no real image base reaches them -
		// so this pins the formula rather than catching a collision.
		MachOFile file = Build(imageBase: 0x100000000, MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET,
			[Rebase(target: 0xF00000000, high8: 0xAA, next: 0)]);

		Assert.That(ReadDataWord(file, 0), Is.EqualTo(0xAA00001000000000UL));
	}

	[Test]
	public void High8OccupiesTheTopByteOfTheRebasedPointer()
	{
		MachOFile file = Build(0, MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET,
			[Rebase(target: 0x1234, high8: 0xB7, next: 0)]);

		Assert.That(ReadDataWord(file, 0), Is.EqualTo(0xB700000000001234UL));
	}

	[Test]
	public void NextIsAStrideInFourByteUnits()
	{
		// Two pointers eight bytes apart are one chain with next == 2, not next == 1.
		MachOFile file = Build(0, MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET,
			[Rebase(target: 0x1111, high8: 0, next: 2), Rebase(target: 0x2222, high8: 0, next: 0)]);

		Assert.That(ReadDataWord(file, 0), Is.EqualTo(0x1111UL));
		Assert.That(ReadDataWord(file, 1), Is.EqualTo(0x2222UL));
	}

	[Test]
	public void AChainStopsAtNextZeroAndLeavesLaterWordsAlone()
	{
		// The untouched word needs a non-zero high8, or its encoded and rebased forms are the same
		// number and the assertion cannot tell whether the walker stopped.
		MachOFile file = Build(0, MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET,
			[Rebase(target: 0x1111, high8: 0, next: 0), Rebase(target: 0x2222, high8: 0xAA, next: 0)]);

		Assert.That(ReadDataWord(file, 0), Is.EqualTo(0x1111UL));
		// The second word was never walked, so it still holds its encoded form.
		Assert.That(ReadDataWord(file, 1), Is.EqualTo(Rebase(0x2222, 0xAA, 0)));
		Assert.That(ReadDataWord(file, 1), Is.Not.EqualTo(0xAA00000000002222UL), "that would be the rebased form");
	}

	[Test]
	public void ABindEntryIsLeftEncodedRatherThanRebasedToZero()
	{
		MachOFile file = Build(0, MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET, [Bind(ordinal: 3, next: 0)]);

		Assert.That(ReadDataWord(file, 0), Is.EqualTo(Bind(3, 0)), "a bind is not a rebase and must not be written as one");
	}

	[Test]
	public void AnUnknownPointerFormatRebasesNothing()
	{
		ulong encoded = Rebase(0x1234, 0xAA, 0);
		MachOFile file = Build(0, (MachODyldChainedPtr)11, [encoded]);

		Assert.That(ReadDataWord(file, 0), Is.EqualTo(encoded));
		Assert.That(ReadDataWord(file, 0), Is.Not.EqualTo(0xAA00000000001234UL), "that would be the rebased form");
	}

	[Test]
	public void PageStartsAreRelativeToTheSegmentAndScaledByPageSize()
	{
		// One pointer on page 0 and one on page 1, each its own single-entry chain.
		ulong[] words = new ulong[PageSize / 8 + 1];
		words[0] = Rebase(0x1111, 0, 0);
		words[PageSize / 8] = Rebase(0x2222, 0, 0);
		MachOFile file = Build(0, MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET, words,
			pageStarts: [0, 0]);

		Assert.That(ReadDataWord(file, 0), Is.EqualTo(0x1111UL));
		Assert.That(ReadDataWord(file, PageSize / 8), Is.EqualTo(0x2222UL));
	}

	[Test]
	public void APageMarkedStartNoneIsSkipped()
	{
		ulong[] words = new ulong[PageSize / 8 + 1];
		words[0] = Rebase(0x1111, 0xAA, 0);
		words[PageSize / 8] = Rebase(0x2222, 0, 0);
		MachOFile file = Build(0, MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET, words,
			pageStarts: [MachODyldChainedStartsInSegment.DYLD_CHAINED_PTR_START_NONE, 0]);

		Assert.That(ReadDataWord(file, 0), Is.EqualTo(Rebase(0x1111, 0xAA, 0)), "the skipped page keeps its encoded form");
		Assert.That(ReadDataWord(file, PageSize / 8), Is.EqualTo(0x2222UL));
	}

	[Test]
	public void AChainDoesNotRunPastTheEndOfItsPage()
	{
		// next would carry the walk into the following page, which a chain may not do.
		ulong[] words = new ulong[PageSize / 8 + 1];
		words[PageSize / 8 - 1] = Rebase(0x1111, 0, 2);
		words[PageSize / 8] = Rebase(0x2222, 0xAA, 0);
		MachOFile file = Build(0, MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET, words,
			pageStarts: [(ushort)(PageSize - 8), MachODyldChainedStartsInSegment.DYLD_CHAINED_PTR_START_NONE]);

		Assert.That(ReadDataWord(file, PageSize / 8 - 1), Is.EqualTo(0x1111UL));
		Assert.That(ReadDataWord(file, PageSize / 8), Is.EqualTo(Rebase(0x2222, 0xAA, 0)),
			"a chain that leaves its page must stop at the page boundary");
	}

	[Test]
	public void AnUnencryptedBinaryReportsNoEncryptedRegion()
	{
		MachOFile file = Build(0, MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET, [Rebase(0x1234, 0, 0)]);

		Assert.That(file.Encryption, Is.Null);
		Assert.That(file.IsVirtualAddressEncrypted(0x1000), Is.False);
	}

	[TestCase(0UL)]
	[TestCase(0x100000000UL)]
	public void TheEncryptedRegionIsTestedPerAddressRatherThanPerFile(ulong imageBase)
	{
		// Covers __TEXT from its second page to its end, which is how FairPlay names it.
		MachOFile file = Build(imageBase, MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET,
			[Rebase(0x1234, 0, 0)], cryptOffset: PageSize, cryptSize: TextSize - PageSize, cryptId: 1);

		Assert.That(file.Encryption, Is.Not.Null);
		Assert.Multiple(() =>
		{
			Assert.That(file.IsVirtualAddressEncrypted(imageBase), Is.False, "the header page is outside the range");
			Assert.That(file.IsVirtualAddressEncrypted(imageBase + PageSize - 1), Is.False, "one byte below the range");
			Assert.That(file.IsVirtualAddressEncrypted(imageBase + PageSize), Is.True, "the first byte of the range");
			Assert.That(file.IsVirtualAddressEncrypted(imageBase + TextSize - 1), Is.True, "the last byte of the range");
			Assert.That(file.IsVirtualAddressEncrypted(imageBase + TextSize), Is.False, "__DATA is never encrypted");
			Assert.That(file.IsVirtualAddressEncrypted(imageBase + TextSize + 8), Is.False);
			Assert.That(file.IsVirtualAddressEncrypted(0xDEADBEEFDEADBEEF), Is.False, "an address in no segment maps nowhere");
		});
	}

	[Test]
	public void ACryptIdOfZeroMeansTheRangeIsPlaintext()
	{
		// A decrypted dump keeps the load command and clears cryptid.
		MachOFile file = Build(0, MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET,
			[Rebase(0x1234, 0, 0)], cryptOffset: PageSize, cryptSize: TextSize - PageSize, cryptId: 0);

		Assert.That(file.Encryption, Is.Not.Null);
		Assert.That(file.Encryption!.IsEncrypted, Is.False);
		Assert.That(file.IsVirtualAddressEncrypted(PageSize), Is.False);
	}

	[Test]
	public void AnEncryptedBinaryStillRebasesItsDataSegment()
	{
		// The point of the region model: __DATA reads even when __TEXT does not.
		MachOFile file = Build(0, MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET,
			[Rebase(0x1234, 0, 0)], cryptOffset: PageSize, cryptSize: TextSize - PageSize, cryptId: 1);

		Assert.That(ReadDataWord(file, 0), Is.EqualTo(0x1234UL));
	}

	private static ulong Rebase(ulong target, ulong high8, ulong next)
		=> (target & 0xFFFFFFFFF) | (high8 & 0xFF) << 36 | (next & 0xFFF) << 51;

	private static ulong Bind(ulong ordinal, ulong next)
		=> (ordinal & 0xFFFFFF) | (next & 0xFFF) << 51 | 1UL << 63;

	private const int TextSize = 0x8000;

	private static ulong ReadDataWord(MachOFile file, int index)
		=> BitConverter.ToUInt64(file.GetRawBinaryContent()[(TextSize + index * 8)..]);

	/// <summary>
	/// Assembles the smallest Mach-O that exercises the walker: a __TEXT segment holding the header
	/// and load commands, a __DATA segment holding <paramref name="dataWords"/>, a __LINKEDIT
	/// segment holding the chained fixups blob, and optionally an encryption command.
	/// </summary>
	private static MachOFile Build(ulong imageBase, MachODyldChainedPtr pointerFormat, ulong[] dataWords,
		ushort[]? pageStarts = null, uint cryptOffset = 0, uint cryptSize = 0, uint cryptId = 0)
	{
		int dataSize = Align(dataWords.Length * 8, PageSize);
		int linkEditOffset = TextSize + dataSize;
		pageStarts ??= [0];

		// dyld_chained_fixups_header, then dyld_chained_starts_in_image, then one
		// dyld_chained_starts_in_segment per segment. Offsets inside the blob are from its start.
		const int headerSize = 7 * 4;
		int startsInImageSize = 4 + 3 * 4; // segment_count plus one offset per segment
		int segmentStartsOffset = headerSize + startsInImageSize;

		using MemoryStream blob = new();
		BinaryWriter bw = new(blob);
		bw.Write(MachODyldChainedFixupsHeader.SupportedFixupsVersion);
		bw.Write((uint)headerSize); // starts_offset
		bw.Write(0u); // imports_offset
		bw.Write(0u); // symbols_offset
		bw.Write(0u); // imports_count
		bw.Write(MachODyldChainedFixupsHeader.SupportedImportsFormat);
		bw.Write(0u); // symbols_format

		bw.Write(3u); // seg_count: __TEXT, __DATA, __LINKEDIT
		bw.Write(0u); // __TEXT has no fixups
		bw.Write((uint)(segmentStartsOffset - headerSize)); // __DATA, relative to starts_offset
		bw.Write(0u); // __LINKEDIT has no fixups

		bw.Write((uint)(MachODyldChainedStartsInSegment.Size + pageStarts.Length * 2)); // size
		bw.Write((ushort)PageSize);
		bw.Write((ushort)pointerFormat);
		bw.Write((ulong)TextSize); // segment_offset: __DATA's file offset
		bw.Write(uint.MaxValue); // max_valid_pointer
		bw.Write((ushort)pageStarts.Length);
		foreach (ushort start in pageStarts)
			bw.Write(start);
		bw.Flush();
		byte[] fixupBlob = blob.ToArray();

		byte[] raw = new byte[linkEditOffset + Align(fixupBlob.Length, PageSize)];
		fixupBlob.CopyTo(raw, linkEditOffset);
		for (int i = 0; i < dataWords.Length; i++)
			BitConverter.GetBytes(dataWords[i]).CopyTo(raw, TextSize + i * 8);

		int cursor = 0;
		void U32(uint value) { BitConverter.GetBytes(value).CopyTo(raw, cursor); cursor += 4; }
		void U64(ulong value) { BitConverter.GetBytes(value).CopyTo(raw, cursor); cursor += 8; }
		void Name(string value)
		{
			byte[] bytes = new byte[16];
			System.Text.Encoding.ASCII.GetBytes(value).CopyTo(bytes, 0);
			bytes.CopyTo(raw, cursor);
			cursor += 16;
		}

		const uint lcSegment64 = 0x19;
		const uint lcDyldChainedFixups = 0x80000034;
		const uint lcEncryptionInfo64 = 0x2C;
		const int segmentCommandSize = 72;

		uint commandCount = cryptSize == 0 ? 4u : 5u;
		U32(0xFEEDFACF); // magic
		U32(0x0100000C); // CPU_TYPE_ARM64
		U32(0); // cpusubtype
		U32(6); // MH_DYLIB
		U32(commandCount);
		U32((uint)(segmentCommandSize * 3 + 16 + (cryptSize == 0 ? 0 : 24)));
		U32(0); // flags
		U32(0); // reserved

		void Segment(string name, ulong vmAddr, ulong vmSize, ulong fileOff, ulong fileSize)
		{
			U32(lcSegment64);
			U32(segmentCommandSize);
			Name(name);
			U64(vmAddr);
			U64(vmSize);
			U64(fileOff);
			U64(fileSize);
			U32(7); // maxprot
			U32(3); // initprot
			U32(0); // nsects
			U32(0); // flags
		}

		Segment("__TEXT", imageBase, TextSize, 0, TextSize);
		Segment("__DATA", imageBase + TextSize, (ulong)dataSize, TextSize, (ulong)dataSize);
		Segment("__LINKEDIT", imageBase + (ulong)linkEditOffset, (ulong)(raw.Length - linkEditOffset),
			(ulong)linkEditOffset, (ulong)(raw.Length - linkEditOffset));

		U32(lcDyldChainedFixups);
		U32(16);
		U32((uint)linkEditOffset);
		U32((uint)fixupBlob.Length);

		if (cryptSize != 0)
		{
			U32(lcEncryptionInfo64);
			U32(24);
			U32(cryptOffset);
			U32(cryptSize);
			U32(cryptId);
			U32(0); // pad
		}

		return new MachOFile(new MemoryStream(raw, 0, raw.Length, writable: true, publiclyVisible: true));
	}

	private static int Align(int value, int alignment) => (value + alignment - 1) / alignment * alignment;
}
