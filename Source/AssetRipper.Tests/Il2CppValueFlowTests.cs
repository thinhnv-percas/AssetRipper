using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// AssetRipper: what a store into, or a load from, one ISIL operand means, decided by the kind of value
/// each local carries rather than by its name.
/// </summary>
/// <remarks>
/// Iteration 064. <c>SetPropertyUtility.SetColor(ref Color currentValue, Color newValue)</c> lifts to
/// <c>Move [currentValue + 0], newValue</c> and came back as <c>currentValue = ref *(Color*)newValue</c>:
/// the generator wrote the reference instead of what it points at. Every case below is written over the
/// operand shape the lifter produces and a kind per local, with no metadata, and the first two are red
/// against the rule that produced that.
/// </remarks>
public sealed class Il2CppValueFlowTests
{
	private static readonly LocalVariable CurrentValue = new("currentValue", new Register(0, "X0"));
	private static readonly LocalVariable NewValue = new("newValue", new Register(32, "V0"));
	private static readonly LocalVariable Pointer = new("v12", new Register(8, "X8"));
	private static readonly LocalVariable Object = new("v20", new Register(9, "X9"));

	private static ValueKind KindOf(LocalVariable local)
	{
		if (ReferenceEquals(local, CurrentValue))
		{
			return ValueKind.ManagedReference;
		}
		if (ReferenceEquals(local, Pointer))
		{
			return ValueKind.NativePointer;
		}
		if (ReferenceEquals(local, Object))
		{
			return ValueKind.ObjectReference;
		}
		return ValueKind.StructValue;
	}

	[Test]
	public void AStoreAtOffsetZeroOffAManagedReferenceWritesThroughIt()
	{
		var destination = new MemoryOperand(CurrentValue, null, 0, 0, 4);

		Assert.That(ValueFlow.StoreInto(destination, KindOf, NewValue), Is.EqualTo(StoreSemantics.WriteThroughReference));
	}

	[Test]
	public void AValueStoredIntoAManagedReferenceLocalIsARebindingNotAnAssignment()
	{
		// The shape the generator used to emit for the case above: the parameter itself took the value.
		Assert.That(ValueFlow.StoreInto(CurrentValue, KindOf, NewValue), Is.EqualTo(StoreSemantics.RebindReference));
	}

	[Test]
	public void AnAddressStoredIntoAManagedReferenceLocalIsALegitimateRebinding()
	{
		// `ref x = ref y` is real C#; only a non-address value makes it a defect.
		Assert.That(ValueFlow.StoreInto(CurrentValue, KindOf, new AddressOf(NewValue)), Is.EqualTo(StoreSemantics.AssignLocal));
	}

	[Test]
	public void AStoreThroughANativePointerIsNotAWriteThrough()
	{
		// A native pointer has no managed referent type to write; the generator drops it, and saying
		// WriteThroughReference here would make that drop look like a recovered store.
		var destination = new MemoryOperand(Pointer, null, 0, 0, 8);

		Assert.That(ValueFlow.StoreInto(destination, KindOf, NewValue), Is.EqualTo(StoreSemantics.Discarded));
	}

	[Test]
	public void OffsetZeroOffAnObjectIsTheHeaderNotTheObject()
	{
		var destination = new MemoryOperand(Object, null, 0, 0, 8);

		Assert.Multiple(() =>
		{
			Assert.That(ValueFlow.StoreInto(destination, KindOf, NewValue), Is.EqualTo(StoreSemantics.Discarded));
			Assert.That(ValueFlow.LoadFrom(destination, KindOf), Is.EqualTo(LoadSemantics.Unresolved));
		});
	}

	[Test]
	public void ALoadAtOffsetZeroOffAManagedReferenceReadsThroughIt()
	{
		Assert.That(ValueFlow.LoadFrom(new MemoryOperand(CurrentValue), KindOf), Is.EqualTo(LoadSemantics.ReadThroughReference));
	}

	[Test]
	public void ANonZeroOffsetOffAManagedReferenceIsLeftToFieldResolution()
	{
		// `[currentValue + 4]` is `currentValue.g` once MetadataResolver looks through the reference;
		// until then it is a load nothing resolved, never a read of the whole referent.
		var member = new MemoryOperand(CurrentValue, null, 4, 0, 4);

		Assert.Multiple(() =>
		{
			Assert.That(ValueFlow.LoadFrom(member, KindOf), Is.EqualTo(LoadSemantics.Unresolved));
			Assert.That(ValueFlow.StoreInto(member, KindOf, NewValue), Is.EqualTo(StoreSemantics.Discarded));
		});
	}

	[Test]
	public void AnUntypedLocalIsUnknownAndNeverAReference()
	{
		Assert.Multiple(() =>
		{
			Assert.That(ValueFlow.KindOf(null), Is.EqualTo(ValueKind.Unknown));
			Assert.That(ValueFlow.WritesThrough(ValueKind.Unknown), Is.False);
		});
	}
}
