using Cpp2IL.Core;

namespace AssetRipper.Tests;

/// <summary>
/// The operand layout an unresolved call keeps, which is what makes a native import's arguments
/// reachable at all.
/// </summary>
/// <remarks>
/// A call whose callee nothing resolved keeps the whole register file as its operands - by definition
/// nothing knew the callee, so nothing remapped them - and the layout is the ABI's: the target, the
/// destination, then X0 to X7 and V0 to V7. Eighteen in all, with the first vector register at index
/// ten. The first version of the rule counted the target twice, asked for nineteen, and never fired
/// once on 2219 calls while looking exactly like a rule that had nothing to match.
/// </remarks>
public class Il2CppNativeImportTests
{
	[Test]
	public void TheRawRegisterFileIsEighteenOperandsWithV0AtTen()
	{
		Assert.Multiple(() =>
		{
			// target + destination + 8 integer + 8 vector
			Assert.That(1 + 1 + 8 + 8, Is.EqualTo(IlGenerator.RawRegisterFileOperandCount));
			Assert.That(IlGenerator.FirstVectorRegisterOperand, Is.EqualTo(1 + 1 + 8));
		});
	}

	[Test]
	public void TheVectorRegistersAreInsideTheOperandList()
	{
		// The two float arguments of a two-argument libm call are V0 and V1, and both have to be
		// addressable within the layout or the rule reads past the end.
		Assert.That(IlGenerator.FirstVectorRegisterOperand + 1, Is.LessThan(IlGenerator.RawRegisterFileOperandCount));
	}

	[Test]
	public void OnlyFmodIsTakenAsAnOperation()
	{
		// Every other libm import would need a method resolved in the game's own mscorlib and a
		// float-to-double conversion decided. `fmod` needs neither: `rem` is a CIL opcode and both
		// operands are already the width the register holds.
		Assert.Multiple(() =>
		{
			Assert.That(IlGenerator.IsNativeImportWithAnOperation("fmodf"), Is.True);
			Assert.That(IlGenerator.IsNativeImportWithAnOperation("fmod"), Is.True);
			Assert.That(IlGenerator.IsNativeImportWithAnOperation("sinf"), Is.False);
			Assert.That(IlGenerator.IsNativeImportWithAnOperation("memcpy"), Is.False);
			Assert.That(IlGenerator.IsNativeImportWithAnOperation("__cxa_begin_catch"), Is.False);
		});
	}
}
