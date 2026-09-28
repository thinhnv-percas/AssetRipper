using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// Covers <see cref="InterfaceScanRegionClassifier"/>: a surviving interface offset scan is called
/// dead only with the data and the control flow both proving it.
/// </summary>
/// <remarks>
/// Iteration 060 left 2248 such scans in place on one fixture rather than delete code on a belief.
/// These hold down the three ways the belief can be wrong - a value that reaches an effect, and a
/// branch that decides where the method goes - and the one way it can be right.
/// </remarks>
internal sealed class Il2CppInterfaceScanRegionTests
{
	private const long Count = 0x12E;
	private const long Offsets = 0xB0;

	private int index;
	private readonly LocalVariable klass = Local("klass");

	private static LocalVariable Local(string name) => new(name, new Register(null, name, 8));

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

	private bool IsScan(IOperand operand)
		=> operand is MemoryOperand { Base: LocalVariable local, Addend: var addend } && local == klass && addend is Count or Offsets;

	/// <summary>scan -> (loop body -> merge | merge), with <paramref name="merge"/> given.</summary>
	private List<(InterfaceScanVerdict Verdict, int Instructions, int Loads)> Scan(Func<LocalVariable, Instruction[]> merge, bool divergent = false)
	{
		var count = Local("count");
		var flag = Local("flag");
		var pointer = Local("pointer");

		Block entry = BlockOf(0, At(OpCode.Nop));
		Block scan = BlockOf(1,
			At(OpCode.Move, count, new MemoryOperand(klass, addend: Count)),
			At(OpCode.CheckEqual, flag, count, new Immediate(0)),
			At(OpCode.ConditionalJump, new Immediate(3), flag));
		// The loop step increments in place: one local object as both destination and source.
		Block body = BlockOf(2,
			At(OpCode.Move, pointer, new MemoryOperand(klass, addend: Offsets)),
			At(OpCode.Add, pointer, pointer, new Immediate(16)),
			At(OpCode.Jump, new Immediate(3)));
		Block join = BlockOf(3, merge(pointer));
		Block other = BlockOf(4, At(OpCode.CallVoid, new Immediate(0x2000)));
		Block exit = BlockOf(5, At(OpCode.Return));

		Link(entry, scan);
		Link(scan, body);
		Link(scan, divergent ? other : join);
		Link(body, join);
		Link(join, exit);
		Link(other, exit);

		ISILControlFlowGraph graph = new([]) { EntryBlock = entry, ExitBlock = exit, Blocks = [entry, scan, body, join, other, exit] };
		return InterfaceScanRegionClassifier.Classify(graph, IsScan);
	}

	[Test]
	public void AScanNothingReadsAndThatReconvergesIsProvenDead()
	{
		var result = Scan(_ => [At(OpCode.CallVoid, new Immediate(0x1000))]);

		Assert.Multiple(() =>
		{
			Assert.That(result, Has.Count.EqualTo(1), "one region per scanned class pointer");
			Assert.That(result[0].Verdict, Is.EqualTo(InterfaceScanVerdict.DeadRegionProven));
			Assert.That(result[0].Loads, Is.EqualTo(2));
		});
	}

	[Test]
	public void AScanWhoseValueReachesACallIsNotDead()
	{
		var result = Scan(pointer => [At(OpCode.CallVoid, new Immediate(0x1000), pointer)]);

		Assert.That(result[0].Verdict, Is.EqualTo(InterfaceScanVerdict.ValueEscapes));
	}

	[Test]
	public void AScanWhoseBranchLeadsTwoWaysDecidesSomething()
	{
		var result = Scan(_ => [At(OpCode.CallVoid, new Immediate(0x1000))], divergent: true);

		Assert.That(result[0].Verdict, Is.EqualTo(InterfaceScanVerdict.ControlDiverges));
	}

	[Test]
	public void AStoreOfAScanValueIsAnEffect()
	{
		var target = Local("target");
		var result = Scan(pointer => [At(OpCode.Move, new MemoryOperand(target, addend: 0x10), pointer)]);

		Assert.That(result[0].Verdict, Is.EqualTo(InterfaceScanVerdict.ValueEscapes));
	}
}
