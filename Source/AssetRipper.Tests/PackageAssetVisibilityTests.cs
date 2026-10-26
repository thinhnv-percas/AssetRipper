using AssetRipper.Export.Configuration;
using AssetRipper.Export.UnityProjects.PackageRemapping;
using AssetRipper.IO.Files;

namespace AssetRipper.Tests;

/// <summary>
/// A ripped asset came out of a build, so it can only pair with a package file a build can carry.
/// </summary>
public sealed class PackageAssetVisibilityTests
{
	[TestCase("Runtime/Textures/BayerMatrix.png", true)]
	[TestCase("Samples~/Common/TextMesh Pro/Resources/TMP Settings.asset", false)]
	[TestCase("Documentation~/images/a.png", false)]
	[TestCase(".hidden/a.png", false)]
	[TestCase("Runtime/cvs/a.png", false)]
	[TestCase("Runtime/a.png.tmp", false)]
	[TestCase(@"Samples~\Lens\Ring.png", false)]
	public void WhatUnityImports(string relative, bool expected)
	{
		Assert.That(PackageAssetVisibility.IsImported(relative), Is.EqualTo(expected));
	}

	[TestCase("Runtime/Textures/BayerMatrix.png", true)]
	[TestCase("DemiLib/Core/Editor/Imgs/circle.png", false)]
	[TestCase("Editor/LookDev/Icons/Link.png", false)]
	[TestCase("Samples~/Textures/Ring.png", false)]
	[TestCase("Runtime/Editor.png", true)]
	public void WhatABuildCanCarry(string relative, bool expected)
	{
		Assert.That(PackageAssetVisibility.CanBeInBuild(relative), Is.EqualTo(expected));
	}

	[Test]
	public void AGameAssetIsNotPairedWithASampleOrAnEditorAssetOfTheSameName()
	{
		string root = Directory.CreateTempSubdirectory("AssetRipperVisibility").FullName;
		try
		{
			string assets = Path.Combine(root, "Export", "ExportedProject", "Assets");
			string package = Path.Combine(root, "Cache", "com.unity.render-pipelines.core");
			Write(Path.Combine(package, "package.json"), "{\"name\":\"com.unity.render-pipelines.core\",\"version\":\"17.3.0\"}\n");
			Write(Path.Combine(package, "Samples~", "Common", "Resources", "TMP Settings.asset"), "x", "a0000000000000000000000000000001");
			Write(Path.Combine(package, "Editor", "Icons", "Link.png"), "x", "a0000000000000000000000000000002");
			Write(Path.Combine(package, "Runtime", "Textures", "BayerMatrix.png"), "x", "a0000000000000000000000000000003");
			Write(Path.Combine(assets, "Resources", "TMP Settings.asset"), "x", "b0000000000000000000000000000001");
			Write(Path.Combine(assets, "Texture2D", "Link.png"), "x", "b0000000000000000000000000000002");
			Write(Path.Combine(assets, "Texture2D", "BayerMatrix.png"), "x", "b0000000000000000000000000000003");

			List<ExportMatch> matches = ExportPackageMatcher.Match(assets, package, LocalFileSystem.Instance);

			Assert.That(matches.Select(m => Path.GetFileName(m.RippedPath)), Is.EquivalentTo(new[] { "BayerMatrix.png" }));
		}
		finally
		{
			Directory.Delete(root, recursive: true);
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
}
