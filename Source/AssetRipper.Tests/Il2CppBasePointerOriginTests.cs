using Cpp2IL.Core.Analysis;

namespace AssetRipper.Tests;

/// <summary>
/// Covers <see cref="BasePointerOrigin"/>: what kind of storage a memory operand's base points into.
/// </summary>
/// <remarks>
/// The walk takes no types and no metadata - everything it reports is read off the IR - so these cases
/// are plain graphs. What they hold down is that it reports only what it was told: an origin it cannot
/// establish is UNKNOWN rather than the nearest plausible answer, because the whole point of the
/// column is to let the offset-frame question be settled by a rule instead of a guess, and a guessed
/// origin would move the guess one step earlier.
/// </remarks>
internal sealed class Il2CppBasePointerOriginTests
{
	[Test]
	public void AReceiverIsTheReceiverHoweverItWasCopied()
	{
		Fixture fixture = new();
		Fixture.Slot receiver = fixture.Local("this", BasePointerOrigin.This);
		Fixture.Slot copy = fixture.Local("copy");
		Fixture.Slot second = fixture.Local("second");

		fixture.Define(copy, fixture.CopyOf(receiver));
		fixture.Define(second, fixture.CopyOf(copy));

		Assert.That(fixture.Of(second), Is.EqualTo(BasePointerOrigin.This));
	}

	[Test]
	public void WhatALocalIsOutranksWhatDefinedIt()
	{
		// Static field storage is named by its own type, so it answers before the definition is read.
		Fixture fixture = new();
		Fixture.Slot storage = fixture.Local("storage", BasePointerOrigin.StaticField);
		fixture.Define(storage, fixture.CallResult());

		Assert.That(fixture.Of(storage), Is.EqualTo(BasePointerOrigin.StaticField));
	}

	[Test]
	public void AConstantAddedToAPointerLeavesItInTheSameStorage()
	{
		Fixture fixture = new();
		Fixture.Slot slot = fixture.Local("stack_-40", BasePointerOrigin.StackSlot);
		Fixture.Slot shifted = fixture.Local("shifted");
		fixture.Define(shifted, fixture.OffsetFrom(slot));

		Assert.That(fixture.Of(shifted), Is.EqualTo(BasePointerOrigin.StackSlot));
	}

	[Test]
	public void APointerReadOutOfMemoryIsItsOwnAnswerNotTheStorageItCameFrom()
	{
		// The pointer points at whatever was stored there, which has nothing to do with where it was
		// read from - so following the load's own base would be wrong, not merely imprecise.
		Fixture fixture = new();
		Fixture.Slot loaded = fixture.Local("loaded");
		fixture.Define(loaded, fixture.LoadFromMemory());

		Assert.That(fixture.Of(loaded), Is.EqualTo(BasePointerOrigin.LoadedPointer));
	}

	[Test]
	public void ALocalNothingDefinedIsAParameterWhenTheIrSaysSo()
	{
		Fixture fixture = new() { Parameters = { "arg" } };

		Assert.That(fixture.Of(fixture.Local("arg")), Is.EqualTo(BasePointerOrigin.Parameter));
	}

	[Test]
	public void ALocalNothingDefinedAndNoParameterIsARegistersEntryValue()
	{
		Fixture fixture = new();

		Assert.That(fixture.Of(fixture.Local("x8")), Is.EqualTo(BasePointerOrigin.EntryValue));
	}

	[Test]
	public void TwoDefinitionsThatDisagreeAreNotResolvedByPickingOne()
	{
		Fixture fixture = new();
		Fixture.Slot local = fixture.Local("local");
		fixture.Define(local, fixture.CallResult());
		fixture.Define(local, fixture.FieldRead());

		Assert.That(fixture.Of(local), Is.EqualTo(BasePointerOrigin.UnknownMerged));
	}

	[Test]
	public void ACopyCycleTerminatesAsUnknown()
	{
		// Honest about what this holds down: with one definition per local the cycle guard can only
		// change how much work the walk does, never its answer - the depth limit returns Unknown for a
		// cycle either way, and removing the guard leaves this case green. It is kept as a termination
		// regression, not as evidence that the guard is load-bearing.
		Fixture fixture = new();
		Fixture.Slot a = fixture.Local("a");
		Fixture.Slot b = fixture.Local("b");
		fixture.Define(a, fixture.CopyOf(b));
		fixture.Define(b, fixture.CopyOf(a));

		Assert.That(fixture.Of(a), Is.EqualTo(BasePointerOrigin.UnknownCycle));
	}

	[Test]
	public void AChainLongerThanTheLimitStopsRatherThanRunningOn()
	{
		Fixture fixture = new();
		Fixture.Slot deepest = fixture.Local("deepest", BasePointerOrigin.This);
		Fixture.Slot link = deepest;

		for (int i = 0; i < BasePointerOrigin.DepthLimit + 2; i++)
		{
			Fixture.Slot above = fixture.Local($"link{i}");
			fixture.Define(above, fixture.CopyOf(link));
			link = above;
		}

		Assert.That(fixture.Of(link), Is.EqualTo(BasePointerOrigin.UnknownDepth));
	}

	[Test]
	public void ACallsBufferIsTheBufferRatherThanAnOrdinaryResult()
	{
		Fixture fixture = new();
		Fixture.Slot buffer = fixture.Local("buffer");
		fixture.Define(buffer, fixture.Opaque());
		fixture.ReturnBuffers.Add(buffer);

		Assert.That(fixture.Of(buffer), Is.EqualTo(BasePointerOrigin.ReturnBuffer));
	}

	[Test]
	public void AnUnrecognisedDefinitionIsUnknownRatherThanTheNearestGuess()
	{
		Fixture fixture = new();
		Fixture.Slot local = fixture.Local("local");
		fixture.Define(local, fixture.Opaque());

		Assert.That(fixture.Of(local), Is.EqualTo(BasePointerOrigin.UnknownOpcode(null)));
	}

	[Test]
	public void EveryDefinitionOfAMergedLocalAgreeing_IsThatOrigin()
	{
		// SSA destruction leaves one definition per merged version. Several of them is a reason to
		// check, not a reason to give up: reaching the same storage by two routes is still that
		// storage, and reporting UNKNOWN there discards an answer that was never in doubt.
		Fixture fixture = new();
		Fixture.Slot receiver = fixture.Local("this", BasePointerOrigin.This);
		Fixture.Slot first = fixture.Local("first");
		Fixture.Slot second = fixture.Local("second");
		Fixture.Slot merged = fixture.Local("merged");

		fixture.Define(first, fixture.CopyOf(receiver));
		fixture.Define(second, fixture.CopyOf(receiver));
		fixture.Define(merged, fixture.CopyOf(first));
		fixture.Define(merged, fixture.CopyOf(second));

		Assert.That(fixture.Of(merged), Is.EqualTo(BasePointerOrigin.This));
	}

	[Test]
	public void DefinitionsOfAMergedLocalDisagreeing_IsUnknown()
	{
		Fixture fixture = new();
		Fixture.Slot receiver = fixture.Local("this", BasePointerOrigin.This);
		Fixture.Slot allocated = fixture.Local("allocated");
		Fixture.Slot merged = fixture.Local("merged");

		fixture.Define(allocated, fixture.Allocation());
		fixture.Define(merged, fixture.CopyOf(receiver));
		fixture.Define(merged, fixture.CopyOf(allocated));

		Assert.That(fixture.Of(merged), Is.EqualTo(BasePointerOrigin.UnknownMerged));
	}

	[Test]
	public void EveryBranchOfAMergeEndingInTheSameUnknown_KeepsThatReason()
	{
		// Agreeing on "no idea" is not an answer, and replacing the reason with a bare UNKNOWN would
		// lose the one column that says which rule is missing.
		Fixture fixture = new();
		Fixture.Slot left = fixture.Local("left");
		Fixture.Slot right = fixture.Local("right");
		Fixture.Slot merged = fixture.Local("merged");

		fixture.Define(left, fixture.Opaque("Or"));
		fixture.Define(right, fixture.Opaque("Or"));
		fixture.Define(merged, fixture.CopyOf(left));
		fixture.Define(merged, fixture.CopyOf(right));

		Assert.That(fixture.Of(merged), Is.EqualTo(BasePointerOrigin.UnknownOpcode("Or")));
	}

	[Test]
	public void TwoBranchesReachingOneLocal_IsConvergenceNotACycle()
	{
		// Both definitions pass through the same copy. Sharing one visited set across the branches
		// would report the second as a cycle and lose an origin that both branches agree on.
		Fixture fixture = new();
		Fixture.Slot slot = fixture.Local("stack_-8", BasePointerOrigin.StackSlot);
		Fixture.Slot shared = fixture.Local("shared");
		Fixture.Slot left = fixture.Local("left");
		Fixture.Slot right = fixture.Local("right");
		Fixture.Slot merged = fixture.Local("merged");

		fixture.Define(shared, fixture.CopyOf(slot));
		fixture.Define(left, fixture.CopyOf(shared));
		fixture.Define(right, fixture.CopyOf(shared));
		fixture.Define(merged, fixture.CopyOf(left));
		fixture.Define(merged, fixture.CopyOf(right));

		Assert.That(fixture.Of(merged), Is.EqualTo(BasePointerOrigin.StackSlot));
	}

	[Test]
	public void ADefinitionWithNoRule_NamesTheOpcode()
	{
		// "No rule for this" as one bucket held 809 loads and five unrelated causes. The opcode is
		// what separates a missing rule from nothing to say, so it is part of the answer.
		Fixture fixture = new();
		Fixture.Slot local = fixture.Local("local");
		fixture.Define(local, fixture.Opaque("IsInst"));

		Assert.That(fixture.Of(local), Is.EqualTo("UNKNOWN:OPCODE:IsInst"));
	}

	[Test]
	public void ACycleAndAMergeAreDifferentAnswers()
	{
		Fixture fixture = new();
		Fixture.Slot first = fixture.Local("first");
		Fixture.Slot second = fixture.Local("second");
		fixture.Define(first, fixture.CopyOf(second));
		fixture.Define(second, fixture.CopyOf(first));

		Assert.That(fixture.Of(first), Is.EqualTo(BasePointerOrigin.UnknownCycle));
	}

	private sealed class Fixture
	{
		internal readonly HashSet<string> Parameters = [];
		internal readonly HashSet<Slot> ReturnBuffers = [];

		private readonly Dictionary<Slot, List<BasePointerOrigin.DefinitionLike>> definitions = [];

		internal sealed record Slot(string Name, string? Describes) : BasePointerOrigin.LocalLike;

		internal Slot Local(string name, string? describes = null) => new(name, describes);

		internal void Define(Slot local, BasePointerOrigin.DefinitionLike definition)
		{
			if (!definitions.TryGetValue(local, out List<BasePointerOrigin.DefinitionLike>? already))
			{
				definitions[local] = already = [];
			}

			already.Add(definition);
		}

		internal BasePointerOrigin.DefinitionLike CopyOf(Slot source)
			=> new(BasePointerOrigin.DefinitionKind.CopyOfLocal, source);

		internal BasePointerOrigin.DefinitionLike OffsetFrom(Slot source)
			=> new(BasePointerOrigin.DefinitionKind.OffsetFromLocal, source);

		internal BasePointerOrigin.DefinitionLike FieldRead() => new(BasePointerOrigin.DefinitionKind.FieldRead, null);

		internal BasePointerOrigin.DefinitionLike CallResult() => new(BasePointerOrigin.DefinitionKind.CallResult, null);

		internal BasePointerOrigin.DefinitionLike LoadFromMemory() => new(BasePointerOrigin.DefinitionKind.LoadFromMemory, null);

		internal BasePointerOrigin.DefinitionLike Allocation() => new(BasePointerOrigin.DefinitionKind.Allocation, null);

		internal BasePointerOrigin.DefinitionLike Opaque(string? opcode = null)
			=> new(BasePointerOrigin.DefinitionKind.Other, null, opcode);

		internal string Of(Slot local)
			=> BasePointerOrigin.Of(
				local,
				candidate => definitions.TryGetValue((Slot)candidate, out List<BasePointerOrigin.DefinitionLike>? found)
					? found
					: [],
				candidate => ((Slot)candidate).Describes,
				(candidate, definition) => definition.Kind == BasePointerOrigin.DefinitionKind.Other
					&& ReturnBuffers.Contains((Slot)candidate),
				candidate => Parameters.Contains(((Slot)candidate).Name) ? BasePointerOrigin.Parameter : null);
	}
}
