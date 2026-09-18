using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// Covers <see cref="InlineListAddRecovery"/>: which inlined fast paths are put back as
/// <c>List&lt;T&gt;.Add</c>, and - the half that matters more - which shapes that look like one are
/// turned down.
/// </summary>
/// <remarks>
/// Recognising the operation wrongly is silent: the region is deleted and a call the program never
/// made takes its place, which no diagnostic reports and no compile error catches. Recognising it
/// too narrowly costs a placeholder that says so. So every shape that merely resembles the fast path
/// - an ordinary array write, a custom collection with the same field names, an indexer setter,
/// <c>Insert</c>, <c>RemoveAt</c>, a dictionary write - is stated here as a fact about what the rule
/// refuses, and the rejection carries a reason rather than being a silent no.
///
/// The metadata questions sit behind <see cref="InlineListAddRecovery.Recognisers"/>, so these run
/// over graphs built by hand with no game behind them.
/// </remarks>
internal sealed class Il2CppInlineListAddTests
{
	[Test]
	public void TheInlinedFastPathBecomesACallToAdd()
	{
		Fixture fixture = new();
		ISILControlFlowGraph graph = fixture.ListAddShape();

		Assert.That(fixture.Run(graph), Is.True);
		Assert.That(fixture.CallTarget, Is.SameAs(Fixture.AddSentinel));
	}

	[Test]
	public void TheFastPathIsNoLongerReached()
	{
		Fixture fixture = new();
		ISILControlFlowGraph graph = fixture.ListAddShape();

		fixture.Run(graph);
		graph.RemoveUnreachableBlocks();

		Assert.That(graph.Blocks, Does.Not.Contain(fixture.Fast));
	}

	[Test]
	public void TheVersionBumpGoesWithTheCallThatPerformsItItself()
	{
		// Add increments _version, so leaving the inlined bump beside the call increments it twice
		// and leaves a write to a private framework field that C# cannot express.
		Fixture fixture = new();
		ISILControlFlowGraph graph = fixture.ListAddShape();

		fixture.Run(graph);

		Assert.That(fixture.VersionBump.OpCode, Is.EqualTo(OpCode.Nop));
	}

	[Test]
	public void AnOrdinaryArrayWriteIsNotAnAdd()
	{
		// The whole shape is there except the anchor: no AddWithResize, so nothing identifies it.
		Fixture fixture = new() { CallIsAddWithResize = false };

		Assert.That(fixture.Run(fixture.ListAddShape()), Is.False);
		Assert.That(InlineOperationRecovery.Candidates, Is.Zero);
	}

	[Test]
	public void ACollectionOfItsOwnWithTheSameFieldNamesIsNotAList()
	{
		// _items, _size and a capacity test are a resizing array, which any collection may be. The
		// framework's own private helper is what says which collection this is.
		Fixture fixture = new() { CallIsAddWithResize = false };
		ISILControlFlowGraph graph = fixture.ListAddShape();

		Assert.That(fixture.Run(graph), Is.False);
		Assert.That(fixture.CallTarget, Is.Not.SameAs(Fixture.AddSentinel));
	}

	[TestCase("Insert")]
	[TestCase("RemoveAt")]
	[TestCase("set_Item")]
	[TestCase("Dictionary.Add")]
	public void AnotherListOperationIsNotAnAdd(string operation)
	{
		// None of these calls AddWithResize, so none of them is even offered to the rule.
		Fixture fixture = new() { CallIsAddWithResize = false, Operation = operation };

		Assert.That(fixture.Run(fixture.ListAddShape()), Is.False);
		Assert.That(InlineOperationRecovery.Candidates, Is.Zero);
	}

	[Test]
	public void TheCapacityTestMustReadTheSameListTheCallDoes()
	{
		// Two lists in one method: the guard tests one and the slow path adds to the other, so the
		// region the rewrite would delete is not this call's fast path.
		Fixture fixture = new() { GuardTestsAnotherList = true };

		Assert.That(fixture.Run(fixture.ListAddShape()), Is.False);
		Assert.That(fixture.Rejections, Has.Some.Contains("size"));
	}

	[Test]
	public void TheBackingArrayMustBeTheSameListsToo()
	{
		Fixture fixture = new() { ItemsComeFromAnotherList = true };

		Assert.That(fixture.Run(fixture.ListAddShape()), Is.False);
		Assert.That(fixture.Rejections, Has.Some.Contains("size compared against"));
	}

	[Test]
	public void AFastPathAnotherEdgeAlsoReachesIsLeftAlone()
	{
		// Deleting it would take code with it that the other edge still needs.
		Fixture fixture = new() { FastPathHasAnotherPredecessor = true };

		Assert.That(fixture.Run(fixture.ListAddShape()), Is.False);
		Assert.That(fixture.Rejections, Has.Some.Contains("fast path has"));
	}

	[Test]
	public void ACallReachedUnconditionallyIsNotAFastPathsSlowHalf()
	{
		// An AddWithResize with no capacity test in front of it has no inlined fast path to fold.
		Fixture fixture = new() { GuardIsUnconditional = true };

		Assert.That(fixture.Run(fixture.ListAddShape()), Is.False);
		Assert.That(fixture.Rejections, Has.Some.Contains("conditional"));
	}

	[Test]
	public void AFastPathThatDoesNotUpdateTheSizeIsNotOne()
	{
		Fixture fixture = new() { FastPathUpdatesSize = false };

		Assert.That(fixture.Run(fixture.ListAddShape()), Is.False);
		Assert.That(fixture.Rejections, Has.Some.Contains("size"));
	}

	[Test]
	public void ARejectionIsAlwaysCountedUnderAReason()
	{
		// A family that matches nothing and a family that is never reached print the same match
		// count, and this project has twice spent an iteration on a pass that never fired.
		Fixture fixture = new() { FastPathUpdatesSize = false };

		fixture.Run(fixture.ListAddShape());

		Assert.That(InlineOperationRecovery.Candidates, Is.EqualTo(1));
		Assert.That(InlineOperationRecovery.Matched, Is.Zero);
		Assert.That(fixture.Rejections, Is.Not.Empty);
	}

	private sealed class Fixture
	{
		/// <summary>Stands in for the List&lt;T&gt;.Add the rewrite retargets onto.</summary>
		public static readonly IOperand AddSentinel = new Immediate(0xADD);

		private static readonly IOperand AddWithResizeSentinel = new Immediate(0xA002);
		private static readonly IOperand OtherCallee = new Immediate(0xBAD);

		private int next;

		public bool CallIsAddWithResize { get; init; } = true;
		public bool GuardTestsAnotherList { get; init; }
		public bool ItemsComeFromAnotherList { get; init; }
		public bool FastPathHasAnotherPredecessor { get; init; }
		public bool GuardIsUnconditional { get; init; }
		public bool FastPathUpdatesSize { get; init; } = true;

		/// <summary>Only ever reported; the rule never sees it.</summary>
		public string Operation { get; init; } = "Add";

		public LocalVariable Receiver { get; } = new("list", new(null, "X0"));
		public LocalVariable Other { get; } = new("other", new(null, "X1"));
		public LocalVariable Items { get; } = new("items", new(null, "X8"));
		public LocalVariable Value { get; } = new("value", new(null, "X2"));
		public LocalVariable Condition { get; } = new("cond", new(null, "NZCV"));
		public LocalVariable Test { get; } = new("test", new(null, "NZCV2"));

		public Block Fast { get; private set; } = null!;
		public Instruction VersionBump { get; private set; } = null!;
		public Instruction Call { get; private set; } = null!;

		public IOperand CallTarget => Call.Operands[0];

		public IReadOnlyCollection<string> Rejections => [.. InlineOperationRecovery.Rejections.Keys];

		public Fixture() => InlineOperationRecovery.ResetCounters();

		/// <summary>
		/// <c>items = list._items; list._version++; if (list._size &lt; items.Length) { list._size++;
		/// items[size] = value; } else list.AddWithResize(value);</c>
		/// </summary>
		public ISILControlFlowGraph ListAddShape()
		{
			LocalVariable sizeOwner = GuardTestsAnotherList ? Other : Receiver;
			LocalVariable itemsOwner = ItemsComeFromAnotherList ? Other : Receiver;

			Instruction loadItems = Move(Items, Field(itemsOwner, "_items"));
			VersionBump = Move(Field(Receiver, "_version"), new Immediate(1));

			Instruction compare = new(next++, OpCode.CheckLess);
			compare.SetOperands(Test, Field(sizeOwner, "_size"), new ArrayLength(Items));

			Instruction invert = new(next++, OpCode.Not);
			invert.SetOperands(Condition, Test);

			Block guard = Block(loadItems, VersionBump, compare, invert);

			Block merge = Block(new Instruction(next++, OpCode.Return));
			Fast = Block(
				FastPathUpdatesSize
					? Move(Field(Receiver, "_size"), new Immediate(1))
					: Move(Field(Other, "_size"), new Immediate(1)),
				Move(new ArrayAccess(Items, new Immediate(0)), Value));

			Call = new Instruction(next++, OpCode.CallVoid);
			Call.SetOperands(CallIsAddWithResize ? AddWithResizeSentinel : OtherCallee, Receiver, Value);
			Block slow = Block(Call);

			Instruction terminator;

			if (GuardIsUnconditional)
			{
				terminator = new Instruction(next++, OpCode.Jump);
				terminator.SetOperands(slow);
			}
			else
			{
				terminator = new Instruction(next++, OpCode.ConditionalJump);
				terminator.SetOperands(slow, Condition);
			}

			guard.AddInstruction(terminator);

			Block entry = Block(new Instruction(next++, OpCode.Nop));
			Link(entry, guard);
			Link(guard, slow);

			if (!GuardIsUnconditional)
				Link(guard, Fast);

			Link(Fast, merge);
			Link(slow, merge);

			if (FastPathHasAnotherPredecessor)
				Link(entry, Fast);

			return new ISILControlFlowGraph([])
			{
				EntryBlock = entry,
				ExitBlock = merge,
				Blocks = [entry, guard, Fast, slow, merge],
			};
		}

		public bool Run(ISILControlFlowGraph graph) => InlineListAddRecovery.Run(graph, null, new()
		{
			IsAddWithResize = operand => ReferenceEquals(operand, AddWithResizeSentinel),
			IsFieldOf = (operand, receiver, name) => operand is MemoryOperand memory
				&& ReferenceEquals(memory.Base, receiver)
				&& memory.Addend == OffsetOf(name),
			AddFor = operand => ReferenceEquals(operand, AddWithResizeSentinel) ? AddSentinel : null,
		});

		/// <summary>A field read, as the addend the resolution would have keyed on.</summary>
		private static MemoryOperand Field(LocalVariable owner, string name) => new(owner, addend: OffsetOf(name));

		private static long OffsetOf(string name) => name switch
		{
			"_items" => 0x10,
			"_size" => 0x18,
			"_version" => 0x1C,
			_ => -1,
		};

		private Instruction Move(IOperand destination, IOperand source)
		{
			Instruction move = new(next++, OpCode.Move);
			move.SetOperands(destination, source);
			return move;
		}

		private static Block Block(params Instruction[] instructions) => new() { Instructions = [.. instructions] };

		private static void Link(Block from, Block to)
		{
			from.Successors.Add(to);
			to.Predecessors.Add(from);
		}
	}
}
