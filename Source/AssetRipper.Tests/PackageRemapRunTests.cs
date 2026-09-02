using AssetRipper.Export.Configuration;
using AssetRipper.Export.UnityProjects.PackageRemapping;
using AssetRipper.Export.UnityProjects.Scripts;
using AssetRipper.IO.Files;

namespace AssetRipper.Tests;

/// <summary>
/// The whole export time job, against an export shaped the way AssetRipper actually writes one and a
/// package shaped the way Unity actually ships one.
/// </summary>
/// <remarks>
/// Both sides have been got wrong before, so both are built from real artifacts here. An export groups
/// assets by type rather than by origin, names a shader after the shader rather than the file, and in
/// the default mode saves a package's code as an assembly under Plugins. A package, meanwhile, usually
/// ships source and an assembly definition and no assembly at all: com.unity.textmeshpro is 109 .cs
/// files and no dll anywhere. The ripped assembly here is a real one, so its types are real types.
/// </remarks>
public sealed class PackageRemapRunTests
{
	private const string PackageName = "com.unity.testpackage";
	private const string PackageVersion = "3.0.6";
	private const string ShaderName = "TextMeshPro/Distance Field";

	private const string RippedAssemblyGuid = "67dfb1fdfb2b407222eda8e23ac8b724";
	private const string RippedShaderGuid = "614273de7bf1ec349adb71aafbc3a359";
	private const string RippedFontGuid = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
	private const string RippedScriptGuid = "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee";
	private const string GameAssetGuid = "77777777777777777777777777777777";

	/// <summary>
	/// The guid of the package's own source file for the type, which is what a reference to it becomes.
	/// </summary>
	private const string OfficialScriptGuid = "f4688fdb7df04437aeb418b961361dc5";
	private const string OfficialShaderGuid = "0f4122b9a34c1ff4b9b9b5f8b7f8b8c1";
	private const string OfficialFontGuid = "33333333333333333333333333333333";

	/// <summary>
	/// A type that really is in the assembly the fixture rips, so the mapping is derived from a real
	/// assembly rather than asserted into existence.
	/// </summary>
	private static readonly Type SampleType = typeof(PackageRemapConfiguration);

	private static string AssemblyName => Path.GetFileNameWithoutExtension(SampleType.Assembly.Location);
	private static string ClassName => SampleType.Name;
	private static string Namespace => SampleType.Namespace ?? "";

	/// <summary>
	/// What a reference to that type looks like once its assembly was saved rather than decompiled.
	/// </summary>
	private static long SavedAssemblyFileId => ScriptHashing.CalculateScriptFileID(Namespace, ClassName);

	private sealed class Fixture : IDisposable
	{
		public string Root { get; } = Directory.CreateTempSubdirectory("AssetRipperRemapRun").FullName;

		public string PackagePath => Path.Combine(Root, "PackageCache", $"{PackageName}@{PackageVersion}");
		public string ExportRoot => Path.Combine(Root, "Export");
		public string AssetsPath => Path.Combine(ExportRoot, "ExportedProject", "Assets");
		public string ManifestPath => Path.Combine(ExportRoot, "ExportedProject", "Packages", "manifest.json");
		public string ConfigurationPath => Path.Combine(Root, PackageRemapConfiguration.FileName);

		public string RippedAssembly => Path.Combine(AssetsPath, "Plugins", AssemblyName + ".dll");
		public string RippedScriptFolder => Path.Combine(AssetsPath, "Scripts", AssemblyName);
		public string RippedShader => Path.Combine(AssetsPath, "Shader", "TextMeshPro_Distance Field.shader");
		public string RippedFont => Path.Combine(AssetsPath, "Font", "LiberationSans.ttf");
		public string GameAsset => Path.Combine(AssetsPath, "Font", "MyOwnFont.ttf");
		public string Prefab => Path.Combine(AssetsPath, "GameObject", "Cube.prefab");

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

	private static void Write(string path, string contents, string guid)
	{
		Directory.CreateDirectory(Path.GetDirectoryName(path)!);
		File.WriteAllText(path, contents);
		File.WriteAllText(path + ".meta", $"fileFormatVersion: 2\nguid: {guid}\n");
	}

	private static Fixture Build()
	{
		Fixture fixture = new();

		Directory.CreateDirectory(Path.Combine(fixture.PackagePath, "Runtime"));
		File.WriteAllText(Path.Combine(fixture.PackagePath, "package.json"), $"{{\"name\":\"{PackageName}\",\"version\":\"{PackageVersion}\"}}\n");

		// A real package ships source and an assembly definition, and no assembly.
		File.WriteAllText(Path.Combine(fixture.PackagePath, "Runtime", AssemblyName + ".asmdef"), $"{{\n  \"name\": \"{AssemblyName}\"\n}}\n");
		Write(Path.Combine(fixture.PackagePath, "Runtime", ClassName + ".cs"), "class Whatever {}\n", OfficialScriptGuid);
		Write(Path.Combine(fixture.PackagePath, "Shaders", "TMP_SDF.shader"), $"Shader \"{ShaderName}\" {{\n}}\n", OfficialShaderGuid);
		Write(Path.Combine(fixture.PackagePath, "Fonts", "LiberationSans.ttf"), "font", OfficialFontGuid);

		// The export names things after the asset and groups them by type.
		Directory.CreateDirectory(Path.GetDirectoryName(fixture.RippedAssembly)!);
		File.Copy(SampleType.Assembly.Location, fixture.RippedAssembly);
		File.WriteAllText(fixture.RippedAssembly + ".meta", $"fileFormatVersion: 2\nguid: {RippedAssemblyGuid}\n");

		Write(fixture.RippedShader, $"Shader \"{ShaderName}\" {{\n}}\n", RippedShaderGuid);
		Write(fixture.RippedFont, "font", RippedFontGuid);

		// Something out of the game itself, which the package has no counterpart for.
		Write(fixture.GameAsset, "font", GameAssetGuid);

		Write(fixture.Prefab,
			$"  m_Script: {{fileID: {SavedAssemblyFileId}, guid: {RippedAssemblyGuid}, type: 3}}\n" +
			$"  m_Shader: {{fileID: 4800000, guid: {RippedShaderGuid}, type: 3}}\n" +
			$"  m_Font:   {{fileID: 12800000, guid: {RippedFontGuid}, type: 3}}\n" +
			$"  m_Mine:   {{fileID: 12800000, guid: {GameAssetGuid}, type: 3}}\n",
			"bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");

		return fixture;
	}

	private static PackageRemapRun Run(Fixture fixture, PackageRemapConfiguration configuration)
	{
		FullConfiguration settings = new() { ExportRootPath = fixture.ExportRoot };

		PackageRemapRun run = new(settings, LocalFileSystem.Instance, configuration);
		run.Consider(fixture.PackagePath);
		run.Finish();
		return run;
	}

	/// <summary>
	/// The case that matters, and the one that was broken: the package ships the type as a source file,
	/// so a reference to it becomes the plain script reference Unity writes for any source file. Both
	/// halves move, because the ripped side had the assembly's guid and a fileID derived from the type.
	/// </summary>
	[Test]
	public void AReferenceIntoASavedAssemblyBecomesAReferenceToThePackagesSourceFile()
	{
		using Fixture fixture = Build();
		Run(fixture, new PackageRemapConfiguration());

		Assert.That(
			File.ReadAllText(fixture.Prefab),
			Does.Contain($"m_Script: {{fileID: {ScriptReferenceMapping.DecompiledScriptFileId}, guid: {OfficialScriptGuid}, type: 3}}"));
	}

	/// <summary>
	/// The other export mode writes one file per type instead, each with a guid of its own, so only the
	/// guid moves.
	/// </summary>
	[Test]
	public void ADecompiledScriptIsRepointedAtThePackagesSourceFile()
	{
		using Fixture fixture = Build();

		// There is no assembly under Plugins in this mode, only the decompiled sources.
		File.Delete(fixture.RippedAssembly);
		File.Delete(fixture.RippedAssembly + ".meta");

		Write(Path.Combine(fixture.RippedScriptFolder, Namespace.Replace('.', Path.DirectorySeparatorChar), ClassName + ".cs"), "class Whatever {}\n", RippedScriptGuid);
		File.WriteAllText(fixture.Prefab, $"  m_Script: {{fileID: 11500000, guid: {RippedScriptGuid}, type: 3}}\n");

		Run(fixture, new PackageRemapConfiguration());

		Assert.Multiple(() =>
		{
			Assert.That(File.ReadAllText(fixture.Prefab), Is.EqualTo($"  m_Script: {{fileID: 11500000, guid: {OfficialScriptGuid}, type: 3}}\n"));
			Assert.That(Directory.Exists(fixture.RippedScriptFolder), Is.False, "the whole folder belongs to the assembly the package replaces");
		});
	}

	/// <summary>
	/// Neither side keeps the other's file name for a shader, so the name it declares is what pairs
	/// them. A material whose shader guid is left behind renders magenta.
	/// </summary>
	[Test]
	public void AShaderIsPairedByTheNameItDeclares()
	{
		using Fixture fixture = Build();
		Run(fixture, new PackageRemapConfiguration());

		Assert.That(File.ReadAllText(fixture.Prefab), Does.Contain($"guid: {OfficialShaderGuid}"));
	}

	[Test]
	public void AnAssetIsPairedByFileNameWhenItIsUniqueOnBothSides()
	{
		using Fixture fixture = Build();
		Run(fixture, new PackageRemapConfiguration());

		Assert.That(File.ReadAllText(fixture.Prefab), Does.Contain($"guid: {OfficialFontGuid}"));
	}

	[Test]
	public void AnAssetTheGameOwnsIsLeftAlone()
	{
		using Fixture fixture = Build();
		Run(fixture, new PackageRemapConfiguration());

		Assert.Multiple(() =>
		{
			Assert.That(File.ReadAllText(fixture.Prefab), Does.Contain($"guid: {GameAssetGuid}"));
			Assert.That(File.Exists(fixture.GameAsset), Is.True);
		});
	}

	/// <summary>
	/// Repointing references is only half the job. Leaving the ripped assembly behind means Unity loads
	/// it alongside the one it compiles from the package and every type exists twice.
	/// </summary>
	[Test]
	public void TheFilesThePackageReplacesAreDeleted()
	{
		using Fixture fixture = Build();
		Run(fixture, new PackageRemapConfiguration());

		Assert.Multiple(() =>
		{
			Assert.That(File.Exists(fixture.RippedAssembly), Is.False);
			Assert.That(File.Exists(fixture.RippedAssembly + ".meta"), Is.False);
			Assert.That(File.Exists(fixture.RippedShader), Is.False);
			Assert.That(File.Exists(fixture.RippedFont), Is.False);
		});
	}

	[Test]
	public void ThePackageIsAddedToTheProjectManifest()
	{
		using Fixture fixture = Build();
		Run(fixture, new PackageRemapConfiguration());

		Assert.That(File.ReadAllText(fixture.ManifestPath), Does.Contain($"\"{PackageName}\": \"{PackageVersion}\""));
	}

	/// <summary>
	/// Deleting is the part someone might not want, so it is the part that can be turned off.
	/// </summary>
	[Test]
	public void DeletingCanBeTurnedOff()
	{
		using Fixture fixture = Build();
		Run(fixture, new PackageRemapConfiguration { DeleteRippedCopies = false });

		Assert.Multiple(() =>
		{
			Assert.That(File.Exists(fixture.RippedAssembly), Is.True);
			Assert.That(File.ReadAllText(fixture.Prefab), Does.Contain(OfficialScriptGuid), "the references are still repointed");
			Assert.That(File.ReadAllText(fixture.ManifestPath), Does.Contain(PackageName));
		});
	}

	[Test]
	public void APackageCanBeSkipped()
	{
		using Fixture fixture = Build();
		PackageRemapConfiguration configuration = new();
		configuration.Packages.Add(new PackageRemapEntry { Name = PackageName, Skip = true });

		Run(fixture, configuration);

		Assert.Multiple(() =>
		{
			Assert.That(File.Exists(fixture.RippedAssembly), Is.True);
			Assert.That(File.ReadAllText(fixture.Prefab), Does.Contain(RippedAssemblyGuid));
		});
	}

	[Test]
	public void TheRunRecordsWhatItFound()
	{
		using Fixture fixture = Build();
		PackageRemapConfiguration configuration = new();
		PackageRemapRun run = Run(fixture, configuration);

		PackageOutcome outcome = run.Outcomes.Single();

		Assert.Multiple(() =>
		{
			Assert.That(outcome.TypesPaired, Is.EqualTo(1));
			Assert.That(outcome.AssembliesPaired, Is.Zero, "the package ships no assembly to pair one against");
			Assert.That(outcome.ShadersPaired, Is.EqualTo(1));
			Assert.That(outcome.OtherAssetsPaired, Is.EqualTo(1));
			Assert.That(configuration.Find(PackageName)?.Version, Is.EqualTo(PackageVersion));
		});
	}

	[Test]
	public void TheConfigurationRoundTripsThroughItsFile()
	{
		using Fixture fixture = Build();
		PackageRemapConfiguration written = new() { DeleteRippedCopies = false };
		written.Packages.Add(new PackageRemapEntry { Name = PackageName, Version = "1.2.3", Skip = true });
		written.Save(fixture.ConfigurationPath);

		PackageRemapConfiguration read = PackageRemapConfiguration.Load(fixture.ConfigurationPath);
		PackageRemapEntry? entry = read.Find(PackageName);

		Assert.Multiple(() =>
		{
			Assert.That(read.DeleteRippedCopies, Is.False);
			Assert.That(entry, Is.Not.Null);
			Assert.That(entry!.Version, Is.EqualTo("1.2.3"));
			Assert.That(entry.Skip, Is.True);
		});
	}

	/// <summary>
	/// A file that cannot be parsed should not stop an export.
	/// </summary>
	[Test]
	public void AMalformedConfigurationFallsBackToTheDefaults()
	{
		using Fixture fixture = Build();
		File.WriteAllText(fixture.ConfigurationPath, "{ not json");

		Assert.That(PackageRemapConfiguration.Load(fixture.ConfigurationPath).DeleteRippedCopies, Is.True);
	}

	/// <summary>
	/// A file name that occurs twice on either side identifies nothing, and pairing the wrong two assets
	/// would repoint references at something unrelated.
	/// </summary>
	[Test]
	public void ADuplicatedFileNamePairsNothing()
	{
		using Fixture fixture = Build();
		Write(Path.Combine(fixture.AssetsPath, "Texture2D", "LiberationSans.ttf"), "other", "cccccccccccccccccccccccccccccccc");

		Run(fixture, new PackageRemapConfiguration());

		Assert.Multiple(() =>
		{
			Assert.That(File.ReadAllText(fixture.Prefab), Does.Contain($"guid: {RippedFontGuid}"), "the ambiguous font is not repointed");
			Assert.That(File.Exists(fixture.RippedFont), Is.True);
			Assert.That(File.ReadAllText(fixture.Prefab), Does.Contain(OfficialScriptGuid), "the script is unaffected");
		});
	}
}
