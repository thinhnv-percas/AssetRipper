using AssetRipper.Export.Configuration;
using AssetRipper.Export.UnityProjects.PackageRemapping;
using AssetRipper.IO.Files;

namespace AssetRipper.Tests;

/// <summary>
/// The whole export time job, from a package cache and an export to a project that refers to the real
/// packages. This runs against a real assembly, because the script half is derived from the types in
/// one and a stub would prove nothing.
/// </summary>
public sealed class PackageRemapRunTests
{
	private const string PackageName = "com.unity.testpackage";
	private const string PackageVersion = "3.0.6";
	private const string RippedShaderGuid = "446635c639a68754da00264d9ac02476";
	private const string OfficialShaderGuid = "0f4122b9a34c1ff4b9b9b5f8b7f8b8c1";
	private const string AssemblyGuid = "f4688fdb7df04437aeb418b961361dc5";
	private const string UserAssetGuid = "77777777777777777777777777777777";

	private sealed class Fixture : IDisposable
	{
		public string Root { get; } = Directory.CreateTempSubdirectory("AssetRipperRemapRun").FullName;

		public string CachePath => Path.Combine(Root, "PackageCache");
		public string PackagePath => Path.Combine(CachePath, $"{PackageName}@{PackageVersion}");
		public string ExportRoot => Path.Combine(Root, "Export");
		public string AssetsPath => Path.Combine(ExportRoot, "ExportedProject", "Assets");
		public string RippedRoot => Path.Combine(AssetsPath, "Test Package");
		public string ManifestPath => Path.Combine(ExportRoot, "ExportedProject", "Packages", "manifest.json");
		public string ConfigurationPath => Path.Combine(Root, PackageRemapConfiguration.FileName);

		/// <summary>
		/// A real assembly, so the types the script half is built from are real ones.
		/// </summary>
		public static string SourceAssembly => typeof(PackageRemapConfiguration).Assembly.Location;

		public string SourceAssemblyName => Path.GetFileNameWithoutExtension(SourceAssembly);

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

	private static void WritePair(string directory, string name, string guid)
	{
		Directory.CreateDirectory(directory);
		File.WriteAllText(Path.Combine(directory, name), "x\n");
		File.WriteAllText(Path.Combine(directory, name + ".meta"), $"fileFormatVersion: 2\nguid: {guid}\n");
	}

	private static Fixture Build(out ScriptRemap scriptRemap)
	{
		Fixture fixture = new();

		Directory.CreateDirectory(fixture.PackagePath);
		File.WriteAllText(Path.Combine(fixture.PackagePath, "package.json"), $"{{\"name\":\"{PackageName}\",\"version\":\"{PackageVersion}\"}}\n");

		WritePair(Path.Combine(fixture.PackagePath, "Shaders"), "A.shader", OfficialShaderGuid);
		WritePair(Path.Combine(fixture.PackagePath, "Shaders"), "B.shader", "88888888888888888888888888888888");
		WritePair(Path.Combine(fixture.PackagePath, "Resources"), "C.asset", "99999999999999999999999999999999");

		Directory.CreateDirectory(Path.Combine(fixture.PackagePath, "Runtime"));
		string assemblyPath = Path.Combine(fixture.PackagePath, "Runtime", Path.GetFileName(Fixture.SourceAssembly));
		File.Copy(Fixture.SourceAssembly, assemblyPath);
		File.WriteAllText(assemblyPath + ".meta", $"fileFormatVersion: 2\nguid: {AssemblyGuid}\n");

		WritePair(Path.Combine(fixture.RippedRoot, "Shaders"), "A.shader", RippedShaderGuid);
		WritePair(Path.Combine(fixture.RippedRoot, "Shaders"), "B.shader", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
		WritePair(Path.Combine(fixture.RippedRoot, "Resources"), "C.asset", "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");

		// Something the user put in the same folder, which the package has no counterpart for.
		WritePair(Path.Combine(fixture.RippedRoot, "Resources"), "Mine.asset", UserAssetGuid);

		// A decompiled script of the package's assembly, where AssetRipper writes it.
		string scriptFolder = Path.Combine(fixture.AssetsPath, "Scripts", fixture.SourceAssemblyName);
		Directory.CreateDirectory(scriptFolder);
		File.WriteAllText(Path.Combine(scriptFolder, "Anything.cs"), "class Anything {}\n");
		File.WriteAllText(Path.Combine(scriptFolder, "Anything.cs.meta"), "fileFormatVersion: 2\nguid: cccccccccccccccccccccccccccccccc\n");

		scriptRemap = ScriptReferenceMapping.Build(fixture.PackagePath).Remaps[0];

		Directory.CreateDirectory(Path.Combine(fixture.AssetsPath, "Prefabs"));
		File.WriteAllText(Path.Combine(fixture.AssetsPath, "Prefabs", "Cube.prefab"),
			$"  m_Script: {{fileID: {scriptRemap.Old.FileId}, guid: {scriptRemap.Old.Guid}, type: 3}}\n" +
			$"  m_Shader: {{fileID: 4800000, guid: {RippedShaderGuid}, type: 3}}\n" +
			$"  m_Mine:   {{fileID: 11400000, guid: {UserAssetGuid}, type: 2}}\n");

		return fixture;
	}

	private static PackageRemapRun Run(Fixture fixture, PackageRemapConfiguration configuration)
	{
		FullConfiguration settings = new() { ExportRootPath = fixture.ExportRoot };
		settings.ExportSettings.OfficialPackageCachePath = fixture.CachePath;

		PackageRemapRun run = new(settings, LocalFileSystem.Instance, configuration);
		run.Consider(fixture.PackagePath);
		run.Finish();
		return run;
	}

	[Test]
	public void AProjectEndsUpReferringToTheRealPackage()
	{
		using Fixture fixture = Build(out ScriptRemap scriptRemap);
		Run(fixture, new PackageRemapConfiguration());

		string prefab = File.ReadAllText(Path.Combine(fixture.AssetsPath, "Prefabs", "Cube.prefab"));

		Assert.Multiple(() =>
		{
			Assert.That(prefab, Does.Contain($"{{fileID: {scriptRemap.New.FileId}, guid: {AssemblyGuid}, type: 3}}"), "the script reference moves both halves");
			Assert.That(prefab, Does.Contain($"guid: {OfficialShaderGuid}"), "the shader reference is repointed");
			Assert.That(prefab, Does.Contain($"guid: {UserAssetGuid}"), "a reference the package has no counterpart for is left alone");
		});
	}

	/// <summary>
	/// Repointing references is only half the job. Leaving the decompiled scripts behind means Unity
	/// compiles them alongside the package's assembly and every type exists twice.
	/// </summary>
	[Test]
	public void TheFilesThePackageReplacesAreDeleted()
	{
		using Fixture fixture = Build(out _);
		Run(fixture, new PackageRemapConfiguration());

		Assert.Multiple(() =>
		{
			Assert.That(File.Exists(Path.Combine(fixture.RippedRoot, "Shaders", "A.shader")), Is.False);
			Assert.That(File.Exists(Path.Combine(fixture.RippedRoot, "Shaders", "A.shader.meta")), Is.False);
			Assert.That(Directory.Exists(Path.Combine(fixture.AssetsPath, "Scripts", fixture.SourceAssemblyName)), Is.False);
			Assert.That(File.Exists(Path.Combine(fixture.RippedRoot, "Resources", "Mine.asset")), Is.True, "a file the package has no counterpart for stays");
		});
	}

	[Test]
	public void ThePackageIsAddedToTheProjectManifest()
	{
		using Fixture fixture = Build(out _);
		Run(fixture, new PackageRemapConfiguration());

		Assert.That(File.ReadAllText(fixture.ManifestPath), Does.Contain($"\"{PackageName}\": \"{PackageVersion}\""));
	}

	/// <summary>
	/// Deleting is the part someone might not want, so it is the part that can be turned off.
	/// </summary>
	[Test]
	public void DeletingCanBeTurnedOff()
	{
		using Fixture fixture = Build(out _);
		Run(fixture, new PackageRemapConfiguration { DeleteRippedCopies = false });

		Assert.Multiple(() =>
		{
			Assert.That(File.Exists(Path.Combine(fixture.RippedRoot, "Shaders", "A.shader")), Is.True);
			Assert.That(File.ReadAllText(fixture.ManifestPath), Does.Contain(PackageName), "the manifest entry is unaffected");
		});
	}

	[Test]
	public void APackageCanBeSkipped()
	{
		using Fixture fixture = Build(out _);
		PackageRemapConfiguration configuration = new();
		configuration.Packages.Add(new PackageRemapEntry { Name = PackageName, Skip = true });

		Run(fixture, configuration);

		Assert.Multiple(() =>
		{
			Assert.That(File.Exists(Path.Combine(fixture.RippedRoot, "Shaders", "A.shader")), Is.True);
			Assert.That(File.ReadAllText(Path.Combine(fixture.AssetsPath, "Prefabs", "Cube.prefab")), Does.Contain(RippedShaderGuid));
		});
	}

	/// <summary>
	/// The configuration records what the run worked out, so a package the locator missed can be placed
	/// by editing it rather than by guesswork.
	/// </summary>
	[Test]
	public void TheRunRecordsWhatItFound()
	{
		using Fixture fixture = Build(out _);
		PackageRemapConfiguration configuration = new();
		Run(fixture, configuration);

		PackageRemapEntry? entry = configuration.Find(PackageName);

		Assert.Multiple(() =>
		{
			Assert.That(entry, Is.Not.Null);
			Assert.That(entry!.Folder, Is.EqualTo("Test Package"));
			Assert.That(entry.Version, Is.EqualTo(PackageVersion));
		});
	}

	[Test]
	public void AConfiguredFolderIsUsedInsteadOfSearching()
	{
		using Fixture fixture = Build(out _);
		PackageRemapConfiguration configuration = new();
		configuration.Packages.Add(new PackageRemapEntry { Name = PackageName, Folder = "Nowhere" });

		PackageRemapRun run = Run(fixture, configuration);

		Assert.Multiple(() =>
		{
			Assert.That(run.Outcomes.Single().Folder, Is.Empty, "the configured folder does not exist, so no assets are paired");
			Assert.That(File.Exists(Path.Combine(fixture.RippedRoot, "Shaders", "A.shader")), Is.True);
		});
	}

	[Test]
	public void TheConfigurationRoundTripsThroughItsFile()
	{
		using Fixture fixture = Build(out _);
		PackageRemapConfiguration written = new() { DeleteRippedCopies = false };
		written.Packages.Add(new PackageRemapEntry { Name = PackageName, Version = "1.2.3", Folder = "Somewhere", Skip = true });
		written.Save(fixture.ConfigurationPath);

		PackageRemapConfiguration read = PackageRemapConfiguration.Load(fixture.ConfigurationPath);
		PackageRemapEntry? entry = read.Find(PackageName);

		Assert.Multiple(() =>
		{
			Assert.That(read.DeleteRippedCopies, Is.False);
			Assert.That(entry, Is.Not.Null);
			Assert.That(entry!.Version, Is.EqualTo("1.2.3"));
			Assert.That(entry.Folder, Is.EqualTo("Somewhere"));
			Assert.That(entry.Skip, Is.True);
		});
	}

	/// <summary>
	/// A file that cannot be parsed should not stop an export.
	/// </summary>
	[Test]
	public void AMalformedConfigurationFallsBackToTheDefaults()
	{
		using Fixture fixture = Build(out _);
		File.WriteAllText(fixture.ConfigurationPath, "{ not json");

		Assert.That(PackageRemapConfiguration.Load(fixture.ConfigurationPath).DeleteRippedCopies, Is.True);
	}
}
