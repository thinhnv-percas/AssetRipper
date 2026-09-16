using Cpp2IL.Core.Analysis;

namespace AssetRipper.Tests;

/// <summary>
/// Whose code a call target is, decided from the symbol a relocation names.
/// </summary>
/// <remarks>
/// <para>
/// The families want opposite work and reached the generator as one placeholder: a managed method
/// the model could not choose between is a recovery defect, a function in another shared library is
/// an external dependency that no amount of decompiling makes managed, and an il2cpp helper is a
/// boundary to represent rather than translate. On the test game the split is 490 system, 416 with
/// no evidence, 339 the runtime's own atomic sequence and 33 managed.
/// </para>
/// <para>
/// Only the symbol half is covered here; it is the half that is a pure function of a name. The
/// address half - a relocation, a located key function, an instruction sequence - needs a binary,
/// and its evidence is the measurement above.
/// </para>
/// </remarks>
public class Il2CppNativeBoundaryTests
{
	[Test]
	public void TheRuntimePrefixesItsOwnExports()
	{
		Assert.Multiple(() =>
		{
			Assert.That(NativeBoundary.KindOfSymbol("il2cpp_object_new"), Is.EqualTo(NativeBoundary.Il2CppRuntime));
			Assert.That(NativeBoundary.KindOfSymbol("il2cpp_class_is_assignable_from"), Is.EqualTo(NativeBoundary.Il2CppRuntime));
		});
	}

	[Test]
	public void UnityPrefixesItsOwn()
	{
		Assert.That(NativeBoundary.KindOfSymbol("UnityEngine_Object_GetName"), Is.EqualTo(NativeBoundary.UnityEngine));
	}

	[Test]
	public void TheCLibraryAndTheCppAbiAreThePlatformsRatherThanTheGames()
	{
		// These are what a generated body actually calls, and calling them a plugin's would say the
		// game shipped them - which is the difference between a dependency to satisfy and one to
		// bundle.
		Assert.Multiple(() =>
		{
			Assert.That(NativeBoundary.KindOfSymbol("memcpy"), Is.EqualTo(NativeBoundary.SystemApi));
			Assert.That(NativeBoundary.KindOfSymbol("modf"), Is.EqualTo(NativeBoundary.SystemApi));
			Assert.That(NativeBoundary.KindOfSymbol("__cxa_begin_catch"), Is.EqualTo(NativeBoundary.SystemApi));
			Assert.That(NativeBoundary.KindOfSymbol("__stack_chk_fail"), Is.EqualTo(NativeBoundary.SystemApi));
			Assert.That(NativeBoundary.KindOfSymbol("pthread_mutex_lock"), Is.EqualTo(NativeBoundary.SystemApi));
			// A libm name with no prefix to key on: named, because the family rule cannot reach it and
			// the alternative is reporting six calls per game as somebody's plugin.
			Assert.That(NativeBoundary.KindOfSymbol("sincosf"), Is.EqualTo(NativeBoundary.SystemApi));
		});
	}

	[Test]
	public void AMangledCppSymbolIsCompiledCodeSomebodyShipped()
	{
		// Neither the runtime nor the player nor a C API, so it is what the game was built with.
		Assert.That(NativeBoundary.KindOfSymbol("_ZN6Plugin4initEv"), Is.EqualTo(NativeBoundary.NativePlugin));
	}

	[Test]
	public void ASymbolMatchingNoFamilyIsResolvedButNotPlaced()
	{
		// Deliberately not a plugin: the name was resolved, and that is all this can say about it.
		// Guessing here would put a verdict on the one case with no evidence behind it.
		Assert.That(NativeBoundary.KindOfSymbol("SomeVendorEntryPoint"), Is.EqualTo(NativeBoundary.ExternalDependency));
	}

	[Test]
	public void EveryKindIsADistinctName()
	{
		// They are reported as strings and compared as strings, so two that collide would merge two
		// families silently.
		Assert.That(new[]
		{
			NativeBoundary.Managed, NativeBoundary.Il2CppRuntime, NativeBoundary.UnityEngine,
			NativeBoundary.NativePlugin, NativeBoundary.SystemApi, NativeBoundary.PInvoke,
			NativeBoundary.ExternalDependency, NativeBoundary.Unknown,
		}, Is.Unique);
	}

	[Test]
	public void ATargetOutsideTheManagedCodeSpanIsTheRuntime()
	{
		// An il2cpp binary keeps generated method bodies in one executable region and the runtime's
		// own code in another, and every managed method the model knows sits in the first. So an
		// address outside the span of every managed method is not generated code, and the only other
		// executable code in the image is the runtime. Read from the model rather than from a section
		// name, so it needs nothing of the container format.
		Assert.Multiple(() =>
		{
			Assert.That(NativeBoundary.IsOutsideManagedCode(0x900000, 0xC00000, 0xF00000), Is.True, "below");
			Assert.That(NativeBoundary.IsOutsideManagedCode(0x1000000, 0xC00000, 0xF00000), Is.True, "above");
			Assert.That(NativeBoundary.IsOutsideManagedCode(0xD00000, 0xC00000, 0xF00000), Is.False, "inside");
		});
	}

	[Test]
	public void TheBoundsThemselvesAreInside()
	{
		// A managed method sits at each end, so neither end is outside.
		Assert.Multiple(() =>
		{
			Assert.That(NativeBoundary.IsOutsideManagedCode(0xC00000, 0xC00000, 0xF00000), Is.False);
			Assert.That(NativeBoundary.IsOutsideManagedCode(0xF00000, 0xC00000, 0xF00000), Is.False);
		});
	}

	[Test]
	public void ABinaryWithNoManagedMethodClassifiesNothingThisWay()
	{
		// The span is empty, so there is no boundary to be on the far side of. Answering "runtime"
		// for every address would be a verdict with nothing behind it.
		Assert.That(NativeBoundary.IsOutsideManagedCode(0xC00000, 0, ulong.MaxValue), Is.False);
	}

	[Test]
	public void AVerdictRendersItsSymbolWhenItHasOne()
	{
		Assert.Multiple(() =>
		{
			Assert.That(new NativeBoundary.Verdict(NativeBoundary.SystemApi, "memcpy").ToString(), Is.EqualTo("SYSTEM_API:memcpy"));
			Assert.That(new NativeBoundary.Verdict(NativeBoundary.Unknown, null).ToString(), Is.EqualTo("UNKNOWN"));
		});
	}
}
