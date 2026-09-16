using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace AssetRipper.Tests;

/// <summary>
/// What a function pointer read out of memory is, split by where the pointer it was read through
/// came from.
/// </summary>
/// <remarks>
/// "Loaded pointer" is a symptom. On the test game it covered 188 indirect calls, and refining it
/// said 124 of them were produced by a call into the il2cpp runtime - an external boundary rather
/// than a type-recovery failure - against 2 that read a <c>MethodInfo</c>'s own entry point. The
/// families want opposite work, which is the whole reason for the split.
/// </remarks>
public class Il2CppLoadedPointerKindTests
{
	private static LocalVariable Local(string name, TypeAnalysisContext? type = null)
		=> new(name, new Register(null, "X0"), type);

	private static Instruction Call(int index, LocalVariable result)
		=> new(index, OpCode.Call, [new Immediate(0xB349B4), result]);

	private static Instruction Move(int index, LocalVariable destination, IOperand source)
		=> new(index, OpCode.Move, [destination, source]);

	/// <summary>Nothing in these cases has a typed base, so the metadata half is never consulted.</summary>
	private static string Classify(MemoryOperand load, params Instruction[] instructions)
		=> LoadedPointerKind.Of(
			load,
			local => instructions.Where(i => ReferenceEquals(i.Destination, local)).ToList(),
			(_, _) => throw new InvalidOperationException("no typed base in this case"));

	[Test]
	public void AnAbsoluteAddressIsNative()
	{
		// No base at all: the address was in the instruction, so nothing in this method points there.
		Assert.That(Classify(new MemoryOperand(null, null, 0x1854E70, 0)), Is.EqualTo(LoadedPointerKind.NativePointer));
	}

	[Test]
	public void APointerThatCameBackFromAnUnresolvedCallIsNative()
	{
		// A resolved call has a return type, which would have typed the base. Reaching here means the
		// callee is runtime code, and what it points into is its business rather than this method's.
		LocalVariable result = Local("v1");

		Assert.That(
			Classify(new MemoryOperand(result, null, 0, 0), Call(0, result)),
			Is.EqualTo(LoadedPointerKind.NativePointer));
	}

	[Test]
	public void APointerLoadedThroughAPointerIsWhateverTheInnerOneWas()
	{
		// The shape the reflection helper produces on the test game: call, load the object's class
		// through the result, then call through a slot of that. Stopping at the outer load would
		// answer with the label being refined.
		LocalVariable result = Local("v1");
		LocalVariable through = Local("v2");

		Assert.That(
			Classify(
				new MemoryOperand(through, null, 0x1A8, 0),
				Call(0, result),
				Move(1, through, new MemoryOperand(result, null, 0, 0))),
			Is.EqualTo(LoadedPointerKind.NativePointer));
	}

	[Test]
	public void APointerNothingDefinedIsTheRegistersEntryValue()
	{
		// Routine rather than exotic: an unresolved call keeps the whole register file as its
		// arguments, so a register nothing wrote still looks defined to everything downstream.
		Assert.That(
			Classify(new MemoryOperand(Local("v1"), null, 0, 0)),
			Is.EqualTo(LoadedPointerKind.Unknown + ":ENTRY_VALUE"));
	}

	[Test]
	public void TwoProducersThatDisagreeAreReportedAsThatRatherThanAsOneOfThem()
	{
		LocalVariable pointer = Local("v1");

		Assert.That(
			Classify(new MemoryOperand(pointer, null, 0, 0), Call(0, pointer), Call(1, pointer)),
			Is.EqualTo(LoadedPointerKind.Unknown + ":PRODUCERS_DISAGREE"));
	}

	[Test]
	public void AnArrayElementNamesTheArray()
	{
		LocalVariable pointer = Local("v1");
		LocalVariable array = Local("v2");

		Assert.That(
			Classify(new MemoryOperand(pointer, null, 0, 0), Move(0, pointer, new ArrayAccess(array, new Immediate(0)))),
			Is.EqualTo(LoadedPointerKind.ArrayDataPointer));
	}

	[Test]
	public void AnAddressTakenInThisFrameIsAStackPointer()
	{
		LocalVariable pointer = Local("v1");

		Assert.That(
			Classify(new MemoryOperand(pointer, null, 0, 0), Move(0, pointer, new AddressOf(Local("v2")))),
			Is.EqualTo(LoadedPointerKind.StackPointer));
	}

	[Test]
	public void AProducerWithNoRuleIsNamedByItsOpcode()
	{
		// A family named after a symptom has four times turned out to be several causes, so an
		// opcode the walk has nothing to say about is reported as that opcode rather than folded in
		// with the rest - which is what says whether a rule is missing or there is nothing to say.
		LocalVariable pointer = Local("v1");

		Assert.That(
			Classify(new MemoryOperand(pointer, null, 0, 0), new Instruction(0, OpCode.Box, [pointer, Local("v2")])),
			Is.EqualTo(LoadedPointerKind.Unknown + ":PRODUCED_BY_Box"));
	}

	[Test]
	public void AChainOfLoadsLongerThanTheLimitStops()
	{
		// Without the bound this is unbounded recursion on a cycle of loads, which a real body can
		// have once a loop carries the pointer.
		List<Instruction> instructions = [];
		LocalVariable current = Local("v0");

		for (int i = 1; i <= LoadedPointerKind.DepthLimit + 3; i++)
		{
			LocalVariable next = Local("v" + i);
			instructions.Add(Move(i, next, new MemoryOperand(current, null, 0, 0)));
			current = next;
		}

		Assert.That(
			Classify(new MemoryOperand(current, null, 0, 0), [.. instructions]),
			Is.EqualTo(LoadedPointerKind.Unknown + ":DEPTH"));
	}
}
