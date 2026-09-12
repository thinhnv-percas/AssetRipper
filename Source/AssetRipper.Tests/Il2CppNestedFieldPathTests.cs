using Cpp2IL.Core.Analysis;

namespace AssetRipper.Tests;

/// <summary>
/// Covers <see cref="NestedFieldResolver"/>: which field chain an access at a given offset and width
/// reaches, and when the honest answer is the outer field rather than a guess at an inner one.
/// </summary>
/// <remarks>
/// The layouts here are written out rather than read from metadata, so each assertion is a fact about
/// offsets and widths rather than a restatement of the code. <c>ObscuredInt</c>'s real shape - 24
/// bytes, an <c>int</c> at 0 and a <c>bool</c> at 0x10 - is the one measured layout among them, and is
/// what <c>ItemDistinc</c>'s constructor stores four bytes into.
/// </remarks>
internal sealed class Il2CppNestedFieldPathTests
{
	[Test]
	public void AnOffsetOnAFieldWithNoWidthGivenTakesTheFieldWhole()
	{
		Layout obscuredInt = ObscuredInt();
		Layout owner = new("ItemDistinc", 0x50, [new("level", 0x30, obscuredInt)]);

		Assert.That(Find(owner, 0x30, accessSize: 0), Is.EqualTo("level"));
	}

	[Test]
	public void AnAccessAsWideAsTheFieldIsTheFieldWhole()
	{
		Layout owner = new("ItemDistinc", 0x50, [new("level", 0x30, ObscuredInt())]);

		Assert.That(Find(owner, 0x30, accessSize: 24), Is.EqualTo("level"));
	}

	[Test]
	public void AnAccessNarrowerThanTheFieldReachesTheMemberAtItsStart()
	{
		// The defect this exists for: four bytes at the offset of a 24-byte struct is its first member.
		Layout owner = new("ItemDistinc", 0x50, [new("level", 0x30, ObscuredInt())]);

		Assert.That(Find(owner, 0x30, accessSize: 4), Is.EqualTo("level.currentCryptoKey"));
	}

	[Test]
	public void AnOffsetInsideAFieldReachesTheMemberThereWithoutNeedingAWidth()
	{
		// Past the start of a field the field itself is not a valid answer, so the offset is the whole
		// of the evidence.
		Layout owner = new("ItemDistinc", 0x50, [new("level", 0x30, ObscuredInt())]);

		Assert.That(Find(owner, 0x40, accessSize: 0), Is.EqualTo("level.fakeValueActive"));
	}

	[Test]
	public void AnAccessWidthTheInnerFieldCannotAccountForKeepsTheOuterField()
	{
		// Two bytes at the start of a struct whose first member is four wide is a partial write of
		// something this cannot name. The outer field is the honest answer, not a guess.
		Layout owner = new("ItemDistinc", 0x50, [new("level", 0x30, ObscuredInt())]);

		Assert.That(Find(owner, 0x30, accessSize: 2), Is.EqualTo("level"));
	}

	[Test]
	public void ANarrowAccessIntoAFieldWithNoInteriorKeepsTheField()
	{
		// A reference field has no interior to descend into whatever the width says.
		Layout owner = new("Holder", 0x20, [new("reference", 0x10, Size: 8)]);

		Assert.That(Find(owner, 0x10, accessSize: 4), Is.EqualTo("reference"));
	}

	[Test]
	public void TwoFieldsAtOneOffsetAreAmbiguousSoTheOuterFieldStands()
	{
		// An overlapping layout: nothing here can say which of the two was meant.
		Layout owner = new("Union", 0x20, [new("first", 0x0, ObscuredInt()), new("second", 0x0, ObscuredInt())]);

		Assert.That(Find(owner, 0x0, accessSize: 4), Is.AnyOf("first", "second"));
		Assert.That(Find(owner, 0x0, accessSize: 4), Does.Not.Contain("."));
	}

	[Test]
	public void AFieldInheritedFromTheBaseSitsAtItsOwnOffsetInTheDerivedLayout()
	{
		// The derived layout carries the base's fields at their absolute offsets, so the offset is not
		// added twice.
		Layout baseFields = new("Base", 0x30, [new("baseLevel", 0x10, ObscuredInt())]);
		Layout derived = new("Derived", 0x50, [new("derivedValue", 0x30, Size: 4)], baseFields);

		Assert.That(Find(derived, 0x10, accessSize: 4), Is.EqualTo("baseLevel.currentCryptoKey"));
		Assert.That(Find(derived, 0x20, accessSize: 0), Is.EqualTo("baseLevel.fakeValueActive"));
		Assert.That(Find(derived, 0x30, accessSize: 4), Is.EqualTo("derivedValue"));
	}

	[Test]
	public void ASelfReferentialLayoutTerminates()
	{
		// Node.next is a Node, so descending at the start of it descends into the same layout at the
		// same offset forever. The query has to be one that actually descends - a width narrower than
		// the field it lands on - or the cycle is never entered and the test proves nothing.
		Layout node = new("Node", 0x20, []);
		node.Fields.Add(new Member("next", 0x0, node));
		node.Fields.Add(new Member("value", 0x18, Size: 4));

		Assert.That(() => Find(node, 0x0, accessSize: 2), Throws.Nothing);
		Assert.That(Find(node, 0x0, accessSize: 2), Is.EqualTo("next"), "the cycle gives no inner answer, so the field stands");
		Assert.That(Find(node, 0x18, accessSize: 4), Is.EqualTo("value"));
	}

	[Test]
	public void TwoFieldsOfOneTypeBothResolve()
	{
		// Note: this does not exercise the offset half of the visited key. A value type cannot contain
		// itself, so within a single descent a type is never revisited at a different offset; the
		// offset in the key is a guard against layouts this cannot currently be handed, and no test
		// here distinguishes it from keying on the type alone.
		Layout obscured = ObscuredInt();
		Layout owner = new("Pair", 0x40, [new("a", 0x0, obscured), new("b", 0x18, obscured)]);

		Assert.Multiple(() =>
		{
			Assert.That(Find(owner, 0x0, accessSize: 4), Is.EqualTo("a.currentCryptoKey"));
			Assert.That(Find(owner, 0x18, accessSize: 4), Is.EqualTo("b.currentCryptoKey"));
			Assert.That(Find(owner, 0x28, accessSize: 0), Is.EqualTo("b.fakeValueActive"));
		});
	}

	[Test]
	public void AThreeDeepChainResolvesToItsLeaf()
	{
		Layout inner = new("Inner", 8, [new("x", 0x0, Size: 4), new("y", 0x4, Size: 4)]);
		Layout middle = new("Middle", 0x10, [new("pad", 0x0, Size: 8), new("point", 0x8, inner)]);
		Layout owner = new("Outer", 0x20, [new("middle", 0x10, middle)]);

		Assert.That(Find(owner, 0x1C, accessSize: 4), Is.EqualTo("middle.point.y"));
	}

	[Test]
	public void AnOffsetPastTheLastFieldReachesNothing()
	{
		Layout owner = new("Holder", 0x20, [new("value", 0x10, Size: 4)]);

		Assert.That(Find(owner, 0x40, accessSize: 4), Is.Null);
	}

	[Test]
	public void ANegativeOffsetReachesNothing()
	{
		Layout owner = new("Holder", 0x20, [new("value", 0x10, Size: 4)]);

		Assert.That(Find(owner, -8, accessSize: 4), Is.Null);
	}

	/// <summary>ObscuredInt as the game's metadata lays it out: 24 bytes, int at 0, bool at 0x10.</summary>
	private static Layout ObscuredInt() => new("ObscuredInt", 24,
	[
		new("currentCryptoKey", 0x0, Size: 4),
		new("hiddenValue", 0x4, Size: 4),
		new("fakeValue", 0x8, Size: 4),
		new("fakeValueActive", 0x10, Size: 1),
	]);

	private sealed record Member(string Name, long Offset, Layout? Interior = null, long Size = 0)
	{
		public long Width => Interior?.Size ?? Size;
	}

	private sealed record Layout(string Name, long Size, List<Member> Fields, Layout? Base = null);

	/// <summary>Runs the search and renders the chain as a dotted path, or null when it reached nothing.</summary>
	private static string? Find(Layout owner, long targetOffset, long accessSize)
	{
		List<Member>? path = NestedFieldResolver.Find<Layout, Member>(
			owner, targetOffset, accessSize,
			InstanceFields,
			member => member.Width,
			member => member.Interior);

		return path is null ? null : string.Join('.', path.Select(member => member.Name));
	}

	/// <summary>Every instance field including the base chain's, at its offset in this layout.</summary>
	private static IEnumerable<(Member Field, long Offset)> InstanceFields(Layout layout)
	{
		for (Layout? level = layout; level is not null; level = level.Base)
		{
			foreach (Member field in level.Fields)
				yield return (field, field.Offset);
		}
	}
}
