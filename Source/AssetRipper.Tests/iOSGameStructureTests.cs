using AssetRipper.Import.Platforms;
using AssetRipper.Import.Structure.Assembly;
using AssetRipper.Import.Structure.Platforms;
using AssetRipper.IO.Files;

namespace AssetRipper.Tests;

public class iOSGameStructureTests
{
	private const string Root = "/ipa";
	private const string AppName = "JellyBlast";

	private static string AppPath(VirtualFileSystem fs) => fs.Path.Join(Root, "Payload", $"{AppName}.app");

	private static VirtualFileSystem CreateFileSystem(bool withUnityFramework)
	{
		VirtualFileSystem fs = new();
		string app = AppPath(fs);
		string data = fs.Path.Join(app, "Data");
		string managed = fs.Path.Join(data, "Managed");

		fs.Directory.Create(fs.Path.Join(managed, "Metadata"));
		fs.File.WriteAllBytes(fs.Path.Join(managed, "Metadata", "global-metadata.dat"), [0]);

		// The launcher executable, which is present whether or not the player is in a framework.
		fs.File.WriteAllBytes(fs.Path.Join(app, AppName), [0]);

		if (withUnityFramework)
		{
			string framework = fs.Path.Join(app, "Frameworks", "UnityFramework.framework");
			fs.Directory.Create(framework);
			fs.File.WriteAllBytes(fs.Path.Join(framework, "UnityFramework"), [0]);
		}

		return fs;
	}

	private static PlatformGameStructure? Detect(VirtualFileSystem fs)
	{
		List<string> paths = [Root];
		PlatformChecker.CheckPlatform(paths, fs, out PlatformGameStructure? platform, out _);
		return platform;
	}

	/// <summary>
	/// Unity 2019.3 moved every generated method body into UnityFramework, leaving a launcher of a few
	/// tens of kilobytes behind. Taking the launcher is not a worse import but no import at all: no code
	/// registration is found in it, initialisation throws, and the run falls back to the Unknown
	/// scripting backend with no scripts exported.
	/// </summary>
	[Test]
	public void UnityFrameworkIsPreferredOverTheLauncherExecutable()
	{
		VirtualFileSystem fs = CreateFileSystem(withUnityFramework: true);
		PlatformGameStructure? platform = Detect(fs);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(platform, Is.Not.Null);
			Assert.That(platform!.GetType().Name, Is.EqualTo("iOSGameStructure"));
			Assert.That(platform.Il2CppGameAssemblyPath,
				Is.EqualTo(fs.Path.Join(AppPath(fs), "Frameworks", "UnityFramework.framework", "UnityFramework")));
			Assert.That(platform.Backend, Is.EqualTo(ScriptingBackend.IL2Cpp));
		}
	}

	/// <summary>Before 2019.3 there is no framework and the app's own executable really is the binary.</summary>
	[Test]
	public void TheExecutableIsUsedWhenThereIsNoUnityFramework()
	{
		VirtualFileSystem fs = CreateFileSystem(withUnityFramework: false);
		PlatformGameStructure? platform = Detect(fs);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(platform, Is.Not.Null);
			Assert.That(platform!.Il2CppGameAssemblyPath, Is.EqualTo(fs.Path.Join(AppPath(fs), AppName)));
			Assert.That(platform.Backend, Is.EqualTo(ScriptingBackend.IL2Cpp));
		}
	}

	/// <summary>
	/// The streaming assets are inside the app's Data directory, not beside Payload, so the path built
	/// from the root pointed at nothing and every streamed asset was silently absent.
	/// </summary>
	[Test]
	public void StreamingAssetsAreUnderTheDataDirectory()
	{
		VirtualFileSystem fs = CreateFileSystem(withUnityFramework: true);
		PlatformGameStructure? platform = Detect(fs);

		Assert.That(platform!.StreamingAssetsPath, Is.EqualTo(fs.Path.Join(AppPath(fs), "Data", "Raw")));
	}
}
