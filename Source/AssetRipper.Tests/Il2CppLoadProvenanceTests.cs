using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// Covers <see cref="UnresolvedLoadProvenance"/>: the walk from an unresolved load's base back to
/// where the value it holds came from.
/// </summary>
/// <remarks>
/// The walk is the half that needs no metadata, which is why it was separated from what a typed base
/// means - so these cases are plain graphs with a stub for the typed end. What they are really here to
/// hold down is the three places the walk can lie: a cycle must terminate and must not be read as a
/// disagreement, a disagreement must not be resolved by picking a side, and an addition that is an
/// element address must be recognised before either of its sides is followed.
/// </remarks>
internal sealed class Il2CppLoadProvenanceTests
{
	[Test]
	public void AChainOfCopiesResolvesToWhereTheValueCameFrom()
	{
		Fixture fixture = new();
		LocalVariable start = fixture.Local("start");
		LocalVariable middle = fixture.Local("middle");
		LocalVariable end = fixture.Local("end");

		fixture.Define(middle, fixture.Call(middle));
		fixture.Define(start, fixture.Move(start, middle));
		fixture.Define(end, fixture.Move(end, start));

		Assert.That(fixture.Of(end), Is.EqualTo("MISSING_METADATA:unresolved-call-result"));
	}

	[Test]
	public void AnAdditionOfAnOffsetKeepsTheBase()
	{
		Fixture fixture = new();
		LocalVariable origin = fixture.Local("origin");
		LocalVariable shifted = fixture.Local("shifted");

		fixture.Define(origin, fixture.Call(origin));
		fixture.Define(shifted, fixture.Add(shifted, origin, new Immediate(0x18)));

		Assert.That(fixture.Of(shifted), Is.EqualTo("MISSING_METADATA:unresolved-call-result"));
	}

	[Test]
	public void AnArrayPlusAScaledIndexIsAnElementAddress()
	{
		Fixture fixture = new();
		LocalVariable array = fixture.Array("array");
		LocalVariable index = fixture.Local("index");
		LocalVariable element = fixture.Local("element");

		fixture.Define(index, fixture.Multiply(index));
		fixture.Define(element, fixture.Add(element, array, index));

		Assert.That(fixture.Of(element), Is.EqualTo("ARRAY_ELEMENT:computed-element-address"));
	}

	[Test]
	public void AnArrayPlusAnUnscaledLocalIsNotAnElementAddress()
	{
		// Without the scaling there is nothing to say the addition was indexing rather than arithmetic,
		// and calling it an element address anyway would be the false positive this whole column exists
		// to avoid. The typed side wins instead, which is the ordinary rule.
		Fixture fixture = new();
		LocalVariable array = fixture.Array("array");
		LocalVariable other = fixture.Local("other");
		LocalVariable sum = fixture.Local("sum");

		fixture.Define(sum, fixture.Add(sum, array, other));

		Assert.That(fixture.Of(sum), Is.EqualTo("TYPED"));
	}

	[Test]
	public void APhiWhoseInputsAgreeHasThatOrigin()
	{
		Fixture fixture = new();
		LocalVariable first = fixture.Local("first");
		LocalVariable second = fixture.Local("second");
		LocalVariable merged = fixture.Local("merged");

		fixture.Define(first, fixture.Call(first));
		fixture.Define(second, fixture.Call(second));
		fixture.Define(merged, fixture.Phi(merged, first, second));

		Assert.That(fixture.Of(merged), Is.EqualTo("MISSING_METADATA:unresolved-call-result"));
	}

	[Test]
	public void APhiWhoseInputsDisagreeIsTheAnswerItself()
	{
		Fixture fixture = new();
		LocalVariable fromCall = fixture.Local("fromCall");
		LocalVariable entry = fixture.Local("entry");
		LocalVariable merged = fixture.Local("merged");

		fixture.Define(fromCall, fixture.Call(fromCall));
		fixture.Define(merged, fixture.Phi(merged, fromCall, entry));

		Assert.That(fixture.Of(merged), Is.EqualTo("PHI_AMBIGUITY:phi"));
	}

	[Test]
	public void ACycleTerminatesRatherThanRecursing()
	{
		Fixture fixture = new();
		LocalVariable carried = fixture.Local("carried");
		LocalVariable around = fixture.Local("around");

		fixture.Define(carried, fixture.Move(carried, around));
		fixture.Define(around, fixture.Move(around, carried));

		Assert.That(fixture.Of(carried), Is.EqualTo("UNKNOWN:cycle"));
	}

	[Test]
	public void APhiWithOneCyclicInputTakesTheOtherOne()
	{
		// This is what a loop-carried value looks like, and reading the back edge as a disagreement
		// would put every loop in the program into PHI_AMBIGUITY.
		Fixture fixture = new();
		LocalVariable merged = fixture.Local("merged");
		LocalVariable initial = fixture.Local("initial");
		LocalVariable next = fixture.Local("next");

		fixture.Define(initial, fixture.Call(initial));
		fixture.Define(next, fixture.Move(next, merged));
		fixture.Define(merged, fixture.Phi(merged, initial, next));

		Assert.That(fixture.Of(merged), Is.EqualTo("MISSING_METADATA:unresolved-call-result"));
	}

	[Test]
	public void ALocalWithNoDefinitionIsARegistersEntryValue()
	{
		Fixture fixture = new();

		Assert.That(fixture.Of(fixture.Local("untouched")), Is.EqualTo("TYPE_PROPAGATION:entry-value"));
	}

	[Test]
	public void TwoDefinitionsThatDisagreeAreADisagreement()
	{
		// The representation is meant to be SSA and is not one by the time this runs, so this is the
		// form a disagreement actually takes in a real body - no phi survives that far.
		Fixture fixture = new();
		LocalVariable local = fixture.Local("local");
		LocalVariable other = fixture.Local("other");

		fixture.Define(local, fixture.Call(local));
		fixture.Define(local, fixture.Move(local, other));

		Assert.That(fixture.Of(local), Is.EqualTo("PHI_AMBIGUITY:multiple-definitions"));
	}

	[Test]
	public void TwoDefinitionsThatAgreeAreNotADisagreement()
	{
		Fixture fixture = new();
		LocalVariable local = fixture.Local("local");

		fixture.Define(local, fixture.Call(local));
		fixture.Define(local, fixture.Call(local));

		Assert.That(fixture.Of(local), Is.EqualTo("MISSING_METADATA:unresolved-call-result"));
	}

	[Test]
	public void AWalkLongerThanTheLimitSaysSoRatherThanRunningOn()
	{
		Fixture fixture = new();
		LocalVariable previous = fixture.Local("link0");

		for (int i = 1; i <= UnresolvedLoadProvenance.DepthLimit + 2; i++)
		{
			LocalVariable next = fixture.Local($"link{i}");
			fixture.Define(next, fixture.Move(next, previous));
			previous = next;
		}

		Assert.That(fixture.Of(previous), Is.EqualTo("UNKNOWN:too-deep"));
	}

	[Test]
	public void ATypedBaseIsHandedStraightToTheCaller()
	{
		Fixture fixture = new();

		Assert.That(fixture.Of(fixture.Array("typed")), Is.EqualTo("TYPED"));
	}

	[Test]
	public void AnAbsoluteAddressHasNoBaseToWalk()
	{
		Assert.That(
			UnresolvedLoadProvenance.Of(null, static _ => [], static _ => "TYPED", static _ => false),
			Is.EqualTo("UNKNOWN:absolute-address"));
	}

	private sealed class Fixture
	{
		/// <summary>
		/// Locals the fixture answers as typed, and those it answers as arrays. A real
		/// <c>TypeAnalysisContext</c> needs a whole application context behind it, which is exactly why
		/// the walk asks about a local's type through a delegate and never looks at one itself.
		/// </summary>
		private readonly HashSet<LocalVariable> arrays = [];

		private readonly Dictionary<LocalVariable, List<Instruction>> definitions = [];
		private int index;

		internal LocalVariable Local(string name) => new(name, new Register(null, name));

		internal LocalVariable Array(string name)
		{
			LocalVariable local = Local(name);
			arrays.Add(local);
			return local;
		}

		internal void Define(LocalVariable local, Instruction instruction)
		{
			if (!definitions.TryGetValue(local, out List<Instruction>? already))
			{
				definitions[local] = already = [];
			}

			already.Add(instruction);
		}

		internal Instruction Move(LocalVariable destination, IOperand source)
			=> new(index++, OpCode.Move, [destination, source]);

		internal Instruction Add(LocalVariable destination, IOperand left, IOperand right)
			=> new(index++, OpCode.Add, [destination, left, right]);

		internal Instruction Multiply(LocalVariable destination)
			=> new(index++, OpCode.Multiply, [destination, Local("i"), new Immediate(12)]);

		internal Instruction Call(LocalVariable destination)
			=> new(index++, OpCode.Call, [destination, new Immediate(0)]);

		internal Instruction Phi(LocalVariable destination, params IOperand[] inputs)
			=> new(index++, OpCode.Phi, [destination, .. inputs]);

		internal string Of(LocalVariable local)
			=> UnresolvedLoadProvenance.Of(
				local,
				candidate => definitions.TryGetValue(candidate, out List<Instruction>? found) ? found : [],
				candidate => arrays.Contains(candidate) ? "TYPED" : null,
				arrays.Contains);
	}
}
