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

	[TestCase(4L)]
	[TestCase(8L)]
	[TestCase(12L)]
	[TestCase(16L)]
	public void AStrideReadAtRunTimeIsNotAnIndexForAnyStride(long elementSize)
	{
		// Iteration 068 (§6): a fully shared generic body indexes T[] with `i * klass->element_size` - a stride
		// the runtime reads out of Il2CppClass (0x104 on 2022.3), whatever T is instantiated with. No static
		// stride is proven, so nothing may fold it to array[i], whichever size the metadata would suggest.
		Fixture fixture = new();
		LocalVariable klass = new("klass", new(null, "X9"));

		Assert.That(fixture.Behind(fixture.MultiplyBy(fixture.Index, new MemoryOperand(baseRegister: klass, addend: 0x104)), elementSize), Is.Null);
		Assert.That(fixture.Behind(fixture.MultiplyBy(fixture.Index, new LocalVariable("stride", new(null, "X11"))), elementSize), Is.Null);
		Assert.That(fixture.Behind(fixture.ShiftLeftBy(fixture.Index, new LocalVariable("shift", new(null, "X12"))), elementSize), Is.Null);
	}

	[Test]
	public void AStrideALoopKeepsInARegisterIsTheStride()
	{
		// Iteration 068: ExtensionMesh.RecalculateNormals reads Vector3[] vertices[triangles[i]] as `triangles[i] * w9` with
		// `mov w9, #12` before the loop and again on its back edge - a phi of one constant, sizeof(Vector3).
		Fixture fixture = new();
		LocalVariable stride = new("stride", new(null, "X9"));
		fixture.Phi(stride, fixture.Constant(12), stride, new Immediate(12));

		Assert.That(fixture.Behind(fixture.MultiplyBy(fixture.Index, stride), elementSize: 12), Is.SameAs(fixture.Index));
		Assert.That(fixture.Behind(fixture.MultiplyBy(stride, fixture.Index), elementSize: 12), Is.SameAs(fixture.Index));
	}

	[Test]
	public void AStrideIsNotProvenByAMergeOfTwoConstants()
	{
		Fixture fixture = new();
		LocalVariable stride = new("stride", new(null, "X9"));
		fixture.Phi(stride, fixture.Constant(12), fixture.Constant(16));

		Assert.That(fixture.Behind(fixture.MultiplyBy(fixture.Index, stride), elementSize: 12), Is.Null);
		Assert.That(fixture.Behind(fixture.MultiplyBy(fixture.Index, stride), elementSize: 16), Is.Null);
	}

	[Test]
	public void AStrideIsNotProvenThroughALocalWithSeveralDefinitions()
	{
		// Out of SSA the map keeps a local's last definition only, so it cannot speak for the others.
		Fixture fixture = new();
		var stride = fixture.Constant(12);
		fixture.DefineAgain(stride);

		Assert.That(fixture.Behind(fixture.MultiplyBy(fixture.Index, stride), elementSize: 12), Is.Null);
	}

	[Test]
	public void AStrideIsNotProvenWithoutKnowingHowManyDefinitionsALocalHas()
	{
		Fixture fixture = new();
		var stride = fixture.Constant(12);

		Assert.That(fixture.BehindWithoutDefinitionCounts(fixture.MultiplyBy(fixture.Index, stride), elementSize: 12), Is.Null);
	}

	[Test]
	public void AStrideCopiedFromALoadIsNotProven()
	{
		Fixture fixture = new();
		LocalVariable stride = new("stride", new(null, "X9"));
		LocalVariable klass = new("klass", new(null, "X10"));
		Instruction load = new(900, OpCode.Move);
		load.SetOperands(stride, new MemoryOperand(baseRegister: klass, addend: 0x104));
		fixture.Record(stride, load);
		LocalVariable copy = new("copy", new(null, "X11"));
		fixture.Phi(copy, stride);

		Assert.That(fixture.Behind(fixture.MultiplyBy(fixture.Index, copy), elementSize: 12), Is.Null);
	}

	[Test]
	public void AnAddPastTheElementsOffsetUnwrapsWithItsWholeConstant()
	{
		// Iteration 068: ExtensionMesh adds 0x24 - the elements offset plus Vector3.y - in its own instruction and loads
		// through the result at offset zero. The whole constant is what the element-address check measures from.
		LocalVariable computed = new("t", new(null, "X11"));
		Assert.Multiple(() =>
		{
			Assert.That(ArrayRecovery.ElementsOffsetAddedSeparately(computed, new Immediate(0x20), 8), Is.EqualTo((computed, 0x20L)));
			Assert.That(ArrayRecovery.ElementsOffsetAddedSeparately(computed, new Immediate(0x24), 8), Is.EqualTo((computed, 0x24L)));
			Assert.That(ArrayRecovery.ElementsOffsetAddedSeparately(new Immediate(0x28), computed, 8), Is.EqualTo((computed, 0x28L)));
			Assert.That(ArrayRecovery.ElementsOffsetAddedSeparately(computed, new Immediate(0x18), 8), Is.Null, "short of the elements offset is the array header");
			Assert.That(ArrayRecovery.ElementsOffsetAddedSeparately(computed, computed, 8), Is.Null);
		});
	}

	private sealed class Fixture
	{
		private int next;
		private readonly ArrayRecovery.DefinitionMap definitions = [];

		public LocalVariable Index { get; } = new("i", new(null, "X10"));

		public LocalVariable ShiftLeft(IOperand index, long shift) => Define(OpCode.ShiftLeft, index, new Immediate(shift));

		public LocalVariable Multiply(IOperand index, long factor) => Define(OpCode.Multiply, index, new Immediate(factor));

		public LocalVariable MultiplyReversed(long factor, IOperand index) => Define(OpCode.Multiply, new Immediate(factor), index);

		public LocalVariable Add(IOperand index, long addend) => Define(OpCode.Add, index, new Immediate(addend));

		public LocalVariable MultiplyBy(IOperand index, IOperand factor) => Define(OpCode.Multiply, index, factor);

		public LocalVariable Constant(long value)
		{
			LocalVariable destination = new($"constant{next}", new(null, "X9"));
			Instruction instruction = new(next++, OpCode.Move);
			instruction.SetOperands(destination, new Immediate(value));
			definitions[destination] = instruction;
			return destination;
		}

		public LocalVariable Phi(LocalVariable destination, params IOperand[] inputs)
		{
			Instruction instruction = new(next++, OpCode.Phi);
			instruction.SetOperands([destination, .. inputs]);
			definitions[destination] = instruction;
			return destination;
		}

		public void DefineAgain(LocalVariable local) => definitions.MultiplyDefined.Add(local);

		public void Record(LocalVariable local, Instruction definition) => definitions[local] = definition;

		public IOperand? BehindWithoutDefinitionCounts(LocalVariable scaled, long elementSize)
			=> ArrayRecovery.ScaledIndexBehind(scaled, elementSize, new Dictionary<LocalVariable, Instruction>(definitions));

		public LocalVariable ShiftLeftBy(IOperand index, IOperand shift) => Define(OpCode.ShiftLeft, index, shift);

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
