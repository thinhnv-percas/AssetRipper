using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// Covers <see cref="IndirectReturnBufferRecovery"/>'s control flow reasoning: which reads through a
/// call's hidden return buffer may be renamed to the value the call returned, and which may not.
/// </summary>
/// <remarks>
/// The rewrite is only sound where the read is reached only by way of the call that filled the
/// buffer, so these are stated as facts about dominance rather than about instruction order. A read
/// the analysis cannot place keeps its memory operand: an unresolved load is reported, while a read
/// renamed to the wrong value is silent, and only one of those is recoverable by whoever reads the
/// output.
/// </remarks>
internal sealed class Il2CppIndirectReturnBufferTests
{
	[Test]
	public void AReadAfterTheCallBecomesAFieldOfTheReturnedValue()
	{
		Fixture fixture = new();
		Block block = fixture.Block(
			fixture.TakeAddress(),
			fixture.Call(),
			fixture.Read(0x14));

		fixture.Run(block);

		Assert.That(fixture.BaseOf(block.Instructions[2]), Is.SameAs(fixture.Returned));
	}

	[Test]
	public void TheOffsetIsKept()
	{
		Fixture fixture = new();
		Block block = fixture.Block(fixture.TakeAddress(), fixture.Call(), fixture.Read(0x14));

		fixture.Run(block);

		Assert.That(fixture.AddendOf(block.Instructions[2]), Is.EqualTo(0x14));
	}

	[Test]
	public void AReadBeforeTheCallIsLeftAlone()
	{
		// It is reading whatever the slot held beforehand, which the call says nothing about.
		Fixture fixture = new();
		Block block = fixture.Block(
			fixture.TakeAddress(),
			fixture.Read(0x8),
			fixture.Call());

		fixture.Run(block);

		Assert.That(fixture.BaseOf(block.Instructions[1]), Is.SameAs(fixture.Buffer));
	}

	[Test]
	public void AStoreThroughTheBufferIsLeftAlone()
	{
		// Writing into the buffer is the callee's business and says nothing about what came back.
		Fixture fixture = new();
		Block block = fixture.Block(
			fixture.TakeAddress(),
			fixture.Call(),
			fixture.Write(0x8));

		fixture.Run(block);

		Assert.That(fixture.BaseOf(block.Instructions[2]), Is.SameAs(fixture.Buffer));
	}

	[Test]
	public void AReadOnEveryPathOutOfTheCallIsRecovered()
	{
		Fixture fixture = new();
		Block head = fixture.Block(fixture.TakeAddress(), fixture.Call(), fixture.Jump());
		Block tail = fixture.Block(fixture.Read(0x10));
		Fixture.Link(head, tail);

		fixture.Run(head, tail);

		Assert.That(fixture.BaseOf(tail.Instructions[0]), Is.SameAs(fixture.Returned));
	}

	[Test]
	public void AReadOnAPathThatDoesNotGoThroughTheCallIsLeftAlone()
	{
		// entry -> { filled -> join, bypass -> join }: the call only covers one of the two paths, so
		// the read at the join is not reached only by way of it.
		Fixture fixture = new();
		Block entry = fixture.Block(fixture.Jump());
		Block filled = fixture.Block(fixture.TakeAddress(), fixture.Call(), fixture.Jump());
		Block bypass = fixture.Block(fixture.Jump());
		Block join = fixture.Block(fixture.Read(0x10));
		Fixture.Link(entry, filled);
		Fixture.Link(entry, bypass);
		Fixture.Link(filled, join);
		Fixture.Link(bypass, join);

		fixture.Run(entry, filled, bypass, join);

		Assert.That(fixture.BaseOf(join.Instructions[0]), Is.SameAs(fixture.Buffer),
			"the join is reachable without passing the call, so the buffer's contents are not known there");
	}

	[Test]
	public void ASecondCallThroughTheSameBufferAbandonsIt()
	{
		// The buffer was reused, so a read after the second call could mean either value and nothing
		// here can say which.
		Fixture fixture = new();
		Block block = fixture.Block(
			fixture.TakeAddress(),
			fixture.Call(),
			fixture.Call(),
			fixture.Read(0x10));

		fixture.Run(block);

		Assert.That(fixture.BaseOf(block.Instructions[3]), Is.SameAs(fixture.Buffer));
	}

	[Test]
	public void AWriteToTheSlotUnderItsOwnNameBetweenTheAddressAndTheCallAbandonsTheBuffer()
	{
		// Both names are live on the slot at that point, and which one a later read wanted is no
		// longer decidable - the aliasing problem SSA cannot express.
		Fixture fixture = new();
		Block block = fixture.Block(
			fixture.TakeAddress(),
			fixture.WriteSlotDirectly(),
			fixture.Call(),
			fixture.Read(0x10));

		fixture.Run(block);

		Assert.That(fixture.BaseOf(block.Instructions[3]), Is.SameAs(fixture.Buffer));
	}

	[Test]
	public void ACallThatDoesNotReturnThroughTheBufferIsNotOne()
	{
		Fixture fixture = new() { CallFillsBuffer = false };
		Block block = fixture.Block(fixture.TakeAddress(), fixture.Call(), fixture.Read(0x10));

		fixture.Run(block);

		Assert.That(fixture.BaseOf(block.Instructions[2]), Is.SameAs(fixture.Buffer));
	}

	[Test]
	public void AnIndexedReadIsLeftAlone()
	{
		// [buffer + index*scale] is not a fixed member of the returned value.
		Fixture fixture = new();
		Block block = fixture.Block(fixture.TakeAddress(), fixture.Call(), fixture.IndexedRead());

		fixture.Run(block);

		Assert.That(fixture.BaseOf(block.Instructions[2]), Is.SameAs(fixture.Buffer));
	}

	[Test]
	public void AReadThroughADifferentBufferIsLeftAlone()
	{
		Fixture fixture = new();
		Block block = fixture.Block(fixture.TakeAddress(), fixture.Call(), fixture.ReadThroughOther(0x10));

		fixture.Run(block);

		Assert.That(fixture.BaseOf(block.Instructions[2]), Is.SameAs(fixture.Other));
	}

	/// <summary>Builds the smallest graph that exercises the pass, with one buffer and one call.</summary>
	private sealed class Fixture
	{
		private int next;

		public bool CallFillsBuffer { get; init; } = true;

		public LocalVariable Buffer { get; } = new("buffer", new(null, "X8"));
		public LocalVariable Other { get; } = new("other", new(null, "X9"));
		public LocalVariable Returned { get; } = new("returned", new(null, "X0"));
		public LocalVariable Slot { get; } = new("slot", new(null, "stack_-40"));

		public Instruction TakeAddress() => Move(Buffer, new AddressOf(Slot));

		public Instruction Call()
		{
			// Operand 0 stands in for the callee, which only the predicate looks at.
			Instruction call = new(next++, OpCode.Call);
			call.SetOperands(new Immediate(0), Returned);
			return call;
		}

		public Instruction Read(long addend) => Move(new LocalVariable("read", new(null, "V0")), new MemoryOperand(Buffer, addend: addend));

		public Instruction ReadThroughOther(long addend) => Move(new LocalVariable("read", new(null, "V0")), new MemoryOperand(Other, addend: addend));

		public Instruction IndexedRead()
			=> Move(new LocalVariable("read", new(null, "V0")), new MemoryOperand(Buffer, Other, addend: 0, scale: 4));

		public Instruction Write(long addend)
		{
			Instruction move = new(next++, OpCode.Move);
			move.SetOperands(new MemoryOperand(Buffer, addend: addend), new Immediate(0));
			return move;
		}

		public Instruction WriteSlotDirectly() => Move(Slot, new Immediate(0));

		public Instruction Jump()
		{
			Instruction jump = new(next++, OpCode.Jump);
			return jump;
		}

		private Instruction Move(IOperand destination, IOperand source)
		{
			Instruction move = new(next++, OpCode.Move);
			move.SetOperands(destination, source);
			return move;
		}

		public Block Block(params Instruction[] instructions) => new() { Instructions = [.. instructions] };

		public static void Link(Block from, Block to)
		{
			from.Successors.Add(to);
			to.Predecessors.Add(from);
		}

		public void Run(params Block[] blocks)
		{
			ISILControlFlowGraph graph = new([]);
			graph.Blocks.Clear();
			graph.Blocks.AddRange(blocks);
			graph.EntryBlock = blocks[0];
			graph.ExitBlock = blocks[^1];

			IndirectReturnBufferRecovery.Apply(graph, new DominatorInfo(graph), (_, buffer) => CallFillsBuffer && ReferenceEquals(buffer, Buffer));
		}

		public IOperand? BaseOf(Instruction instruction)
			=> instruction.Operands.OfType<MemoryOperand>().Select(memory => memory.Base).FirstOrDefault();

		public long AddendOf(Instruction instruction)
			=> instruction.Operands.OfType<MemoryOperand>().Select(memory => memory.Addend).First();
	}
}
