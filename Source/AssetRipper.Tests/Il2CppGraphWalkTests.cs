using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// The two walks over a control flow graph, and the difference between them.
/// </summary>
/// <remarks>
/// <see cref="ISILControlFlowGraph.Instructions"/> is a breadth-first walk from the entry block, so a
/// block nothing reaches is silently absent from it - while code generation emits every block in
/// <see cref="ISILControlFlowGraph.Blocks"/>. A pass written against the walk therefore leaves those
/// instructions untouched and the generator emits them raw, which reads much later as an operand
/// nothing ever tried to resolve. <see cref="ISILControlFlowGraph.AllInstructions"/> is the walk that
/// matches what is emitted.
/// </remarks>
public class Il2CppGraphWalkTests
{
	private static Instruction Nop(int index) => new(index, OpCode.Nop);

	private static ISILControlFlowGraph TwoBlocks(bool linked)
	{
		Block entry = new() { ID = 0 };
		entry.AddInstruction(Nop(0));

		Block second = new() { ID = 1 };
		second.AddInstruction(Nop(1));

		if (linked)
		{
			entry.Successors.Add(second);
			second.Predecessors.Add(entry);
		}

		// Built empty and populated directly: the constructor splits a linear instruction list into
		// blocks and always links them, which is the one shape this test has to be able to avoid.
		return new ISILControlFlowGraph([])
		{
			EntryBlock = entry,
			ExitBlock = second,
			Blocks = [entry, second],
		};
	}

	[Test]
	public void ReachableBlock_IsInBothWalks()
	{
		ISILControlFlowGraph graph = TwoBlocks(linked: true);

		Assert.Multiple(() =>
		{
			Assert.That(graph.Instructions, Has.Count.EqualTo(2));
			Assert.That(graph.AllInstructions.Count(), Is.EqualTo(2));
		});
	}

	[Test]
	public void UnreachableBlock_IsMissedByTheBreadthFirstWalk()
	{
		ISILControlFlowGraph graph = TwoBlocks(linked: false);

		// The premise of the whole distinction: the walk a pass uses does not see this instruction.
		Assert.That(graph.Instructions, Has.Count.EqualTo(1));
	}

	[Test]
	public void UnreachableBlock_IsCoveredByAllInstructions()
	{
		ISILControlFlowGraph graph = TwoBlocks(linked: false);

		Assert.That(graph.AllInstructions.Count(), Is.EqualTo(2));
	}

	[Test]
	public void AllInstructions_FollowsBlockOrderRatherThanEdges()
	{
		// Block order is what code generation emits in, so a pass that wants to cover what is emitted
		// has to be in that order too - a breadth-first walk reorders as soon as a graph branches.
		ISILControlFlowGraph graph = TwoBlocks(linked: true);

		Assert.That(graph.AllInstructions.Select(instruction => instruction.Index), Is.EqualTo(new[] { 0, 1 }));
	}
}
