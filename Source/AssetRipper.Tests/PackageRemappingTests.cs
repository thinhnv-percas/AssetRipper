using AssetRipper.Export.UnityProjects.PackageRemapping;
using AssetRipper.Export.UnityProjects.Scripts;

namespace AssetRipper.Tests;

/// <summary>
/// Swapping a ripped package for the official one is a destructive edit of a whole project, so the
/// rules it follows are pinned down here rather than discovered on someone's project.
/// </summary>
public sealed class PackageRemappingTests
{
	private const string RippedShaderGuid = "446635c639a68754da00264d9ac02476";
	private const string OfficialShaderGuid = "0f4122b9a34c1ff4b9b9b5f8b7f8b8c1";
	private const string OfficialAssemblyGuid = "f4688fdb7df04437aeb418b961361dc5";

	/// <summary>
	/// A decompiled script is referred to by the one fileID every script file has. Both halves of the
	/// reference have to move, and this is the half the ripped project wrote.
	/// </summary>
	[Test]
	public void ADecompiledScriptIsReferredToByTheScriptFileId()
	{
		Assert.That(ScriptReferenceMapping.DecompiledScriptFileId, Is.EqualTo(11500000));
	}

	/// <summary>
	/// Neither end of a script reference has to be read out of the project: AssetRipper derives the
	/// decompiled script's guid from the type's identity, so the official assembly gives both.
	/// </summary>
	[Test]
	public void AScriptRemapDerivesBothEndsFromTheTypeIdentity()
	{
		ScriptRemap remap = ScriptReferenceMapping.Build("Unity.TextMeshPro.dll", OfficialAssemblyGuid, "TMPro", "TextMeshProUGUI");

		Assert.Multiple(() =>
		{
			Assert.That(remap.TypeFullName, Is.EqualTo("TMPro.TextMeshProUGUI"));
			Assert.That(remap.Old.FileId, Is.EqualTo(ScriptReferenceMapping.DecompiledScriptFileId));
			Assert.That(remap.Old.Guid, Is.EqualTo(ScriptHashing.CalculateScriptGuid(
				System.Text.Encoding.UTF8.GetBytes("Unity.TextMeshPro"),
				System.Text.Encoding.UTF8.GetBytes("TMPro"),
				System.Text.Encoding.UTF8.GetBytes("TextMeshProUGUI")).ToString()));
			Assert.That(remap.New.Guid, Is.EqualTo(OfficialAssemblyGuid));
			Assert.That(remap.New.FileId, Is.EqualTo(ScriptHashing.CalculateScriptFileID("TMPro", "TextMeshProUGUI")));
		});
	}

	[Test]
	public void TheAssemblyExtensionIsOptional()
	{
		ScriptRemap withExtension = ScriptReferenceMapping.Build("Unity.TextMeshPro.dll", OfficialAssemblyGuid, "TMPro", "TMP_Text");
		ScriptRemap without = ScriptReferenceMapping.Build("Unity.TextMeshPro", OfficialAssemblyGuid, "TMPro", "TMP_Text");

		Assert.That(withExtension, Is.EqualTo(without));
	}

	private static ProjectRemapPlan Plan(params ScriptRemap[] scripts)
	{
		PackageGuidMapping mapping = new()
		{
			Matches = [new GuidMatch("Shaders/TMP_SDF.shader", "Shaders/TMP_SDF.shader", RippedShaderGuid, OfficialShaderGuid, GuidMatchKind.RelativePath)],
			UnmatchedRipped = [new AssetIdentity("Fonts/Custom.asset", "11111111111111111111111111111111")],
			UnmatchedOfficial = [],
			Conflicts = [],
		};

		return ProjectRemapPlan.Build(mapping, scripts);
	}

	/// <summary>
	/// A material names its shader exactly the way a component names its script, so the shader guid has
	/// to be rewritten too. A material whose shader guid is left behind renders magenta.
	/// </summary>
	[Test]
	public void AShaderReferenceKeepsItsFileIdAndChangesGuid()
	{
		RemapReport report = new();
		string rewritten = ProjectReferenceRewriter.Rewrite(
			$"  m_Shader: {{fileID: 4800000, guid: {RippedShaderGuid}, type: 3}}\n",
			Plan(),
			report);

		Assert.Multiple(() =>
		{
			Assert.That(rewritten, Is.EqualTo($"  m_Shader: {{fileID: 4800000, guid: {OfficialShaderGuid}, type: 3}}\n"));
			Assert.That(report.GuidsRewritten, Is.EqualTo(1));
			Assert.That(report.ScriptReferencesRewritten, Is.Zero);
		});
	}

	/// <summary>
	/// The case a guid only remap gets wrong: the fileID has to be recomputed for the assembly, or the
	/// reference resolves to nothing inside it while looking repaired in a diff.
	/// </summary>
	[Test]
	public void AScriptReferenceChangesBothHalves()
	{
		ScriptRemap remap = ScriptReferenceMapping.Build("Unity.TextMeshPro.dll", OfficialAssemblyGuid, "TMPro", "TextMeshProUGUI");

		RemapReport report = new();
		string rewritten = ProjectReferenceRewriter.Rewrite(
			$"  m_Script: {{fileID: {ScriptReferenceMapping.DecompiledScriptFileId}, guid: {remap.Old.Guid}, type: 3}}\n",
			Plan(remap),
			report);

		Assert.Multiple(() =>
		{
			Assert.That(rewritten, Is.EqualTo($"  m_Script: {{fileID: {remap.New.FileId}, guid: {OfficialAssemblyGuid}, type: 3}}\n"));
			Assert.That(report.ScriptReferencesRewritten, Is.EqualTo(1));
		});
	}

	/// <summary>
	/// A meta file holds the asset's own guid and references to other assets in the same document.
	/// Rewriting the identity would hand the official package's identity to the ripped copy, so only a
	/// guid written as part of a reference is touched.
	/// </summary>
	[Test]
	public void AnAssetsOwnGuidIsNotRewritten()
	{
		RemapReport report = new();
		string meta = $"fileFormatVersion: 2\nguid: {RippedShaderGuid}\nShaderImporter:\n  defaultTextures: []\n";

		Assert.Multiple(() =>
		{
			Assert.That(ProjectReferenceRewriter.Rewrite(meta, Plan(), report), Is.EqualTo(meta));
			Assert.That(report.GuidsRewritten, Is.Zero);
		});
	}

	/// <summary>
	/// An assembly definition names what it depends on in a form of its own.
	/// </summary>
	[Test]
	public void AnAssemblyDefinitionReferenceIsRewritten()
	{
		RemapReport report = new();
		string rewritten = ProjectReferenceRewriter.Rewrite(
			$"{{\n  \"name\": \"Game\",\n  \"references\": [\"GUID:{RippedShaderGuid}\"]\n}}\n",
			Plan(),
			report);

		Assert.That(rewritten, Does.Contain($"GUID:{OfficialShaderGuid}"));
	}

	/// <summary>
	/// A rewrite that leaves references pointing at the ripped package is a partial success, which is
	/// the failure this whole thing exists to make visible.
	/// </summary>
	[Test]
	public void ReferencesWithNothingToPointAtAreCounted()
	{
		RemapReport report = new();
		const string Unmapped = "11111111111111111111111111111111";
		ProjectReferenceRewriter.Rewrite(
			$"  a: {{fileID: 11400000, guid: {Unmapped}, type: 2}}\n  b: {{fileID: 11400000, guid: {Unmapped}, type: 2}}\n",
			Plan(),
			report);

		Assert.That(report.UnresolvedByGuid[Unmapped], Is.EqualTo(2));
	}

	/// <summary>
	/// A guid that belongs to neither package is left alone and is not reported as a problem.
	/// </summary>
	[Test]
	public void AnUnrelatedReferenceIsUntouched()
	{
		RemapReport report = new();
		const string Text = "  m_Sprite: {fileID: 21300000, guid: 99999999999999999999999999999999, type: 3}\n";

		Assert.Multiple(() =>
		{
			Assert.That(ProjectReferenceRewriter.Rewrite(Text, Plan(), report), Is.EqualTo(Text));
			Assert.That(report.UnresolvedByGuid, Is.Empty);
		});
	}

	/// <summary>
	/// The rewrite edits a project in place, so it reports before it writes.
	/// </summary>
	[Test]
	public void ADryRunChangesNothingOnDisk()
	{
		using TemporaryDirectory directory = new();
		string prefab = Path.Combine(directory.Path, "Cube.prefab");
		string original = $"  m_Shader: {{fileID: 4800000, guid: {RippedShaderGuid}, type: 3}}\n";
		File.WriteAllText(prefab, original);

		RemapReport report = ProjectReferenceRewriter.Apply(directory.Path, Plan());

		Assert.Multiple(() =>
		{
			Assert.That(report.FilesChanged, Is.EqualTo(1));
			Assert.That(File.ReadAllText(prefab), Is.EqualTo(original));
		});
	}

	[Test]
	public void ApplyingWritesTheFileAndBacksUpTheOriginal()
	{
		using TemporaryDirectory directory = new();
		string assets = Path.Combine(directory.Path, "Assets");
		string backup = Path.Combine(directory.Path, "Backup");
		Directory.CreateDirectory(Path.Combine(assets, "Prefabs"));

		string prefab = Path.Combine(assets, "Prefabs", "Cube.prefab");
		string original = $"  m_Shader: {{fileID: 4800000, guid: {RippedShaderGuid}, type: 3}}\n";
		File.WriteAllText(prefab, original);

		// A source file can hold something guid shaped and must never be rewritten.
		string source = Path.Combine(assets, "Script.cs");
		string sourceText = $"// guid: {RippedShaderGuid}\n";
		File.WriteAllText(source, sourceText);

		RemapReport report = ProjectReferenceRewriter.Apply(assets, Plan(), dryRun: false, backupDirectory: backup);

		Assert.Multiple(() =>
		{
			Assert.That(report.FilesChanged, Is.EqualTo(1));
			Assert.That(File.ReadAllText(prefab), Does.Contain(OfficialShaderGuid));
			Assert.That(File.ReadAllText(Path.Combine(backup, "Prefabs", "Cube.prefab")), Is.EqualTo(original));
			Assert.That(File.ReadAllText(source), Is.EqualTo(sourceText));
		});
	}

	private sealed class TemporaryDirectory : IDisposable
	{
		public string Path { get; } = Directory.CreateTempSubdirectory("AssetRipperRemapTests").FullName;

		public void Dispose()
		{
			try
			{
				Directory.Delete(Path, recursive: true);
			}
			catch (IOException)
			{
			}
		}
	}
}
