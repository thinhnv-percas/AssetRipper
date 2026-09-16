using Cpp2IL.Core;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// Which operand of a delegate construction is its target, and when there is no target at all.
/// </summary>
/// <remarks>
/// il2cpp hands the two-argument delegate constructor a receiver, a raw function pointer and the
/// target's <c>MethodInfo*</c>. The pointer resolves to nothing, which is why this used to be
/// reported as a loss; the MethodInfo names the method, which is why it is not one. A delegate over
/// a <em>static</em> method is constructed with a zero where the receiver goes, and emitting that
/// zero as a receiver rather than as <c>ldnull</c> would close the delegate over address zero.
/// </remarks>
public class Il2CppDelegateConstructionTests
{
	private static Instruction Construction(params IOperand[] operands)
		=> new(0, OpCode.CallVoid, [.. operands]);

	private static LocalVariable Local(string name) => new(name, new Register(null, "X0"));

	[Test]
	public void TheReceiverIsTheFirstArgumentAfterTheAllocatedObject()
	{
		// CallVoid puts the allocated object at index 1, so the target is index 2.
		var target = Local("closure");
		var call = Construction(Local("ctor"), Local("newObject"), target, Local("methodInfo"));

		Assert.That(IlGenerator.TargetOfDelegateConstructionForTests(call), Is.SameAs(target));
	}

	[Test]
	public void AZeroReceiverIsNoReceiver()
	{
		// A delegate over a static method. Loading the zero would close it over address zero.
		var call = Construction(Local("ctor"), Local("newObject"), new Immediate(0), Local("methodInfo"));

		Assert.That(IlGenerator.TargetOfDelegateConstructionForTests(call), Is.Null);
	}

	[Test]
	public void AConstructionWithNoArgumentsHasNoReceiver()
	{
		var call = Construction(Local("ctor"), Local("newObject"));

		Assert.That(IlGenerator.TargetOfDelegateConstructionForTests(call), Is.Null);
	}

	[Test]
	public void ACallReceiverSitsOneOperandLater()
	{
		// A non-void call carries a destination before the receiver, which is what
		// ConstructorReceiverIndex exists to say; getting it wrong takes the allocated object as the
		// delegate's target.
		var target = Local("closure");
		var call = new Instruction(0, OpCode.Call, [Local("ctor"), Local("result"), Local("newObject"), target]);

		Assert.That(IlGenerator.TargetOfDelegateConstructionForTests(call), Is.SameAs(target));
	}
}
