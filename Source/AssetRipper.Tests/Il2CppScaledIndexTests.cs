using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// Covers <see cref="ArrayRecovery.ScaledIndexBehind"/>: the index behind a value the compiler scaled
/// by an array's element stride.
/// </summary>
/// <remarks>
/// A shift is only available when the stride is a power of two, and a struct's rarely is - a
/// <c>Vector3</c> is twelve bytes, so DOTween's <c>Vector3ArrayPlugin.EvaluateAndApply</c> lifts to
/// <c>Multiply TEMP, i, 12</c> then <c>Add t, changeValue, TEMP</c>, which a shift-only match never
/// saw. Hitting the metadata stride exactly is what makes either form safe to read as an index; the
/// half that decides *which member* the offset then reaches is
/// <see cref="NestedFieldResolver"/>, covered by its own tests.
/// </remarks>
internal sealed class Il2CppScaledIndexTests
{
	[Test]
	public void AShiftByTheLogOfTheStrideIsAnIndex()
	{
		Fixture fixture = new();

		Assert.That(fixture.Behind(fixture.ShiftLeft(fixture.Index, 2), elementSize: 4), Is.SameAs(fixture.Index));
	}

	[Test]
	public void AMultiplyByTheStrideIsAnIndex()
	{
		// Twelve is not a power of two, so this is the only form a Vector3[] ever takes.
		Fixture fixture = new();

		Assert.That(fixture.Behind(fixture.Multiply(fixture.Index, 12), elementSize: 12), Is.SameAs(fixture.Index));
	}

	[Test]
	public void AMultiplyWithTheFactorOnTheLeftIsAlsoAnIndex()
	{
		Fixture fixture = new();

		Assert.That(fixture.Behind(fixture.MultiplyReversed(12, fixture.Index), elementSize: 12), Is.SameAs(fixture.Index));
	}

	[Test]
	public void TheIndexItselfIsPreservedRatherThanFoldedToAConstant()
	{
		// array[i] must stay array[i]; an index that is a live value is the whole point of the shape.
		Fixture fixture = new();
		IOperand? behind = fixture.Behind(fixture.Multiply(fixture.Index, 12), elementSize: 12);

		Assert.That(behind, Is.InstanceOf<LocalVariable>());
		Assert.That(((LocalVariable)behind!).Name, Is.EqualTo("i"));
	}

	[Test]
	public void AMultiplyByAnythingElseIsNotAnIndexForThisStride()
	{
		// The stride has to be hit on the nose, or an ordinary multiply feeding an add would pass.
		Fixture fixture = new();

		Assert.That(fixture.Behind(fixture.Multiply(fixture.Index, 10), elementSize: 12), Is.Null);
	}

	[Test]
	public void AShiftThatDoesNotProduceTheStrideIsNotAnIndex()
	{
		Fixture fixture = new();

		Assert.That(fixture.Behind(fixture.ShiftLeft(fixture.Index, 3), elementSize: 4), Is.Null);
	}

	[Test]
	public void AValueNothingDefinedIsNotAnIndex()
	{
		Fixture fixture = new();

		Assert.That(fixture.Behind(new LocalVariable("loose", new(null, "X9")), elementSize: 4), Is.Null);
	}

	[Test]
	public void AnUnrelatedOpcodeIsNotAnIndex()
	{
		Fixture fixture = new();

		Assert.That(fixture.Behind(fixture.Add(fixture.Index, 12), elementSize: 12), Is.Null);
	}

	[Test]
	public void AShiftWiderThanTheWordIsRejectedRatherThanWrapped()
	{
		// C# masks a shift count to 63, so this would silently compare 1 against the stride. The guard
		// makes the rejection deliberate; the test pins the intent rather than catching a regression.
		Fixture fixture = new();

		Assert.That(() => fixture.Behind(fixture.ShiftLeft(fixture.Index, 64), elementSize: 4), Throws.Nothing);
		Assert.That(fixture.Behind(fixture.ShiftLeft(fixture.Index, 64), elementSize: 4), Is.Null);
	}

	private sealed class Fixture
	{
		private int next;
		private readonly Dictionary<LocalVariable, Instruction> definitions = [];

		public LocalVariable Index { get; } = new("i", new(null, "X10"));

		public LocalVariable ShiftLeft(IOperand index, long shift) => Define(OpCode.ShiftLeft, index, new Immediate(shift));

		public LocalVariable Multiply(IOperand index, long factor) => Define(OpCode.Multiply, index, new Immediate(factor));

		public LocalVariable MultiplyReversed(long factor, IOperand index) => Define(OpCode.Multiply, new Immediate(factor), index);

		public LocalVariable Add(IOperand index, long addend) => Define(OpCode.Add, index, new Immediate(addend));

		private LocalVariable Define(OpCode opCode, IOperand left, IOperand right)
		{
			LocalVariable destination = new($"scaled{next}", new(null, "TEMP"));
			Instruction instruction = new(next++, opCode);
			instruction.SetOperands(destination, left, right);
			definitions[destination] = instruction;
			return destination;
		}

		public IOperand? Behind(LocalVariable scaled, long elementSize)
			=> ArrayRecovery.ScaledIndexBehind(scaled, elementSize, definitions);
	}
}
