using Cpp2IL.Core.Analysis;
using System.Buffers.Binary;

namespace AssetRipper.Tests;

/// <summary>
/// Recognising a compare-and-swap from its instructions rather than from its address.
/// </summary>
/// <remarks>
/// <para>
/// One address on the test game takes 339 unresolved calls, all of them from event accessors, and
/// the code there is a compare-and-swap loop. Naming it by address would be right on that build and
/// silently wrong on the next - a wrong mapping corrupts 339 accessors in the quiet way - so it has
/// to be named by what it does.
/// </para>
/// <para>
/// Every case here is assembled at a different address, and the address is never an input: a rule
/// that reads one would pass these and still be the rule this exists to avoid. The encodings are
/// written out from the A64 manual's load/store-exclusive format rather than restated from the code
/// under test, and the negative cases are the neighbours a too-lax rule would swallow.
/// </para>
/// </remarks>
public class Il2CppAtomicIntrinsicTests
{
	/// <summary>LDAXR/LDXR &lt;Xt&gt;, [&lt;Xn&gt;] - size 11, L set, Rs and Rt2 all ones.</summary>
	private static uint LoadExclusive(int transfer, int address, bool acquire = true, bool wide = true)
		=> (uint)((wide ? 0xC0000000 : 0x80000000) | 0x085F7C00 | (acquire ? 0x8000 : 0) | (address << 5) | transfer);

	/// <summary>STLXR/STXR &lt;Ws&gt;, &lt;Xt&gt;, [&lt;Xn&gt;] - the same family with L clear.</summary>
	private static uint StoreExclusive(int status, int transfer, int address, bool release = true, bool wide = true)
		=> (uint)((wide ? 0xC0000000 : 0x80000000) | 0x08007C00 | (status << 16) | (release ? 0x8000 : 0) | (address << 5) | transfer);

	/// <summary>CMP &lt;Xn&gt;, &lt;Xm&gt; - SUBS with the zero register as its destination.</summary>
	private static uint Compare(int first, int second) => (uint)(0xEB00001F | (second << 16) | (first << 5));

	private static uint Move(int destination, int source) => (uint)(0xAA0003E0 | (source << 16) | destination);

	private static uint Return() => 0xD65F03C0;

	/// <summary>The words laid out as bytes, the way they sit in a binary.</summary>
	private static byte[] Code(params uint[] words)
	{
		byte[] bytes = new byte[words.Length * 4];
		for (int i = 0; i < words.Length; i++)
		{
			BinaryPrimitives.WriteUInt32LittleEndian(bytes.AsSpan(i * 4, 4), words[i]);
		}
		return bytes;
	}

	[Test]
	public void TheCompareAndSwapLoopIsRecognised()
	{
		// ldaxr x8,[x0]; cmp x8,x2; b.ne out; stlxr w9,x1,[x0]; cbnz w9,retry - the exact sequence at
		// the address in question, with the two branches left in so the window has to step over them.
		byte[] code = Code(LoadExclusive(8, 0), Compare(8, 2), 0x54000061, StoreExclusive(9, 1, 0), 0x35FFFF69, Return());

		Assert.That(AtomicIntrinsicRecognizer.Classify(code), Is.EqualTo(AtomicIntrinsicRecognizer.Shape.CompareExchange));
	}

	[Test]
	public void TheSameLoopAtAnyOtherAddressIsTheSameAnswer()
	{
		// Stated as a case because it is the whole point: the classifier is handed bytes and never an
		// address, so a rule that keyed on one could not compile, let alone pass.
		byte[] first = Code(LoadExclusive(8, 0), Compare(8, 2), StoreExclusive(9, 1, 0), Return());
		byte[] second = Code(0xD503201F, 0xD503201F, LoadExclusive(3, 5), Compare(3, 7), StoreExclusive(4, 6, 5), Return());

		Assert.Multiple(() =>
		{
			Assert.That(AtomicIntrinsicRecognizer.Classify(first), Is.EqualTo(AtomicIntrinsicRecognizer.Shape.CompareExchange));
			Assert.That(AtomicIntrinsicRecognizer.Classify(second), Is.EqualTo(AtomicIntrinsicRecognizer.Shape.CompareExchange));
		});
	}

	[Test]
	public void TheNarrowAndUnorderedFormsAreTheSameSequence()
	{
		// An int field is compare-and-swapped as often as a reference, and a compiler may fence the
		// loop some other way and emit the plain exclusive forms. Both are still the sequence.
		byte[] code = Code(LoadExclusive(8, 0, acquire: false, wide: false), Compare(8, 2), StoreExclusive(9, 1, 0, release: false, wide: false), Return());

		Assert.That(AtomicIntrinsicRecognizer.Classify(code), Is.EqualTo(AtomicIntrinsicRecognizer.Shape.CompareExchange));
	}

	[Test]
	public void AnExchangeWithNoComparisonIsNotCompareAndSwap()
	{
		// Interlocked.Exchange is the same pair without the comparison, and it is the neighbour a
		// rule that only looked for the pair would swallow - with the arguments in another order.
		byte[] code = Code(LoadExclusive(8, 0), StoreExclusive(9, 1, 0), Return());

		Assert.That(AtomicIntrinsicRecognizer.Classify(code), Is.EqualTo(AtomicIntrinsicRecognizer.Shape.ExchangeWithoutComparison));
	}

	[Test]
	public void AComparisonOfSomethingElseDoesNotCount()
	{
		// The comparison has to be of the value just loaded, or an exchange followed by an unrelated
		// test reads as a compare-and-swap.
		byte[] code = Code(LoadExclusive(8, 0), Compare(3, 2), StoreExclusive(9, 1, 0), Return());

		Assert.That(AtomicIntrinsicRecognizer.Classify(code), Is.EqualTo(AtomicIntrinsicRecognizer.Shape.ExchangeWithoutComparison));
	}

	[Test]
	public void TwoExclusiveAccessesToDifferentAddressesAreNotAPair()
	{
		byte[] code = Code(LoadExclusive(8, 0), Compare(8, 2), StoreExclusive(9, 1, 4), Return());

		Assert.That(AtomicIntrinsicRecognizer.Classify(code), Is.EqualTo(AtomicIntrinsicRecognizer.Shape.None));
	}

	[Test]
	public void AComparisonBeforeTheLoadIsPrologueRatherThanPartOfTheSequence()
	{
		// Every function that guards its argument compares before it does anything; counting that
		// would make the comparison free and the rule would stop separating the two shapes.
		byte[] code = Code(Compare(8, 2), LoadExclusive(8, 0), StoreExclusive(9, 1, 0), Return());

		Assert.That(AtomicIntrinsicRecognizer.Classify(code), Is.EqualTo(AtomicIntrinsicRecognizer.Shape.ExchangeWithoutComparison));
	}

	[Test]
	public void AnOrdinaryFunctionMatchesNothing()
	{
		byte[] code = Code(Move(0, 1), Compare(0, 2), Move(0, 3), Return());

		Assert.That(AtomicIntrinsicRecognizer.Classify(code), Is.EqualTo(AtomicIntrinsicRecognizer.Shape.None));
	}

	[Test]
	public void ASequenceBeyondTheWindowIsNotReachedFor()
	{
		// The window is what stops a match being made out of two unrelated functions laid out next to
		// each other, which is exactly how InspectPotentialThrowHelper collected three stubs' calls.
		uint[] padding = new uint[AtomicIntrinsicRecognizer.WindowInstructions + 2];
		Array.Fill(padding, 0xD503201Fu);
		byte[] code = Code([.. padding, LoadExclusive(8, 0), Compare(8, 2), StoreExclusive(9, 1, 0)]);

		Assert.That(AtomicIntrinsicRecognizer.Classify(code), Is.EqualTo(AtomicIntrinsicRecognizer.Shape.None));
	}

	[Test]
	public void CodeTooShortToHoldTheSequenceIsNotReadPastItsEnd()
	{
		Assert.Multiple(() =>
		{
			Assert.That(AtomicIntrinsicRecognizer.Classify([]), Is.EqualTo(AtomicIntrinsicRecognizer.Shape.None));
			Assert.That(AtomicIntrinsicRecognizer.Classify([0x08, 0x7C]), Is.EqualTo(AtomicIntrinsicRecognizer.Shape.None));
			Assert.That(AtomicIntrinsicRecognizer.Classify(Code(LoadExclusive(8, 0))), Is.EqualTo(AtomicIntrinsicRecognizer.Shape.None));
		});
	}
}
