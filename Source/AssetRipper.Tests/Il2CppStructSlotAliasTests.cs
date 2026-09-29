using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// Covers <see cref="StructSlotAliasRecovery"/>: a word inside a stack struct whose address is handed to
/// a call is a field of that struct once the call has run.
/// </summary>
/// <remarks>
/// The fixture is <c>foreach</c> over a list: a 24-byte enumerator at <c>stack_-48</c>, its element
/// word at <c>stack_-38</c>, <c>MoveNext(&amp;stack_-48)</c>, then a read of the element. Before the pass
/// the read saw the element as it was before the first <c>MoveNext</c>.
/// </remarks>
internal sealed class Il2CppStructSlotAliasTests
{
	private int index;

	private static readonly LocalVariable Element = new("current", new Register(null, "_current"));

	private readonly LocalVariable enumerator = new("e", new Register(null, "stack_-48"));
	private readonly LocalVariable word = new("w", new Register(null, "stack_-38"));
	private readonly LocalVariable pointer = new("p", new Register(null, "X0"));
	private readonly LocalVariable read = new("r", new Register(null, "X1"));

	private Instruction At(OpCode opCode, params IOperand[] operands) => new(index++, opCode, [.. operands]);

	private Instruction MoveNext() => At(OpCode.Call, new Immediate(0x1000), new LocalVariable("b", new Register(null, "X0")), pointer);

	private static Block BlockOf(params Instruction[] instructions) => new() { Instructions = [.. instructions] };

	private static void Link(Block from, Block to)
	{
		from.Successors.Add(to);
		to.Predecessors.Add(from);
	}

	private void Run(params Block[] blocks)
	{
		ISILControlFlowGraph graph = new([]);
		graph.Blocks.Clear();
		graph.Blocks.AddRange(blocks);
		graph.EntryBlock = blocks[0];
		graph.ExitBlock = blocks[^1];

		StructSlotAliasRecovery.Apply(graph, new DominatorInfo(graph),
			slot => ReferenceEquals(slot, enumerator) ? 24 : null,
			(slot, offset) => offset is 0x10 or 0x18 ? Element : null, // 0x18 answers so only the size bound can reject it
			(_, _) => null,
			(member, source) => ReferenceEquals(member, Element) && ReferenceEquals(source, StaleElement));
	}

	/// <summary>The element as the call returned it, before any MoveNext: what the word was a copy of.</summary>
	private static readonly LocalVariable StaleElement = new("ret._current", new Register(null, "FIELD"));

	[Test]
	public void TheElementReadAfterMoveNextIsTheStructsField()
	{
		Block entry = BlockOf(At(OpCode.Move, word, StaleElement), At(OpCode.Move, pointer, new AddressOf(enumerator)));
		Block header = BlockOf(MoveNext());
		Block body = BlockOf(At(OpCode.Move, read, word));
		Link(entry, header);
		Link(header, body);
		Link(body, header);

		Run(entry, header, body);

		Assert.That(body.Instructions[0].Operands[1], Is.SameAs(Element));
	}

	[Test]
	public void AWordWithNoDefinitionIsNotAssumedToBeTheMember()
	{
		// Nothing says this word was ever the element; it stays what it was rather than becoming a guess.
		Block only = BlockOf(At(OpCode.Move, pointer, new AddressOf(enumerator)), MoveNext(), At(OpCode.Move, read, word));

		Run(only);

		Assert.That(only.Instructions[2].Operands[1], Is.SameAs(word));
	}

	[Test]
	public void AWordCopiedFromSomethingElseIsNotTheMember()
	{
		Block only = BlockOf(At(OpCode.Move, word, new Immediate(0)), At(OpCode.Move, pointer, new AddressOf(enumerator)),
			MoveNext(), At(OpCode.Move, read, word));

		Run(only);

		Assert.That(only.Instructions[3].Operands[1], Is.SameAs(word));
	}

	[Test]
	public void AReadBeforeTheHandOffIsLeftAlone()
	{
		Block only = BlockOf(At(OpCode.Move, word, StaleElement), At(OpCode.Move, read, word),
			At(OpCode.Move, pointer, new AddressOf(enumerator)), MoveNext());

		Run(only);

		Assert.That(only.Instructions[1].Operands[1], Is.SameAs(word));
	}

	[Test]
	public void AWordWrittenAfterTheHandOffHoldsWhatWasWritten()
	{
		Block only = BlockOf(At(OpCode.Move, pointer, new AddressOf(enumerator)), MoveNext(),
			At(OpCode.Move, word, new Immediate(7)), At(OpCode.Move, read, word));

		Run(only);

		Assert.That(only.Instructions[3].Operands[1], Is.SameAs(word));
	}

	[Test]
	public void AWordOutsideTheStructIsNotItsMember()
	{
		LocalVariable beyond = new("x", new Register(null, "stack_-28"));
		Block only = BlockOf(At(OpCode.Move, beyond, StaleElement), At(OpCode.Move, pointer, new AddressOf(enumerator)),
			MoveNext(), At(OpCode.Move, read, beyond));

		Run(only);

		Assert.That(only.Instructions[3].Operands[1], Is.SameAs(beyond), "stack_-28 is 0x20 past a 24-byte struct");
	}

	[Test]
	public void AReadOnABranchTheHandOffDoesNotDominateIsLeftAlone()
	{
		Block entry = BlockOf(At(OpCode.Move, word, StaleElement));
		Block left = BlockOf(At(OpCode.Move, pointer, new AddressOf(enumerator)), MoveNext());
		Block right = BlockOf(At(OpCode.Move, read, word));
		Link(entry, left);
		Link(entry, right);

		Run(entry, left, right);

		Assert.That(right.Instructions[0].Operands[1], Is.SameAs(word));
	}

	[Test]
	public void ASlotCopiedFromTheFirstFieldOfAReturnedStructIsTheWholeStruct()
	{
		// The enumerator is copied out of its return buffer through a vector register; the copy of word
		// zero is also the copy of the whole struct, which is what MoveNext is handed.
		LocalVariable returned = new("ret", new Register(null, "X0"));
		LocalVariable vector = new("q", new Register(null, "V0"));
		IOperand firstField = new LocalVariable("ret._list", new Register(null, "FIELD"));
		Block only = BlockOf(At(OpCode.Move, vector, firstField), At(OpCode.Move, enumerator, vector),
			At(OpCode.Move, pointer, new AddressOf(enumerator)), MoveNext());

		ISILControlFlowGraph graph = new([]);
		graph.Blocks.Clear();
		graph.Blocks.Add(only);
		graph.EntryBlock = graph.ExitBlock = only;
		StructSlotAliasRecovery.Apply(graph, new DominatorInfo(graph),
			slot => ReferenceEquals(slot, enumerator) ? 24 : null,
			(_, _) => null,
			(_, source) => ReferenceEquals(source, firstField) ? returned : null,
			(_, _) => false);

		Assert.That(only.Instructions[1].Operands[1], Is.SameAs(returned));
	}

	[Test]
	public void ALoadThroughTheStructsAddressIsItsField()
	{
		// ldr x1, [x0, #0x10] with x0 = &enumerator is the element, before or after any MoveNext.
		Block only = BlockOf(At(OpCode.Move, pointer, new AddressOf(enumerator)),
			At(OpCode.Move, read, new MemoryOperand(pointer, addend: 0x10)), MoveNext());

		Run(only);

		Assert.That(only.Instructions[1].Operands[1], Is.SameAs(Element));
	}

	[Test]
	public void ALoadPastTheStructThroughItsAddressIsLeftAlone()
	{
		Block only = BlockOf(At(OpCode.Move, pointer, new AddressOf(enumerator)),
			At(OpCode.Move, read, new MemoryOperand(pointer, addend: 0x18)), MoveNext());

		Run(only);

		Assert.That(only.Instructions[1].Operands[1], Is.InstanceOf<MemoryOperand>());
	}

	[TestCase("stack_-48", -0x48)]
	[TestCase("stack_20", 0x20)]
	[TestCase("X8", null)]
	public void TheSlotOffsetIsReadFromItsName(string register, long? expected)
		=> Assert.That(StructSlotAliasRecovery.StackOffsetOf(new LocalVariable("v", new Register(null, register))), Is.EqualTo(expected));
}
