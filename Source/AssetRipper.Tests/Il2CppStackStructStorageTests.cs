using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace AssetRipper.Tests;

/// <summary>
/// Iteration 067 §2: <see cref="StackStructStorage"/> - a struct on the stack is one storage.
/// </summary>
/// <remarks>
/// The fixture is an async kickoff as A64 writes it: the state machine at <c>stack_-80</c>, 0x48 bytes, with the state
/// at 0, a 0x18-byte builder at 8, <c>this</c> at 0x20 and an argument at 0x28; zeroed by one run of stores, the builder
/// copied out of the value <c>Create()</c> returned in a 16-byte and an 8-byte chunk, and <c>&amp;sm | 8</c> as the
/// builder's address. Before the pass every member store was dead code.
/// </remarks>
internal sealed class Il2CppStackStructStorageTests
{
	private int index;

	private static LocalVariable Slot(string name, int version) => new($"{name}_v{version}", new Register(null, name, version));

	private static LocalVariable Reg(string name, int version = 1) => new($"{name}_v{version}", new Register(null, name, version));

	private Instruction At(OpCode opCode, params IOperand[] operands) => new(index++, opCode, [.. operands]);

	private sealed class FakeModel : IStackStructModel
	{
		public HashSet<LocalVariable> Typed { get; } = [];
		public LocalVariable? BuilderValue { get; set; }
		public Dictionary<long, IOperand> Members { get; } = [];
		public List<LocalVariable> Retyped { get; } = [];

		public object? StructKey(LocalVariable version) => Typed.Contains(version) ? "StateMachine" : null;

		public long StructSize(LocalVariable version) => 0x48;

		public IOperand? Member(LocalVariable storage, long offset)
		{
			if (offset is not (0 or 8 or 0x20 or 0x28))
				return null;
			if (!Members.TryGetValue(offset, out var member))
				Members[offset] = member = new LocalVariable($"sm.member{offset:X}", new Register(null, $"member{offset:X}"));
			return member;
		}

		public long MemberSize(LocalVariable storage, long offset) => offset switch { 0 => 4, 8 => 0x18, 0x20 or 0x28 => 8, _ => 0 };

		public (long Start, long Size)? StructMemberContaining(LocalVariable storage, long offset)
			=> offset is >= 8 and < 0x20 ? (8, 0x18) : null;

		public bool HoldsMember(LocalVariable storage, long offset, LocalVariable source) => offset == 8 && ReferenceEquals(source, BuilderValue);

		public TypeAnalysisContext? AddressType(LocalVariable storage, long offset) => null;

		public void Retype(LocalVariable version, LocalVariable typed) => Retyped.Add(version);
	}

	private sealed class Kickoff
	{
		public required Block Zeroing;
		public required Block Body;
		public required LocalVariable StorageZeroed;
		public required LocalVariable Storage;
		public required LocalVariable Builder;
		public required LocalVariable BuilderAddress;
		public required FakeModel Model;
		public required ISILControlFlowGraph Graph;
		public required Dictionary<Instruction, int> Widths;

		public int Apply() => StackStructStorage.Apply(Graph, Model, instruction => Widths.TryGetValue(instruction, out var width) ? width : 0);
	}

	private Kickoff Build(bool readInteriorByName = false, bool gapInCopy = false, bool otherSource = false, int orConstant = 8, int thisStoreWidth = 8)
	{
		var zero = Reg("V0");
		var storageZeroed = Slot("stack_-80", 1);
		var storage = Slot("stack_-80", 2);
		var builder = Reg("X0", 5);
		var other = Reg("X0", 9);
		var chunk0 = Slot("stack_-98", 1);
		var chunk2 = Slot("stack_-88", 1);
		var vector = Reg("V0", 2);
		var x9 = Reg("X9");
		var address = Reg("X8", 5);
		var builderAddress = Reg("X20", 2);
		var self = Reg("X19");
		var argument = Reg("X20");
		var state = Reg("X10");

		Block zeroing = new()
		{
			Instructions =
			[
				At(OpCode.Move, zero, new Immediate(0)),
				At(OpCode.Move, Slot("stack_-40", 1), new Immediate(0)),
				At(OpCode.Move, Slot("stack_-60", 1), zero),
				At(OpCode.Move, Slot("stack_-50", 1), zero),
				At(OpCode.Move, storageZeroed, zero),
				At(OpCode.Move, Slot("stack_-70", 1), zero),
			],
		};

		List<Instruction> body =
		[
			At(OpCode.Call, new Immediate(0x1000), builder),
			At(OpCode.Move, chunk0, new MemoryOperand(builder, addend: 0)),
			At(OpCode.Move, chunk2, new MemoryOperand(otherSource ? other : builder, addend: gapInCopy ? 0x14 : 0x10)),
			At(OpCode.Move, vector, chunk0),
			At(OpCode.Move, x9, chunk2),
			At(OpCode.Move, address, new AddressOf(storageZeroed)),
			At(OpCode.Move, Slot("stack_-60", 2), self),
			At(OpCode.Move, Slot("stack_-58", 1), argument),
			At(OpCode.Or, builderAddress, address, new Immediate(orConstant)),
			At(OpCode.Move, state, new Immediate(-1)),
			At(OpCode.Move, Slot("stack_-78", 1), vector),
			At(OpCode.Move, gapInCopy ? Slot("stack_-64", 1) : Slot("stack_-68", 1), x9),
			At(OpCode.Move, storage, state),
			At(OpCode.CallVoid, new Immediate(0x2000), builderAddress, new AddressOf(storage)),
		];
		if (readInteriorByName)
			body.Add(At(OpCode.Move, Reg("X1", 7), Slot("stack_-60", 2)));
		body.Add(At(OpCode.Return));

		Block code = new() { Instructions = body };
		zeroing.Successors.Add(code);
		code.Predecessors.Add(zeroing);

		ISILControlFlowGraph graph = new([]);
		graph.Blocks.Clear();
		graph.Blocks.AddRange([zeroing, code]);
		graph.EntryBlock = zeroing;
		graph.ExitBlock = code;

		FakeModel model = new() { BuilderValue = builder };
		model.Typed.Add(storage);

		// the widths the instructions wrote: str x, str x, str q, str x, str w
		Dictionary<Instruction, int> widths = [];
		foreach (var instruction in body)
		{
			if (instruction.Destination is LocalVariable { Register.Name: var slot })
			{
				widths[instruction] = slot switch
				{
					"stack_-60" => thisStoreWidth,
					"stack_-58" or "stack_-68" or "stack_-64" => 8,
					"stack_-78" => 16,
					"stack_-80" => 4,
					_ => 0,
				};
			}
		}

		return new Kickoff
		{
			Zeroing = zeroing, Body = code, StorageZeroed = storageZeroed, Storage = storage, Builder = builder,
			BuilderAddress = builderAddress, Model = model, Graph = graph, Widths = widths,
		};
	}

	private static string? NameOf(IOperand operand) => (operand as LocalVariable)?.Name;

	private static Instruction StoreInto(Block block, string slot)
		=> block.Instructions.First(i => i.Destination is LocalVariable { Register.Name: var name } && name == slot);

	[Test]
	public void TheKickoffBecomesMemberStoresIntoOneStorage()
	{
		var k = Build();

		Assert.That(k.Apply(), Is.EqualTo(1));

		var members = k.Model.Members;
		var stores = k.Body.Instructions.Where(i => i.OpCode == OpCode.Move && i.Operands[0] is LocalVariable { Name: var n } && n.StartsWith("sm.", StringComparison.Ordinal))
			.ToDictionary(i => ((LocalVariable)i.Operands[0]).Name, i => i.Operands[1]);

		Assert.Multiple(() =>
		{
			Assert.That(NameOf(stores["sm.member20"]), Is.EqualTo("X19_v1"), "this");
			Assert.That(NameOf(stores["sm.member28"]), Is.EqualTo("X20_v1"), "the argument");
			Assert.That(stores["sm.member8"], Is.SameAs(k.Builder), "the builder is the value Create returned, copied whole");
			Assert.That(NameOf(stores["sm.member0"]), Is.EqualTo("X10_v1"), "the state is the first member, not the struct");
			Assert.That(k.Body.Instructions.Count(i => i.Destination is LocalVariable { Register.Name: "stack_-68" }), Is.Zero, "the second chunk is part of the copy");
		});

		var orInstruction = k.Body.Instructions.Single(i => ReferenceEquals(i.Destination, k.BuilderAddress));
		Assert.That(orInstruction.OpCode, Is.EqualTo(OpCode.Move));
		Assert.That(orInstruction.Operands[1] is AddressOf { Target: var target } && ReferenceEquals(target, members[8]), "&sm | 8 is &sm.builder");

		var zeroRoot = StoreInto(k.Zeroing, "stack_-80");
		Assert.That(zeroRoot.Operands[1], Is.EqualTo(new Immediate(0)), "the zeroing is the struct's initobj");
		Assert.That(k.Zeroing.Instructions.Count(i => i.Destination is LocalVariable { Register.Name: "stack_-70" or "stack_-60" or "stack_-50" or "stack_-40" }), Is.Zero,
			"the rest of the zero run is the same initobj");
		Assert.That(k.Model.Retyped, Does.Contain(k.StorageZeroed), "every version of the slot is the one storage");
	}

	[Test]
	public void AnInteriorSlotReadByNameIsSomethingElseAndNothingChanges()
	{
		var k = Build(readInteriorByName: true);
		Assert.That(k.Apply(), Is.Zero);
		Assert.That(NameOf(StoreInto(k.Body, "stack_-60").Operands[1]), Is.EqualTo("X19_v1"));
		Assert.That(k.Model.Retyped, Is.Empty);
	}

	[Test]
	public void ACopyWhoseChunksDoNotTileTheMemberIsNotACopy()
	{
		var k = Build(gapInCopy: true);
		Assert.That(k.Apply(), Is.Zero);
	}

	[Test]
	public void ACopyFromTwoValuesIsNotACopy()
	{
		var k = Build(otherSource: true);
		Assert.That(k.Apply(), Is.Zero);
	}

	[Test]
	public void AnOrThatCouldCarryIsNotAnAddition()
	{
		// stack_-80 is 16-aligned, so `| 8` adds; `| 0x18` reaches past the alignment and is not known to add
		var k = Build(orConstant: 0x18);
		k.Apply();
		var orInstruction = k.Body.Instructions.Single(i => ReferenceEquals(i.Destination, k.BuilderAddress));
		Assert.That(orInstruction.OpCode, Is.EqualTo(OpCode.Or));
	}

	[Test]
	public void ASlotNoVersionTypesAsAStructIsNotOne()
	{
		var k = Build();
		k.Model.Typed.Clear();
		Assert.That(k.Apply(), Is.Zero);
		Assert.That(StoreInto(k.Body, "stack_-80").Operands[0], Is.SameAs(k.Storage));
	}

	[Test]
	public void AWiderStoreOverAMemberIsNotAStoreOfTheMember()
	{
		// A sixteen-byte vector store at a float member's offset writes four floats. Calling it a store of the first
		// is what produced `matrix.m01 = 0f` beside three placeholders on the second fixture.
		var k = Build(thisStoreWidth: 16);
		Assert.That(k.Apply(), Is.Zero);
		Assert.That(NameOf(StoreInto(k.Body, "stack_-60").Operands[0]), Is.EqualTo("stack_-60_v2"));
	}

	[Test]
	public void AStoreOfUnknownWidthIsNotAssumedToFitItsMember()
	{
		var k = Build();
		k.Widths.Clear();
		Assert.That(k.Apply(), Is.Zero);
	}

	[TestCase("stack_-80", -0x80)]
	[TestCase("stack_18", 0x18)]
	[TestCase("stack_-1A8", -0x1A8)]
	[TestCase("X19", null)]
	[TestCase("stack_zz", null)]
	public void ASlotNameReadsBackAsItsOffset(string name, int? offset)
	{
		Assert.That(StackAnalyzer.SlotOffset(name), Is.EqualTo(offset));
	}
}
