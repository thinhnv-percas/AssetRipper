using Cpp2IL.Core;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// Which field of a <c>MethodInfo</c> a call goes through, and what that means.
/// </summary>
/// <remarks>
/// 182 of the calls iteration 050's brief described as unresolved vtable slots read a field of a
/// <c>MethodInfo*</c> instead, and the field decides whether a target exists: <c>methodPointer</c> is
/// the entry point of the method the MethodInfo names, so a call through it is a direct call to that
/// method, while <c>invoker_method</c> is the runtime's reflection-style invoker and a call through
/// it is not a call to that method's body at all. Two offsets apart, opposite answers.
/// </remarks>
public class Il2CppCallResolutionTests
{
	[Test]
	public void MethodPointerIsTheFirstFieldOfMethodInfo()
	{
		Assert.Multiple(() =>
		{
			Assert.That(Il2CppMethodInfoUsefulOffsets.TryGetOffset("methodPointer", is32Bit: false, out long wide), Is.True);
			Assert.That(wide, Is.EqualTo(0));

			Assert.That(Il2CppMethodInfoUsefulOffsets.TryGetOffset("methodPointer", is32Bit: true, out long narrow), Is.True);
			Assert.That(narrow, Is.EqualTo(0));
		});
	}

	[Test]
	public void MethodPointerIsNotTheSameFieldAsKlass()
	{
		// The 64-bit layouts put klass well past the pointers, and confusing the two would resolve
		// every call through a MethodInfo to whatever sits at the class pointer's offset.
		Il2CppMethodInfoUsefulOffsets.TryGetOffset("methodPointer", is32Bit: false, out long pointer);
		Il2CppMethodInfoUsefulOffsets.TryGetOffset("klass", is32Bit: false, out long klass);

		Assert.That(pointer, Is.Not.EqualTo(klass));
	}

	[Test]
	public void AnOffsetNobodyDeclaredIsNotAnswered()
	{
		// `invoker_method` is deliberately absent: a call through it is not a call to the method, so
		// the table must not hand out an offset that would make one look resolvable.
		Assert.That(Il2CppMethodInfoUsefulOffsets.TryGetOffset("invoker_method", is32Bit: false, out _), Is.False);
	}
}
