using Cpp2IL.Core.Analysis;

namespace AssetRipper.Tests;

/// <summary>
/// Covers <see cref="FieldOffsetFrame"/>: which of IL2CPP's two frames a field offset is measured in.
/// </summary>
/// <remarks>
/// These are synthetic on purpose. The question - "an offset of X, X bytes from where?" - is a
/// property of the layout model and not of any binary, and answering it against a game mixes the
/// model's semantics with whatever the lifter made of a particular instruction. The numbers the model
/// has to satisfy were measured separately, on two games and two architectures: of 598 and 458
/// non-generic structs with recorded offsets, 547 and 435 reproduce at metadata + header and none at
/// the metadata offset itself.
/// </remarks>
internal sealed class Il2CppFieldOffsetFrameTests
{
	private const int PointerSize = 8;
	private const long Header = 16;

	[Test]
	public void AClassCarriesAHeaderAndItsMetadataOffsetsAlreadyIncludeIt()
	{
		// Nothing to convert: both frames are the object for a reference type.
		Assert.Multiple(() =>
		{
			Assert.That(FieldOffsetFrame.FromComputedLayout(0x20, isValueType: false, PointerSize), Is.EqualTo(0x20));
			Assert.That(FieldOffsetFrame.ToReceiverDisplacement(0x20, isValueType: false, PointerSize), Is.EqualTo(0x20));
		});
	}

	[Test]
	public void AValueTypeHasNoHeaderSoTheComputedLayoutIsOneHeaderAhead()
	{
		// The computed layout lays every type out from the object; a struct's metadata starts at its
		// own data. This is the whole of the difference, and it is exactly one header.
		Assert.That(FieldOffsetFrame.FromComputedLayout(Header, isValueType: true, PointerSize), Is.EqualTo(0));
	}

	[Test]
	public void AStructsFirstFieldIsAtZeroAndThatIsARealOffset()
	{
		// Offset zero is the case a "> 0 means known" test silently drops, and it is the one every
		// struct has. Rect.m_XMin is 0, and a receiver names it at 0x10.
		Assert.Multiple(() =>
		{
			Assert.That(FieldOffsetFrame.ToReceiverDisplacement(0, isValueType: true, PointerSize), Is.EqualTo(Header));
			Assert.That(FieldOffsetFrame.FromComputedLayout(Header, isValueType: true, PointerSize), Is.EqualTo(0));
		});
	}

	[Test]
	public void AStructFieldPastTheFirstKeepsItsDistanceFromTheStart()
	{
		Assert.Multiple(() =>
		{
			Assert.That(FieldOffsetFrame.ToReceiverDisplacement(4, isValueType: true, PointerSize), Is.EqualTo(Header + 4));
			Assert.That(FieldOffsetFrame.ToReceiverDisplacement(8, isValueType: true, PointerSize), Is.EqualTo(Header + 8));
			Assert.That(FieldOffsetFrame.FromComputedLayout(Header + 8, isValueType: true, PointerSize), Is.EqualTo(8));
		});
	}

	[Test]
	public void TheTwoConversionsAreInverses()
	{
		// The defect this file exists for was composing them in the same direction twice, so the
		// round trip is the property that matters rather than either conversion alone.
		foreach (long offset in new long[] { 0, 4, 8, 0x20, 0x138 })
		{
			foreach (bool isValueType in new[] { true, false })
			{
				long there = FieldOffsetFrame.ToReceiverDisplacement(offset, isValueType, PointerSize);

				Assert.That(FieldOffsetFrame.FromComputedLayout(there, isValueType, PointerSize), Is.EqualTo(offset),
					$"offset {offset:X}, isValueType {isValueType}");
			}
		}
	}

	[Test]
	public void ApplyingTheReceiverDisplacementTwiceIsNotTheSameAsApplyingItOnce()
	{
		// States the bug as a test: a generic value type took its offset from the computed layout,
		// which already includes the header, and the caller added it again.
		long once = FieldOffsetFrame.ToReceiverDisplacement(0, isValueType: true, PointerSize);
		long twice = FieldOffsetFrame.ToReceiverDisplacement(once, isValueType: true, PointerSize);

		Assert.That(twice, Is.Not.EqualTo(once));
		Assert.That(twice, Is.EqualTo(2 * Header));
	}

	[Test]
	public void AThirtyTwoBitHeaderIsTwoFourBytePointers()
	{
		// The header is two pointers, not the number sixteen.
		Assert.Multiple(() =>
		{
			Assert.That(FieldOffsetFrame.HeaderSize(4), Is.EqualTo(8));
			Assert.That(FieldOffsetFrame.HeaderSize(8), Is.EqualTo(16));
			Assert.That(FieldOffsetFrame.ToReceiverDisplacement(0, isValueType: true, pointerSize: 4), Is.EqualTo(8));
		});
	}
}
