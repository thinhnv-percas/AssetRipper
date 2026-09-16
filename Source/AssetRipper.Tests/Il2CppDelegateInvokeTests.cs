using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// Which field access is a delegate invoke.
/// </summary>
/// <remarks>
/// il2cpp compiles <c>d(args)</c> into a call through the delegate's own <c>invoke_impl</c> slot, and
/// the pass that turns that back into <c>Invoke</c> had only ever matched the raw memory operand -
/// while running after the resolution that replaces it with a named field. 117 of the 350
/// <c>Indirect call</c> placeholders on the test game were exactly this shape.
/// </remarks>
public class Il2CppDelegateInvokeTests
{
	private static LocalVariable Local() => new("d", new Register(null, "X0"));

	[Test]
	public void AFieldNamedInvokeImplIsTheDelegateBeingInvoked()
	{
		var local = Local();
		Assert.That(DelegateInvokeRecovery.DelegateFromResolvedField("invoke_impl", local, false, 0), Is.SameAs(local));
	}

	[Test]
	public void AnyOtherFieldIsNot()
	{
		// `method_ptr` sits one slot earlier and is loaded by the same code, so this is the neighbour
		// the rule has to keep out rather than a hypothetical.
		Assert.That(DelegateInvokeRecovery.DelegateFromResolvedField("method_ptr", Local(), false, 0), Is.Null);
	}

	[Test]
	public void AnArrayElementIsNot()
	{
		// The local is the array, not the delegate, so calling Invoke on it would name the wrong value.
		Assert.That(DelegateInvokeRecovery.DelegateFromResolvedField("invoke_impl", Local(), true, 0), Is.Null);
	}

	[Test]
	public void AFieldReachedInsideAValueTypeIsNot()
	{
		Assert.That(DelegateInvokeRecovery.DelegateFromResolvedField("invoke_impl", Local(), false, 1), Is.Null);
	}

	[Test]
	public void InvokeImplIsThreePointersIntoTheObject()
	{
		// klass, monitor, method_ptr, then invoke_impl.
		Assert.Multiple(() =>
		{
			Assert.That(DelegateInvokeRecovery.InvokeImplOffset(is32Bit: false), Is.EqualTo(24));
			Assert.That(DelegateInvokeRecovery.InvokeImplOffset(is32Bit: true), Is.EqualTo(12));
		});
	}
}
