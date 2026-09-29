using AssetRipper.Export.UnityProjects.Shaders;

namespace AssetRipper.Tests;

/// <summary>
/// AssetRipper: that a pass's variants are written under guards of their exact keyword sets, and that
/// nothing chooses a program for a keyword state the original build never compiled.
/// </summary>
public sealed class ShaderVariantGuardsTests
{
	private static ShaderVariantGuards.Variant V(int index, string keywords, string source)
		=> new(index, keywords.Length == 0 ? [] : keywords.Split('+'), source);

	[Test]
	public void EachProgramIsGuardedByItsExactKeywordSet()
	{
		var result = ShaderVariantGuards.Build([
			V(0, "", "base"),
			V(1, "OUTLINE_ON", "outline"),
			V(2, "OUTLINE_ON+UNDERLAY_ON", "both"),
		], indent: "");

		Assert.Multiple(() =>
		{
			Assert.That(result.Text, Is.Not.Null);
			Assert.That(result.Text, Does.Contain("#if (!defined(OUTLINE_ON) && !defined(UNDERLAY_ON))\n// AssetRipperVariant: variant 1"));
			Assert.That(result.Text, Does.Contain("#elif (defined(OUTLINE_ON) && !defined(UNDERLAY_ON))"));
			Assert.That(result.Text, Does.Contain("#elif (defined(OUTLINE_ON) && defined(UNDERLAY_ON))"));
			Assert.That(result.Text, Does.Contain("#pragma multi_compile __ OUTLINE_ON"), "no recorded scope declares global");
		});
	}

	[Test]
	public void AStateTheBuildNeverCompiledSelectsNothing()
	{
		// UNDERLAY_ON without OUTLINE_ON was never compiled; it must not quietly get the base program.
		var result = ShaderVariantGuards.Build([V(0, "", "base"), V(1, "OUTLINE_ON+UNDERLAY_ON", "both")], indent: "");

		Assert.That(result.Text, Does.Contain("#else\n// AssetRipperVariantSelectionUnknown").And.Contain("#error VARIANT_SELECTION_UNKNOWN\n#endif"));
	}

	[Test]
	public void IdenticalProgramsShareOneGuard()
	{
		var result = ShaderVariantGuards.Build([V(0, "", "same"), V(1, "A", "same"), V(2, "B", "other")], indent: "");

		Assert.Multiple(() =>
		{
			Assert.That(result.DistinctPrograms, Is.EqualTo(2));
			Assert.That(result.Text, Does.Contain("#if (!defined(A) && !defined(B)) || (defined(A) && !defined(B))"));
			Assert.That(result.Text!.Split("same").Length - 1, Is.EqualTo(1), "one copy per distinct program");
		});
	}

	[Test]
	public void EachKeywordIsDeclaredInTheScopeTheAssetRecords()
	{
		// SHADOWS_DEPTH is set by the engine as a global keyword; declared local, the pass that needs it
		// could never select its program.
		var result = ShaderVariantGuards.Build([V(0, "SHADOWS_DEPTH", "depth"), V(1, "_FADING_ON", "fading")], indent: "",
			isLocal: keyword => keyword switch { "_FADING_ON" => true, "SHADOWS_DEPTH" => false, _ => null });

		Assert.Multiple(() =>
		{
			Assert.That(result.Text, Does.Contain("#pragma multi_compile __ SHADOWS_DEPTH\n"));
			Assert.That(result.Text, Does.Contain("#pragma multi_compile_local __ _FADING_ON\n"));
		});
	}

	[Test]
	public void OneDistinctProgramNeedsNoGuards()
		=> Assert.That(ShaderVariantGuards.Build([V(0, "", "x"), V(1, "A", "x")]).Text, Is.Null);

	[Test]
	public void TooManyKeywordsAreNotEmbeddedAndSaySo()
	{
		List<ShaderVariantGuards.Variant> variants = [.. Enumerable.Range(0, 10).Select(i => V(i, $"K{i}", $"p{i}"))];
		var result = ShaderVariantGuards.Build(variants);

		Assert.Multiple(() =>
		{
			Assert.That(result.Text, Is.Null);
			Assert.That(result.Reason, Does.Contain("10 keywords"));
		});
	}
}
