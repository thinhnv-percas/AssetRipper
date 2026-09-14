using Cpp2IL.Core.InstructionSets;

namespace AssetRipper.Tests;

/// <summary>
/// The two masks a bitfield move needs.
/// </summary>
/// <remarks>
/// <c>BFI</c> and <c>BFXIL</c> are <c>UBFIZ</c> and <c>UBFX</c> plus a read of the destination, and
/// that read is the whole difference: everything the field covers comes from the source, everything
/// else stays. 92 placeholders on the second measurement game came from these two opcodes alone.
/// The part worth a test is not the shifting but the width of the complement - a 32 bit register
/// keeps 32 bits, and a 64 bit complement sets the destination's whole high half to ones.
/// </remarks>
public class Il2CppBitfieldMoveTests
{
	[Test]
	public void AnInsertPlacesTheFieldAtTheOffsetAndKeepsEverythingElse()
	{
		// bfi w8, w9, #4, #8
		var (field, kept) = NewArmV8InstructionSet.BitfieldMoveMasks(isInsert: true, lsb: 4, width: 8, is64: false);

		Assert.Multiple(() =>
		{
			Assert.That(field, Is.EqualTo(0xFFUL));
			Assert.That(kept, Is.EqualTo(0xFFFFF00FUL));
		});
	}

	[Test]
	public void AnExtractInsertLowPlacesTheFieldAtTheBottom()
	{
		// bfxil w8, w9, #4, #8 - the field is read from bit 4 of the source but written at bit 0.
		var (field, kept) = NewArmV8InstructionSet.BitfieldMoveMasks(isInsert: false, lsb: 4, width: 8, is64: false);

		Assert.Multiple(() =>
		{
			Assert.That(field, Is.EqualTo(0xFFUL));
			Assert.That(kept, Is.EqualTo(0xFFFFFF00UL));
		});
	}

	[Test]
	public void ThirtyTwoBitComplementsDoNotReachTheHighHalf()
	{
		// This is the case the cut exists for. Without it `kept` is 0xFFFFFFFFFFFFF00F, so every bit
		// of the destination's high half arrives set from an instruction that never wrote there.
		var (_, kept) = NewArmV8InstructionSet.BitfieldMoveMasks(isInsert: true, lsb: 4, width: 8, is64: false);

		Assert.That(kept >> 32, Is.EqualTo(0UL));
	}

	[Test]
	public void SixtyFourBitComplementsDo()
	{
		var (_, kept) = NewArmV8InstructionSet.BitfieldMoveMasks(isInsert: true, lsb: 4, width: 8, is64: true);

		Assert.That(kept, Is.EqualTo(0xFFFFFFFFFFFFF00FUL));
	}

	[Test]
	public void AFullWidthFieldDoesNotShiftOutOfRange()
	{
		// `1UL << 64` is not zero, it is one - the shift count wraps - so a full width field has to be
		// spelled out rather than computed.
		var (field, kept) = NewArmV8InstructionSet.BitfieldMoveMasks(isInsert: true, lsb: 0, width: 64, is64: true);

		Assert.Multiple(() =>
		{
			Assert.That(field, Is.EqualTo(ulong.MaxValue));
			Assert.That(kept, Is.EqualTo(0UL));
		});
	}

	[Test]
	public void AThirtyTwoBitMaskIsWrittenAsAThirtyTwoBitValue()
	{
		// Same bits, but a 32 bit mask whose top bit is set is a negative int, not a large positive
		// long. Written the wide way the generator pushes an I8 into an I4 destination: 75 stack type
		// mismatches on the second fixture.
		var (_, kept) = NewArmV8InstructionSet.BitfieldMoveMasks(isInsert: true, lsb: 4, width: 8, is64: false);

		Assert.Multiple(() =>
		{
			Assert.That(NewArmV8InstructionSet.MaskImmediate(kept, is64: false), Is.EqualTo(-4081L));
			Assert.That(NewArmV8InstructionSet.MaskImmediate(kept, is64: false), Is.InRange(int.MinValue, int.MaxValue));
		});
	}

	[Test]
	public void ASixtyFourBitMaskKeepsItsBits()
	{
		var (_, kept) = NewArmV8InstructionSet.BitfieldMoveMasks(isInsert: true, lsb: 4, width: 8, is64: true);

		Assert.That(unchecked((ulong)NewArmV8InstructionSet.MaskImmediate(kept, is64: true)), Is.EqualTo(kept));
	}
}

