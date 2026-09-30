using Cpp2IL.Core.Utils;
using Shape = Cpp2IL.Core.Utils.Arm64ArgumentPlacement.Shape;
using Kind = Cpp2IL.Core.Utils.Arm64ArgumentPlacement.Kind;

namespace AssetRipper.Tests;

/// <summary>
/// Iteration 063: where AAPCS64 and Apple's arm64 ABI put each argument. Found by the JellyBlast source
/// oracle, measuring PathCreator against its upstream source: <c>EvaluateCurve(Vector3 a1, Vector3 c1,
/// Vector3 c2, Vector3 a2, float t)</c> recovered with <c>t</c> as <c>default(float)</c>.
/// </summary>
public class Arm64ArgumentPlacementTests
{
	private static readonly Shape Vector3 = new(Kind.FloatAggregate, 12, 3, 4);
	private static readonly Shape Single = new(Kind.Float, 4, 1, 4);
	private static readonly Shape Int32 = new(Kind.Integer, 4, 1, 4);

	private static string[] Place(bool apple, params Shape[] shapes)
		=> Arm64ArgumentPlacement.Place(shapes, apple).Select(l => l.ToString()).ToArray();

	/// <summary>
	/// C.3: an aggregate that does not fit sets NSRN to 8, so the float after it goes to the stack too
	/// rather than into V6, which nothing writes.
	/// </summary>
	[Test]
	public void AnAggregateThatDoesNotFitSendsEveryLaterFloatToTheStack()
	{
		Assert.That(Place(false, Vector3, Vector3, Vector3, Vector3, Single, Shape.Pointer),
			Is.EqualTo(new[] { "V0", "V3", "[sp+0]", "[sp+16]", "[sp+32]", "X0" }));
	}

	/// <summary>Apple packs stack arguments at natural alignment: 12-byte vectors, a 4-byte float.</summary>
	[Test]
	public void ApplePacksStackArgumentsAtNaturalAlignment()
	{
		Assert.That(Place(true, Vector3, Vector3, Vector3, Vector3, Single, Shape.Pointer),
			Is.EqualTo(new[] { "V0", "V3", "[sp+0]", "[sp+12]", "[sp+24]", "X0" }));
	}

	[Test]
	public void AFloatAfterAnAggregateThatFitsTakesTheNextRegister()
	{
		Assert.That(Place(false, Vector3, Single, Vector3), Is.EqualTo(new[] { "V0", "V3", "V4" }));
	}

	[Test]
	public void TheNinthIntegerArgumentIsOnTheStackInASlotItsOwnSizeOnApple()
	{
		Shape[] nine = [.. Enumerable.Repeat(Shape.Pointer, 8), Int32, Int32, Shape.Pointer];
		Assert.Multiple(() =>
		{
			Assert.That(Place(false, nine)[8..], Is.EqualTo(new[] { "[sp+0]", "[sp+8]", "[sp+16]" }));
			Assert.That(Place(true, nine)[8..], Is.EqualTo(new[] { "[sp+0]", "[sp+4]", "[sp+8]" }));
		});
	}

	/// <summary>The two register files are counted separately: floats on the stack do not move integers.</summary>
	[Test]
	public void IntegerAndFloatCountersAreIndependent()
	{
		Assert.That(Place(false, Vector3, Vector3, Vector3, Shape.Pointer, Single),
			Is.EqualTo(new[] { "V0", "V3", "[sp+0]", "X0", "[sp+16]" }));
	}
}
