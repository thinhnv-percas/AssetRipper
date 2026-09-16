using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// Walking a pointer back to what produced it, through the copies and merges that carry it.
/// </summary>
/// <remarks>
/// The first form of <see cref="InterfaceInvokeDataRecovery"/> read only the operand in front of the
/// instruction it was matching and fired on nothing at all: every one of the 592 dispatches it wanted
/// was at least one Move or one Phi away from the call that produced its pointer. These cases are
/// that distance, stated so the walk can be tested without a game behind it.
/// </remarks>
public class Il2CppPointerProvenanceTests
{
	private static LocalVariable Local(string name) => new(name, new Register(null, "X0"));

	private static Instruction Move(int index, LocalVariable destination, IOperand source)
		=> new(index, OpCode.Move, [destination, source]);

	private static Instruction Call(int index, LocalVariable result)
		=> new(index, OpCode.Call, [new Immediate(0xB349B4), result]);

	private static Instruction Phi(int index, LocalVariable destination, params LocalVariable[] inputs)
		=> new(index, OpCode.Phi, [destination, .. inputs]);

	/// <summary>Every definition of each local, which is what the walk is given.</summary>
	private static Func<LocalVariable, IReadOnlyList<Instruction>> Definitions(params Instruction[] instructions)
		=> local => instructions.Where(i => ReferenceEquals(i.Destination, local)).ToList();

	[Test]
	public void AValueUsedWhereItWasMadeIsItsOwnProducer()
	{
		LocalVariable result = Local("v1");
		Instruction call = Call(0, result);

		Assert.That(PointerProvenance.Producer(result, Definitions(call)), Is.SameAs(call));
	}

	[Test]
	public void ACopyIsFollowedToTheProducer()
	{
		LocalVariable result = Local("v1");
		LocalVariable copy = Local("v2");
		Instruction call = Call(0, result);

		Assert.That(PointerProvenance.Producer(copy, Definitions(call, Move(1, copy, result))), Is.SameAs(call));
	}

	[Test]
	public void AChainOfCopiesIsFollowedToTheProducer()
	{
		LocalVariable result = Local("v1");
		LocalVariable first = Local("v2");
		LocalVariable second = Local("v3");
		Instruction call = Call(0, result);

		Assert.That(
			PointerProvenance.Producer(second, Definitions(call, Move(1, first, result), Move(2, second, first))),
			Is.SameAs(call));
	}

	[Test]
	public void AMergeWhoseInputsAgreeAnswersWithWhatTheyAgreeOn()
	{
		// The same value reaching a join by two paths is convergence, and a join is where SSA puts a
		// phi whether or not the inputs came from different places.
		LocalVariable result = Local("v1");
		LocalVariable left = Local("v2");
		LocalVariable right = Local("v3");
		LocalVariable merged = Local("v4");
		Instruction call = Call(0, result);

		Assert.That(
			PointerProvenance.Producer(merged, Definitions(call, Move(1, left, result), Move(2, right, result), Phi(3, merged, left, right))),
			Is.SameAs(call));
	}

	[Test]
	public void AMergeWhoseInputsDisagreeAnswersWithNothing()
	{
		// This is the shape the interface lookup actually has - the helper has an inline fast path,
		// so the pointer is a phi of the helper's result and an address the compiler computed itself.
		// Picking one is the guess the walk exists to avoid, which is why that pass matches forwards.
		LocalVariable slow = Local("v1");
		LocalVariable fast = Local("v2");
		LocalVariable merged = Local("v3");

		Assert.That(
			PointerProvenance.Producer(merged, Definitions(Call(0, slow), Move(1, fast, new Immediate(0x138)), Phi(2, merged, slow, fast))),
			Is.Null);
	}

	[Test]
	public void ALoopCarriedValueTakesTheInputThatIsNotTheLoop()
	{
		// A phi one of whose inputs is the phi's own result is every loop-carried value there is. The
		// cyclic input says nothing rather than disagreeing, or no loop would ever have a producer.
		LocalVariable result = Local("v1");
		LocalVariable merged = Local("v2");
		Instruction call = Call(0, result);

		Assert.That(
			PointerProvenance.Producer(merged, Definitions(call, Phi(1, merged, result, merged))),
			Is.SameAs(call));
	}

	[Test]
	public void AValueNothingDefinedHasNoProducer()
	{
		Assert.That(PointerProvenance.Producer(Local("v1"), Definitions()), Is.Null);
	}

	[Test]
	public void TwoDefinitionsOfOneLocalMustAgree()
	{
		// SSA destruction leaves one definition per merged version, so this is what a phi looks like
		// by the time the late passes run - the same question, without the Phi instruction.
		LocalVariable result = Local("v1");
		Instruction first = Call(0, result);
		Instruction second = Call(1, result);

		Assert.That(PointerProvenance.Producer(result, Definitions(first, second)), Is.Null);
	}

	[Test]
	public void TwoDefinitionsReachingTheSameProducerAgree()
	{
		LocalVariable result = Local("v1");
		LocalVariable merged = Local("v2");
		Instruction call = Call(0, result);

		Assert.That(
			PointerProvenance.Producer(merged, Definitions(call, Move(1, merged, result), Move(2, merged, result))),
			Is.SameAs(call));
	}

	[Test]
	public void ACopyCycleHasNoProducer()
	{
		LocalVariable first = Local("v1");
		LocalVariable second = Local("v2");

		Assert.That(
			PointerProvenance.Producer(first, Definitions(Move(0, first, second), Move(1, second, first))),
			Is.Null);
	}
}
