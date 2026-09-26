using Cpp2IL.Core.Analysis;

namespace AssetRipper.Tests;

/// <summary>
/// AssetRipper: that a load, a store and an address-take of one lifted local agree on where it lives.
/// </summary>
/// <remarks>
/// Two iterations found the same defect at different sites - the address-of site took the address of
/// a local the generator invented for a parameter, and the store site wrote that invented local while
/// the load site read the parameter. Both were silent: a body that compiles, reads plausibly, and
/// answers for a value nobody wrote. Each case below is red against the rule that produced one of
/// those.
/// </remarks>
public sealed class Il2CppLocalStorageTests
{
	private static readonly string[] Parameters = ["layerMask", "values", "result"];
	private static readonly bool[] ByReference = [false, false, true];

	private static LocalStorageSite Site(string name, bool isThis = false)
		=> LocalStorage.For(name, isThis, Parameters, ByReference);

	[Test]
	public void ALocalNamedAfterAParameterIsThatParameter()
	{
		var site = Site("layerMask");

		Assert.Multiple(() =>
		{
			Assert.That(site.Kind, Is.EqualTo(LocalStorageKind.Parameter));
			Assert.That(site.ParameterIndex, Is.EqualTo(0));
			Assert.That(site.ByReference, Is.False);
		});
	}

	[Test]
	public void ALocalNamedAfterNothingIsALocal()
	{
		Assert.That(Site("v27").Kind, Is.EqualTo(LocalStorageKind.Local));
	}

	[Test]
	public void TheReceiverIsNotAParameterEvenWhenItsNameMatchesOne()
	{
		// `this` wins: a receiver flagged by the analysis is the receiver whatever the name says.
		Assert.That(Site("layerMask", isThis: true).Kind, Is.EqualTo(LocalStorageKind.This));
	}

	[Test]
	public void ARefOrOutParameterIsAlreadyAnAddress()
	{
		var site = Site("result");

		Assert.Multiple(() =>
		{
			Assert.That(site.Kind, Is.EqualTo(LocalStorageKind.Parameter));
			Assert.That(site.ParameterIndex, Is.EqualTo(2));
			// Taking the address of one again would give a pointer to the pointer, so the caller of
			// this rule loads it rather than taking its address.
			Assert.That(site.ByReference, Is.True);
		});
	}

	[Test]
	public void EveryUseOfOneLocalResolvesToOneStorage()
	{
		// The whole point: a load, a store and an address-take ask the same question and so cannot
		// disagree. A generator that answered this three times in three places did, twice.
		foreach (string name in new[] { "layerMask", "values", "result", "v27", "stack_-88" })
		{
			var first = Site(name);
			var second = Site(name);
			var third = Site(name);

			Assert.That(second, Is.EqualTo(first), name);
			Assert.That(third, Is.EqualTo(first), name);
		}
	}

	[Test]
	public void AMethodWithNoParametersResolvesEverythingToALocal()
	{
		Assert.That(LocalStorage.For("anything", false, [], []).Kind, Is.EqualTo(LocalStorageKind.Local));
	}

	[Test]
	public void ByReferenceIsFalseWhenTheMethodDidNotSayForThatParameter()
	{
		// A shorter by-reference list must not throw or read past its end; the honest answer for a
		// parameter it does not cover is "not by reference".
		var site = LocalStorage.For("result", false, Parameters, [false]);

		Assert.Multiple(() =>
		{
			Assert.That(site.Kind, Is.EqualTo(LocalStorageKind.Parameter));
			Assert.That(site.ByReference, Is.False);
		});
	}
}
