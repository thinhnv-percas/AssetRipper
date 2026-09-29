using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// Covers <see cref="StorageHazardClassifier"/>: a stack slot held in several IL locals while its
/// address is taken is called a true alias only where the order of events is a fact.
/// </summary>
internal sealed class Il2CppStorageHazardTests
{
	private int index;

	private static LocalVariable Slot(string name) => new(name, new Register(null, "stack_-58", 8));

	private Instruction At(OpCode opCode, params IOperand[] operands) => new(index++, opCode, [.. operands]);

	private static Block BlockOf(int id, params Instruction[] instructions)
	{
		Block block = new() { ID = id };
		foreach (var instruction in instructions)
			block.AddInstruction(instruction);
		return block;
	}

	private static void Link(Block from, Block to)
	{
		from.Successors.Add(to);
		to.Predecessors.Add(from);
	}

	private static StorageHazardKind Classify(params Block[] blocks)
	{
		ISILControlFlowGraph graph = new([]) { EntryBlock = blocks[0], ExitBlock = blocks[^1], Blocks = [.. blocks] };
		var storage = StorageIdentities.Analyze(blocks.SelectMany(block => block.Instructions), [], []);
		var hazards = StorageIdentities.Hazards(storage);
		Assert.That(hazards, Has.Count.EqualTo(1), "the fixture is one hazard");
		return StorageHazardClassifier.Classify(graph, hazards)[0].Kind;
	}

	[Test]
	public void AWriteUnderAnotherNameBeforeTheHandOffIsATrueAlias()
	{
		var before = Slot("v3");
		var after = Slot("v5");
		Block only = BlockOf(0,
			At(OpCode.Move, before, new Immediate(1)),
			At(OpCode.Move, after, new Immediate(2)),
			At(OpCode.CallVoid, new Immediate(0x1000), new AddressOf(before)),
			At(OpCode.Return));

		Assert.That(Classify(only), Is.EqualTo(StorageHazardKind.TrueAlias));
	}

	[Test]
	public void AReadUnderAnotherNameAfterTheHandOffIsATrueAlias()
	{
		// The callee may write through the pointer - an out parameter - and the other name never sees it.
		var taken = Slot("v3");
		var read = Slot("v5");
		Block only = BlockOf(0,
			At(OpCode.Move, read, new Immediate(0)),
			At(OpCode.Move, taken, new Immediate(0)),
			At(OpCode.CallVoid, new Immediate(0x1000), new AddressOf(taken)),
			At(OpCode.Return, read));

		Assert.That(Classify(only), Is.EqualTo(StorageHazardKind.TrueAlias));
	}

	[Test]
	public void ALaterWriteUnderTheTakenNameSettlesTheOrder()
	{
		// The other name is written first and the taken name after it: the pointer names the latest value.
		var taken = Slot("v3");
		var other = Slot("v5");
		Block only = BlockOf(0,
			At(OpCode.Move, other, new Immediate(2)),
			At(OpCode.Move, taken, new Immediate(1)),
			At(OpCode.CallVoid, new Immediate(0x1000), new AddressOf(taken)),
			At(OpCode.Return));

		Assert.That(Classify(only), Is.Not.EqualTo(StorageHazardKind.TrueAlias));
	}

	[Test]
	public void NamesWithNoPathBetweenThemAreNotAliases()
	{
		var taken = Slot("v3");
		var other = Slot("v5");
		Block entry = BlockOf(0, At(OpCode.Nop));
		Block left = BlockOf(1, At(OpCode.Move, taken, new Immediate(1)), At(OpCode.CallVoid, new Immediate(0x1000), new AddressOf(taken)));
		Block right = BlockOf(2, At(OpCode.Move, other, new Immediate(2)), At(OpCode.Return, other));
		Block exit = BlockOf(3, At(OpCode.Return));
		Link(entry, left);
		Link(entry, right);
		Link(left, exit);

		Assert.That(Classify(entry, left, right, exit), Is.EqualTo(StorageHazardKind.NonAlias));
	}

	[Test]
	public void APathAcrossBlocksIsNotAnOrder()
	{
		var taken = Slot("v3");
		var other = Slot("v5");
		Block first = BlockOf(0, At(OpCode.Move, taken, new Immediate(1)), At(OpCode.CallVoid, new Immediate(0x1000), new AddressOf(taken)));
		Block second = BlockOf(1, At(OpCode.Return, other));
		Link(first, second);

		Assert.That(Classify(first, second), Is.EqualTo(StorageHazardKind.Unknown));
	}
}
