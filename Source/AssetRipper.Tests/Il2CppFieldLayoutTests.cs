using AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

namespace AssetRipper.Tests;

/// <summary>
/// The layout rule Il2Cpp runs, checked against the cases that separate it from a plausible guess.
/// </summary>
/// <remarks>
/// The whole point of reproducing this rather than approximating it is that a generic type has no
/// stored layout to fall back on, so these pin the parts a shorter rule would get wrong.
/// </remarks>
public sealed class Il2CppFieldLayoutTests
{
	private const int ObjectHeader = 16;

	private static Il2CppFieldLayout.SizeAndAlignment Scalar(int size) => new(size, size);

	private static Il2CppFieldLayout.FieldLayoutData Layout(
		IReadOnlyList<Il2CppFieldLayout.SizeAndAlignment> fields,
		int actualParentSize = ObjectHeader,
		int parentAlignment = 8,
		int packing = 0,
		IReadOnlyList<int>? explicitOffsets = null,
		bool microsoftAbi = false)
	{
		return Il2CppFieldLayout.LayoutFields(fields, actualParentSize, parentAlignment, packing, explicitOffsets, microsoftAbi);
	}

	[Test]
	public void EachFieldIsRoundedUpToItsOwnAlignment()
	{
		Il2CppFieldLayout.FieldLayoutData data = Layout([Scalar(1), Scalar(4), Scalar(2)]);

		Assert.Multiple(() =>
		{
			// One byte at 16, then four bytes which cannot start at 17, then two which cannot start at 24.
			Assert.That(data.Offsets, Is.EqualTo(new[] { 16, 20, 24 }));
			Assert.That(data.ActualClassSize, Is.EqualTo(26));
		});
	}

	/// <summary>
	/// The size is rounded to the strictest alignment any field wanted, not to the last field's.
	/// </summary>
	[Test]
	public void TrailingPaddingFollowsTheStrictestFieldAlignment()
	{
		Il2CppFieldLayout.FieldLayoutData data = Layout([Scalar(8), Scalar(1)]);

		Assert.Multiple(() =>
		{
			Assert.That(data.MinimumAlignment, Is.EqualTo(8));
			Assert.That(data.ActualClassSize, Is.EqualTo(25));
			Assert.That(data.ClassSize, Is.EqualTo(32));
		});
	}

	/// <summary>
	/// The two sizes are the difference between the ABIs, and it decides where a derived class starts.
	/// </summary>
	[Test]
	public void OnlyTheMicrosoftAbiPadsBeforeADerivedClass()
	{
		Il2CppFieldLayout.SizeAndAlignment[] fields = [Scalar(8), Scalar(1)];

		Il2CppFieldLayout.FieldLayoutData itanium = Layout(fields);
		Il2CppFieldLayout.FieldLayoutData microsoft = Layout(fields, microsoftAbi: true);

		Assert.Multiple(() =>
		{
			Assert.That(itanium.ClassSize, Is.EqualTo(microsoft.ClassSize));
			// A derived class continues from the actual size, so under Itanium its first field lands in
			// the seven bytes of padding the base left behind and under Microsoft it does not.
			Assert.That(itanium.ActualClassSize, Is.EqualTo(25));
			Assert.That(microsoft.ActualClassSize, Is.EqualTo(32));
		});
	}

	[Test]
	public void ADerivedClassContinuesFromWhereItsBaseStopped()
	{
		Il2CppFieldLayout.FieldLayoutData baseClass = Layout([Scalar(8), Scalar(1)]);
		Il2CppFieldLayout.FieldLayoutData derived = Layout([Scalar(1)], baseClass.ActualClassSize);

		Assert.That(derived.Offsets, Is.EqualTo(new[] { 25 }));
	}

	/// <summary>
	/// Packing lowers an alignment and never raises one.
	/// </summary>
	[Test]
	public void PackingCapsAlignmentWithoutIncreasingIt()
	{
		Assert.Multiple(() =>
		{
			Assert.That(Layout([Scalar(1), Scalar(8)], packing: 1).Offsets, Is.EqualTo(new[] { 16, 17 }));
			Assert.That(Layout([Scalar(1), Scalar(2)], packing: 8).Offsets, Is.EqualTo(new[] { 16, 18 }));
		});
	}

	/// <summary>
	/// A field of no size still occupies a byte, or the next field would be laid on top of it.
	/// </summary>
	[Test]
	public void AZeroSizedFieldStillAdvancesTheType()
	{
		Il2CppFieldLayout.FieldLayoutData data = Layout([new Il2CppFieldLayout.SizeAndAlignment(0, 1), Scalar(1)]);

		Assert.That(data.Offsets, Is.EqualTo(new[] { 16, 17 }));
	}

	/// <summary>
	/// An explicit layout supplies its own offsets, which is what makes a union a union.
	/// </summary>
	[Test]
	public void ExplicitOffsetsOverlapButStillDecideTheSize()
	{
		Il2CppFieldLayout.FieldLayoutData data = Layout(
			[Scalar(4), Scalar(4), Scalar(8)],
			explicitOffsets: [16, 20, 16]);

		Assert.Multiple(() =>
		{
			Assert.That(data.Offsets, Is.EqualTo(new[] { 16, 20, 16 }));
			Assert.That(data.ClassSize, Is.EqualTo(24));
			Assert.That(data.MinimumAlignment, Is.EqualTo(8));
		});
	}

	/// <summary>
	/// An explicit offset is still rounded up, so a declaration cannot misalign a field.
	/// </summary>
	[Test]
	public void ExplicitOffsetsAreStillAligned()
	{
		Assert.That(Layout([Scalar(8)], explicitOffsets: [17]).Offsets, Is.EqualTo(new[] { 24 }));
	}

	/// <summary>
	/// A type with nothing in it is as large as its base and no larger.
	/// </summary>
	[Test]
	public void NoFieldsLeavesTheTypeTheSizeOfItsBase()
	{
		Il2CppFieldLayout.FieldLayoutData data = Layout([]);

		Assert.Multiple(() =>
		{
			Assert.That(data.Offsets, Is.Empty);
			Assert.That(data.ClassSize, Is.EqualTo(ObjectHeader));
			Assert.That(data.MinimumAlignment, Is.EqualTo(8));
		});
	}

	/// <summary>
	/// A struct starts at zero and is not aligned like an object, which is why its parent alignment is
	/// one rather than the pointer size.
	/// </summary>
	[Test]
	public void AStructOfThreeFloatsIsTwelveBytes()
	{
		Il2CppFieldLayout.FieldLayoutData data = Layout([Scalar(4), Scalar(4), Scalar(4)], parentAlignment: 1);

		Assert.Multiple(() =>
		{
			Assert.That(data.Offsets, Is.EqualTo(new[] { 16, 20, 24 }));
			Assert.That(data.ClassSize - ObjectHeader, Is.EqualTo(12));
			Assert.That(data.MinimumAlignment, Is.EqualTo(4));
		});
	}
}
