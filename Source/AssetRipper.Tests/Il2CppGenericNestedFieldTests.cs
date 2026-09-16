using Cpp2IL.Core.Analysis;

namespace AssetRipper.Tests;

/// <summary>
/// Reaching a member of a struct field on a <em>generic instance</em>, where the offsets come from
/// the computed layout and a field declared of the type's own parameter is whatever the instance
/// says the parameter is.
/// </summary>
/// <remarks>
/// <para>
/// The descent into a struct field was excluded for a generic owner outright. Measuring the family
/// said what that cost: of 228 generic-instance loads the generator gave up on, 173 were
/// <em>inside</em> a layout the walk had computed correctly and simply not on a field boundary -
/// three quarters of the family, and the ordinary shape of reaching a member of a struct field.
/// After wiring the descent, that group is 3 and the total falls 2712 to 2554. The other two
/// verdicts are different work: 35 past the layout (the base is not the type the load thinks it is)
/// and 20 with no layout at all (a field that could not be sized).
/// </para>
/// <para>
/// What these cases cover is the search itself, over layouts written out here rather than read from
/// metadata, so each assertion is a fact about offsets and widths. What they deliberately do not
/// cover is the substitution lookup that turns a field declared <c>T</c> into the instance's
/// argument: that needs a <c>GenericInstanceTypeAnalysisContext</c> and a game behind it, and its
/// evidence is the measurement above and <c>CirclePlugin.SetFrom</c>, where
/// <c>NoteDecompilerIssue("Unmanaged memory load: [t + 0x154]")</c> followed by an always-true
/// <c>if ((nint)0 == 0)</c> became <c>if (!t.plugOptions.initialized)</c> - the source's own
/// condition, reached through a field whose declared type is the generic parameter.
/// </para>
/// </remarks>
internal sealed class Il2CppGenericNestedFieldTests
{
	[Test]
	public void AValueTypeArgumentInlinedIntoTheInstanceIsDescendedInto()
	{
		// TweenerCore<Vector2, Vector2, CircleOptions>: the third argument is a struct and the field
		// declared of it is stored inline, so an offset inside that field is one of its members. This
		// is CirclePlugin.SetFrom's `t.plugOptions.initialized`, with the substitution already done.
		Layout circleOptions = new("CircleOptions", 0x10,
		[
			new("center", 0x0, Size: 8),
			new("endValueDegrees", 0x8, Size: 4),
			new("initialized", 0xC, Size: 1),
		]);
		Layout tweener = new("TweenerCore", 0x160, [new("plugOptions", 0x148, circleOptions)]);

		Assert.Multiple(() =>
		{
			Assert.That(Find(tweener, 0x148, accessSize: 0), Is.EqualTo("plugOptions"));
			Assert.That(Find(tweener, 0x154, accessSize: 1), Is.EqualTo("plugOptions.initialized"));
			Assert.That(Find(tweener, 0x150, accessSize: 4), Is.EqualTo("plugOptions.endValueDegrees"));
		});
	}

	[Test]
	public void AReferenceTypeArgumentIsAPointerWithNoInterior()
	{
		// List<string>: the argument is a reference, so the element field is a pointer and an offset
		// inside it is not a member of anything. The contrast with the case above is the whole point
		// of substituting rather than assuming a pointer.
		Layout list = new("List", 0x20, [new("_items", 0x10, Size: 8), new("_size", 0x18, Size: 4)]);

		Assert.Multiple(() =>
		{
			Assert.That(Find(list, 0x10, accessSize: 4), Is.EqualTo("_items"));
			Assert.That(Find(list, 0x18, accessSize: 4), Is.EqualTo("_size"));
		});
	}

	[Test]
	public void APrimitiveArgumentShiftsEveryFieldAfterIt()
	{
		// A value-type argument is not pointer sized, so a field of it moves what follows. Written as
		// two layouts of the same definition because that difference is the defect §7 names: an int
		// argument laid out as a pointer puts every later field four bytes too far along.
		Layout ofInt = new("Entry", 0x10, [new("key", 0x0, Size: 4), new("next", 0x8, Size: 8)]);
		Layout ofLong = new("Entry", 0x10, [new("key", 0x0, Size: 8), new("next", 0x8, Size: 8)]);

		Assert.Multiple(() =>
		{
			Assert.That(Find(ofInt, 0x0, accessSize: 4), Is.EqualTo("key"));
			Assert.That(Find(ofInt, 0x8, accessSize: 8), Is.EqualTo("next"));
			Assert.That(Find(ofLong, 0x0, accessSize: 8), Is.EqualTo("key"));
		});
	}

	[Test]
	public void AGenericStructArgumentIsDescendedThroughToItsOwnMembers()
	{
		// List<KeyValuePair<Animation, float>>: the argument is itself a generic instance and a value
		// type, so a member of it is two levels down. Nothing about the search cares that the inner
		// layout came from an instantiation rather than from metadata.
		Layout pair = new("KeyValuePair", 0x10, [new("key", 0x0, Size: 8), new("value", 0x8, Size: 4)]);
		Layout holder = new("Holder", 0x30, [new("current", 0x18, pair)]);

		Assert.Multiple(() =>
		{
			Assert.That(Find(holder, 0x18, accessSize: 8), Is.EqualTo("current.key"));
			Assert.That(Find(holder, 0x20, accessSize: 4), Is.EqualTo("current.value"));
			Assert.That(Find(holder, 0x18, accessSize: 0x10), Is.EqualTo("current"));
		});
	}

	[Test]
	public void AStructArgumentNestedTwoDeepResolvesToItsLeaf()
	{
		// List<Bounds> - Bounds is a struct of two Vector3s - reached at the y of the second.
		Layout vector = new("Vector3", 0xC, [new("x", 0x0, Size: 4), new("y", 0x4, Size: 4), new("z", 0x8, Size: 4)]);
		Layout bounds = new("Bounds", 0x18, [new("m_Center", 0x0, vector), new("m_Extents", 0xC, vector)]);
		Layout holder = new("Holder", 0x30, [new("value", 0x10, bounds)]);

		Assert.That(Find(holder, 0x20, accessSize: 4), Is.EqualTo("value.m_Extents.y"));
	}

	[Test]
	public void AnOffsetPastTheComputedLayoutReachesNothing()
	{
		// The second verdict the measurement separated out: past the end of a layout that was computed
		// correctly, which means the base is not the type the load thinks it is. Answering here would
		// be inventing a field, so the search has to come back with nothing and let the load stay
		// reported.
		Layout pair = new("KeyValuePair", 0x10, [new("key", 0x0, Size: 8), new("value", 0x8, Size: 4)]);

		Assert.That(Find(pair, 0x28, accessSize: 4), Is.Null);
	}

	private sealed record Member(string Name, long Offset, Layout? Interior = null, long Size = 0)
	{
		public long Width => Interior?.Size ?? Size;
	}

	private sealed record Layout(string Name, long Size, List<Member> Fields);

	private static string? Find(Layout owner, long targetOffset, long accessSize)
	{
		List<Member>? path = NestedFieldResolver.Find<Layout, Member>(
			owner, targetOffset, accessSize,
			// The computed layout already carries the base chain, which is why this does not walk one:
			// asking for a base's fields again would place them twice.
			layout => layout.Fields.Select(field => (field, field.Offset)),
			member => member.Width,
			member => member.Interior);

		return path is null ? null : string.Join('.', path.Select(member => member.Name));
	}
}
