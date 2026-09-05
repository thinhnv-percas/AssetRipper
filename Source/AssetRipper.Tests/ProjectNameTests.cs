using AssetRipper.Export.UnityProjects;
using AssetRipper.Import.Configuration;
using AssetRipper.IO.Files;

namespace AssetRipper.Tests;

/// <summary>
/// An export is named after whatever was loaded, so that several of them sitting beside each other are
/// telling apart.
/// </summary>
internal sealed class ProjectNameTests
{
	private static VirtualFileSystem WithDirectory(string path)
	{
		VirtualFileSystem fileSystem = new();
		fileSystem.Directory.Create(path);
		return fileSystem;
	}

	[Test]
	public void AFolderGivesItsOwnName()
	{
		Assert.That(ExportHandler.ChooseProjectName(["/games/SandLoop"], WithDirectory("/games/SandLoop")), Is.EqualTo("SandLoop"));
	}

	/// <summary>
	/// A path typed with a trailing separator names the same folder.
	/// </summary>
	[Test]
	public void ATrailingSeparatorIsIgnored()
	{
		Assert.That(ExportHandler.ChooseProjectName(["/games/SandLoop/"], WithDirectory("/games/SandLoop")), Is.EqualTo("SandLoop"));
	}

	[Test]
	public void AFileGivesItsNameWithoutTheExtension()
	{
		Assert.That(ExportHandler.ChooseProjectName(["/downloads/demo-android.apk"], new VirtualFileSystem()), Is.EqualTo("demo-android"));
	}

	/// <summary>
	/// Several paths at once give nothing to prefer over the others.
	/// </summary>
	[Test]
	public void SeveralPathsFallBack()
	{
		Assert.That(
			ExportHandler.ChooseProjectName(["/a/One", "/b/Two"], new VirtualFileSystem()),
			Is.EqualTo(CoreConfiguration.DefaultProjectName));
	}

	/// <summary>
	/// The name has to be one a folder can be created with.
	/// </summary>
	[TestCase("/")]
	[TestCase("")]
	public void APathWithNoNameFallsBack(string path)
	{
		Assert.That(ExportHandler.ChooseProjectName([path], new VirtualFileSystem()), Is.EqualTo(CoreConfiguration.DefaultProjectName));
	}

	/// <summary>
	/// The name goes through the same sanitising as every other name an export writes, which takes out
	/// the colon on every platform rather than only where the runtime calls it invalid.
	/// </summary>
	[Test]
	public void AnInvalidNameIsMadeUsable()
	{
		string name = ExportHandler.ChooseProjectName(["/downloads/demo:android.apk"], new VirtualFileSystem());

		Assert.Multiple(() =>
		{
			Assert.That(name, Does.Not.Contain(':'));
			Assert.That(name, Is.EqualTo("demo_android"));
		});
	}
}
