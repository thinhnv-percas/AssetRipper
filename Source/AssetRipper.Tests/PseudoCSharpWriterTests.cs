using AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// Covers the reconstruction text attached to methods IL recovery could not express.
/// </summary>
/// <remarks>
/// The text competes for a per-assembly character budget, so noise costs coverage as well as
/// readability: bookkeeping written out for one method is reconstruction another method does not get.
/// </remarks>
internal sealed class PseudoCSharpWriterTests
{
	private static Register Reg(string name) => new(null, name, 0);

	private static Instruction Make(int index, OpCode opCode, params IOperand[] operands)
		=> new(index, opCode, [.. operands]);

	private static string Write(params Instruction[] instructions)
	{
		// The writer only needs the instruction list, which a caller normally gets from a method.
		PseudoCSharpWriter writer = new(annotator: null);
		return writer.WriteInstructions([.. instructions]);
	}

	/// <summary>
	/// A comparison into a condition-code register exists only for the branch that reads it, and the
	/// branch prints its own condition.
	/// </summary>
	[Test]
	public void FlagRegisterComparisonsAreDropped()
	{
		string text = Write(
			Make(0, OpCode.CheckEqual, Reg("Z"), Reg("X0"), new Immediate(0)),
			Make(1, OpCode.Subtract, Reg("TEMP_v3"), Reg("X1"), Reg("X2")),
			Make(2, OpCode.Move, Reg("X8"), Reg("X9")));

		Assert.Multiple(() =>
		{
			Assert.That(text, Does.Not.Contain("Z ="));
			Assert.That(text, Does.Not.Contain("TEMP_v3 ="));
			Assert.That(text, Does.Contain("X8 = X9;"));
			Assert.That(text, Does.Contain("bookkeeping instructions omitted"));
		});
	}

	/// <summary>
	/// The page half of an adrp/add pair is meaningless alone; the add that follows carries the address.
	/// </summary>
	[Test]
	public void PageBaseLoadsAreDropped()
	{
		string text = Write(
			Make(0, OpCode.Move, Reg("X20"), new Immediate(0x1624000)),
			Make(1, OpCode.Move, Reg("X21"), new Immediate(0x24)));

		Assert.Multiple(() =>
		{
			Assert.That(text, Does.Not.Contain("0x1624000"));
			Assert.That(text, Does.Contain("X21 = 0x24;"));
		});
	}

	[Test]
	public void NoOpsAreDropped()
	{
		string text = Write(
			Make(0, OpCode.Nop),
			Make(1, OpCode.Move, Reg("X8"), Reg("X9")));

		Assert.That(text, Does.Not.Contain("\t;"));
	}

	/// <summary>
	/// The defect this covers: once the control flow graph is built the lifter rewrites branch operands
	/// to the block they enter, and a writer that only understands instruction and immediate operands
	/// wrote every branch in every method as a comment.
	/// </summary>
	[Test]
	public void BranchesToBlocksBecomeGotos()
	{
		Instruction landing = Make(7, OpCode.Move, Reg("X0"), Reg("X1"));
		Block target = new() { ID = 40 };
		target.AddInstruction(landing);

		string text = Write(
			Make(0, OpCode.ConditionalJump, target, Reg("X5")),
			Make(1, OpCode.Jump, target),
			landing);

		Assert.Multiple(() =>
		{
			Assert.That(text, Does.Contain("if (X5) goto L_0007;"));
			Assert.That(text, Does.Contain("goto L_0007;"));
			Assert.That(text, Does.Contain("L_0007:"));
			Assert.That(text, Does.Not.Contain("ConditionalJump"));
		});
	}

	/// <summary>
	/// A label target is program logic by definition — something jumps to it — so it survives the
	/// noise filter even when it looks like bookkeeping.
	/// </summary>
	[Test]
	public void ANoisyInstructionThatIsAJumpTargetIsKept()
	{
		Instruction landing = Make(5, OpCode.Nop);
		Block target = new() { ID = 1 };
		target.AddInstruction(landing);

		string text = Write(Make(0, OpCode.Jump, target), landing);

		Assert.That(text, Does.Contain("L_0005:"));
	}

	[Test]
	public void UnnamedCallTargetsKeepTheirAddress()
	{
		// With no application context there is nothing to look an address up in, and the address is
		// still better than nothing.
		string text = Write(Make(0, OpCode.CallVoid, new Immediate(0x8D8204)));

		Assert.That(text, Does.Contain("0x8D8204()"));
	}
}
