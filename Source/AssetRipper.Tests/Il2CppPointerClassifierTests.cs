using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// Covers <see cref="PointerClassifier"/>: what a pointer points into, and how it was built.
/// </summary>
/// <remarks>
/// The distinction these hold down is the one that has cost this project three separate
/// investigations: an array, the address of one of its elements, and an object, which share a static
/// type in the IR and are three different values. A rule that reads a computed element address as the
/// array it was computed from is what puts a pointer into a receiver register and makes it look like a
/// list.
/// </remarks>
internal sealed class Il2CppPointerClassifierTests
{
	private const int ElementsOffset = 0x20;

	private sealed class Fixture
	{
		private readonly Dictionary<LocalVariable, List<Instruction>> _definitions = [];
		private int _index;

		public readonly HashSet<LocalVariable> Parameters = [];
		public readonly HashSet<LocalVariable> StaticStorage = [];
		public readonly HashSet<LocalVariable> RuntimeContext = [];

		public LocalVariable Local(string name, bool isThis = false)
		{
			LocalVariable local = new(name, new Register(null, name, 8)) { IsThis = isThis };
			_definitions[local] = [];
			return local;
		}

		public Instruction Define(LocalVariable destination, OpCode opCode, params IOperand[] operands)
		{
			Instruction instruction = new(_index++, opCode, [destination, .. operands]);
			_definitions[destination].Add(instruction);
			return instruction;
		}

		public readonly HashSet<LocalVariable> Arrays = [];

		public PointerClassification Classify(IOperand operand) => PointerClassifier.Classify(
			operand,
			new PointerClassifier.Facts(
				local => _definitions.TryGetValue(local, out var list) ? list : [],
				Parameters.Contains,
				StaticStorage.Contains,
				RuntimeContext.Contains,
				Arrays.Contains,
				ElementsOffset));
	}

	[Test]
	public void AnArrayIsNotTheAddressOfItsElement()
	{
		Fixture fixture = new();
		var array = fixture.Local("items");
		fixture.Arrays.Add(array);
		var index = fixture.Local("index");
		var scaled = fixture.Local("scaled");
		var element = fixture.Local("element");
		var address = fixture.Local("address");

		fixture.Define(scaled, OpCode.ShiftLeft, index, new Immediate(3));
		fixture.Define(element, OpCode.Add, array, scaled);
		fixture.Define(address, OpCode.Add, element, new Immediate(ElementsOffset));

		Assert.Multiple(() =>
		{
			Assert.That(fixture.Classify(address).Kind, Is.EqualTo(PointerKind.ArrayElement));
			// The array it was computed from is a different value and must not answer the same way.
			Assert.That(fixture.Classify(array).Kind, Is.Not.EqualTo(PointerKind.ArrayElement));
		});
	}

	[Test]
	public void TheReceiverIsTheReceiverThroughAnyNumberOfCopies()
	{
		Fixture fixture = new();
		var receiver = fixture.Local("this", isThis: true);
		var copy = fixture.Local("copy");
		var second = fixture.Local("second");

		fixture.Define(copy, OpCode.Move, receiver);
		fixture.Define(second, OpCode.Move, copy);

		Assert.Multiple(() =>
		{
			Assert.That(fixture.Classify(second).Kind, Is.EqualTo(PointerKind.This));
			Assert.That(fixture.Classify(second).Frame, Is.EqualTo(CoordinateFrame.ObjectRelative));
		});
	}

	[Test]
	public void StaticStorageIsValueRelative()
	{
		Fixture fixture = new();
		var storage = fixture.Local("storage");
		fixture.StaticStorage.Add(storage);

		var classification = fixture.Classify(storage);

		Assert.Multiple(() =>
		{
			Assert.That(classification.Kind, Is.EqualTo(PointerKind.Static));
			Assert.That(classification.Frame, Is.EqualTo(CoordinateFrame.ValueRelative));
		});
	}

	[Test]
	public void WhatTheIrStatesOutranksWhatDefinedIt()
	{
		// A parameter is a parameter even where something also assigned to its register.
		Fixture fixture = new();
		var parameter = fixture.Local("list");
		fixture.Parameters.Add(parameter);
		fixture.Define(parameter, OpCode.Add, parameter, new Immediate(ElementsOffset));

		Assert.That(fixture.Classify(parameter).Kind, Is.EqualTo(PointerKind.Parameter));
	}

	[Test]
	public void AnAllocationIsAnObject()
	{
		Fixture fixture = new();
		var list = fixture.Local("list");
		fixture.Define(list, OpCode.Newobj);

		Assert.That(fixture.Classify(list).Kind, Is.EqualTo(PointerKind.Object));
	}

	[Test]
	public void SeveralDefinitionsAreNotADisagreementToResolveHere()
	{
		Fixture fixture = new();
		var array = fixture.Local("items");
		var merged = fixture.Local("merged");

		fixture.Define(merged, OpCode.Move, array);
		fixture.Define(merged, OpCode.Newobj);

		Assert.That(fixture.Classify(merged).Kind, Is.EqualTo(PointerKind.Unknown));
	}

	[Test]
	public void ElementZeroIsStillAnElement()
	{
		// `array + elementsOffset` with no index is the address of element zero. It is a slot, not
		// the array, and reading it as the array is the offset-zero ambiguity one level out.
		Fixture fixture = new();
		var array = fixture.Local("items");
		fixture.Arrays.Add(array);
		var address = fixture.Local("address");

		fixture.Define(address, OpCode.Add, array, new Immediate(ElementsOffset));

		Assert.That(fixture.Classify(address).Kind, Is.EqualTo(PointerKind.ArrayElement));
	}

	[Test]
	public void AFieldReferenceNamesItsField()
	{
		Fixture fixture = new();
		var list = fixture.Local("list");

		var classification = fixture.Classify(new FieldReference(null!, list, 0x10));

		Assert.Multiple(() =>
		{
			Assert.That(classification.Kind, Is.EqualTo(PointerKind.Field));
			Assert.That(classification.Frame, Is.EqualTo(CoordinateFrame.ObjectRelative));
		});
	}
}
