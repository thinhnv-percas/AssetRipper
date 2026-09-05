using AssetRipper.Export.UnityProjects.PackageRemapping;

namespace AssetRipper.Tests;

/// <summary>
/// The mapping decides what an irreversible rewrite of a whole project would do, so the cases where
/// it must refuse to decide matter as much as the ones where it succeeds.
/// </summary>
public sealed class PackageGuidMappingTests
{
	private static AssetIdentity Asset(string path, string guid) => new(path, guid);

	private const string GuidA = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
	private const string GuidB = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
	private const string GuidC = "cccccccccccccccccccccccccccccccc";
	private const string GuidD = "dddddddddddddddddddddddddddddddd";

	[Test]
	public void AssetsAtTheSamePathArePaired()
	{
		PackageGuidMapping mapping = PackageGuidMapping.Build(
			[Asset("Scripts/TMP_Text.cs", GuidA)],
			[Asset("Scripts/TMP_Text.cs", GuidB)]);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(mapping.Matches, Has.Count.EqualTo(1));
			Assert.That(mapping.Matches[0].OldGuid, Is.EqualTo(GuidA));
			Assert.That(mapping.Matches[0].NewGuid, Is.EqualTo(GuidB));
			Assert.That(mapping.Matches[0].Kind, Is.EqualTo(GuidMatchKind.RelativePath));
			Assert.That(mapping.IsSafeToApply, Is.True);
		}
	}

	/// <summary>
	/// Shaders are remapped exactly like scripts. A material whose shader GUID is left behind renders
	/// magenta, so it must not be skipped.
	/// </summary>
	[Test]
	public void ShadersArePairedLikeAnythingElse()
	{
		PackageGuidMapping mapping = PackageGuidMapping.Build(
			[Asset("Shaders/TMP_SDF.shader", GuidA)],
			[Asset("Shaders/TMP_SDF.shader", GuidB)]);

		Assert.That(mapping.Matches, Has.Count.EqualTo(1));
		Assert.That(mapping.Matches[0].RippedPath, Does.EndWith(".shader"));
	}

	[Test]
	public void AssetsWhoseGuidAlreadyAgreesNeedNoRewrite()
	{
		PackageGuidMapping mapping = PackageGuidMapping.Build(
			[Asset("Scripts/A.cs", GuidA)],
			[Asset("Scripts/A.cs", GuidA)]);

		Assert.That(mapping.Matches, Is.Empty);
	}

	/// <summary>
	/// A package may move a file between versions, so the path can differ while the name does not.
	/// </summary>
	[Test]
	public void AUniqueFileNameIsAcceptedWhenThePathDoesNotMatch()
	{
		PackageGuidMapping mapping = PackageGuidMapping.Build(
			[Asset("Scripts/TMP_Text.cs", GuidA)],
			[Asset("Runtime/Scripts/TMP_Text.cs", GuidB)]);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(mapping.Matches, Has.Count.EqualTo(1));
			Assert.That(mapping.Matches[0].Kind, Is.EqualTo(GuidMatchKind.FileName));
		}
	}

	/// <summary>
	/// Names like Editor.cs repeat throughout a package, and picking one arbitrarily would repoint
	/// references at the wrong asset.
	/// </summary>
	[Test]
	public void ARepeatedFileNameIsNotGuessedAt()
	{
		PackageGuidMapping mapping = PackageGuidMapping.Build(
			[Asset("A/Editor.cs", GuidA), Asset("B/Editor.cs", GuidB)],
			[Asset("X/Editor.cs", GuidC), Asset("Y/Editor.cs", GuidD)]);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(mapping.Matches, Is.Empty);
			Assert.That(mapping.UnmatchedRipped, Has.Count.EqualTo(2));
		}
	}

	[Test]
	public void AnAssetWithNoCounterpartIsReportedRatherThanDropped()
	{
		PackageGuidMapping mapping = PackageGuidMapping.Build(
			[Asset("Scripts/Gone.cs", GuidA)],
			[Asset("Scripts/Other.cs", GuidB)]);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(mapping.Matches, Is.Empty);
			Assert.That(mapping.UnmatchedRipped, Has.Count.EqualTo(1));
			Assert.That(mapping.UnmatchedRipped[0].RelativePath, Is.EqualTo("Scripts/Gone.cs"));
			Assert.That(mapping.UnmatchedOfficial, Has.Count.EqualTo(1));
		}
	}

	/// <summary>
	/// Merging two distinct assets onto one would silently conflate references to them.
	/// </summary>
	[Test]
	public void TwoAssetsMappingOntoOneIsAConflict()
	{
		PackageGuidMapping mapping = PackageGuidMapping.Build(
			[Asset("A.cs", GuidA), Asset("B.cs", GuidB)],
			[Asset("A.cs", GuidC), Asset("B.cs", GuidC)]);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(mapping.IsSafeToApply, Is.False);
			Assert.That(mapping.Conflicts, Has.Count.EqualTo(1));
			Assert.That(mapping.Conflicts[0], Does.Contain(GuidC));
		}
	}

	[Test]
	public void OneGuidRewrittenToTwoValuesIsAConflict()
	{
		// The same ripped asset duplicated under two paths, pointing at different official assets.
		PackageGuidMapping mapping = PackageGuidMapping.Build(
			[Asset("A.cs", GuidA), Asset("B.cs", GuidA)],
			[Asset("A.cs", GuidC), Asset("B.cs", GuidD)]);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(mapping.IsSafeToApply, Is.False);
			Assert.That(mapping.Conflicts.Exists(static c => c.Contains(GuidA, StringComparison.Ordinal)), Is.True);
		}
	}

	[Test]
	public void TheReportNamesTheConflictsAndTheMatches()
	{
		PackageGuidMapping mapping = PackageGuidMapping.Build(
			[Asset("A.cs", GuidA)],
			[Asset("A.cs", GuidB)]);

		StringWriter writer = new() { NewLine = "\n" };
		mapping.Write(writer);
		string report = writer.ToString();

		using (Assert.EnterMultipleScope())
		{
			Assert.That(report, Does.Contain("Matches: 1"));
			Assert.That(report, Does.Contain($"{GuidA},{GuidB},RelativePath,A.cs,A.cs"));
		}
	}

	[TestCase("guid: aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", GuidA)]
	[TestCase("  guid: aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa  ", GuidA)]
	public void TheGuidIsReadOutOfAMetaFile(string line, string expected)
	{
		string meta = $"fileFormatVersion: 2\n{line}\nMonoImporter:\n";

		Assert.That(MetaGuidScanner.TryReadGuid(new StringReader(meta), out string? guid), Is.True);
		Assert.That(guid, Is.EqualTo(expected));
	}

	[TestCase("fileFormatVersion: 2\nMonoImporter:\n")]
	[TestCase("guid: notaguid\n")]
	[TestCase("guid: aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n")]
	public void AMetaFileWithoutAUsableGuidIsRejected(string meta)
	{
		Assert.That(MetaGuidScanner.TryReadGuid(new StringReader(meta), out _), Is.False);
	}

	[Test]
	public void ScanningReadsGuidsAndPathsRelativeToTheRoot()
	{
		string root = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());
		Directory.CreateDirectory(Path.Join(root, "Shaders"));
		try
		{
			File.WriteAllText(Path.Join(root, "Shaders", "TMP_SDF.shader"), "");
			File.WriteAllText(Path.Join(root, "Shaders", "TMP_SDF.shader.meta"), $"fileFormatVersion: 2\nguid: {GuidA}\n");

			List<AssetIdentity> identities = MetaGuidScanner.Scan(root);

			using (Assert.EnterMultipleScope())
			{
				Assert.That(identities, Has.Count.EqualTo(1));
				Assert.That(identities[0].RelativePath, Is.EqualTo("Shaders/TMP_SDF.shader"));
				Assert.That(identities[0].Guid, Is.EqualTo(GuidA));
			}
		}
		finally
		{
			Directory.Delete(root, true);
		}
	}
}
