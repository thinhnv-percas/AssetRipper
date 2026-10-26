using AssetRipper.Export.Configuration;
using AssetRipper.Export.UnityProjects.PackageRemapping;
using AssetRipper.IO.Files;

namespace AssetRipper.Tests;

/// <summary>
/// An Editor's built-in packages as a remap source, and what a package has to show before it is applied.
/// </summary>
/// <remarks>
/// com.unity.ugui - UnityEngine.UI - ships inside the Editor and in no registry, so a cache built from the registry
/// can never place it, and the Editor's BuiltInPackages is the only source there is. But that folder is a catalog of
/// every package the Editor ships - HDRP, URP, Shader Graph, VFX Graph - not a list of what the game used, and assets
/// match across packages by name: on RunFromZombies, a Built-in RP game, PostProcessing v2's Hidden shaders and blue
/// noise textures matched HDRP's namesakes, and the run deleted 78 files and put HDRP in the manifest.
/// </remarks>
public sealed class PackageRemapCatalogTests
{
	private const string RippedShaderGuid = "a0000000000000000000000000000001";
	private const string OfficialShaderGuid = "b0000000000000000000000000000002";
	private const string ShaderName = "Hidden/PostProcessing/Bloom";

	private sealed class Fixture : IDisposable
	{
		public string Root { get; } = Directory.CreateTempSubdirectory("AssetRipperRemapCatalog").FullName;
		public string ExportRoot => Path.Combine(Root, "Export");
		public string AssetsPath => Path.Combine(ExportRoot, "ExportedProject", "Assets");
		public string ManifestPath => Path.Combine(ExportRoot, "ExportedProject", "Packages", "manifest.json");
		public string RippedShader => Path.Combine(AssetsPath, "Shader", "Hidden_PostProcessing_Bloom.shader");
		public string Prefab => Path.Combine(AssetsPath, "GameObject", "Camera.prefab");

		public void Dispose()
		{
			try
			{
				Directory.Delete(Root, recursive: true);
			}
			catch (IOException)
			{
			}
		}
	}

	private static void Write(string path, string contents, string? guid = null)
	{
		Directory.CreateDirectory(Path.GetDirectoryName(path)!);
		File.WriteAllText(path, contents);
		if (guid is not null)
		{
			File.WriteAllText(path + ".meta", $"fileFormatVersion: 2\nguid: {guid}\n");
		}
	}

	/// <summary>
	/// A game shader whose name a package also declares, and a package folder - catalog or cache - holding it.
	/// </summary>
	private static Fixture Build(string sourceFolderName, out string sourceFolder)
	{
		Fixture fixture = new();
		sourceFolder = Path.Combine(fixture.Root, sourceFolderName);
		string package = Path.Combine(sourceFolder, "com.unity.render-pipelines.high-definition");
		Write(Path.Combine(package, "package.json"), "{\"name\":\"com.unity.render-pipelines.high-definition\",\"version\":\"14.0.12\"}\n");
		Write(Path.Combine(package, "Runtime", "PostProcessing", "Shaders", "Bloom.shader"), $"Shader \"{ShaderName}\" {{\n}}\n", OfficialShaderGuid);

		Write(fixture.RippedShader, $"Shader \"{ShaderName}\" {{\n}}\n", RippedShaderGuid);
		Write(fixture.Prefab, $"  m_Shader: {{fileID: 4800000, guid: {RippedShaderGuid}, type: 3}}\n", "c0000000000000000000000000000003");
		return fixture;
	}

	private static PackageRemapRun RunFrom(Fixture fixture, string sourceFolder)
		=> RunFrom(fixture, new PackageSource { Kind = PackageSourceKind.Cache, Location = sourceFolder });

	private static PackageRemapRun RunFrom(Fixture fixture, PackageSource source)
	{
		FullConfiguration settings = new() { ExportRootPath = fixture.ExportRoot };
		PackageRemapRun run = new(settings, LocalFileSystem.Instance, new PackageRemapConfiguration());
		PackageSourceResult result = PackageSourceResolver.Resolve(source, GitFetchMode.Never);
		foreach (ResolvedPackage package in result.Packages)
		{
			run.Consider(package);
		}
		run.Finish();
		return run;
	}

	[Test]
	public void AnEditorsBuiltInPackagesFolderIsACatalog()
	{
		Assert.That(PackageSourceResolver.IsEditorCatalog("/opt/Unity/Editor/Data/Resources/PackageManager/BuiltInPackages"), Is.True);
		Assert.That(PackageSourceResolver.IsEditorCatalog("/opt/Unity/Editor/Data/Resources/PackageManager/BuiltInPackages/"), Is.True);
		Assert.That(PackageSourceResolver.IsEditorCatalog("/project/Library/PackageCache"), Is.False);
	}

	[Test]
	public void FromACatalogAPackageWhoseCodeTheGameLacksIsLeftAloneAssetsIncluded()
	{
		using Fixture fixture = Build("BuiltInPackages", out string catalog);

		PackageRemapRun run = RunFrom(fixture, catalog);

		Assert.Multiple(() =>
		{
			PackageOutcome outcome = run.Outcomes.Single();
			Assert.That(outcome.NoCodeEvidence, Is.True);
			Assert.That(outcome.AddedToManifest, Is.False, "HDRP must not reach the manifest of a game that never used it");
			Assert.That(File.Exists(fixture.RippedShader), Is.True, "the game's own shader must not be deleted");
			Assert.That(File.ReadAllText(fixture.Prefab), Does.Contain(RippedShaderGuid), "nor its reference repointed");
			Assert.That(run.PackageGuids, Is.Empty);
		});
	}

	[Test]
	public void FromAProjectsOwnCacheTheSameMatchStillApplies()
	{
		// A project's Library/PackageCache lists what that project resolved, so a package in it was used.
		using Fixture fixture = Build("PackageCache", out string cache);

		PackageRemapRun run = RunFrom(fixture, cache);

		Assert.Multiple(() =>
		{
			PackageOutcome outcome = run.Outcomes.Single();
			Assert.That(outcome.NoCodeEvidence, Is.False);
			Assert.That(outcome.ShadersPaired, Is.EqualTo(1));
			Assert.That(File.ReadAllText(fixture.Prefab), Does.Contain(OfficialShaderGuid));
			Assert.That(run.PackageGuids[OfficialShaderGuid], Is.EqualTo("com.unity.render-pipelines.high-definition"));
		});
	}

	[Test]
	public void APackageThatPairedNothingIsNotAddedBecauseAnEarlierOneDid()
	{
		// The run-wide script list used to decide each package's manifest entry, so a package considered after one
		// that paired a type went into the manifest with nothing of its own paired. com.unity.ui, ui.builder, VFX
		// Graph and nuget.mono-cecil reached RunFromZombies' manifest that way.
		using Fixture fixture = Build("PackageCache", out string cache);
		Write(Path.Combine(cache, "com.unity.nothing", "package.json"), "{\"name\":\"com.unity.nothing\",\"version\":\"1.0.0\"}\n");

		PackageRemapRun run = RunFrom(fixture, cache);

		Assert.Multiple(() =>
		{
			Assert.That(run.Outcomes.Single(o => o.Name == "com.unity.render-pipelines.high-definition").AddedToManifest, Is.True);
			Assert.That(run.Outcomes.Single(o => o.Name == "com.unity.nothing").AddedToManifest, Is.False);
			Assert.That(File.ReadAllText(fixture.ManifestPath), Does.Not.Contain("com.unity.nothing"));
		});
	}

	[Test]
	public void AFolderMarkedAsACatalogIsOne()
	{
		// A repository collecting Asset Store packages is the shape of BuiltInPackages, whatever it is called: on
		// Kitty Knots nine packages of ThinhNV-DEV/unity-package reached the manifest on file names alone.
		using Fixture fixture = Build("unity-package", out string repository);

		PackageRemapRun run = RunFrom(fixture, new PackageSource { Kind = PackageSourceKind.Folder, Location = repository, Catalog = true });

		Assert.Multiple(() =>
		{
			Assert.That(run.Outcomes.Single().NoCodeEvidence, Is.True);
			Assert.That(File.Exists(fixture.RippedShader), Is.True);
			Assert.That(File.ReadAllText(fixture.Prefab), Does.Contain(RippedShaderGuid));
		});
	}

	[Test]
	public void ADecompiledAssemblyThePackageReplacesIsCodeEvidence()
	{
		// DOTween Pro ships DOTween.dll and the game's DOTween was decompiled, so nothing paired as a type or as a DLL
		// file and the package read as 0 and 0 while replacing the whole folder.
		using Fixture fixture = Build("unity-package", out string repository);
		string package = Path.Combine(repository, "com.demigiant.dotween.pro");
		Write(Path.Combine(package, "package.json"), "{\"name\":\"com.demigiant.dotween.pro\",\"version\":\"1.0.386\"}\n");
		string assembly = Path.Combine(package, "DOTween", "DOTween.dll");
		Directory.CreateDirectory(Path.GetDirectoryName(assembly)!);
		new AsmResolver.DotNet.ModuleDefinition("DOTween.dll").Write(assembly);
		File.WriteAllText(assembly + ".meta", "fileFormatVersion: 2\nguid: d0000000000000000000000000000004\n");
		string ripped = Path.Combine(fixture.AssetsPath, "Scripts", "DOTween", "DG", "Tweening", "Tween.cs");
		Write(ripped, "namespace DG.Tweening { public class Tween { } }\n", "e0000000000000000000000000000005");

		PackageRemapRun run = RunFrom(fixture, new PackageSource { Kind = PackageSourceKind.Folder, Location = repository, Catalog = true });

		Assert.Multiple(() =>
		{
			PackageOutcome outcome = run.Outcomes.Single(o => o.Name == "com.demigiant.dotween.pro");
			Assert.That(outcome.NoCodeEvidence, Is.False);
			Assert.That(outcome.AssembliesPaired, Is.EqualTo(1));
			Assert.That(outcome.AddedToManifest, Is.True);
			Assert.That(File.Exists(ripped), Is.False, "the decompiled copy is replaced by the package");
			Assert.That(run.Outcomes.Single(o => o.Name == "com.unity.render-pipelines.high-definition").NoCodeEvidence, Is.True);
		});
	}
}
