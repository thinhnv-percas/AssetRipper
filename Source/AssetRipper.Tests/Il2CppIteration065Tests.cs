using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// The rules iteration 065 added at the producer layer, each tested without metadata behind it.
/// </summary>
public class Il2CppIteration065Tests
{
	// Which frame the body behind a recorded method pointer names a value type's fields in is a fact of
	// the binary: the adjustor thunk table arrived in metadata 24.5 and 27.1 (not 27.0), and before it
	// the method pointer table held the thunk itself, which takes the boxed object.
	[TestCase(24.1f, true)]
	[TestCase(24.2f, true)]
	[TestCase(24.4f, true)]
	[TestCase(24.5f, false)]
	[TestCase(27.0f, true)]
	[TestCase(27.1f, false)]
	[TestCase(29.0f, false)]
	[TestCase(31.0f, false)]
	public void MethodPointerReceiverFrameFollowsTheAdjustorThunkTable(float version, bool boxed)
	{
		Assert.That(FieldOffsetFrame.MethodPointerReceiverIsBoxed(version), Is.EqualTo(boxed));
	}

	private static Instruction Nop(int index) => new(index, OpCode.Nop);

	/// <summary>entry -> left, right -> join (the return); a write in each of the listed blocks.</summary>
	private static (ISILControlFlowGraph Graph, Block Entry, Block Left, Block Right, Block Join) Diamond()
	{
		Block entry = new() { ID = 0 };
		Block left = new() { ID = 1 };
		Block right = new() { ID = 2 };
		Block join = new() { ID = 3 };

		foreach (var block in new[] { entry, left, right, join })
			block.AddInstruction(Nop(block.ID));

		Link(entry, left);
		Link(entry, right);
		Link(left, join);
		Link(right, join);

		return (new ISILControlFlowGraph([]) { EntryBlock = entry, ExitBlock = join, Blocks = [entry, left, right, join] }, entry, left, right, join);

		static void Link(Block from, Block to)
		{
			from.Successors.Add(to);
			to.Predecessors.Add(from);
		}
	}

	[Test]
	public void ABufferWrittenOnBothBranchesIsWrittenOnEveryPath()
	{
		// The ordinary shape a single dominating write cannot express: two branches each fill the
		// returned struct in and meet at one return.
		var (graph, _, left, right, join) = Diamond();

		Assert.That(LocalVariables.EveryPathWrites(graph, [(left, 0), (right, 0)], join, 0), Is.True);
	}

	[Test]
	public void ABufferWrittenOnOneBranchIsNotWrittenOnEveryPath()
	{
		// `return Other();` on the other branch hands the caller's buffer straight on and writes nothing;
		// returning the local there would return a default value that reads as a real one.
		var (graph, _, left, _, join) = Diamond();

		Assert.That(LocalVariables.EveryPathWrites(graph, [(left, 0)], join, 0), Is.False);
	}

	[Test]
	public void AWriteAfterTheReturnInItsOwnBlockDoesNotCount()
	{
		var (graph, _, _, _, join) = Diamond();

		Assert.Multiple(() =>
		{
			Assert.That(LocalVariables.EveryPathWrites(graph, [(join, 1)], join, 0), Is.False);
			Assert.That(LocalVariables.EveryPathWrites(graph, [(join, 0)], join, 1), Is.True);
		});
	}

	[Test]
	public void AWriteInTheEntryCoversEveryPath()
	{
		var (graph, entry, _, _, join) = Diamond();

		Assert.That(LocalVariables.EveryPathWrites(graph, [(entry, 0)], join, 0), Is.True);
	}

	// Merge-Room 0x17FDEF4: stp x30,x19,[sp,#-16]!; mov x19,x0; bl init; ldr w0,[x19,#0xd8]; cbnz w0,raise;
	// mov x0,x19; ldp x30,x19,[sp],#16; ret; raise: bl; mov x1,xzr; bl; then the next function's prologue.
	private static readonly uint[] ClassInitHelper =
	[
		0xA9BF4FFE, 0xAA0003F3, 0x97FFBC90, 0xB940DA60, 0x35000080, 0xAA1303E0,
		0xA8C14FFE, 0xD65F03C0, 0x940095AD, 0xAA1F03E1, 0x94006EA8, 0xA9BF4FFE,
	];

	private static byte[] Code(uint[] words) => [.. words.SelectMany(BitConverter.GetBytes)];

	[Test]
	public void AHelperThatRestoresItsArgumentOnEveryReturnReturnsIt()
	{
		Assert.That(ArgumentReturningHelper.ReturnsFirstArgument(Code(ClassInitHelper)), Is.True);
	}

	[Test]
	public void ReturningAnotherCalleeSavedRegisterIsNotProven()
	{
		var words = (uint[])ClassInitHelper.Clone();
		words[5] = 0xAA1403E0; // mov x0, x20
		Assert.That(ArgumentReturningHelper.ReturnsFirstArgument(Code(words)), Is.False);
	}

	[Test]
	public void AWriteToTheSavedRegisterIsNotProven()
	{
		var words = (uint[])ClassInitHelper.Clone();
		words[3] = 0xAA0103F3; // mov x19, x1
		Assert.That(ArgumentReturningHelper.ReturnsFirstArgument(Code(words)), Is.False);
	}

	[Test]
	public void ABranchLandingBetweenTheRestoreAndTheReturnIsNotProven()
	{
		var words = (uint[])ClassInitHelper.Clone();
		words[4] = 0x35000040; // cbnz w0, +2 -> lands on the ldp, skipping mov x0, x19
		Assert.That(ArgumentReturningHelper.ReturnsFirstArgument(Code(words)), Is.False);
	}

	[Test]
	public void FallingIntoTheNextFunctionIsNotProven()
	{
		var words = (uint[])ClassInitHelper.Clone();
		words[10] = 0xD503201F; // nop where the noreturn call was
		Assert.That(ArgumentReturningHelper.ReturnsFirstArgument(Code(words)), Is.False);
	}

	private static Register R(string name) => new(null, name);

	// il2cpp's exception bookkeeping on A64: the address of a spilled local is recorded in a frame slot that
	// nothing in the method loads again, then the register is reused.
	private static (ISILControlFlowGraph Graph, Block Block) FrameRecord(params Instruction[] after)
	{
		Block block = new() { ID = 0 };
		block.AddInstruction(new Instruction(0, OpCode.Move, R("X8"), new AddressOf(R("stack_-70"))));
		block.AddInstruction(new Instruction(1, OpCode.Move, R("stack_-80"), R("X8")));
		foreach (var instruction in after)
			block.AddInstruction(instruction);

		return (new ISILControlFlowGraph([]) { EntryBlock = block, ExitBlock = block, Blocks = [block] }, block);
	}

	[Test]
	public void AnAddressOnlyRecordedInAnUnreadSlotCannotBeWrittenThrough()
	{
		var (graph, block) = FrameRecord(new Instruction(2, OpCode.Move, R("X8"), new Immediate(0)));

		Assert.That(SsaForm.OnlyRecordedInUnreadSlots(graph, block, 0), Is.True);
	}

	[Test]
	public void AnAddressRecordedInASlotThatIsReadBackMayBeWrittenThrough()
	{
		var (graph, block) = FrameRecord(
			new Instruction(2, OpCode.Move, R("X8"), new Immediate(0)),
			new Instruction(3, OpCode.Move, R("X26"), R("stack_-80")));

		Assert.That(SsaForm.OnlyRecordedInUnreadSlots(graph, block, 0), Is.False);
	}

	[Test]
	public void AnAddressHandedToACallMayBeWrittenThrough()
	{
		var (graph, block) = FrameRecord(
			new Instruction(2, OpCode.CallVoid, new Immediate(0x1234), R("X8")),
			new Instruction(3, OpCode.Move, R("X8"), new Immediate(0)));

		Assert.That(SsaForm.OnlyRecordedInUnreadSlots(graph, block, 0), Is.False);
	}

	[Test]
	public void AnAddressStillLiveAtTheEndOfItsBlockIsTreatedAsEscaping()
	{
		var (graph, block) = FrameRecord();

		Assert.That(SsaForm.OnlyRecordedInUnreadSlots(graph, block, 0), Is.False);
	}
}
