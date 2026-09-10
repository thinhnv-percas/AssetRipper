using AsmResolver.PE.DotNet.Cil;
using Cpp2IL.Core;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// A branch whose target instruction generated no CIL. Generation is allowed to emit nothing - a
/// constructor call the allocation already covers is dropped - and indexing the empty list that
/// leaves behind used to throw out of the whole method body.
/// </summary>
public class Il2CppBranchTargetTests
{
	private static Instruction Nop(int index) => new(index, OpCode.Nop);

	[Test]
	public void TargetThatGeneratedCode_ResolvesToItsFirstInstruction()
	{
		Instruction target = Nop(1);
		Block block = new() { Instructions = [target] };
		CilInstruction generated = new(CilOpCodes.Nop);

		CilInstruction? resolved = IlGenerator.ResolveBranchTarget(
			target, block, new() { [target] = [generated] }, []);

		Assert.That(resolved, Is.SameAs(generated));
	}

	[Test]
	public void TargetThatGeneratedNothing_ResolvesToTheNextInstructionThatDid()
	{
		Instruction dropped = Nop(1);
		Instruction next = Nop(2);
		Block block = new() { Instructions = [dropped, next] };
		CilInstruction generated = new(CilOpCodes.Nop);

		CilInstruction? resolved = IlGenerator.ResolveBranchTarget(
			dropped, block, new() { [dropped] = [], [next] = [generated] }, []);

		Assert.That(resolved, Is.SameAs(generated));
	}

	[Test]
	public void TargetIsTheLastInstructionOfItsBlock_ResolvesToASuccessorsEntry()
	{
		Instruction dropped = Nop(1);
		Block successor = new();
		Block block = new() { Instructions = [dropped], Successors = [successor] };
		CilInstruction entry = new(CilOpCodes.Nop);

		CilInstruction? resolved = IlGenerator.ResolveBranchTarget(
			dropped, block, new() { [dropped] = [] }, new() { [successor] = entry });

		Assert.That(resolved, Is.SameAs(entry));
	}

	[Test]
	public void NothingAfterTheTargetGeneratedCode_ResolvesToNothingRatherThanThrowing()
	{
		Instruction dropped = Nop(1);
		Block block = new() { Instructions = [dropped] };

		CilInstruction? resolved = IlGenerator.ResolveBranchTarget(
			dropped, block, new() { [dropped] = [] }, []);

		Assert.That(resolved, Is.Null);
	}

	[Test]
	public void TargetOutsideAnyBlock_ResolvesToNothingRatherThanThrowing()
	{
		Instruction dropped = Nop(1);

		CilInstruction? resolved = IlGenerator.ResolveBranchTarget(
			dropped, null, new() { [dropped] = [] }, []);

		Assert.That(resolved, Is.Null);
	}
}
