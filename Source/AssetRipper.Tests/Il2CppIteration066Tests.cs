using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// The rules iteration 066 added, each tested without metadata behind it.
/// </summary>
public class Il2CppIteration066Tests
{
	private const long CctorFinished = 0xE0;
	private const long UnrelatedFlagOffset = 0x135;

	private static Register R(string name) => new(null, name);
	private static LocalVariable L(string name, string register) => new(name, R(register));

	private static void Link(Block from, Block to)
	{
		from.Successors.Add(to);
		to.Predecessors.Add(from);
	}

	private static Block NewBlock(int id, params Instruction[] instructions)
	{
		Block block = new() { ID = id };
		foreach (var instruction in instructions)
			block.AddInstruction(instruction);
		return block;
	}

	private static ISILControlFlowGraph Graph(Block entry, Block exit, params Block[] blocks)
	{
		var graph = new ISILControlFlowGraph([]) { EntryBlock = entry, ExitBlock = exit, Blocks = [entry, .. blocks, exit] };
		foreach (var block in graph.Blocks)
			block.CalculateBlockType();
		return graph;
	}

	/// <summary>
	/// <c>if (klass-&gt;cctor_finished_or_no_cctor == 0) { class_init(klass); rest' } else { rest }</c> - the iOS shape,
	/// with the continuation copied into the init arm. <paramref name="copyCallee"/> lets the copy differ.
	/// </summary>
	private static (ISILControlFlowGraph Graph, Block Guard, Block InitArm, Block Other, LocalVariable Klass) DuplicatedTail(string copyCallee = "Viewport..ctor", long cctorOffset = CctorFinished)
	{
		var self = L("v14", "X19");
		var klass = L("v22", "X0");
		var word = L("v23", "X8");
		var test = L("v24", "TEMP");

		var exit = NewBlock(99);
		var other = NewBlock(4);
		var initArm = NewBlock(8);
		var tail = NewBlock(10);

		var entry = NewBlock(0);
		var guard = NewBlock(3,
			new Instruction(16, OpCode.Move, word, new MemoryOperand(klass, addend: cctorOffset)),
			new Instruction(17, OpCode.CheckEqual, test, word, new Immediate(0)),
			new Instruction(18, OpCode.ConditionalJump, initArm, test));

		other.AddInstruction(new Instruction(20, OpCode.Move, L("v49", "X0"), self));
		other.AddInstruction(new Instruction(21, OpCode.Move, L("v50", "X1"), new Immediate(0)));
		other.AddInstruction(new Instruction(22, OpCode.CallVoid, new StringLiteral("Viewport..ctor"), L("v49", "X0"), L("v50", "X1")));
		other.AddInstruction(new Instruction(23, OpCode.Return));

		initArm.AddInstruction(new Instruction(41, OpCode.Call, new StringLiteral("il2cpp_codegen_runtime_class_init"), L("v60", "X0"), klass));
		initArm.AddInstruction(new Instruction(42, OpCode.Move, L("v63", "X0"), self));
		initArm.AddInstruction(new Instruction(43, OpCode.Move, L("v64", "X1"), new Immediate(0)));
		initArm.AddInstruction(new Instruction(44, OpCode.CallVoid, new StringLiteral(copyCallee), L("v63", "X0"), L("v64", "X1")));
		tail.AddInstruction(new Instruction(52, OpCode.Return));

		Link(entry, guard);
		Link(guard, other);
		Link(guard, initArm);
		Link(initArm, tail);
		Link(other, exit);
		Link(tail, exit);

		return (Graph(entry, exit, guard, other, initArm, tail), guard, initArm, other, klass);
	}

	[Test]
	public void AClassInitGuardOverADuplicatedContinuationFoldsToTheContinuation()
	{
		var (graph, guard, initArm, other, klass) = DuplicatedTail();

		MetadataInitGuardRemover.Run(graph, UnrelatedFlagOffset, CctorFinished, [klass]);

		Assert.That(guard.Successors, Is.EqualTo(new[] { other }));
		Assert.That(graph.Blocks, Does.Not.Contain(initArm), "the init arm nothing enters any more is deleted");
		Assert.That(graph.Blocks.SelectMany(b => b.Instructions).Any(i => i.Operands.OfType<StringLiteral>().Any(s => s.Value.Contains("class_init"))), Is.False);
	}

	[Test]
	public void AnInitArmWhoseCopyCannotBeProvedIsFoldedOnTheWordAloneAndCountedAsSuch()
	{
		// the copy differs, so the duplicated-tail proof does not apply; the word identity still decides, and the
		// fold is counted under the rule that took it so a report can say how many rest on that evidence alone
		var (graph, guard, initArm, other, klass) = DuplicatedTail(copyCallee: "Viewport.Show");
		var provedBefore = MetadataInitGuardRemover.DuplicatedTailGuardsFolded;
		var wordBefore = MetadataInitGuardRemover.ClassInitWordTestsFolded;

		MetadataInitGuardRemover.Run(graph, UnrelatedFlagOffset, CctorFinished, [klass]);

		Assert.That(guard.Successors, Is.EqualTo(new[] { other }));
		Assert.That(graph.Blocks, Does.Not.Contain(initArm));
		Assert.That(MetadataInitGuardRemover.DuplicatedTailGuardsFolded, Is.EqualTo(provedBefore));
		Assert.That(MetadataInitGuardRemover.ClassInitWordTestsFolded, Is.EqualTo(wordBefore + 1));
	}

	[Test]
	public void TheFoldKeepsTheInitialisedSideWhateverTheBranchPolarity()
	{
		// `word != 0` jumping to the continuation: the init arm is the fall-through this time
		var self = L("v14", "X19");
		var klass = L("v22", "X0");
		var word = L("v23", "X8");
		var test = L("v24", "TEMP");
		var negated = L("v25", "TEMP");

		var exit = NewBlock(99);
		var initialised = NewBlock(4, new Instruction(22, OpCode.CallVoid, new StringLiteral("A.M"), self), new Instruction(23, OpCode.Return));
		var initArm = NewBlock(8, new Instruction(44, OpCode.CallVoid, new StringLiteral("A.M2"), self), new Instruction(45, OpCode.Return));
		var entry = NewBlock(0);
		var guard = NewBlock(3,
			new Instruction(16, OpCode.Move, word, new MemoryOperand(klass, addend: CctorFinished)),
			new Instruction(17, OpCode.CheckEqual, test, word, new Immediate(0)),
			new Instruction(18, OpCode.Not, negated, test),
			new Instruction(19, OpCode.ConditionalJump, initialised, negated));

		Link(entry, guard);
		Link(guard, initArm);
		Link(guard, initialised);
		Link(initialised, exit);
		Link(initArm, exit);
		var graph = Graph(entry, exit, guard, initialised, initArm);

		MetadataInitGuardRemover.Run(graph, UnrelatedFlagOffset, CctorFinished, [klass]);

		Assert.That(guard.Successors, Is.EqualTo(new[] { initialised }));
	}

	[Test]
	public void AWordTestAtAnotherOffsetIsNotAClassInitGuard()
	{
		// the offset comes from the measured table; a word compare elsewhere in Il2CppClass is not this guard
		var (graph, guard, initArm, _, klass) = DuplicatedTail(cctorOffset: 0xFC);

		MetadataInitGuardRemover.Run(graph, UnrelatedFlagOffset, CctorFinished, [klass]);

		Assert.That(guard.Successors, Does.Contain(initArm));
	}

	[Test]
	public void WithoutAMeasuredOffsetNothingIsRecognised()
	{
		var (graph, guard, initArm, _, klass) = DuplicatedTail();

		MetadataInitGuardRemover.Run(graph, UnrelatedFlagOffset, null, [klass]);

		Assert.That(guard.Successors, Does.Contain(initArm));
	}

	/// <summary>
	/// The metadata-init guard on A64 with the flag reached through a page base kept in a callee-saved register:
	/// <c>page = 0x302A000; if ((byte)[page + 0xAEC] &amp; 1) == 0 { init_metadata(usage); [page + 0xAEC] = 1; }</c>,
	/// where the skip arm is the remnant of an inner guard that already folded.
	/// </summary>
	private static (ISILControlFlowGraph Graph, Block Guard, Block Forwarding, Block Region, Block Merge) MetadataGuardThroughForwarding(bool storeThroughPage = true)
	{
		var page = L("v16", "X20");
		var flag = L("v17", "X8");
		var masked = L("v20", "TEMP");
		var test = L("v21", "TEMP");
		var one = L("v61", "X8");

		var exit = NewBlock(99);
		var merge = NewBlock(4, new Instruction(29, OpCode.CallVoid, new StringLiteral("Viewport..ctor")), new Instruction(30, OpCode.Return));
		var forwarding = NewBlock(3, new Instruction(16, OpCode.Nop), new Instruction(19, OpCode.Jump, merge));
		var region = NewBlock(6,
			new Instruction(33, OpCode.Call, new StringLiteral("il2cpp_codegen_initialize_runtime_metadata"), L("v27", "X0"), new Immediate(0x2E1B198)),
			new Instruction(34, OpCode.Move, one, new Immediate(1)),
			new Instruction(35, OpCode.Move, storeThroughPage ? new MemoryOperand(page, addend: 0xAEC) : new MemoryOperand(L("v99", "X9"), addend: 0xAEC), one),
			new Instruction(40, OpCode.Jump, merge));
		var entry = NewBlock(0);
		var guard = NewBlock(2,
			new Instruction(9, OpCode.Move, page, new Immediate(0x302A000)),
			new Instruction(10, OpCode.Move, flag, new MemoryOperand(page, addend: 0xAEC)),
			new Instruction(13, OpCode.And, masked, flag, new Immediate(1)),
			new Instruction(14, OpCode.CheckEqual, test, masked, new Immediate(0)),
			new Instruction(15, OpCode.ConditionalJump, region, test));

		Link(entry, guard);
		Link(guard, forwarding);
		Link(guard, region);
		Link(forwarding, merge);
		Link(region, merge);
		Link(merge, exit);

		return (Graph(entry, exit, guard, forwarding, region, merge), guard, forwarding, region, merge);
	}

	[Test]
	public void AMetadataInitGuardIsExcisedThroughTheRemnantOfAFoldedInnerGuard()
	{
		var (graph, guard, forwarding, region, merge) = MetadataGuardThroughForwarding();

		MetadataInitGuardRemover.Run(graph, UnrelatedFlagOffset, CctorFinished, []);

		Assert.That(guard.Successors, Is.EqualTo(new[] { forwarding }));
		Assert.That(graph.Blocks, Does.Not.Contain(region));
		Assert.That(merge.Predecessors, Is.EqualTo(new[] { forwarding }));
	}

	[Test]
	public void AFlagStoreThroughAnAddressNothingNamesDoesNotMakeARegionAGuard()
	{
		// the base of the store is not a constant: it could be any object, so the region has an effect
		var (graph, guard, _, region, _) = MetadataGuardThroughForwarding(storeThroughPage: false);

		MetadataInitGuardRemover.Run(graph, UnrelatedFlagOffset, CctorFinished, []);

		Assert.That(guard.Successors, Does.Contain(region));
	}

	// ---- dynamic stack allocation (StackAnalyzer) ----

	/// <summary>A one-block method from the instructions given, followed by an empty exit.</summary>
	private static (ISILControlFlowGraph Graph, Instruction[] Instructions) Method(params Instruction[] instructions)
	{
		var body = NewBlock(0, instructions);
		var exit = NewBlock(1);
		Link(body, exit);
		var graph = new ISILControlFlowGraph([]) { EntryBlock = body, ExitBlock = exit, Blocks = [body, exit] };
		body.CalculateBlockType();
		return (graph, instructions);
	}

	private static Instruction I(int index, OpCode opCode, params IOperand[] operands)
	{
		var instruction = new Instruction(index, opCode);
		instruction.SetOperands([.. operands]);
		return instruction;
	}
	private static StackOffset Sp(int offset) => new(offset);

	// sub sp, sp, #0x30; add x29, sp, #0x10; str x0, [sp, #8]
	private static Instruction[] Prologue() =>
	[
		I(0, OpCode.ShiftStack, new Immediate(-0x30)),
		I(1, OpCode.Move, R("X29"), new AddressOf(Sp(0x10))),
		I(2, OpCode.Move, Sp(8), R("X0")),
	];

	// mov x9, sp; sub x8, x9, x10; mov sp, x8
	private static Instruction[] Alloca(int index) =>
	[
		I(index, OpCode.Move, R("X9"), new AddressOf(Sp(0))),
		I(index + 1, OpCode.Subtract, R("X8"), R("X9"), R("X10")),
		I(index + 2, OpCode.ShiftStack, R("X8")),
	];

	private static string? SlotName(IOperand operand) => operand is Register register ? register.Name : null;

	[Test]
	public void AFixedAllocationNamesItsSlotsAsBefore()
	{
		var (graph, code) = Method([.. Prologue(), I(3, OpCode.Move, R("X1"), Sp(8)), I(4, OpCode.ShiftStack, new Immediate(0x30)), I(5, OpCode.Return)]);

		StackAnalyzer.Analyze(graph);

		Assert.That(SlotName(code[2].Operands[0]), Is.EqualTo("stack_-28"));
		Assert.That(SlotName(code[3].Operands[1]), Is.EqualTo("stack_-28"));
		Assert.That(graph.Instructions.Any(i => i.OpCode == OpCode.StackAlloc), Is.False);
	}

	[Test]
	public void ADynamicAllocationIsAStackAllocOfItsSize()
	{
		var (graph, code) = Method([.. Prologue(), .. Alloca(3), I(6, OpCode.Return)]);

		StackAnalyzer.Analyze(graph);

		Assert.That(code[4].OpCode, Is.EqualTo(OpCode.StackAlloc));
		Assert.That(SlotName(code[4].Operands[0]), Is.EqualTo("X8"));
		Assert.That(SlotName(code[4].Operands[1]), Is.EqualTo("X10"));
		Assert.That(code[5] is { OpCode: OpCode.Move, Operands: [Register { Name: StackAnalyzer.DynamicStackPointer }, Register { Name: "X8" }] }, Is.True,
			"the stack pointer is the allocation's result from here on");
	}

	[Test]
	public void AStackOperandAfterTheAllocationIsNotTheFixedSlotAtTheSameOffset()
	{
		// str x0, [sp, #8] before; ldr x1, [sp, #8] after. Before the fix both were stack_-28 - one storage.
		var (graph, code) = Method([.. Prologue(), .. Alloca(3), I(6, OpCode.Move, R("X1"), Sp(8)), I(7, OpCode.Return)]);

		StackAnalyzer.Analyze(graph);

		Assert.That(SlotName(code[2].Operands[0]), Is.EqualTo("stack_-28"));
		Assert.That(code[6].Operands[1] is MemoryOperand { Base: Register { Name: StackAnalyzer.DynamicStackPointer }, Addend: 8 }, Is.True,
			$"read relative to the moved stack pointer, got {code[6].Operands[1]}");
	}

	[Test]
	public void AnAddressTakenAfterTheAllocationIsComputedFromTheMovedStackPointer()
	{
		// add x0, sp, #8 after the allocation is the buffer plus 8, not the address of a fixed local
		var (graph, code) = Method([.. Prologue(), .. Alloca(3), I(6, OpCode.Move, R("X0"), new AddressOf(Sp(8))), I(7, OpCode.Return)]);

		StackAnalyzer.Analyze(graph);

		Assert.That(code[6] is { OpCode: OpCode.Add, Operands: [Register { Name: "X0" }, Register { Name: StackAnalyzer.DynamicStackPointer }, Immediate { Value: 8 }] }, Is.True,
			$"got {code[6]}");
	}

	[Test]
	public void AnAddressTakenBeforeTheAllocationStaysTheFixedLocal()
	{
		var (graph, code) = Method([.. Prologue(), I(3, OpCode.Move, R("X0"), new AddressOf(Sp(8))), .. Alloca(4), I(7, OpCode.Return)]);

		StackAnalyzer.Analyze(graph);

		Assert.That(code[3].Operands[1] is AddressOf { Target: Register { Name: "stack_-28" } }, Is.True, $"got {code[3]}");
	}

	[Test]
	public void TheFramePointerStillNamesTheFixedSlotInsideTheDynamicRegion()
	{
		// ldur x3, [x29, #-8] while the stack pointer has moved: the frame did not move
		var (graph, code) = Method([.. Prologue(), .. Alloca(3), I(6, OpCode.Move, R("X3"), new MemoryOperand(R("X29"), addend: -8)), I(7, OpCode.Return)]);

		StackAnalyzer.Analyze(graph);

		Assert.That(SlotName(code[6].Operands[1]), Is.EqualTo("stack_-28"));
	}

	[TestCase(-0x10, TestName = "AnEpilogueResetFromTheFramePointerEndsTheDynamicRegion(sub sp, x29, #0x10)")]
	public void AnEpilogueResetFromTheFramePointerEndsTheDynamicRegion(int fromFrame)
	{
		// sub sp, x29, #0x10 puts the stack pointer back at the fixed frame; the restore after it is the fixed slot again
		var (graph, code) = Method([.. Prologue(), .. Alloca(3),
			I(6, OpCode.ShiftStack, new Immediate(fromFrame), R("X29")),
			I(7, OpCode.Move, R("X4"), Sp(8)),
			I(8, OpCode.ShiftStack, new Immediate(0x30)),
			I(9, OpCode.Return)]);

		StackAnalyzer.Analyze(graph);

		Assert.That(SlotName(code[7].Operands[1]), Is.EqualTo("stack_-28"));
	}

	[Test]
	public void AMovSpFromTheFramePointerEndsTheDynamicRegion()
	{
		// mov sp, x29 (k = 0) after a frame set up at sp + 0: the restore is the fixed slot
		var (graph, code) = Method([
			I(0, OpCode.ShiftStack, new Immediate(-0x30)),
			I(1, OpCode.Move, R("X29"), new AddressOf(Sp(0))),
			I(2, OpCode.Move, Sp(8), R("X0")),
			.. Alloca(3),
			I(6, OpCode.ShiftStack, new Immediate(0), R("X29")),
			I(7, OpCode.Move, R("X4"), Sp(8)),
			I(8, OpCode.ShiftStack, new Immediate(0x30)),
			I(9, OpCode.Return)]);

		StackAnalyzer.Analyze(graph);

		Assert.That(SlotName(code[7].Operands[1]), Is.EqualTo(SlotName(code[2].Operands[0])));
	}

	[Test]
	public void ASecondAllocationReadsTheMovedStackPointer()
	{
		// mov x9, sp after the first allocation is the first buffer; the second allocation is a StackAlloc too
		var (graph, code) = Method([.. Prologue(), .. Alloca(3), .. Alloca(6), I(9, OpCode.Return)]);

		StackAnalyzer.Analyze(graph);

		Assert.That(code[4].OpCode, Is.EqualTo(OpCode.StackAlloc));
		Assert.That(code[7].OpCode, Is.EqualTo(OpCode.StackAlloc));
	}

	[Test]
	public void ASetOfTheStackPointerThatIsNotAnAllocationStillMovesIt()
	{
		// mov sp, x8 with x8 from somewhere else: no StackAlloc, but nothing after it names a fixed slot
		var (graph, code) = Method([.. Prologue(), I(3, OpCode.Move, R("X8"), R("X5")), I(4, OpCode.ShiftStack, R("X8")),
			I(5, OpCode.Move, R("X1"), Sp(8)), I(6, OpCode.Return)]);

		StackAnalyzer.Analyze(graph);

		Assert.That(graph.Instructions.Any(i => i.OpCode == OpCode.StackAlloc), Is.False);
		Assert.That(code[5].Operands[1] is MemoryOperand { Base: Register { Name: StackAnalyzer.DynamicStackPointer } }, Is.True, $"got {code[5]}");
	}
}
